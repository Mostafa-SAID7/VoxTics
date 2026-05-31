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
        loadViewMode();
        initializeViewModeToggle();
    }

    function initializeMovieFilters() {
        const categoryFilter = document.querySelector('#category-filter');
        const genreFilter = document.querySelector('#genre-filter');
        const sortFilter = document.querySelector('#sort-filter');
        const yearFilter = document.querySelector('#year-filter');

        if (categoryFilter) categoryFilter.addEventListener('change', applyFilters);
        if (genreFilter) genreFilter.addEventListener('change', applyFilters);
        if (sortFilter) sortFilter.addEventListener('change', applyFilters);
        if (yearFilter) yearFilter.addEventListener('change', applyFilters);

        document.querySelectorAll('.movie-filter-btn').forEach(btn => {
            btn.addEventListener('click', handleQuickFilter);
        });
    }

    function handleQuickFilter(e) {
        e.preventDefault();
        document.querySelectorAll('.movie-filter-btn').forEach(btn => btn.classList.remove('active'));
        e.target.classList.add('active');
        applyQuickFilter(e.target.dataset.filter, e.target.dataset.value);
    }

    function applyQuickFilter(type, value) {
        VoxTicsUtils.applyUrlFilter(type, value, true);
    }

    function applyFilters() {
        document.querySelector('#movie-filters-form')?.submit();
    }

    function initializeMovieSearch() {
        const searchInput = document.querySelector('#movie-search');
        const searchBtn = document.querySelector('#search-btn');
        const clearBtn = document.querySelector('#clear-search');

        if (searchInput) {
            const debouncedSearch = VoxTicsUtils.debounce((value) => performSearch(value), 500);
            searchInput.addEventListener('input', function() {
                debouncedSearch(this.value);
            });
        }

        if (searchBtn) {
            searchBtn.addEventListener('click', function() {
                performSearch(searchInput.value);
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
        url.searchParams.delete('page');
        window.location.href = url.toString();
    }

    function initializeMovieGrid() {
        document.querySelectorAll('.movie-card').forEach(card => {
            card.addEventListener('mouseenter', function() { this.classList.add('hover'); });
            card.addEventListener('mouseleave', function() { this.classList.remove('hover'); });

            card.querySelector('.watchlist-btn')?.addEventListener('click', handleWatchlistToggle);
            card.querySelector('.quick-view-btn')?.addEventListener('click', handleQuickView);
        });
    }

    function handleWatchlistToggle(e) {
        e.preventDefault();
        e.stopPropagation();
        const btn = e.currentTarget;
        const movieId = btn.dataset.movieId;

        if (window.VoxTicsMain?.toggleWatchlist) {
            window.VoxTicsMain.toggleWatchlist(btn, movieId);
        }
    }

    function handleQuickView(e) {
        e.preventDefault();
        e.stopPropagation();
        loadQuickView(e.currentTarget.dataset.movieId);
    }

    function loadQuickView(movieId) {
        const modal = document.querySelector('#quick-view-modal');
        if (!modal) return;
        const modalBody = modal.querySelector('.modal-body');

        VoxTicsUtils.showLoading(modalBody, 'Loading movie details...');
        new bootstrap.Modal(modal).show();

        new VoxTicsUtils.ApiService()
            .get(`/Movies/QuickView/${movieId}`)
            .then(html => {
                modalBody.innerHTML = html;
                initializeQuickViewFeatures();
            })
            .catch(error => {
                console.error('Error loading quick view:', error);
                modalBody.innerHTML = '<div class="alert alert-danger">Error loading movie details</div>';
            });
    }

    function initializeQuickViewFeatures() {
        const modal = document.querySelector('#quick-view-modal');

        modal?.querySelector('.watchlist-btn')?.addEventListener('click', handleWatchlistToggle);

        const bookingBtn = modal?.querySelector('.booking-btn');
        if (bookingBtn) {
            bookingBtn.addEventListener('click', function() {
                window.location.href = `/Movies/Details/${this.dataset.movieId}#showtimes`;
            });
        }
    }

    function initializePagination() {
        document.querySelectorAll('.pagination .page-link').forEach(link => {
            link.addEventListener('click', function(e) {
                if (this.classList.contains('disabled')) {
                    e.preventDefault();
                    return;
                }
                this.innerHTML = '<span class="spinner-border spinner-border-sm"></span>';
            });
        });
    }

    function initializeViewModeToggle() {
        document.querySelector('#grid-view-btn')?.addEventListener('click', () => setViewMode('grid'));
        document.querySelector('#list-view-btn')?.addEventListener('click', () => setViewMode('list'));
    }

    function setViewMode(mode) {
        const movieContainer = document.querySelector('#movies-container');
        const gridBtn = document.querySelector('#grid-view-btn');
        const listBtn = document.querySelector('#list-view-btn');

        if (mode === 'grid') {
            movieContainer?.classList.remove('list-view');
            movieContainer?.classList.add('grid-view');
            gridBtn?.classList.add('active');
            listBtn?.classList.remove('active');
        } else {
            movieContainer?.classList.remove('grid-view');
            movieContainer?.classList.add('list-view');
            listBtn?.classList.add('active');
            gridBtn?.classList.remove('active');
        }

        VoxTicsUtils.LocalStorageManager.set('movieViewMode', mode);
    }

    function loadViewMode() {
        setViewMode(VoxTicsUtils.LocalStorageManager.get('movieViewMode', 'grid'));
    }

})();
