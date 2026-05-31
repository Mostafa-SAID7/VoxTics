// VoxTics - Admin Panel JavaScript
// Handles admin sidebar, theme toggle, and panel-wide features

(function() {
    'use strict';

    document.addEventListener('DOMContentLoaded', function() {
        initializeAdmin();
    });

    function initializeAdmin() {
        initializeSidebar();
        initializeThemeToggle();
        initializePageLoader();
        initializeTopbarActions();
        initializeToastrNotifications();
    }

    // Sidebar toggle (collapse/expand)
    function initializeSidebar() {
        const sidebar = document.getElementById('adminSidebar');
        const adminMain = document.getElementById('adminMain');
        const sidebarToggle = document.getElementById('sidebarToggle');
        const mobileToggle = document.getElementById('mobileToggle');

        if (sidebarToggle && sidebar && adminMain) {
            sidebarToggle.addEventListener('click', function() {
                sidebar.classList.toggle('collapsed');
                adminMain.classList.toggle('expanded');
                const icon = sidebarToggle.querySelector('i');
                if (icon) {
                    icon.classList.toggle('bi-chevron-left');
                    icon.classList.toggle('bi-chevron-right');
                }
            });
        }

        if (mobileToggle && sidebar) {
            mobileToggle.addEventListener('click', function() {
                sidebar.classList.toggle('mobile-open');
            });
        }
    }

    // Theme toggle (light / dark)
    function initializeThemeToggle() {
        const themeToggle = document.getElementById('themeToggle');
        if (!themeToggle) return;

        const saved = localStorage.getItem('voxtics-admin-theme') || 'light';
        applyTheme(saved);

        themeToggle.addEventListener('click', function() {
            const current = document.documentElement.getAttribute('data-theme') || 'light';
            const next = current === 'dark' ? 'light' : 'dark';
            applyTheme(next);
            localStorage.setItem('voxtics-admin-theme', next);
        });
    }

    function applyTheme(theme) {
        document.documentElement.setAttribute('data-theme', theme);
        const icon = document.querySelector('#themeToggle i');
        if (icon) {
            icon.className = theme === 'dark' ? 'bi bi-sun' : 'bi bi-moon';
        }
    }

    // Hide page loader once content is ready
    function initializePageLoader() {
        const loader = document.getElementById('page-loader');
        if (loader) {
            loader.style.opacity = '0';
            setTimeout(function() { loader.style.display = 'none'; }, 300);
        }
    }

    // Fullscreen toggle
    function initializeTopbarActions() {
        const fullscreenToggle = document.getElementById('fullscreenToggle');
        if (fullscreenToggle) {
            fullscreenToggle.addEventListener('click', function() {
                if (!document.fullscreenElement) {
                    document.documentElement.requestFullscreen().catch(function() {});
                    fullscreenToggle.querySelector('i').className = 'bi bi-fullscreen-exit';
                } else {
                    document.exitFullscreen().catch(function() {});
                    fullscreenToggle.querySelector('i').className = 'bi bi-arrows-fullscreen';
                }
            });
        }

        const markAllRead = document.getElementById('markAllRead');
        if (markAllRead) {
            markAllRead.addEventListener('click', function(e) {
                e.preventDefault();
                document.querySelectorAll('#notificationsList .dropdown-item').forEach(function(item) {
                    item.style.opacity = '0.5';
                });
            });
        }
    }

    // Show toastr notifications from TempData
    function initializeToastrNotifications() {
        if (typeof $ === 'undefined' || typeof toastr === 'undefined') return;
        var success = $('meta[name="success-notification"]').attr('content');
        var error = $('meta[name="error-notification"]').attr('content');
        if (success) toastr.success(success);
        if (error) toastr.error(error);
    }

})();
