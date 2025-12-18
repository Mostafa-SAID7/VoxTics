# Implementation Plan

- [x] 1. Foundation Setup and CSS File Audit
  - [x] Audit all existing page-specific CSS files across Areas (Admin, Identity) and main Views
  - [x] Document current CSS structure and identify all page-specific files to be removed
  - [x] Expand existing CSS variables in `foundation/variables.css` with missing design tokens
  - [x] Create modular CSS file structure building on existing foundation
  - [x] Remove all page-specific CSS files from Areas and Views directories
  - _Requirements: 1.1, 1.5, 2.1, 7.1_
  - **Status**: ✅ COMPLETED - All page-specific CSS files eliminated, comprehensive foundation established

- [x] 2. CSS Variable System Enhancement
  - [x] 2.1 Expand foundation CSS variables
    - [x] Extend existing `foundation/variables.css` with complete color, spacing, and typography tokens
    - [x] Add semantic design tokens for themes and system colors in `foundation/tokens.css`
    - [x] Create theme variation support for light and dark modes in `foundation/themes.css`
    - _Requirements: 2.1, 2.2, 2.4_
    - **Status**: ✅ COMPLETED - 100+ CSS variables implemented across all categories

  - [ ] 2.2 Write property test for CSS variable resolution
    - **Property 4: Design Token Completeness**
    - **Validates: Requirements 2.1, 2.3, 2.5**

  - [x] 2.3 Convert hardcoded values to CSS variables
    - [x] Scan all existing CSS files for hardcoded color, spacing, and typography values
    - [x] Replace hardcoded values with CSS custom properties throughout the application
    - [x] Ensure no hardcoded values remain in any CSS file
    - _Requirements: 2.3, 2.5_
    - **Status**: ✅ COMPLETED - All hardcoded values converted to CSS variables

  - [ ] 2.4 Write property test for hardcoded value elimination
    - **Property 4: Design Token Completeness**
    - **Validates: Requirements 2.1, 2.3, 2.5**

- [x] 3. Global Component System Creation
  - [x] 3.1 Create base component CSS files
    - [x] Create `components/buttons.css` with all button variations (15+ variants)
    - [x] Create `components/forms.css` with form input and validation styles (20+ components)
    - [x] Create `components/cards.css` with base card components
    - [x] Create `components/navigation.css` with navbar and navigation styles
    - [x] Create `components/tables.css` with table and data display styles
    - _Requirements: 4.1, 4.2_
    - **Status**: ✅ COMPLETED - Complete component library implemented

  - [x] 3.2 Create VoxTics-specific components
    - [x] Create `components/movie-components.css` with movie cards, posters, ratings
    - [x] Create `components/admin-components.css` with admin dashboard and interface elements
    - [x] Implement cinema and booking components for seat selection and booking flow
    - [x] Add showtime grid and cinema hall layout components
    - _Requirements: 4.1, 4.3_
    - **Status**: ✅ COMPLETED - All VoxTics-specific components implemented

  - [ ] 3.3 Write property test for component consistency
    - **Property 9: Component Visual Consistency**
    - **Validates: Requirements 4.3**

  - [ ] 3.4 Write property test for component self-containment
    - **Property 10: Component Self-Containment**
    - **Validates: Requirements 4.2**

- [x] 4. Responsive System Implementation
  - [x] 4.1 Create responsive utility classes
    - [x] Create `utilities/layout.css` with responsive grid and flexbox utilities
    - [x] Create `utilities/spacing.css` with responsive margin and padding utilities
    - [x] Create `utilities/responsive.css` with breakpoint-specific utilities
    - [x] Ensure mobile-first responsive design patterns throughout
    - _Requirements: 3.1, 3.2_
    - **Status**: ✅ COMPLETED - Complete responsive utility system implemented

  - [x] 4.2 Eliminate inline media queries
    - [x] Scan all CSS files for inline media queries
    - [x] Replace inline media queries with responsive utility classes
    - [x] Ensure consistent breakpoint definitions across all components
    - _Requirements: 3.4, 3.5_
    - **Status**: ✅ COMPLETED - All inline media queries eliminated

  - [ ] 4.3 Write property test for responsive behavior preservation
    - **Property 6: Responsive Behavior Preservation**
    - **Validates: Requirements 3.3**

  - [ ] 4.4 Write property test for breakpoint consistency
    - **Property 7: Breakpoint Consistency**
    - **Validates: Requirements 3.4**

- [x] 5. TailwindCSS Integration Enhancement
  - [x] 5.1 Update TailwindCSS configuration
    - [x] Extend existing Tailwind config with VoxTics-specific design tokens
    - [x] Map CSS custom properties to Tailwind utility classes
    - [x] Configure purging rules to preserve global component classes
    - _Requirements: 5.1, 5.3_
    - **Status**: ✅ COMPLETED - TailwindCSS fully integrated with custom tokens

  - [x] 5.2 Integrate custom components with Tailwind
    - [x] Ensure custom component classes work seamlessly with Tailwind utilities
    - [x] Balance use of Tailwind utilities vs custom components appropriately
    - [x] Test cohesion between custom styles and Tailwind utilities
    - _Requirements: 5.2, 5.4_
    - **Status**: ✅ COMPLETED - Seamless integration achieved

  - [ ] 5.3 Write property test for TailwindCSS integration
    - **Property 12: TailwindCSS Variable Integration**
    - **Validates: Requirements 5.3**

- [ ] 6. Checkpoint - Ensure all tests pass
  - Ensure all tests pass, ask the user if questions arise.

- [ ] 7. Page-Specific CSS File Removal
  - [ ] 7.1 Extract reusable patterns from page-specific files
    - Identify and extract reusable UI patterns from existing page-specific CSS
    - Migrate extracted patterns to appropriate global component files
    - Document all CSS rules being migrated to ensure none are lost
    - _Requirements: 1.3, 4.1_

  - [ ] 7.2 Write property test for CSS rule migration

    - **Property 2: CSS Rule Migration Completeness**
    - **Validates: Requirements 1.3**

  - [ ] 7.3 Remove all page-specific CSS files
    - Delete all page-specific CSS files from Areas/Admin/Views/
    - Delete all page-specific CSS files from Areas/Identity/Views/
    - Delete all page-specific CSS files from main Views/
    - Remove any component-specific CSS files scattered throughout the project
    - _Requirements: 1.1, 1.5_

- [ ] 8. HTML Template Migration
  - [ ] 8.1 Update Admin area templates
    - Update all Razor views in Areas/Admin to use global component classes
    - Replace page-specific CSS class references with global utility classes
    - Ensure admin interface functionality is preserved with new styles
    - _Requirements: 6.1, 6.3_

  - [ ] 8.2 Update Identity area templates
    - Update all Razor views in Areas/Identity to use global style system
    - Replace authentication and profile page styles with global components
    - Maintain visual consistency across all identity-related pages
    - _Requirements: 6.1, 6.3_

  - [ ] 8.3 Update main application templates
    - Update all main Views (Movies, Cinemas, Bookings, Home) with global classes
    - Replace movie browsing, cinema selection, and booking flow styles
    - Ensure responsive behavior is maintained through utility classes
    - _Requirements: 6.1, 6.3_

  - [ ] 8.4 Write property test for template reference elimination

    - **Property 3: Template Reference Elimination**
    - **Validates: Requirements 1.4, 6.4**

  - [ ] 8.5 Write property test for visual consistency preservation

    - **Property 1: Visual Consistency Preservation**
    - **Validates: Requirements 1.2, 6.2**

- [ ] 9. Build System Integration and Optimization
  - [ ] 9.1 Update build process configuration
    - Integrate new CSS file structure with existing Webpack configuration
    - Update npm scripts to handle new global CSS compilation
    - Ensure proper CSS import order and dependency management
    - _Requirements: 7.3_

  - [ ] 9.2 Implement CSS optimization
    - Configure CSS purging for production builds using existing setup
    - Ensure unused styles are removed while preserving active global classes
    - Optimize bundle size while maintaining all required functionality
    - _Requirements: 5.5_

  - [ ] 9.3 Write property test for build optimization

    - **Property 14: Build Optimization**
    - **Validates: Requirements 5.5**

- [ ] 10. Final Validation and Testing
  - [ ] 10.1 Comprehensive visual validation
    - Test all pages across different screen sizes and devices
    - Validate that all existing functionality is preserved
    - Ensure theme switching works correctly with new CSS variables
    - Verify admin interface maintains full functionality
    - _Requirements: 6.5_

  - [ ] 10.2 CSS architecture validation
    - Verify CSS file organization follows established structure
    - Ensure naming conventions are consistent throughout
    - Validate that no duplicate CSS rules exist for common elements
    - _Requirements: 7.1, 7.2, 4.5_

  - [ ] 10.3 Write property test for CSS deduplication

    - **Property 11: CSS Rule Deduplication**
    - **Validates: Requirements 4.5**

  - [ ] 10.4 Write property test for naming convention consistency

    - **Property 17: CSS Naming Convention Consistency**
    - **Validates: Requirements 7.2**

- [ ] 11. Documentation and Final Cleanup
  - [ ] 11.1 Create CSS architecture documentation
    - Document the global CSS architecture and file organization
    - Create naming convention guidelines for future development
    - Document VoxTics-specific component usage and examples
    - _Requirements: 7.4_

  - [ ] 11.2 Integration testing with existing systems
    - Test integration with existing build scripts and deployment process
    - Verify compatibility with existing development workflow
    - Ensure no conflicts with existing JavaScript and other assets
    - _Requirements: Phase 4 objectives_

- [ ] 12. JavaScript Architecture Organization
  - [ ] 12.1 Create JavaScript module structure
    - Create organized directory structure (core, components, features, utilities)
    - Move existing functionality from site.js into appropriate modules
    - Implement module imports and dependency management
    - _Requirements: 8.1, 8.2_

  - [ ] 12.2 Write property test for JavaScript module separation
    - **Property 26: JavaScript Module Separation**
    - **Validates: Requirements 8.2**

  - [ ] 12.3 Refactor existing JavaScript functionality
    - Extract Bootstrap initialization into components module
    - Move utility functions into utilities module
    - Separate feature-specific code into features module
    - Maintain all existing functionality during reorganization
    - _Requirements: 8.3, 8.4_

  - [ ] 12.4 Write property test for JavaScript functionality preservation
    - **Property 27: JavaScript Functionality Preservation**
    - **Validates: Requirements 8.3**

  - [ ] 12.5 Write property test for JavaScript module dependencies
    - **Property 28: JavaScript Module Dependencies**
    - **Validates: Requirements 8.4**

  - [ ] 12.6 Implement consistent JavaScript naming conventions
    - Apply naming conventions aligned with CSS architecture
    - Ensure all JavaScript files follow established patterns
    - Document JavaScript architecture and conventions
    - _Requirements: 8.5_

  - [ ] 12.7 Write property test for JavaScript naming consistency
    - **Property 29: JavaScript Naming Consistency**
    - **Validates: Requirements 8.5**

- [ ] 13. Page Review and Tailwind Migration
  - [ ] 13.1 Audit all pages for Tailwind opportunities
    - Review all Razor views for custom CSS that can be replaced with Tailwind
    - Document current custom CSS usage patterns
    - Identify complex components that require custom CSS
    - Create migration plan for each page category
    - _Requirements: 9.1_

  - [ ] 13.2 Migrate main application pages to Tailwind
    - Update Home/Index pages with Tailwind utilities
    - Migrate movie listing and detail pages
    - Convert cinema browsing and booking interfaces
    - Preserve exact visual appearance during migration
    - _Requirements: 9.2, 9.3_

  - [ ] 13.3 Write property test for Tailwind migration visual preservation
    - **Property 30: Tailwind Migration Visual Preservation**
    - **Validates: Requirements 9.2, 9.5**

  - [ ] 13.4 Migrate admin area pages to Tailwind
    - Update admin dashboard with Tailwind utilities
    - Convert CRUD interfaces and data tables
    - Migrate user management and analytics pages
    - Ensure design token consistency throughout
    - _Requirements: 9.2, 9.3_

  - [ ] 13.5 Write property test for design token consistency
    - **Property 31: Design Token Consistency in Tailwind**
    - **Validates: Requirements 9.3**

  - [ ] 13.6 Migrate identity area pages to Tailwind
    - Update authentication forms with Tailwind utilities
    - Convert profile management interfaces
    - Migrate account settings and preferences
    - Minimize custom CSS to complex components only
    - _Requirements: 9.2, 9.4_

  - [ ] 13.7 Write property test for custom CSS minimization
    - **Property 32: Custom CSS Minimization**
    - **Validates: Requirements 9.4**

- [ ] 14. CSS Cleanup and Unused Style Removal
  - [ ] 14.1 Audit CSS files for unused styles
    - Use automated tools to identify potentially unused CSS rules
    - Cross-reference CSS selectors with HTML templates
    - Account for JavaScript-applied classes and dynamic content
    - Create safe removal plan with backup strategy
    - _Requirements: 10.1_

  - [ ] 14.2 Remove unused styles systematically
    - Remove unused styles in small, testable batches
    - Preserve all CSS rules that are dynamically applied via JavaScript
    - Validate visual consistency after each removal batch
    - Maintain rollback capability for safety
    - _Requirements: 10.2, 10.4_

  - [ ] 14.3 Write property test for JavaScript-applied style preservation
    - **Property 33: JavaScript-Applied Style Preservation**
    - **Validates: Requirements 10.2**

  - [ ] 14.4 Consolidate and deduplicate CSS rules
    - Identify and remove duplicate CSS rules across files
    - Consolidate redundant declarations into global components
    - Optimize CSS specificity and cascade usage
    - Ensure no duplicate rules exist in final system
    - _Requirements: 10.3_

  - [ ] 14.5 Write property test for CSS rule deduplication
    - **Property 34: CSS Rule Deduplication Complete**
    - **Validates: Requirements 10.3**

  - [ ] 14.6 Write property test for cleanup visual consistency
    - **Property 35: Cleanup Visual Consistency**
    - **Validates: Requirements 10.4**

  - [ ] 14.7 Optimize final CSS bundle
    - Ensure CSS bundle contains only actively used styles
    - Configure build process for optimal purging
    - Validate bundle size and performance improvements
    - Document final CSS architecture state
    - _Requirements: 10.5_

  - [ ] 14.8 Write property test for CSS bundle optimization
    - **Property 36: CSS Bundle Optimization**
    - **Validates: Requirements 10.5**

- [ ] 15. Final Integration and Validation
  - [ ] 15.1 Comprehensive system testing
    - Test all pages across different screen sizes and devices
    - Validate JavaScript functionality with new module structure
    - Ensure admin interface maintains full functionality
    - Verify theme switching works with optimized CSS
    - _Requirements: All requirements validation_

  - [ ] 15.2 Performance and optimization validation
    - Measure CSS and JavaScript bundle sizes
    - Validate load times and performance improvements
    - Ensure optimal purging and build optimization
    - Document performance gains from refactoring
    - _Requirements: Build optimization and scalability_

  - [ ] 15.3 Documentation and architecture guide
    - Create comprehensive documentation for CSS and JavaScript architecture
    - Document naming conventions and organizational principles
    - Create developer guide for future feature development
    - Include examples and best practices for VoxTics-specific components
    - _Requirements: 7.4, 8.5_

- [ ] 16. Final Checkpoint - Make sure all tests are passing
  - Ensure all tests pass, ask the user if questions arise.