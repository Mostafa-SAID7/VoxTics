// Enhanced Movie Details JavaScript

class MovieDetailsManager {
    constructor() {
        this.isImageModalOpen = false;
        this.currentImageIndex = 0;
        this.galleryImages = [];
        this.init();
    }

    init() {
        this.setupAnimations();
        this.setupImageGallery();
        this.setupScrollEffects();
        this.setupInteractiveElements();
        this.setupKeyboardNavigation();
        this.setupLoadingStates();
        this.createImageModal();
    }

    setupAnimations() {
        // Intersection Observer for scroll animations
        const observer = new IntersectionObserver((entries) => {
            entries.forEach((entry, index) => {
                if (entry.isIntersecting) {
                    setTimeout(() => {
                        entry.target.classList.add('animate-fade-up');
                    }, index * 100);
                }
            });
        }, {
            threshold: 0.1,
            rootMargin: '0px 0px -50px 0px'
        });

        // Observe all animatable elements
        const animatableElements = document.querySelectorAll(
            '.content-section, .info-card, .cast-card, .showtime-card, .gallery-item'
        );

        animatableElements.forEach(element => {
            element.style.opacity = '0';
            element.style.transform = 'translateY(30px)';
            observer.observe(element);
        });

        // Hero content animations
        this.animateHeroContent();
    }

    animateHeroContent() {
        const heroElements = [
            { selector: '.hero-poster', delay: 200, animation: 'animate-fade-left' },
            { selector: '.hero-info h1', delay: 400, animation: 'animate-fade-right' },
            { selector: '.hero-meta', delay: 600, animation: 'animate-fade-right' },
            { selector: '.hero-description', delay: 800, animation: 'animate-fade-right' },
            { selector: '.hero-actions', delay: 1000, animation: 'animate-fade-right' }
        ];

        heroElements.forEach(({ selector, delay, animation }) => {
            const element = document.querySelector(selector);
            if (element) {
                element.style.opacity = '0';
                element.style.transform = animation.includes('left') ? 'translateX(-30px)' : 'translateX(30px)';

                setTimeout(() => {
                    element.classList.add(animation);
                    element.style.opacity = '1';
                }, delay);
            }
        });
    }

    setupImageGallery() {
        const galleryItems = document.querySelectorAll('.gallery-item');
        this.galleryImages = Array.from(galleryItems).map(item => ({
            src: item.querySelector('img').src,
            alt: item.querySelector('img').alt
        }));

        galleryItems.forEach((item, index) => {
            item.addEventListener('click', () => {
                this.openImageModal(index);
            });

            // Add loading state
            const img = item.querySelector('img');
            if (img) {
                this.setupImageLoading(img, item);
            }
        });

        // Setup main poster click
        const heroPoster = document.querySelector('.hero-poster img');
        if (heroPoster) {
            document.querySelector('.hero-poster').addEventListener('click', () => {
                this.openImageModal(0, heroPoster.src);
            });
        }
    }

    setupImageLoading(img, container) {
        const placeholder = document.createElement('div');
        placeholder.className = 'loading-skeleton';
        placeholder.style.cssText = `
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            z-index: 1;
        `;

        container.style.position = 'relative';
        container.appendChild(placeholder);

        img.addEventListener('load', () => {
            placeholder.style.opacity = '0';
            setTimeout(() => placeholder.remove(), 300);
        });

        img.addEventListener('error', () => {
            placeholder.style.background = '#f1f5f9';
            placeholder.innerHTML = `
                <div style="display: flex; align-items: center; justify-content: center; height: 100%; color: #a0aec0;">
                    <span>📷</span>
                </div>
            `;
        });
    }

    createImageModal() {
        const modal = document.createElement('div');
        modal.className = 'image-modal';
        modal.innerHTML = `
            <div class="modal-overlay">
                <div class="modal-content">
                    <button class="modal-close">&times;</button>
                    <button class="modal-prev">&#8249;</button>
                    <button class="modal-next">&#8250;</button>
                    <img class="modal-image" src="" alt="">
                    <div class="modal-counter">
                        <span class="current-index">1</span> / <span class="total-images">1</span>
                    </div>
                </div>
            </div>
        `;

        // Add modal styles
        const style = document.createElement('style');
        style.textContent = `
            .image-modal {
                position: fixed;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                z-index: 10000;
                opacity: 0;
                visibility: hidden;
                transition: all 0.3s ease;
            }
            
            .image-modal.active {
                opacity: 1;
                visibility: visible;
            }
            
            .modal-overlay {
                position: absolute;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                background: rgba(0, 0, 0, 0.95);
                backdrop-filter: blur(20px);
                display: flex;
                align-items: center;
                justify-content: center;
                padding: 2rem;
            }
            
            .modal-content {
                position: relative;
                max-width: 90vw;
                max-height: 90vh;
                display: flex;
                align-items: center;
                justify-content: center;
            }
            
            .modal-image {
                max-width: 100%;
                max-height: 100%;
                object-fit: contain;
                border-radius: 12px;
                box-shadow: 0 25px 50px rgba(0, 0, 0, 0.5);
            }
            
            .modal-close, .modal-prev, .modal-next {
                position: absolute;
                background: rgba(255, 255, 255, 0.1);
                border: 2px solid rgba(255, 255, 255, 0.3);
                color: white;
                font-size: 2rem;
                padding: 1rem;
                border-radius: 50%;
                cursor: pointer;
                transition: all 0.3s ease;
                backdrop-filter: blur(20px);
                z-index: 10001;
            }
            
            .modal-close {
                top: -60px;
                right: -60px;
                width: 60px;
                height: 60px;
                display: flex;
                align-items: center;
                justify-content: center;
            }
            
            .modal-prev {
                left: -80px;
                top: 50%;
                transform: translateY(-50%);
                width: 60px;
                height: 60px;
                display: flex;
                align-items: center;
                justify-content: center;
            }
            
            .modal-next {
                right: -80px;
                top: 50%;
                transform: translateY(-50%);
                width: 60px;
                height: 60px;
                display: flex;
                align-items: center;
                justify-content: center;
            }
            
            .modal-close:hover, .modal-prev:hover, .modal-next:hover {
                background: rgba(255, 255, 255, 0.2);
                border-color: rgba(255, 255, 255, 0.5);
                transform: scale(1.1);
            }
            
            .modal-next:hover {
                transform: translateY(-50%) scale(1.1);
            }
            
            .modal-prev:hover {
                transform: translateY(-50%) scale(1.1);
            }
            
            .modal-counter {
                position: absolute;
                bottom: -60px;
                left: 50%;
                transform: translateX(-50%);
                color: white;
                background: rgba(255, 255, 255, 0.1);
                padding: 0.75rem 1.5rem;
                border-radius: 20px;
                backdrop-filter: blur(20px);
                border: 1px solid rgba(255, 255, 255, 0.2);
                font-weight: 600;
            }
            
            @media (max-width: 768px) {
                .modal-close { top: -40px; right: -40px; font-size: 1.5rem; }
                .modal-prev, .modal-next { font-size: 1.5rem; }
                .modal-prev { left: -40px; }
                .modal-next { right: -40px; }
                .modal-counter { bottom: -40px; font-size: 0.9rem; }
            }
        `;
        document.head.appendChild(style);
        document.body.appendChild(modal);

        // Setup modal event listeners
        modal.querySelector('.modal-close').addEventListener('click', () => this.closeImageModal());
        modal.querySelector('.modal-prev').addEventListener('click', () => this.previousImage());
        modal.querySelector('.modal-next').addEventListener('click', () => this.nextImage());
        modal.querySelector('.modal-overlay').addEventListener('click', (e) => {
            if (e.target === modal.querySelector('.modal-overlay')) {
                this.closeImageModal();
            }
        });

        this.imageModal = modal;
    }

    openImageModal(index, customSrc = null) {
        this.isImageModalOpen = true;
        this.currentImageIndex = index;

        const modal = this.imageModal;
        const modalImage = modal.querySelector('.modal-image');
        const currentIndexSpan = modal.querySelector('.current-index');
        const totalImagesSpan = modal.querySelector('.total-images');

        if (customSrc) {
            modalImage.src = customSrc;
            modalImage.alt = 'Movie Poster';
            currentIndexSpan.textContent = '1';
            totalImagesSpan.textContent = '1';
        } else {
            const imageData = this.galleryImages[index];
            modalImage.src = imageData.src;
            modalImage.alt = imageData.alt;
            currentIndexSpan.textContent = index + 1;
            totalImagesSpan.textContent = this.galleryImages.length;
        }

        modal.classList.add('active');
        document.body.style.overflow = 'hidden';
    }

    closeImageModal() {
        this.isImageModalOpen = false;
        this.imageModal.classList.remove('active');
        document.body.style.overflow = '';
    }

    previousImage() {
        if (this.galleryImages.length === 0) return;
        this.currentImageIndex = (this.currentImageIndex - 1 + this.galleryImages.length) % this.galleryImages.length;
        this.updateModalImage();
    }

    nextImage() {
        if (this.galleryImages.length === 0) return;
        this.currentImageIndex = (this.currentImageIndex + 1) % this.galleryImages.length;
        this.updateModalImage();
    }

    updateModalImage() {
        const modal = this.imageModal;
        const modalImage = modal.querySelector('.modal-image');
        const currentIndexSpan = modal.querySelector('.current-index');
        const imageData = this.galleryImages[this.currentImageIndex];

        modalImage.style.opacity = '0';
        setTimeout(() => {
            modalImage.src = imageData.src;
            modalImage.alt = imageData.alt;
            currentIndexSpan.textContent = this.currentImageIndex + 1;
            modalImage.style.opacity = '1';
        }, 150);
    }

    setupScrollEffects() {
        let ticking = false;

        const updateScrollEffects = () => {
            const scrolled = window.pageYOffset;
            const heroBackground = document.querySelector('.hero-background');
            const heroOverlay = document.querySelector('.hero-overlay');

            if (heroBackground) {
                // Parallax effect
                heroBackground.style.transform = `scale(1.1) translateY(${scrolled * 0.5}px)`;

                // Increase overlay opacity on scroll
                const opacity = Math.min(0.8 + (scrolled / 500) * 0.2, 0.95);
                heroOverlay.style.background = `linear-gradient(135deg, rgba(0,0,0,${opacity}) 0%, rgba(0,0,0,${opacity * 0.7}) 100%)`;
            }

            ticking = false;
        };

        window.addEventListener('scroll', () => {
            if (!ticking) {
                requestAnimationFrame(updateScrollEffects);
                ticking = true;
            }
        });
    }

    setupInteractiveElements() {
        // Enhanced hover effects for info cards
        const infoCards = document.querySelectorAll('.info-card');
        infoCards.forEach(card => {
            card.addEventListener('mouseenter', () => {
                this.addCardGlow(card);
            });

            card.addEventListener('mouseleave', () => {
                this.removeCardGlow(card);
            });
        });

        // Cast card interactions
        const castCards = document.querySelectorAll('.cast-card');
        castCards.forEach(card => {
            card.addEventListener('click', () => {
                this.highlightCastCard(card);
            });
        });

        // Showtime card booking interaction
        const showtimeCards = document.querySelectorAll('.showtime-card');
        showtimeCards.forEach(card => {
            card.addEventListener('click', () => {
                this.selectShowtime(card);
            });
        });

        // Button ripple effects
        const buttons = document.querySelectorAll('.btn-hero, .btn-book, .btn-back');
        buttons.forEach(button => {
            button.addEventListener('click', (e) => {
                this.createRipple(e, button);
            });
        });

        // Floating Action Button scroll behavior
        this.setupFAB();
    }

    addCardGlow(card) {
        card.style.boxShadow = '0 15px 35px rgba(102, 126, 234, 0.2), 0 8px 15px rgba(102, 126, 234, 0.1)';
        card.style.borderColor = 'rgba(102, 126, 234, 0.3)';
    }

    removeCardGlow(card) {
        card.style.boxShadow = '';
        card.style.borderColor = '';
    }

    highlightCastCard(card) {
        // Remove existing highlights
        document.querySelectorAll('.cast-card.highlighted')
            .forEach(c => c.classList.remove('highlighted'));

        // Add highlight to clicked card
        card.classList.add('highlighted');

        // Add temporary glow effect
        card.style.transform = 'translateY(-15px) scale(1.05)';
        card.style.boxShadow = '0 20px 40px rgba(102, 126, 234, 0.3)';

        setTimeout(() => {
            card.style.transform = '';
            card.style.boxShadow = '';
            card.classList.remove('highlighted');
        }, 2000);
    }

    selectShowtime(card) {
        // Remove previous selections
        document.querySelectorAll('.showtime-card.selected')
            .forEach(c => c.classList.remove('selected'));

        // Add selection to current card
        card.classList.add('selected');

        // Visual feedback
        card.style.background = 'linear-gradient(135deg, #e6fffa 0%, #f0fff4 100%)';
        card.style.borderColor = 'var(--success-color)';

        // Update FAB with selected showtime info
        const fab = document.querySelector('.fab-book');
        if (fab) {
            fab.title = 'Book Selected Showtime';
            fab.style.background = 'var(--gradient-success, linear-gradient(135deg, #48bb78 0%, #38a169 100%))';
        }
    }

    setupFAB() {
        const fab = document.querySelector('.fab-book');
        if (!fab) return;

        let isVisible = false;

        const showFAB = () => {
            if (!isVisible) {
                fab.style.transform = 'translateY(0) scale(1)';
                fab.style.opacity = '1';
                isVisible = true;
            }
        };

        const hideFAB = () => {
            if (isVisible) {
                fab.style.transform = 'translateY(100px) scale(0.8)';
                fab.style.opacity = '0';
                isVisible = false;
            }
        };

        // Show/hide based on scroll position
        let lastScrollTop = 0;
        window.addEventListener('scroll', () => {
            const scrollTop = window.pageYOffset;

            if (scrollTop > 300) {
                if (scrollTop < lastScrollTop) {
                    showFAB(); // Scrolling up
                } else {
                    hideFAB(); // Scrolling down
                }
            } else {
                hideFAB(); // At top of page
            }

            lastScrollTop = scrollTop;
        });

        // Initial state
        fab.style.transform = 'translateY(100px) scale(0.8)';
        fab.style.opacity = '0';
        fab.style.transition = 'all 0.3s cubic-bezier(0.4, 0, 0.2, 1)';
    }

    setupKeyboardNavigation() {
        document.addEventListener('keydown', (e) => {
            if (this.isImageModalOpen) {
                switch (e.key) {
                    case 'Escape':
                        this.closeImageModal();
                        break;
                    case 'ArrowLeft':
                        this.previousImage();
                        break;
                    case 'ArrowRight':
                        this.nextImage();
                        break;
                }
            }
        });
    }

    setupLoadingStates() {
        // Lazy load images in gallery and cast sections
        const lazyImages = document.querySelectorAll('img[loading="lazy"]');

        const imageObserver = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    const img = entry.target;
                    this.loadImageWithPlaceholder(img);
                    imageObserver.unobserve(img);
                }
            });
        });

        lazyImages.forEach(img => imageObserver.observe(img));
    }

    loadImageWithPlaceholder(img) {
        const container = img.parentElement;
        const placeholder = container.querySelector('.loading-skeleton');

        if (!placeholder) {
            const newPlaceholder = document.createElement('div');
            newPlaceholder.className = 'loading-skeleton';
            newPlaceholder.style.cssText = `
                position: absolute;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                border-radius: inherit;
            `;

            container.style.position = 'relative';
            container.insertBefore(newPlaceholder, img);

            img.addEventListener('load', () => {
                newPlaceholder.style.opacity = '0';
                setTimeout(() => newPlaceholder.remove(), 300);
            });
        }
    }

    createRipple(event, element) {
        const ripple = document.createElement('span');
        const rect = element.getBoundingClientRect();
        const size = Math.max(rect.width, rect.height);
        const x = event.clientX - rect.left - size / 2;
        const y = event.clientY - rect.top - size / 2;

        ripple.style.cssText = `
            position: absolute;
            width: ${size}px;
            height: ${size}px;
            left: ${x}px;
            top: ${y}px;
            background: rgba(255, 255, 255, 0.3);
            border-radius: 50%;
            transform: scale(0);
            animation: ripple 0.8s ease-out;
            pointer-events: none;
            z-index: 1;
        `;

        if (!element.style.position || element.style.position === 'static') {
            element.style.position = 'relative';
        }
        element.style.overflow = 'hidden';

        element.appendChild(ripple);

        setTimeout(() => ripple.remove(), 800);
    }

    // Utility methods
    formatRuntime(minutes) {
        const hours = Math.floor(minutes / 60);
        const mins = minutes % 60;
        return hours > 0 ? `${hours}h ${mins}m` : `${mins}m`;
    }

    shareMovie() {
        if (navigator.share) {
            navigator.share({
                title: document.querySelector('.hero-info h1').textContent,
                text: document.querySelector('.hero-description').textContent,
                url: window.location.href
            });
        } else {
            // Fallback - copy to clipboard
            navigator.clipboard.writeText(window.location.href).then(() => {
                this.showToast('Link copied to clipboard!');
            });
        }
    }

    showToast(message, duration = 3000) {
        const toast = document.createElement('div');
        toast.style.cssText = `
            position: fixed;
            bottom: 2rem;
            left: 50%;
            transform: translateX(-50%);
            background: rgba(0, 0, 0, 0.8);
            color: white;
            padding: 1rem 2rem;
            border-radius: 8px;
            z-index: 10000;
            backdrop-filter: blur(20px);
            animation: toastSlideIn 0.3s ease;
        `;
        toast.textContent = message;

        document.body.appendChild(toast);

        setTimeout(() => {
            toast.style.animation = 'toastSlideOut 0.3s ease forwards';
            setTimeout(() => toast.remove(), 300);
        }, duration);
    }
}

// Utility functions
const MovieDetailsUtils = {
    // Format date nicely
    formatDate(dateString) {
        const options = {
            year: 'numeric',
            month: 'long',
            day: 'numeric'
        };
        return new Date(dateString).toLocaleDateString('en-US', options);
    },

    // Format showtime nicely
    formatShowtime(dateTimeString) {
        const date = new Date(dateTimeString);
        const dateOptions = {
            weekday: 'long',
            month: 'short',
            day: 'numeric'
        };
        const timeOptions = {
            hour: '2-digit',
            minute: '2-digit'
        };

        return {
            date: date.toLocaleDateString('en-US', dateOptions),
            time: date.toLocaleTimeString('en-US', timeOptions)
        };
    },

    // Truncate text with ellipsis
    truncateText(text, maxLength) {
        if (text.length <= maxLength) return text;
        return text.substr(0, maxLength).replace(/\s+\S*$/, '') + '...';
    }
};

// Initialize when DOM is ready
document.addEventListener('DOMContentLoaded', () => {
    window.movieDetailsManager = new MovieDetailsManager();

    // Add additional CSS animations
    const style = document.createElement('style');
    style.textContent = `
        @keyframes ripple {
            to {
                transform: scale(2);
                opacity: 0;
            }
        }
        
        @keyframes toastSlideIn {
            from {
                opacity: 0;
                transform: translateX(-50%) translateY(100px);
            }
            to {
                opacity: 1;
                transform: translateX(-50%) translateY(0);
            }
        }
        
        @keyframes toastSlideOut {
            from {
                opacity: 1;
                transform: translateX(-50%) translateY(0);
            }
            to {
                opacity: 0;
                transform: translateX(-50%) translateY(100px);
            }
        }
        
        .showtime-card.selected {
            animation: cardSelect 0.3s ease;
        }
        
        @keyframes cardSelect {
            0% { transform: scale(1); }
            50% { transform: scale(1.05); }
            100% { transform: scale(1); }
        }
        
        .cast-card.highlighted {
            z-index: 10;
        }
    `;
    document.head.appendChild(style);
});

// Export for potential external use
if (typeof module !== 'undefined' && module.exports) {
    module.exports = { MovieDetailsManager, MovieDetailsUtils };
}