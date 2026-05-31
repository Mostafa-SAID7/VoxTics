(function () {
    'use strict';

    document.addEventListener('DOMContentLoaded', function () {
        initMoviesIndex();
    });

    function initMoviesIndex() {
        initSearch();
        initStatusFilter();
        initDeleteConfirm();
    }

    function initSearch() {
        const searchInput = document.querySelector('#movieSearch, #searchInput, input[name="search"]');
        if (!searchInput) return;
        searchInput.addEventListener('input', VoxTicsUtils.debounce(function () {
            const query = this.value.toLowerCase();
            document.querySelectorAll('.movie-row, tbody tr').forEach(function (row) {
                const title = (row.dataset.title || row.textContent).toLowerCase();
                row.style.display = title.includes(query) ? '' : 'none';
            });
        }, 250));
    }

    function initStatusFilter() {
        const statusFilter = document.querySelector('#statusFilter, select[name="status"]');
        if (!statusFilter) return;
        statusFilter.addEventListener('change', function () {
            const status = this.value.toLowerCase();
            document.querySelectorAll('.movie-row, tbody tr').forEach(function (row) {
                if (!status || row.dataset.status === status || row.dataset.status === undefined) {
                    row.style.display = '';
                } else {
                    row.style.display = 'none';
                }
            });
        });
    }

    function initDeleteConfirm() {
        document.querySelectorAll('[data-confirm-delete], .btn-delete-table').forEach(function (btn) {
            btn.addEventListener('click', function (e) {
                if (!confirm('Are you sure you want to delete this movie?')) {
                    e.preventDefault();
                }
            });
        });
    }
})();
