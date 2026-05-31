# VoxTics JavaScript Architecture

This document outlines the JavaScript architecture and frontend functionality for the VoxTics cinema booking application.

## Overview

VoxTics uses a modern, modular JavaScript architecture that provides:
- **Modular Design** - Organized into logical modules with clear separation of concerns
- **Performance Optimization** - Efficient event handling and resource management
- **Error Handling** - Comprehensive error handling and graceful degradation
- **Cross-Browser Compatibility** - Modern JavaScript with fallbacks for older browsers
- **Maintainable Code** - Clean, documented code following best practices

## Architecture Status

✅ **Completed:**
- Modular JavaScript structure with ES6 classes
- Comprehensive error handling and fallback systems
- Performance monitoring and optimization
- Cross-browser notification system
- Event delegation for better performance
- API service layer for centralized HTTP requests
- Modern clipboard API with fallbacks

🔄 **Recent Updates:**
- ✅ Complete JavaScript architecture documentation update (COMPLETED - December 2024)
- ✅ Cinema functionality documentation added (COMPLETED)
- ✅ Movie.js functionality fully documented (COMPLETED)
- ✅ Syntax error corrections in main.js (COMPLETED - December 2024)
- ✅ Improved function structure and organization (COMPLETED)
- ✅ Enhanced error handling in notification systems (COMPLETED)
- ✅ Configuration object structure validation and cleanup (COMPLETED)
- ✅ API service integration in main.js (COMPLETED)
- ✅ Centralized utility usage across all modules (COMPLETED)

## File Structure

```
VoxTics/wwwroot/js/
├── main/
│   ├── main.js                    # Global public site functionality
│   ├── movies/
│   │   ├── movie.js               # Movies index page functionality
│   │   └── moviedetails.js        # Movie details page functionality
│   └── cinemas/
│       ├── cinemas.js             # Cinema listing page functionality
│       └── cinema-details.js      # Cinema details page functionality
├── utils/
│   └── voxtics-utils.js           # Centralized utility functions and classes
├── site.js                        # Global site utilities and initialization
└── notfound.js                    # 404 page functionality
```

## Core Modules

### 1. Centralized Utilities (`utils/voxtics-utils.js`)

**Purpose**: Foundation layer providing reusable utilities and classes for the entire application.

**Core Classes:**
- **PerformanceMonitor**: Execution timing and performance tracking
- **EventDelegator**: Efficient event handling for dynamic content
- **ApiService**: HTTP request handling with timeout and error management
- **NotificationService**: Multi-fallback notification system
- **LoadingManager**: Consistent loading state management
- **StarRating**: Interactive rating components
- **LocalStorageManager**: Safe localStorage operations with error handling

**Utility Functions:**
```javascript
// Modern clipboard with fallbacks
VoxTicsUtils.copyToClipboard(text)

// Performance optimization
VoxTicsUtils.debounce(func, wait)
VoxTicsUtils.throttle(func, limit)

// Formatting utilities
VoxTicsUtils.formatCurrency(amount, currency, locale)
VoxTicsUtils.formatDate(date, options, locale)
VoxTicsUtils.formatDuration(minutes)

// Social sharing
VoxTicsUtils.shareOnSocial(platform, url, title)
```

### 2. Global Site Functionality (`site.js`)

**Purpose**: Provides global utilities and initialization for all pages.

**Key Features:**
- Bootstrap component initialization (tooltips, modals)
- Scroll-to-top functionality
- Image lazy loading with Intersection Observer
- Global utility functions (loading states, currency/date formatting)

```javascript
// Global utilities available throughout the application
window.VoxTics = {
    showLoading: function(element) { /* ... */ },
    hideLoading: function(element) { /* ... */ },
    formatCurrency: function(amount) { /* ... */ },
    formatDate: function(date) { /* ... */ }
};
```

### 3. Main Public Site (`main/main.js`)

**Purpose**: Handles public-facing functionality across the main application.

**Key Features:**
- Search and filter functionality
- Watchlist management with API integration
- Interactive rating system
- Notification system integration

**API Integration:**
```javascript
// Watchlist toggle with proper error handling
fetch('/Movies/ToggleWatchlist', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
        'RequestVerificationToken': token
    },
    body: JSON.stringify({ movieId: movieId })
})
```

### 4. VoxTics Page-Specific Modules

#### Movies Index Page (`main/movies/movie.js`)

**Purpose**: Handles movie listing, filtering, search, and grid functionality on the movies index page.

**Key Features:**
- Advanced filtering system (category, genre, sort, year filters)
- Real-time search with debounced input handling
- Movie grid/list view toggle with localStorage persistence
- Watchlist integration with API calls
- Quick view modal functionality
- Pagination handling with loading states
- Hover effects and interactive movie cards

**Filter System:**
```javascript
function applyFilters() {
    const form = document.querySelector('#movie-filters-form');
    if (form) {
        form.submit();
    }
}

function applyQuickFilter(type, value) {
    const url = new URL(window.location);
    url.searchParams.set(type, value);
    url.searchParams.delete('page'); // Reset pagination
    window.location.href = url.toString();
}
```

**Search Functionality:**
```javascript
// Debounced search with centralized utilities
const debouncedSearch = window.VoxTicsUtils 
    ? VoxTicsUtils.debounce((value) => performSearch(value), 500)
    : function(value) {
        let searchTimeout;
        clearTimeout(searchTimeout);
        searchTimeout = setTimeout(() => performSearch(value), 500);
    };
```

#### Cinema Listing Page (`main/cinemas/cinemas.js`)

**Purpose**: Handles cinema listing, filtering, and location-based functionality.

**Key Features:**
- Cinema filtering by location, amenities, and distance
- Interactive map integration for cinema locations
- Favorite cinema management with localStorage
- Cinema search and sorting functionality
- Responsive grid/list view toggle

#### Cinema Details Page (`main/cinemas/cinema-details.js`)

**Purpose**: Comprehensive functionality for individual cinema pages including hall selection, showtime filtering, and facility information.

**Key Features:**
- **Hall Selection System**: Interactive hall selection with seating chart preview
- **Showtime Filtering**: Dynamic filtering by date, time, movie, and hall
- **Facility Information**: Interactive facility highlights and descriptions
- **Contact Features**: Direct calling, directions, and favorite management
- **Image Gallery**: Lightbox functionality with keyboard navigation
- **Booking Integration**: Direct links to booking system with selected showtimes

**Hall Management:**
```javascript
function selectHall(hallBtn) {
    const hallId = hallBtn.dataset.hallId;
    
    // Update active hall button
    document.querySelectorAll('.hall-btn').forEach(btn => {
        btn.classList.remove('active');
    });
    hallBtn.classList.add('active');

    // Load hall details and filter showtimes
    loadHallDetails(hallId);
    filterShowtimesByHall(hallId);
}
```

**Showtime Filtering:**
```javascript
function loadShowtimes(date, time, movieId, hallId) {
    const params = new URLSearchParams({
        cinemaId: cinemaId,
        date: date || '',
        time: time || '',
        movieId: movieId || '',
        hallId: hallId || ''
    });

    fetch(`/Cinemas/GetShowtimes?${params}`)
        .then(response => response.text())
        .then(html => {
            showtimesContainer.innerHTML = html;
            initializeShowtimeButtons();
        });
}
```

#### Movie Details Page (`main/movies/moviedetails.js`)

**Purpose**: Comprehensive functionality for movie detail pages including showtimes, booking, and reviews.

**Architecture**: Modular design with ES6 classes and performance optimization.

#### Module Manager System
```javascript
class ModuleManager {
    constructor(elements, config) {
        this.elements = elements;
        this.config = config;
        this.modules = new Map();
        this.performanceMonitor = new PerformanceMonitor();
    }
    
    registerModule(name, ModuleClass) {
        // Module registration with error handling and performance monitoring
    }
}
```

#### Core Modules

**Image Gallery Module**
- Keyboard navigation support (arrow keys)
- Thumbnail selection with smooth transitions
- Error handling for image loading
- Performance optimizations with `will-change` and `backface-visibility`

**Showtimes Module**
- Dynamic showtime loading via API
- Cinema and date filtering
- Loading states and error handling
- Automatic button re-initialization after AJAX updates

**Booking Flow Module**
- Showtime selection validation
- Redirect to booking page with proper parameters
- Quick booking functionality

**Reviews Module**
- Interactive star rating system with null-safe operations
- AJAX form submission with centralized loading states
- Load more reviews functionality
- Real-time rating updates
- Integrated with VoxTicsUtils for consistent UX

**Trailer Module**
- Modal-based video player
- Lazy loading of video content
- Automatic cleanup on modal close

**Social Sharing Module**
- Multi-platform sharing (Facebook, Twitter, LinkedIn, WhatsApp)
- Modern clipboard API with fallbacks
- Error handling for sharing failures

#### API Service Layer
```javascript
class ApiService {
    constructor(config) {
        this.config = config;
    }
    
    async fetchShowtimes(movieId, date) {
        // Centralized HTTP request handling with error management
    }
    
    async submitReview(formData) {
        // Form submission with proper error handling
    }
}
```

#### Performance Monitoring
```javascript
class PerformanceMonitor {
    start(name) { /* Performance timing start */ }
    end(name) { /* Performance timing end with logging */ }
    clear() { /* Cleanup performance marks */ }
}
```

## Key Features

### 1. Error Handling Strategy

**Graceful Degradation**: All functionality includes fallbacks for when dependencies are unavailable.

```javascript
// Multi-tier notification system with fallbacks
function showNotification(message, type = 'info') {
    try {
        // Try VoxTics main notification system first
        if (window.VoxTicsMain?.showNotification) {
            window.VoxTicsMain.showNotification(message, type);
            return;
        }
        
        // Try Toastr if available
        if (typeof toastr !== 'undefined' && toastr[type]) {
            toastr[type](message);
            return;
        }
        
        // Try SweetAlert2 if available
        if (typeof Swal !== 'undefined') {
            Swal.fire({ /* SweetAlert configuration */ });
            return;
        }
        
        // Fallback to console and alert for critical errors
        console.log(`${type.toUpperCase()}: ${message}`);
        if (type === 'error') {
            alert(`Error: ${message}`);
        }
    } catch (error) {
        console.error('Failed to show notification:', error);
        console.log(`NOTIFICATION (${type}): ${message}`);
    }
}
```

### 2. Modern Clipboard API

**Cross-Browser Clipboard Support**: Modern API with legacy fallbacks.

```javascript
async function copyToClipboard(text) {
    try {
        // Modern Clipboard API for secure contexts
        if (navigator.clipboard && window.isSecureContext) {
            await navigator.clipboard.writeText(text);
            showNotification('Link copied to clipboard', 'success');
            return;
        }
        
        // Fallback for older browsers or non-secure contexts
        await fallbackCopyToClipboard(text);
        showNotification('Link copied to clipboard', 'success');
    } catch (error) {
        console.error('Failed to copy to clipboard:', error);
        showNotification('Failed to copy link. Please copy manually.', 'error');
    }
}
```

### 3. Event Delegation

**Performance Optimization**: Efficient event handling for dynamic content.

```javascript
class EventDelegator {
    delegate(container, selector, event, handler) {
        const key = `${selector}-${event}`;
        
        if (!this.handlers.has(key)) {
            const delegatedHandler = (e) => {
                const target = e.target.closest(selector);
                if (target && container.contains(target)) {
                    handler.call(target, e);
                }
            };
            
            container.addEventListener(event, delegatedHandler);
            this.handlers.set(key, delegatedHandler);
        }
    }
}
```

### 4. Configuration Management

**Centralized Configuration**: All module settings in a single configuration object.

```javascript
const CONFIG = {
    selectors: {
        mainImage: '#main-movie-image',
        thumbnails: '.movie-thumbnail',
        dateButtons: '.date-btn',
        // ... more selectors
    },
    endpoints: {
        showtimes: '/Movies/GetShowtimes',
        reviews: '/Movies/GetReviews',
        submitReview: '/Movies/SubmitReview'
    },
    classes: {
        active: 'active',
        selected: 'selected',
        loading: 'loading',
        disabled: 'disabled'
    },
    timeouts: {
        debounce: 300,
        apiRequest: 10000
    },
    messages: {
        selectShowtime: 'Please select a showtime first',
        reviewSuccess: 'Review submitted successfully',
        // ... more messages
    }
};
```

## Integration with Backend

### ASP.NET Core MVC Integration

**CSRF Protection**: All AJAX requests include anti-forgery tokens.

```javascript
fetch('/Movies/ToggleWatchlist', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
        'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
    },
    body: JSON.stringify({ movieId: movieId })
})
```

**Server-Side Rendering**: JavaScript enhances server-rendered content without replacing it.

### API Endpoints

**Standardized Responses**: All API endpoints return consistent JSON responses.

```javascript
// Expected response format
{
    success: true|false,
    message: "User-friendly message",
    data: { /* Response data */ }
}
```

## Performance Optimizations

### 1. Lazy Loading
- Images loaded using Intersection Observer API
- Video content loaded only when modals are opened
- JavaScript modules loaded on demand

### 2. Event Optimization
- Event delegation to reduce memory usage
- Debounced input handlers to prevent excessive API calls
- Cleanup functions to prevent memory leaks

### 3. DOM Optimization
- Element caching to avoid repeated queries
- Batch DOM updates to minimize reflows
- CSS transforms for smooth animations

```javascript
// Performance optimizations in CSS
.movie-card,
.cinema-card,
.showtime-button {
    will-change: transform;
    backface-visibility: hidden;
}
```

## Browser Compatibility

### Modern JavaScript Features
- ES6 classes and modules
- Async/await for asynchronous operations
- Modern APIs with fallbacks (Clipboard, Intersection Observer)

### Fallback Strategies
- Legacy clipboard implementation for older browsers
- Console logging when notification libraries are unavailable
- Progressive enhancement for advanced features

## Cinema-Specific Features

### Hall Management System
The cinema details page includes a sophisticated hall management system:

```javascript
// Interactive seating chart with real-time updates
function initializeSeatingChart() {
    const seatingChart = document.querySelector('#seating-chart');
    if (!seatingChart) return;

    const seats = seatingChart.querySelectorAll('.seat');
    seats.forEach(seat => {
        seat.addEventListener('click', function() {
            if (!this.classList.contains('occupied')) {
                this.classList.toggle('selected');
                updateSelectedSeatsInfo();
            }
        });
    });
}
```

### Facility Highlighting System
Interactive facility information with visual highlighting:

```javascript
function highlightFacility(facilityType) {
    // Remove previous highlights
    document.querySelectorAll('.facility-item').forEach(item => {
        item.classList.remove('highlighted');
    });

    // Highlight matching facilities
    const matchingFacilities = document.querySelectorAll(`[data-facility-type="${facilityType}"]`);
    matchingFacilities.forEach(facility => {
        facility.classList.add('highlighted');
    });

    // Auto-scroll to first matching facility
    if (matchingFacilities.length > 0) {
        matchingFacilities[0].scrollIntoView({ behavior: 'smooth', block: 'center' });
    }
}
```

### Lightbox Gallery System
Full-featured image gallery with keyboard navigation:

```javascript
function openLightbox() {
    const images = Array.from(document.querySelectorAll('.gallery-image')).map(img => ({
        src: img.src,
        alt: img.alt
    }));
    
    // Create dynamic lightbox with navigation controls
    const lightboxModal = document.createElement('div');
    lightboxModal.className = 'lightbox-modal';
    
    // Keyboard navigation support
    document.addEventListener('keydown', function(e) {
        switch(e.key) {
            case 'ArrowRight': nextImage(); break;
            case 'ArrowLeft': prevImage(); break;
            case 'Escape': closeLightbox(); break;
        }
    });
}
```

## Recent Improvements

### Latest Improvements (December 2024)

#### Main.js Refactoring ✅ COMPLETED
Successfully refactored and improved `main.js` with proper structure and API integration:

1. **API Service Integration**: Added proper API service usage for watchlist and rating functionality
2. **Centralized Utilities**: Migrated to use VoxTicsUtils for all common operations
3. **Improved Error Handling**: Enhanced error handling with proper try-catch blocks
4. **Function Organization**: Better separation of concerns and cleaner function structure

#### Syntax Error Resolution ✅ COMPLETED
Successfully resolved all syntax errors in `moviedetails.js`:

1. **Configuration Object Validation**: Fixed malformed configuration structure
2. **Function Declaration Cleanup**: Corrected function declarations and scope issues  
3. **Code Structure Optimization**: Improved separation between utility functions and module exports
4. **Error Handling Enhancement**: Strengthened error handling throughout the module system

**Impact:**
- **Zero Syntax Errors**: All JavaScript files now pass validation without errors
- **Improved Reliability**: Eliminates runtime errors that could break movie details functionality
- **Enhanced Debugging**: Cleaner code structure makes troubleshooting easier
- **Better Performance**: Optimized function structure reduces execution overhead

#### Utility Integration Enhancement ✅ COMPLETED
Refactored review submission functionality to use centralized VoxTicsUtils:

1. **Loading State Management**: Replaced manual DOM manipulation with `VoxTicsUtils.showLoading()` and `VoxTicsUtils.hideLoading()`
2. **Notification System**: Migrated from direct function calls to `VoxTicsUtils.notify()` for consistent messaging
3. **Star Rating Integration**: Added proper null checking for star rating component interactions
4. **Error Handling Consistency**: Unified error handling patterns across all review operations

**Code Example:**
```javascript
// Before: Manual loading state management
submitBtn.disabled = true;
submitBtn.innerHTML = '<span class="spinner-border spinner-border-sm me-2"></span>Submitting...';

// After: Centralized utility usage
VoxTicsUtils.showLoading(submitBtn, 'Submitting...');

// Before: Direct notification calls
showNotification('Review submitted successfully', 'success');

// After: Centralized notification system
VoxTicsUtils.notify('Review submitted successfully', 'success');
```

**Benefits:**
- **Consistency**: All loading states and notifications now use the same centralized system
- **Maintainability**: Changes to loading/notification behavior only need to be made in one place
- **Reliability**: Proper null checking prevents runtime errors when components are missing
- **User Experience**: Consistent visual feedback across all interactive elements

#### Module System Enhancements
- **Performance Monitoring**: Built-in timing for module initialization
- **Error Isolation**: Individual module failures don't break the entire system
- **Graceful Degradation**: Fallback systems ensure functionality even when dependencies fail
- **Memory Management**: Proper cleanup prevents memory leaks in long-running sessions

#### Centralized Utility Integration
- **VoxTicsUtils Integration**: All modules now use centralized utilities for common operations
- **Loading State Management**: Consistent loading indicators across all interactive elements
- **Notification System**: Unified messaging system with multiple fallback options
- **Null-Safe Operations**: Proper checking for component availability before interaction

## Best Practices

### Utility Function Usage
Always use centralized utilities from `VoxTicsUtils` for common operations:

```javascript
// ✅ CORRECT: Use centralized utilities
VoxTicsUtils.showLoading(element, 'Loading...');
VoxTicsUtils.notify('Success message', 'success');
VoxTicsUtils.hideLoading(element);

// ❌ INCORRECT: Manual DOM manipulation
element.disabled = true;
element.innerHTML = '<span class="spinner">Loading...</span>';
```

### Null-Safe Component Interactions
Always check for component existence before interaction:

```javascript
// ✅ CORRECT: Null-safe operation
if (this.starRating) {
    this.starRating.setRating(0);
}

// ❌ INCORRECT: Assumes component exists
this.starRating.setRating(0); // May throw error if starRating is null
```

### Consistent Error Handling
Use try-catch blocks with centralized notification system:

```javascript
// ✅ CORRECT: Consistent error handling
try {
    const data = await this.apiService.submitReview(formData);
    if (data.success) {
        VoxTicsUtils.notify('Review submitted successfully', 'success');
    } else {
        VoxTicsUtils.notify(data.message || 'Error submitting review', 'error');
    }
} catch (error) {
    console.error('Error:', error);
    VoxTicsUtils.notify('Error submitting review', 'error');
} finally {
    VoxTicsUtils.hideLoading(submitBtn);
}
```

### Loading State Management
Always use utility functions for loading states with proper cleanup:

```javascript
// ✅ CORRECT: Centralized loading management
VoxTicsUtils.showLoading(button, 'Processing...');
try {
    await performOperation();
} finally {
    VoxTicsUtils.hideLoading(button); // Always cleanup in finally block
}
```

## Testing Strategy

### Error Handling Testing
- Test all fallback scenarios (missing dependencies, network failures)
- Validate graceful degradation in older browsers
- Ensure proper error logging and user feedback
- Verify null-safe operations when components are missing

### Performance Testing
- Monitor module initialization times
- Test event delegation efficiency
- Validate memory usage and cleanup
- Measure loading state transition performance

### Integration Testing
- Test API integration with backend services
- Validate CSRF token handling
- Ensure proper form submission and validation
- Verify VoxTicsUtils integration across all modules

## Future Enhancements

### Planned Improvements
1. **Module Bundling**: Implement webpack bundling for production optimization
2. **TypeScript Migration**: Add type safety and better IDE support
3. **Unit Testing**: Implement Jest-based unit testing for critical functions
4. **Service Worker**: Add offline functionality and caching strategies

### Architecture Evolution
1. **Component System**: Move toward a more component-based architecture
2. **State Management**: Implement centralized state management for complex interactions
3. **Progressive Web App**: Add PWA features for mobile experience enhancement

This JavaScript architecture provides a solid foundation for the VoxTics application with excellent error handling, performance optimization, and maintainability.