    // Global variables
    let currentView = 'card';
    let allShowtimes = [];

    // Initialize on page load
    document.addEventListener('DOMContentLoaded', function() {
        initializeShowtimes();
    setupEventListeners();
    animateCards();
    });

    function initializeShowtimes() {
        const cards = document.querySelectorAll('.showtime-card, .enhanced-table tbody tr');
    allShowtimes = Array.from(cards);
    }

    function setupEventListeners() {
        // Search functionality
        document.getElementById('movieSearch').addEventListener('input', filterShowtimes);
    document.getElementById('hallFilter').addEventListener('change', filterShowtimes);
    document.getElementById('timeFilter').addEventListener('change', filterShowtimes);
    document.getElementById('sortFilter').addEventListener('change', sortShowtimes);
    }

    function toggleView(view) {
        currentView = view;

        // Update button states
        document.querySelectorAll('.view-btn').forEach(btn => btn.classList.remove('active'));
    event.target.classList.add('active');

    // Toggle views
    const cardView = document.getElementById('cardView');
    const tableView = document.getElementById('tableView');

    if (view === 'card') {
        cardView.style.display = 'block';
    tableView.classList.remove('active');
            setTimeout(() => animateCards(), 100);
        } else {
        cardView.style.display = 'none';
    tableView.classList.add('active');
        }

    showNotification(`Switched to ${view} view`);
    }

    function filterShowtimes() {
        const movieSearch = document.getElementById('movieSearch').value.toLowerCase();
    const hallFilter = document.getElementById('hallFilter').value;
    const timeFilter = document.getElementById('timeFilter').value;

    let visibleCount = 0;

        allShowtimes.forEach(item => {
            const movieTitle = item.dataset.movie;
    const hallName = item.dataset.hall;
    const showTime = parseInt(item.dataset.time);

    let showItem = true;

    // Movie search filter
    if (movieSearch && !movieTitle.includes(movieSearch)) {
        showItem = false;
            }

    // Hall filter
    if (hallFilter && hallName !== hallFilter) {
        showItem = false;
            }

    // Time filter
    if (timeFilter) {
                const timeInRange = checkTimeRange(showTime, timeFilter);
    if (!timeInRange) {
        showItem = false;
                }
            }

    if (showItem) {
        item.style.display = '';
    item.style.animation = 'fadeInUp 0.5s ease-out';
    visibleCount++;
            } else {
        item.style.display = 'none';
            }
        });

    updateNoResultsMessage(visibleCount);
    }

    function checkTimeRange(hour, range) {
        switch(range) {
            case 'morning':
                return hour >= 6 && hour < 12;
    case 'afternoon':
                return hour >= 12 && hour < 18;
    case 'evening':
                return hour >= 18 || hour < 6;
    default:
    return true;
        }
    }

    function sortShowtimes() {
        const sortBy = document.getElementById('sortFilter').value;
    const container = currentView === 'card' ?
    document.getElementById('showtimesGrid') :
    document.querySelector('#tableBody');

    const items = Array.from(container.children);

        items.sort((a, b) => {
            switch(sortBy) {
                case 'movie':
    return a.dataset.movie.localeCompare(b.dataset.movie);
    case 'price':
    return parseFloat(a.dataset.price) - parseFloat(b.dataset.price);
    case 'hall':
    return a.dataset.hall.localeCompare(b.dataset.hall);
    case 'time':
    default:
    return parseInt(a.dataset.time) - parseInt(b.dataset.time);
            }
        });

        // Re-append sorted items
        items.forEach(item => container.appendChild(item));

    if (currentView === 'card') {
        animateCards();
        }

    showNotification(`Sorted by ${sortBy}`);
    }

    function updateNoResultsMessage(count) {
        let noResultsEl = document.querySelector('.no-results-filtered');

    if (count === 0) {
            if (!noResultsEl) {
        noResultsEl = document.createElement('div');
    noResultsEl.className = 'no-results no-results-filtered';
    noResultsEl.innerHTML = `
    <div class="no-results-icon">🔍</div>
    <h3>No Matching Showtimes</h3>
    <p>Try adjusting your filters to see more results.</p>
    `;
    document.querySelector('.showtimes-content').appendChild(noResultsEl);
            }
    noResultsEl.style.display = 'block';
        } else if (noResultsEl) {
        noResultsEl.style.display = 'none';
        }
    }

    function selectShowtime(showtimeId) {
        showNotification(`Selected showtime ${showtimeId}`, 'success');

    // Add visual feedback
    const target = event.currentTarget;
    target.style.transform = 'scale(0.98)';
        setTimeout(() => {
        target.style.transform = '';
        }, 150);

        // Here you could navigate to booking page or show details
        // window.location.href = `/Booking/${showtimeId}`;
    }

    function animateCards() {
        const cards = document.querySelectorAll('.showtime-card:not([style*="display: none"])');
        cards.forEach((card, index) => {
        card.style.opacity = '0';
    card.style.transform = 'translateY(30px)';

            setTimeout(() => {
        card.style.transition = 'all 0.6s ease-out';
    card.style.opacity = '1';
    card.style.transform = 'translateY(0)';
            }, index * 100);
        });
    }

    function showNotification(message, type = 'info') {
        const notification = document.createElement('div');
    const bgColor = type === 'success' ? 'rgba(46, 204, 113, 0.9)' :
    type === 'error' ? 'rgba(231, 76, 60, 0.9)' :
    'rgba(52, 152, 219, 0.9)';

    notification.style.cssText = `
    position: fixed;
    top: 20px;
    right: 20px;
    background: ${bgColor};
    color: white;
    padding: 1rem 2rem;
    border-radius: 15px;
    z-index: 1000;
    animation: slideInRight 0.3s ease-out;
    backdrop-filter: blur(10px);
    box-shadow: 0 10px 25px rgba(0,0,0,0.2);
    max-width: 400px;
    font-weight: 500;
    `;
    notification.textContent = message;
    document.body.appendChild(notification);

        setTimeout(() => {
        notification.style.animation = 'slideOutRight 0.3s ease-in';
            setTimeout(() => notification.remove(), 300);
        }, 3000);
    }
