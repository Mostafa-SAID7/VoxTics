// Movies Index Enhanced Functionality
class MoviesIndex {
    constructor() {
        this.currentView = localStorage.getItem('moviesView') || 'cards';
        this.init();
    }

    init() {
        this.initializeViewToggle();
        this.initializeSearch();
        this.initializeAlerts();
        this.initializeSorting();
        this.initializeMovieCards();
        this.initializeFilters();
        this.initializeResponsive();
    }

    // View Toggle Functionality
    initializeViewToggle() {
        const cardViewBtn = document.getElementById('cardViewBtn');
        const tableViewBtn = document.getElementById('tableViewBtn');
        const cardView = document.getElementById('cardView');
        const tableView = document.getElementById('tableView');

        if (!cardViewBtn || !tableViewBtn) return;

        // Set initial view
        this.setActiveView(this.currentView);

        cardViewBtn.addEventListener('click', () => {
            this.setActiveView('cards');
            localStorage.setItem('moviesView', 'cards');
        });

        tableViewBtn.addEventListener('click', () => {
            this.setActiveView('table');
            localStorage.setItem('moviesView', 'table');
        });
    }

    setActiveView(view) {
        const cardViewBtn = document.getElementById('cardViewBtn');
        const tableViewBtn = document.getElementById('tableViewBtn');
        const cardView = document.getElementById('cardView');
        const tableView = document.getElementById('tableView');

        if (view === 'cards') {
            cardViewBtn.classList.add('active');
            tableViewBtn.classList.remove('active');
            cardView.style.display = 'block';
            tableView.style.display = 'none';
        } else {
            cardViewBtn.classList.remove('active');
            tableViewBtn.classList.add('active');
            cardView.style.display = 'none';
            tableView.style.display = 'block';
        }

        // Trigger resize event for any charts or responsive elements
        window.dispatchEvent(new Event('resize'));
    }

    // Search Functionality
    initializeSearch() {
        const searchInput = document.querySelector('.search-input');
        const clearSearchBtn = document.querySelector('.clear-search');
        const clearSearchLink = document.querySelector('.btn-clear-search');

        if (searchInput) {
            // Real-time search with debounce
            searchInput.addEventListener('input', this.debounce(() => {
                this.performSearch();
            }, 300));

            // Enter key submission
            searchInput.addEventListener('keypress', (e) => {
                if (e.key === 'Enter') {
                    e.preventDefault();
                    this.performSearch();
                }
            });
        }

        if (clearSearchBtn) {
            clearSearchBtn.addEventListener('click', () => {
                this.clearSearch();
            });
        }

        if (clearSearchLink) {
            clearSearchLink.addEventListener('click', (e) => {
                e.preventDefault();
                this.clearSearch();
            });
        }
    }

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

    performSearch() {
        const searchInput = document.querySelector('.search-input');
        const clearSearchBtn = document.querySelector('.clear-search');

        // Show/hide clear button
        if (clearSearchBtn) {
            clearSearchBtn.style.display = searchInput.value ? 'block' : 'none';
        }

        // Auto-submit form if search term changes significantly
        if (searchInput.value.length === 0 || searchInput.value.length > 2) {
            searchInput.form.submit();
        }
    }

    clearSearch() {
        const searchInput = document.querySelector('.search-input');
        const searchForm = document.querySelector('.search-form');

        searchInput.value = '';
        searchForm.submit();
    }

    // Alert Management
    initializeAlerts() {
        // Auto-dismiss alerts after 5 seconds
        const alerts = document.querySelectorAll('.alert');
        alerts.forEach(alert => {
            setTimeout(() => {
                this.dismissAlert(alert);
            }, 5000);
        });

        // Manual dismiss
        const dismissButtons = document.querySelectorAll('.alert-close');
        dismissButtons.forEach(button => {
            button.addEventListener('click', (e) => {
                e.preventDefault();
                this.dismissAlert(button.closest('.alert'));
            });
        });
    }

    dismissAlert(alert) {
        alert.style.opacity = '0';
        alert.style.transform = 'translateY(-10px)';
        setTimeout(() => {
            alert.remove();
        }, 300);
    }

    // Sorting Enhancement
    initializeSorting() {
        const sortableHeaders = document.querySelectorAll('.sortable');

        sortableHeaders.forEach(header => {
            header.addEventListener('click', (e) => {
                e.preventDefault();
                const link = header.querySelector('.sort-link');
                if (link) {
                    window.location.href = link.href;
                }
            });
        });
    }

    // Movie Cards Interactions
    initializeMovieCards() {
        // Add hover effects and click handlers
        const movieCards = document.querySelectorAll('.movie-card');

        movieCards.forEach(card => {
            card.addEventListener('click', (e) => {
                // Don't trigger if clicking on action buttons
                if (e.target.closest('.movie-actions')) {
                    return;
                }

                const detailsLink = card.querySelector('a[href*="Details"]');
                if (detailsLink) {
                    window.location.href = detailsLink.href;
                }
            });

            // Keyboard navigation
            card.addEventListener('keypress', (e) => {
                if (e.key === 'Enter' || e.key === ' ') {
                    e.preventDefault();
                    card.click();
                }
            });
        });

        // Make cards focusable
        movieCards.forEach((card, index) => {
            card.setAttribute('tabindex', '0');
            card.setAttribute('role', 'button');
            card.setAttribute('aria-label', `View details for ${card.querySelector('.movie-title')?.textContent}`);
        });
    }

    // Filtering Functionality
    initializeFilters() {
        // Status filter (could be extended)
        const statusBadges = document.querySelectorAll('.status-badge');

        statusBadges.forEach(badge => {
            badge.addEventListener('click', (e) => {
                e.stopPropagation();
                this.filterByStatus(badge.classList[1].replace('status-', ''));
            });
        });
    }

    filterByStatus(status) {
        // This would typically redirect to a filtered view
        const currentUrl = new URL(window.location.href);
        currentUrl.searchParams.set('status', status);
        window.location.href = currentUrl.toString();
    }

    // Responsive Behavior
    initializeResponsive() {
        this.handleResize();
        window.addEventListener('resize', this.debounce(() => {
            this.handleResize();
        }, 250));
    }

    handleResize() {
        const viewToggle = document.querySelector('.view-toggle');
        const actionSection = document.querySelector('.action-section');

        if (window.innerWidth < 768) {
            // Mobile adjustments
            document.querySelectorAll('.btn-text').forEach(text => {
                text.style.display = 'none';
            });

            if (actionSection) {
                actionSection.style.flexDirection = 'column';
            }
        } else {
            // Desktop adjustments
            document.querySelectorAll('.btn-text').forEach(text => {
                text.style.display = 'inline';
            });

            if (actionSection) {
                actionSection.style.flexDirection = 'row';
            }
        }
    }

    // Utility Methods
    showLoading() {
        const loadingOverlay = document.querySelector('.loading-overlay');
        if (loadingOverlay) {
            loadingOverlay.classList.add('show');
        }
    }

    hideLoading() {
        const loadingOverlay = document.querySelector('.loading-overlay');
        if (loadingOverlay) {
            loadingOverlay.classList.remove('show');
        }
    }

    // Export functionality (could be extended)
    exportMovies(format = 'csv') {
        this.showLoading();

        // Simulate export process
        setTimeout(() => {
            this.hideLoading();
            this.showNotification(`Movies exported as ${format.toUpperCase()} successfully!`, 'success');
        }, 2000);
    }

    showNotification(message, type = 'info') {
        // Create and show a toast notification
        const notification = document.createElement('div');
        notification.className = `alert alert-${type} fade-in`;
        notification.innerHTML = `
            <i class="fas fa-${type === 'success' ? 'check' : 'info'}-circle"></i>
            ${message}
            <button type="button" class="alert-close">
                <i class="fas fa-times"></i>
            </button>
        `;

        document.querySelector('.alerts-container').appendChild(notification);

        // Auto-remove after 3 seconds
        setTimeout(() => {
            this.dismissAlert(notification);
        }, 3000);
    }
}

// Initialize when DOM is loaded
document.addEventListener('DOMContentLoaded', function () {
    new MoviesIndex();
});

// Export for potential module usage
if (typeof module !== 'undefined' && module.exports) {
    module.exports = MoviesIndex;
}