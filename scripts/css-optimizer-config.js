/**
 * VoxTics CSS Optimizer Configuration
 * Centralized configuration management with validation
 */

class OptimizerConfig {
  constructor(options = {}) {
    this.config = {
      // File scanning configuration
      cssDirectories: options.cssDirectories || [
        'VoxTics/wwwroot/css',
        'VoxTics/wwwroot/css/components'
      ],
      viewDirectories: options.viewDirectories || [
        'VoxTics/Views',
        'VoxTics/Areas'
      ],
      excludePatterns: options.excludePatterns || [
        '*.min.css',
        'node_modules/**',
        'bin/**',
        'obj/**'
      ],
      
      // Optimization settings
      duplicateThreshold: options.duplicateThreshold || 0.9,
      unusedConfidenceThreshold: options.unusedConfidenceThreshold || 0.7,
      preserveSystemSelectors: options.preserveSystemSelectors !== false,
      
      // Output configuration
      outputDirectory: options.outputDirectory || 'VoxTics/wwwroot/css/optimized',
      generateSourceMaps: options.generateSourceMaps !== false,
      minifyOutput: options.minifyOutput !== false,
      
      // Logging configuration
      logLevel: options.logLevel || 'info',
      logFile: options.logFile || 'css-optimization.log',
      
      // Feature detection
      features: options.features || [
        'movies', 'cinemas', 'bookings', 'admin', 'auth', 'shared'
      ],
      
      // Design system integration
      designSystem: {
        prefix: options.designSystemPrefix || 'apple-',
        customProperties: options.useCustomProperties !== false,
        utilityClasses: options.generateUtilityClasses !== false
      }
    };
    
    this.validate();
  }

  validate() {
    const required = ['cssDirectories', 'viewDirectories', 'outputDirectory'];
    
    for (const field of required) {
      if (!this.config[field]) {
        throw new Error(`Configuration field '${field}' is required`);
      }
    }
    
    if (this.config.duplicateThreshold < 0 || this.config.duplicateThreshold > 1) {
      throw new Error('duplicateThreshold must be between 0 and 1');
    }
    
    if (this.config.unusedConfidenceThreshold < 0 || this.config.unusedConfidenceThreshold > 1) {
      throw new Error('unusedConfidenceThreshold must be between 0 and 1');
    }
  }

  get(key) {
    return key.split('.').reduce((obj, k) => obj?.[k], this.config);
  }

  set(key, value) {
    const keys = key.split('.');
    const lastKey = keys.pop();
    const target = keys.reduce((obj, k) => obj[k] = obj[k] || {}, this.config);
    target[lastKey] = value;
  }

  merge(otherConfig) {
    return new OptimizerConfig({
      ...this.config,
      ...otherConfig
    });
  }

  static fromFile(filePath) {
    try {
      const fs = require('fs');
      const configData = JSON.parse(fs.readFileSync(filePath, 'utf8'));
      return new OptimizerConfig(configData);
    } catch (error) {
      throw new Error(`Failed to load configuration from ${filePath}: ${error.message}`);
    }
  }

  toFile(filePath) {
    const fs = require('fs');
    fs.writeFileSync(filePath, JSON.stringify(this.config, null, 2));
  }
}

module.exports = { OptimizerConfig };