// VoxTics - Movies Index Page JavaScript
// Handles movie listing, filtering, and search functionality

(function() {
    'use strict';

    document.addEventListener('DOMContentLoaded', function() {
        initializeMoviesPage();
    });

    function initializeMoviesPage() {
        initializeMovieFilters();
        initializeMovieSearch();
        initializeMovieGrid();
        initializePagination();
    }

    // Movie filtering functionality
    function initializeMovieFilters() {
        const categoryFilter = document.querySelector('#category-filter');
        const genreFilter = document.querySelector('#genre-filter');
        const sortFilter = document.querySelector('#sort-filter');
        const yearFilter = document.querySelector('#year-filter');

        if (categoryFilter) {
            categoryFilter.addEventListener('change', applyFilters);
        }
        if (genreFilter) {
            genreFilter.addEventListener('change', applyFilters);
        }
        if (sortFilter) {
            sortFilter.addEventListener('change', applyFilters);
        }
        if (yearFilter) {
            yearFilter.addEventListener('change', applyFilters);
        }

        // Filter buttons
        const filterBtns = document.querySelectorAll('.movie-filter-btn');
        filterBtns.forEach(btn => {
            btn.addEventListener('click', handleQuickFilter);
        });
    }

    function handleQuickFilter(e) {
        e.preventDefault();
        const filterType = e.target.dataset.filter;
        const filterValue = e.target.dataset.value;

        // Update active state
        document.querySelectorAll('.movie-filter-btn').forEach(btn => {
            btn.classList.remove('active');
        });
        e.target.classList.add('active');

        // Apply filter
        applyQuickFilter(filterType, filterValue);
    }

    function applyQuickFilter(type, value) {
        const url = new URL(window.location);
        url.searchParams.set(type, value);
        url.searchParams.delete('page'); // Reset pagination
        window.location.href = url.toString();
    }

    function applyFilters() {
        const form = document.querySelector('#movie-filters-form');
        if (form) {
            form.submit();
        }
    }

    // Movie search functionality
    function initializeMovieSearch() {
        const searchInput = document.querySelector('#movie-search');
        const searchBtn = document.querySelector('#search-btn');
        const clearBtn = document.querySelector('#clear-search');

        if (searchInput) {
            // Use centralized debounce function if available
            const debouncedSearch = window.VoxTicsUtils 
                ? VoxTicsUtils.debounce((value) => performSearch(value), 500)
                : function(value) {
                    let searchTimeout;
                    clearTimeout(searchTimeout);
                    searchTimeout = setTimeout(() => performSearch(value), 500);
                };
            
            searchInput.addEventListener('input', function() {
                debouncedSearch(this.value);
            });
        }

        if (searchBtn) {
            searchBtn.addEventListener('click', function() {
                const searchTerm = searchInput.value;
                performSearch(searchTerm);
            });
        }

        if (clearBtn) {
            clearBtn.addEventListener('click', function() {
                searchInput.value = '';
                performSearch('');
            });
        }
    }

    function performSearch(searchTerm) {
        const url = new URL(window.location);
        if (searchTerm.trim()) {
            url.searchParams.set('search', searchTerm);
        } else {
            url.searchParams.delete('search');
        }
        url.searchParams.delete('page'); // Reset pagination
        window.location.href = url.toString();
    }

    // Movie grid functionality
    function initializeMovieGrid() {
        const movieCards = document.querySelectorAll('.movie-card');
        
        movieCards.forEach(card => {
            // Add hover effects
            card.addEventListener('mouseenter', function() {
                this.classList.add('hover');
            });
            
            card.addEventListener('mouseleave', function() {
                this.classList.remove('hover');
            });

            // Initialize watchlist buttons on cards
            const watchlistBtn = card.querySelector('.watchlist-btn');
            if (watchlistBtn) {
                watchlistBtn.addEventListener('click', handleWatchlistToggle);
            }

            // Initialize quick view buttons
            const quickViewBtn = card.querySelector('.quick-view-btn');
            if (quickViewBtn) {
                quickViewBtn.addEventListener('click', handleQuickView);
            }
        });
    }

    function handleWatchlistToggle(e) {
        e.preventDefault();
        e.stopPropagation();
        
        const btn = e.currentTarget;
        const movieId = btn.dataset.movieId;
        
        // Use the main watchlist functionality
        if (window.VoxTicsMain && window.VoxTicsMain.toggleWatchlist) {
            window.VoxTicsMain.toggleWatchlist(btn, movieId);
        }
    }

    function handleQuickView(e) {
        e.preventDefault();
        e.stopPropagation();
        
        const movieId = e.currentTarget.dataset.movieId;
        loadQuickView(movieId);
    }

    function loadQuickView(movieId) {
        // Show loading modal
        const modal = document.querySelector('#quick-view-modal');
        const modalBody = modal.querySelector('.modal-body');
        
        // Use centralized loading manager
        if (window.VoxTicsUtils) {
            VoxTicsUtils.showLoading(modalBody, 'Loading movie details...');
        } else {
            modalBody.innerHTML = '<div class="text-center"><div class="spinner-border" role="status"></div></div>';
        }
        
        const bsModal = new bootstrap.Modal(modal);
        bsModal.show();

        // Load movie details using centralized API service
        if (window.VoxTicsUtils) {
            const apiService = new VoxTicsUtils.ApiService();
            apiService.get(`/Movies/QuickView/${movieId}`)
                .then(html => {
                    modalBody.innerHTML = html;
                    initializeQuickViewFeatures();
                })
                .catch(error => {
                    console.error('Error loading quick view:', error);
                    modalBody.innerHTML = '<div class="alert alert-danger">Error loading movie details</div>';
                });
        } else {
            // Fallback implementation
            fetch(`/Movies/QuickView/${movieId}`)
                .then(response => response.text())
                .then(html => {
                    modalBody.innerHTML = html;
                    initializeQuickViewFeatures();
                })
                .catch(error => {
                    console.error('Error loading quick view:', error);
                    modalBody.innerHTML = '<div class="alert alert-danger">Error loading movie details</div>';
                });
        }
    }

    function initializeQuickViewFeatures() {
        // Initialize features within the quick view modal
        const modal = document.querySelector('#quick-view-modal');
        
        // Watchlist button in modal
        const watchlistBtn = modal.querySelector('.watchlist-btn');
        if (watchlistBtn) {
            watchlistBtn.addEventListener('click', handleWatchlistToggle);
        }

        // Booking button in modal
        const bookingBtn = modal.querySelector('.booking-btn');
        if (bookingBtn) {
            bookingBtn.addEventListener('click', function() {
                const movieId = this.dataset.movieId;
                window.location.href = `/Movies/Details/${movieId}#showtimes`;
            });
        }
    }

    // Pagination functionality
    function initializePagination() {
        const paginationLinks = document.querySelectorAll('.pagination .page-link');
        
        paginationLinks.forEach(link => {
            link.addEventListener('click', function(e) {
                if (this.classList.contains('disabled')) {
                    e.preventDefault();
                    return;
                }
                
                // Add loading state to clicked link
                this.innerHTML = '<span class="spinner-border spinner-border-sm"></span>';
            });
        });
    }

    // View mode toggle (grid/list)
    function initializeViewModeToggle() {
        const gridViewBtn = document.querySelector('#grid-view-btn');
        const listViewBtn = document.querySelector('#list-view-btn');
        const movieContainer = document.querySelector('#movies-container');

        if (gridViewBtn) {
            gridViewBtn.addEventListener('click', function() {
                setViewMode('grid');
            });
        }

        if (listViewBtn) {
            listViewBtn.addEventListener('click', function() {
                setViewMode('list');
            });
        }
    }

    function setViewMode(mode) {
        const movieContainer = document.querySelector('#movies-container');
        const gridBtn = document.querySelector('#grid-view-btn');
        const listBtn = document.querySelector('#list-view-btn');

        if (mode === 'grid') {
            movieContainer.classList.remove('list-view');
            movieContainer.classList.add('grid-view');
            gridBtn.classList.add('active');
            listBtn.classList.remove('active');
        } else {
            movieContainer.classList.remove('grid-view');
            movieContainer.classList.add('list-view');
            listBtn.classList.add('active');
            gridBtn.classList.remove('active');
        }

        // Save preference using centralized storage manager
        if (window.VoxTicsUtils) {
            VoxTicsUtils.LocalStorageManager.set('movieViewMode', mode);
        } else {
            localStorage.setItem('movieViewMode', mode);
        }
    }

    // Load saved view mode using centralized storage manager
    function loadViewMode() {
        let savedMode = 'grid';
        if (window.VoxTicsUtils) {
            savedMode = VoxTicsUtils.LocalStorageManager.get('movieViewMode', 'grid');
        } else {
            savedMode = localStorage.getItem('movieViewMode') || 'grid';
        }
        setViewMode(savedMode);
    }

    // Initialize view mode on page load
    loadViewMode();
    initializeViewModeToggle();

})();