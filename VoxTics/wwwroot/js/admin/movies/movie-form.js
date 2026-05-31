(function () {
    'use strict';

    document.addEventListener('DOMContentLoaded', function () {
        initMovieForm();
    });

    function initMovieForm() {
        initImagePreviews();
        initFormSubmit();
    }

    function initImagePreviews() {
        document.querySelectorAll('input[type="file"][accept*="image"]').forEach(function (input) {
            input.addEventListener('change', function () {
                const file = this.files[0];
                if (!file) return;
                const previewId = this.dataset.preview;
                const preview = previewId ? document.getElementById(previewId) : null;
                if (preview) {
                    const reader = new FileReader();
                    reader.onload = function (e) { preview.src = e.target.result; };
                    reader.readAsDataURL(file);
                }
            });
        });
    }

    function initFormSubmit() {
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
