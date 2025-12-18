// VoxTics - Centralized Utilities
// Reusable functions and utilities for the entire application

(function(window, document) {
    'use strict';

    // =============================================================================
    // CORE UTILITIES
    // =============================================================================

    /**
     * Performance Monitor - Track execution times
     */
    class PerformanceMonitor {
        constructor() {
            this.marks = new Map();
        }

        start(name) {
            this.marks.set(name, performance.now());
        }

        end(name) {
            const startTime = this.marks.get(name);
            if (startTime) {
                const duration = performance.now() - startTime;
                console.log(`⏱️ ${name} took ${duration.toFixed(2)}ms`);
                this.marks.delete(name);
                return duration;
            }
            return null;
        }

        clear() {
            this.marks.clear();
        }
    }

    /**
     * Event Delegator - Efficient event handling for dynamic content
     */
    class EventDelegator {
        constructor() {
            this.handlers = new Map();
        }

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

        cleanup() {
            this.handlers.clear();
        }
    }

    /**
     * API Service - Centralized HTTP request handling
     */
    class ApiService {
        constructor(config = {}) {
            this.baseUrl = config.baseUrl || '';
            this.timeout = config.timeout || 10000;
            this.defaultHeaders = {
                'Content-Type': 'application/json',
                ...config.headers
            };
        }

        async request(url, options = {}) {
            const controller = new AbortController();
            const timeoutId = setTimeout(() => controller.abort(), this.timeout);

            try {
                const response = await fetch(url, {
                    ...options,
                    signal: controller.signal,
                    headers: {
                        ...this.defaultHeaders,
                        ...options.headers
                    }
                });

                clearTimeout(timeoutId);

                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }

                const contentType = response.headers.get('content-type');
                if (contentType && contentType.includes('application/json')) {
                    return await response.json();
                } else {
                    return await response.text();
                }
            } catch (error) {
                clearTimeout(timeoutId);
                console.error('API request failed:', error);
                throw error;
            }
        }

        async get(url, params = {}) {
            const urlWithParams = new URL(url, window.location.origin);
            Object.keys(params).forEach(key => {
                if (params[key] !== null && params[key] !== undefined) {
                    urlWithParams.searchParams.append(key, params[key]);
                }
            });
            return this.request(urlWithParams.toString());
        }

        async post(url, data = {}) {
            return this.request(url, {
                method: 'POST',
                body: data instanceof FormData ? data : JSON.stringify(data)
            });
        }

        async put(url, data = {}) {
            return this.request(url, {
                method: 'PUT',
                body: JSON.stringify(data)
            });
        }

        async delete(url) {
            return this.request(url, { method: 'DELETE' });
        }
    }

    // =============================================================================
    // UI UTILITIES
    // =============================================================================

    /**
     * Unified Notification System
     */
    class NotificationService {
        static show(message, type = 'info', options = {}) {
            const config = {
                duration: 5000,
                position: 'top-end',
                ...options
            };

            try {
                // Try VoxTics main notification system first
                if (window.VoxTicsMain?.showNotification) {
                    window.VoxTicsMain.showNotification(message, type);
                    return;
                }
                
                // Try Toastr if available
                if (typeof toastr !== 'undefined' && toastr[type]) {
                    toastr.options = {
                        timeOut: config.duration,
                        positionClass: `toast-${config.position}`
                    };
                    toastr[type](message);
                    return;
                }
                
                // Try SweetAlert2 if available
                if (typeof Swal !== 'undefined') {
                    const iconMap = {
                        success: 'success',
                        error: 'error',
                        warning: 'warning',
                        info: 'info'
                    };
                    
                    Swal.fire({
                        icon: iconMap[type] || 'info',
                        title: message,
                        toast: true,
                        position: config.position,
                        showConfirmButton: false,
                        timer: config.duration
                    });
                    return;
                }
                
                // Fallback to custom notification
                this.createCustomNotification(message, type, config);
            } catch (error) {
                console.error('Failed to show notification:', error);
                // Last resort fallback
                if (type === 'error') {
                    alert(`Error: ${message}`);
                } else {
                    console.log(`NOTIFICATION (${type}): ${message}`);
                }
            }
        }

        static createCustomNotification(message, type, config) {
            const notification = document.createElement('div');
            const typeClass = type === 'error' ? 'danger' : type;
            
            notification.className = `alert alert-${typeClass} alert-dismissible fade show position-fixed m-3`;
            notification.style.cssText = `
                z-index: 9999;
                ${config.position.includes('top') ? 'top: 20px;' : 'bottom: 20px;'}
                ${config.position.includes('end') ? 'right: 20px;' : 'left: 20px;'}
                max-width: 400px;
            `;
            
            notification.innerHTML = `
                <div class="d-flex align-items-center">
                    <i class="bi bi-${this.getIcon(type)} me-2"></i>
                    <span>${message}</span>
                    <button type="button" class="btn-close ms-auto" data-bs-dismiss="alert"></button>
                </div>
            `;
            
            document.body.appendChild(notification);
            
            // Auto-remove after duration
            setTimeout(() => {
                if (notification.parentNode) {
                    notification.classList.remove('show');
                    setTimeout(() => notification.remove(), 150);
                }
            }, config.duration);
        }

        static getIcon(type) {
            const icons = {
                success: 'check-circle',
                error: 'exclamation-triangle',
                warning: 'exclamation-triangle',
                info: 'info-circle'
            };
            return icons[type] || 'info-circle';
        }
    }

    /**
     * Loading State Manager
     */
    class LoadingManager {
        static show(element, text = 'Loading...') {
            if (!element) return;
            
            element.classList.add('loading');
            element.setAttribute('data-original-content', element.innerHTML);
            
            const spinner = `
                <span class="spinner-border spinner-border-sm me-2" role="status"></span>
                ${text}
            `;
            
            if (element.tagName === 'BUTTON') {
                element.disabled = true;
                element.innerHTML = spinner;
            } else {
                element.innerHTML = `
                    <div class="d-flex justify-content-center align-items-center p-3">
                        ${spinner}
                    </div>
                `;
            }
        }

        static hide(element) {
            if (!element) return;
            
            element.classList.remove('loading');
            const originalContent = element.getAttribute('data-original-content');
            
            if (originalContent) {
                element.innerHTML = originalContent;
                element.removeAttribute('data-original-content');
            }
            
            if (element.tagName === 'BUTTON') {
                element.disabled = false;
            }
        }
    }

    /**
     * Star Rating System
     */
    class StarRating {
        constructor(container, options = {}) {
            this.container = container;
            this.options = {
                maxRating: 5,
                currentRating: 0,
                readonly: false,
                onRate: null,
                ...options
            };
            this.stars = [];
            this.init();
        }

        init() {
            this.createStars();
            this.bindEvents();
            this.setRating(this.options.currentRating);
        }

        createStars() {
            this.container.innerHTML = '';
            for (let i = 1; i <= this.options.maxRating; i++) {
                const star = document.createElement('i');
                star.className = 'bi bi-star rating-star';
                star.dataset.rating = i;
                this.container.appendChild(star);
                this.stars.push(star);
            }
        }

        bindEvents() {
            if (this.options.readonly) return;

            this.stars.forEach((star, index) => {
                star.addEventListener('click', () => {
                    const rating = index + 1;
                    this.setRating(rating);
                    if (this.options.onRate) {
                        this.options.onRate(rating);
                    }
                });

                star.addEventListener('mouseenter', () => {
                    this.highlightStars(index + 1);
                });
            });

            this.container.addEventListener('mouseleave', () => {
                this.setRating(this.options.currentRating);
            });
        }

        setRating(rating) {
            this.options.currentRating = rating;
            this.highlightStars(rating);
        }

        highlightStars(rating) {
            this.stars.forEach((star, index) => {
                if (index < rating) {
                    star.classList.remove('bi-star');
                    star.classList.add('bi-star-fill', 'text-warning');
                } else {
                    star.classList.remove('bi-star-fill', 'text-warning');
                    star.classList.add('bi-star');
                }
            });
        }

        getRating() {
            return this.options.currentRating;
        }
    }

    // =============================================================================
    // UTILITY FUNCTIONS
    // =============================================================================

    /**
     * Modern clipboard functionality with fallback
     */
    async function copyToClipboard(text) {
        try {
            // Modern Clipboard API
            if (navigator.clipboard && window.isSecureContext) {
                await navigator.clipboard.writeText(text);
                NotificationService.show('Copied to clipboard', 'success');
                return;
            }
            
            // Fallback for older browsers
            await fallbackCopyToClipboard(text);
            NotificationService.show('Copied to clipboard', 'success');
        } catch (error) {
            console.error('Failed to copy to clipboard:', error);
            NotificationService.show('Failed to copy. Please copy manually.', 'error');
        }
    }

    function fallbackCopyToClipboard(text) {
        return new Promise((resolve, reject) => {
            // Try to use the newer document.execCommand alternative first
            if (navigator.clipboard && navigator.clipboard.writeText) {
                navigator.clipboard.writeText(text)
                    .then(resolve)
                    .catch(() => {
                        // Fall back to the legacy method if clipboard API fails
                        legacyCopyToClipboard(text, resolve, reject);
                    });
            } else {
                legacyCopyToClipboard(text, resolve, reject);
            }
        });
    }

    function legacyCopyToClipboard(text, resolve, reject) {
        const textArea = document.createElement('textarea');
        textArea.value = text;
        textArea.style.cssText = 'position:fixed;left:-999999px;top:-999999px;';
        
        document.body.appendChild(textArea);
        textArea.focus();
        textArea.select();
        
        try {
            // Note: execCommand is deprecated but still widely supported as fallback
            const successful = document.execCommand('copy');
            document.body.removeChild(textArea);
            
            if (successful) {
                resolve();
            } else {
                reject(new Error('Copy command failed'));
            }
        } catch (error) {
            document.body.removeChild(textArea);
            reject(error);
        }
    }

    /**
     * Debounce function for performance optimization
     */
    function debounce(func, wait, immediate = false) {
        let timeout;
        return function executedFunction(...args) {
            const later = () => {
                timeout = null;
                if (!immediate) func.apply(this, args);
            };
            const callNow = immediate && !timeout;
            clearTimeout(timeout);
            timeout = setTimeout(later, wait);
            if (callNow) func.apply(this, args);
        };
    }

    /**
     * Throttle function for performance optimization
     */
    function throttle(func, limit) {
        let inThrottle;
        return function(...args) {
            if (!inThrottle) {
                func.apply(this, args);
                inThrottle = true;
                setTimeout(() => inThrottle = false, limit);
            }
        };
    }

    /**
     * Format currency with locale support
     */
    function formatCurrency(amount, currency = 'USD', locale = 'en-US') {
        return new Intl.NumberFormat(locale, {
            style: 'currency',
            currency: currency
        }).format(amount);
    }

    /**
     * Format date with locale support
     */
    function formatDate(date, options = {}, locale = 'en-US') {
        const defaultOptions = {
            year: 'numeric',
            month: 'long',
            day: 'numeric'
        };
        return new Intl.DateTimeFormat(locale, { ...defaultOptions, ...options }).format(new Date(date));
    }

    /**
     * Validate email format
     */
    function isValidEmail(email) {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    }

    /**
     * Generate unique ID
     */
    function generateId(prefix = 'id') {
        return `${prefix}-${Date.now()}-${Math.random().toString(36).substring(2, 11)}`;
    }

    /**
     * Get CSRF token for forms
     */
    function getCSRFToken() {
        const token = document.querySelector('input[name="__RequestVerificationToken"]');
        return token ? token.value : null;
    }

    /**
     * Social sharing functionality
     */
    function shareOnSocial(platform, url, title = '') {
        const encodedUrl = encodeURIComponent(url);
        const encodedTitle = encodeURIComponent(title);
        
        const shareUrls = {
            facebook: `https://www.facebook.com/sharer/sharer.php?u=${encodedUrl}`,
            twitter: `https://twitter.com/intent/tweet?url=${encodedUrl}&text=${encodedTitle}`,
            linkedin: `https://www.linkedin.com/sharing/share-offsite/?url=${encodedUrl}`,
            whatsapp: `https://wa.me/?text=${encodedTitle}%20${encodedUrl}`,
            email: `mailto:?subject=${encodedTitle}&body=${encodedUrl}`
        };
        
        const shareUrl = shareUrls[platform];
        if (shareUrl) {
            if (platform === 'email') {
                window.location.href = shareUrl;
            } else {
                window.open(shareUrl, '_blank', 'width=600,height=400,scrollbars=yes,resizable=yes');
            }
        }
    }

    // =============================================================================
    // ADDITIONAL UTILITY FUNCTIONS
    // =============================================================================

    /**
     * Sanitize HTML to prevent XSS attacks
     */
    function sanitizeHtml(str) {
        const temp = document.createElement('div');
        temp.textContent = str;
        return temp.innerHTML;
    }

    /**
     * Format time duration (e.g., movie runtime)
     */
    function formatDuration(minutes) {
        const hours = Math.floor(minutes / 60);
        const mins = minutes % 60;
        
        if (hours > 0) {
            return `${hours}h ${mins}m`;
        }
        return `${mins}m`;
    }

    /**
     * Validate phone number format
     */
    function isValidPhone(phone) {
        const phoneRegex = /^[\+]?[1-9][\d]{0,15}$/;
        return phoneRegex.test(phone.replace(/[\s\-\(\)]/g, ''));
    }

    /**
     * Get responsive image URL based on screen size
     */
    function getResponsiveImageUrl(baseUrl, size = 'medium') {
        const sizes = {
            small: '_sm',
            medium: '_md', 
            large: '_lg',
            xlarge: '_xl'
        };
        
        const suffix = sizes[size] || sizes.medium;
        const extension = baseUrl.split('.').pop();
        const baseName = baseUrl.replace(`.${extension}`, '');
        
        return `${baseName}${suffix}.${extension}`;
    }

    /**
     * Local storage wrapper with error handling
     */
    const LocalStorageManager = {
        set(key, value) {
            try {
                localStorage.setItem(key, JSON.stringify(value));
                return true;
            } catch (error) {
                console.warn('LocalStorage not available:', error);
                return false;
            }
        },

        get(key, defaultValue = null) {
            try {
                const item = localStorage.getItem(key);
                return item ? JSON.parse(item) : defaultValue;
            } catch (error) {
                console.warn('LocalStorage read error:', error);
                return defaultValue;
            }
        },

        remove(key) {
            try {
                localStorage.removeItem(key);
                return true;
            } catch (error) {
                console.warn('LocalStorage remove error:', error);
                return false;
            }
        },

        clear() {
            try {
                localStorage.clear();
                return true;
            } catch (error) {
                console.warn('LocalStorage clear error:', error);
                return false;
            }
        }
    };

    // =============================================================================
    // GLOBAL EXPORTS
    // =============================================================================

    // Export all utilities to global VoxTics namespace
    window.VoxTicsUtils = {
        // Classes
        PerformanceMonitor,
        EventDelegator,
        ApiService,
        NotificationService,
        LoadingManager,
        StarRating,
        LocalStorageManager,
        
        // Utility functions
        copyToClipboard,
        debounce,
        throttle,
        formatCurrency,
        formatDate,
        formatDuration,
        isValidEmail,
        isValidPhone,
        generateId,
        getCSRFToken,
        shareOnSocial,
        sanitizeHtml,
        getResponsiveImageUrl,
        
        // Convenience aliases
        notify: NotificationService.show.bind(NotificationService),
        showLoading: LoadingManager.show.bind(LoadingManager),
        hideLoading: LoadingManager.hide.bind(LoadingManager)
    };

    // Backward compatibility
    window.showNotification = NotificationService.show.bind(NotificationService);

})(window, document);