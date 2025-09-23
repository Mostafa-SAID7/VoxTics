/**
 * Modern Movie Page JavaScript
 * Enhanced functionality with modern ES6+ features
 */

class MoviePage {
    constructor() {
        this.searchInput = document.querySelector('.search-input');
        this.searchForm = document.querySelector('.search-form');
        this.loadingOverlay = document.getElementById('loadingOverlay');
        this.movieCards = document.querySelectorAll('.movie-card');
        this.sortButtons = document.querySelectorAll('.sort-btn');
        this.searchTimeout = null;

        this.init();
    }

    init() {
        this.setupEventListeners();
        this.setupKeyboardShortcuts();
        this.setupIntersectionObserver();
        this.setupPerformanceOptimizations();
        this.setupAccessibility();
        this.animatePageLoad();
    }

    setupEventListeners() {
        // Enhanced search functionality
        if (this.searchInput) {
            // Real-time search with debouncing
            this.searchInput.addEventListener('input', this.handleSearchInput.bind(this));

            // Search suggestions (if you want to add this feature later)
            this.searchInput.addEventListener('focus', this.handleSearchFocus.bind(this));
            this.searchInput.addEventListener('blur', this.handleSearchBlur.bind(this));
        }

        // Form submission with loading state
        if (this.searchForm) {
            this.searchForm.addEventListener('submit', this.handleFormSubmit.bind(this));
        }

        // Sort buttons with enhanced UX
        this.sortButtons.forEach(button => {
            button.addEventListener('click', this.handleSortClick.bind(this));
        });

        // Movie card interactions
        this.movieCards.forEach(card => {
            this.setupCardInteractions(card);
        });

        // Pagination with loading states
        this.setupPaginationLoading();

        // Window events
        window.addEventListener('scroll', this.throttle(this.handleScroll.bind(this), 16));
        window.addEventListener('resize', this.debounce(this.handleResize.bind(this), 250));
    }

    setupKeyboardShortcuts() {
        document.addEventListener('keydown', (e) => {
            // Ctrl/Cmd + F to focus search
            if ((e.ctrlKey || e.metaKey) && e.key === 'f') {
                e.preventDefault();
                if (this.searchInput) {
                    this.searchInput.focus();
                    this.searchInput.select();
                }
            }

            // Escape to clear search
            if (e.key === 'Escape' && this.searchInput === document.activeElement) {
                this.searchInput.value = '';
                this.searchInput.blur();
            }

            // Arrow keys for pagination navigation
            if (e.key === 'ArrowLeft' || e.key === 'ArrowRight') {
                this.handleKeyboardPagination(e);
            }
        });
    }

    setupIntersectionObserver() {
        // Animate cards on scroll
        const observerOptions = {
            threshold: 0.1,
            rootMargin: '0px 0px -50px 0px'
        };

        const observer = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.classList.add('animate-in');
                    observer.unobserve(entry.target);
                }
            });
        }, observerOptions);

        this.movieCards.forEach(card => {
            observer.observe(card);
        });
    }

    setupPerformanceOptimizations() {
        // Lazy load images
        if ('IntersectionObserver' in window) {
            this.lazyLoadImages();
        }

        // Preload critical resources
        this.preloadCriticalResources();

        // Setup service worker for caching (if implemented)
        if ('serviceWorker' in navigator) {
            this.registerServiceWorker();
        }
    }

    setupAccessibility() {
        // ARIA live regions for dynamic content
        this.createAriaLiveRegions();

        // Enhanced focus management
        this.setupFocusManagement();

        // Keyboard navigation for cards
        this.setupCardKeyboardNavigation();
    }

    // Event Handlers
    handleSearchInput(e) {
        const query = e.target.value.trim();

        // Clear previous timeout
        if (this.searchTimeout) {
            clearTimeout(this.searchTimeout);
        }

        // Debounce search
        this.searchTimeout = setTimeout(() => {
            this.performSearch(query);
        }, 300);

        // Visual feedback
        this.updateSearchUI(query);
    }

    handleSearchFocus(e) {
        e.target.parentElement.classList.add('focused');
    }

    handleSearchBlur(e) {
        e.target.parentElement.classList.remove('focused');
    }

    handleFormSubmit(e) {
        this.showLoading();
        // Form will submit naturally, loading will be hidden on page load
    }

    handleSortClick(e) {
        e.preventDefault();
        this.showLoading();

        // Add visual feedback
        this.updateSortUI(e.target);

        // Navigate to URL after brief delay for UX
        setTimeout(() => {
            window.location.href = e.target.href;
        }, 150);
    }

    handleScroll() {
        // Update scroll-based effects
        const scrollY = window.scrollY;
        const header = document.querySelector('.page-header');

        if (header) {
            const parallaxSpeed = 0.5;
            header.style.transform = `translateY(${scrollY * parallaxSpeed}px)`;
        }

        // Show/hide scroll-to-top button
        this.toggleScrollToTop(scrollY);
    }

    handleResize() {
        // Recalculate layouts if needed
        this.updateLayoutCalculations();
    }

    handleKeyboardPagination(e) {
        const currentPage = document.querySelector('.page-item.active .page-link');
        if (!currentPage) return;

        let targetLink = null;

        if (e.key === 'ArrowLeft') {
            // Previous page
            const prevItem = currentPage.closest('.page-item').previousElementSibling;
            if (prevItem && !prevItem.classList.contains('disabled')) {
                targetLink = prevItem.querySelector('.page-link');
            }
        } else if (e.key === 'ArrowRight') {
            // Next page
            const nextItem = currentPage.closest('.page-item').nextElementSibling;
            if (nextItem && !nextItem.classList.contains('disabled')) {
                targetLink = nextItem.querySelector('.page-link');
            }
        }

        if (targetLink) {
            e.preventDefault();
            this.showLoading();
            window.location.href = targetLink.href;
        }
    }

    // Card Interactions
    setupCardInteractions(card) {
        const movieId = card.dataset.movieId;

        // Enhanced hover effects
        card.addEventListener('mouseenter', () => {
            this.handleCardHover(card, true);
        });

        card.addEventListener('mouseleave', () => {
            this.handleCardHover(card, false);
        });

        // Click to focus for keyboard users
        card.addEventListener('click', (e) => {
            if (e.target === card) {
                card.focus();
            }
        });

        // Keyboard navigation within card
        card.addEventListener('keydown', (e) => {
            this.handleCardKeydown(e, card);
        });

        // Track interactions for analytics (if implemented)
        this.trackCardInteraction(card, movieId);
    }

    setupCardKeyboardNavigation() {
        this.movieCards.forEach((card, index) => {
            card.setAttribute('tabindex', '0');
            card.setAttribute('role', 'article');
            card.setAttribute('aria-label', `Movie: ${card.querySelector('.movie-title')?.textContent}`);
        });
    }

    handleCardHover(card, isEntering) {
        const image = card.querySelector('.movie-image');
        const overlay = card.querySelector('.movie-overlay');

        if (isEntering) {
            // Preload actions for better UX
            this.preloadCardActions(card);

            // Add hover class for additional styling
            card.classList.add('card-hovered');
        } else {
            card.classList.remove('card-hovered');
        }
    }

    handleCardKeydown(e, card) {
        switch (e.key) {
            case 'Enter':
            case ' ':
                e.preventDefault();
                const detailsLink = card.querySelector('.btn-details');
                if (detailsLink) detailsLink.click();
                break;
            case 'b':
            case 'B':
                e.preventDefault();
                const bookLink = card.querySelector('.btn-book');
                if (bookLink) bookLink.click();
                break;
        }
    }

    // Search Functionality
    performSearch(query) {
        if (query.length < 2 && query.length > 0) return;

        // Update URL without refreshing
        const url = new URL(window.location);
        if (query) {
            url.searchParams.set('search', query);
        } else {
            url.searchParams.delete('search');
        }

        // Only update URL if it's different
        if (url.toString() !== window.location.toString()) {
            window.history.replaceState({}, '', url);
        }
    }

    updateSearchUI(query) {
        const form = this.searchInput.closest('.search-form');

        if (query.length > 0) {
            form.classList.add('has-query');
        } else {
            form.classList.remove('has-query');
        }
    }

    // UI State Management
    showLoading() {
        if (this.loadingOverlay) {
            this.loadingOverlay.classList.add('active');
            document.body.style.overflow = 'hidden';
        }
    }

    hideLoading() {
        if (this.loadingOverlay) {
            this.loadingOverlay.classList.remove('active');
            document.body.style.overflow = '';
        }
    }

    updateSortUI(activeButton) {
        this.sortButtons.forEach(btn => {
            btn.classList.remove('active');
        });
        activeButton.classList.add('active');
    }

    // Performance Optimizations
    lazyLoadImages() {
        const imageObserver = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    const img = entry.target;
                    if (img.dataset.src) {
                        img.src = img.dataset.src;
                        img.classList.add('loaded');
                        imageObserver.unobserve(img);
                    }
                }
            });
        });

        document.querySelectorAll('img[data-src]').forEach(img => {
            imageObserver.observe(img);
        });
    }

    preloadCriticalResources() {
        // Preload fonts
        const fonts = [
            'https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&display=swap'
        ];

        fonts.forEach(font => {
            const link = document.createElement('link');
            link.rel = 'preload';
            link.as = 'style';
            link.href = font;
            document.head.appendChild(link);
        });

        // Preload next page if pagination exists
        const nextPageLink = document.querySelector('.pagination .page-item:last-child .page-link');
        if (nextPageLink && !nextPageLink.closest('.page-item').classList.contains('active')) {
            const link = document.createElement('link');
            link.rel = 'prefetch';
            link.href = nextPageLink.href;
            document.head.appendChild(link);
        }
    }

    preloadCardActions(card) {
        const bookingLink = card.querySelector('.btn-book');
        const detailsLink = card.querySelector('.btn-details');

        [bookingLink, detailsLink].forEach(link => {
            if (link && link.href) {
                const prefetchLink = document.createElement('link');
                prefetchLink.rel = 'prefetch';
                prefetchLink.href = link.href;
                document.head.appendChild(prefetchLink);
            }
        });
    }

    registerServiceWorker() {
        navigator.serviceWorker.register('/sw.js')
            .then(registration => {
                console.log('SW registered:', registration);
            })
            .catch(error => {
                console.log('SW registration failed:', error);
            });
    }

    // Accessibility Features
    createAriaLiveRegions() {
        // Create live region for search results
        const searchLiveRegion = document.createElement('div');
        searchLiveRegion.setAttribute('aria-live', 'polite');
        searchLiveRegion.setAttribute('aria-atomic', 'true');
        searchLiveRegion.className = 'sr-only';
        searchLiveRegion.id = 'search-live-region';
        document.body.appendChild(searchLiveRegion);

        // Create live region for loading states
        const loadingLiveRegion = document.createElement('div');
        loadingLiveRegion.setAttribute('aria-live', 'assertive');
        loadingLiveRegion.className = 'sr-only';
        loadingLiveRegion.id = 'loading-live-region';
        document.body.appendChild(loadingLiveRegion);
    }

    announceToScreenReader(message, region = 'search-live-region') {
        const liveRegion = document.getElementById(region);
        if (liveRegion) {
            liveRegion.textContent = message;
            setTimeout(() => {
                liveRegion.textContent = '';
            }, 1000);
        }
    }

    setupFocusManagement() {
        // Enhanced focus indicators
        document.addEventListener('keydown', (e) => {
            if (e.key === 'Tab') {
                document.body.classList.add('keyboard-navigation');
            }
        });

        document.addEventListener('mousedown', () => {
            document.body.classList.remove('keyboard-navigation');
        });

        // Focus trap for modal-like states
        this.setupFocusTrap();
    }

    setupFocusTrap() {
        // This would be used if you have modals or overlays
        document.addEventListener('keydown', (e) => {
            if (e.key === 'Tab' && this.loadingOverlay.classList.contains('active')) {
                e.preventDefault(); // Trap focus during loading
            }
        });
    }

    // Pagination Enhancement
    setupPaginationLoading() {
        const paginationLinks = document.querySelectorAll('.pagination .page-link');

        paginationLinks.forEach(link => {
            link.addEventListener('click', (e) => {
                if (!link.closest('.page-item').classList.contains('disabled')) {
                    this.showLoading();
                    this.announceToScreenReader('Loading new page...', 'loading-live-region');
                }
            });
        });
    }

    // Animation and Visual Effects
    animatePageLoad() {
        // Stagger animation of movie cards
        this.movieCards.forEach((card, index) => {
            card.style.animationDelay = `${index * 0.1}s`;
        });

        // Animate other elements
        this.animateElements();

        // Hide loading overlay after animations
        setTimeout(() => {
            this.hideLoading();
        }, 500);
    }

    animateElements() {
        const elementsToAnimate = [
            { selector: '.page-header h2', delay: 0 },
            { selector: '.page-header .lead', delay: 200 },
            { selector: '.search-container', delay: 400 },
            { selector: '.sort-controls', delay: 600 }
        ];

        elementsToAnimate.forEach(({ selector, delay }) => {
            const element = document.querySelector(selector);
            if (element) {
                setTimeout(() => {
                    element.classList.add('animate-in');
                }, delay);
            }
        });
    }

    toggleScrollToTop(scrollY) {
        let scrollButton = document.getElementById('scroll-to-top');

        if (!scrollButton) {
            scrollButton = this.createScrollToTopButton();
        }

        if (scrollY > 300) {
            scrollButton.classList.add('visible');
        } else {
            scrollButton.classList.remove('visible');
        }
    }

    createScrollToTopButton() {
        const button = document.createElement('button');
        button.id = 'scroll-to-top';
        button.innerHTML = '↑';
        button.setAttribute('aria-label', 'Scroll to top');
        button.className = 'scroll-to-top-btn';

        button.addEventListener('click', () => {
            window.scrollTo({
                top: 0,
                behavior: 'smooth'
            });
        });

        document.body.appendChild(button);
        return button;
    }

    // Utility Functions
    debounce(func, wait) {
        let timeout;
        return function executedFunction(...args) {
            const later = () => {
                clearTimeout(timeout);
                func(...args);
            };
            clearTimeout(timeout);
            timeout = setTimeout(later, wait);
        };
    }

    throttle(func, limit) {
        let inThrottle;
        return function (...args) {
            if (!inThrottle) {
                func.apply(this, args);
                inThrottle = true;
                setTimeout(() => inThrottle = false, limit);
            }
        };
    }

    updateLayoutCalculations() {
        // Recalculate any layout-dependent features
        const grid = document.querySelector('.movies-grid');
        if (grid) {
            const columns = getComputedStyle(grid).gridTemplateColumns.split(' ').length;
            grid.dataset.columns = columns;
        }
    }

    trackCardInteraction(card, movieId) {
        // Analytics tracking (implement with your preferred analytics service)
        const trackEvent = (eventType, element) => {
            element.addEventListener('click', () => {
                // Example: Google Analytics 4
                if (typeof gtag !== 'undefined') {
                    gtag('event', eventType, {
                        event_category: 'movie_interaction',
                        event_label: movieId,
                        value: 1
                    });
                }

                // Example: Custom analytics
                this.sendAnalyticsEvent({
                    type: eventType,
                    movieId: movieId,
                    timestamp: Date.now()
                });
            });
        };

        const bookButton = card.querySelector('.btn-book');
        const detailsButton = card.querySelector('.btn-details');

        if (bookButton) trackEvent('book_movie', bookButton);
        if (detailsButton) trackEvent('view_details', detailsButton);
    }

    sendAnalyticsEvent(eventData) {
        // Implement your analytics endpoint
        if ('navigator' in window && 'sendBeacon' in navigator) {
            navigator.sendBeacon('/api/analytics', JSON.stringify(eventData));
        }
    }

    // Error Handling
    handleImageError(img) {
        img.src = '/images/defaults/placeholder.png';
        img.classList.add('image-error');
    }

    handleNetworkError() {
        this.showNotification('Network error. Please check your connection.', 'error');
    }

    showNotification(message, type = 'info') {
        const notification = document.createElement('div');
        notification.className = `notification notification-${type}`;
        notification.textContent = message;

        document.body.appendChild(notification);

        setTimeout(() => {
            notification.classList.add('show');
        }, 100);

        setTimeout(() => {
            notification.classList.remove('show');
            setTimeout(() => {
                document.body.removeChild(notification);
            }, 300);
        }, 3000);
    }

    // Cleanup
    destroy() {
        // Remove event listeners
        if (this.searchTimeout) {
            clearTimeout(this.searchTimeout);
        }

        // Clean up observers
        // (In a real implementation, you'd store references to observers)

        // Remove created elements
        const elementsToRemove = [
            '#scroll-to-top',
            '#search-live-region',
            '#loading-live-region'
        ];

        elementsToRemove.forEach(selector => {
            const element = document.querySelector(selector);
            if (element) {
                element.remove();
            }
        });
    }
}

// Additional CSS for scroll-to-top button and notifications
const additionalStyles = `
.scroll-to-top-btn {
    position: fixed;
    bottom: 2rem;
    right: 2rem;
    width: 50px;
    height: 50px;
    border-radius: 50%;
    background: var(--gradient-primary);
    border: none;
    color: white;
    font-size: 1.5rem;
    cursor: pointer;
    box-shadow: 0 4px 20px rgba(103, 126, 234, 0.3);
    transition: all 0.3s ease;
    opacity: 0;
    visibility: hidden;
    transform: translateY(20px);
    z-index: 1000;
}

.scroll-to-top-btn.visible {
    opacity: 1;
    visibility: visible;
    transform: translateY(0);
}

.scroll-to-top-btn:hover {
    transform: translateY(-3px);
    box-shadow: 0 6px 25px rgba(103, 126, 234, 0.4);
}

.notification {
    position: fixed;
    top: 2rem;
    right: 2rem;
    padding: 1rem 1.5rem;
    background: var(--bg-card);
    backdrop-filter: blur(20px);
    border: 1px solid var(--border-color);
    border-radius: var(--border-radius-sm);
    color: var(--text-primary);
    box-shadow: 0 8px 32px rgba(0, 0, 0, 0.2);
    transform: translateX(100%);
    transition: transform 0.3s ease;
    z-index: 1001;
    max-width: 300px;
}

.notification.show {
    transform: translateX(0);
}

.notification-error {
    border-left: 4px solid #ef4444;
}

.notification-success {
    border-left: 4px solid #10b981;
}

.notification-warning {
    border-left: 4px solid #f59e0b;
}

.sr-only {
    position: absolute;
    width: 1px;
    height: 1px;
    padding: 0;
    margin: -1px;
    overflow: hidden;
    clip: rect(0, 0, 0, 0);
    white-space: nowrap;
    border: 0;
}

body.keyboard-navigation *:focus {
    outline: 2px solid var(--primary-color);
    outline-offset: 2px;
}

.animate-in {
    animation: fadeInUp 0.6s ease-out;
}

.card-hovered {
    z-index: 10;
}

.search-form.has-query .search-input {
    color: var(--text-primary);
}

.search-form.focused {
    transform: translateY(-2px);
    box-shadow: 0 12px 40px rgba(103, 126, 234, 0.2);
}

.image-error {
    filter: grayscale(1);
    opacity: 0.7;
}
`;

// Inject additional styles
const styleSheet = document.createElement('style');
styleSheet.textContent = additionalStyles;
document.head.appendChild(styleSheet);

// Initialize when DOM is loaded
document.addEventListener('DOMContentLoaded', () => {
    window.moviePage = new MoviePage();
});

// Handle page visibility changes
document.addEventListener('visibilitychange', () => {
    if (document.visibilityState === 'visible') {
        // Page became visible again - refresh data if needed
        // This could be useful for long-running sessions
    }
});

// Export for module systems
if (typeof module !== 'undefined' && module.exports) {
    module.exports = MoviePage;
}