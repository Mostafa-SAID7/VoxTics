# VoxTics CSS Architecture

This document outlines the comprehensive CSS architecture and design system for the VoxTics cinema booking application.

## Overview

VoxTics uses a modern, global CSS architecture that eliminates page-specific stylesheets in favor of a unified design system built on:
- **Global CSS Variables** - Comprehensive design tokens for consistency
- **TailwindCSS Integration** - Utility-first CSS framework with custom extensions
- **Apple Keyboard+ Design System** - Custom design tokens and components
- **Component-based Architecture** - Reusable UI components across all pages
- **Responsive Design System** - Mobile-first approach with consistent breakpoints

## Architecture Status

✅ **Completed:**
- Foundation layer with comprehensive CSS variables
- Semantic design tokens system
- Theme support (light/dark mode with automatic switching)
- Complete component library (buttons, forms, cards, navigation, tables)
- VoxTics-specific components (movies, cinema, admin)
- Responsive utilities system
- Page-specific CSS file elimination
- TailwindCSS integration with custom tokens
- Cross-browser compatibility improvements (line-clamp standardization)

🔄 **In Progress:**
- HTML template migration to global classes
- Build system optimization
- Comprehensive testing and validation

## File Structure

```
VoxTics/wwwroot/css/
├── foundation/
│   ├── variables.css          # Core CSS custom properties
│   ├── tokens.css             # Semantic design tokens
│   └── themes.css             # Light/dark theme variations
├── base/
│   ├── reset.css              # CSS reset
│   ├── typography.css         # Typography styles
│   └── base.css               # Base element styles
├── components/
│   ├── buttons.css            # Button components
│   ├── forms.css              # Form components
│   ├── cards.css              # Card components
│   ├── navigation.css         # Navigation components
│   ├── tables.css             # Table components
│   ├── movie-components.css   # VoxTics movie-specific components
│   └── admin-components.css   # Admin interface components
├── utilities/
│   ├── layout.css             # Layout utilities
│   ├── spacing.css            # Spacing utilities
│   └── responsive.css         # Responsive utilities
├── critical.css               # Critical above-fold styles
├── input.css                  # TailwindCSS source
├── output.css                 # Compiled CSS output (production-ready)
└── voxtics-global.css         # Main compiled stylesheet
```

## Design Token System

### Foundation Variables
The system is built on comprehensive CSS custom properties organized by category:

#### Colors
```css
/* Brand Colors */
--color-primary: #007AFF;
--color-primary-light: #40A9FF;
--color-primary-dark: #0051D5;

/* Status Colors */
--color-success: #34C759;
--color-warning: #FF9500;
--color-danger: #FF3B30;

/* System Colors */
--system-background: #FFFFFF;
--system-background-secondary: #F2F2F7;
--system-fill: rgba(120, 120, 128, 0.2);
```

#### Spacing (8pt Grid System)
```css
--space-1: 0.25rem;   /* 4px */
--space-2: 0.5rem;    /* 8px */
--space-4: 1rem;      /* 16px */
--space-6: 1.5rem;    /* 24px */
--space-8: 2rem;      /* 32px */
/* ... up to --space-96: 24rem (384px) */
```

#### Typography
```css
--font-family-system: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif;
--text-xs: 0.75rem;   /* 12px */
--text-sm: 0.875rem;  /* 14px */
--text-base: 1rem;    /* 16px */
/* ... up to --text-9xl: 8rem (128px) */
```

### Semantic Tokens
Higher-level tokens that provide semantic meaning:

```css
/* Interactive States */
--color-interactive-primary: var(--color-primary);
--color-interactive-primary-hover: var(--color-primary-light);
--color-interactive-primary-active: var(--color-primary-dark);

/* Component Spacing */
--spacing-component-xs: var(--space-1);
--spacing-component-sm: var(--space-2);
--spacing-component-md: var(--space-4);

/* VoxTics-Specific */
--color-seat-available: var(--color-success);
--color-seat-selected: var(--color-primary);
--color-seat-occupied: var(--color-text-tertiary);
```

## Component System

### Button Components
```css
.btn                    /* Base button styles */
.btn-primary           /* Primary action button */
.btn-secondary         /* Secondary button */
.btn-success           /* Success/confirmation buttons */
.btn-warning           /* Warning buttons */
.btn-danger            /* Danger/delete buttons */
.btn-ghost             /* Transparent button */
.btn-outline           /* Outlined button */

/* Sizes */
.btn-xs, .btn-sm, .btn-lg, .btn-xl

/* Shapes */
.btn-square, .btn-circle, .btn-pill

/* Special */
.btn-loading, .btn-fab, .btn-apple
```

### Form Components
```css
.form-group            /* Form field container */
.form-label            /* Form labels with variants */
.form-control          /* Input fields */
.form-control-apple    /* Apple-styled inputs */
.search-input          /* Search input with icon */

/* Validation States */
.is-valid, .is-invalid
.valid-feedback, .invalid-feedback

/* Input Types */
.form-check            /* Checkboxes and radios */
.form-switch           /* Toggle switches */
.form-range            /* Range sliders */
.form-file             /* File inputs */
```

### Card Components
```css
.card                  /* Base card component */
.movie-card            /* Movie display cards */
.cinema-card           /* Cinema location cards */
.booking-card          /* Booking summary cards */
.admin-card            /* Admin interface cards */
.dashboard-card        /* Admin dashboard widgets */
```

### VoxTics-Specific Components
```css
/* Movie Components */
.movie-poster          /* Movie poster container */
.movie-rating          /* Star rating display */
.movie-genre-tags      /* Genre tag styling */
.showtime-grid         /* Showtime selection grid */
.showtime-button       /* Individual showtime buttons */

/* Cinema Components */
.cinema-info           /* Cinema details and amenities */
.hall-layout           /* Cinema hall seating layout */
.seat-map              /* Interactive seat selection */
.seat-available        /* Available seat styling */
.seat-selected         /* Selected seat styling */
.seat-occupied         /* Occupied seat styling */

/* Admin Components */
.admin-dashboard       /* Dashboard layout */
.admin-stats           /* Statistics cards */
.admin-table           /* Data tables for admin */
.admin-sidebar         /* Admin navigation sidebar */
```

## Theme System

### Automatic Theme Switching
```css
/* Light Theme (Default) */
:root {
    --theme-background: #FFFFFF;
    --theme-text-primary: #000000;
}

/* Dark Theme */
@media (prefers-color-scheme: dark) {
    :root {
        --theme-background: #000000;
        --theme-text-primary: #FFFFFF;
    }
}

/* Manual Theme Classes */
[data-theme="dark"] { /* Dark theme overrides */ }
[data-theme="light"] { /* Light theme overrides */ }
```

### Accessibility Support
```css
/* High Contrast */
@media (prefers-contrast: high) { /* Enhanced contrast */ }

/* Reduced Motion */
@media (prefers-reduced-motion: reduce) { /* Disable animations */ }
```

## Responsive Design System

### Breakpoints (Mobile-First)
```css
/* Base styles: 0px and up */
@media (min-width: 640px)  { /* sm */ }
@media (min-width: 768px)  { /* md */ }
@media (min-width: 1024px) { /* lg */ }
@media (min-width: 1280px) { /* xl */ }
@media (min-width: 1536px) { /* 2xl */ }
```

### Responsive Utilities
```css
/* Layout */
.grid-cols-1, .sm:grid-cols-2, .lg:grid-cols-3
.hidden, .md:block, .lg:flex

/* Typography */
.text-base, .md:text-lg, .lg:text-xl

/* Spacing */
.p-4, .md:p-6, .lg:p-8
.gap-4, .md:gap-6, .lg:gap-8
```

## TailwindCSS Integration

### Custom Configuration
The TailwindCSS configuration extends the default setup with:
- Apple Keyboard+ design system colors
- Custom spacing based on 8pt grid
- VoxTics-specific component plugins
- Custom animations and effects
- Production purging with safelist

### Utility Class Mapping
```css
/* CSS Variables → Tailwind Utilities */
--color-primary     → bg-apple-blue, text-apple-blue
--space-4           → p-4, m-4, gap-4
--text-lg           → text-lg
--radius-lg         → rounded-lg
```

## Build Process

### CSS Processing Pipeline
1. **Foundation** - CSS variables and tokens loaded first
2. **Base** - Reset and typography styles
3. **Components** - Reusable component styles
4. **Utilities** - TailwindCSS utilities and custom utilities
5. **Optimization** - Purging and minification

### Build Commands
```bash
# Development with hot reload
npm run dev

# Build CSS only
npm run build-css

# Production build with optimization
npm run build

# CSS linting
npm run lint-css
```

### Webpack Configuration
- PostCSS processing with autoprefixer
- TailwindCSS compilation and purging
- CSS optimization and minification
- Source map generation for development

## Migration Status

### ✅ Completed Tasks
1. **Foundation Setup** - CSS variables and file structure created
2. **Component System** - All major components implemented
3. **Theme System** - Light/dark mode support with automatic switching
4. **Responsive System** - Mobile-first utilities and breakpoints
5. **TailwindCSS Integration** - Custom tokens and component plugins
6. **Page-Specific CSS Removal** - All page-specific files eliminated

### 🔄 Current Tasks
1. **Template Migration** - Converting HTML templates to use global classes
2. **Build Optimization** - CSS purging and bundle size optimization
3. **Testing & Validation** - Visual regression and consistency testing

### 📋 Remaining Tasks
1. **Documentation** - Complete component usage examples
2. **Performance Testing** - Bundle size and load time optimization
3. **Integration Testing** - Cross-browser and device testing

## Usage Guidelines

### Component Usage
```html
<!-- Button Examples -->
<button class="btn btn-primary">Primary Action</button>
<button class="btn btn-secondary btn-sm">Small Secondary</button>

<!-- Card Examples -->
<div class="card movie-card">
    <img src="poster.jpg" class="movie-poster" alt="Movie">
    <div class="movie-content">
        <h3 class="movie-title">Movie Title</h3>
    </div>
</div>

<!-- Form Examples -->
<div class="form-group">
    <label class="form-label form-label-required">Email</label>
    <input type="email" class="form-control" placeholder="Enter email">
</div>
```

### Responsive Design
```html
<!-- Responsive Grid -->
<div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
    <!-- Content -->
</div>

<!-- Responsive Typography -->
<h1 class="text-2xl md:text-3xl lg:text-4xl">Responsive Heading</h1>
```

### Theme Integration
```html
<!-- Theme Toggle -->
<button onclick="toggleTheme()" class="btn btn-ghost">
    Toggle Dark Mode
</button>

<script>
function toggleTheme() {
    document.documentElement.setAttribute(
        'data-theme', 
        document.documentElement.getAttribute('data-theme') === 'dark' ? 'light' : 'dark'
    );
}
</script>
```

## Performance Considerations

### CSS Bundle Optimization
- Production builds use TailwindCSS purging to remove unused styles
- Critical CSS is inlined for above-fold content
- Non-critical CSS is loaded asynchronously
- CSS variables reduce bundle size through value reuse

### Cross-Browser Compatibility
- Modern CSS properties with fallbacks (e.g., `line-clamp` with `-webkit-line-clamp`)
- Progressive enhancement for advanced features
- Graceful degradation for older browsers

### Loading Strategy
1. **Critical CSS** - Inlined in `<head>` for immediate rendering
2. **Main CSS** - Loaded with high priority
3. **Component CSS** - Loaded on demand for specific features

## Recent Improvements

### Text Truncation Enhancement (Latest)
Enhanced the movie title truncation in `movie-components.css` with improved cross-browser support:

```css
.movie-title {
    display: -webkit-box;
    -webkit-line-clamp: 2;
    line-clamp: 2;              /* ← Added standard property */
    -webkit-box-orient: vertical;
    overflow: hidden;
}
```

**Benefits:**
- **Better Browser Support**: Standard `line-clamp` property for modern browsers
- **Fallback Compatibility**: Maintains `-webkit-line-clamp` for older WebKit browsers
- **Consistent Text Truncation**: Ensures movie titles display consistently across all browsers
- **Future-Proof**: Aligns with CSS standards as browser support improves

This architecture provides a scalable, maintainable CSS system that eliminates duplication while preserving all VoxTics functionality and visual design.