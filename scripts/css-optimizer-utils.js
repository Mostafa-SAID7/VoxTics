/**
 * VoxTics CSS Optimizer - Utility Functions
 * Focused utility functions for better maintainability
 */

const fs = require('fs').promises;
const path = require('path');
const crypto = require('crypto');

/**
 * File system utilities with proper error handling
 */
class FileSystemUtils {
  static async ensureDirectory(dirPath) {
    try {
      await fs.mkdir(dirPath, { recursive: true });
      return true;
    } catch (error) {
      throw new Error(`Failed to create directory ${dirPath}: ${error.message}`);
    }
  }

  static async safeReadFile(filePath, encoding = 'utf8') {
    try {
      return await fs.readFile(filePath, encoding);
    } catch (error) {
      if (error.code === 'ENOENT') {
        return null; // File doesn't exist
      }
      throw new Error(`Failed to read file ${filePath}: ${error.message}`);
    }
  }

  static async safeWriteFile(filePath, content, options = {}) {
    try {
      // Ensure directory exists
      await this.ensureDirectory(path.dirname(filePath));
      
      // Write file with backup if it exists
      if (options.backup && await this.fileExists(filePath)) {
        await this.createBackup(filePath);
      }
      
      await fs.writeFile(filePath, content, 'utf8');
      return true;
    } catch (error) {
      throw new Error(`Failed to write file ${filePath}: ${error.message}`);
    }
  }

  static async fileExists(filePath) {
    try {
      await fs.access(filePath);
      return true;
    } catch {
      return false;
    }
  }

  static async createBackup(filePath) {
    const backupPath = `${filePath}.backup.${Date.now()}`;
    const content = await this.safeReadFile(filePath);
    if (content) {
      await fs.writeFile(backupPath, content);
    }
    return backupPath;
  }

  static async getFileStats(filePath) {
    try {
      const stats = await fs.stat(filePath);
      return {
        size: stats.size,
        modified: stats.mtime,
        created: stats.birthtime,
        isFile: stats.isFile(),
        isDirectory: stats.isDirectory()
      };
    } catch (error) {
      return null;
    }
  }
}

/**
 * CSS parsing utilities with VoxTics-specific enhancements
 */
class CSSParsingUtils {
  static extractRules(cssContent) {
    if (!cssContent || typeof cssContent !== 'string') {
      return [];
    }

    // Remove comments and normalize whitespace
    const cleanContent = this.cleanCSS(cssContent);
    
    const rules = [];
    const ruleRegex = /([^{}]+)\s*\{([^{}]*(?:\{[^{}]*\}[^{}]*)*)\}/g;
    let match;

    while ((match = ruleRegex.exec(cleanContent)) !== null) {
      const selector = match[1].trim();
      const content = match[2].trim();

      if (this.isValidRule(selector, content)) {
        rules.push({
          selector,
          content,
          type: this.determineRuleType(selector),
          specificity: this.calculateSpecificity(selector),
          hash: this.hashContent(content),
          lineNumber: this.getLineNumber(cssContent, match.index)
        });
      }
    }

    return rules;
  }

  static cleanCSS(cssContent) {
    return cssContent
      // Remove single-line comments
      .replace(/\/\/.*$/gm, '')
      // Remove multi-line comments
      .replace(/\/\*[\s\S]*?\*\//g, '')
      // Normalize whitespace
      .replace(/\s+/g, ' ')
      // Remove empty lines
      .replace(/^\s*$/gm, '')
      .trim();
  }

  static isValidRule(selector, content) {
    if (!selector || !content) return false;
    
    // Skip @import, @charset, etc.
    if (selector.startsWith('@import') || selector.startsWith('@charset')) {
      return false;
    }
    
    // Skip empty rules
    if (content.trim().length === 0) return false;
    
    return true;
  }

  static determineRuleType(selector) {
    if (selector.includes('@media')) return 'media-query';
    if (selector.includes('@keyframes')) return 'animation';
    if (selector.includes('@supports')) return 'feature-query';
    if (selector.includes(':hover') || selector.includes(':focus') || selector.includes(':active')) return 'pseudo-state';
    if (selector.includes('::before') || selector.includes('::after')) return 'pseudo-element';
    if (selector.startsWith('.')) return 'class';
    if (selector.startsWith('#')) return 'id';
    if (selector.match(/^[a-zA-Z]/)) return 'element';
    return 'complex';
  }

  static calculateSpecificity(selector) {
    // CSS specificity calculation: inline, ids, classes, elements
    let specificity = { inline: 0, ids: 0, classes: 0, elements: 0 };
    
    // Count IDs
    specificity.ids = (selector.match(/#[\w-]+/g) || []).length;
    
    // Count classes, attributes, and pseudo-classes
    const classMatches = selector.match(/\.[\w-]+|:[\w-]+|\[[\w-]+\]/g) || [];
    specificity.classes = classMatches.length;
    
    // Count elements and pseudo-elements
    const elementMatches = selector.match(/^[a-zA-Z]+|::?[a-zA-Z]+/g) || [];
    specificity.elements = elementMatches.length;
    
    // Calculate numeric specificity
    return specificity.inline * 1000 + specificity.ids * 100 + specificity.classes * 10 + specificity.elements;
  }

  static hashContent(content) {
    return crypto.createHash('md5')
      .update(content.replace(/\s+/g, ' ').trim())
      .digest('hex');
  }

  static getLineNumber(fullContent, position) {
    return fullContent.substring(0, position).split('\n').length;
  }

  static extractClassNames(htmlContent) {
    const classes = new Set();
    
    if (!htmlContent || typeof htmlContent !== 'string') {
      return Array.from(classes);
    }

    // Extract from class attributes
    const classRegex = /class\s*=\s*["']([^"']+)["']/gi;
    let match;
    
    while ((match = classRegex.exec(htmlContent)) !== null) {
      const classString = match[1];
      classString.split(/\s+/).forEach(cls => {
        const trimmed = cls.trim();
        if (trimmed && this.isValidClassName(trimmed)) {
          classes.add(trimmed);
        }
      });
    }

    // Extract from @class attributes (Razor syntax)
    const razorClassRegex = /@class\s*=\s*["']([^"']+)["']/gi;
    while ((match = razorClassRegex.exec(htmlContent)) !== null) {
      const classString = match[1];
      classString.split(/\s+/).forEach(cls => {
        const trimmed = cls.trim();
        if (trimmed && this.isValidClassName(trimmed)) {
          classes.add(trimmed);
        }
      });
    }

    // Extract from JavaScript class manipulations
    const jsClassRegex = /(?:addClass|removeClass|toggleClass|classList\.(?:add|remove|toggle))\s*\(\s*["']([^"']+)["']\s*\)/gi;
    while ((match = jsClassRegex.exec(htmlContent)) !== null) {
      const className = match[1].trim();
      if (className && this.isValidClassName(className)) {
        classes.add(className);
      }
    }

    return Array.from(classes);
  }

  static isValidClassName(className) {
    // Valid CSS class name pattern
    return /^[a-zA-Z_-][a-zA-Z0-9_-]*$/.test(className);
  }
}

/**
 * VoxTics-specific CSS utilities
 */
class VoxTicsStyleUtils {
  static readonly VOXTICS_FEATURES = [
    'movies', 'cinemas', 'bookings', 'admin', 'auth', 'shared'
  ];

  static readonly DESIGN_SYSTEM_PREFIXES = [
    'apple-', 'system-', 'key-', 'btn-', 'card-', 'nav-', 'form-'
  ];

  static categorizeByFeature(selector, filePath = '') {
    // Check file path context first
    const pathFeature = this.getFeatureFromPath(filePath);
    if (pathFeature) return pathFeature;

    // Check selector patterns
    const featurePatterns = {
      movies: /movie|film|rating|genre|cast|trailer|poster/i,
      cinemas: /cinema|theater|hall|seat|location|venue/i,
      bookings: /booking|ticket|reservation|payment|cart|checkout/i,
      admin: /admin|dashboard|sidebar|topbar|management/i,
      auth: /login|register|profile|account|auth|identity|user/i
    };

    for (const [feature, pattern] of Object.entries(featurePatterns)) {
      if (pattern.test(selector)) {
        return feature;
      }
    }

    return 'shared';
  }

  static getFeatureFromPath(filePath) {
    const normalizedPath = filePath.toLowerCase();
    
    if (normalizedPath.includes('/movies/')) return 'movies';
    if (normalizedPath.includes('/cinemas/')) return 'cinemas';
    if (normalizedPath.includes('/bookings/') || normalizedPath.includes('/cart/')) return 'bookings';
    if (normalizedPath.includes('/admin/')) return 'admin';
    if (normalizedPath.includes('/identity/') || normalizedPath.includes('/account/')) return 'auth';
    
    return null;
  }

  static isDesignSystemSelector(selector) {
    return this.DESIGN_SYSTEM_PREFIXES.some(prefix => 
      selector.includes(`.${prefix}`) || selector.includes(`--${prefix}`)
    );
  }

  static generateFeatureCSS(feature, rules) {
    const header = `/*
 * VoxTics ${feature.charAt(0).toUpperCase() + feature.slice(1)} Styles
 * Generated by CSS Optimizer
 * Feature-specific styles for the ${feature} module
 */

`;

    const groupedRules = this.groupRulesByType(rules);
    let css = header;

    // Add rules in logical order
    const order = ['element', 'class', 'id', 'pseudo-state', 'pseudo-element', 'media-query', 'animation'];
    
    for (const type of order) {
      if (groupedRules[type] && groupedRules[type].length > 0) {
        css += `/* ${type.replace('-', ' ').toUpperCase()} RULES */\n`;
        
        for (const rule of groupedRules[type]) {
          css += `${rule.selector} {\n`;
          css += this.formatCSSContent(rule.content);
          css += `}\n\n`;
        }
      }
    }

    return css;
  }

  static groupRulesByType(rules) {
    const groups = {};
    
    for (const rule of rules) {
      const type = rule.type || 'unknown';
      if (!groups[type]) {
        groups[type] = [];
      }
      groups[type].push(rule);
    }

    // Sort each group by specificity
    for (const type in groups) {
      groups[type].sort((a, b) => (a.specificity || 0) - (b.specificity || 0));
    }

    return groups;
  }

  static formatCSSContent(content) {
    if (!content) return '';
    
    // Add proper indentation and formatting
    return content
      .split(';')
      .filter(prop => prop.trim())
      .map(prop => `  ${prop.trim()};`)
      .join('\n') + '\n';
  }

  static generateOptimizationSummary(results) {
    const summary = {
      totalRules: results.totalRules || 0,
      duplicatesFound: results.duplicates?.length || 0,
      unusedRules: results.unusedRules?.length || 0,
      sizeBefore: results.sizeBefore || 0,
      sizeAfter: results.sizeAfter || 0,
      features: results.featureBreakdown || {},
      recommendations: []
    };

    // Calculate savings
    summary.sizeReduction = summary.sizeBefore - summary.sizeAfter;
    summary.percentageReduction = summary.sizeBefore > 0 
      ? Math.round((summary.sizeReduction / summary.sizeBefore) * 100) 
      : 0;

    // Generate recommendations
    if (summary.duplicatesFound > 0) {
      summary.recommendations.push(`Remove ${summary.duplicatesFound} duplicate CSS rules`);
    }
    
    if (summary.unusedRules > 0) {
      summary.recommendations.push(`Consider removing ${summary.unusedRules} unused CSS rules`);
    }
    
    if (summary.percentageReduction > 10) {
      summary.recommendations.push(`Implement CSS purging to maintain ${summary.percentageReduction}% size reduction`);
    }

    summary.recommendations.push('Use the Apple Keyboard+ design system consistently');
    summary.recommendations.push('Implement feature-based CSS organization');

    return summary;
  }
}

/**
 * Performance monitoring utilities
 */
class PerformanceUtils {
  static startTimer(label) {
    const start = process.hrtime.bigint();
    return {
      label,
      start,
      end() {
        const end = process.hrtime.bigint();
        const duration = Number(end - start) / 1000000; // Convert to milliseconds
        return { label, duration };
      }
    };
  }

  static formatDuration(milliseconds) {
    if (milliseconds < 1000) {
      return `${Math.round(milliseconds)}ms`;
    } else if (milliseconds < 60000) {
      return `${(milliseconds / 1000).toFixed(1)}s`;
    } else {
      const minutes = Math.floor(milliseconds / 60000);
      const seconds = ((milliseconds % 60000) / 1000).toFixed(1);
      return `${minutes}m ${seconds}s`;
    }
  }

  static formatFileSize(bytes) {
    const units = ['B', 'KB', 'MB', 'GB'];
    let size = bytes;
    let unitIndex = 0;

    while (size >= 1024 && unitIndex < units.length - 1) {
      size /= 1024;
      unitIndex++;
    }

    return `${size.toFixed(1)} ${units[unitIndex]}`;
  }
}

module.exports = {
  FileSystemUtils,
  CSSParsingUtils,
  VoxTicsStyleUtils,
  PerformanceUtils
};