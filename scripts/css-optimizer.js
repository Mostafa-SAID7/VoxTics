#!/usr/bin/env node

/**
 * VoxTics CSS Optimizer
 * Detects duplicate styles, organizes CSS files, and ensures all pages use the main design system
 */

const fs = require('fs').promises;
const path = require('path');
const crypto = require('crypto');

class VoxTicsCSSOptimizer {
  constructor() {
    this.projectRoot = process.cwd();
    this.cssFiles = [];
    this.duplicates = [];
    this.unusedFiles = [];
    this.viewFiles = [];
    this.cssRules = new Map();
    this.selectorUsage = new Map();
  }

  async optimize() {
    console.log('🎨 VoxTics CSS Optimization Starting...\n');
    
    try {
      await this.scanCSSFiles();
      await this.scanViewFiles();
      await this.detectDuplicates();
      await this.analyzeUsage();
      await this.createOptimizedStructure();
      await this.updateViewReferences();
      await this.generateReport();
      
      console.log('✅ CSS Optimization Complete!\n');
    } catch (error) {
      console.error('❌ Optimization failed:', error.message);
      process.exit(1);
    }
  }

  async scanCSSFiles() {
    console.log('📁 Scanning CSS files...');
    
    const cssDirectories = [
      'VoxTics/wwwroot/css',
      'VoxTics/wwwroot/css/components',
      'VoxTics/wwwroot/css/legacy-backup'
    ];
    
    for (const dir of cssDirectories) {
      try {
        await this.scanDirectory(dir);
      } catch (error) {
        console.warn(`⚠️  Could not scan ${dir}: ${error.message}`);
      }
    }
    
    console.log(`   Found ${this.cssFiles.length} CSS files`);
  }

  async scanDirectory(dirPath) {
    try {
      const entries = await fs.readdir(dirPath, { withFileTypes: true });
      
      for (const entry of entries) {
        const fullPath = path.join(dirPath, entry.name);
        
        if (entry.isDirectory()) {
          await this.scanDirectory(fullPath);
        } else if (entry.name.endsWith('.css') && !entry.name.includes('.min.')) {
          this.cssFiles.push(fullPath);
        }
      }
    } catch (error) {
      // Directory doesn't exist, skip
    }
  }

  async scanViewFiles() {
    console.log('📄 Scanning Razor view files...');
    
    const viewDirectories = [
      'VoxTics/Views',
      'VoxTics/Areas'
    ];
    
    for (const dir of viewDirectories) {
      try {
        await this.scanViewDirectory(dir);
      } catch (error) {
        console.warn(`⚠️  Could not scan ${dir}: ${error.message}`);
      }
    }
    
    console.log(`   Found ${this.viewFiles.length} view files`);
  }

  async scanViewDirectory(dirPath) {
    try {
      const entries = await fs.readdir(dirPath, { withFileTypes: true });
      
      for (const entry of entries) {
        const fullPath = path.join(dirPath, entry.name);
        
        if (entry.isDirectory()) {
          await this.scanViewDirectory(fullPath);
        } else if (entry.name.endsWith('.cshtml')) {
          this.viewFiles.push(fullPath);
        }
      }
    } catch (error) {
      // Directory doesn't exist, skip
    }
  }

  async detectDuplicates() {
    console.log('🔍 Detecting duplicate CSS rules...');
    
    for (const cssFile of this.cssFiles) {
      try {
        const content = await fs.readFile(cssFile, 'utf8');
        const rules = this.extractCSSRules(content);
        
        for (const rule of rules) {
          const hash = this.hashContent(rule.content);
          const key = `${rule.selector}:${hash}`;
          
          if (this.cssRules.has(key)) {
            this.duplicates.push({
              type: 'duplicate_rule',
              selector: rule.selector,
              files: [this.cssRules.get(key).file, cssFile],
              content: rule.content
            });
          } else {
            this.cssRules.set(key, { file: cssFile, rule });
          }
        }
      } catch (error) {
        console.warn(`⚠️  Could not analyze ${cssFile}: ${error.message}`);
      }
    }
    
    console.log(`   Found ${this.duplicates.length} duplicate rules`);
  }

  async analyzeUsage() {
    console.log('📊 Analyzing CSS usage in views...');
    
    // Extract all class names from view files
    const usedClasses = new Set();
    
    for (const viewFile of this.viewFiles) {
      try {
        const content = await fs.readFile(viewFile, 'utf8');
        
        // Extract classes from class attributes
        const classMatches = content.matchAll(/class\s*=\s*["']([^"']+)["']/g);
        for (const match of classMatches) {
          const classes = match[1].split(/\s+/);
          classes.forEach(cls => cls && usedClasses.add(cls.trim()));
        }
        
        // Extract classes from @class attributes (Razor syntax)
        const atClassMatches = content.matchAll(/@class\s*=\s*["']([^"']+)["']/g);
        for (const match of atClassMatches) {
          const classes = match[1].split(/\s+/);
          classes.forEach(cls => cls && usedClasses.add(cls.trim()));
        }
      } catch (error) {
        console.warn(`⚠️  Could not analyze ${viewFile}: ${error.message}`);
      }
    }
    
    // Check which CSS selectors are actually used
    for (const [key, ruleData] of this.cssRules) {
      const selector = ruleData.rule.selector;
      const isUsed = this.isSelectorUsed(selector, usedClasses);
      
      if (!isUsed && !this.isSystemSelector(selector)) {
        this.unusedFiles.push({
          file: ruleData.file,
          selector: selector,
          rule: ruleData.rule
        });
      }
    }
    
    console.log(`   Found ${usedClasses.size} used classes`);
    console.log(`   Found ${this.unusedFiles.length} potentially unused rules`);
  }

  async createOptimizedStructure() {
    console.log('🏗️  Creating optimized CSS structure...');
    
    // Create feature-based CSS organization
    const featureStyles = {
      'movies': [],
      'cinemas': [],
      'bookings': [],
      'admin': [],
      'auth': [],
      'shared': []
    };
    
    // Categorize CSS rules by feature
    for (const [key, ruleData] of this.cssRules) {
      const feature = this.categorizeRule(ruleData.rule.selector, ruleData.file);
      if (featureStyles[feature]) {
        featureStyles[feature].push(ruleData.rule);
      } else {
        featureStyles['shared'].push(ruleData.rule);
      }
    }
    
    // Create feature-specific CSS files
    for (const [feature, rules] of Object.entries(featureStyles)) {
      if (rules.length > 0) {
        await this.createFeatureCSS(feature, rules);
      }
    }
    
    // Create main consolidated CSS file
    await this.createMainCSS();
  }

  async createFeatureCSS(feature, rules) {
    const fileName = `VoxTics/wwwroot/css/features/${feature}.css`;
    
    // Ensure directory exists
    await fs.mkdir(path.dirname(fileName), { recursive: true });
    
    let cssContent = `/*\n * VoxTics ${feature.charAt(0).toUpperCase() + feature.slice(1)} Styles\n * Generated by CSS Optimizer\n */\n\n`;
    
    // Group rules by type
    const groupedRules = this.groupRulesByType(rules);
    
    for (const [type, typeRules] of Object.entries(groupedRules)) {
      if (typeRules.length > 0) {
        cssContent += `/* ${type} */\n`;
        for (const rule of typeRules) {
          cssContent += `${rule.selector} {\n${rule.content}\n}\n\n`;
        }
      }
    }
    
    await fs.writeFile(fileName, cssContent);
    console.log(`   Created ${fileName}`);
  }

  async createMainCSS() {
    const mainCSSPath = 'VoxTics/wwwroot/css/voxtics-main.css';
    
    const mainCSS = `/*
 * VoxTics Main CSS
 * Consolidated design system entry point
 * Generated by CSS Optimizer
 */

/* Core Design System */
@import url('apple-keyboard-plus.css');

/* TailwindCSS Integration */
@import url('input.css');

/* Feature-Specific Styles */
@import url('features/shared.css');
@import url('features/movies.css');
@import url('features/cinemas.css');
@import url('features/bookings.css');
@import url('features/admin.css');
@import url('features/auth.css');

/* Component Styles */
@import url('components/layout.css');
@import url('components/movies.css');
@import url('components/admin.css');

/* Utility Classes */
.voxtics-container {
  @apply container-apple;
}

.voxtics-card {
  @apply card glass-light hover-lift;
}

.voxtics-btn {
  @apply btn btn-primary focus-ring;
}

.voxtics-input {
  @apply input focus-ring;
}

/* Cinema-specific utilities */
.cinema-grid {
  @apply grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6;
}

.movie-grid {
  @apply grid grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 gap-4;
}

.booking-layout {
  @apply flex flex-col lg:flex-row gap-8;
}

/* Admin-specific utilities */
.admin-sidebar {
  @apply w-64 bg-system-background-secondary border-r border-separator;
}

.admin-content {
  @apply flex-1 p-6;
}

.admin-table {
  @apply table table-striped w-full;
}

/* Responsive utilities */
@media (max-width: 768px) {
  .cinema-grid {
    @apply grid-cols-1;
  }
  
  .movie-grid {
    @apply grid-cols-2;
  }
  
  .booking-layout {
    @apply flex-col;
  }
  
  .admin-sidebar {
    @apply w-full h-auto;
  }
}
`;

    await fs.writeFile(mainCSSPath, mainCSS);
    console.log(`   Created ${mainCSSPath}`);
  }

  async updateViewReferences() {
    console.log('🔄 Updating view file CSS references...');
    
    let updatedFiles = 0;
    
    for (const viewFile of this.viewFiles) {
      try {
        let content = await fs.readFile(viewFile, 'utf8');
        let modified = false;
        
        // Remove old CSS references
        const oldCSSReferences = [
          /<link[^>]*href="[^"]*\/css\/[^"]*\.css"[^>]*>/g,
          /@section\s+Styles\s*{[^}]*}/g,
          /@{[^}]*ViewData\["Title"\][^}]*}/g
        ];
        
        for (const regex of oldCSSReferences) {
          if (regex.test(content)) {
            content = content.replace(regex, '');
            modified = true;
          }
        }
        
        // Add reference to main CSS if it's a layout file
        if (viewFile.includes('_Layout.cshtml') || viewFile.includes('_AdminLayout.cshtml')) {
          const cssReference = `    <link rel="stylesheet" href="~/css/voxtics-main.css" asp-append-version="true" />`;
          
          if (!content.includes('voxtics-main.css')) {
            // Insert before closing </head>
            content = content.replace('</head>', `${cssReference}\n</head>`);
            modified = true;
          }
        }
        
        if (modified) {
          await fs.writeFile(viewFile, content);
          updatedFiles++;
        }
      } catch (error) {
        console.warn(`⚠️  Could not update ${viewFile}: ${error.message}`);
      }
    }
    
    console.log(`   Updated ${updatedFiles} view files`);
  }

  async generateReport() {
    const report = {
      timestamp: new Date().toISOString(),
      summary: {
        total_css_files: this.cssFiles.length,
        duplicate_rules: this.duplicates.length,
        unused_rules: this.unusedFiles.length,
        view_files_scanned: this.viewFiles.length
      },
      duplicates: this.duplicates,
      unused_rules: this.unusedFiles.slice(0, 50), // Limit to first 50
      recommendations: this.generateRecommendations()
    };
    
    await fs.writeFile('css-optimization-report.json', JSON.stringify(report, null, 2));
    
    // Generate human-readable report
    let readableReport = `# VoxTics CSS Optimization Report\n\n`;
    readableReport += `**Generated:** ${new Date().toLocaleString()}\n\n`;
    
    readableReport += `## Summary\n`;
    readableReport += `- Total CSS Files: ${report.summary.total_css_files}\n`;
    readableReport += `- Duplicate Rules: ${report.summary.duplicate_rules}\n`;
    readableReport += `- Unused Rules: ${report.summary.unused_rules}\n`;
    readableReport += `- View Files Scanned: ${report.summary.view_files_scanned}\n\n`;
    
    if (this.duplicates.length > 0) {
      readableReport += `## Duplicate Rules (Top 10)\n`;
      for (const duplicate of this.duplicates.slice(0, 10)) {
        readableReport += `- **${duplicate.selector}**\n`;
        readableReport += `  Files: ${duplicate.files.join(', ')}\n\n`;
      }
    }
    
    readableReport += `## Recommendations\n`;
    for (const recommendation of report.recommendations) {
      readableReport += `- ${recommendation}\n`;
    }
    
    readableReport += `\n## New CSS Structure\n`;
    readableReport += `\`\`\`\n`;
    readableReport += `VoxTics/wwwroot/css/\n`;
    readableReport += `├── voxtics-main.css          # Main entry point\n`;
    readableReport += `├── apple-keyboard-plus.css   # Design system\n`;
    readableReport += `├── input.css                 # TailwindCSS source\n`;
    readableReport += `├── components/               # Component styles\n`;
    readableReport += `│   ├── layout.css\n`;
    readableReport += `│   ├── movies.css\n`;
    readableReport += `│   └── admin.css\n`;
    readableReport += `└── features/                 # Feature-specific styles\n`;
    readableReport += `    ├── shared.css\n`;
    readableReport += `    ├── movies.css\n`;
    readableReport += `    ├── cinemas.css\n`;
    readableReport += `    ├── bookings.css\n`;
    readableReport += `    ├── admin.css\n`;
    readableReport += `    └── auth.css\n`;
    readableReport += `\`\`\`\n`;
    
    await fs.writeFile('CSS_OPTIMIZATION_REPORT.md', readableReport);
    
    console.log('📊 Reports generated: css-optimization-report.json, CSS_OPTIMIZATION_REPORT.md');
  }

  // Helper methods
  extractCSSRules(css) {
    const rules = [];
    const ruleRegex = /([^{}]+)\s*\{([^{}]*(?:\{[^{}]*\}[^{}]*)*)\}/g;
    let match;
    
    while ((match = ruleRegex.exec(css)) !== null) {
      const selector = match[1].trim();
      const content = match[2].trim();
      
      if (selector && content && !selector.startsWith('/*') && !selector.startsWith('@import')) {
        rules.push({ selector, content });
      }
    }
    
    return rules;
  }

  hashContent(content) {
    return crypto.createHash('md5').update(content.replace(/\s+/g, ' ').trim()).digest('hex');
  }

  isSelectorUsed(selector, usedClasses) {
    // Extract class names from CSS selector
    const classMatches = selector.match(/\.([a-zA-Z0-9_-]+)/g);
    if (!classMatches) return true; // Keep non-class selectors
    
    for (const classMatch of classMatches) {
      const className = classMatch.substring(1); // Remove the dot
      if (usedClasses.has(className)) {
        return true;
      }
    }
    
    return false;
  }

  isSystemSelector(selector) {
    const systemSelectors = [
      'html', 'body', '*', '::before', '::after', ':root',
      '@media', '@keyframes', '@supports', '@import'
    ];
    
    return systemSelectors.some(sys => selector.includes(sys));
  }

  categorizeRule(selector, filePath) {
    const fileName = path.basename(filePath).toLowerCase();
    
    if (fileName.includes('admin') || filePath.includes('/admin/')) return 'admin';
    if (fileName.includes('movie') || selector.includes('movie')) return 'movies';
    if (fileName.includes('cinema') || selector.includes('cinema')) return 'cinemas';
    if (fileName.includes('booking') || selector.includes('booking')) return 'bookings';
    if (fileName.includes('auth') || fileName.includes('login') || fileName.includes('register')) return 'auth';
    
    return 'shared';
  }

  groupRulesByType(rules) {
    const groups = {
      'Layout & Structure': [],
      'Typography': [],
      'Forms & Inputs': [],
      'Buttons & Actions': [],
      'Cards & Components': [],
      'Utilities': []
    };
    
    for (const rule of rules) {
      const selector = rule.selector.toLowerCase();
      
      if (selector.includes('container') || selector.includes('grid') || selector.includes('flex')) {
        groups['Layout & Structure'].push(rule);
      } else if (selector.includes('text') || selector.includes('font') || selector.includes('h1') || selector.includes('h2')) {
        groups['Typography'].push(rule);
      } else if (selector.includes('input') || selector.includes('form') || selector.includes('select')) {
        groups['Forms & Inputs'].push(rule);
      } else if (selector.includes('btn') || selector.includes('button')) {
        groups['Buttons & Actions'].push(rule);
      } else if (selector.includes('card') || selector.includes('modal') || selector.includes('nav')) {
        groups['Cards & Components'].push(rule);
      } else {
        groups['Utilities'].push(rule);
      }
    }
    
    return groups;
  }

  generateRecommendations() {
    const recommendations = [];
    
    if (this.duplicates.length > 0) {
      recommendations.push('Remove duplicate CSS rules to reduce bundle size');
      recommendations.push('Consolidate similar selectors into utility classes');
    }
    
    if (this.unusedFiles.length > 0) {
      recommendations.push('Remove unused CSS rules to improve performance');
      recommendations.push('Use CSS purging tools in production builds');
    }
    
    recommendations.push('Use the new voxtics-main.css as the single entry point');
    recommendations.push('Leverage TailwindCSS utilities for consistent styling');
    recommendations.push('Follow the Apple Keyboard+ design system guidelines');
    recommendations.push('Use feature-based CSS organization for better maintainability');
    
    return recommendations;
  }
}

// Run the optimizer
if (require.main === module) {
  const optimizer = new VoxTicsCSSOptimizer();
  optimizer.optimize().catch(console.error);
}

module.exports = VoxTicsCSSOptimizer;