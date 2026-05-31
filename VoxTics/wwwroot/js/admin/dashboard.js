(function () {
    'use strict';

    var cfg = {};
    var dashboardChart, movieStatusChart, bookingStatusChart, refreshInterval;

    $(document).ready(function () {
        var configEl = document.getElementById('dashboard-config');
        if (configEl) {
            try { cfg = JSON.parse(configEl.textContent); } catch (e) { cfg = {}; }
        }
        initializeDashboard();
        setupAutoRefresh();
        loadSavedSettings();
    });

    function initializeDashboard() {
        loadMainChart();
        loadStatusCharts();
        animateCounters();
    }

    function loadMainChart() {
        fetch(cfg.chartDataUrl || '')
            .then(function (res) { return res.json(); })
            .then(function (data) {
                var ctx = document.getElementById('dashboardChart');
                if (!ctx) return;
                if (dashboardChart) dashboardChart.destroy();
                dashboardChart = new Chart(ctx.getContext('2d'), {
                    type: 'line',
                    data: {
                        labels: Object.keys(data.MonthlyBookings || {}),
                        datasets: [
                            {
                                label: 'Bookings',
                                data: Object.values(data.MonthlyBookings || {}),
                                borderColor: '#007bff',
                                backgroundColor: 'rgba(0,123,255,0.1)',
                                fill: true, tension: 0.4,
                                pointRadius: 6, pointHoverRadius: 8,
                                yAxisID: 'y'
                            },
                            {
                                label: 'Revenue',
                                data: Object.values(data.MonthlyRevenue || {}),
                                borderColor: '#28a745',
                                backgroundColor: 'rgba(40,167,69,0.1)',
                                fill: true, tension: 0.4,
                                pointRadius: 6, pointHoverRadius: 8,
                                yAxisID: 'y1'
                            }
                        ]
                    },
                    options: {
                        responsive: true,
                        maintainAspectRatio: false,
                        interaction: { mode: 'index', intersect: false },
                        plugins: {
                            legend: { position: 'top', labels: { usePointStyle: true, padding: 20 } },
                            tooltip: {
                                backgroundColor: 'rgba(0,0,0,0.8)',
                                titleColor: 'white', bodyColor: 'white',
                                borderColor: 'rgba(255,255,255,0.1)', borderWidth: 1,
                                cornerRadius: 8, displayColors: true
                            }
                        },
                        scales: {
                            x:  { display: true, grid: { display: false } },
                            y:  { type: 'linear', position: 'left',  title: { display: true, text: 'Bookings', color: '#007bff' }, grid: { color: 'rgba(0,0,0,0.05)' } },
                            y1: { type: 'linear', position: 'right', title: { display: true, text: 'Revenue ($)', color: '#28a745' }, grid: { drawOnChartArea: false } }
                        }
                    }
                });
            })
            .catch(function (err) { console.error('Chart data error:', err); });
    }

    function loadStatusCharts() {
        var movieStatusData   = cfg.moviesByStatus   || {};
        var bookingStatusData = cfg.bookingsByStatus || {};
        createDoughnutChart('movieStatusChart',   movieStatusData,   ['#007bff','#28a745','#ffc107','#dc3545','#6c757d']);
        createDoughnutChart('bookingStatusChart', bookingStatusData, ['#28a745','#ffc107','#dc3545','#17a2b8','#6c757d']);
    }

    function createDoughnutChart(canvasId, data, colors) {
        var ctx = document.getElementById(canvasId);
        if (!ctx) return;
        new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: Object.keys(data),
                datasets: [{ data: Object.values(data), backgroundColor: colors, borderWidth: 2, borderColor: '#fff', hoverBorderWidth: 3 }]
            },
            options: {
                responsive: true, maintainAspectRatio: false,
                plugins: {
                    legend: { display: false },
                    tooltip: { backgroundColor: 'rgba(0,0,0,0.8)', titleColor: 'white', bodyColor: 'white', cornerRadius: 8 }
                },
                cutout: '70%'
            }
        });
    }

    function animateCounters() {
        $('.card-hover').each(function (index) {
            $(this).css('animation-delay', (index * 0.1) + 's').addClass('fade-in-up');
        });
        $('[id$="Count"], [id$="Amount"]').each(function () {
            var $el = $(this);
            var countTo = parseInt($el.text().replace(/[^0-9]/g, ''), 10) || 0;
            var isAmount = $el.attr('id') && $el.attr('id').includes('Amount');
            $({ n: 0 }).animate({ n: countTo }, {
                duration: 2000,
                easing: 'swing',
                step: function () {
                    var f = Math.floor(this.n).toLocaleString();
                    $el.text(isAmount ? '$' + f : f);
                },
                complete: function () {
                    var f = countTo.toLocaleString();
                    $el.text(isAmount ? '$' + f : f);
                }
            });
        });
    }

    function setupAutoRefresh() {
        var interval = parseInt(localStorage.getItem('dashboardRefreshInterval'), 10) || 300;
        if (interval > 0) {
            refreshInterval = setInterval(refreshDashboardData, interval * 1000);
        }
    }

    function refreshDashboardData() {
        $('#refreshDashboard').addClass('fa-spin');
        fetch(cfg.dashboardDataUrl || '')
            .then(function (res) { return res.json(); })
            .then(function (data) {
                updateDashboardData(data);
                showNotification('Dashboard data updated', 'success');
            })
            .catch(function () { showNotification('Failed to refresh dashboard', 'error'); })
            .finally(function () { $('#refreshDashboard').removeClass('fa-spin'); });
    }

    function updateDashboardData(data) {
        $('#totalMoviesCount').text(data.TotalMovies);
        $('#totalUsersCount').text(data.TotalUsers);
        $('#totalBookingsCount').text(data.TotalBookings);
        $('#totalRevenueAmount').text(data.FormattedTotalRevenue);
        loadMainChart();
        loadStatusCharts();
    }

    window.updateChartPeriod = function (period) {
        $('#dashboardChart').parent().find('.dropdown-toggle').text(
            period === '7days' ? 'Last 7 Days' : period === '30days' ? 'Last 30 Days' : 'Last 12 Months'
        );
        fetch((cfg.chartDataUrl || '') + '?period=' + period)
            .then(function (res) { return res.json(); })
            .then(function (data) {
                if (!dashboardChart) return;
                dashboardChart.data.labels = Object.keys(data.MonthlyBookings || {});
                dashboardChart.data.datasets[0].data = Object.values(data.MonthlyBookings || {});
                dashboardChart.data.datasets[1].data = Object.values(data.MonthlyRevenue  || {});
                dashboardChart.update('active');
            });
    };

    window.exportDashboard = function (format) {
        var form = $('<form>', { method: 'POST', action: cfg.exportUrl || '', target: '_blank' });
        form.append($('<input>', { type: 'hidden', name: 'format', value: format }));
        form.append($('input[name="__RequestVerificationToken"]').clone());
        $('body').append(form);
        form.submit();
        form.remove();
        showNotification(format.toUpperCase() + ' export started', 'info');
    };

    window.saveSettings = function () {
        var ri = $('#refreshInterval').val();
        var notif = $('#enableNotifications').is(':checked');
        var anim  = $('#enableAnimations').is(':checked');
        localStorage.setItem('dashboardRefreshInterval', ri);
        localStorage.setItem('dashboardNotifications', notif);
        localStorage.setItem('dashboardAnimations', anim);
        if (refreshInterval) clearInterval(refreshInterval);
        if (parseInt(ri, 10) > 0) refreshInterval = setInterval(refreshDashboardData, parseInt(ri, 10) * 1000);
        $('body').toggleClass('no-animations', !anim);
        $('#settingsModal').modal('hide');
        showNotification('Settings saved successfully', 'success');
    };

    function showNotification(message, type) {
        if (localStorage.getItem('dashboardNotifications') === 'false') return;
        VoxTicsUtils.notify(message, type || 'info');
    }

    $('#refreshDashboard').click(function () { refreshDashboardData(); });

    function loadSavedSettings() {
        var ri    = localStorage.getItem('dashboardRefreshInterval');
        var notif = localStorage.getItem('dashboardNotifications');
        var anim  = localStorage.getItem('dashboardAnimations');
        if (ri)              $('#refreshInterval').val(ri);
        if (notif === 'false') $('#enableNotifications').prop('checked', false);
        if (anim  === 'false') { $('#enableAnimations').prop('checked', false); $('body').addClass('no-animations'); }
    }

    if (typeof signalR !== 'undefined') {
        var connection = new signalR.HubConnectionBuilder().withUrl('/dashboardHub').build();
        connection.start()
            .then(function () { console.log('Dashboard SignalR connected'); })
            .catch(function (err) { console.error('SignalR error:', err); });
        connection.on('UpdateDashboard', function (data) {
            updateDashboardData(data);
            showNotification('Dashboard updated in real-time', 'info');
        });
    }

})();
