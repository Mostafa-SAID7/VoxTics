        // Enhanced Public Layout Functionality
        class PublicLayout {
            constructor() {
                this.navbar = document.getElementById('mainNavbar');
                this.backToTopBtn = document.getElementById('backToTop');
                this.loadingOverlay = document.getElementById('loadingOverlay');
                this.searchInput = document.querySelector('.search-input');
                this.init();
            }

            init() {
                this.setupScrollEffects();
                this.setupBackToTop();
                this.setupSearch();
                this.setupAnimations();
                this.setupNotifications();
                this.setupLoader();
                this.setupKeyboardShortcuts();
                this.initializeTooltips();
            }

            setupScrollEffects() {
                let lastScrollTop = 0;

                window.addEventListener('scroll', () => {
                    const scrollTop = window.pageYOffset || document.documentElement.scrollTop;

                    // Navbar scroll effect
                    if (scrollTop > 50) {
                        this.navbar.classList.add('scrolled');
                    } else {
                        this.navbar.classList.remove('scrolled');
                    }

                    // Hide/show navbar on scroll
                    if (scrollTop > lastScrollTop && scrollTop > 100) {
                        this.navbar.style.transform = 'translateY(-100%)';
                    } else {
                        this.navbar.style.transform = 'translateY(0)';
                    }

                    lastScrollTop = scrollTop <= 0 ? 0 : scrollTop;

                    // Back to top button
                    if (scrollTop > 300) {
                        this.backToTopBtn.style.display = 'block';
                        this.backToTopBtn.style.opacity = '1';
                    } else {
                        this.backToTopBtn.style.opacity = '0';
                        setTimeout(() => {
                            if (this.backToTopBtn.style.opacity === '0') {
                                this.backToTopBtn.style.display = 'none';
                            }
                        }, 300);
                    }
                });
            }

            setupBackToTop() {
                this.backToTopBtn?.addEventListener('click', () => {
                    window.scrollTo({
                        top: 0,
                        behavior: 'smooth'
                    });
                });
            }

            setupSearch() {
                let searchTimeout;

                this.searchInput?.addEventListener('input', (e) => {
                    clearTimeout(searchTimeout);
                    const query = e.target.value.trim();

                    if (query.length >= 2) {
                        searchTimeout = setTimeout(() => {
                            this.performLiveSearch(query);
                        }, 300);
                    }
                });

                // Search suggestions dropdown
                this.createSearchSuggestions();
            }

            createSearchSuggestions() {
                if (!this.searchInput) return;

                const suggestionsContainer = document.createElement('div');
                suggestionsContainer.className = 'search-suggestions position-absolute w-100 mt-1';
                suggestionsContainer.style.cssText = `
                    background: var(--glass-bg);
                    backdrop-filter: var(--blur);
                    border: 1px solid var(--glass-border);
                    border-radius: var(--border-radius);
                    box-shadow: var(--shadow-lg);
                    z-index: 1000;
                    display: none;
                    max-height: 300px;
                    overflow-y: auto;
                `;

                this.searchInput.parentNode.appendChild(suggestionsContainer);
                this.suggestionsContainer = suggestionsContainer;

                // Hide suggestions when clicking outside
                document.addEventListener('click', (e) => {
                    if (!this.searchInput.parentNode.contains(e.target)) {
                        this.hideSuggestions();
                    }
                });
            }

            async performLiveSearch(query) {
                try {
                    const response = await fetch(`/api/search/suggestions?q=${encodeURIComponent(query)}`);
                    if (response.ok) {
                        const suggestions = await response.json();
                        this.displaySuggestions(suggestions);
                    }
                } catch (error) {
                    console.warn('Search suggestions failed:', error);
                }
            }

            displaySuggestions(suggestions) {
                if (!suggestions || suggestions.length === 0) {
                    this.hideSuggestions();
                    return;
                }

                const html = suggestions.map(item => `
                    <a href="${item.url}" class="d-flex align-items-center p-3 text-decoration-none suggestion-item"
                       style="color: var(--text-primary); border-bottom: 1px solid var(--glass-border);">
                        <i class="bi ${item.icon || 'bi-search'} me-3"></i>
                        <div class="flex-grow-1">
                            <div class="fw-medium">${item.title}</div>
                            ${item.subtitle ? `<div class="small text-muted">${item.subtitle}</div>` : ''}
                        </div>
                        <i class="bi bi-arrow-right text-muted"></i>
                    </a>
                `).join('');

                this.suggestionsContainer.innerHTML = html;
                this.suggestionsContainer.style.display = 'block';

                // Add hover effects
                this.suggestionsContainer.querySelectorAll('.suggestion-item').forEach(item => {
                    item.addEventListener('mouseenter', () => {
                        item.style.background = 'var(--glass-bg)';
                        item.style.transform = 'translateX(4px)';
                    });
                    item.addEventListener('mouseleave', () => {
                        item.style.background = 'transparent';
                        item.style.transform = 'translateX(0)';
                    });
                });
            }

            hideSuggestions() {
                if (this.suggestionsContainer) {
                    this.suggestionsContainer.style.display = 'none';
                }
            }

            setupAnimations() {
                // Intersection Observer for scroll animations
                const observerOptions = {
                    threshold: 0.1,
                    rootMargin: '0px 0px -50px 0px'
                };

                const observer = new IntersectionObserver((entries) => {
                    entries.forEach(entry => {
                        if (entry.isIntersecting) {
                            entry.target.style.opacity = '1';
                            entry.target.style.animation = entry.target.style.animation || 'fadeInUp 0.8s ease-out forwards';
                        }
                    });
                }, observerOptions);

                // Observe elements with animate-on-scroll class
                document.querySelectorAll('.animate-on-scroll').forEach(el => {
                    observer.observe(el);
                });
            }

            setupNotifications() {
                // Check for new notifications periodically
                if (document.querySelector('.user-avatar')) {
                    this.checkNotifications();
                    setInterval(() => this.checkNotifications(), 60000); // Check every minute
                }
            }

            async checkNotifications() {
                try {
                    const response = await fetch('/api/notifications/count');
                    if (response.ok) {
                        const data = await response.json();
                        this.updateNotificationBadge(data.count);
                    }
                } catch (error) {
                    console.warn('Failed to check notifications:', error);
                }
            }

            updateNotificationBadge(count) {
                const badge = document.getElementById('notificationBadge');
                if (badge) {
                    if (count > 0) {
                        badge.textContent = count > 9 ? '9+' : count;
                        badge.style.display = 'flex';
                    } else {
                        badge.style.display = 'none';
                    }
                }
            }

            setupLoader() {
                // Show loader for form submissions and navigation
                document.addEventListener('submit', (e) => {
                    if (!e.target.hasAttribute('data-no-loader')) {
                        this.showLoader();
                    }
                });

                // Show loader for navigation links
                document.querySelectorAll('a[href]:not([href^="#"]):not([href^="mailto:"]):not([href^="tel:"])').forEach(link => {
                    link.addEventListener('click', (e) => {
                        if (!link.hasAttribute('data-no-loader') &&
                            !link.hasAttribute('target') &&
                            !e.ctrlKey && !e.metaKey) {
                            this.showLoader();
                        }
                    });
                });

                // Hide loader when page loads
                window.addEventListener('load', () => {
                    this.hideLoader();
                });
            }

            setupKeyboardShortcuts() {
                document.addEventListener('keydown', (e) => {
                    // Ctrl/Cmd + K for search focus
                    if ((e.ctrlKey || e.metaKey) && e.key === 'k') {
                        e.preventDefault();
                        this.searchInput?.focus();
                    }

                    // Escape to close suggestions
                    if (e.key === 'Escape') {
                        this.hideSuggestions();
                        document.activeElement?.blur();
                    }
                });
            }

            initializeTooltips() {
                // Initialize Bootstrap tooltips
                const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
                tooltipTriggerList.map(function (tooltipTriggerEl) {
                    return new bootstrap.Tooltip(tooltipTriggerEl);
                });
            }

            showLoader() {
                if (this.loadingOverlay) {
                    this.loadingOverlay.style.display = 'flex';
                    setTimeout(() => {
                        this.loadingOverlay.style.opacity = '1';
                    }, 10);
                }
            }

            hideLoader() {
                if (this.loadingOverlay) {
                    this.loadingOverlay.style.opacity = '0';
                    setTimeout(() => {
                        this.loadingOverlay.style.display = 'none';
                    }, 300);
                }
            }

            // Public API methods
            showNotification(message, type = 'info') {
                if (typeof toastr !== 'undefined') {
                    toastr[type](message);
                }
            }

            refreshNotifications() {
                this.checkNotifications();
            }
        }

        // Initialize when DOM is ready
        document.addEventListener('DOMContentLoaded', () => {
            window.publicLayout = new PublicLayout();

            // Configure toastr
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

            // Configure SweetAlert2
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
        });

        // Newsletter subscription handling
        document.addEventListener('submit', function(e) {
            if (e.target.classList.contains('newsletter-form')) {
                e.preventDefault();

                const form = e.target;
                const email = form.querySelector('input[name="email"]').value;

                if (email) {
                    // Show success message
                    window.publicLayout?.showNotification('Thank you for subscribing to our newsletter!', 'success');
                    form.reset();
                }
            }
        });
