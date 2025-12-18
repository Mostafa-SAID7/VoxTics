# Global CSS Architecture Design Document

## Overview

This design document outlines the comprehensive refactoring of VoxTics' CSS architecture from page-specific styles to a unified global style system. The refactoring will eliminate CSS duplication, improve maintainability, and create a scalable design system that leverages both custom CSS variables and TailwindCSS utilities.

The current VoxTics application already has a solid foundation with TailwindCSS configured and a global CSS file (`voxtics-global.css`) containing Apple Keyboard+ design system components. This refactoring will build upon this foundation to create a complete global style system.

## Architecture

### Current State Analysis
- **Existing Assets**: TailwindCSS is configured with comprehensive Apple Keyboard+ design system including custom colors, spacing, typography, animations, and component plugins
- **Foundation Layer**: CSS variables are established in `foundation/variables.css` with basic color, spacing, and typography tokens (needs expansion for complete coverage)
- **Critical CSS**: Basic critical styles exist in `critical.css` with minimal CSS variables and essential above-fold styling
- **TailwindCSS Configuration**: Extensive configuration with Apple design system colors, 8pt grid spacing, custom animations, glass morphism, and component plugins (`.btn-apple`, `.card-apple`, `.input-apple`)
- **Page Structure**: ASP.NET Core MVC with Razor views organized by Areas (Admin, Identity) and Controllers
- **Build System**: Webpack with PostCSS for CSS processing, npm scripts for build automation, TailwindCSS purging configured for production
- **Current Issues**: Page-specific CSS files exist throughout the application that need to be eliminated to reduce duplication and inconsistencies

### Target Architecture
The new architecture will follow a **Design System First** approach with complete elimination of page-specific CSS files. The system will have these layers:

1. **Foundation Layer**: CSS variables and design tokens (centralized in global files)
2. **Base Layer**: Reset styles and typography (no page-specific overrides)
3. **Component Layer**: Reusable UI components (replacing all page-specific component styles)
4. **Utility Layer**: TailwindCSS utilities and custom utilities (globally available)
5. **Layout Layer**: Global layout classes (eliminating page-specific layout CSS)

### Migration Strategy
The refactoring will systematically:
- **Remove all page-specific CSS files** from components and features directories
- **Extract reusable patterns** from existing page-specific styles into global components
- **Convert hardcoded values** to CSS custom properties for consistency
- **Update all HTML templates** to use global classes instead of page-specific ones

### File Structure
The new structure eliminates all page-specific CSS files and organizes everything globally:

```
VoxTics/wwwroot/css/
├── foundation/
│   ├── variables.css          # CSS custom properties (EXISTING - needs expansion)
│   ├── tokens.css             # Semantic design tokens (NEW)
│   └── themes.css             # Light/dark theme variations (NEW)
├── base/
│   ├── reset.css              # CSS reset (NEW)
│   ├── typography.css         # Typography styles (NEW)
│   └── base.css               # Base element styles (NEW)
├── components/
│   ├── buttons.css            # Button components (NEW - extract from pages)
│   ├── forms.css              # Form components (NEW - extract from pages)
│   ├── cards.css              # Card components (NEW - movie cards, admin cards)
│   ├── navigation.css         # Navigation components (NEW - navbar, admin sidebar)
│   ├── tables.css             # Table components (NEW - admin tables, data tables)
│   ├── movie-components.css   # VoxTics-specific components (NEW)
│   └── admin-components.css   # Admin-specific components (NEW)
├── utilities/
│   ├── layout.css             # Layout utilities (NEW)
│   ├── spacing.css            # Spacing utilities (NEW)
│   └── responsive.css         # Responsive utilities (NEW)
├── critical.css               # Critical above-fold styles (EXISTING - needs refactoring)
└── voxtics-global.css         # Main compiled stylesheet (EXISTING - needs restructuring)

# Files to be REMOVED during refactoring:
# - All page-specific CSS files in Areas/Admin/Views/
# - All page-specific CSS files in Areas/Identity/Views/
# - All page-specific CSS files in Views/
# - Any component-specific CSS files scattered throughout the project
# - Feature-specific CSS files that duplicate global patterns
```

## Components and Interfaces

### CSS Variable System
The foundation will be built on CSS custom properties that replace ALL hardcoded values throughout the application, expanding the existing foundation:

**Color System** (expanding existing variables)
- Primary colors (Apple blue variants: `--color-primary`, `--color-primary-light`, `--color-primary-dark`) - already established
- System colors (backgrounds, fills, labels) - partially established, needs expansion for complete coverage
- Semantic colors (`--color-success`, `--color-warning`, `--color-danger`) - already established
- Theme-aware colors with automatic dark mode support - needs implementation
- **Current State**: Basic color variables exist, need expansion for comprehensive coverage
- **Migration**: All existing hardcoded color values will be converted to use these variables

**Spacing System** (expanding existing 8pt grid)
- 8pt grid system aligned with Apple design principles - partially established (--space-0 through --space-12)
- Needs expansion to complete range from 2px to 384px (--space-1 through --space-96)
- Responsive spacing modifiers - needs implementation
- **Current State**: Basic spacing tokens exist up to 48px, need expansion for larger values
- **Migration**: All hardcoded margins, padding, and gap values will use these tokens

**Typography System** (expanding existing foundation)
- SF Pro Display font family with fallbacks (`--font-family-system`) - already established
- Font weight variations (`--font-weight-normal` through `--font-weight-bold`) - already established
- Consistent font sizes and line heights (--text-xs through --text-5xl) - needs implementation
- **Current State**: Basic typography variables exist, need expansion for complete scale
- **Migration**: All font-size, line-height, and font-weight values will use these variables

**Layout System** (new implementation needed)
- Container max-widths (--container-max-width) - needs implementation
- Sidebar dimensions (--sidebar-width, --sidebar-collapsed-width) - needs implementation
- Header heights (--header-height) - needs implementation
- Z-index layers (--z-sticky, --z-fixed, --z-modal) - needs implementation

**Shadow and Effects System** (leveraging TailwindCSS foundation)
- Apple-specific shadow tokens (--shadow-apple-sm, --shadow-apple-md, --shadow-apple-lg)
- Glass morphism effects (--glass-background, --glass-border)
- Animation timing tokens (--transition-fast, --transition-normal) - needs implementation

### Component Architecture
Each component will be self-contained, composable, and replace all page-specific styling:

**Button System** (replaces all page-specific button styles)
```css
.btn                /* Base button styles */
.btn-primary        /* Primary action button */
.btn-secondary      /* Secondary action button */
.btn-success        /* Success/confirmation buttons */
.btn-warning        /* Warning buttons */
.btn-danger         /* Danger/delete buttons */
.btn-sm, .btn-lg    /* Size variations */
```

**Card System** (replaces all page-specific card styles)
```css
.card               /* Base card component */
.movie-card         /* Movie display cards for browsing */
.cinema-card        /* Cinema location cards */
.booking-card       /* Booking summary cards */
.admin-card         /* Admin interface cards */
.dashboard-card     /* Admin dashboard widgets */
.card-title         /* Consistent card titles */
.card-content       /* Card content area */
.card-actions       /* Card action buttons */
```

**Form System** (replaces all page-specific form styles)
```css
.form-group         /* Form field container */
.form-label         /* Form labels */
.form-control       /* Input fields */
.input-apple        /* Apple-styled inputs */
```

**Navigation System** (replaces all page-specific navigation styles)
```css
.navbar             /* Main public navigation bar */
.nav-link           /* Navigation links */
.nav-brand          /* VoxTics brand/logo area */
.admin-sidebar      /* Admin area sidebar navigation */
.admin-nav-item     /* Admin navigation items */
.breadcrumb         /* Breadcrumb navigation */
.pagination         /* Pagination controls */
.user-menu          /* User account dropdown menu */
```

**Table System** (replaces all page-specific table styles)
```css
.table              /* Base table styles */
.table-admin        /* Admin interface tables */
.table-responsive   /* Responsive table wrapper */
.table th           /* Table headers */
.table td           /* Table cells */
.table-actions      /* Action buttons in tables */
.table-status       /* Status indicators in tables */
.table-pagination   /* Table pagination controls */
```

**Component Naming Convention**
- **Block**: `.component-name` (e.g., `.movie-card`)
- **Element**: `.component-name__element` (e.g., `.movie-card__title`)
- **Modifier**: `.component-name--modifier` (e.g., `.movie-card--featured`)
- **Utility**: `.u-utility-name` (e.g., `.u-text-center`)

### TailwindCSS Integration
The existing comprehensive TailwindCSS configuration with Apple Keyboard+ design system will be enhanced to support the global style system:

**Current TailwindCSS Assets**
- Apple Keyboard+ design system colors already configured (apple.blue, apple.gray-*, system.*, label.*)
- Comprehensive spacing system based on 8pt grid (0.5rem to 24rem)
- Custom animations and keyframes for smooth interactions (fade-in, slide-in, bounce-gentle, glow, shimmer)
- Glass morphism and backdrop blur utilities (`.glass` component, backdrop-blur variants)
- Custom component plugins for buttons, cards, and inputs (`.btn-apple`, `.card-apple`, `.input-apple`, `.key`)
- Apple-specific shadows and effects (apple-sm, apple-md, apple-lg, key shadows)
- Typography system with SF Pro Display font family
- Form styling with @tailwindcss/forms plugin
- Production purging configured with safelist for critical classes

**CSS Variable Integration**
- Import all CSS custom properties from `foundation/variables.css` as Tailwind tokens
- Extend existing color palette with VoxTics-specific brand colors
- Map spacing tokens to Tailwind utilities for consistent spacing
- Ensure typography tokens are accessible through Tailwind classes

**Custom Component Integration**
- Enhance existing `.btn-apple`, `.card-apple`, `.input-apple` components
- Add VoxTics-specific components like `.movie-card`, `.cinema-card`
- Maintain utility-first approach for layout and spacing
- Provide both utility classes and component classes for flexibility

**Build Optimization**
- Leverage existing purge configuration to remove unused styles
- Maintain optimal bundle size through intelligent CSS purging
- Ensure all global classes are preserved in production builds
- Use safelist to protect critical VoxTics component classes

**Enhanced Utility Class Mapping**
```css
/* CSS Variables become Tailwind utilities */
--color-primary     → bg-apple-blue, text-apple-blue
--space-4           → p-4, m-4, gap-4
--text-lg           → text-lg
--radius-lg         → rounded-lg
--system-background → bg-system-background
--font-family-system → font-sf-pro
```

## Data Models

### CSS Variable Schema
```css
:root {
  /* Color Tokens */
  --color-primary: #007AFF;
  --color-primary-light: #40A9FF;
  --color-primary-dark: #0051D5;
  
  /* System Colors */
  --system-background: #FFFFFF;
  --system-background-secondary: #F2F2F7;
  --system-fill: rgba(120, 120, 128, 0.2);
  
  /* Spacing Tokens */
  --space-1: 0.25rem;  /* 4px */
  --space-2: 0.5rem;   /* 8px */
  --space-3: 0.75rem;  /* 12px */
  /* ... continuing 8pt grid */
  
  /* Typography Tokens */
  --font-family-system: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif;
  --text-xs: 0.75rem;
  --text-sm: 0.875rem;
  --text-base: 1rem;
  /* ... continuing scale */
  
  /* Layout Tokens */
  --container-max-width: 1200px;
  --sidebar-width: 280px;
  --header-height: 64px;
  
  /* Animation Tokens */
  --transition-fast: all 0.15s ease-in-out;
  --transition-normal: all 0.3s ease-in-out;
}
```

### CSS File Organization and Naming Conventions

**File Organization Strategy**
- **Logical categorization**: Styles organized by function (variables, base, components, utilities)
- **Clear naming conventions**: Consistent file and class naming throughout the system
- **Proper import order**: Dependencies managed through structured imports
- **Documentation**: Each CSS file includes header comments explaining its purpose

**Class Naming Conventions**
- **Component Classes**: `.component-name` (e.g., `.movie-card`, `.admin-sidebar`)
- **Element Classes**: `.component-name__element` (e.g., `.movie-card__title`)
- **Modifier Classes**: `.component-name--modifier` (e.g., `.movie-card--featured`)
- **Utility Classes**: `.u-utility-name` (e.g., `.u-text-center`, `.u-hidden`)
- **State Classes**: `.is-state` (e.g., `.is-active`, `.is-loading`)

**Scalable Architecture**
The file structure and naming conventions are designed to support future feature development without style conflicts, ensuring the system remains maintainable as the application grows.

### Responsive Design System
The global responsive system will replace all inline media queries with utility classes:

**Breakpoint System** (Mobile First Approach)
```css
/* Base styles: 0px and up */
@media (min-width: 640px)  { /* sm */ }
@media (min-width: 768px)  { /* md */ }
@media (min-width: 1024px) { /* lg */ }
@media (min-width: 1280px) { /* xl */ }
@media (min-width: 1536px) { /* 2xl */ }
```

**Responsive Utilities** (replacing all inline media queries)
```css
/* Layout utilities with breakpoint prefixes */
.grid-cols-1, .sm:grid-cols-2, .lg:grid-cols-3
.hidden, .md:block, .lg:flex
.p-4, .md:p-6, .lg:p-8

/* Typography utilities with breakpoint prefixes */
.text-base, .md:text-lg, .lg:text-xl
.font-normal, .md:font-medium, .lg:font-bold

/* Spacing utilities with breakpoint prefixes */
.space-y-4, .md:space-y-6, .lg:space-y-8
.gap-4, .md:gap-6, .lg:gap-8
```

**Consistent Breakpoint Definitions**
All components and utilities will use the same breakpoint definitions, eliminating inconsistencies across the application. The responsive system will ensure all existing responsive behavior is maintained through global utility classes.

## Correctness Properties

*A property is a characteristic or behavior that should hold true across all valid executions of a system-essentially, a formal statement about what the system should do. Properties serve as the bridge between human-readable specifications and machine-verifiable correctness guarantees.*

Based on the prework analysis, the following properties ensure the global CSS system maintains correctness after eliminating redundancy:

**Property 1: Visual Consistency Preservation**
*For any* page in the VoxTics application, the visual appearance and functionality should remain identical before and after the CSS refactoring
**Validates: Requirements 1.2, 6.2, 6.5**

**Property 2: Page-Specific CSS File Elimination**
*For any* directory in the VoxTics application, it should contain no page-specific CSS files after the refactoring is complete
**Validates: Requirements 1.1**

**Property 3: CSS Rule Migration Completeness**
*For any* CSS rule that existed in page-specific files, it should be preserved in the appropriate global CSS file after migration
**Validates: Requirements 1.3**

**Property 4: Template Reference Elimination**
*For any* HTML template in the application, it should contain no references to removed page-specific CSS files
**Validates: Requirements 1.4, 6.4**

**Property 5: Global Directory Structure Organization**
*For any* CSS file in the system, it should be organized in the logical categories (variables, base, components, utilities) with proper naming conventions
**Validates: Requirements 1.5, 7.1, 7.2**

**Property 6: Design Token Completeness**
*For any* color, spacing, or typography value used in the application, it should be defined as a CSS custom property rather than a hardcoded value
**Validates: Requirements 2.1, 2.3, 2.5**

**Property 7: CSS Variable Organization**
*For any* CSS custom property in the system, it should be organized logically by category in the appropriate foundation files
**Validates: Requirements 2.2**

**Property 8: Theme Variable Consistency**
*For any* CSS custom property in the theme system, switching between light and dark themes should result in appropriate value changes without breaking layout
**Validates: Requirements 2.4**

**Property 9: Responsive Utility Completeness**
*For any* major layout property, breakpoint-specific utility classes should be available following mobile-first patterns
**Validates: Requirements 3.1, 3.2**

**Property 10: Responsive Behavior Preservation**
*For any* responsive behavior that existed before refactoring, it should be maintained through global utility classes with identical breakpoint behavior
**Validates: Requirements 3.3**

**Property 11: Breakpoint Consistency**
*For any* responsive utility or component, it should use consistent breakpoint definitions throughout the application
**Validates: Requirements 3.4**

**Property 12: Media Query Elimination**
*For any* CSS file in the global system, it should contain no inline media queries, with all responsive behavior handled through utility classes
**Validates: Requirements 3.5**

**Property 13: Component Pattern Extraction**
*For any* reusable UI pattern in the application, it should be available as a global component class with modifier support
**Validates: Requirements 4.1, 4.4**

**Property 14: Component Self-Containment**
*For any* component class in the global system, it should be self-contained and composable without external dependencies
**Validates: Requirements 4.2**

**Property 15: Component Visual Consistency**
*For any* UI component type (button, card, form field), all instances across different pages should render with identical visual properties when using the same component class
**Validates: Requirements 4.3**

**Property 16: CSS Rule Deduplication**
*For any* common UI element, there should be no duplicate styling rules across the global CSS system
**Validates: Requirements 4.5**

**Property 17: TailwindCSS Token Integration**
*For any* custom design token, it should be properly integrated into the TailwindCSS configuration and accessible through utility classes
**Validates: Requirements 5.1, 5.3**

**Property 18: Style System Balance**
*For any* styling implementation, the system should use TailwindCSS utilities where appropriate while maintaining custom components for complex patterns
**Validates: Requirements 5.2**

**Property 19: Style System Cohesion**
*For any* styling implementation, custom styles and TailwindCSS utilities should work together without conflicts
**Validates: Requirements 5.4**

**Property 20: Build Optimization**
*For any* production build, unused CSS styles should be purged while maintaining all actively used styles
**Validates: Requirements 5.5**

**Property 21: Global Class Migration**
*For any* HTML template in the application, all styling should be achieved through global utility and component classes
**Validates: Requirements 6.1**

**Property 22: Template System Coverage**
*For any* Razor view, partial view, or layout file, it should use the new global style system consistently
**Validates: Requirements 6.3**

**Property 23: CSS Import Order Management**
*For any* CSS file in the global system, it should be imported in the correct order with proper dependency management
**Validates: Requirements 7.3**

**Property 24: Documentation Completeness**
*For any* aspect of the CSS architecture and naming conventions, comprehensive documentation should be available
**Validates: Requirements 7.4**

**Property 25: System Scalability**
*For any* future feature development, the system should support new additions without creating style conflicts
**Validates: Requirements 7.5**

**Property 26: JavaScript Module Separation**
*For any* JavaScript module in the system, utility functions should be separated from feature-specific code with clear boundaries
**Validates: Requirements 8.2**

**Property 27: JavaScript Functionality Preservation**
*For any* existing JavaScript functionality, it should continue to work identically after module reorganization
**Validates: Requirements 8.3**

**Property 28: JavaScript Module Dependencies**
*For any* JavaScript module, it should have clear dependencies without circular references
**Validates: Requirements 8.4**

**Property 29: JavaScript Naming Consistency**
*For any* JavaScript file in the system, it should follow consistent naming conventions aligned with the CSS architecture
**Validates: Requirements 8.5**

**Property 30: Tailwind Migration Visual Preservation**
*For any* page in the application, visual appearance and functionality should remain identical before and after Tailwind migration
**Validates: Requirements 9.2, 9.5**

**Property 31: Design Token Consistency in Tailwind**
*For any* spacing, color, or typography value in the application, it should use defined design tokens rather than hardcoded values after Tailwind migration
**Validates: Requirements 9.3**

**Property 32: Custom CSS Minimization**
*For any* CSS in the final system, custom CSS should be limited to complex components that cannot be achieved with Tailwind utilities
**Validates: Requirements 9.4**

**Property 33: JavaScript-Applied Style Preservation**
*For any* CSS rule that is dynamically applied via JavaScript, it should continue to function after unused style removal
**Validates: Requirements 10.2**

**Property 34: CSS Rule Deduplication Complete**
*For any* CSS rule in the final system, there should be no duplicate rules or redundant declarations
**Validates: Requirements 10.3**

**Property 35: Cleanup Visual Consistency**
*For any* page in the application, it should render identically before and after unused style removal
**Validates: Requirements 10.4**

**Property 36: CSS Bundle Optimization**
*For any* CSS rule in the final bundle, it should be actively used somewhere in the application
**Validates: Requirements 10.5**

## Error Handling

### CSS Fallback Strategy
- **Font Fallbacks**: System font stack ensures consistent typography across platforms
- **Color Fallbacks**: Hex color fallbacks for CSS variables in older browsers
- **Feature Detection**: `@supports` queries for advanced CSS features

### Build Process Error Handling
- **Missing Dependencies**: Webpack will fail fast if required CSS files are missing
- **Syntax Errors**: PostCSS and Stylelint will catch CSS syntax issues during build
- **Unused Styles**: TailwindCSS purge will warn about potentially unused custom classes

### Runtime Error Prevention
- **Specificity Management**: BEM methodology prevents CSS specificity conflicts
- **Namespace Isolation**: Component classes use consistent prefixes to avoid collisions
- **Graceful Degradation**: Progressive enhancement ensures functionality without advanced CSS

## Testing Strategy

### Dual Testing Approach
The testing strategy combines both unit testing and property-based testing to ensure comprehensive coverage:

**Unit Testing**
- Visual regression tests for component rendering
- Cross-browser compatibility tests
- Theme switching functionality tests
- Responsive breakpoint behavior tests

**Property-Based Testing**
- CSS variable resolution across different contexts
- Component consistency across page types
- Theme application completeness
- Build optimization effectiveness

**Testing Tools**
- **Stylelint**: CSS linting and code quality
- **Backstop.js**: Visual regression testing
- **Jest**: JavaScript unit tests for build processes
- **Playwright**: Cross-browser integration testing

**Property-Based Testing Configuration**
- Minimum 100 iterations per property test
- Random component generation for consistency testing
- Automated theme switching validation
- Build output verification

Each property-based test will be tagged with comments referencing the specific correctness property:
```javascript
// **Feature: global-css-architecture, Property 1: Style Consistency**
test('component classes render consistently across pages', () => {
  // Property test implementation
});
```

### Integration Testing
- **Template Rendering**: Verify all Razor views render correctly with global styles
- **Admin Interface**: Ensure admin area maintains functionality with new CSS architecture
- **Mobile Responsiveness**: Test responsive behavior across device sizes
- **Performance**: Measure CSS bundle size and load times

### Validation Criteria
- All existing visual functionality preserved
- No broken layouts or missing styles
- Consistent component appearance across pages
- Successful theme switching
- Optimized CSS bundle size
- Zero references to removed CSS files in templates

### VoxTics-Specific Component Requirements

Based on the VoxTics cinema booking system, the following domain-specific components need to be created:

**Movie Components**
```css
.movie-card         /* Movie display cards with poster, title, rating */
.movie-poster       /* Movie poster image container */
.movie-details      /* Movie information layout */
.movie-rating       /* Star rating display */
.movie-genre-tags   /* Genre tag styling */
.showtime-grid      /* Showtime selection grid */
.showtime-button    /* Individual showtime buttons */
```

**Cinema Components**
```css
.cinema-card        /* Cinema location cards */
.cinema-info        /* Cinema details and amenities */
.hall-layout        /* Cinema hall seating layout */
.seat-map           /* Interactive seat selection */
.seat-available     /* Available seat styling */
.seat-selected      /* Selected seat styling */
.seat-occupied      /* Occupied seat styling */
```

**Booking Components**
```css
.booking-summary    /* Booking details summary */
.booking-card       /* Individual booking cards */
.ticket-info        /* Ticket information display */
.payment-form       /* Payment form styling */
.booking-status     /* Booking status indicators */
```

**Admin Components**
```css
.admin-dashboard    /* Dashboard layout */
.admin-stats        /* Statistics cards */
.admin-table        /* Data tables for admin */
.admin-form         /* Admin form styling */
.admin-sidebar      /* Admin navigation sidebar */
```

## Implementation Phases

### Phase 1: Foundation and Cleanup
- **Audit existing page-specific CSS files** across Areas (Admin, Identity) and main Views
- **Remove all page-specific CSS files** from components and features directories
- **Expand existing CSS variables** in `foundation/variables.css` with missing tokens
- **Create modular CSS file structure** building on existing foundation
- **Update build process** to integrate new structure with existing Webpack configuration

### Phase 2: Global System Implementation
- **Convert all hardcoded values** to CSS custom properties throughout the application
- **Extract reusable component patterns** from removed page-specific styles
- **Create VoxTics-specific component classes** for movies, cinemas, bookings, and admin
- **Enhance existing TailwindCSS configuration** with VoxTics-specific tokens
- **Implement responsive utilities** to replace inline media queries

### Phase 3: Template Migration and Integration
- **Update all Razor views** in Areas/Admin, Areas/Identity, and main Views
- **Remove all references** to deleted page-specific CSS files from HTML templates
- **Apply global component and utility classes** throughout the application
- **Validate visual consistency** across all pages, areas, and responsive breakpoints
- **Test admin interface functionality** with new global styles

### Phase 4: Optimization and Documentation
- **Implement CSS purging and optimization** for production builds using existing configuration
- **Add comprehensive test coverage** for visual regression and consistency
- **Create documentation** for the CSS architecture and VoxTics-specific naming conventions
- **Performance optimization** and bundle size validation
- **Integration testing** with existing build scripts and deployment process

## JavaScript Architecture Organization

### Current JavaScript State
The VoxTics application currently has minimal JavaScript organization:
- **Single File**: `VoxTics/wwwroot/js/site.js` contains all global functionality
- **Functionality**: Bootstrap initialization, scroll-to-top, lazy loading, global utilities
- **Libraries**: Bootstrap, jQuery, SweetAlert2, Toastr for notifications
- **No Modular Structure**: All code exists in a single file without clear separation of concerns

### Target JavaScript Architecture
Following the same organizational principles as the CSS architecture, JavaScript will be structured into logical modules:

```
VoxTics/wwwroot/js/
├── core/
│   ├── app.js                 # Main application initialization
│   ├── config.js              # Global configuration and constants
│   └── utils.js               # Global utility functions
├── components/
│   ├── modals.js              # Modal functionality
│   ├── tooltips.js            # Tooltip initialization
│   ├── forms.js               # Form validation and handling
│   └── navigation.js          # Navigation interactions
├── features/
│   ├── movies.js              # Movie-specific functionality
│   ├── booking.js             # Booking flow interactions
│   ├── cinema.js              # Cinema and seat selection
│   └── admin.js               # Admin interface functionality
├── utilities/
│   ├── formatters.js          # Data formatting utilities
│   ├── validators.js          # Input validation helpers
│   ├── api.js                 # API communication helpers
│   └── storage.js             # Local storage utilities
└── site.js                    # Main entry point (imports all modules)
```

### JavaScript Module Organization Strategy
- **Core Modules**: Essential application functionality and configuration
- **Component Modules**: Reusable UI component behaviors
- **Feature Modules**: Domain-specific functionality (movies, booking, admin)
- **Utility Modules**: Helper functions and common operations
- **Entry Point**: Single `site.js` file that imports and initializes all modules

### Module Dependencies and Loading
```javascript
// site.js - Main entry point
import { initializeApp } from './core/app.js';
import { initializeComponents } from './components/index.js';
import { initializeFeatures } from './features/index.js';

document.addEventListener('DOMContentLoaded', function() {
    initializeApp();
    initializeComponents();
    initializeFeatures();
});
```

## Page Review and Tailwind Migration Strategy

### Current Page Analysis Requirements
Each page in the VoxTics application needs systematic review to:
1. **Identify Custom CSS Usage**: Find all instances where custom CSS is used instead of Tailwind utilities
2. **Evaluate Tailwind Opportunities**: Determine where Tailwind utilities can replace custom styles
3. **Preserve Complex Components**: Identify components that require custom CSS due to complexity
4. **Maintain Visual Consistency**: Ensure exact visual preservation during migration

### Page Categories for Review
**Main Application Pages**
- Home/Index pages with movie showcases and hero sections
- Movie listing and detail pages with complex layouts
- Cinema browsing and hall selection interfaces
- Booking flow with seat selection and payment forms

**Admin Area Pages**
- Dashboard with statistics and data visualization
- CRUD interfaces for movies, cinemas, showtimes
- User management and booking administration
- Analytics and reporting interfaces

**Identity Area Pages**
- Login and registration forms
- Profile management interfaces
- Password reset and email verification
- Account settings and preferences

### Tailwind Migration Methodology
**Step 1: Audit Current Styles**
- Scan all Razor views for inline styles and CSS classes
- Identify custom CSS rules that can be replaced with Tailwind utilities
- Document complex components that require custom CSS

**Step 2: Create Tailwind Equivalents**
- Map existing spacing, colors, and typography to Tailwind utilities
- Ensure design token consistency through CSS variables
- Create utility combinations for common patterns

**Step 3: Systematic Replacement**
- Replace simple styles (margins, padding, colors) with Tailwind utilities
- Maintain complex components as custom CSS where necessary
- Validate visual consistency after each replacement

**Step 4: Optimization and Cleanup**
- Remove unused custom CSS rules after Tailwind migration
- Consolidate remaining custom CSS into global components
- Ensure optimal bundle size through proper purging

### CSS Cleanup and Unused Style Removal

### Unused Style Detection Strategy
**Automated Detection**
- Use PurgeCSS to identify potentially unused CSS rules
- Cross-reference CSS selectors with HTML templates
- Account for dynamically applied classes via JavaScript

**Manual Verification**
- Review admin interfaces for dynamically generated content
- Check JavaScript-applied classes and state changes
- Validate responsive and hover states are preserved

**Safe Removal Process**
1. **Backup Current Styles**: Create backup of all CSS files before removal
2. **Incremental Removal**: Remove unused styles in small batches
3. **Visual Validation**: Test all pages after each removal batch
4. **Rollback Capability**: Maintain ability to restore removed styles if needed

### CSS Rule Consolidation
**Duplicate Rule Elimination**
- Identify identical CSS rules across different files
- Consolidate duplicate rules into global components
- Remove redundant declarations and conflicting styles

**Specificity Optimization**
- Reduce CSS specificity where possible
- Use consistent naming conventions to avoid conflicts
- Leverage CSS cascade effectively for maintainable styles

This comprehensive approach ensures that the JavaScript organization follows the same principles as the CSS architecture, while the page review and cleanup process maintains visual consistency while optimizing the codebase for maintainability and performance.