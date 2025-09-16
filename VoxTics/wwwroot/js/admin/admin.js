class AdminLayout {
    constructor() {
        this.sidebar = document.getElementById('adminSidebar');
        this.main = document.getElementById('adminMain');
        this.sidebarToggle = document.getElementById('sidebarToggle');
        this.mobileToggle = document.getElementById('mobileToggle');
        this.loader = document.getElementById('page-loader');
        this.searchInput = document.getElementById('globalSearchInput');

        this.init();
    }

    init() {
        this.setupEventListeners();
        this.setupResponsive();
        this.setupLoader();
        this.setupSearch();
        this.setupNotifications();
        this.setupThemeToggle();
        this.setupFullscreen();
        this.loadUserPreferences();
        this.initializeTooltips();
    }

    setupEventListeners() {
        // Desktop sidebar toggle
        this.sidebarToggle?.addEventListener('click', () => this.toggleSidebar());

        // Mobile sidebar toggle
        this.mobileToggle?.addEventListener('click', () => this.toggleMobileSidebar());

        // Close mobile sidebar on outside click
        document.addEventListener('click', (e) => this.handleOutsideClick(e));

        // Keyboard shortcuts
        document.addEventListener('keydown', (e) => this.handleKeyboardShortcuts(e));

        // Navigation link loading states
        document.querySelectorAll('.nav-link[data-page]').forEach(link => {
            link.addEventListener('click', (e) => this.handleNavClick(e));
        });

        // Window resize handler
        window.addEventListener('resize', () => this.handleResize());

        // Page visibility change
        document.addEventListener('visibilitychange', () => this.handleVisibilityChange());
    }

    toggleSidebar() {
        const isCollapsed = this.sidebar.classList.toggle('collapsed');
        this.main.classList.toggle('expanded', isCollapsed);

        const icon = this.sidebarToggle.querySelector('i');
        icon.classList.toggle('bi-chevron-left', !isCollapsed);
        icon.classList.toggle('bi-chevron-right', isCollapsed);

        // Save preference
        localStorage.setItem('sidebarCollapsed', isCollapsed);

        // Trigger custom event
        document.dispatchEvent(new CustomEvent('sidebarToggle', { detail: { collapsed: isCollapsed } }));
    }

    toggleMobileSidebar() {
        const isOpen = this.sidebar.classList.toggle('mobile-open');
        const icon = this.mobileToggle.querySelector('i');

        icon.classList.toggle('bi-list', !isOpen);
        icon.classList.toggle('bi-x-lg', isOpen);

        // Prevent body scroll when sidebar is open
        document.body.style.overflow = isOpen ? 'hidden' : '';
    }

    handleOutsideClick(e) {
        if (window.innerWidth <= 768) {
            if (!this.sidebar.contains(e.target) && !this.mobileToggle.contains(e.target)) {
                this.sidebar.classList.remove('mobile-open');
                this.mobileToggle.querySelector('i').classList.replace('bi-x-lg', 'bi-list');
                document.body.style.overflow = '';
            }
        }
    }

    handleKeyboardShortcuts(e) {
        // Ctrl/Cmd + K for search
        if ((e.ctrlKey || e.metaKey) && e.key === 'k') {
            e.preventDefault();
            const searchModal = new bootstrap.Modal(document.getElementById('searchModal'));
            searchModal.show();
            setTimeout(() => this.searchInput?.focus(), 300);
        }

        // Ctrl/Cmd + B for sidebar toggle
        if ((e.ctrlKey || e.metaKey) && e.key === 'b') {
            e.preventDefault();
            if (window.innerWidth > 768) {
                this.toggleSidebar();
            } else {
                this.toggleMobileSidebar();
            }
        }

        // Escape key to close mobile sidebar
        if (e.key === 'Escape' && this.sidebar.classList.contains('mobile-open')) {
            this.toggleMobileSidebar();
        }
    }

    handleNavClick(e) {
        const link = e.currentTarget;
        const icon = link.querySelector('.nav-icon');

        if (icon && !link.getAttribute('href')?.startsWith('#')) {
            const originalClass = icon.className;
            icon.className = icon.className.replace(/bi-[\w-]+/, 'bi-arrow-clockwise');
            icon.style.animation = 'spin 1s linear infinite';

            // Reset after navigation or timeout
            setTimeout(() => {
                icon.className = originalClass;
                icon.style.animation = '';
            }, 2000);
        }
    }

    handleResize() {
        const width = window.innerWidth;

        if (width <= 768) {
            // Mobile
            this.sidebar.classList.remove('collapsed');
            this.main.classList.remove('expanded');
            if (!this.sidebar.classList.contains('mobile-open')) {
                this.sidebar.classList.add('mobile-hidden');
            }
        } else if (width <= 992) {
            // Tablet
            this.sidebar.classList.remove('mobile-open', 'mobile-hidden');
            this.sidebar.classList.add('collapsed');
            this.main.classList.add('expanded');
            document.body.style.overflow = '';
        } else {
            // Desktop
            this.sidebar.classList.remove('mobile-open', 'mobile-hidden');
            document.body.style.overflow = '';

            // Restore saved preference
            const isCollapsed = localStorage.getItem('sidebarCollapsed') === 'true';
            this.sidebar.classList.toggle('collapsed', isCollapsed);
            this.main.classList.toggle('expanded', isCollapsed);
        }
    }

    handleVisibilityChange() {
        if (document.visibilityState === 'visible') {
            // Refresh notifications when page becomes visible
            this.refreshNotifications();
        }
    }

    setupResponsive() {
        // Initialize responsive behavior
        this.handleResize();

        // Setup viewport meta for better mobile experience
        let viewport = document.querySelector("meta[name=viewport]");
        if (viewport) {
            viewport.setAttribute('content',
                'width=device-width, initial-scale=1, shrink-to-fit=no, viewport-fit=cover');
        }
    }

    setupLoader() {
        // Enhanced loader functionality
        window.showLoader = (message = 'Loading...') => {
            const loader = document.getElementById('page-loader');
            const loaderText = loader.querySelector('.loader-text');
            if (loaderText) loaderText.textContent = message;

            loader.style.display = 'flex';
            // Force reflow
            loader.offsetHeight;
            loader.classList.add('show');
        };

        window.hideLoader = () => {
            const loader = document.getElementById('page-loader');
            loader.classList.remove('show');
            setTimeout(() => {
                loader.style.display = 'none';
            }, 300);
        };

        // AJAX loader integration
        if (typeof $ !== 'undefined') {
            $(document).ajaxStart(() => window.showLoader('Loading data...'));
            $(document).ajaxStop(() => window.hideLoader());
            $(document).ajaxError(() => {
                window.hideLoader();
                this.showToast('An error occurred while loading data', 'error');
            });
        }
    }

    setupSearch() {
        if (!this.searchInput) return;

        let searchTimeout;
        this.searchInput.addEventListener('input', (e) => {
            clearTimeout(searchTimeout);
            const query = e.target.value.trim();

            if (query.length < 2) {
                this.showSearchPlaceholder();
                return;
            }

            searchTimeout = setTimeout(() => this.performSearch(query), 300);
        });
    }

    async performSearch(query) {
        const resultsContainer = document.getElementById('searchResults');
        resultsContainer.innerHTML = '<div class="text-center py-4"><div class="spinner-border spinner-border-sm"></div><div class="mt-2">Searching...</div></div>';

        try {
            const response = await fetch('/Admin/Search', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Requested-With': 'XMLHttpRequest'
                },
                body: JSON.stringify({ query })
            });

            if (!response.ok) throw new Error('Search failed');

            const results = await response.json();
            this.displaySearchResults(results);
        } catch (error) {
            resultsContainer.innerHTML = '<div class="text-center py-4 text-danger"><i class="bi bi-exclamation-triangle"></i><div class="mt-2">Search failed. Please try again.</div></div>';
        }
    }

    displaySearchResults(results) {
        const resultsContainer = document.getElementById('searchResults');

        if (!results || results.length === 0) {
            resultsContainer.innerHTML = '<div class="text-center py-4 text-muted"><i class="bi bi-search"></i><div class="mt-2">No results found</div></div>';
            return;
        }

        const html = results.map(item => `
                    <a href="${item.url}" class="d-flex align-items-center p-2 rounded text-decoration-none" style="color: var(--text-primary); background: var(--glass-bg);">
                        <div class="flex-shrink-0 me-3">
                            <i class="bi ${item.icon} fs-5"></i>
                        </div>
                        <div class="flex-grow-1">
                            <div class="fw-medium">${item.title}</div>
                            <div class="text-muted small">${item.description}</div>
                        </div>
                        <div class="flex-shrink-0">
                            <span class="badge bg-secondary">${item.type}</span>
                        </div>
                    </a>
                `).join('');

        resultsContainer.innerHTML = html;
    }

    showSearchPlaceholder() {
        const resultsContainer = document.getElementById('searchResults');
        resultsContainer.innerHTML = '<div class="text-muted text-center py-4"><i class="bi bi-search display-6 opacity-50"></i><div class="mt-2">Start typing to search...</div></div>';
    }

    setupNotifications() {
        // Real-time notifications setup
        this.refreshNotifications();

        // Auto-refresh notifications every 30 seconds
        setInterval(() => this.refreshNotifications(), 30000);

        // Mark all as read functionality
        document.getElementById('markAllRead')?.addEventListener('click', () => {
            this.markAllNotificationsRead();
        });
    }

    async refreshNotifications() {
        try {
            const response = await fetch('/Admin/Notifications/GetLatest');
            if (response.ok) {
                const data = await response.json();
                this.updateNotificationBadge(data.unreadCount);
                this.updateNotificationsList(data.notifications);
            }
        } catch (error) {
            console.warn('Failed to refresh notifications:', error);
        }
    }

    updateNotificationBadge(count) {
        const badge = document.querySelector('#notificationsToggle .badge');
        if (badge) {
            badge.textContent = count;
            badge.style.display = count > 0 ? 'block' : 'none';
        }
    }

    updateNotificationsList(notifications) {
        const container = document.getElementById('notificationsList');
        if (!container || !notifications) return;

        // Update with new notifications (implementation depends on your data structure)
        // This is a placeholder - you'll need to implement based on your notification system
    }

    async markAllNotificationsRead() {
        try {
            const response = await fetch('/Admin/Notifications/MarkAllRead', { method: 'POST' });
            if (response.ok) {
                this.updateNotificationBadge(0);
                this.showToast('All notifications marked as read', 'success');
            }
        } catch (error) {
            this.showToast('Failed to mark notifications as read', 'error');
        }
    }

    setupThemeToggle() {
        const themeToggle = document.getElementById('themeToggle');
        const icon = themeToggle?.querySelector('i');

        themeToggle?.addEventListener('click', () => {
            const isDark = document.body.classList.toggle('dark-theme');
            icon?.classList.toggle('bi-moon', !isDark);
            icon?.classList.toggle('bi-sun', isDark);

            localStorage.setItem('darkTheme', isDark);
            this.showToast(`${isDark ? 'Dark' : 'Light'} theme activated`, 'info');
        });

        // Apply saved theme
        if (localStorage.getItem('darkTheme') === 'true') {
            document.body.classList.add('dark-theme');
            icon?.classList.replace('bi-moon', 'bi-sun');
        }
    }

    setupFullscreen() {
        const fullscreenToggle = document.getElementById('fullscreenToggle');
        const icon = fullscreenToggle?.querySelector('i');

        fullscreenToggle?.addEventListener('click', () => {
            if (document.fullscreenElement) {
                document.exitFullscreen();
                icon?.classList.replace('bi-fullscreen-exit', 'bi-arrows-fullscreen');
            } else {
                document.documentElement.requestFullscreen();
                icon?.classList.replace('bi-arrows-fullscreen', 'bi-fullscreen-exit');
            }
        });

        document.addEventListener('fullscreenchange', () => {
            const isFullscreen = !!document.fullscreenElement;
            icon?.classList.toggle('bi-arrows-fullscreen', !isFullscreen);
            icon?.classList.toggle('bi-fullscreen-exit', isFullscreen);
        });
    }

    loadUserPreferences() {
        // Load saved sidebar state
        const sidebarCollapsed = localStorage.getItem('sidebarCollapsed') === 'true';
        if (window.innerWidth > 992 && sidebarCollapsed) {
            this.sidebar.classList.add('collapsed');
            this.main.classList.add('expanded');
            const icon = this.sidebarToggle.querySelector('i');
            icon?.classList.replace('bi-chevron-left', 'bi-chevron-right');
        }
    }

    initializeTooltips() {
        // Initialize Bootstrap tooltips
        const tooltipTriggerList = [].slice.call(document.querySelectorAll('[title]:not([data-bs-toggle])'));
        tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl, {
                delay: { show: 500, hide: 100 }
            });
        });
    }

    showToast(message, type = 'info') {
        if (typeof toastr !== 'undefined') {
            toastr.options.positionClass = 'toast-top-right';
            toastr.options.timeOut = 3000;
            toastr[type](message);
        }
    }

    // Public API methods
    showLoader(message) { window.showLoader(message); }
    hideLoader() { window.hideLoader(); }

    addNotification(notification) {
        // Add new notification to the list
        this.refreshNotifications();
    }

    updateBadge(elementId, count) {
        const badge = document.getElementById(elementId);
        if (badge) {
            badge.textContent = count;
            badge.style.display = count > 0 ? 'inline' : 'none';
        }
    }
}

// Initialize admin layout when DOM is ready
document.addEventListener('DOMContentLoaded', () => {
    window.adminLayout = new AdminLayout();

    // Configure enhanced toastr
    if (typeof toastr !== 'undefined') {
        toastr.options = {
            closeButton: true,
            debug: false,
            newestOnTop: true,
            progressBar: true,
            positionClass: 'toast-top-right',
            preventDuplicates: false,
            showDuration: 300,
            hideDuration: 1000,
            timeOut: 5000,
            extendedTimeOut: 1000,
            showEasing: 'swing',
            hideEasing: 'linear',
            showMethod: 'fadeIn',
            hideMethod: 'fadeOut'
        };
    }

    // Configure SweetAlert2 defaults
    if (typeof Swal !== 'undefined') {
        Swal.mixin({
            customClass: {
                popup: 'swal2-backdrop-blur',
                confirmButton: 'btn btn-primary me-2',
                cancelButton: 'btn btn-secondary'
            },
            buttonsStyling: false,
            background: 'var(--glass-bg)',
            backdrop: 'rgba(102, 126, 234, 0.8)',
            color: 'var(--text-primary)'
        });
    }

    // Hide loader when page is fully loaded
    window.addEventListener('load', () => {
        setTimeout(() => window.hideLoader(), 500);
    });
});

// Service Worker registration for PWA support
if ('serviceWorker' in navigator) {
    window.addEventListener('load', () => {
        navigator.serviceWorker.register('/sw.js')
            .then((registration) => {
                console.log('SW registered: ', registration);
            })
            .catch((registrationError) => {
                console.log('SW registration failed: ', registrationError);
            });
    });
}