// VoxTics - Main Site JavaScript
// Global site functionality and utilities

(function() {
    'use strict';

    document.addEventListener('DOMContentLoaded', function() {
        initializeGlobalFeatures();
    });

    function initializeGlobalFeatures() {
        initializeTooltips();
        initializeImageLazyLoading();
    }

    function initializeTooltips() {
        const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
        tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl);
        });
    }

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

    window.VoxTics = {
        showLoading: function(element, text) {
            VoxTicsUtils.showLoading(element, text);
        },

        hideLoading: function(element) {
            VoxTicsUtils.hideLoading(element);
        },

        formatCurrency: function(amount, currency, locale) {
            return VoxTicsUtils.formatCurrency(amount, currency, locale);
        },

        formatDate: function(date, options, locale) {
            return VoxTicsUtils.formatDate(date, options, locale);
        },

        notify: function(message, type, options) {
            VoxTicsUtils.notify(message, type, options);
        }
    };

})();
