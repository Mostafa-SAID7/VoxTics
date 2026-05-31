---
name: VoxTics JS/CSS architecture
description: The finalized centralization rules for styles and scripts in VoxTics views.
---

## CSS
- Single source of truth: `wwwroot/css/voxtics-global.css`
- Sections: Global Reset → Typography → Layout → Components → Loader → Showtimes Page → Admin Dashboard → Admin Movie Table → Responsive
- No `@section Styles` blocks remain in any view.

## JavaScript
- `wwwroot/js/site.js` — global: tooltips, lazy-load, pagination AJAX (loadWithAjax), loader API (window.showLoader/hideLoader/Loader/fetchWithLoader)
- `wwwroot/js/voxtics-utils.js` — VoxTicsUtils.notify, formatCurrency, showLoading/hideLoading
- `wwwroot/js/main/home.js` — home page search, selectMovie/selectCinema globals (onclick)
- `wwwroot/js/main/showtimes/showtimes.js` — filter/sort/view toggle; toggleView/selectShowtime globals (onclick)
- `wwwroot/js/main/bookings/booking-create.js` — reads data-seat-price + data-discount from #booking-data div
- `wwwroot/js/admin/cinemas/cinema-form.js` — previewFile global (onchange)
- `wwwroot/js/admin/dashboard.js` — reads JSON config from #dashboard-config <script type="application/json">
- `wwwroot/js/admin/bookings/bookings-index.js` — reads data attributes from #bookings-config div

## Accepted inline-script exception
- `Views/Shared/_Layout.cshtml` line ~223: a small `<script>` block that reads TempData (ShowLoginModal, success-notification, etc.) MUST stay inline — it has no other mechanism.

## Pattern for Razor data → JS
- Simple values (prices, IDs, page counts): `data-*` attributes on a hidden config div, read with `el.dataset.*`
- Complex data (serialized model dicts, multiple URLs): `<script id="...-config" type="application/json">{ ... }</script>`, read with `JSON.parse(document.getElementById('...-config').textContent)`
