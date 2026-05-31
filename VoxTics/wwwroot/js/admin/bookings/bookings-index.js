(function () {
    'use strict';

    var cfg = {};

    $(document).ready(function () {
        var el = document.getElementById('bookings-config');
        if (el) {
            cfg = {
                indexUrl:   el.dataset.indexUrl,
                cancelUrl:  el.dataset.cancelUrl,
                exportUrl:  el.dataset.exportUrl,
                pageIndex:  parseInt(el.dataset.pageIndex,  10) || 0,
                pageSize:   parseInt(el.dataset.pageSize,   10) || 10,
                totalCount: parseInt(el.dataset.totalCount, 10) || 0
            };
        }

        initBookingsIndex();
    });

    function initBookingsIndex() {
        updatePaginationInfo();
        bindSearch();
        bindFilters();
        bindPagination();
        bindCancelBooking();
        bindExport();
        bindKeyboard();
        startAutoRefresh();
    }

    function updatePaginationInfo() {
        var start = (cfg.pageIndex * cfg.pageSize) + 1;
        var end   = Math.min((cfg.pageIndex + 1) * cfg.pageSize, cfg.totalCount);
        $('.pagination-info').text('Showing ' + start + ' to ' + end + ' of ' + cfg.totalCount + ' entries');
    }

    function toggleLoading(show) {
        if (show) {
            $('#loadingSpinner').show();
            $('#bookingTableContainer').css('opacity', '0.5');
        } else {
            $('#loadingSpinner').hide();
            $('#bookingTableContainer').css('opacity', '1').addClass('fade-in');
        }
    }

    function showToast(type, message) {
        VoxTicsUtils.notify(message, type === 'error' ? 'error' : 'success');
    }

    function loadData(params) {
        params = params || {};
        toggleLoading(true);
        var defaults = {
            pageIndex: 0,
            pageSize:  $('#pageSizeSelect').val() || cfg.pageSize,
            search:    $('#searchInput').val(),
            status:    $('#statusFilter').val(),
            dateFrom:  $('#dateFrom').val(),
            dateTo:    $('#dateTo').val()
        };
        var finalParams = $.extend({}, defaults, params);

        $.ajax({
            url:  cfg.indexUrl,
            type: 'GET',
            data: finalParams,
            success: function (data) {
                var $data = $(data);
                $('#bookingTableContainer').html($data.find('#bookingTableContainer').html());
                $('#pagination').html($data.find('#pagination').html());
                cfg.pageIndex = finalParams.pageIndex;
                updatePaginationInfo();
                showToast('success', 'Data loaded successfully');
            },
            error: function (xhr) {
                showToast('error', 'Failed to load data: ' + xhr.responseText);
            },
            complete: function () {
                toggleLoading(false);
            }
        });
    }

    function bindSearch() {
        var searchTimeout;
        $('#searchInput').on('input', function () {
            clearTimeout(searchTimeout);
            var term = $(this).val();
            searchTimeout = setTimeout(function () {
                loadData({ pageIndex: 0, search: term });
            }, 500);
        });
        $('#clearSearch').click(function () {
            $('#searchInput').val('');
            loadData({ pageIndex: 0, search: '' });
        });
        $('#searchForm').submit(function (e) {
            e.preventDefault();
            loadData({ pageIndex: 0 });
        });
    }

    function bindFilters() {
        $('#pageSizeSelect').change(function () {
            loadData({ pageIndex: 0, pageSize: $(this).val() });
        });
        $('#statusFilter, #dateFrom, #dateTo').change(function () {
            loadData({ pageIndex: 0 });
        });
        $('#refreshBtn').click(function () {
            loadData({ pageIndex: cfg.pageIndex });
        });
    }

    function bindPagination() {
        $(document).on('click', '.page-link-num, .page-link-nav', function (e) {
            e.preventDefault();
            loadData({ pageIndex: $(this).data('page') });
        });
    }

    function bindCancelBooking() {
        $(document).on('click', '.cancel-booking', function () {
            var bookingId  = $(this).data('id');
            var bookingRef = $(this).data('reference') || ('#' + bookingId);
            if (!confirm('Are you sure you want to cancel booking ' + bookingRef + '?')) return;

            var $btn = $(this);
            var originalText = $btn.html();
            $btn.prop('disabled', true).html('<i class="fas fa-spinner fa-spin"></i> Cancelling...');

            $.ajax({
                url:  cfg.cancelUrl,
                type: 'POST',
                data: { bookingId: bookingId },
                headers: { 'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val() },
                success: function (response) {
                    showToast('success', response.message || 'Booking cancelled successfully');
                    $('#bookingRow_' + bookingId).fadeOut(300, function () { $(this).remove(); });
                    setTimeout(function () { loadData({ pageIndex: cfg.pageIndex }); }, 300);
                },
                error: function (xhr) {
                    var msg = 'Failed to cancel booking';
                    try { msg = JSON.parse(xhr.responseText).message || msg; } catch (e) { msg = xhr.responseText || msg; }
                    showToast('error', msg);
                    $btn.prop('disabled', false).html(originalText);
                }
            });
        });
    }

    function bindExport() {
        $('#exportBtn').click(function () {
            var format   = $('input[name="exportFormat"]:checked').val();
            var filtered = $('#exportFiltered').is(':checked');
            var params   = { format: format };
            if (filtered) {
                $.extend(params, {
                    search:   $('#searchInput').val(),
                    status:   $('#statusFilter').val(),
                    dateFrom: $('#dateFrom').val(),
                    dateTo:   $('#dateTo').val()
                });
            }
            var form = $('<form>', { method: 'POST', action: cfg.exportUrl });
            $.each(params, function (k, v) {
                if (v) form.append($('<input>', { type: 'hidden', name: k, value: v }));
            });
            form.append($('input[name="__RequestVerificationToken"]').clone());
            $('body').append(form);
            form.submit();
            form.remove();
            $('#exportModal').modal('hide');
            showToast('success', 'Export started. Download will begin shortly.');
        });
    }

    function bindKeyboard() {
        $(document).keydown(function (e) {
            if ((e.ctrlKey || e.metaKey) && e.keyCode === 70) {
                e.preventDefault();
                $('#searchInput').focus();
            }
            if (e.keyCode === 27 && $('#searchInput').is(':focus')) {
                $('#clearSearch').click();
            }
        });
    }

    function startAutoRefresh() {
        setInterval(function () {
            loadData({ pageIndex: cfg.pageIndex });
        }, 300000);
    }

})();
