// VoxTics - Cinemas Index Page JavaScript
// Handles cinema listing, filtering, and location features

(function() {
    'use strict';

    document.addEventListener('DOMContentLoaded', function() {
        initializeCinemasPage();
    });

    function initializeCinemasPage() {
        initializeCinemaFilters();
        initializeLocationFeatures();
        initializeCinemaCards();
        initializeMapIntegration();
    }

    function initializeCinemaFilters() {
        const locationFilter = document.querySelector('#location-filter');
        const facilitiesFilter = document.querySelector('#facilities-filter');
        const sortFilter = document.querySelector('#sort-filter');

        if (locationFilter) locationFilter.addEventListener('change', applyFilters);
        if (facilitiesFilter) facilitiesFilter.addEventListener('change', applyFilters);
        if (sortFilter) sortFilter.addEventListener('change', applyFilters);

        document.querySelectorAll('.cinema-filter-btn').forEach(btn => {
            btn.addEventListener('click', handleQuickFilter);
        });
    }

    function handleQuickFilter(e) {
        e.preventDefault();
        document.querySelectorAll('.cinema-filter-btn').forEach(btn => btn.classList.remove('active'));
        e.target.classList.add('active');
        applyQuickFilter(e.target.dataset.filter, e.target.dataset.value);
    }

    function applyQuickFilter(type, value) {
        const url = new URL(window.location);
        url.searchParams.set(type, value);
        window.location.href = url.toString();
    }

    function applyFilters() {
        document.querySelector('#cinema-filters-form')?.submit();
    }

    function initializeLocationFeatures() {
        const nearMeBtn = document.querySelector('#find-near-me-btn');
        const locationInput = document.querySelector('#location-input');
        const searchLocationBtn = document.querySelector('#search-location-btn');

        if (nearMeBtn) nearMeBtn.addEventListener('click', findNearestCinemas);
        if (searchLocationBtn) searchLocationBtn.addEventListener('click', searchByLocation);
        if (locationInput) {
            locationInput.addEventListener('keypress', function(e) {
                if (e.key === 'Enter') searchByLocation();
            });
        }
    }

    function findNearestCinemas() {
        const nearMeBtn = document.querySelector('#find-near-me-btn');

        if (!navigator.geolocation) {
            VoxTicsUtils.notify('Geolocation is not supported by this browser', 'error');
            return;
        }

        VoxTicsUtils.showLoading(nearMeBtn, 'Finding...');

        navigator.geolocation.getCurrentPosition(
            function(position) {
                const url = new URL(window.location);
                url.searchParams.set('lat', position.coords.latitude);
                url.searchParams.set('lng', position.coords.longitude);
                url.searchParams.set('sortBy', 'distance');
                window.location.href = url.toString();
            },
            function(error) {
                console.error('Geolocation error:', error);
                VoxTicsUtils.notify('Unable to get your location. Please try again.', 'error');
                VoxTicsUtils.hideLoading(nearMeBtn);
            },
            { enableHighAccuracy: true, timeout: 10000, maximumAge: 300000 }
        );
    }

    function searchByLocation() {
        const locationInput = document.querySelector('#location-input');
        const location = locationInput.value.trim();

        if (!location) {
            VoxTicsUtils.notify('Please enter a location', 'warning');
            return;
        }

        const searchBtn = document.querySelector('#search-location-btn');
        VoxTicsUtils.showLoading(searchBtn, 'Searching...');

        geocodeLocation(location)
            .then(coordinates => {
                const url = new URL(window.location);
                url.searchParams.set('lat', coordinates.lat);
                url.searchParams.set('lng', coordinates.lng);
                url.searchParams.set('location', location);
                url.searchParams.set('sortBy', 'distance');
                window.location.href = url.toString();
            })
            .catch(error => {
                console.error('Geocoding error:', error);
                VoxTicsUtils.notify('Unable to find that location. Please try again.', 'error');
                VoxTicsUtils.hideLoading(searchBtn);
            });
    }

    function geocodeLocation(location) {
        return new Promise((resolve, reject) => {
            const url = new URL(window.location);
            url.searchParams.set('location', location);
            window.location.href = url.toString();
        });
    }

    function initializeCinemaCards() {
        document.querySelectorAll('.cinema-card').forEach(card => {
            card.addEventListener('mouseenter', function() { this.classList.add('hover'); });
            card.addEventListener('mouseleave', function() { this.classList.remove('hover'); });

            card.querySelector('.directions-btn')?.addEventListener('click', handleDirections);
            card.querySelector('.call-btn')?.addEventListener('click', handleCall);
            card.querySelector('.favorite-btn')?.addEventListener('click', handleFavorite);
        });
    }

    function handleDirections(e) {
        e.preventDefault();
        e.stopPropagation();
        const card = e.target.closest('.cinema-card');
        const address = card?.dataset.address;
        if (address) {
            window.open(`https://www.google.com/maps/dir/?api=1&destination=${encodeURIComponent(address)}`, '_blank');
        } else {
            VoxTicsUtils.notify('Address not available', 'warning');
        }
    }

    function handleCall(e) {
        e.preventDefault();
        e.stopPropagation();
        const phone = e.target.dataset.phone;
        if (phone) window.location.href = `tel:${phone}`;
    }

    function handleFavorite(e) {
        e.preventDefault();
        e.stopPropagation();
        const btn = e.currentTarget;
        const cinemaId = btn.dataset.cinemaId;

        VoxTicsUtils.showLoading(btn, 'Updating...');

        new VoxTicsUtils.ApiService()
            .post('/Cinemas/ToggleFavorite', { cinemaId: cinemaId })
            .then(data => {
                if (data.success) {
                    updateFavoriteButton(btn, data.isFavorite);
                    VoxTicsUtils.notify(data.message, 'success');
                } else {
                    VoxTicsUtils.notify(data.message || 'Error updating favorite', 'error');
                }
            })
            .catch(error => {
                console.error('Error:', error);
                VoxTicsUtils.notify('Error updating favorite', 'error');
            })
            .finally(() => {
                VoxTicsUtils.hideLoading(btn);
            });
    }

    function updateFavoriteButton(btn, isFavorite) {
        if (isFavorite) {
            btn.classList.add('favorited');
            btn.innerHTML = '<i class="bi bi-heart-fill"></i>';
            btn.title = 'Remove from favorites';
        } else {
            btn.classList.remove('favorited');
            btn.innerHTML = '<i class="bi bi-heart"></i>';
            btn.title = 'Add to favorites';
        }
    }

    function initializeMapIntegration() {
        const mapContainer = document.querySelector('#cinemas-map');
        const toggleMapBtn = document.querySelector('#toggle-map-btn');

        if (toggleMapBtn) toggleMapBtn.addEventListener('click', toggleMap);
        if (mapContainer && window.google) initializeGoogleMap();
    }

    function toggleMap() {
        const mapContainer = document.querySelector('#cinemas-map');
        const toggleBtn = document.querySelector('#toggle-map-btn');

        if (mapContainer.style.display === 'none' || !mapContainer.style.display) {
            mapContainer.style.display = 'block';
            toggleBtn.innerHTML = '<i class="bi bi-list"></i> Show List';
            if (!window.cinemasMap) initializeGoogleMap();
        } else {
            mapContainer.style.display = 'none';
            toggleBtn.innerHTML = '<i class="bi bi-map"></i> Show Map';
        }
    }

    function initializeGoogleMap() {
        const mapContainer = document.querySelector('#cinemas-map');
        if (!mapContainer) return;

        mapContainer.innerHTML = `
            <div class="map-placeholder text-center p-5">
                <i class="bi bi-map display-1 text-muted"></i>
                <p class="text-muted">Map integration would be implemented here</p>
            </div>
        `;
    }

    function calculateDistance(lat1, lon1, lat2, lon2) {
        const R = 6371;
        const dLat = (lat2 - lat1) * Math.PI / 180;
        const dLon = (lon2 - lon1) * Math.PI / 180;
        const a = Math.sin(dLat/2) * Math.sin(dLat/2) +
                  Math.cos(lat1 * Math.PI / 180) * Math.cos(lat2 * Math.PI / 180) *
                  Math.sin(dLon/2) * Math.sin(dLon/2);
        return R * 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    }

    function updateDistances(userLat, userLng) {
        document.querySelectorAll('.cinema-card').forEach(card => {
            const lat = parseFloat(card.dataset.latitude);
            const lng = parseFloat(card.dataset.longitude);

            if (lat && lng) {
                const distanceEl = card.querySelector('.distance');
                if (distanceEl) {
                    distanceEl.textContent = `${calculateDistance(userLat, userLng, lat, lng).toFixed(1)} km away`;
                    distanceEl.style.display = 'block';
                }
            }
        });
    }

    window.VoxTicsCinemas = {
        updateDistances: updateDistances,
        calculateDistance: calculateDistance
    };

})();
