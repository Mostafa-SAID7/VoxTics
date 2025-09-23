    // Global variables
    let searchTimeout;

    // Initialize on page load
    document.addEventListener('DOMContentLoaded', function() {
        initializeAnimations();
    setupEventListeners();
    });

    function initializeAnimations() {
        // Stagger card animations
        const cards = document.querySelectorAll('.fade-in-card');
        cards.forEach((card, index) => {
        setTimeout(() => {
            card.style.opacity = '1';
            card.style.transform = 'translateY(0)';
        }, index * 100);
        });
    }

    function setupEventListeners() {
        // Enhanced search with debouncing
        document.getElementById('searchInput').addEventListener('input', function (e) {
            clearTimeout(searchTimeout);
            searchTimeout = setTimeout(() => {
                performSearch(e.target.value);
            }, 300);
        });

    // Add keyboard shortcuts
    document.addEventListener('keydown', function(e) {
            if (e.ctrlKey && e.key === 'k') {
        e.preventDefault();
    document.getElementById('searchInput').focus();
            }
        });
    }

    function performSearch(searchTerm) {
        const term = searchTerm.toLowerCase().trim();
    const movieCards = document.querySelectorAll('.movie-card');
    const movieListItems = document.querySelectorAll('.movie-list-item');
    const cinemaCards = document.querySelectorAll('.cinema-card');

    let visibleCount = 0;

        // Search movie cards
        movieCards.forEach(card => {
            const title = card.querySelector('.card-title').textContent.toLowerCase();
    const isVisible = !term || title.includes(term);

    card.style.display = isVisible ? 'block' : 'none';
    if (isVisible) {
        visibleCount++;
    card.style.animation = 'fadeInUp 0.5s ease-out';
            }
        });

        // Search movie list items
        movieListItems.forEach(item => {
            const title = item.querySelector('.movie-title').textContent.toLowerCase();
    const isVisible = !term || title.includes(term);

    item.style.display = isVisible ? 'flex' : 'none';
    if (isVisible) visibleCount++;
        });

        // Search cinema cards
        cinemaCards.forEach(card => {
            const name = card.querySelector('.cinema-name').textContent.toLowerCase();
    const location = card.querySelector('.cinema-location span').textContent.toLowerCase();
    const isVisible = !term || name.includes(term) || location.includes(term);

    card.style.display = isVisible ? 'block' : 'none';
    if (isVisible) visibleCount++;
        });

    // Show search results feedback
    if (term) {
        showNotification(`Found ${visibleCount} results for "${searchTerm}"`, 'info');
        }
    }

    function selectMovie(movieTitle) {
        showNotification(`Selected: ${movieTitle}`, 'success');
    // Add navigation logic here
    console.log('Navigate to movie:', movieTitle);
    }

    function selectCinema(cinemaName) {
        showNotification(`Selected cinema: ${cinemaName}`, 'success');
    // Add navigation logic here
    console.log('Navigate to cinema:', cinemaName);
    }

    function showNotification(message, type = 'info') {
        const notification = document.createElement('div');
    const bgColor = type === 'success' ? 'rgba(46, 204, 113, 0.9)' :
    type === 'error' ? 'rgba(231, 76, 60, 0.9)' :
    'rgba(79, 172, 254, 0.9)';

    notification.className = 'notification';
    notification.style.background = bgColor;
    notification.textContent = message;

    document.body.appendChild(notification);

        setTimeout(() => {
        notification.style.animation = 'slideInRight 0.3s ease-in reverse';
            setTimeout(() => notification.remove(), 300);
        }, 3000);
    }

    // Enhanced hover effects
    document.querySelectorAll('.movie-card').forEach(card => {
        card.addEventListener('mouseenter', function () {
            this.style.transform = 'translateY(-8px) scale(1.02)';
        });

    card.addEventListener('mouseleave', function() {
        this.style.transform = '';
        });
    });
