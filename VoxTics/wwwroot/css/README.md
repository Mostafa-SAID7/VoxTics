# VoxTics Apple Keyboard+ Design System

## Overview

The VoxTics Design System is a comprehensive CSS framework inspired by Apple's Human Interface Guidelines with unique keyboard-inspired visual elements. It provides a unified, consistent, and accessible design language across the entire application.

## Architecture

### Core Files

1. **`apple-keyboard-plus.css`** - The foundational design system containing:
   - CSS Custom Properties (Design Tokens)
   - Base typography system
   - Component primitives (buttons, forms, cards, etc.)
   - Utility classes
   - Dark mode support
   - Accessibility features

2. **`voxtics-design-system.css`** - Main entry point that imports all components

### Component Libraries

Located in the `components/` directory:

- **`layout.css`** - Layout components (header, sidebar, footer, navigation)
- **`movies.css`** - Movie-specific components (cards, grids, hero sections)
- **`admin.css`** - Admin panel components (tables, forms, dashboards)

## Design Tokens

### Color System

The design system uses Apple's semantic color approach:

```css
/* Primary Colors */
--apple-blue: #007AFF;
--apple-green: #34C759;
--apple-orange: #FF9500;
--apple-red: #FF3B30;
--apple-purple: #AF52DE;

/* System Colors */
--system-background: #FFFFFF;
--system-background-secondary: #F2F2F7;
--label-primary: #000000;
--label-secondary: rgba(60, 60, 67, 0.60);
```

### Typography

Uses Apple's system font stack:

```css
--font-family-system: -apple-system, BlinkMacSystemFont, 'SF Pro Display', 'Segoe UI', 'Roboto', 'Helvetica Neue', Arial, sans-serif;
```

### Spacing Scale

Consistent spacing using a 4px base unit:

```css
--space-1: 0.25rem; /* 4px */
--space-2: 0.5rem;  /* 8px */
--space-3: 0.75rem; /* 12px */
--space-4: 1rem;    /* 16px */
/* ... up to --space-32 */
```

### Border Radius

Consistent rounded corners:

```css
--radius-sm: 6px;
--radius-md: 8px;
--radius-lg: 12px;
--radius-xl: 16px;
--radius-2xl: 20px;
--radius-full: 9999px;
```

## Key Features

### Apple Keyboard+ Elements

The design system includes unique keyboard-inspired visual elements:

- **Key-style buttons** with realistic shadows and press effects
- **Tactile feedback** through hover and active states
- **Layered shadows** mimicking physical keyboard keys

### Dark Mode Support

Automatic dark mode support using CSS custom properties and `prefers-color-scheme`:

```css
@media (prefers-color-scheme: dark) {
    :root {
        --system-background: var(--dark-system-background);
        --label-primary: var(--dark-label-primary);
    }
}
```

### Accessibility

- **Focus management** with visible focus indicators
- **High contrast mode** support
- **Reduced motion** support for users with vestibular disorders
- **Semantic color usage** with proper contrast ratios

### Glass Morphism

Modern glass effects using backdrop filters:

```css
.glass-effect {
    background: rgba(255, 255, 255, 0.1);
    backdrop-filter: blur(20px);
    -webkit-backdrop-filter: blur(20px);
    border: 1px solid rgba(255, 255, 255, 0.2);
}
```

## Component Usage

### Buttons

```html
<!-- Primary button -->
<button class="btn btn-primary">Book Now</button>

<!-- Secondary button -->
<button class="btn btn-secondary">Learn More</button>

<!-- Keyboard-style button -->
<button class="btn">Press Me</button>
```

### Cards

```html
<div class="card">
    <div class="card-header">
        <h3>Movie Title</h3>
    </div>
    <div class="card-body">
        <p>Movie description...</p>
    </div>
</div>
```

### Movie Components

```html
<div class="movies-grid">
    <div class="movie-card">
        <div class="movie-poster-container">
            <img src="poster.jpg" alt="Movie" class="movie-poster">
            <div class="movie-overlay">
                <button class="play-button">▶</button>
            </div>
        </div>
        <div class="movie-content">
            <h3 class="movie-title">Movie Title</h3>
            <div class="movie-actions">
                <a href="#" class="btn-book">Book Now</a>
                <a href="#" class="btn-details">Details</a>
            </div>
        </div>
    </div>
</div>
```

## Utility Classes

### Display

```css
.d-none { display: none !important; }
.d-flex { display: flex !important; }
.d-grid { display: grid !important; }
```

### Spacing

```css
.m-0 { margin: 0 !important; }
.p-4 { padding: var(--space-4) !important; }
```

### Colors

```css
.text-primary { color: var(--label-primary) !important; }
.bg-blue { background-color: var(--apple-blue) !important; }
```

## Responsive Design

The system uses a mobile-first approach with breakpoints:

- **Mobile**: < 768px
- **Tablet**: 768px - 1024px
- **Desktop**: > 1024px

## Migration from Legacy CSS

The old CSS files have been moved to `legacy-backup/` and consolidated into the new system:

### Replaced Files

- `site.css` → `apple-keyboard-plus.css`
- `adminlayout.css` → `components/admin.css`
- `mainlayout.css` → `components/layout.css`
- `notification.css` → Integrated into core system
- `pagination.css` → Integrated into core system
- All page-specific CSS → `components/movies.css`

### Benefits of Migration

1. **Reduced CSS size** - Eliminated duplicate styles
2. **Consistent design** - Unified color scheme and spacing
3. **Better maintainability** - Centralized design tokens
4. **Enhanced accessibility** - Built-in a11y features
5. **Dark mode support** - Automatic theme switching
6. **Modern CSS features** - CSS Grid, Flexbox, Custom Properties

## Usage in Views

Replace old CSS references with the new design system:

```html
<!-- Old -->
<link rel="stylesheet" href="~/css/site.css" />
<link rel="stylesheet" href="~/css/main/mainlayout.css" />

<!-- New -->
<link rel="stylesheet" href="~/css/voxtics-design-system.css" />
```

## Customization

To customize the design system, modify the CSS custom properties in `apple-keyboard-plus.css`:

```css
:root {
    /* Override default colors */
    --apple-blue: #0066CC;
    --border-radius-lg: 16px;
}
```

## Browser Support

- **Modern browsers**: Full support (Chrome 88+, Firefox 85+, Safari 14+)
- **Legacy browsers**: Graceful degradation with fallbacks
- **Mobile browsers**: Optimized for touch interfaces

## Performance

- **Optimized CSS**: Minimal redundancy and efficient selectors
- **Tree-shakable**: Unused styles can be removed in production
- **Compressed**: Minified version available for production

## Future Enhancements

- Component-specific CSS modules
- CSS-in-JS integration options
- Advanced animation library
- Theme customization tools