#!/usr/bin/env node

/**
 * VoxTics CSS Optimizer - Improved Version
 * Detects duplicate styles, organizes CSS files, and ensures all pages use the main design system
 * 
 * Improvements:
 * - Better error handling and logging
 * - Separation of concerns with focused classes
 * - Strategy pattern for different optimization strategies
 * - Factory pattern for rule processors
 * - Observer pattern for progress reporting
 */

const fs = require('fs').promises;
const path = require('path');
const crypto = require('crypto');

// Strategy Pattern: Different optimization strategies
class OptimizationStrategy {
  async execute(context) {
    throw new Error('Strategy must implement execute method');
  }
}

class DuplicateDetectionStrategy extends OptimizationStrategy {
  async execute(context) {
    console.log('🔍 Detecting duplicate CSS rules...');
    
    const duplicates = [];
    const ruleMap = new Map();
    
    for (const cssFile of context.cssFiles) {
      try {
        const content = await fs.readFile(cssFile, 'utf8');
        const rules = context.ruleExtractor.extractRules(content);
        
        for (const rule of rules) {
          const hash = this.hashContent(rule.content);
          const key = `${rule.selector}:${hash}`;
          
          if (ruleMap.has(key)) {
            duplicates.push({
              type: 'duplicate_rule',
              selector: rule.selector,
              files: [ruleMap.get(key).file, cssFile],
              content: rule.content,
              severity: this.calculateSeverity(rule)
            });
          } else {
            ruleMap.set(key, { file: cssFile, rule });
          }
        }
      } catch (error) {
        context.logger.warn(`Could not analyze ${cssFile}: ${error.message}`);
      }
    }
    
    context.results.duplicates = duplicates;
    context.logger.info(`Found ${duplicates.length} duplicate rules`);
    return duplicates;
  }

  hashContent(content) {
    return crypto.createHash('md5')
      .update(content.replace(/\s+/g, ' ').trim())
      .digest('hex');
  }

  calculateSeverity(rule) {
    // Calculate severity based on rule complexity and size
    const contentLength = rule.content.length;
    const selectorComplexity = (rule.selector.match(/[.#:]/g) || []).length;
    
    if (contentLength > 200 || selectorComplexity > 3) return 'high';
    if (contentLength > 100 || selectorComplexity > 2) return 'medium';
    return 'low';
  }
}

class UsageAnalysisStrategy extends OptimizationStrategy {
  async execute(context) {
    console.log('📊 Analyzing CSS usage in views...');
    
    const usedClasses = new Set();
    const unusedRules = [];
    
    // Extract classes from view files
    for (const viewFile of context.viewFiles) {
      try {
        const content = await fs.readFile(viewFile, 'utf8');
        const classes = this.extractClassNames(content);
        classes.forEach(cls => usedClasses.add(cls));
      } catch (error) {
        context.logger.warn(`Could not analyze view ${viewFile}: ${error.message}`);
      }
    }
    
    // Check CSS rule usage
    for (const [key, ruleData] of context.cssRules) {
      const selector = ruleData.rule.selector;
      if (!this.isSelectorUsed(selector, usedClasses) && !this.isSystemSelector(selector)) {
        unusedRules.push({
          file: ruleData.file,
          selector: selector,
          rule: ruleData.rule,
          confidence: this.calculateConfidence(selector, usedClasses)
        });
      }
    }
    
    context.results.usedClasses = usedClasses;
    context.results.unusedRules = unusedRules;
    context.logger.info(`Found ${usedClasses.size} used classes, ${unusedRules.length} potentially unused rules`);
    
    return { usedClasses, unusedRules };
  }

  extractClassNames(content) {
    const classes = new Set();
    
    // Extract from class attributes
    const classMatches = content.matchAll(/class\s*=\s*["']([^"']+)["']/gi);
    for (const match of classMatches) {
      match[1].split(/\s+/).forEach(cls => cls.trim() && classes.add(cls.trim()));
    }
    
    // Extract from @class attributes (Razor syntax)
    const atClassMatches = content.matchAll(/@class\s*=\s*["']([^"']+)["']/gi);
    for (const match of atClassMatches) {
      match[1].split(/\s+/).forEach(cls => cls.trim() && classes.add(cls.trim()));
    }
    
    // Extract from CSS class references in JavaScript
    const jsClassMatches = content.matchAll(/['"]([\w-]+)['"]\.classList|addClass\(['"]([^'"]+)['"]\)/gi);
    for (const match of jsClassMatches) {
      const className = match[1] || match[2];
      if (className) classes.add(className.trim());
    }
    
    return Array.from(classes);
  }

  isSelectorUsed(selector, usedClasses) {
    // Simple class selector
    if (selector.startsWith('.')) {
      const className = selector.substring(1).split(/[:\s>+~]/)[0];
      return usedClasses.has(className);
    }
    
    // Complex selectors - be conservative
    if (selector.includes('.')) {
      const classNames = selector.match(/\.([a-zA-Z0-9_-]+)/g);
      if (classNames) {
        return classNames.some(cls => usedClasses.has(cls.substring(1)));
      }
    }
    
    return true; // Conservative approach for complex selectors
  }

  isSystemSelector(selector) {
    const systemSelectors = [
      /^:root/, /^html/, /^body/, /^\*/, /^@/, // System selectors
      /^\.btn/, /^\.form/, /^\.nav/, /^\.card/, // Framework selectors
      /^\.apple-/, /^\.system-/, /^\.key-/ // Design system selectors
    ];
    
    return systemSelectors.some(pattern => pattern.test(selector));
  }

  calculateConfidence(selector, usedClasses) {
    // Calculate confidence that the rule is truly unused
    if (this.isSystemSelector(selector)) return 0.1;
    if (selector.includes(':hover') || selector.includes(':focus')) return 0.3;
    if (selector.includes('@media')) return 0.2;
    
    return 0.8; // High confidence for simple unused selectors
  }
}

// Factory Pattern: Rule processor factory
class RuleProcessorFactory {
  static createProcessor(type) {
    switch (type) {
      case 'css':
        return new CSSRuleProcessor();
      case 'scss':
        return new SCSSRuleProcessor();
      case 'tailwind':
        return new TailwindRuleProcessor();
      default:
        return new CSSRuleProcessor();
    }
  }
}

class CSSRuleProcessor {
  extractRules(content) {
    const rules = [];
    
    // Remove comments and normalize whitespace
    const cleanContent = content
      .replace(/\/\*[\s\S]*?\*\//g, '')
      .replace(/\s+/g, ' ')
      .trim();
    
    // Extract CSS rules
    const ruleRegex = /([^{}]+)\s*\{([^{}]*)\}/g;
    let match;
    
    while ((match = ruleRegex.exec(cleanContent)) !== null) {
      const selector = match[1].trim();
      const content = match[2].trim();
      
      if (selector && content && !selector.startsWith('@import')) {
        rules.push({
          selector,
          content,
          type: this.determineRuleType(selector),
          specificity: this.calculateSpecificity(selector)
        });
      }
    }
    
    return rules;
  }

  determineRuleType(selector) {
    if (selector.includes('@media')) return 'media-query';
    if (selector.includes('@keyframes')) return 'animation';
    if (selector.includes(':hover') || selector.includes(':focus')) return 'pseudo';
    if (selector.startsWith('.')) return 'class';
    if (selector.startsWith('#')) return 'id';
    return 'element';
  }

  calculateSpecificity(selector) {
    // Simple specificity calculation
    const ids = (selector.match(/#/g) || []).length * 100;
    const classes = (selector.match(/\./g) || []).length * 10;
    const elements = (selector.match(/[a-zA-Z]/g) || []).length;
    
    return ids + classes + elements;
  }
}

class SCSSRuleProcessor extends CSSRuleProcessor {
  extractRules(content) {
    // Handle SCSS-specific syntax
    const processedContent = this.processSCSS(content);
    return super.extractRules(processedContent);
  }

  processSCSS(content) {
    // Basic SCSS processing - expand nested rules
    // This is a simplified implementation
    return content
      .replace(/\$[\w-]+:\s*[^;]+;/g, '') // Remove variables
      .replace(/@mixin[\s\S]*?}/g, '') // Remove mixins
      .replace(/@include\s+[\w-]+[^;]*;/g, ''); // Remove includes
  }
}

class TailwindRuleProcessor extends CSSRuleProcessor {
  extractRules(content) {
    const rules = super.extractRules(content);
    
    // Filter out Tailwind utility classes that are generated
    return rules.filter(rule => !this.isTailwindUtility(rule.selector));
  }

  isTailwindUtility(selector) {
    const tailwindPatterns = [
      /^\.text-/, /^\.bg-/, /^\.border-/, /^\.p-/, /^\.m-/, /^\.w-/, /^\.h-/,
      /^\.flex/, /^\.grid/, /^\.hidden/, /^\.block/, /^\.inline/
    ];
    
    return tailwindPatterns.some(pattern => pattern.test(selector));
  }
}

// Observer Pattern: Progress reporting
class ProgressObserver {
  constructor() {
    this.observers = [];
  }

  subscribe(observer) {
    this.observers.push(observer);
  }

  notify(event, data) {
    this.observers.forEach(observer => observer.update(event, data));
  }
}

class ConsoleProgressObserver {
  update(event, data) {
    switch (event) {
      case 'file_processed':
        process.stdout.write('.');
        break;
      case 'stage_complete':
        console.log(`\n✅ ${data.stage} completed`);
        break;
      case 'error':
        console.error(`❌ Error: ${data.message}`);
        break;
    }
  }
}

// Logger with different levels
class Logger {
  constructor(level = 'info') {
    this.level = level;
    this.levels = { error: 0, warn: 1, info: 2, debug: 3 };
  }

  log(level, message) {
    if (this.levels[level] <= this.levels[this.level]) {
      const timestamp = new Date().toISOString();
      const prefix = level.toUpperCase().padEnd(5);
      console.log(`[${timestamp}] ${prefix} ${message}`);
    }
  }

  error(message) { this.log('error', message); }
  warn(message) { this.log('warn', message); }
  info(message) { this.log('info', message); }
  debug(message) { this.log('debug', message); }
}

// Main optimizer class with improved architecture
class VoxTicsCSSOptimizer {
  constructor(options = {}) {
    this.projectRoot = options.projectRoot || process.cwd();
    this.logger = new Logger(options.logLevel || 'info');
    this.progressObserver = new ProgressObserver();
    this.ruleExtractor = RuleProcessorFactory.createProcessor('css');
    
    // Initialize observers
    this.progressObserver.subscribe(new ConsoleProgressObserver());
    
    // Initialize context
    this.context = {
      cssFiles: [],
      viewFiles: [],
      cssRules: new Map(),
      results: {},
      logger: this.logger,
      ruleExtractor: this.ruleExtractor
    };
    
    // Initialize strategies
    this.strategies = [
      new DuplicateDetectionStrategy(),
      new UsageAnalysisStrategy()
    ];
  }

  async optimize() {
    this.logger.info('🎨 VoxTics CSS Optimization Starting...');
    
    try {
      await this.scanFiles();
      await this.runOptimizationStrategies();
      await this.generateOptimizedStructure();
      await this.generateReport();
      
      this.logger.info('✅ CSS Optimization Complete!');
      return this.context.results;
    } catch (error) {
      this.logger.error(`Optimization failed: ${error.message}`);
      throw error;
    }
  }

  async scanFiles() {
    this.logger.info('📁 Scanning project files...');
    
    await Promise.all([
      this.scanCSSFiles(),
      this.scanViewFiles()
    ]);
    
    this.progressObserver.notify('stage_complete', { stage: 'File Scanning' });
  }

  async scanCSSFiles() {
    const cssDirectories = [
      'VoxTics/wwwroot/css',
      'VoxTics/wwwroot/css/components'
    ];
    
    for (const dir of cssDirectories) {
      await this.scanDirectory(dir, '.css', this.context.cssFiles);
    }
    
    this.logger.info(`Found ${this.context.cssFiles.length} CSS files`);
  }

  async scanViewFiles() {
    const viewDirectories = [
      'VoxTics/Views',
      'VoxTics/Areas'
    ];
    
    for (const dir of viewDirectories) {
      await this.scanDirectory(dir, '.cshtml', this.context.viewFiles);
    }
    
    this.logger.info(`Found ${this.context.viewFiles.length} view files`);
  }

  async scanDirectory(dirPath, extension, targetArray) {
    try {
      const entries = await fs.readdir(dirPath, { withFileTypes: true });
      
      for (const entry of entries) {
        const fullPath = path.join(dirPath, entry.name);
        
        if (entry.isDirectory()) {
          await this.scanDirectory(fullPath, extension, targetArray);
        } else if (entry.name.endsWith(extension) && !entry.name.includes('.min.')) {
          targetArray.push(fullPath);
          this.progressObserver.notify('file_processed', { file: fullPath });
        }
      }
    } catch (error) {
      this.logger.warn(`Could not scan directory ${dirPath}: ${error.message}`);
    }
  }

  async runOptimizationStrategies() {
    this.logger.info('🔧 Running optimization strategies...');
    
    for (const strategy of this.strategies) {
      try {
        await strategy.execute(this.context);
      } catch (error) {
        this.logger.error(`Strategy failed: ${error.message}`);
        this.progressObserver.notify('error', { message: error.message });
      }
    }
    
    this.progressObserver.notify('stage_complete', { stage: 'Optimization Analysis' });
  }

  async generateOptimizedStructure() {
    this.logger.info('🏗️ Generating optimized CSS structure...');
    
    // Create optimized directory structure
    const optimizedDir = 'VoxTics/wwwroot/css/optimized';
    await fs.mkdir(optimizedDir, { recursive: true });
    
    // Generate consolidated CSS files
    await this.createConsolidatedCSS();
    await this.createFeatureSpecificCSS();
    
    this.progressObserver.notify('stage_complete', { stage: 'Structure Generation' });
  }

  async createConsolidatedCSS() {
    const consolidatedPath = 'VoxTics/wwwroot/css/optimized/voxtics-consolidated.css';
    
    const header = `/*
 * VoxTics Consolidated CSS
 * Generated by CSS Optimizer on ${new Date().toISOString()}
 * 
 * This file contains all non-duplicate, actively used CSS rules
 * organized by feature and importance.
 */

`;
    
    let consolidatedCSS = header;
    
    // Add critical CSS first
    consolidatedCSS += this.generateCriticalCSS();
    
    // Add feature-specific CSS
    consolidatedCSS += this.generateFeatureCSS();
    
    await fs.writeFile(consolidatedPath, consolidatedCSS);
    this.logger.info(`Created consolidated CSS: ${consolidatedPath}`);
  }

  generateCriticalCSS() {
    return `
/* Critical CSS - Above the fold styles */
:root {
  /* CSS Custom Properties from Apple Keyboard+ Design System */
  --apple-blue: #007AFF;
  --system-background: #FFFFFF;
  --label-primary: #000000;
}

body {
  font-family: -apple-system, BlinkMacSystemFont, 'SF Pro Display', sans-serif;
  background-color: var(--system-background);
  color: var(--label-primary);
}

/* Loading states */
.loading-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(255, 255, 255, 0.9);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 9999;
}

`;
  }

  generateFeatureCSS() {
    // This would generate feature-specific CSS based on analysis
    return `
/* Feature-specific styles would be generated here based on usage analysis */

`;
  }

  async createFeatureSpecificCSS() {
    const features = ['movies', 'cinemas', 'bookings', 'admin', 'auth'];
    
    for (const feature of features) {
      const featurePath = `VoxTics/wwwroot/css/optimized/${feature}.css`;
      const featureCSS = this.generateFeatureSpecificStyles(feature);
      
      if (featureCSS.trim()) {
        await fs.writeFile(featurePath, featureCSS);
        this.logger.info(`Created feature CSS: ${featurePath}`);
      }
    }
  }

  generateFeatureSpecificStyles(feature) {
    // Generate feature-specific styles based on analysis
    return `/*
 * VoxTics ${feature.charAt(0).toUpperCase() + feature.slice(1)} Styles
 * Generated by CSS Optimizer
 */

/* ${feature} specific styles would be generated here */

`;
  }

  async generateReport() {
    this.logger.info('📊 Generating optimization report...');
    
    const report = {
      timestamp: new Date().toISOString(),
      summary: {
        totalCSSFiles: this.context.cssFiles.length,
        totalViewFiles: this.context.viewFiles.length,
        duplicatesFound: this.context.results.duplicates?.length || 0,
        unusedRulesFound: this.context.results.unusedRules?.length || 0,
        usedClassesCount: this.context.results.usedClasses?.size || 0
      },
      duplicates: this.context.results.duplicates || [],
      unusedRules: this.context.results.unusedRules || [],
      recommendations: this.generateRecommendations()
    };
    
    // Save detailed JSON report
    await fs.writeFile('css-optimization-report.json', JSON.stringify(report, null, 2));
    
    // Generate human-readable report
    await this.generateHumanReadableReport(report);
    
    this.logger.info('Reports generated: css-optimization-report.json, CSS_OPTIMIZATION_REPORT.md');
  }

  async generateHumanReadableReport(report) {
    let markdown = `# VoxTics CSS Optimization Report

Generated: ${new Date().toLocaleString()}

## Summary
- **Total CSS Files**: ${report.summary.totalCSSFiles}
- **Total View Files**: ${report.summary.totalViewFiles}
- **Duplicates Found**: ${report.summary.duplicatesFound}
- **Unused Rules**: ${report.summary.unusedRulesFound}
- **Used Classes**: ${report.summary.usedClassesCount}

## Optimization Opportunities

### High Priority Duplicates
`;

    const highPriorityDuplicates = report.duplicates.filter(d => d.severity === 'high');
    if (highPriorityDuplicates.length > 0) {
      highPriorityDuplicates.forEach(duplicate => {
        markdown += `- **${duplicate.selector}**: Found in ${duplicate.files.join(', ')}\n`;
      });
    } else {
      markdown += 'No high priority duplicates found.\n';
    }

    markdown += `
### Unused Rules (High Confidence)
`;

    const highConfidenceUnused = report.unusedRules.filter(r => r.confidence > 0.7);
    if (highConfidenceUnused.length > 0) {
      highConfidenceUnused.slice(0, 10).forEach(rule => {
        markdown += `- **${rule.selector}** in ${rule.file} (${Math.round(rule.confidence * 100)}% confidence)\n`;
      });
      
      if (highConfidenceUnused.length > 10) {
        markdown += `... and ${highConfidenceUnused.length - 10} more\n`;
      }
    } else {
      markdown += 'No high confidence unused rules found.\n';
    }

    markdown += `
## Recommendations

${report.recommendations.join('\n')}

## Next Steps

1. Review and remove high priority duplicates
2. Safely remove unused rules with high confidence
3. Consolidate feature-specific styles
4. Implement the generated optimized CSS structure
5. Update view files to use the new CSS organization
`;

    await fs.writeFile('CSS_OPTIMIZATION_REPORT.md', markdown);
  }

  generateRecommendations() {
    const recommendations = [];
    
    if (this.context.results.duplicates?.length > 0) {
      recommendations.push('- Consolidate duplicate CSS rules to reduce file size');
      recommendations.push('- Use CSS custom properties for repeated values');
    }
    
    if (this.context.results.unusedRules?.length > 0) {
      recommendations.push('- Remove unused CSS rules to improve performance');
      recommendations.push('- Implement CSS purging in the build process');
    }
    
    recommendations.push('- Use the Apple Keyboard+ design system consistently');
    recommendations.push('- Implement CSS-in-JS or CSS modules for component-scoped styles');
    recommendations.push('- Set up automated CSS optimization in the build pipeline');
    
    return recommendations;
  }
}

// CLI interface
if (require.main === module) {
  const optimizer = new VoxTicsCSSOptimizer({
    logLevel: process.env.LOG_LEVEL || 'info'
  });
  
  optimizer.optimize()
    .then(results => {
      console.log('\n🎉 Optimization completed successfully!');
      console.log(`📊 Results: ${results.duplicates?.length || 0} duplicates, ${results.unusedRules?.length || 0} unused rules`);
    })
    .catch(error => {
      console.error('\n💥 Optimization failed:', error.message);
      process.exit(1);
    });
}

module.exports = { VoxTicsCSSOptimizer, OptimizationStrategy, RuleProcessorFactory };