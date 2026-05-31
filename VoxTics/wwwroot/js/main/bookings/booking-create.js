(function () {
    'use strict';

    document.addEventListener('DOMContentLoaded', function () {
        var cfg = document.getElementById('booking-data');
        if (!cfg) return;

        var seatPrice = parseFloat(cfg.dataset.seatPrice) || 0;
        var discount  = parseFloat(cfg.dataset.discount)  || 0;

        function updateSummary() {
            var selected = document.querySelectorAll('.seat-checkbox:checked').length;
            var total    = selected * seatPrice;
            var final    = total - discount;

            var selEl   = document.getElementById('selectedSeats');
            var totEl   = document.getElementById('totalAmount');
            var finEl   = document.getElementById('finalAmount');

            if (selEl) selEl.textContent = selected;
            if (totEl) totEl.textContent = total.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
            if (finEl) finEl.textContent = final.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
        }

        document.querySelectorAll('.seat-checkbox').forEach(function (cb) {
            cb.addEventListener('change', updateSummary);
        });
        updateSummary();
    });

})();
