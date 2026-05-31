(function () {
    'use strict';

    document.addEventListener('DOMContentLoaded', function () {
        initCategoryForm();
    });

    function initCategoryForm() {
        const form = document.querySelector('form');
        if (!form) return;

        form.addEventListener('submit', function () {
            const submitBtn = form.querySelector('[type="submit"]');
            if (submitBtn) {
                submitBtn.disabled = true;
                submitBtn.textContent = 'Saving...';
            }
        });
    }
})();
