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

    function initializeHallSelection() {
        const hallButtons = document.querySelectorAll('.hall-btn');

        hallButtons.forEach(btn => {
            btn.addEventListener('click', function() {
                selectHall(this);
            });
        });

        if (hallButtons.length > 0) {
            selectHall(hallButtons[0]);
        }
    }

    function selectHall(hallBtn) {
        const hallId = hallBtn.dataset.hallId;

        document.querySelectorAll('.hall-btn').forEach(btn => {
            btn.classList.remove('active');
        });
        hallBtn.classList.add('active');

        loadHallDetails(hallId);
        filterShowtimesByHall(hallId);
    }

    function loadHallDetails(hallId) {
        const hallDetailsContainer = document.querySelector('#hall-details');
        if (!hallDetailsContainer) return;

        VoxTicsUtils.showLoading(hallDetailsContainer, 'Loading hall details...');

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

        seatingChart.querySelectorAll('.seat').forEach(seat => {
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

    function initializeShowtimeFilters() {
        const dateFilter = document.querySelector('#date-filter');
        const timeFilter = document.querySelector('#time-filter');
        const movieFilter = document.querySelector('#movie-filter');

        if (dateFilter) dateFilter.addEventListener('change', applyShowtimeFilters);
        if (timeFilter) timeFilter.addEventListener('change', applyShowtimeFilters);
        if (movieFilter) movieFilter.addEventListener('change', applyShowtimeFilters);

        const prevDateBtn = document.querySelector('#prev-date-btn');
        const nextDateBtn = document.querySelector('#next-date-btn');

        if (prevDateBtn) prevDateBtn.addEventListener('click', () => navigateDate(-1));
        if (nextDateBtn) nextDateBtn.addEventListener('click', () => navigateDate(1));
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
        dateFilter.value = currentDate.toISOString().split('T')[0];
        applyShowtimeFilters();
    }

    function loadShowtimes(date, time, movieId, hallId) {
        const showtimesContainer = document.querySelector('#showtimes-container');
        const cinemaId = document.querySelector('[data-cinema-id]')?.dataset.cinemaId;

        if (!showtimesContainer || !cinemaId) return;

        VoxTicsUtils.showLoading(showtimesContainer, 'Loading showtimes...');

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
        document.querySelectorAll('.showtime-btn').forEach(btn => {
            btn.addEventListener('click', function() {
                window.location.href = `/Bookings/Create?showtimeId=${this.dataset.showtimeId}`;
            });
        });
    }

    function filterShowtimesByHall(hallId) {
        document.querySelectorAll('.showtime-item').forEach(item => {
            item.style.display = (hallId === 'all' || item.dataset.hallId === hallId) ? 'block' : 'none';
        });
    }

    function initializeFacilitiesInfo() {
        document.querySelectorAll('.facility-item').forEach(item => {
            item.addEventListener('click', function() {
                this.querySelector('.facility-info')?.classList.toggle('show');
            });
        });

        document.querySelectorAll('.facility-filter').forEach(filter => {
            filter.addEventListener('click', function() {
                highlightFacility(this.dataset.facility);
            });
        });
    }

    function highlightFacility(facilityType) {
        document.querySelectorAll('.facility-item').forEach(item => {
            item.classList.remove('highlighted');
        });

        const matching = document.querySelectorAll(`[data-facility-type="${facilityType}"]`);
        matching.forEach(f => f.classList.add('highlighted'));

        if (matching.length > 0) {
            matching[0].scrollIntoView({ behavior: 'smooth', block: 'center' });
        }
    }

    function initializeContactFeatures() {
        const callBtn = document.querySelector('#call-cinema-btn');
        const directionsBtn = document.querySelector('#directions-btn');
        const favoriteBtn = document.querySelector('#favorite-cinema-btn');

        if (callBtn) callBtn.addEventListener('click', handleCall);
        if (directionsBtn) directionsBtn.addEventListener('click', handleDirections);
        if (favoriteBtn) favoriteBtn.addEventListener('click', handleFavorite);
    }

    function handleCall(e) {
        CinemaShared.handleCall(e);
    }

    function handleDirections(e) {
        e.preventDefault();
        const address = e.target.dataset.address;
        if (address) {
            window.open(`https://www.google.com/maps/dir/?api=1&destination=${encodeURIComponent(address)}`, '_blank');
        }
    }

    function handleFavorite(e) {
        e.preventDefault();
        CinemaShared.toggleFavorite(e.currentTarget, updateFavoriteButton);
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

    function initializeImageGallery() {
        const galleryImages = document.querySelectorAll('.gallery-image');
        const mainImage = document.querySelector('#main-cinema-image');

        galleryImages.forEach(img => {
            img.addEventListener('click', function() {
                if (mainImage) {
                    mainImage.src = this.src;
                    mainImage.alt = this.alt;
                }
                galleryImages.forEach(thumb => thumb.classList.remove('active'));
                this.classList.add('active');
            });
        });

        const lightboxBtn = document.querySelector('#lightbox-btn');
        if (lightboxBtn) lightboxBtn.addEventListener('click', openLightbox);
    }

    function openLightbox() {
        const images = Array.from(document.querySelectorAll('.gallery-image')).map(img => ({
            src: img.src,
            alt: img.alt
        }));

        if (images.length === 0) return;

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

        function showImage(index) {
            lightboxModal.querySelector('.lightbox-image').src = images[index].src;
            lightboxModal.querySelector('.lightbox-image').alt = images[index].alt;
            lightboxModal.querySelector('.lightbox-counter').textContent = `${index + 1} / ${images.length}`;
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

        lightboxModal.querySelector('.lightbox-close').addEventListener('click', closeLightbox);
        lightboxModal.querySelector('.lightbox-next').addEventListener('click', nextImage);
        lightboxModal.querySelector('.lightbox-prev').addEventListener('click', prevImage);
        lightboxModal.addEventListener('click', function(e) {
            if (e.target === lightboxModal) closeLightbox();
        });

        document.addEventListener('keydown', function(e) {
            if (!lightboxModal.parentNode) return;
            if (e.key === 'ArrowRight') nextImage();
            else if (e.key === 'ArrowLeft') prevImage();
            else if (e.key === 'Escape') closeLightbox();
        });
    }

})();
