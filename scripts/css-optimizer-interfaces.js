/**
 * VoxTics CSS Optimizer - Interface Definitions
 * Following SOLID principles and Clean Architecture
 */

// Interface Segregation Principle - Focused interfaces
class IOptimizationStrategy {
  async execute(context) {
    throw new Error('Strategy must implement execute method');
  }
}

class IRuleProcessor {
  extractRules(content) {
    throw new Error('Processor must implement extractRules method');
  }
  
  validateRule(rule) {
    throw new Error('Processor must implement validateRule method');
  }
}

class IProgressReporter {
  reportProgress(stage, progress, details) {
    throw new Error('Reporter must implement reportProgress method');
  }
}

class IFileScanner {
  async scanFiles(directories, extensions, excludePatterns) {
    throw new Error('Scanner must implement scanFiles method');
  }
}

class ICSSAnalyzer {
  async analyzeDuplicates(cssRules) {
    throw new Error('Analyzer must implement analyzeDuplicates method');
  }
  
  async analyzeUsage(cssRules, viewFiles) {
    throw new Error('Analyzer must implement analyzeUsage method');
  }
}

class IReportGenerator {
  async generateReport(results, format) {
    throw new Error('Generator must implement generateReport method');
  }
}

// Dependency Inversion Principle - Abstractions for VoxTics-specific features
class IVoxTicsFeatureDetector {
  detectFeature(selector, filePath) {
    throw new Error('Detector must implement detectFeature method');
  }
  
  getFeatureCategories() {
    throw new Error('Detector must implement getFeatureCategories method');
  }
}

class IDesignSystemIntegrator {
  isDesignSystemSelector(selector) {
    throw new Error('Integrator must implement isDesignSystemSelector method');
  }
  
  generateDesignSystemCSS() {
    throw new Error('Integrator must implement generateDesignSystemCSS method');
  }
}

// VoxTics-specific feature detector implementation
class VoxTicsFeatureDetector extends IVoxTicsFeatureDetector {
  constructor() {
    super();
    this.featurePatterns = {
      movies: [
        /movie-card/, /movie-grid/, /movie-details/, /movie-poster/,
        /rating/, /genre/, /cast/, /trailer/
      ],
      cinemas: [
        /cinema-card/, /cinema-grid/, /cinema-details/, /hall/,
        /seating/, /seat-map/, /location/
      ],
      bookings: [
        /booking/, /ticket/, /seat-selection/, /payment/,
        /cart/, /checkout/, /confirmation/
      ],
      admin: [
        /admin-/, /dashboard/, /sidebar/, /topbar/,
        /data-table/, /form-/, /modal/
      ],
      auth: [
        /login/, /register/, /profile/, /account/,
        /auth/, /identity/, /user-/
      ],
      shared: [
        /btn/, /card/, /nav/, /header/, /footer/,
        /loading/, /notification/, /alert/
      ]
    };
  }

  detectFeature(selector, filePath) {
    // Check file path first for context
    const pathFeature = this.detectFeatureFromPath(filePath);
    if (pathFeature) return pathFeature;
    
    // Check selector patterns
    for (const [feature, patterns] of Object.entries(this.featurePatterns)) {
      if (patterns.some(pattern => pattern.test(selector))) {
        return feature;
      }
    }
    
    return 'shared';
  }

  detectFeatureFromPath(filePath) {
    if (filePath.includes('/Movies/')) return 'movies';
    if (filePath.includes('/Cinemas/')) return 'cinemas';
    if (filePath.includes('/Bookings/') || filePath.includes('/Cart/')) return 'bookings';
    if (filePath.includes('/Admin/')) return 'admin';
    if (filePath.includes('/Identity/') || filePath.includes('/Account/')) return 'auth';
    return null;
  }

  getFeatureCategories() {
    return Object.keys(this.featurePatterns);
  }
}

// Apple Keyboard+ Design System integrator
class AppleKeyboardDesignSystemIntegrator extends IDesignSystemIntegrator {
  constructor() {
    super();
    this.systemSelectors = [
      /^:root/, /^html/, /^body/, /^\*/,
      /^\.apple-/, /^\.system-/, /^\.key-/,
      /^\.btn/, /^\.card/, /^\.nav/, /^\.form/,
      /--apple-/, /--system-/, /--key-/
    ];
  }

  isDesignSystemSelector(selector) {
    return this.systemSelectors.some(pattern => pattern.test(selector));
  }

  generateDesignSystemCSS() {
    return `/*
 * VoxTics Apple Keyboard+ Design System Integration
 * Core design tokens and component styles
 */

:root {
  /* Apple Color Palette */
  --apple-blue: #007AFF;
  --apple-blue-light: #5AC8FA;
  --apple-blue-dark: #0051D5;
  --apple-green: #34C759;
  --apple-orange: #FF9500;
  --apple-red: #FF3B30;
  --apple-purple: #AF52DE;
  --apple-pink: #FF2D92;
  --apple-yellow: #FFCC00;
  
  /* System Colors */
  --system-background: #FFFFFF;
  --system-background-secondary: #F2F2F7;
  --label-primary: #000000;
  --label-secondary: rgba(60, 60, 67, 0.60);
  --separator-opaque: #C6C6C8;
  
  /* VoxTics Cinema Theme */
  --voxtics-primary: var(--apple-blue);
  --voxtics-secondary: var(--apple-purple);
  --voxtics-accent: var(--apple-orange);
  --voxtics-success: var(--apple-green);
  --voxtics-warning: var(--apple-yellow);
  --voxtics-danger: var(--apple-red);
}

/* Core Component Styles */
.btn {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  padding: 0.75rem 1.5rem;
  border-radius: 0.75rem;
  font-weight: 600;
  transition: all 0.2s ease;
  border: none;
  cursor: pointer;
}

.btn-primary {
  background: var(--voxtics-primary);
  color: white;
}

.btn-primary:hover {
  background: var(--apple-blue-dark);
  transform: translateY(-1px);
}

.card {
  background: var(--system-background);
  border-radius: 1rem;
  padding: 1.5rem;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  border: 1px solid var(--separator-opaque);
}

/* VoxTics-specific components */
.movie-card {
  @extend .card;
  overflow: hidden;
  transition: transform 0.3s ease;
}

.movie-card:hover {
  transform: translateY(-4px);
}

.cinema-card {
  @extend .card;
  text-align: center;
}

.booking-summary {
  @extend .card;
  background: var(--system-background-secondary);
}
`;
  }
}

module.exports = {
  IOptimizationStrategy,
  IRuleProcessor,
  IProgressReporter,
  IFileScanner,
  ICSSAnalyzer,
  IReportGenerator,
  IVoxTicsFeatureDetector,
  IDesignSystemIntegrator,
  VoxTicsFeatureDetector,
  AppleKeyboardDesignSystemIntegrator
};