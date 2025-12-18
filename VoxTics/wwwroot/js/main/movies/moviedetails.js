// VoxTics - Movie Details Page JavaScript
// Handles movie details functionality, showtimes, and booking

(function(window, document) {
    'use strict';

    // Wait for utilities to be loaded
    if (!window.VoxTicsUtils) {
        console.error('VoxTicsUtils not loaded. Please include voxtics-utils.js before this file.');
        return;
    }

    // Configuration object for better maintainability
    const CONFIG = {
        selectors: {
            mainImage: '#main-movie-image',
            thumbnails: '.movie-thumbnail',
            dateButtons: '.date-btn',
            cinemaButtons: '.cinema-btn',
            showtimeButtons: '.showtime-btn',
            bookingBtn: '#book-tickets-btn',
            reviewForm: '#review-form',
            trailerModal: '#trailer-modal',
            movieId: '[data-movie-id]',
            showtimesContainer: '#showtimes-container',
            reviewsContainer: '#reviews-container'
        },
        endpoints: {
            showtimes: '/Movies/GetShowtimes',
            reviews: '/Movies/GetReviews',
            submitReview: '/Movies/SubmitReview'
        },
        classes: {
            active: 'active',
            selected: 'selected',
            loading: 'loading',
            disabled: 'disabled'
        },
        timeouts: {
            debounce: 300,
            apiRequest: 10000
        },
        messages: {
            selectShowtime: 'Please select a showtime first',
            reviewSuccess: 'Review submitted successfully',
            reviewError: 'Error submitting review',
            loadingShowtimes: 'Loading showtimes...',
            loadingReviews: 'Loading reviews...',
            noMoreReviews: 'No more reviews to load',
            clipboardSuccess: 'Link copied to clipboard',
            clipboardError: 'Failed to copy link. Please copy manually.'
        }
    };

    // Cache DOM elements to avoid repeated queries
    const elements = {};

    function cacheElements() {
        Object.keys(CONFIG.selectors).forEach(key => {
            elements[key] = document.querySelector(CONFIG.selectors[key]);
        });
        elements.allThumbnails = document.querySelectorAll(CONFIG.selectors.thumbnails);
        elements.allDateButtons = document.querySelectorAll(CONFIG.selectors.dateButtons);
        elements.allCinemaButtons = document.querySelectorAll(CONFIG.selectors.cinemaButtons);
        elements.allShowtimeButtons = document.querySelectorAll(CONFIG.selectors.showtimeButtons);
    }

    document.addEventListener('DOMContentLoaded', function() {
        cacheElements();
        initializeMovieDetails();
    });

    // Module Manager for better organization
    class ModuleManager {
        constructor(elements, config) {
            this.elements = elements;
            this.config = config;
            this.modules = new Map();
            this.performanceMonitor = new VoxTicsUtils.PerformanceMonitor();
        }

        registerModule(name, ModuleClass) {
            try {
                this.performanceMonitor.start(`init-${name}`);
                const module = new ModuleClass(this.elements, this.config);
                module.init();
                this.modules.set(name, module);
                this.performanceMonitor.end(`init-${name}`);
                console.log(`✓ ${name} module initialized successfully`);
            } catch (error) {
                console.error(`✗ Failed to initialize ${name} module:`, error);
                // Continue with other modules even if one fails
            }
        }

        getModule(name) {
            return this.modules.get(name);
        }

        cleanup() {
            this.modules.forEach((module, name) => {
                if (typeof module.cleanup === 'function') {
                    try {
                        module.cleanup();
                    } catch (error) {
                        console.error(`Error cleaning up ${name} module:`, error);
                    }
                }
            });
            this.modules.clear();
            this.performanceMonitor.clear();
        }
    }

    function initializeMovieDetails() {
        const moduleManager = new ModuleManager(elements, CONFIG);
        
        // Register all modules
        moduleManager.registerModule('ImageGallery', ImageGalleryModule);
        moduleManager.registerModule('Showtimes', ShowtimesModule);
        moduleManager.registerModule('BookingFlow', BookingFlowModule);
        moduleManager.registerModule('Reviews', ReviewsModule);
        moduleManager.registerModule('Trailer', TrailerModule);
        moduleManager.registerModule('SocialSharing', SocialSharingModule);

        // Store module manager globally for potential cleanup
        window.VoxTicsMovieDetails.moduleManager = moduleManager;
    }

    // Image Gallery Module using ES6 Class
    class ImageGalleryModule {
        constructor(elements, config) {
            this.elements = elements;
            this.config = config;
            this.currentIndex = 0;
        }

        init() {
            if (!this.elements.mainImage || !this.elements.allThumbnails.length) return;
            
            this.bindEvents();
            this.setInitialState();
        }

        bindEvents() {
            this.elements.allThumbnails.forEach((thumb, index) => {
                thumb.addEventListener('click', () => this.selectImage(index));
            });
            
            document.addEventListener('keydown', (e) => this.handleKeyNavigation(e));
        }

        selectImage(index) {
            const thumb = this.elements.allThumbnails[index];
            if (!thumb) return;
            
            const newSrc = thumb.dataset.fullsize || thumb.src;
            
            // Update main image with error handling
            try {
                this.elements.mainImage.src = newSrc;
                this.elements.mainImage.alt = thumb.alt;
                this.updateActiveState(index);
                this.currentIndex = index;
            } catch (error) {
                console.error('Failed to update image:', error);
            }
        }

        updateActiveState(activeIndex) {
            this.elements.allThumbnails.forEach((thumb, index) => {
                thumb.classList.toggle(this.config.classes.active, index === activeIndex);
            });
        }

        handleKeyNavigation(e) {
            if (!['ArrowLeft', 'ArrowRight'].includes(e.key)) return;
            
            const direction = e.key === 'ArrowLeft' ? -1 : 1;
            const newIndex = this.getNextIndex(direction);
            this.selectImage(newIndex);
        }

        getNextIndex(direction) {
            const totalImages = this.elements.allThumbnails.length;
            let newIndex = this.currentIndex + direction;
            
            if (newIndex < 0) newIndex = totalImages - 1;
            if (newIndex >= totalImages) newIndex = 0;
            
            return newIndex;
        }

        setInitialState() {
            const activeThumb = document.querySelector('.movie-thumbnail.active');
            if (activeThumb) {
                const index = Array.from(this.elements.allThumbnails).indexOf(activeThumb);
                this.currentIndex = index >= 0 ? index : 0;
            }
        }
    }



    // Movie-specific API Service extending the base ApiService
    class MovieApiService extends VoxTicsUtils.ApiService {
        constructor(config) {
            super({ timeout: config.timeouts.apiRequest });
            this.config = config;
        }

        async fetchShowtimes(movieId, date) {
            return this.get(this.config.endpoints.showtimes, { movieId, date });
        }

        async fetchReviews(movieId, skip = 0) {
            return this.get(this.config.endpoints.reviews, { movieId, skip });
        }

        async submitReview(formData) {
            return this.post(this.config.endpoints.submitReview, formData);
        }
    }

    // Showtimes Module with proper error handling
    class ShowtimesModule {
        constructor(elements, config) {
            this.elements = elements;
            this.config = config;
            this.apiService = new MovieApiService(config);
        }

        init() {
            this.bindEvents();
            this.initializeDefaultDate();
        }

        bindEvents() {
            const dateButtons = document.querySelectorAll('.date-btn');
            const cinemaButtons = document.querySelectorAll('.cinema-btn');
            const showtimeButtons = document.querySelectorAll('.showtime-btn');

            dateButtons.forEach(btn => {
                btn.addEventListener('click', () => this.selectDate(btn));
            });

            cinemaButtons.forEach(btn => {
                btn.addEventListener('click', () => this.selectCinema(btn));
            });

            showtimeButtons.forEach(btn => {
                btn.addEventListener('click', () => this.selectShowtime(btn));
            });
        }

        initializeDefaultDate() {
            const firstDateBtn = document.querySelector('.date-btn');
            if (firstDateBtn) {
                this.selectDate(firstDateBtn);
            }
        }

        selectDate(dateBtn) {
            const selectedDate = dateBtn.dataset.date;
            
            document.querySelectorAll('.date-btn').forEach(btn => {
                btn.classList.remove('active');
            });
            dateBtn.classList.add('active');

            this.loadShowtimesForDate(selectedDate);
        }

        selectCinema(cinemaBtn) {
            const cinemaId = cinemaBtn.dataset.cinemaId;
            
            document.querySelectorAll('.cinema-btn').forEach(btn => {
                btn.classList.remove('active');
            });
            cinemaBtn.classList.add('active');

            this.filterShowtimesByCinema(cinemaId);
        }

        selectShowtime(showtimeBtn) {
            const showtimeId = showtimeBtn.dataset.showtimeId;
            
            document.querySelectorAll('.showtime-btn').forEach(btn => {
                btn.classList.remove('active');
            });
            showtimeBtn.classList.add('active');

            const bookingBtn = document.querySelector('#book-tickets-btn');
            if (bookingBtn) {
                bookingBtn.disabled = false;
                bookingBtn.dataset.showtimeId = showtimeId;
            }
        }

        async loadShowtimesForDate(date) {
            const movieId = document.querySelector('[data-movie-id]')?.dataset.movieId;
            const showtimesContainer = document.querySelector('#showtimes-container');
            
            if (!showtimesContainer || !movieId) return;

            try {
                VoxTicsUtils.showLoading(showtimesContainer, this.config.messages.loadingShowtimes);
                const html = await this.apiService.fetchShowtimes(movieId, date);
                showtimesContainer.innerHTML = html;
                this.reinitializeShowtimeButtons(showtimesContainer);
            } catch (error) {
                this.showErrorState(showtimesContainer, 'Failed to load showtimes. Please try again.');
            }
        }

        showErrorState(container, message) {
            container.innerHTML = `
                <div class="alert alert-danger" role="alert">
                    <i class="bi bi-exclamation-triangle me-2"></i>
                    ${message}
                </div>
            `;
        }

        reinitializeShowtimeButtons(container) {
            const showtimeButtons = container.querySelectorAll('.showtime-btn');
            showtimeButtons.forEach(btn => {
                btn.addEventListener('click', () => this.selectShowtime(btn));
            });
        }

        filterShowtimesByCinema(cinemaId) {
            const showtimeItems = document.querySelectorAll('.showtime-item');
            
            showtimeItems.forEach(item => {
                const itemCinemaId = item.dataset.cinemaId;
                if (cinemaId === 'all' || itemCinemaId === cinemaId) {
                    item.style.display = 'block';
                } else {
                    item.style.display = 'none';
                }
            });
        }
    }

    // Booking Flow Module
    class BookingFlowModule {
        constructor(elements, config) {
            this.elements = elements;
            this.config = config;
        }

        init() {
            this.bindEvents();
        }

        bindEvents() {
            const bookingBtn = document.querySelector('#book-tickets-btn');
            
            if (bookingBtn) {
                bookingBtn.addEventListener('click', (e) => {
                    e.preventDefault();
                    const showtimeId = bookingBtn.dataset.showtimeId;
                    if (showtimeId) {
                        this.redirectToBooking(showtimeId);
                    } else {
                        VoxTicsUtils.notify('Please select a showtime first', 'warning');
                    }
                });
            }

            const quickBookBtns = document.querySelectorAll('.quick-book-btn');
            quickBookBtns.forEach(btn => {
                btn.addEventListener('click', (e) => {
                    e.preventDefault();
                    const showtimeId = btn.dataset.showtimeId;
                    this.redirectToBooking(showtimeId);
                });
            });
        }

        redirectToBooking(showtimeId) {
            if (showtimeId) {
                window.location.href = `/Bookings/Create?showtimeId=${showtimeId}`;
            }
        }
    }

    // Reviews Module
    class ReviewsModule {
        constructor(elements, config) {
            this.elements = elements;
            this.config = config;
            this.apiService = new MovieApiService(config);
            this.starRating = null;
        }

        init() {
            this.initializeStarRating();
            this.bindEvents();
        }

        initializeStarRating() {
            const ratingContainer = document.querySelector('.rating-stars');
            if (ratingContainer) {
                this.starRating = new VoxTicsUtils.StarRating(ratingContainer, {
                    maxRating: 5,
                    currentRating: 0,
                    onRate: (rating) => {
                        const reviewRating = document.querySelector('#review-rating');
                        if (reviewRating) {
                            reviewRating.value = rating;
                        }
                    }
                });
            }
        }

        bindEvents() {
            const reviewForm = document.querySelector('#review-form');
            
            if (reviewForm) {
                reviewForm.addEventListener('submit', (e) => {
                    e.preventDefault();
                    this.submitReview();
                });
            }

            const loadMoreBtn = document.querySelector('#load-more-reviews');
            if (loadMoreBtn) {
                loadMoreBtn.addEventListener('click', () => this.loadMoreReviews());
            }
        }

        async submitReview() {
            const form = document.querySelector('#review-form');
            const formData = new FormData(form);
            const submitBtn = form.querySelector('button[type="submit"]');
            
            if (!submitBtn) return;

            VoxTicsUtils.showLoading(submitBtn, 'Submitting...');

            try {
                const data = await this.apiService.submitReview(formData);
                if (data.success) {
                    VoxTicsUtils.notify('Review submitted successfully', 'success');
                    form.reset();
                    if (this.starRating) {
                        this.starRating.setRating(0);
                    }
                } else {
                    VoxTicsUtils.notify(data.message || 'Error submitting review', 'error');
                }
            } catch (error) {
                console.error('Error:', error);
                VoxTicsUtils.notify('Error submitting review', 'error');
            } finally {
                VoxTicsUtils.hideLoading(submitBtn);
            }
        }

        async loadMoreReviews() {
            const movieId = document.querySelector('[data-movie-id]')?.dataset.movieId;
            const reviewsContainer = document.querySelector('#reviews-container');
            const loadMoreBtn = document.querySelector('#load-more-reviews');
            
            if (!movieId || !reviewsContainer || !loadMoreBtn) return;
            
            const currentCount = reviewsContainer.querySelectorAll('.review-item').length;

            VoxTicsUtils.showLoading(loadMoreBtn, 'Loading...');

            try {
                const html = await this.apiService.fetchReviews(movieId, currentCount);
                if (html.trim()) {
                    reviewsContainer.insertAdjacentHTML('beforeend', html);
                } else {
                    loadMoreBtn.style.display = 'none';
                    VoxTicsUtils.notify('No more reviews to load', 'info');
                }
            } catch (error) {
                console.error('Error loading reviews:', error);
                VoxTicsUtils.notify('Error loading reviews', 'error');
            } finally {
                VoxTicsUtils.hideLoading(loadMoreBtn);
            }
        }
    }

    // Trailer Module
    class TrailerModule {
        constructor(elements, config) {
            this.elements = elements;
            this.config = config;
        }

        init() {
            this.bindEvents();
        }

        bindEvents() {
            const trailerBtn = document.querySelector('#watch-trailer-btn');
            const trailerModal = document.querySelector('#trailer-modal');
            
            if (trailerBtn && trailerModal) {
                trailerBtn.addEventListener('click', (e) => {
                    e.preventDefault();
                    const trailerUrl = trailerBtn.dataset.trailerUrl;
                    this.loadTrailer(trailerUrl);
                });

                trailerModal.addEventListener('hidden.bs.modal', () => {
                    this.clearTrailer();
                });
            }
        }

        loadTrailer(trailerUrl) {
            const videoContainer = document.querySelector('#trailer-modal .video-container');
            
            if (trailerUrl && videoContainer) {
                const embedHtml = `
                    <div class="ratio ratio-16x9">
                        <iframe src="${trailerUrl}" 
                                allowfullscreen 
                                loading="lazy"
                                title="Movie Trailer">
                        </iframe>
                    </div>
                `;
                videoContainer.innerHTML = embedHtml;
            }
        }

        clearTrailer() {
            const videoContainer = document.querySelector('#trailer-modal .video-container');
            if (videoContainer) {
                videoContainer.innerHTML = '';
            }
        }
    }

    // Social Sharing Module
    class SocialSharingModule {
        constructor(elements, config) {
            this.elements = elements;
            this.config = config;
        }

        init() {
            this.bindEvents();
        }

        bindEvents() {
            const shareButtons = document.querySelectorAll('.share-btn');
            
            shareButtons.forEach(btn => {
                btn.addEventListener('click', (e) => {
                    e.preventDefault();
                    const platform = btn.dataset.platform;
                    VoxTicsUtils.shareOnSocial(platform, window.location.href, document.title);
                });
            });

            const copyLinkBtn = document.querySelector('#copy-link-btn');
            if (copyLinkBtn) {
                copyLinkBtn.addEventListener('click', () => {
                    VoxTicsUtils.copyToClipboard(window.location.href);
                });
            }
        }
    }







    // Expose modules for testing and external access
    window.VoxTicsMovieDetails = {
        ImageGalleryModule,
        ShowtimesModule,
        MovieApiService,
        ModuleManager
    };

})(window, document);