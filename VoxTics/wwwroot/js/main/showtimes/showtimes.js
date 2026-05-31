(function () {
    'use strict';

    var currentView = 'card';
    var allShowtimes = [];

    document.addEventListener('DOMContentLoaded', function () {
        initializeShowtimes();
        setupEventListeners();
        animateCards();
    });

    function initializeShowtimes() {
        var cards = document.querySelectorAll('.showtime-card, .enhanced-table tbody tr');
        allShowtimes = Array.from(cards);
    }

    function setupEventListeners() {
        var movieSearch = document.getElementById('movieSearch');
        var hallFilter  = document.getElementById('hallFilter');
        var timeFilter  = document.getElementById('timeFilter');
        var sortFilter  = document.getElementById('sortFilter');
        if (movieSearch) movieSearch.addEventListener('input', filterShowtimes);
        if (hallFilter)  hallFilter.addEventListener('change', filterShowtimes);
        if (timeFilter)  timeFilter.addEventListener('change', filterShowtimes);
        if (sortFilter)  sortFilter.addEventListener('change', sortShowtimes);
    }

    function filterShowtimes() {
        var movieSearchEl = document.getElementById('movieSearch');
        var hallFilterEl  = document.getElementById('hallFilter');
        var timeFilterEl  = document.getElementById('timeFilter');
        var movieSearch = movieSearchEl ? movieSearchEl.value.toLowerCase() : '';
        var hallFilter  = hallFilterEl  ? hallFilterEl.value  : '';
        var timeFilter  = timeFilterEl  ? timeFilterEl.value  : '';
        var visibleCount = 0;

        allShowtimes.forEach(function (item) {
            var movieTitle = (item.dataset.movie || '').toLowerCase();
            var hallName   = item.dataset.hall  || '';
            var showTime   = parseInt(item.dataset.time, 10);
            var show = true;

            if (movieSearch && !movieTitle.includes(movieSearch)) show = false;
            if (hallFilter  && hallName !== hallFilter)           show = false;
            if (timeFilter  && !checkTimeRange(showTime, timeFilter)) show = false;

            if (show) {
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
        switch (range) {
            case 'morning':   return hour >= 6  && hour < 12;
            case 'afternoon': return hour >= 12 && hour < 18;
            case 'evening':   return hour >= 18 || hour < 6;
            default:          return true;
        }
    }

    function sortShowtimes() {
        var sortFilter = document.getElementById('sortFilter');
        var sortBy = sortFilter ? sortFilter.value : 'time';
        var container = currentView === 'card'
            ? document.getElementById('showtimesGrid')
            : document.querySelector('#tableBody');
        if (!container) return;

        var items = Array.from(container.children);
        items.sort(function (a, b) {
            switch (sortBy) {
                case 'movie': return (a.dataset.movie || '').localeCompare(b.dataset.movie || '');
                case 'price': return parseFloat(a.dataset.price || 0) - parseFloat(b.dataset.price || 0);
                case 'hall':  return (a.dataset.hall  || '').localeCompare(b.dataset.hall  || '');
                default:      return parseInt(a.dataset.time || 0, 10) - parseInt(b.dataset.time || 0, 10);
            }
        });
        items.forEach(function (item) { container.appendChild(item); });
        if (currentView === 'card') animateCards();
        VoxTicsUtils.notify('Sorted by ' + sortBy, 'info');
    }

    function updateNoResultsMessage(count) {
        var noResultsEl = document.querySelector('.no-results-filtered');
        if (count === 0) {
            if (!noResultsEl) {
                noResultsEl = document.createElement('div');
                noResultsEl.className = 'no-results no-results-filtered';
                noResultsEl.innerHTML =
                    '<div class="no-results-icon">🔍</div>' +
                    '<h3>No Matching Showtimes</h3>' +
                    '<p>Try adjusting your filters to see more results.</p>';
                var content = document.querySelector('.showtimes-content');
                if (content) content.appendChild(noResultsEl);
            }
            noResultsEl.style.display = 'block';
        } else if (noResultsEl) {
            noResultsEl.style.display = 'none';
        }
    }

    function animateCards() {
        var cards = document.querySelectorAll('.showtime-card:not([style*="display: none"])');
        cards.forEach(function (card, index) {
            card.style.opacity = '0';
            card.style.transform = 'translateY(30px)';
            setTimeout(function () {
                card.style.transition = 'all 0.6s ease-out';
                card.style.opacity = '1';
                card.style.transform = 'translateY(0)';
            }, index * 100);
        });
    }

    window.toggleView = function (view) {
        currentView = view;
        document.querySelectorAll('.view-btn').forEach(function (btn) {
            btn.classList.remove('active');
        });
        var clickedBtn = document.querySelector('.view-btn[onclick*="' + view + '"]');
        if (clickedBtn) clickedBtn.classList.add('active');

        var cardView  = document.getElementById('cardView');
        var tableView = document.getElementById('tableView');

        if (view === 'card') {
            if (cardView)  cardView.style.display = 'block';
            if (tableView) tableView.classList.remove('active');
            setTimeout(animateCards, 100);
        } else {
            if (cardView)  cardView.style.display = 'none';
            if (tableView) tableView.classList.add('active');
        }
        VoxTicsUtils.notify('Switched to ' + view + ' view', 'info');
    };

    window.selectShowtime = function (showtimeId) {
        VoxTicsUtils.notify('Selected showtime ' + showtimeId, 'success');
    };

})();
