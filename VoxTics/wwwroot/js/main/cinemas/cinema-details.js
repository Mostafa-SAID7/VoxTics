// VoxTics - Cinema Details Page JavaScript
// Handles cinema details, hall information, and showtime listings

(function() {
    'use strict';

    document.addEventListener('DOMContentLoaded', function() {
        initializeCinemaDetails();
    });

    function initializeCinemaDetails() {
        initializeHallSelection();
        initializeShowtimeFilters();
        initializeFacilitiesInfo();
        initializeContactFeatures();
        initializeImageGallery();
    }

    // Hall selection functionality
    function initializeHallSelection() {
        const hallButtons = document.querySelectorAll('.hall-btn');
        const hallDetails = document.querySelector('#hall-details');
        
        hallButtons.forEach(btn => {
            btn.addEventListener('click', function() {
                selectHall(this);
            });
        });

        // Initialize with first hall if available
        if (hallButtons.length > 0) {
            selectHall(hallButtons[0]);
        }
    }

    function selectHall(hallBtn) {
        const hallId = hallBtn.dataset.hallId;
        
        // Update active hall button
        document.querySelectorAll('.hall-btn').forEach(btn => {
            btn.classList.remove('active');
        });
        hallBtn.classList.add('active');

        // Load hall details
        loadHallDetails(hallId);
        
        // Filter showtimes by hall
        filterShowtimesByHall(hallId);
    }

    function loadHallDetails(hallId) {
        const hallDetailsContainer = document.querySelector('#hall-details');
        if (!hallDetailsContainer) return;

        // Use centralized loading manager
        if (window.VoxTicsUtils) {
            VoxTicsUtils.showLoading(hallDetailsContainer, 'Loading hall details...');
        } else {
            hallDetailsContainer.innerHTML = '<div class="text-center p-4"><div class="spinner-border"></div></div>';
        }

        fetch(`/Cinemas/GetHallDetails/${hallId}`)
            .then(response => response.text())
            .then(html => {
                hallDetailsContainer.innerHTML = html;
                initializeSeatingChart();
            })
            .catch(error => {
                console.error('Error loading hall details:', error);
                hallDetailsContainer.innerHTML = '<div class="alert alert-danger">Error loading hall details</div>';
            });
    }

    function initializeSeatingChart() {
        const seatingChart = document.querySelector('#seating-chart');
        if (!seatingChart) return;

        const seats = seatingChart.querySelectorAll('.seat');
        seats.forEach(seat => {
            seat.addEventListener('click', function() {
                if (!this.classList.contains('occupied')) {
                    this.classList.toggle('selected');
                    updateSelectedSeatsInfo();
                }
            });
        });
    }

    function updateSelectedSeatsInfo() {
        const selectedSeats = document.querySelectorAll('.seat.selected');
        const selectedSeatsInfo = document.querySelector('#selected-seats-info');
        
        if (selectedSeatsInfo) {
            if (selectedSeats.length > 0) {
                const seatNumbers = Array.from(selectedSeats).map(seat => seat.dataset.seatNumber);
                selectedSeatsInfo.innerHTML = `Selected seats: ${seatNumbers.join(', ')}`;
                selectedSeatsInfo.style.display = 'block';
            } else {
                selectedSeatsInfo.style.display = 'none';
            }
        }
    }

    // Showtime filters
    function initializeShowtimeFilters() {
        const dateFilter = document.querySelector('#date-filter');
        const timeFilter = document.querySelector('#time-filter');
        const movieFilter = document.querySelector('#movie-filter');

        if (dateFilter) {
            dateFilter.addEventListener('change', applyShowtimeFilters);
        }
        if (timeFilter) {
            timeFilter.addEventListener('change', applyShowtimeFilters);
        }
        if (movieFilter) {
            movieFilter.addEventListener('change', applyShowtimeFilters);
        }

        // Date navigation buttons
        const prevDateBtn = document.querySelector('#prev-date-btn');
        const nextDateBtn = document.querySelector('#next-date-btn');
        
        if (prevDateBtn) {
            prevDateBtn.addEventListener('click', () => navigateDate(-1));
        }
        if (nextDateBtn) {
            nextDateBtn.addEventListener('click', () => navigateDate(1));
        }
    }

    function applyShowtimeFilters() {
        const selectedDate = document.querySelector('#date-filter')?.value;
        const selectedTime = document.querySelector('#time-filter')?.value;
        const selectedMovie = document.querySelector('#movie-filter')?.value;
        const selectedHall = document.querySelector('.hall-btn.active')?.dataset.hallId;

        loadShowtimes(selectedDate, selectedTime, selectedMovie, selectedHall);
    }

    function navigateDate(direction) {
        const dateFilter = document.querySelector('#date-filter');
        if (!dateFilter) return;

        const currentDate = new Date(dateFilter.value || new Date());
        currentDate.setDate(currentDate.getDate() + direction);
        
        const newDateString = currentDate.toISOString().split('T')[0];
        dateFilter.value = newDateString;
        
        applyShowtimeFilters();
    }

    function loadShowtimes(date, time, movieId, hallId) {
        const showtimesContainer = document.querySelector('#showtimes-container');
        const cinemaId = document.querySelector('[data-cinema-id]')?.dataset.cinemaId;
        
        if (!showtimesContainer || !cinemaId) return;

        // Use centralized loading manager
        if (window.VoxTicsUtils) {
            VoxTicsUtils.showLoading(showtimesContainer, 'Loading showtimes...');
        } else {
            showtimesContainer.innerHTML = '<div class="text-center p-4"><div class="spinner-border"></div></div>';
        }

        const params = new URLSearchParams({
            cinemaId: cinemaId,
            date: date || '',
            time: time || '',
            movieId: movieId || '',
            hallId: hallId || ''
        });

        fetch(`/Cinemas/GetShowtimes?${params}`)
            .then(response => response.text())
            .then(html => {
                showtimesContainer.innerHTML = html;
                initializeShowtimeButtons();
            })
            .catch(error => {
                console.error('Error loading showtimes:', error);
                showtimesContainer.innerHTML = '<div class="alert alert-danger">Error loading showtimes</div>';
            });
    }

    function initializeShowtimeButtons() {
        const showtimeButtons = document.querySelectorAll('.showtime-btn');
        
        showtimeButtons.forEach(btn => {
            btn.addEventListener('click', function() {
                const showtimeId = this.dataset.showtimeId;
                window.location.href = `/Bookings/Create?showtimeId=${showtimeId}`;
            });
        });
    }

    function filterShowtimesByHall(hallId) {
        const showtimeItems = document.querySelectorAll('.showtime-item');
        
        showtimeItems.forEach(item => {
            const itemHallId = item.dataset.hallId;
            if (hallId === 'all' || itemHallId === hallId) {
                item.style.display = 'block';
            } else {
                item.style.display = 'none';
            }
        });
    }

    // Facilities information
    function initializeFacilitiesInfo() {
        const facilityItems = document.querySelectorAll('.facility-item');
        
        facilityItems.forEach(item => {
            item.addEventListener('click', function() {
                const facilityInfo = this.querySelector('.facility-info');
                if (facilityInfo) {
                    facilityInfo.classList.toggle('show');
                }
            });
        });

        // Facility filter buttons
        const facilityFilters = document.querySelectorAll('.facility-filter');
        facilityFilters.forEach(filter => {
            filter.addEventListener('click', function() {
                const facilityType = this.dataset.facility;
                highlightFacility(facilityType);
            });
        });
    }

    function highlightFacility(facilityType) {
        // Remove previous highlights
        document.querySelectorAll('.facility-item').forEach(item => {
            item.classList.remove('highlighted');
        });

        // Highlight matching facilities
        const matchingFacilities = document.querySelectorAll(`[data-facility-type="${facilityType}"]`);
        matchingFacilities.forEach(facility => {
            facility.classList.add('highlighted');
        });

        // Auto-scroll to first matching facility
        if (matchingFacilities.length > 0) {
            matchingFacilities[0].scrollIntoView({ behavior: 'smooth', block: 'center' });
        }
    }

    // Contact features
    function initializeContactFeatures() {
        const callBtn = document.querySelector('#call-cinema-btn');
        const directionsBtn = document.querySelector('#directions-btn');
        const favoriteBtn = document.querySelector('#favorite-cinema-btn');

        if (callBtn) {
            callBtn.addEventListener('click', handleCall);
        }
        if (directionsBtn) {
            directionsBtn.addEventListener('click', handleDirections);
        }
        if (favoriteBtn) {
            favoriteBtn.addEventListener('click', handleFavorite);
        }
    }

    function handleCall(e) {
        e.preventDefault();
        const phone = e.target.dataset.phone;
        if (phone) {
            window.location.href = `tel:${phone}`;
        }
    }

    function handleDirections(e) {
        e.preventDefault();
        const address = e.target.dataset.address;
        if (address) {
            const mapsUrl = `https://www.google.com/maps/dir/?api=1&destination=${encodeURIComponent(address)}`;
            window.open(mapsUrl, '_blank');
        }
    }

    function handleFavorite(e) {
        e.preventDefault();
        const btn = e.currentTarget;
        const cinemaId = btn.dataset.cinemaId;

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
            btn.innerHTML = '<span class="spinner-border spinner-border-sm me-2"></span>Updating...';

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
                btn.innerHTML = originalHtml;
            })
            .finally(() => {
                btn.disabled = false;
            });
        }
    }

    function updateFavoriteButton(btn, isFavorite) {
        if (isFavorite) {
            btn.classList.add('favorited');
            btn.innerHTML = '<i class="bi bi-heart-fill me-2"></i>Remove from Favorites';
        } else {
            btn.classList.remove('favorited');
            btn.innerHTML = '<i class="bi bi-heart me-2"></i>Add to Favorites';
        }
    }

    // Image gallery
    function initializeImageGallery() {
        const galleryImages = document.querySelectorAll('.gallery-image');
        const mainImage = document.querySelector('#main-cinema-image');
        
        galleryImages.forEach(img => {
            img.addEventListener('click', function() {
                if (mainImage) {
                    mainImage.src = this.src;
                    mainImage.alt = this.alt;
                }
                
                // Update active thumbnail
                galleryImages.forEach(thumb => thumb.classList.remove('active'));
                this.classList.add('active');
            });
        });

        // Lightbox functionality
        const lightboxBtn = document.querySelector('#lightbox-btn');
        if (lightboxBtn) {
            lightboxBtn.addEventListener('click', openLightbox);
        }
    }

    function openLightbox() {
        const images = Array.from(document.querySelectorAll('.gallery-image')).map(img => ({
            src: img.src,
            alt: img.alt
        }));
        
        if (images.length === 0) return;

        // Create lightbox modal
        const lightboxModal = document.createElement('div');
        lightboxModal.className = 'lightbox-modal';
        lightboxModal.innerHTML = `
            <div class="lightbox-content">
                <button class="lightbox-close">&times;</button>
                <button class="lightbox-prev">&#10094;</button>
                <img class="lightbox-image" src="${images[0].src}" alt="${images[0].alt}">
                <button class="lightbox-next">&#10095;</button>
                <div class="lightbox-counter">1 / ${images.length}</div>
            </div>
        `;
        
        document.body.appendChild(lightboxModal);
        
        let currentIndex = 0;
        
        // Navigation functions
        function showImage(index) {
            const img = lightboxModal.querySelector('.lightbox-image');
            const counter = lightboxModal.querySelector('.lightbox-counter');
            
            img.src = images[index].src;
            img.alt = images[index].alt;
            counter.textContent = `${index + 1} / ${images.length}`;
        }
        
        function nextImage() {
            currentIndex = (currentIndex + 1) % images.length;
            showImage(currentIndex);
        }
        
        function prevImage() {
            currentIndex = (currentIndex - 1 + images.length) % images.length;
            showImage(currentIndex);
        }
        
        function closeLightbox() {
            document.body.removeChild(lightboxModal);
        }
        
        // Event listeners
        lightboxModal.querySelector('.lightbox-close').addEventListener('click', closeLightbox);
        lightboxModal.querySelector('.lightbox-next').addEventListener('click', nextImage);
        lightboxModal.querySelector('.lightbox-prev').addEventListener('click', prevImage);
        lightboxModal.addEventListener('click', function(e) {
            if (e.target === lightboxModal) {
                closeLightbox();
            }
        });
        
        // Keyboard navigation
        document.addEventListener('keydown', function(e) {
            if (lightboxModal.parentNode) {
                switch(e.key) {
                    case 'ArrowRight':
                        nextImage();
                        break;
                    case 'ArrowLeft':
                        prevImage();
                        break;
                    case 'Escape':
                        closeLightbox();
                        break;
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

})();