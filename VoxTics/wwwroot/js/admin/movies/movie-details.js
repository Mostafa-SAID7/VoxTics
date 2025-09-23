// movies-index.js - Enhanced JavaScript for Movies Index page

class MoviesIndexManager {
    constructor() {
        this.storageKey = 'adminMoviesView';
        this.currentView = 'cards'; // default
        this.searchTimeout = null;
        this.isLoading = false;

        this.init();
    }

    init() {
        this.initElements();
        this.loadSavedView();
        this.bindEvents();
        this.enhanceAccessibility();
        this.initAnimations();

        console.log('Movies Index Manager initialized');
    }

    initElements() {
        // View elements
        this.cardViewBtn = document.getElementById('cardViewBtn');
        this.tableViewBtn = document.getElementById('tableViewBtn');
        this.cardView = document.getElementById('cardView');
        this.tableView = document.getElementById('tableView');

        // Search elements
        this.searchInput = document.querySelector('.search-input');
        this.searchForm = document.querySelector('.search-form');
        this.clearSearchBtn = document.querySelector('.clear-search');

        // Alert elements
        this.alerts = document.querySelectorAll('.alert');

        // Loading overlay
        this.loadingOverlay = document.querySelector('.loading-overlay');

        // Pagination
        this.paginationLinks = document.querySelectorAll('.page-link');
    }

    loadSavedView() {
        try {
            const saved = localStorage.getItem(this.storageKey);
            if (saved === 'table' || saved === 'cards') {
                this.currentView = saved;
            }
        } catch (error) {
            console.warn('Could not access localStorage:', error);
        }

        this.setView(this.currentView);
    }

    bindEvents() {
        // View toggle buttons
        if (this.cardViewBtn) {
            this.cardViewBtn.addEventListener('click', () => this.setView('cards'));
        }

        if (this.tableViewBtn) {
            this.tableViewBtn.addEventListener('click', () => this.setView('table'));
        }

        // Search functionality
        if (this.searchInput) {
            this.searchInput.addEventListener('input', (e) => this.handleSearchInput(e));
            this.searchInput.addEventListener('keydown', (e) => this.handleSearchKeydown(e));
        }

        if (this.clearSearchBtn) {
            this.clearSearchBtn.addEventListener('click', () => this.clearSearch());
        }

        // Alert dismiss functionality
        this.alerts.forEach(alert => {
            const closeBtn = alert.querySelector('.alert-close');
            if (closeBtn) {
                closeBtn.addEventListener('click', () => this.dismissAlert(alert));
            }
        });

        // Enhanced pagination
        this.enhancePagination();

        // Keyboard shortcuts
        document.addEventListener('keydown', (e) => this.handleKeyboardShortcuts(e));

        // Clear search button in empty state
        const btnClearSearch = document.querySelector('.btn-clear-search');
        if (btnClearSearch) {
            btnClearSearch.addEventListener('click', () => this.clearSearch());
        }

        // Window resize handler for responsive adjustments
        window.addEventListener('resize', this.debounce(() => this.handleResize(), 250));
    }

    setView(view) {
        this.currentView = view;

        if (view === 'table') {
            this.showTableView();
        } else {
            this.showCardView();
        }

        this.updateViewButtons();
        this.saveViewPreference();

        // Announce view change to screen readers
        this.announceViewChange(view);
    }

    showTableView() {
        if (this.cardView) this.cardView.style.display = 'none';
        if (this.tableView) {
            this.tableView.style.display = '';
            // Add fade-in animation
            this.tableView.style.opacity = '0';
            requestAnimationFrame(() => {
                this.tableView.style.transition = 'opacity 0.3s ease-in';
                this.tableView.style.opacity = '1';
            });
        }
    }

    showCardView() {
        if (this.tableView) this.tableView.style.display = 'none';
        if (this.cardView) {
            this.cardView.style.display = '';
            // Add fade-in animation
            this.cardView.style.opacity = '0';
            requestAnimationFrame(() => {
                this.cardView.style.transition = 'opacity 0.3s ease-in';
                this.cardView.style.opacity = '1';
            });
        }
    }

    updateViewButtons() {
        if (this.cardViewBtn && this.tableViewBtn) {
            if (this.currentView === 'table') {
                this.cardViewBtn.classList.remove('active');
                this.tableViewBtn.classList.add('active');
                this.cardViewBtn.setAttribute('aria-pressed', 'false');
                this.tableViewBtn.setAttribute('aria-pressed', 'true');
            } else {
                this.cardViewBtn.classList.add('active');
                this.tableViewBtn.classList.remove('active');
                this.cardViewBtn.setAttribute('aria-pressed', 'true');
                this.tableViewBtn.setAttribute('aria-pressed', 'false');
            }
        }
    }

    saveViewPreference() {
        try {
            localStorage.setItem(this.storageKey, this.currentView);
        } catch (error) {
            console.warn('Could not save view preference:', error);
        }
    }

    handleSearchInput(e) {
        const value = e.target.value;

        // Show/hide clear button
        if (this.clearSearchBtn) {
            this.clearSearchBtn.style.display = value ? 'block' : 'none';
        }

        // Auto-submit search after delay (optional feature)
        if (this.searchTimeout) {
            clearTimeout(this.searchTimeout);
        }

        // Uncomment the following lines if you want auto-search functionality
        /*
        this.searchTimeout = setTimeout(() => {
            if (value.length >= 3 || value.length === 0) {
                this.submitSearch();
            }
        }, 1000);
        */
    }

    handleSearchKeydown(e) {
        if (e.key === 'Escape') {
            this.clearSearch();
        }
    }

    clearSearch() {
        if (this.searchInput) {
            this.searchInput.value = '';
            if (this.clearSearchBtn) {
                this.clearSearchBtn.style.display = 'none';
            }
            this.submitSearch();
        }
    }

    submitSearch() {
        if (this.searchForm) {
            this.showLoading();
            this.searchForm.submit();
        }
    }

    dismissAlert(alert) {
        alert.style.transition = 'all 0.3s ease-out';
        alert.style.opacity = '0';
        alert.style.transform = 'translateY(-10px)';

        setTimeout(() => {
            alert.remove();
        }, 300);
    }

    enhancePagination() {
        this.paginationLinks.forEach(link => {
            if (!link.closest('.page-item.disabled') && !link.closest('.page-item.active')) {
                link.addEventListener('click', (e) => {
                    this.showLoading();
                    // Let the normal link behavior continue
                });
            }
        });
    }

    enhanceAccessibility() {
        // Add ARIA labels and descriptions
        if (this.searchInput) {
            this.searchInput.setAttribute('aria-describedby', 'search-help');

            // Create search help text
            const searchHelp = document.createElement('div');
            searchHelp.id = 'search-help';
            searchHelp.className = 'sr-only';
            searchHelp.textContent = 'Search movies by title, genre, or description. Press Escape to clear.';
            this.searchInput.parentNode.appendChild(searchHelp);
        }

        // Enhance table accessibility
        const table = document.querySelector('.movies-table');
        if (table) {
            table.setAttribute('role', 'table');
            table.setAttribute('aria-label', 'Movies list');

            const headers = table.querySelectorAll('th');
            headers.forEach((header, index) => {
                header.setAttribute('scope', 'col');
                header.id = `col-header-${index}`;
            });
        }
    }

    handleKeyboardShortcuts(e) {
        // Ctrl/Cmd + K to focus search
        if ((e.ctrlKey || e.metaKey) && e.key === 'k') {
            e.preventDefault();
            if (this.searchInput) {
                this.searchInput.focus();
                this.searchInput.select();
            }
        }

        // V key to toggle view (when not in input)
        if (e.key === 'v' && !e.target.matches('input, textarea, select')) {
            e.preventDefault();
            this.setView(this.currentView === 'cards' ? 'table' : 'cards');
        }

        // Escape to clear search when focused on search input
        if (e.key === 'Escape' && e.target === this.searchInput) {
            this.clearSearch();
        }
    }

    showLoading() {
        if (this.loadingOverlay) {
            this.isLoading = true;
            this.loadingOverlay.classList.add('show');
        }
    }

    hideLoading() {
        if (this.loadingOverlay) {
            this.isLoading = false;
            this.loadingOverlay.classList.remove('show');
        }
    }

    initAnimations() {
        // Stagger card animations
        const cards = document.querySelectorAll('.movie-card-wrapper');
        cards.forEach((card, index) => {
            card.style.animationDelay = `${index * 0.1}s`;
        });

        // Intersection Observer for scroll animations
        if ('IntersectionObserver' in window) {
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

            // Observe cards for animation
            cards.forEach(card => {
                card.classList.add('animate-ready');
                observer.observe(card);
            });
        }
    }

    handleResize() {
        // Handle responsive adjustments
        if (window.innerWidth < 768) {
            // Mobile adjustments
            this.adjustForMobile();
        } else {
            // Desktop adjustments
            this.adjustForDesktop();
        }
    }

    adjustForMobile() {
        // Mobile-specific adjustments
        const controlPanel = document.querySelector('.control-panel');
        if (controlPanel) {
            controlPanel.classList.add('mobile-layout');
        }
    }

    adjustForDesktop() {
        // Desktop-specific adjustments
        const controlPanel = document.querySelector('.control-panel');
        if (controlPanel) {
            controlPanel.classList.remove('mobile-layout');
        }
    }

    announceViewChange(view) {
        // Create announcement for screen readers
        const announcement = document.createElement('div');
        announcement.setAttribute('aria-live', 'polite');
        announcement.setAttribute('aria-atomic', 'true');
        announcement.className = 'sr-only';
        announcement.textContent = `Switched to ${view} view`;

        document.body.appendChild(announcement);

        setTimeout(() => {
            document.body.removeChild(announcement);
        }, 1000);
    }

    // Utility function for debouncing
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

    // Public method to refresh the view
    refresh() {
        this.hideLoading();
        this.initAnimations();
    }

    // Public method to show loading state
    setLoading(loading) {
        if (loading) {
            this.showLoading();
        } else {
            this.hideLoading();
        }
    }
}

// Enhanced features class for additional functionality
class MoviesIndexEnhanced {
    constructor(manager) {
        this.manager = manager;
        this.init();
    }

    init() {
        this.initTooltips();
        this.initConfirmDialogs();
        this.initBulkActions();
        this.initFilters();
    }

    initTooltips() {
        // Add tooltips to action buttons
        const actionButtons = document.querySelectorAll('[data-toggle="tooltip"]');
        actionButtons.forEach(button => {
            this.createTooltip(button);
        });
    }

    createTooltip(element) {
        const tooltipText = element.getAttribute('title') || element.getAttribute('data-tooltip');
        if (!tooltipText) return;

        const tooltip = document.createElement('div');
        tooltip.className = 'custom-tooltip';
        tooltip.textContent = tooltipText;
        tooltip.style.cssText = `
            position: absolute;
            background: #1e293b;
            color: white;
            padding: 0.5rem 0.75rem;
            border-radius: 0.375rem;
            font-size: 0.875rem;
            white-space: nowrap;
            pointer-events: none;
            z-index: 1000;
            opacity: 0;
            transition: opacity 0.2s ease;
            transform: translateY(-8px);
        `;

        document.body.appendChild(tooltip);

        element.addEventListener('mouseenter', () => {
            const rect = element.getBoundingClientRect();
            tooltip.style.left = rect.left + (rect.width / 2) - (tooltip.offsetWidth / 2) + 'px';
            tooltip.style.top = rect.top - tooltip.offsetHeight - 8 + 'px';
            tooltip.style.opacity = '1';
        });

        element.addEventListener('mouseleave', () => {
            tooltip.style.opacity = '0';
        });

        // Clean up on element removal
        const observer = new MutationObserver((mutations) => {
            mutations.forEach((mutation) => {
                mutation.removedNodes.forEach((node) => {
                    if (node === element) {
                        tooltip.remove();
                        observer.disconnect();
                    }
                });
            });
        });

        observer.observe(document.body, { childList: true, subtree: true });
    }

    initConfirmDialogs() {
        // Enhanced confirmation dialogs for delete actions
        const deleteButtons = document.querySelectorAll('[data-action="delete"]');
        deleteButtons.forEach(button => {
            button.addEventListener('click', (e) => {
                e.preventDefault();
                this.showConfirmDialog(
                    'Delete Movie',
                    'Are you sure you want to delete this movie? This action cannot be undone.',
                    () => {
                        // Proceed with delete
                        window.location.href = button.href;
                    }
                );
            });
        });
    }

    showConfirmDialog(title, message, onConfirm) {
        const modal = document.createElement('div');
        modal.className = 'confirm-modal';
        modal.innerHTML = `
            <div class="confirm-overlay"></div>
            <div class="confirm-dialog">
                <div class="confirm-header">
                    <h3>${title}</h3>
                    <button class="confirm-close">&times;</button>
                </div>
                <div class="confirm-body">
                    <p>${message}</p>
                </div>
                <div class="confirm-footer">
                    <button class="btn btn-secondary confirm-cancel">Cancel</button>
                    <button class="btn btn-danger confirm-ok">Delete</button>
                </div>
            </div>
        `;

        // Add styles
        modal.style.cssText = `
            position: fixed;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            z-index: 2000;
            display: flex;
            align-items: center;
            justify-content: center;
        `;

        document.body.appendChild(modal);
        document.body.style.overflow = 'hidden';

        // Event listeners
        modal.querySelector('.confirm-close').onclick = () => this.closeConfirmDialog(modal);
        modal.querySelector('.confirm-cancel').onclick = () => this.closeConfirmDialog(modal);
        modal.querySelector('.confirm-ok').onclick = () => {
            onConfirm();
            this.closeConfirmDialog(modal);
        };
        modal.querySelector('.confirm-overlay').onclick = () => this.closeConfirmDialog(modal);

        // Escape key
        const escHandler = (e) => {
            if (e.key === 'Escape') {
                this.closeConfirmDialog(modal);
                document.removeEventListener('keydown', escHandler);
            }
        };
        document.addEventListener('keydown', escHandler);
    }

    closeConfirmDialog(modal) {
        document.body.style.overflow = '';
        modal.remove();
    }

    initBulkActions() {
        // Add bulk action functionality (if needed)
        const selectAllCheckbox = document.querySelector('#selectAll');
        const itemCheckboxes = document.querySelectorAll('.item-checkbox');

        if (selectAllCheckbox && itemCheckboxes.length) {
            selectAllCheckbox.addEventListener('change', (e) => {
                itemCheckboxes.forEach(checkbox => {
                    checkbox.checked = e.target.checked;
                });
                this.updateBulkActionButtons();
            });

            itemCheckboxes.forEach(checkbox => {
                checkbox.addEventListener('change', () => {
                    this.updateBulkActionButtons();
                });
            });
        }
    }

    updateBulkActionButtons() {
        const selectedItems = document.querySelectorAll('.item-checkbox:checked');
        const bulkActionBar = document.querySelector('.bulk-action-bar');

        if (bulkActionBar) {
            if (selectedItems.length > 0) {
                bulkActionBar.style.display = 'flex';
                bulkActionBar.querySelector('.selected-count').textContent = selectedItems.length;
            } else {
                bulkActionBar.style.display = 'none';
            }
        }
    }

    initFilters() {
        // Advanced filtering functionality
        const filterButtons = document.querySelectorAll('.filter-btn');
        filterButtons.forEach(button => {
            button.addEventListener('click', (e) => {
                e.preventDefault();
                const filterType = button.dataset.filter;
                const filterValue = button.dataset.value;
                this.applyFilter(filterType, filterValue);
            });
        });
    }

    applyFilter(type, value) {
        // Apply filter logic here
        this.manager.showLoading();

        // Update URL with filter parameters
        const url = new URL(window.location);
        url.searchParams.set(`filter_${type}`, value);
        window.location.href = url.toString();
    }
}

// Initialize when DOM is ready
document.addEventListener('DOMContentLoaded', () => {
    // Check if we're on the movies index page
    if (document.querySelector('.movies-container')) {
        const moviesManager = new MoviesIndexManager();
        const moviesEnhanced = new MoviesIndexEnhanced(moviesManager);

        // Make manager available globally for debugging
        window.moviesManager = moviesManager;

        // Auto-hide loading after page load
        window.addEventListener('load', () => {
            setTimeout(() => {
                moviesManager.hideLoading();
            }, 500);
        });

        // Show helpful keyboard shortcut info in console
        console.log('🎬 Movies Index loaded! Keyboard shortcuts:');
        console.log('  • Ctrl/Cmd + K: Focus search');
        console.log('  • V: Toggle between card/table view');
        console.log('  • Esc: Clear search (when search is focused)');
    }
});

// Add CSS for additional components
const additionalStyles = `
    .sr-only {
        position: absolute !important;
        width: 1px !important;
        height: 1px !important;
        padding: 0 !important;
        margin: -1px !important;
        overflow: hidden !important;
        clip: rect(0, 0, 0, 0) !important;
        white-space: nowrap !important;
        border: 0 !important;
    }
    
    .animate-ready {
        opacity: 0;
        transform: translateY(20px);
    }
    
    .animate-in {
        opacity: 1;
        transform: translateY(0);
        transition: all 0.4s ease-out;
    }
    
    .confirm-modal .confirm-overlay {
        position: absolute;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        background: rgba(0, 0, 0, 0.5);
        backdrop-filter: blur(4px);
    }
    
    .confirm-modal .confirm-dialog {
        background: white;
        border-radius: 0.75rem;
        box-shadow: 0 20px 25px -5px rgb(0 0 0 / 0.1), 0 10px 10px -5px rgb(0 0 0 / 0.04);
        max-width: 400px;
        width: 90%;
        z-index: 1;
    }
    
    .confirm-modal .confirm-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 1.5rem 1.5rem 0;
    }
    
    .confirm-modal .confirm-header h3 {
        margin: 0;
        font-size: 1.25rem;
        font-weight: 600;
        color: #1e293b;
    }
    
    .confirm-modal .confirm-close {
        background: none;
        border: none;
        font-size: 1.5rem;
        color: #64748b;
        cursor: pointer;
        padding: 0.25rem;
        border-radius: 0.25rem;
        line-height: 1;
    }
    
    .confirm-modal .confirm-body {
        padding: 1rem 1.5rem;
    }
    
    .confirm-modal .confirm-body p {
        margin: 0;
        color: #64748b;
        line-height: 1.5;
    }
    
    .confirm-modal .confirm-footer {
        display: flex;
        gap: 0.75rem;
        padding: 0 1.5rem 1.5rem;
        justify-content: flex-end;
    }
    
    .mobile-layout {
        flex-direction: column !important;
    }
    
    .mobile-layout .search-section {
        width: 100% !important;
    }
    
    .mobile-layout .action-section {
        width: 100% !important;
        justify-content: center !important;
    }
`;

// Inject additional styles
if (!document.querySelector('#movies-index-additional-styles')) {
    const styleSheet = document.createElement('style');
    styleSheet.id = 'movies-index-additional-styles';
    styleSheet.textContent = additionalStyles;
    document.head.appendChild(styleSheet);
}