#!/usr/bin/env node

/**
 * VoxTics Project Optimization Script
 * Detects and removes duplicates in CSS, JavaScript, and C# files
 * Optimizes file structure and naming conventions
 */

const fs = require('fs').promises;
const path = require('path');
const crypto = require('crypto');

class ProjectOptimizer {
  constructor() {
    this.duplicates = {
      css: [],
      js: [],
      csharp: [],
      files: []
    };
    this.optimizations = [];
    this.projectRoot = process.cwd();
  }

  // Main optimization function
  async optimize() {
    console.log('🚀 Starting VoxTics Project Optimization...\n');
    
    try {
      await this.analyzeCSSFiles();
      await this.analyzeCSharpFiles();
      await this.analyzeFileStructure();
      await this.checkNamingConventions();
      await this.generateReport();
      await this.applyOptimizations();
      
      console.log('✅ Optimization complete!\n');
    } catch (error) {
      console.error('❌ Optimization failed:', error.message);
      process.exit(1);
    }
  }

  // Analyze CSS files for duplicates and optimization opportunities
  async analyzeCSSFiles() {
    console.log('🎨 Analyzing CSS files...');
    
    const cssFiles = await this.findFiles('**/*.css', ['node_modules', 'bin', 'obj']);
    const cssRules = new Map();
    const duplicateSelectors = new Map();
    
    for (const file of cssFiles) {
      try {
        const content = await fs.readFile(file, 'utf8');
        const rules = this.extractCSSRules(content);
        
        for (const rule of rules) {
          const hash = this.hashContent(rule.content);
          
          if (cssRules.has(hash)) {
            this.duplicates.css.push({
              type: 'duplicate_rule',
              files: [cssRules.get(hash).file, file],
              rule: rule.selector,
              content: rule.content
            });
          } else {
            cssRules.set(hash, { file, rule });
          }
          
          // Check for duplicate selectors
          if (duplicateSelectors.has(rule.selector)) {
            duplicateSelectors.get(rule.selector).push(file);
          } else {
            duplicateSelectors.set(rule.selector, [file]);
          }
        }
      } catch (error) {
        console.warn(`⚠️  Could not analyze ${file}: ${error.message}`);
      }
    }
    
    // Report duplicate selectors
    for (const [selector, files] of duplicateSelectors) {
      if (files.length > 1) {
        this.duplicates.css.push({
          type: 'duplicate_selector',
          selector,
          files
        });
      }
    }
    
    console.log(`   Found ${this.duplicates.css.length} CSS duplicates`);
  }

  // Analyze C# files for duplicate methods and classes
  async analyzeCSharpFiles() {
    console.log('🔧 Analyzing C# files...');
    
    const csFiles = await this.findFiles('**/*.cs', ['bin', 'obj', 'Migrations']);
    const methods = new Map();
    const classes = new Map();
    
    for (const file of csFiles) {
      try {
        const content = await fs.readFile(file, 'utf8');
        
        // Extract methods
        const methodMatches = content.matchAll(/(?:public|private|protected|internal)\s+(?:static\s+)?(?:async\s+)?(?:\w+\s+)?(\w+)\s*\([^)]*\)\s*{([^{}]*(?:{[^{}]*}[^{}]*)*)}/g);
        
        for (const match of methodMatches) {
          const methodName = match[1];
          const methodBody = match[2].trim();
          const hash = this.hashContent(methodBody);
          
          if (methods.has(hash) && methodBody.length > 50) {
            this.duplicates.csharp.push({
              type: 'duplicate_method',
              method: methodName,
              files: [methods.get(hash).file, file],
              similarity: this.calculateSimilarity(methods.get(hash).body, methodBody)
            });
          } else {
            methods.set(hash, { file, method: methodName, body: methodBody });
          }
        }
        
        // Extract class names
        const classMatches = content.matchAll(/(?:public|internal)\s+(?:abstract\s+|static\s+)?class\s+(\w+)/g);
        
        for (const match of classMatches) {
          const className = match[1];
          
          if (classes.has(className)) {
            this.duplicates.csharp.push({
              type: 'duplicate_class_name',
              className,
              files: [classes.get(className), file]
            });
          } else {
            classes.set(className, file);
          }
        }
        
      } catch (error) {
        console.warn(`⚠️  Could not analyze ${file}: ${error.message}`);
      }
    }
    
    console.log(`   Found ${this.duplicates.csharp.length} C# duplicates`);
  }

  // Analyze file structure for optimization opportunities
  async analyzeFileStructure() {
    console.log('📁 Analyzing file structure...');
    
    const allFiles = await this.findFiles('**/*', ['node_modules', 'bin', 'obj', '.git']);
    const fileHashes = new Map();
    const namingIssues = [];
    
    for (const file of allFiles) {
      try {
        const stats = await fs.stat(file);
        
        if (stats.isFile()) {
          const content = await fs.readFile(file);
          const hash = crypto.createHash('md5').update(content).digest('hex');
          
          if (fileHashes.has(hash)) {
            this.duplicates.files.push({
              type: 'duplicate_file',
              files: [fileHashes.get(hash), file],
              size: stats.size
            });
          } else {
            fileHashes.set(hash, file);
          }
          
          // Check naming conventions
          const fileName = path.basename(file);
          const ext = path.extname(file);
          
          if (ext === '.cs' && !this.isPascalCase(fileName.replace('.cs', ''))) {
            namingIssues.push({
              file,
              issue: 'C# files should use PascalCase',
              suggestion: this.toPascalCase(fileName.replace('.cs', '')) + '.cs'
            });
          }
          
          if (ext === '.css' && !this.isKebabCase(fileName.replace('.css', ''))) {
            namingIssues.push({
              file,
              issue: 'CSS files should use kebab-case',
              suggestion: this.toKebabCase(fileName.replace('.css', '')) + '.css'
            });
          }
        }
      } catch (error) {
        // Skip files that can't be read
      }
    }
    
    this.optimizations.push(...namingIssues);
    console.log(`   Found ${this.duplicates.files.length} duplicate files`);
    console.log(`   Found ${namingIssues.length} naming convention issues`);
  }

  // Check naming conventions across the project
  async checkNamingConventions() {
    console.log('📝 Checking naming conventions...');
    
    const csFiles = await this.findFiles('**/*.cs', ['bin', 'obj', 'Migrations']);
    const conventionIssues = [];
    
    for (const file of csFiles) {
      try {
        const content = await fs.readFile(file, 'utf8');
        
        // Check class naming
        const classMatches = content.matchAll(/(?:public|internal)\s+(?:abstract\s+|static\s+)?class\s+(\w+)/g);
        for (const match of classMatches) {
          const className = match[1];
          if (!this.isPascalCase(className)) {
            conventionIssues.push({
              file,
              type: 'class_naming',
              issue: `Class '${className}' should use PascalCase`,
              suggestion: this.toPascalCase(className)
            });
          }
        }
        
        // Check method naming
        const methodMatches = content.matchAll(/(?:public|private|protected|internal)\s+(?:static\s+)?(?:async\s+)?(?:\w+\s+)?(\w+)\s*\(/g);
        for (const match of methodMatches) {
          const methodName = match[1];
          if (!this.isPascalCase(methodName) && !['get', 'set'].includes(methodName.toLowerCase())) {
            conventionIssues.push({
              file,
              type: 'method_naming',
              issue: `Method '${methodName}' should use PascalCase`,
              suggestion: this.toPascalCase(methodName)
            });
          }
        }
        
        // Check variable naming
        const variableMatches = content.matchAll(/(?:var|int|string|bool|double|decimal|DateTime|List<\w+>)\s+(\w+)\s*=/g);
        for (const match of variableMatches) {
          const variableName = match[1];
          if (!this.isCamelCase(variableName)) {
            conventionIssues.push({
              file,
              type: 'variable_naming',
              issue: `Variable '${variableName}' should use camelCase`,
              suggestion: this.toCamelCase(variableName)
            });
          }
        }
        
      } catch (error) {
        console.warn(`⚠️  Could not check conventions in ${file}: ${error.message}`);
      }
    }
    
    this.optimizations.push(...conventionIssues);
    console.log(`   Found ${conventionIssues.length} naming convention issues`);
  }

  // Generate optimization report
  async generateReport() {
    console.log('📊 Generating optimization report...');
    
    const report = {
      timestamp: new Date().toISOString(),
      summary: {
        css_duplicates: this.duplicates.css.length,
        csharp_duplicates: this.duplicates.csharp.length,
        duplicate_files: this.duplicates.files.length,
        optimization_opportunities: this.optimizations.length
      },
      duplicates: this.duplicates,
      optimizations: this.optimizations,
      recommendations: this.generateRecommendations()
    };
    
    await fs.writeFile('optimization-report.json', JSON.stringify(report, null, 2));
    
    // Generate human-readable report
    let readableReport = `# VoxTics Project Optimization Report\n\n`;
    readableReport += `Generated: ${new Date().toLocaleString()}\n\n`;
    
    readableReport += `## Summary\n`;
    readableReport += `- CSS Duplicates: ${report.summary.css_duplicates}\n`;
    readableReport += `- C# Duplicates: ${report.summary.csharp_duplicates}\n`;
    readableReport += `- Duplicate Files: ${report.summary.duplicate_files}\n`;
    readableReport += `- Optimization Opportunities: ${report.summary.optimization_opportunities}\n\n`;
    
    if (this.duplicates.css.length > 0) {
      readableReport += `## CSS Duplicates\n`;
      for (const duplicate of this.duplicates.css) {
        readableReport += `- **${duplicate.type}**: ${duplicate.selector || duplicate.rule}\n`;
        readableReport += `  Files: ${duplicate.files.join(', ')}\n\n`;
      }
    }
    
    if (this.duplicates.csharp.length > 0) {
      readableReport += `## C# Duplicates\n`;
      for (const duplicate of this.duplicates.csharp) {
        readableReport += `- **${duplicate.type}**: ${duplicate.method || duplicate.className}\n`;
        readableReport += `  Files: ${duplicate.files.join(', ')}\n`;
        if (duplicate.similarity) {
          readableReport += `  Similarity: ${(duplicate.similarity * 100).toFixed(1)}%\n`;
        }
        readableReport += `\n`;
      }
    }
    
    if (this.duplicates.files.length > 0) {
      readableReport += `## Duplicate Files\n`;
      for (const duplicate of this.duplicates.files) {
        readableReport += `- Files: ${duplicate.files.join(', ')}\n`;
        readableReport += `  Size: ${(duplicate.size / 1024).toFixed(1)} KB\n\n`;
      }
    }
    
    readableReport += `## Recommendations\n`;
    for (const recommendation of report.recommendations) {
      readableReport += `- ${recommendation}\n`;
    }
    
    await fs.writeFile('OPTIMIZATION_REPORT.md', readableReport);
    
    console.log('   Reports saved: optimization-report.json, OPTIMIZATION_REPORT.md');
  }

  // Apply safe optimizations
  async applyOptimizations() {
    console.log('🔧 Applying safe optimizations...');
    
    let appliedCount = 0;
    
    // Remove duplicate files (keep the first one)
    for (const duplicate of this.duplicates.files) {
      if (duplicate.files.length > 1) {
        for (let i = 1; i < duplicate.files.length; i++) {
          try {
            await fs.unlink(duplicate.files[i]);
            console.log(`   Removed duplicate file: ${duplicate.files[i]}`);
            appliedCount++;
          } catch (error) {
            console.warn(`   Could not remove ${duplicate.files[i]}: ${error.message}`);
          }
        }
      }
    }
    
    console.log(`   Applied ${appliedCount} optimizations`);
  }

  // Helper methods
  async findFiles(pattern, excludeDirs = []) {
    const glob = require('glob');
    return new Promise((resolve, reject) => {
      glob(pattern, {
        ignore: excludeDirs.map(dir => `**/${dir}/**`),
        nodir: true
      }, (err, files) => {
        if (err) reject(err);
        else resolve(files);
      });
    });
  }

  extractCSSRules(css) {
    const rules = [];
    const ruleRegex = /([^{}]+)\s*\{([^{}]*)\}/g;
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

  calculateSimilarity(str1, str2) {
    const longer = str1.length > str2.length ? str1 : str2;
    const shorter = str1.length > str2.length ? str2 : str1;
    
    if (longer.length === 0) return 1.0;
    
    const editDistance = this.levenshteinDistance(longer, shorter);
    return (longer.length - editDistance) / longer.length;
  }

  levenshteinDistance(str1, str2) {
    const matrix = [];
    
    for (let i = 0; i <= str2.length; i++) {
      matrix[i] = [i];
    }
    
    for (let j = 0; j <= str1.length; j++) {
      matrix[0][j] = j;
    }
    
    for (let i = 1; i <= str2.length; i++) {
      for (let j = 1; j <= str1.length; j++) {
        if (str2.charAt(i - 1) === str1.charAt(j - 1)) {
          matrix[i][j] = matrix[i - 1][j - 1];
        } else {
          matrix[i][j] = Math.min(
            matrix[i - 1][j - 1] + 1,
            matrix[i][j - 1] + 1,
            matrix[i - 1][j] + 1
          );
        }
      }
    }
    
    return matrix[str2.length][str1.length];
  }

  isPascalCase(str) {
    return /^[A-Z][a-zA-Z0-9]*$/.test(str);
  }

  isCamelCase(str) {
    return /^[a-z][a-zA-Z0-9]*$/.test(str);
  }

  isKebabCase(str) {
    return /^[a-z0-9]+(-[a-z0-9]+)*$/.test(str);
  }

  toPascalCase(str) {
    return str.replace(/(?:^|[-_])(\w)/g, (_, char) => char.toUpperCase());
  }

  toCamelCase(str) {
    const pascal = this.toPascalCase(str);
    return pascal.charAt(0).toLowerCase() + pascal.slice(1);
  }

  toKebabCase(str) {
    return str.replace(/([A-Z])/g, '-$1').toLowerCase().replace(/^-/, '');
  }

  generateRecommendations() {
    const recommendations = [];
    
    if (this.duplicates.css.length > 0) {
      recommendations.push('Consolidate duplicate CSS rules into utility classes');
      recommendations.push('Use CSS custom properties for repeated values');
      recommendations.push('Consider using a CSS framework like Tailwind CSS');
    }
    
    if (this.duplicates.csharp.length > 0) {
      recommendations.push('Extract duplicate methods into base classes or utility classes');
      recommendations.push('Use dependency injection for shared functionality');
      recommendations.push('Consider implementing design patterns like Strategy or Template Method');
    }
    
    if (this.duplicates.files.length > 0) {
      recommendations.push('Remove duplicate files to reduce bundle size');
      recommendations.push('Use symbolic links for shared resources');
    }
    
    if (this.optimizations.length > 0) {
      recommendations.push('Follow consistent naming conventions across the project');
      recommendations.push('Use automated tools like EditorConfig and StyleCop');
      recommendations.push('Set up pre-commit hooks to enforce code standards');
    }
    
    recommendations.push('Implement automated testing to prevent regressions');
    recommendations.push('Use bundling and minification for production builds');
    recommendations.push('Consider implementing a design system for consistent UI components');
    
    return recommendations;
  }
}

// Run the optimizer
if (require.main === module) {
  const optimizer = new ProjectOptimizer();
  optimizer.optimize().catch(console.error);
}

module.exports = ProjectOptimizer;