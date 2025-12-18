// VoxTics - Main Site JavaScript
// Global site functionality and utilities

(function() {
    'use strict';

    // Initialize site when DOM is ready
    document.addEventListener('DOMContentLoaded', function() {
        initializeGlobalFeatures();
    });

    function initializeGlobalFeatures() {
        // Initialize common site features
        initializeTooltips();
        initializeModals();
        initializeScrollToTop();
        initializeImageLazyLoading();
    }

    // Bootstrap tooltips initialization
    function initializeTooltips() {
        const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
        tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl);
        });
    }

    // Bootstrap modals initialization
    function initializeModals() {
        const modalElements = document.querySelectorAll('.modal');
        modalElements.forEach(function(modalEl) {
            new bootstrap.Modal(modalEl);
        });
    }

    // Scroll to top functionality with throttling
    function initializeScrollToTop() {
        const scrollToTopBtn = document.querySelector('.btn-to-top');
        if (!scrollToTopBtn) return;

        // Use throttle from VoxTicsUtils if available
        const handleScroll = window.VoxTicsUtils 
            ? VoxTicsUtils.throttle(function() {
                if (window.pageYOffset > 300) {
                    scrollToTopBtn.classList.add('show');
                } else {
                    scrollToTopBtn.classList.remove('show');
                }
            }, 100)
            : function() {
                if (window.pageYOffset > 300) {
                    scrollToTopBtn.classList.add('show');
                } else {
                    scrollToTopBtn.classList.remove('show');
                }
            };

        window.addEventListener('scroll', handleScroll);

        scrollToTopBtn.addEventListener('click', function(e) {
            e.preventDefault();
            window.scrollTo({
                top: 0,
                behavior: 'smooth'
            });
        });
    }

    // Lazy loading for images
    function initializeImageLazyLoading() {
        if ('IntersectionObserver' in window) {
            const imageObserver = new IntersectionObserver((entries) => {
                entries.forEach(entry => {
                    if (entry.isIntersecting) {
                        const img = entry.target;
                        img.src = img.dataset.src;
                        img.classList.remove('lazy');
                        imageObserver.unobserve(img);
                    }
                });
            });

            document.querySelectorAll('img[data-src]').forEach(img => {
                imageObserver.observe(img);
            });
        }
    }

    // Global utility functions - delegate to VoxTicsUtils if available
    window.VoxTics = {
        // Show loading spinner
        showLoading: function(element, text) {
            if (window.VoxTicsUtils) {
                VoxTicsUtils.showLoading(element, text);
            } else if (element) {
                element.classList.add('loading');
            }
        },

        // Hide loading spinner
        hideLoading: function(element) {
            if (window.VoxTicsUtils) {
                VoxTicsUtils.hideLoading(element);
            } else if (element) {
                element.classList.remove('loading');
            }
        },

        // Format currency
        formatCurrency: function(amount, currency, locale) {
            if (window.VoxTicsUtils) {
                return VoxTicsUtils.formatCurrency(amount, currency, locale);
            }
            return new Intl.NumberFormat('en-US', {
                style: 'currency',
                currency: currency || 'USD'
            }).format(amount);
        },

        // Format date
        formatDate: function(date, options, locale) {
            if (window.VoxTicsUtils) {
                return VoxTicsUtils.formatDate(date, options, locale);
            }
            return new Intl.DateTimeFormat('en-US', {
                year: 'numeric',
                month: 'long',
                day: 'numeric'
            }).format(new Date(date));
        },

        // Notification
        notify: function(message, type, options) {
            if (window.VoxTicsUtils) {
                VoxTicsUtils.notify(message, type, options);
            } else {
                console.log(`NOTIFICATION (${type}): ${message}`);
            }
        }
    };

})();