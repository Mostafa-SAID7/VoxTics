// VoxTics - Main Public Site JavaScript
// Handles public-facing functionality

(function() {
    'use strict';

    // Wait for utilities to be loaded
    if (!window.VoxTicsUtils) {
        console.error('VoxTicsUtils not loaded. Please include voxtics-utils.js before this file.');
        return;
    }

    // Create API service instance
    const apiService = new VoxTicsUtils.ApiService();

    document.addEventListener('DOMContentLoaded', function() {
        initializeMainFeatures();
    });

    function initializeMainFeatures() {
        initializeSearchFilters();
        initializeWatchlist();
        initializeRatingSystem();
        initializeNotifications();
    }

    // Search and filter functionality
    function initializeSearchFilters() {
        const searchForm = document.querySelector('#movie-search-form');
        const filterButtons = document.querySelectorAll('.filter-btn');
        
        if (searchForm) {
            searchForm.addEventListener('submit', handleSearch);
        }

        filterButtons.forEach(btn => {
            btn.addEventListener('click', handleFilter);
        });
    }

    function handleSearch(e) {
        e.preventDefault();
        const formData = new FormData(e.target);
        const searchParams = new URLSearchParams(formData);
        
        // Update URL and reload content
        window.location.search = searchParams.toString();
    }

    function handleFilter(e) {
        const filterType = e.target.dataset.filter;
        const filterValue = e.target.dataset.value;
        
        // Update active filter state
        document.querySelectorAll('.filter-btn').forEach(btn => {
            btn.classList.remove('active');
        });
        e.target.classList.add('active');

        // Apply filter logic here
        applyFilter(filterType, filterValue);
    }

    function applyFilter(type, value) {
        // Implementation for filtering movies/content
        console.log(`Applying filter: ${type} = ${value}`);
    }

    // Watchlist functionality
    function initializeWatchlist() {
        const watchlistBtns = document.querySelectorAll('.watchlist-btn');
        
        watchlistBtns.forEach(btn => {
            btn.addEventListener('click', toggleWatchlist);
        });
    }

    async function toggleWatchlist(e) {
        e.preventDefault();
        const btn = e.currentTarget;
        const movieId = btn.dataset.movieId;

        VoxTicsUtils.showLoading(btn, 'Updating...');

        try {
            const data = await apiService.post('/Movies/ToggleWatchlist', { movieId: movieId });
            
            if (data.success) {
                updateWatchlistButton(btn, data.inWatchlist);
                VoxTicsUtils.notify(data.message, 'success');
            } else {
                VoxTicsUtils.notify(data.message || 'Error updating watchlist', 'error');
            }
        } catch (error) {
            console.error('Error:', error);
            VoxTicsUtils.notify('Error updating watchlist', 'error');
        } finally {
            VoxTicsUtils.hideLoading(btn);
        }
    }

    function updateWatchlistButton(btn, inWatchlist) {
        if (inWatchlist) {
            btn.classList.add('in-watchlist');
            btn.innerHTML = '<i class="bi bi-heart-fill"></i> In Watchlist';
        } else {
            btn.classList.remove('in-watchlist');
            btn.innerHTML = '<i class="bi bi-heart"></i> Add to Watchlist';
        }
    }

    // Rating system - using centralized StarRating class
    function initializeRatingSystem() {
        const ratingContainers = document.querySelectorAll('.rating-stars');
        
        ratingContainers.forEach(container => {
            const movieId = container.dataset.movieId;
            const currentRating = parseFloat(container.dataset.currentRating) || 0;
            const readonly = container.dataset.readonly === 'true';
            
            // Use centralized StarRating class
            new VoxTicsUtils.StarRating(container, {
                maxRating: 5,
                currentRating: currentRating,
                readonly: readonly,
                onRate: (rating) => submitRating(movieId, rating)
            });
        });
    }

    async function submitRating(movieId, rating) {
        try {
            const data = await apiService.post('/Movies/Rate', { movieId: movieId, rating: rating });
            
            if (data.success) {
                VoxTicsUtils.notify('Rating submitted successfully', 'success');
            } else {
                VoxTicsUtils.notify(data.message || 'Error submitting rating', 'error');
            }
        } catch (error) {
            console.error('Error:', error);
            VoxTicsUtils.notify('Error submitting rating', 'error');
        }
    }

    // Notification system
    function initializeNotifications() {
        // Auto-hide notifications after 5 seconds
        const notifications = document.querySelectorAll('.alert');
        notifications.forEach(notification => {
            setTimeout(() => {
                notification.style.opacity = '0';
                setTimeout(() => {
                    notification.remove();
                }, 300);
            }, 5000);
        });
    }

    // Export functions for global use
    window.VoxTicsMain = {
        showNotification: VoxTicsUtils.notify,
        updateWatchlistButton: updateWatchlistButton
    };

})();