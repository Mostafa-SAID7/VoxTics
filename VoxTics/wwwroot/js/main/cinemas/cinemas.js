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

    // Cinema filtering functionality
    function initializeCinemaFilters() {
        const locationFilter = document.querySelector('#location-filter');
        const facilitiesFilter = document.querySelector('#facilities-filter');
        const sortFilter = document.querySelector('#sort-filter');

        if (locationFilter) {
            locationFilter.addEventListener('change', applyFilters);
        }
        if (facilitiesFilter) {
            facilitiesFilter.addEventListener('change', applyFilters);
        }
        if (sortFilter) {
            sortFilter.addEventListener('change', applyFilters);
        }

        // Quick filter buttons
        const filterBtns = document.querySelectorAll('.cinema-filter-btn');
        filterBtns.forEach(btn => {
            btn.addEventListener('click', handleQuickFilter);
        });
    }

    function handleQuickFilter(e) {
        e.preventDefault();
        const filterType = e.target.dataset.filter;
        const filterValue = e.target.dataset.value;

        // Update active state
        document.querySelectorAll('.cinema-filter-btn').forEach(btn => {
            btn.classList.remove('active');
        });
        e.target.classList.add('active');

        // Apply filter
        applyQuickFilter(filterType, filterValue);
    }

    function applyQuickFilter(type, value) {
        const url = new URL(window.location);
        url.searchParams.set(type, value);
        window.location.href = url.toString();
    }

    function applyFilters() {
        const form = document.querySelector('#cinema-filters-form');
        if (form) {
            form.submit();
        }
    }

    // Location features
    function initializeLocationFeatures() {
        const nearMeBtn = document.querySelector('#find-near-me-btn');
        const locationInput = document.querySelector('#location-input');
        const searchLocationBtn = document.querySelector('#search-location-btn');

        if (nearMeBtn) {
            nearMeBtn.addEventListener('click', findNearestCinemas);
        }

        if (searchLocationBtn) {
            searchLocationBtn.addEventListener('click', searchByLocation);
        }

        if (locationInput) {
            locationInput.addEventListener('keypress', function(e) {
                if (e.key === 'Enter') {
                    searchByLocation();
                }
            });
        }
    }

    function findNearestCinemas() {
        const nearMeBtn = document.querySelector('#find-near-me-btn');
        
        if (!navigator.geolocation) {
            showNotification('Geolocation is not supported by this browser', 'error');
            return;
        }

        // Use centralized loading manager
        if (window.VoxTicsUtils) {
            VoxTicsUtils.showLoading(nearMeBtn, 'Finding...');
        } else {
            nearMeBtn.disabled = true;
            nearMeBtn.innerHTML = '<span class="spinner-border spinner-border-sm me-2"></span>Finding...';
        }

        navigator.geolocation.getCurrentPosition(
            function(position) {
                const latitude = position.coords.latitude;
                const longitude = position.coords.longitude;
                
                // Redirect with location parameters
                const url = new URL(window.location);
                url.searchParams.set('lat', latitude);
                url.searchParams.set('lng', longitude);
                url.searchParams.set('sortBy', 'distance');
                window.location.href = url.toString();
            },
            function(error) {
                console.error('Geolocation error:', error);
                showNotification('Unable to get your location. Please try again.', 'error');
                
                // Reset button
                if (window.VoxTicsUtils) {
                    VoxTicsUtils.hideLoading(nearMeBtn);
                } else {
                    nearMeBtn.disabled = false;
                    nearMeBtn.innerHTML = '<i class="bi bi-geo-alt"></i> Find Near Me';
                }
            },
            {
                enableHighAccuracy: true,
                timeout: 10000,
                maximumAge: 300000 // 5 minutes
            }
        );
    }

    function searchByLocation() {
        const locationInput = document.querySelector('#location-input');
        const location = locationInput.value.trim();
        
        if (!location) {
            showNotification('Please enter a location', 'warning');
            return;
        }

        // Use centralized loading manager
        const searchBtn = document.querySelector('#search-location-btn');
        if (window.VoxTicsUtils) {
            VoxTicsUtils.showLoading(searchBtn, 'Searching...');
        } else {
            searchBtn.disabled = true;
            searchBtn.innerHTML = '<span class="spinner-border spinner-border-sm"></span>';
        }

        // Geocode the location
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
                showNotification('Unable to find that location. Please try again.', 'error');
                
                // Reset button
                if (window.VoxTicsUtils) {
                    VoxTicsUtils.hideLoading(searchBtn);
                } else {
                    searchBtn.disabled = false;
                    searchBtn.innerHTML = '<i class="bi bi-search"></i>';
                }
            });
    }

    function geocodeLocation(location) {
        // This would typically use a geocoding service like Google Maps API
        // For now, we'll simulate with a simple implementation
        return new Promise((resolve, reject) => {
            // In a real implementation, you would call a geocoding API
            // For demo purposes, we'll just redirect with the location name
            const url = new URL(window.location);
            url.searchParams.set('location', location);
            window.location.href = url.toString();
        });
    }

    // Cinema cards functionality
    function initializeCinemaCards() {
        const cinemaCards = document.querySelectorAll('.cinema-card');
        
        cinemaCards.forEach(card => {
            // Add hover effects
            card.addEventListener('mouseenter', function() {
                this.classList.add('hover');
            });
            
            card.addEventListener('mouseleave', function() {
                this.classList.remove('hover');
            });

            // Initialize direction buttons
            const directionsBtn = card.querySelector('.directions-btn');
            if (directionsBtn) {
                directionsBtn.addEventListener('click', handleDirections);
            }

            // Initialize call buttons
            const callBtn = card.querySelector('.call-btn');
            if (callBtn) {
                callBtn.addEventListener('click', handleCall);
            }

            // Initialize favorite buttons
            const favoriteBtn = card.querySelector('.favorite-btn');
            if (favoriteBtn) {
                favoriteBtn.addEventListener('click', handleFavorite);
            }
        });
    }

    function handleDirections(e) {
        e.preventDefault();
        e.stopPropagation();
        
        const cinemaCard = e.target.closest('.cinema-card');
        const address = cinemaCard.dataset.address;
        const cinemaName = cinemaCard.dataset.name;
        
        if (address) {
            const mapsUrl = `https://www.google.com/maps/dir/?api=1&destination=${encodeURIComponent(address)}`;
            window.open(mapsUrl, '_blank');
        } else {
            showNotification('Address not available', 'warning');
        }
    }

    function handleCall(e) {
        e.preventDefault();
        e.stopPropagation();
        
        const phone = e.target.dataset.phone;
        if (phone) {
            window.location.href = `tel:${phone}`;
        }
    }

    function handleFavorite(e) {
        e.preventDefault();
        e.stopPropagation();
        
        const btn = e.currentTarget;
        const cinemaId = btn.dataset.cinemaId;
        const isFavorite = btn.classList.contains('favorited');

        // Use centralized loading and API service
        if (window.VoxTicsUtils) {
            VoxTicsUtils.showLoading(btn, 'Updating...');
            
            const apiService = new VoxTicsUtils.ApiService();
            apiService.post('/Cinemas/ToggleFavorite', { cinemaId: cinemaId })
                .then(data => {
                    if (data.success) {
                        updateFavoriteButton(btn, data.isFavorite);
                        showNotification(data.message, 'success');
                    } else {
                        showNotification(data.message || 'Error updating favorite', 'error');
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                    showNotification('Error updating favorite', 'error');
                })
                .finally(() => {
                    VoxTicsUtils.hideLoading(btn);
                });
        } else {
            // Fallback implementation
            btn.disabled = true;
            const originalHtml = btn.innerHTML;
            btn.innerHTML = '<i class="bi bi-hourglass-split"></i>';

            fetch('/Cinemas/ToggleFavorite', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
                },
                body: JSON.stringify({ cinemaId: cinemaId })
            })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    updateFavoriteButton(btn, data.isFavorite);
                    showNotification(data.message, 'success');
                } else {
                    showNotification(data.message || 'Error updating favorite', 'error');
                }
            })
            .catch(error => {
                console.error('Error:', error);
                showNotification('Error updating favorite', 'error');
            })
            .finally(() => {
                btn.disabled = false;
            });
        }
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

    // Map integration
    function initializeMapIntegration() {
        const mapContainer = document.querySelector('#cinemas-map');
        const toggleMapBtn = document.querySelector('#toggle-map-btn');
        
        if (toggleMapBtn) {
            toggleMapBtn.addEventListener('click', toggleMap);
        }

        // Initialize map if container exists
        if (mapContainer && window.google) {
            initializeGoogleMap();
        }
    }

    function toggleMap() {
        const mapContainer = document.querySelector('#cinemas-map');
        const toggleBtn = document.querySelector('#toggle-map-btn');
        
        if (mapContainer.style.display === 'none' || !mapContainer.style.display) {
            mapContainer.style.display = 'block';
            toggleBtn.innerHTML = '<i class="bi bi-list"></i> Show List';
            
            // Initialize map if not already done
            if (!window.cinemasMap) {
                initializeGoogleMap();
            }
        } else {
            mapContainer.style.display = 'none';
            toggleBtn.innerHTML = '<i class="bi bi-map"></i> Show Map';
        }
    }

    function initializeGoogleMap() {
        // This would integrate with Google Maps API
        // For now, we'll create a placeholder
        const mapContainer = document.querySelector('#cinemas-map');
        if (!mapContainer) return;

        // In a real implementation, you would:
        // 1. Load Google Maps API
        // 2. Create map instance
        // 3. Add markers for each cinema
        // 4. Handle marker clicks to show cinema details
        
        mapContainer.innerHTML = `
            <div class="map-placeholder text-center p-5">
                <i class="bi bi-map display-1 text-muted"></i>
                <p class="text-muted">Map integration would be implemented here</p>
            </div>
        `;
    }

    // Distance calculation (if coordinates are available)
    function calculateDistance(lat1, lon1, lat2, lon2) {
        const R = 6371; // Radius of the Earth in kilometers
        const dLat = (lat2 - lat1) * Math.PI / 180;
        const dLon = (lon2 - lon1) * Math.PI / 180;
        const a = Math.sin(dLat/2) * Math.sin(dLat/2) +
                  Math.cos(lat1 * Math.PI / 180) * Math.cos(lat2 * Math.PI / 180) *
                  Math.sin(dLon/2) * Math.sin(dLon/2);
        const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
        const distance = R * c;
        return distance;
    }

    function updateDistances(userLat, userLng) {
        const cinemaCards = document.querySelectorAll('.cinema-card');
        
        cinemaCards.forEach(card => {
            const cinemaLat = parseFloat(card.dataset.latitude);
            const cinemaLng = parseFloat(card.dataset.longitude);
            
            if (cinemaLat && cinemaLng) {
                const distance = calculateDistance(userLat, userLng, cinemaLat, cinemaLng);
                const distanceElement = card.querySelector('.distance');
                
                if (distanceElement) {
                    distanceElement.textContent = `${distance.toFixed(1)} km away`;
                    distanceElement.style.display = 'block';
                }
            }
        });
    }

    // Use centralized notification system
    function showNotification(message, type = 'info') {
        if (window.VoxTicsUtils) {
            VoxTicsUtils.notify(message, type);
        } else if (window.VoxTicsMain && window.VoxTicsMain.showNotification) {
            window.VoxTicsMain.showNotification(message, type);
        } else {
            console.log(`NOTIFICATION (${type}): ${message}`);
        }
    }

    // Export functions for global use
    window.VoxTicsCinemas = {
        updateDistances: updateDistances,
        calculateDistance: calculateDistance
    };

})();