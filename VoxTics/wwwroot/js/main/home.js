(function () {
    'use strict';

    document.addEventListener('DOMContentLoaded', function () {
        initHomeSearch();
    });

    function initHomeSearch() {
        var searchInput = document.getElementById('searchInput');
        if (!searchInput) return;

        var searchTimeout;
        searchInput.addEventListener('input', function (e) {
            clearTimeout(searchTimeout);
            var val = e.target.value;
            searchTimeout = setTimeout(function () {
                performSearch(val);
            }, 300);
        });

        document.addEventListener('keydown', function (e) {
            if (e.ctrlKey && e.key === 'k') {
                e.preventDefault();
                searchInput.focus();
            }
        });
    }

    function performSearch(searchTerm) {
        var term = searchTerm.toLowerCase().trim();
        var movieCards = document.querySelectorAll('.movie-card');
        var listItems = document.querySelectorAll('.list-apple-item');
        var cinemaCards = document.querySelectorAll('.cinema-card');
        var visibleCount = 0;

        movieCards.forEach(function (card) {
            var title = (card.dataset.movie || '').toLowerCase();
            var isVisible = !term || title.includes(term);
            var col = card.closest('[class*="col-"]');
            if (col) col.style.display = isVisible ? '' : 'none';
            if (isVisible) visibleCount++;
        });

        listItems.forEach(function (item) {
            var h6 = item.querySelector('h6');
            var title = (h6 ? h6.textContent : '').toLowerCase();
            var isVisible = !term || title.includes(term);
            item.style.display = isVisible ? '' : 'none';
            if (isVisible) visibleCount++;
        });

        cinemaCards.forEach(function (card) {
            var h5 = card.querySelector('h5');
            var span = card.querySelector('span');
            var name = (h5 ? h5.textContent : '').toLowerCase();
            var location = (span ? span.textContent : '').toLowerCase();
            var isVisible = !term || name.includes(term) || location.includes(term);
            var col = card.closest('[class*="col-"]');
            if (col) col.style.display = isVisible ? '' : 'none';
            if (isVisible) visibleCount++;
        });

        if (term && visibleCount === 0) {
            VoxTicsUtils.notify('No results found for "' + searchTerm + '"', 'warning');
        } else if (term) {
            VoxTicsUtils.notify('Found ' + visibleCount + ' results for "' + searchTerm + '"', 'info');
        }
    }

    window.selectMovie = function (movieTitle) {
        VoxTicsUtils.notify('Selected: ' + movieTitle, 'success');
    };

    window.selectCinema = function (cinemaName) {
        VoxTicsUtils.notify('Selected cinema: ' + cinemaName, 'success');
    };

})();
