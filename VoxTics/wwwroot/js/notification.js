// wwwroot/js/notifications.js
class NotificationManager {
    constructor() {
        this.container = document.getElementById('notification-container');
        this.template = document.getElementById('notification-template');
        this.icons = {
            success: 'bi-check-circle-fill',
            error: 'bi-x-circle-fill',
            warning: 'bi-exclamation-triangle-fill',
            info: 'bi-info-circle-fill'
        };
        this.init();
    }

    init() {
        // Process queued notifications from server
        if (window.notificationQueue) {
            window.notificationQueue.forEach(notification => {
                this.show(notification);
            });
            window.notificationQueue = null;
        }

        // Global notification method
        window.showNotification = this.show.bind(this);
    }

    show(options) {
        if (typeof options === 'string') {
            options = { message: options, type: 'info' };
        }

        const config = {
            type: options.type || 'info',
            title: options.title || this.getDefaultTitle(options.type),
            message: options.message || '',
            autoClose: options.autoClose !== undefined ? options.autoClose : 5000,
            dismissible: options.dismissible !== false,
            icon: options.icon || this.icons[options.type] || this.icons.info,
            position: options.position || this.container?.dataset.position || 'top-right',
            data: options.data
        };

        this.createNotification(config);
    }

    getDefaultTitle(type) {
        const titles = {
            success: 'Success',
            error: 'Error',
            warning: 'Warning',
            info: 'Information'
        };
        return titles[type] || 'Notification';
    }

    createNotification(config) {
        if (!this.template) return;

        const clone = this.template.content.cloneNode(true);
        const notificationEl = clone.querySelector('.notification');

        // Set notification type and attributes
        notificationEl.classList.add(config.type);
        notificationEl.setAttribute('role', 'alert');
        notificationEl.setAttribute('aria-live', 'polite');
        notificationEl.dataset.notificationId = this.generateId();

        // Set icon
        const iconEl = clone.querySelector('[data-icon]');
        iconEl.className = `bi ${config.icon}`;

        // Set title and message
        clone.querySelector('[data-title]').textContent = config.title;
        clone.querySelector('[data-message]').textContent = config.message;

        // Add to container
        this.container.appendChild(clone);

        // Get the actual DOM element
        const newNotification = this.container.lastElementChild;

        // Add show animation
        setTimeout(() => {
            newNotification.classList.add('showing');
        }, 10);

        // Setup auto-close
        let autoCloseTimeout;
        if (config.autoClose > 0) {
            this.setupAutoClose(newNotification, config.autoClose);
        }

        // Setup close button
        if (config.dismissible) {
            const closeBtn = newNotification.querySelector('.notification-close');
            closeBtn.addEventListener('click', () => {
                this.close(newNotification);
            });
        }

        // Pause on hover
        newNotification.addEventListener('mouseenter', () => {
            if (autoCloseTimeout) {
                clearTimeout(autoCloseTimeout);
                newNotification.classList.add('progress-paused');
            }
        });

        newNotification.addEventListener('mouseleave', () => {
            if (config.autoClose > 0) {
                this.setupAutoClose(newNotification, config.autoClose);
            }
        });

        // Accessibility
        newNotification.addEventListener('keydown', (e) => {
            if (e.key === 'Escape' && config.dismissible) {
                this.close(newNotification);
            }
        });

        return newNotification;
    }

    setupAutoClose(notification, duration) {
        const progressBar = notification.querySelector('.notification-progress');
        if (progressBar) {
            progressBar.style.animation = `progressBar ${duration}ms linear forwards`;
        }

        return setTimeout(() => {
            if (notification.parentElement) {
                this.close(notification);
            }
        }, duration);
    }

    close(notification) {
        if (!notification.parentElement) return;

        notification.classList.remove('showing');
        notification.classList.add('hiding');

        setTimeout(() => {
            if (notification.parentElement) {
                notification.remove();
            }
        }, 300);
    }

    closeAll() {
        const notifications = this.container.querySelectorAll('.notification');
        notifications.forEach(notification => this.close(notification));
    }

    generateId() {
        return `notification-${Date.now()}-${Math.random().toString(36).substr(2, 9)}`;
    }

    // Static methods for quick access
    static success(message, title = 'Success') {
        this.getInstance().show({ type: 'success', message, title });
    }

    static error(message, title = 'Error') {
        this.getInstance().show({ type: 'error', message, title });
    }

    static warning(message, title = 'Warning') {
        this.getInstance().show({ type: 'warning', message, title });
    }

    static info(message, title = 'Information') {
        this.getInstance().show({ type: 'info', message, title });
    }

    static getInstance() {
        if (!NotificationManager.instance) {
            NotificationManager.instance = new NotificationManager();
        }
        return NotificationManager.instance;
    }
}

// Initialize when DOM is loaded
document.addEventListener('DOMContentLoaded', () => {
    NotificationManager.getInstance();
});

// Export for module usage
if (typeof module !== 'undefined' && module.exports) {
    module.exports = NotificationManager;
}

//using in controllers:
//TempData["Success"] = "Your changes have been saved successfully!";

//// Multiple notifications
//TempData.AddSuccess("User created successfully!");
//TempData.AddWarning("Profile image is too large");
//TempData.AddInfo("System maintenance scheduled");

//// Custom notification
//var notification = new NotificationModel {
//    Type = "success",
//    Title = "Payment Processed",
//    Message = "Your payment of $99.00 was processed successfully.",
//    AutoClose = 8000
//};
//TempData.AddNotification(notification);
//<partial name="_Notifications" />