// Enhanced Movie Cards JavaScript

class MovieCardsManager {
    constructor() {
        this.currentSearch = '';
        this.currentSort = '';
        this.isLoading = false;
        this.lazyImages = [];
        this.init();
    }

    init() {
        this.setupEventListeners();
        this.setupAnimations();
        this.setupKeyboardShortcuts();
        this.setupImageLazyLoading();
        this.setupTooltips();
        this.setupCardInteractions();
        this.setupFilterAnimations();
    }

    setupEventListeners() {
        // Search functionality
        const searchForm = document.querySelector('.search-form');
        const searchInput = document.querySelector('.search-input');
        const searchBtn = document.querySelector('.search-btn');

        if (searchForm && searchInput) {
            // Real-time search with debounce
            let searchTimeout;
            searchInput.addEventListener('input', (e) => {
                clearTimeout(searchTimeout);
                const query = e.target.value.trim();

                // Visual feedback
                this.showSearchIndicator();

                searchTimeout = setTimeout(() => {
                    if (query.length >= 2 || query.length === 0) {
                        this.performSearch(query);
                    }
                    this.hideSearchIndicator();
                }, 800);
            });

            // Enhanced search button
            searchBtn?.addEventListener('click', (e) => {
                e.preventDefault();
                const query = searchInput.value.trim();
                this.performSearch(query);
            });

            // Search input enhancements
            searchInput.addEventListener('focus', this.onSearchFocus.bind(this));
            searchInput.addEventListener('blur', this.onSearchBlur.bind(this));
        }

        // Sort button interactions
        this.setupSortControls();

        // Card button interactions
        this.setupCardButtons();

        // Pagination enhancements
        this.setupPagination();
    }

    setupCardInteractions() {
        const movieCards = document.querySelectorAll('.movie-card');

        movieCards.forEach((card, index) => {
            // Add staggered animation delay
            card.style.setProperty('--card-delay', `${index * 0.1}s`);

            // Enhanced hover effects
            card.addEventListener('mouseenter', (e) => {
                this.onCardHover(e, card);
            });

            card.addEventListener('mouseleave', (e) => {
                this.onCardLeave(e, card);
            });

            // Card click to expand (optional)
            card.addEventListener('click', (e) => {
                if (!e.target.closest('.btn-book, .btn-details, .overlay-btn')) {
                    this.highlightCard(card);
                }
            });

            // Image error handling
            const img = card.querySelector('.movie-image');
            if (img) {
                img.addEventListener('error', () => {
                    this.handleImageError(img);
                });
            }
        });
    }

    setupSortControls() {
        const sortButtons = document.querySelectorAll('.sort-btn');

        sortButtons.forEach(btn => {
            btn.addEventListener('click', (e) => {
                e.preventDefault();
                this.showSortingIndicator();

                // Add loading state
                btn.classList.add('loading');

                // Navigate after a short delay for visual feedback
                setTimeout(() => {
                    window.location.href = btn.href;
                }, 300);
            });
        });
    }

    setupCardButtons() {
        const bookButtons = document.querySelectorAll('.btn-book');
        const detailButtons = document.querySelectorAll('.btn-details');

        [...bookButtons, ...detailButtons].forEach(button => {
            // Ripple effect
            button.addEventListener('click', (e) => {
                this.createRipple(e, button);
            });

            // Loading state for book buttons
            if (button.classList.contains('btn-book')) {
                button.addEventListener('click', (e) => {
                    if (!this.isLoading) {
                        this.showButtonLoading(button);
                    }
                });
            }
        });
    }

    setupAnimations() {
        // Intersection Observer for scroll animations
        const observer = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.classList.add('animate-in');
                    this.triggerCardAnimation(entry.target);
                }
            });
        }, {
            threshold: 0.1,
            rootMargin: '0px 0px -50px 0px'
        });

        // Observe movie cards
        const movieCards = document.querySelectorAll('.movie-card');
        movieCards.forEach((card, index) => {
            observer.observe(card);
        });

        // Observe other elements
        const animatedElements = document.querySelectorAll('.search-container, .sort-controls, .pagination-container');
        animatedElements.forEach(element => observer.observe(element));
    }

    setupKeyboardShortcuts() {
        document.addEventListener('keydown', (e) => {
            // Ctrl/Cmd + F to focus search
            if ((e.ctrlKey || e.metaKey) && e.key === 'f') {
                e.preventDefault();
                const searchInput = document.querySelector('.search-input');
                if (searchInput) {
                    searchInput.focus();
                    searchInput.select();
                }
            }

            // Escape to clear search
            if (e.key === 'Escape') {
                const searchInput = document.querySelector('.search-input');
                if (searchInput && document.activeElement === searchInput) {
                    searchInput.value = '';
                    this.performSearch('');
                    searchInput.blur();
                }
            }

            // Arrow key navigation for cards
            if (['ArrowLeft', 'ArrowRight', 'ArrowUp', 'ArrowDown'].includes(e.key)) {
                this.handleCardNavigation(e);
            }
        });
    }

    setupImageLazyLoading() {
        const images = document.querySelectorAll('.movie-image[loading="lazy"]');

        const imageObserver = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    const img = entry.target;
                    this.loadImage(img);
                    imageObserver.unobserve(img);
                }
            });
        }, {
            rootMargin: '50px'
        });

        images.forEach(img => {
            imageObserver.observe(img);
            this.lazyImages.push(img);
        });
    }

    setupTooltips() {
        const tooltipElements = document.querySelectorAll('[data-tooltip]');

        tooltipElements.forEach(element => {
            let tooltip;

            element.addEventListener('mouseenter', (e) => {
                const text = element.getAttribute('data-tooltip');
                tooltip = this.createTooltip(text);
                document.body.appendChild(tooltip);
                this.positionTooltip(tooltip, element);
            });

            element.addEventListener('mouseleave', () => {
                if (tooltip) {
                    tooltip.classList.add('fade-out');
                    setTimeout(() => tooltip.remove(), 200);
                    tooltip = null;
                }
            });
        });
    }

    setupPagination() {
        const pageLinks = document.querySelectorAll('.page-link');

        pageLinks.forEach(link => {
            link.addEventListener('click', (e) => {
                if (!link.parentElement.classList.contains('active') &&
                    !link.parentElement.classList.contains('disabled')) {
                    this.showPageLoading();
                }
            });
        });
    }

    setupFilterAnimations() {
        // Add smooth transitions when cards are filtered/sorted
        const moviesGrid = document.querySelector('.movies-grid');
        if (moviesGrid) {
            moviesGrid.style.transition = 'all 0.3s ease';
        }
    }

    // Card interaction methods
    onCardHover(e, card) {
        // Add subtle glow effect
        card.style.setProperty('--glow-opacity', '1');

        // Slightly scale adjacent cards down
        const allCards = document.querySelectorAll('.movie-card');
        const currentIndex = Array.from(allCards).indexOf(card);

        allCards.forEach((otherCard, index) => {
            if (index !== currentIndex && Math.abs(index - currentIndex) <= 1) {
                otherCard.style.transform = 'scale(0.98)';
                otherCard.style.opacity = '0.8';
            }
        });
    }

    onCardLeave(e, card) {
        card.style.removeProperty('--glow-opacity');

        // Reset all cards
        const allCards = document.querySelectorAll('.movie-card');
        allCards.forEach(otherCard => {
            otherCard.style.transform = '';
            otherCard.style.opacity = '';
        });
    }

    highlightCard(card) {
        // Remove existing highlights
        document.querySelectorAll('.movie-card.highlighted')
            .forEach(c => c.classList.remove('highlighted'));

        // Add highlight to current card
        card.classList.add('highlighted');

        // Scroll card into view
        card.scrollIntoView({
            behavior: 'smooth',
            block: 'center'
        });

        // Remove highlight after animation
        setTimeout(() => {
            card.classList.remove('highlighted');
        }, 2000);
    }

    triggerCardAnimation(card) {
        // Add a subtle entrance animation
        card.style.animation = 'cardEntrance 0.6s ease forwards';
    }

    handleImageError(img) {
        img.style.opacity = '0.7';
        img.src = 'data:image/svg+xml,<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 400 240" fill="none"><rect width="400" height="240" fill="%23f1f5f9"/><path d="M180 80h40v80h-40z" fill="%23cbd5e0"/><circle cx="190" cy="100" r="8" fill="%23cbd5e0"/><path d="M160 140l20-20 20 20 20-30 20 30v40H160z" fill="%23cbd5e0"/></svg>';

        // Add error styling
        const container = img.closest('.movie-image-container');
        if (container) {
            container.classList.add('image-error');
        }
    }

    handleCardNavigation(e) {
        const cards = Array.from(document.querySelectorAll('.movie-card'));
        const focusedCard = document.querySelector('.movie-card.keyboard-focused') || cards[0];
        const currentIndex = cards.indexOf(focusedCard);
        let newIndex = currentIndex;

        // Calculate grid columns for up/down navigation
        const gridStyles = getComputedStyle(document.querySelector('.movies-grid'));
        const columns = gridStyles.gridTemplateColumns.split(' ').length;

        switch (e.key) {
            case 'ArrowLeft':
                newIndex = Math.max(0, currentIndex - 1);
                break;
            case 'ArrowRight':
                newIndex = Math.min(cards.length - 1, currentIndex + 1);
                break;
            case 'ArrowUp':
                newIndex = Math.max(0, currentIndex - columns);
                break;
            case 'ArrowDown':
                newIndex = Math.min(cards.length - 1, currentIndex + columns);
                break;
        }

        if (newIndex !== currentIndex) {
            e.preventDefault();
            cards.forEach(card => card.classList.remove('keyboard-focused'));
            cards[newIndex].classList.add('keyboard-focused');
            cards[newIndex].focus();
            cards[newIndex].scrollIntoView({ behavior: 'smooth', block: 'center' });
        }
    }

    // Search functionality
    performSearch(query) {
        this.currentSearch = query;
        this.showLoadingOverlay();

        // Update URL parameters
        const url = new URL(window.location);
        if (query) {
            url.searchParams.set('search', query);
        } else {
            url.searchParams.delete('search');
        }
        url.searchParams.delete('page'); // Reset to first page

        // Navigate to new URL
        window.location.href = url.toString();
    }

    // Visual feedback methods
    showSearchIndicator() {
        const searchInput = document.querySelector('.search-input');
        const searchContainer = document.querySelector('.search-container');

        if (searchInput && searchContainer) {
            searchInput.style.borderColor = 'var(--primary-color)';
            searchInput.style.boxShadow = '0 0 0 4px rgba(102, 126, 234, 0.1)';
            searchContainer.classList.add('search-active');
        }
    }

    hideSearchIndicator() {
        const searchInput = document.querySelector('.search-input');
        const searchContainer = document.querySelector('.search-container');

        if (searchInput && searchContainer) {
            searchInput.style.borderColor = '';
            searchInput.style.boxShadow = '';
            searchContainer.classList.remove('search-active');
        }
    }

    showSortingIndicator() {
        const sortControls = document.querySelector('.sort-controls');
        if (sortControls) {
            sortControls.classList.add('loading');
        }
    }

    showPageLoading() {
        this.showLoadingOverlay();
    }

    showLoadingOverlay() {
        const overlay = document.getElementById('loadingOverlay');
        if (overlay) {
            overlay.classList.add('active');
        }
    }

    hideLoadingOverlay() {
        const overlay = document.getElementById('loadingOverlay');
        if (overlay) {
            overlay.classList.remove('active');
        }
    }

    showButtonLoading(button) {
        this.isLoading = true;
        const originalText = button.textContent;
        const originalHTML = button.innerHTML;

        button.innerHTML = '<span>Booking...</span>';
        button.style.pointerEvents = 'none';
        button.classList.add('loading');

        // Reset after 2 seconds (adjust based on your needs)
        setTimeout(() => {
            button.innerHTML = originalHTML;
            button.style.pointerEvents = '';
            button.classList.remove('loading');
            this.isLoading = false;
        }, 2000);
    }

    onSearchFocus(e) {
        const container = e.target.closest('.search-container');
        container?.classList.add('search-focused');

        // Enhanced placeholder animation
        if (!e.target.value) {
            this.animatePlaceholder(e.target);
        }
    }

    onSearchBlur(e) {
        const container = e.target.closest('.search-container');
        container?.classList.remove('search-focused');
    }

    // Animation helpers
    createRipple(event, element) {
        const ripple = document.createElement('span');
        const rect = element.getBoundingClientRect();
        const size = Math.max(rect.width, rect.height);
        const x = event.clientX - rect.left - size / 2;
        const y = event.clientY - rect.top - size / 2;

        ripple.style.cssText = `
            position: absolute;
            width: ${size}px;
            height: ${size}px;
            left: ${x}px;
            top: ${y}px;
            background: rgba(255, 255, 255, 0.4);
            border-radius: 50%;
            transform: scale(0);
            animation: ripple 0.8s ease-out;
            pointer-events: none;
            z-index: 1;
        `;

        if (!element.style.position || element.style.position === 'static') {
            element.style.position = 'relative';
        }
        element.style.overflow = 'hidden';

        element.appendChild(ripple);

        setTimeout(() => ripple.remove(), 800);
    }

    animatePlaceholder(input) {
        const placeholders = [
            'Search movies by title...',
            'Find your favorite films...',
            'Discover new releases...',
            'Search by genre or actor...'
        ];

        let index = 0;
        const interval = setInterval(() => {
            if (document.activeElement === input && !input.value) {
                input.placeholder = placeholders[index % placeholders.length];
                index++;
            } else {
                clearInterval(interval);
                input.placeholder = 'Search movies by title, category...';
            }
        }, 2500);
    }

    loadImage(img) {
        const src = img.getAttribute('src');
        if (src && !img.complete) {
            const newImg = new Image();
            newImg.onload = () => {
                img.style.opacity = '0';
                setTimeout(() => {
                    img.src = src;
                    img.style.opacity = '1';
                    img.classList.add('loaded');

                    // Trigger load animation
                    const container = img.closest('.movie-image-container');
                    if (container) {
                        container.classList.add('image-loaded');
                    }
                }, 100);
            };
            newImg.onerror = () => this.handleImageError(img);
            newImg.src = src;
        }
    }

    createTooltip(text) {
        const tooltip = document.createElement('div');
        tooltip.className = 'custom-tooltip';
        tooltip.textContent = text;
        tooltip.style.cssText = `
            position: absolute;
            background: rgba(0, 0, 0, 0.9);
            color: white;
            padding: 0.75rem 1rem;
            border-radius: 8px;
            font-size: 0.875rem;
            white-space: nowrap;
            z-index: 10000;
            opacity: 0;
            transform: translateY(10px);
            transition: all 0.3s ease;
            pointer-events: none;
            backdrop-filter: blur(10px);
            border: 1px solid rgba(255, 255, 255, 0.1);
        `;

        setTimeout(() => {
            tooltip.style.opacity = '1';
            tooltip.style.transform = 'translateY(0)';
        }, 50);

        return tooltip;
    }

    positionTooltip(tooltip, element) {
        const elementRect = element.getBoundingClientRect();
        const tooltipRect = tooltip.getBoundingClientRect();
        const viewportWidth = window.innerWidth;
        const viewportHeight = window.innerHeight;

        let left = elementRect.left + (elementRect.width - tooltipRect.width) / 2;
        let top = elementRect.top - tooltipRect.height - 10;

        // Adjust if tooltip goes outside viewport
        if (left < 10) left = 10;
        if (left + tooltipRect.width > viewportWidth - 10) {
            left = viewportWidth - tooltipRect.width - 10;
        }
        if (top < 10) {
            top = elementRect.bottom + 10;
        }

        tooltip.style.left = `${left}px`;
        tooltip.style.top = `${top}px`;
    }
}

// Utility functions for enhanced card interactions
const MovieCardUtils = {
    // Format price with animation
    animatePrice(price, element) {
        if (element && typeof price === 'number') {
            element.style.transform = 'scale(1.1)';
            element.style.color = 'var(--success-hover)';
            setTimeout(() => {
                element.style.transform = '';
                element.style.color = '';
            }, 300);
        }
    },

    // Add card favorite functionality
    toggleFavorite(movieId, element) {
        const isFavorite = element.classList.contains('favorited');

        if (isFavorite) {
            element.classList.remove('favorited');
            element.innerHTML = '♡';
        } else {
            element.classList.add('favorited');
            element.innerHTML = '❤️';
        }

        // Here you would typically make an API call to save the favorite status
        console.log(`Movie ${movieId} ${isFavorite ? 'removed from' : 'added to'} favorites`);
    },

    // Smooth scroll to card
    scrollToCard(cardId) {
        const card = document.querySelector(`[data-movie-id="${cardId}"]`);
        if (card) {
            card.scrollIntoView({
                behavior: 'smooth',
                block: 'center'
            });
            card.classList.add('highlighted');
            setTimeout(() => card.classList.remove('highlighted'), 2000);
        }
    },

    // Filter cards by category
    filterByCategory(category) {
        const cards = document.querySelectorAll('.movie-card');

        cards.forEach(card => {
            const cardCategory = card.querySelector('.movie-category').textContent.toLowerCase();
            const shouldShow = !category || cardCategory.includes(category.toLowerCase());

            if (shouldShow) {
                card.style.display = '';
                card.classList.add('filter-match');
            } else {
                card.style.display = 'none';
                card.classList.remove('filter-match');
            }
        });
    }
};

// Initialize when DOM is ready
document.addEventListener('DOMContentLoaded', () => {
    window.movieCardsManager = new MovieCardsManager();

    // Add additional CSS animations
    const style = document.createElement('style');
    style.textContent = `
        @keyframes ripple {
            to {
                transform: scale(2);
                opacity: 0;
            }
        }
        
        @keyframes cardEntrance {
            from {
                opacity: 0;
                transform: translateY(30px) scale(0.9);
            }
            to {
                opacity: 1;
                transform: translateY(0) scale(1);
            }
        }
        
        .search-focused {
            transform: translateY(-4px);
            box-shadow: 0 15px 35px rgba(0,0,0,0.1) !important;
        }
        
        .search-active {
            background: linear-gradient(145deg, #ffffff 0%, #f0f9ff 100%) !important;
        }
        
        .movie-card.highlighted {
            animation: cardHighlight 2s ease;
            z-index: 10;
        }
        
        @keyframes cardHighlight {
            0%, 100% { transform: translateY(0) scale(1); }
            50% { transform: translateY(-10px) scale(1.05); box-shadow: 0 25px 50px rgba(102, 126, 234, 0.3); }
        }
        
        .movie-card.keyboard-focused {
            outline: 3px solid var(--primary-color);
            outline-offset: 4px;
        }
        
        .image-error {
            background: linear-gradient(45deg, #f8fafc, #e2e8f0);
        }
        
        .image-loaded {
            animation: imageReveal 0.6s ease;
        }
        
        @keyframes imageReveal {
            from { opacity: 0; transform: scale(1.1); }
            to { opacity: 1; transform: scale(1); }
        }
        
        .custom-tooltip.fade-out {
            opacity: 0 !important;
            transform: translateY(-10px) !important;
        }
        
        .sort-controls.loading {
            opacity: 0.7;
            pointer-events: none;
        }
        
        .sort-btn.loading::after {
            content: '';
            display: inline-block;
            width: 12px;
            height: 12px;
            border: 2px solid currentColor;
            border-radius: 50%;
            border-top: 2px solid transparent;
            animation: spin 1s linear infinite;
            margin-left: 0.5rem;
        }
    `;
    document.head.appendChild(style);
});

// Export for potential external use
if (typeof module !== 'undefined' && module.exports) {
    module.exports = { MovieCardsManager, MovieCardUtils };
}