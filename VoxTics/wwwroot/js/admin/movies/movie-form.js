// Movie Form Enhanced Functionality
class MovieForm {
    constructor() {
        this.init();
    }

    init() {
        this.initializeImagePreview();
        this.initializeDragAndDrop();
        this.initializeSlugGeneration();
        this.initializeRealTimeValidation();
        this.initializeFormSubmission();
        this.initializeThumbnailManagement();
    }

    // Image Preview Functionality
    initializeImagePreview() {
        const mainImageInput = document.getElementById('mainImageInput');
        const mainImagePreview = document.getElementById('mainImagePreview');

        if (mainImageInput && mainImagePreview) {
            mainImageInput.addEventListener('change', (e) => {
                this.previewImage(e.target, mainImagePreview);
            });
        }

        // Additional images preview
        const additionalImagesInput = document.querySelector('input[name="AdditionalImages"]');
        if (additionalImagesInput) {
            additionalImagesInput.addEventListener('change', (e) => {
                this.previewMultipleImages(e.target);
            });
        }
    }

    previewImage(input, previewElement) {
        const file = input.files[0];
        if (!file) return;

        if (!file.type.startsWith('image/')) {
            this.showToast('Please select a valid image file', 'error');
            return;
        }

        const reader = new FileReader();
        reader.onload = (e) => {
            previewElement.src = e.target.result;
            previewElement.classList.add('image-preview');
        };
        reader.readAsDataURL(file);
    }

    previewMultipleImages(input) {
        const files = input.files;
        if (!files.length) return;

        // Create preview container if it doesn't exist
        let previewContainer = document.getElementById('additionalImagesPreview');
        if (!previewContainer) {
            previewContainer = document.createElement('div');
            previewContainer.id = 'additionalImagesPreview';
            previewContainer.className = 'thumbnail-grid mt-3';
            input.parentNode.appendChild(previewContainer);
        }

        previewContainer.innerHTML = '';

        Array.from(files).forEach(file => {
            if (!file.type.startsWith('image/')) return;

            const reader = new FileReader();
            reader.onload = (e) => {
                const thumbnail = document.createElement('div');
                thumbnail.className = 'thumbnail-item';
                thumbnail.innerHTML = `
                    <img src="${e.target.result}" alt="Preview" class="thumbnail-image">
                    <div class="thumbnail-actions">
                        <button type="button" class="btn btn-sm btn-danger remove-thumbnail" data-filename="${file.name}">
                            <i class="fas fa-times"></i>
                        </button>
                    </div>
                `;
                previewContainer.appendChild(thumbnail);
            };
            reader.readAsDataURL(file);
        });
    }

    // Drag and Drop Functionality
    initializeDragAndDrop() {
        const uploadAreas = document.querySelectorAll('.image-upload-area');

        uploadAreas.forEach(area => {
            area.addEventListener('dragover', (e) => {
                e.preventDefault();
                area.classList.add('dragover');
            });

            area.addEventListener('dragleave', (e) => {
                e.preventDefault();
                area.classList.remove('dragover');
            });

            area.addEventListener('drop', (e) => {
                e.preventDefault();
                area.classList.remove('dragover');

                const files = e.dataTransfer.files;
                const input = area.querySelector('input[type="file"]');

                if (input) {
                    input.files = files;
                    const event = new Event('change', { bubbles: true });
                    input.dispatchEvent(event);
                }
            });
        });
    }

    // Slug Generation
    initializeSlugGeneration() {
        const titleInput = document.getElementById('Title');
        const slugInput = document.getElementById('Slug');

        if (titleInput && slugInput) {
            titleInput.addEventListener('blur', () => {
                if (!slugInput.value) {
                    this.generateSlug(titleInput.value, slugInput);
                }
            });

            slugInput.addEventListener('input', () => {
                this.slugifyInput(slugInput);
            });
        }
    }

    generateSlug(title, slugInput) {
        if (!title) return;

        const slug = title
            .toLowerCase()
            .trim()
            .replace(/[^a-z0-9\s-]/g, '')
            .replace(/[\s-]+/g, '-')
            .replace(/^-+|-+$/g, '');

        slugInput.value = slug;
    }

    slugifyInput(input) {
        input.value = input.value
            .toLowerCase()
            .replace(/[^a-z0-9\s-]/g, '')
            .replace(/[\s-]+/g, '-')
            .replace(/^-+|-+$/g, '');
    }

    // Real-time Validation
    initializeRealTimeValidation() {
        const form = document.querySelector('form');
        if (!form) return;

        const inputs = form.querySelectorAll('input, select, textarea');

        inputs.forEach(input => {
            input.addEventListener('blur', () => {
                this.validateField(input);
            });

            input.addEventListener('input', () => {
                this.clearFieldError(input);
            });
        });
    }

    validateField(field) {
        // Clear previous error
        this.clearFieldError(field);

        // Basic validation rules
        if (field.hasAttribute('required') && !field.value.trim()) {
            this.showFieldError(field, 'This field is required');
            return false;
        }

        if (field.type === 'email' && field.value) {
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailRegex.test(field.value)) {
                this.showFieldError(field, 'Please enter a valid email address');
                return false;
            }
        }

        if (field.type === 'number' && field.value) {
            const min = parseFloat(field.getAttribute('min'));
            const max = parseFloat(field.getAttribute('max'));
            const value = parseFloat(field.value);

            if (!isNaN(min) && value < min) {
                this.showFieldError(field, `Value must be greater than or equal to ${min}`);
                return false;
            }

            if (!isNaN(max) && value > max) {
                this.showFieldError(field, `Value must be less than or equal to ${max}`);
                return false;
            }
        }

        return true;
    }

    showFieldError(field, message) {
        field.classList.add('is-invalid');

        let errorElement = field.parentNode.querySelector('.field-error');
        if (!errorElement) {
            errorElement = document.createElement('div');
            errorElement.className = 'field-error text-danger mt-1 small';
            field.parentNode.appendChild(errorElement);
        }

        errorElement.textContent = message;
    }

    clearFieldError(field) {
        field.classList.remove('is-invalid');

        const errorElement = field.parentNode.querySelector('.field-error');
        if (errorElement) {
            errorElement.remove();
        }
    }

    // Form Submission
    initializeFormSubmission() {
        const form = document.querySelector('form');
        if (!form) return;

        form.addEventListener('submit', (e) => {
            if (!this.validateForm(form)) {
                e.preventDefault();
                this.showToast('Please fix the errors before submitting', 'error');
            } else {
                this.showLoadingState(true);
            }
        });
    }

    validateForm(form) {
        let isValid = true;
        const inputs = form.querySelectorAll('input, select, textarea');

        inputs.forEach(input => {
            if (!this.validateField(input)) {
                isValid = false;
            }
        });

        return isValid;
    }

    showLoadingState(show) {
        const submitButton = document.querySelector('button[type="submit"]');
        const cancelButton = document.querySelector('a.btn-secondary');

        if (show) {
            submitButton.classList.add('loading');
            submitButton.innerHTML = '<i class="fas fa-spinner fa-spin me-2"></i>Saving...';
            cancelButton.classList.add('disabled');
        } else {
            submitButton.classList.remove('loading');
            cancelButton.classList.remove('disabled');
        }
    }

    // Thumbnail Management
    initializeThumbnailManagement() {
        document.addEventListener('click', (e) => {
            if (e.target.closest('.remove-thumbnail')) {
                this.removeThumbnail(e.target.closest('.remove-thumbnail'));
            }
        });
    }

    removeThumbnail(button) {
        const thumbnail = button.closest('.thumbnail-item');
        const filename = button.dataset.filename;

        if (thumbnail) {
            thumbnail.style.transform = 'scale(0)';
            setTimeout(() => {
                thumbnail.remove();
                this.removeFileFromInput(filename);
            }, 300);
        }
    }

    removeFileFromInput(filename) {
        // This would need to be implemented based on your file input handling
        console.log('Remove file:', filename);
    }

    // Utility Functions
    showToast(message, type = 'info') {
        // Implement toast notification or use existing framework
        console.log(`${type.toUpperCase()}: ${message}`);
    }
}

// Initialize when DOM is loaded
document.addEventListener('DOMContentLoaded', function () {
    new MovieForm();
});

// Export for potential module usage
if (typeof module !== 'undefined' && module.exports) {
    module.exports = MovieForm;
}