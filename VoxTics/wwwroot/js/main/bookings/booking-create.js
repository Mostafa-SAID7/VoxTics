(function () {
    'use strict';

    document.addEventListener('DOMContentLoaded', function () {
        var cfg = document.getElementById('booking-data');
        if (!cfg) return;

        var seatPrice  = parseFloat(cfg.dataset.seatPrice) || 0;
        var discount   = parseFloat(cfg.dataset.discount)  || 0;
        var MAX_SEATS  = 10;

        var selectedSeats = [];

        // ── Seat buttons ──────────────────────────────────
        document.querySelectorAll('.seat-available').forEach(function (btn) {
            btn.addEventListener('click', function () {
                var seatId = btn.dataset.seatId;
                var idx    = selectedSeats.indexOf(seatId);

                if (idx >= 0) {
                    // Deselect
                    selectedSeats.splice(idx, 1);
                    btn.classList.remove('seat-selected');
                    btn.classList.add('seat-available');
                } else {
                    if (selectedSeats.length >= MAX_SEATS) {
                        alert('You can select a maximum of ' + MAX_SEATS + ' seats per booking.');
                        return;
                    }
                    selectedSeats.push(seatId);
                    btn.classList.remove('seat-available');
                    btn.classList.add('seat-selected');
                }

                syncCheckboxes();
                updateSummary();
                updateConfirmBtn();
            });
        });

        // ── Payment method radios ─────────────────────────
        document.querySelectorAll('.payment-radio').forEach(function (radio) {
            radio.addEventListener('change', updateConfirmBtn);
        });

        // ── Sync hidden checkbox inputs for form POST ─────
        function syncCheckboxes() {
            var container = document.getElementById('seat-checkboxes');
            if (!container) return;
            container.innerHTML = '';
            selectedSeats.forEach(function (id) {
                var input = document.createElement('input');
                input.type  = 'hidden';
                input.name  = 'SeatIds';
                input.value = id;
                container.appendChild(input);
            });
        }

        // ── Summary display ───────────────────────────────
        function updateSummary() {
            var count  = selectedSeats.length;
            var total  = count * seatPrice;
            var final  = Math.max(0, total - discount);

            var fmtUSD = function (v) {
                return v.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
            };

            var selEl  = document.getElementById('selectedSeats');
            var totEl  = document.getElementById('totalAmount');
            var finEl  = document.getElementById('finalAmount');
            var hidTot = document.getElementById('hiddenTotalAmount');
            var hidFin = document.getElementById('hiddenFinalAmount');

            if (selEl)  selEl.textContent  = count;
            if (totEl)  totEl.textContent  = fmtUSD(total);
            if (finEl)  finEl.textContent  = fmtUSD(final);
            if (hidTot) hidTot.value        = total.toFixed(2);
            if (hidFin) hidFin.value        = final.toFixed(2);
        }

        // ── Enable confirm only when seats + payment chosen ──
        function updateConfirmBtn() {
            var btn           = document.getElementById('confirm-booking-btn');
            var paymentChosen = !!document.querySelector('.payment-radio:checked');
            if (btn) {
                btn.disabled = selectedSeats.length === 0 || !paymentChosen;
            }
        }

        // Initial state
        updateSummary();
        updateConfirmBtn();
    });

})();
