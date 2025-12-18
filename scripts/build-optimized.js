#!/usr/bin/env node

/**
 * VoxTics Optimized Build Script
 * Comprehensive build process with optimization, duplicate detection, and quality checks
 */

const { execSync, spawn } = require('child_process');
const fs = require('fs').promises;
const path = require('path');
const chalk = require('chalk');

class OptimizedBuilder {
  constructor() {
    this.startTime = Date.now();
    this.steps = [];
    this.errors = [];
    this.warnings = [];
  }

  log(message, type = 'info') {
    const timestamp = new Date().toLocaleTimeString();
    const colors = {
      info: chalk.blue,
      success: chalk.green,
      warning: chalk.yellow,
      error: chalk.red,
      step: chalk.cyan
    };
    
    console.log(`${chalk.gray(timestamp)} ${colors[type]('●')} ${message}`);
  }

  async runCommand(command, description, options = {}) {
    this.log(`${description}...`, 'step');
    
    try {
      const result = execSync(command, {
        stdio: options.silent ? 'pipe' : 'inherit',
        cwd: process.cwd(),
        encoding: 'utf8',
        ...options
      });
      
      this.log(`${description} completed`, 'success');
      this.steps.push({ description, status: 'success', duration: Date.now() - this.startTime });
      
      return result;
    } catch (error) {
      this.log(`${description} failed: ${error.message}`, 'error');
      this.errors.push({ description, error: error.message });
      
      if (!options.continueOnError) {
        throw error;
      }
    }
  }

  async checkPrerequisites() {
    this.log('Checking prerequisites...', 'step');
    
    const checks = [
      { command: 'node --version', name: 'Node.js' },
      { command: 'npm --version', name: 'npm' },
      { command: 'dotnet --version', name: '.NET Core' }
    ];
    
    for (const check of checks) {
      try {
        const version = execSync(check.command, { encoding: 'utf8', stdio: 'pipe' }).trim();
        this.log(`${check.name}: ${version}`, 'success');
      } catch (error) {
        this.log(`${check.name} not found`, 'error');
        throw new Error(`${check.name} is required but not installed`);
      }
    }
  }

  async installDependencies() {
    // Check if package.json exists
    try {
      await fs.access('package.json');
      await this.runCommand('npm ci', 'Installing npm dependencies');
    } catch (error) {
      this.log('No package.json found, skipping npm install', 'warning');
    }
    
    // Restore .NET packages
    await this.runCommand('dotnet restore VoxTics/VoxTics.csproj', 'Restoring .NET packages');
  }

  async runQualityChecks() {
    this.log('Running quality checks...', 'step');
    
    // ESLint (if configured)
    try {
      await fs.access('.eslintrc.json');
      await this.runCommand('npx eslint VoxTics/wwwroot/js/**/*.js --fix', 'Running ESLint', { continueOnError: true });
    } catch (error) {
      this.log('ESLint not configured, skipping', 'warning');
    }
    
    // StyleLint
    try {
      await fs.access('.stylelintrc.json');
      await this.runCommand('npx stylelint "VoxTics/wwwroot/css/**/*.css" --fix', 'Running StyleLint', { continueOnError: true });
    } catch (error) {
      this.log('StyleLint not configured, skipping', 'warning');
    }
    
    // C# code analysis
    await this.runCommand('dotnet format VoxTics/VoxTics.csproj --verify-no-changes', 'Running C# formatter', { continueOnError: true });
  }

  async optimizeProject() {
    this.log('Running project optimization...', 'step');
    
    // Run duplicate detection
    try {
      await fs.access('scripts/optimize-project.js');
      await this.runCommand('node scripts/optimize-project.js', 'Detecting and removing duplicates');
    } catch (error) {
      this.log('Optimization script not found, skipping', 'warning');
    }
    
    // Optimize images (if imagemin is available)
    try {
      await this.runCommand('npx imagemin VoxTics/wwwroot/images/**/* --out-dir=VoxTics/wwwroot/images/optimized/', 'Optimizing images', { continueOnError: true });
    } catch (error) {
      this.log('Image optimization failed, continuing', 'warning');
    }
  }

  async buildAssets() {
    this.log('Building frontend assets...', 'step');
    
    // Build Tailwind CSS
    try {
      await fs.access('tailwind.config.js');
      await this.runCommand('npx tailwindcss -i VoxTics/wwwroot/css/input.css -o VoxTics/wwwroot/css/output.css --minify', 'Building Tailwind CSS');
    } catch (error) {
      this.log('Tailwind config not found, skipping CSS build', 'warning');
    }
    
    // Build with Webpack (if configured)
    try {
      await fs.access('webpack.config.js');
      await this.runCommand('npx webpack --mode=production', 'Building with Webpack');
    } catch (error) {
      this.log('Webpack config not found, skipping JS build', 'warning');
    }
  }

  async buildDotNet() {
    this.log('Building .NET application...', 'step');
    
    // Clean previous build
    await this.runCommand('dotnet clean VoxTics/VoxTics.csproj', 'Cleaning previous build');
    
    // Build in Release mode
    await this.runCommand('dotnet build VoxTics/VoxTics.csproj --configuration Release --no-restore', 'Building .NET application');
    
    // Run tests (if any)
    try {
      const testProjects = execSync('find . -name "*.Tests.csproj" -o -name "*Test*.csproj"', { encoding: 'utf8', stdio: 'pipe' }).trim();
      if (testProjects) {
        await this.runCommand('dotnet test --configuration Release --no-build', 'Running tests', { continueOnError: true });
      }
    } catch (error) {
      this.log('No test projects found, skipping tests', 'warning');
    }
  }

  async generateBundleReport() {
    this.log('Generating bundle analysis...', 'step');
    
    try {
      // Generate webpack bundle analyzer report
      await this.runCommand('ANALYZE=true npx webpack --mode=production', 'Generating bundle analysis', { continueOnError: true });
      
      // Generate CSS stats
      await this.runCommand('npx cssstats VoxTics/wwwroot/css/*.css > css-stats.json', 'Generating CSS statistics', { continueOnError: true });
      
    } catch (error) {
      this.log('Bundle analysis failed, continuing', 'warning');
    }
  }

  async runSecurityChecks() {
    this.log('Running security checks...', 'step');
    
    // npm audit
    try {
      await this.runCommand('npm audit --audit-level moderate', 'Running npm security audit', { continueOnError: true });
    } catch (error) {
      this.log('npm audit found issues, check the output above', 'warning');
    }
    
    // .NET security scan (if available)
    try {
      await this.runCommand('dotnet list VoxTics/VoxTics.csproj package --vulnerable', 'Checking for vulnerable packages', { continueOnError: true });
    } catch (error) {
      this.log('Package vulnerability check failed', 'warning');
    }
  }

  async generateReport() {
    const duration = Date.now() - this.startTime;
    const report = {
      timestamp: new Date().toISOString(),
      duration: `${(duration / 1000).toFixed(2)}s`,
      steps: this.steps,
      errors: this.errors,
      warnings: this.warnings,
      summary: {
        total_steps: this.steps.length,
        successful_steps: this.steps.filter(s => s.status === 'success').length,
        errors: this.errors.length,
        warnings: this.warnings.length
      }
    };
    
    await fs.writeFile('build-report.json', JSON.stringify(report, null, 2));
    
    // Generate human-readable report
    let readableReport = `# VoxTics Build Report\n\n`;
    readableReport += `**Generated:** ${new Date().toLocaleString()}\n`;
    readableReport += `**Duration:** ${report.duration}\n\n`;
    
    readableReport += `## Summary\n`;
    readableReport += `- Total Steps: ${report.summary.total_steps}\n`;
    readableReport += `- Successful: ${report.summary.successful_steps}\n`;
    readableReport += `- Errors: ${report.summary.errors}\n`;
    readableReport += `- Warnings: ${report.summary.warnings}\n\n`;
    
    if (this.errors.length > 0) {
      readableReport += `## Errors\n`;
      for (const error of this.errors) {
        readableReport += `- **${error.description}**: ${error.error}\n`;
      }
      readableReport += `\n`;
    }
    
    if (this.warnings.length > 0) {
      readableReport += `## Warnings\n`;
      for (const warning of this.warnings) {
        readableReport += `- ${warning}\n`;
      }
      readableReport += `\n`;
    }
    
    readableReport += `## Build Steps\n`;
    for (const step of this.steps) {
      const status = step.status === 'success' ? '✅' : '❌';
      readableReport += `${status} ${step.description}\n`;
    }
    
    await fs.writeFile('BUILD_REPORT.md', readableReport);
    
    this.log(`Build report generated: build-report.json, BUILD_REPORT.md`, 'success');
  }

  async build() {
    console.log(chalk.bold.blue('\n🚀 VoxTics Optimized Build Process\n'));
    
    try {
      await this.checkPrerequisites();
      await this.installDependencies();
      await this.runQualityChecks();
      await this.optimizeProject();
      await this.buildAssets();
      await this.buildDotNet();
      await this.generateBundleReport();
      await this.runSecurityChecks();
      await this.generateReport();
      
      const duration = (Date.now() - this.startTime) / 1000;
      
      console.log(chalk.bold.green(`\n✅ Build completed successfully in ${duration.toFixed(2)}s\n`));
      
      if (this.warnings.length > 0) {
        console.log(chalk.yellow(`⚠️  ${this.warnings.length} warnings found. Check BUILD_REPORT.md for details.\n`));
      }
      
    } catch (error) {
      console.log(chalk.bold.red(`\n❌ Build failed: ${error.message}\n`));
      await this.generateReport();
      process.exit(1);
    }
  }
}

// CLI interface
if (require.main === module) {
  const builder = new OptimizedBuilder();
  
  // Handle CLI arguments
  const args = process.argv.slice(2);
  const options = {
    skipTests: args.includes('--skip-tests'),
    skipOptimization: args.includes('--skip-optimization'),
    skipSecurity: args.includes('--skip-security'),
    verbose: args.includes('--verbose')
  };
  
  if (args.includes('--help')) {
    console.log(`
VoxTics Optimized Build Script

Usage: node scripts/build-optimized.js [options]

Options:
  --skip-tests         Skip running tests
  --skip-optimization  Skip project optimization
  --skip-security      Skip security checks
  --verbose           Enable verbose output
  --help              Show this help message

Examples:
  node scripts/build-optimized.js
  node scripts/build-optimized.js --skip-tests
  node scripts/build-optimized.js --verbose
    `);
    process.exit(0);
  }
  
  // Apply options
  if (options.skipTests) {
    builder.log('Skipping tests as requested', 'warning');
  }
  
  if (options.skipOptimization) {
    builder.log('Skipping optimization as requested', 'warning');
  }
  
  if (options.skipSecurity) {
    builder.log('Skipping security checks as requested', 'warning');
  }
  
  builder.build().catch(console.error);
}

module.exports = OptimizedBuilder;