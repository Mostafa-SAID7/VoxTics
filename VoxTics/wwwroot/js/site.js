(function () {
    'use strict';

    document.addEventListener('DOMContentLoaded', function () {
        initializeTooltips();
        initializeImageLazyLoading();
        initPaginationAjax();
        initLoaderApi();
    });

    function initializeTooltips() {
        var els = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
        els.forEach(function (el) { new bootstrap.Tooltip(el); });
    }

    function initializeImageLazyLoading() {
        if (!('IntersectionObserver' in window)) return;
        var observer = new IntersectionObserver(function (entries) {
            entries.forEach(function (entry) {
                if (!entry.isIntersecting) return;
                var img = entry.target;
                img.src = img.dataset.src;
                img.classList.remove('lazy');
                observer.unobserve(img);
            });
        });
        document.querySelectorAll('img[data-src]').forEach(function (img) {
            observer.observe(img);
        });
    }

    function initLoaderApi() {
        var overlay = document.getElementById('loadingOverlay');
        var global  = document.getElementById('global-loader');

        window.showLoader = function () {
            if (overlay) { overlay.classList.remove('d-none'); overlay.classList.add('d-flex'); }
            if (global)  global.classList.remove('d-none');
        };
        window.hideLoader = function () {
            if (overlay) { overlay.classList.add('d-none'); overlay.classList.remove('d-flex'); }
            if (global)  global.classList.add('d-none');
        };
        window.Loader = { show: window.showLoader, hide: window.hideLoader };

        if (window.jQuery) {
            $(document).ajaxStart(window.showLoader);
            $(document).ajaxStop(window.hideLoader);
            $(document).ajaxError(function () { setTimeout(window.hideLoader, 200); });
        }

        window.fetchWithLoader = function (input, init) {
            window.showLoader();
            return fetch(input, init)
                .then(function (res) { setTimeout(window.hideLoader, 150); return res; })
                .catch(function (err) { setTimeout(window.hideLoader, 150); throw err; });
        };

        window.addEventListener('beforeunload', window.showLoader);
        window.addEventListener('load', window.hideLoader);
    }

    function initPaginationAjax() {
        function loadWithAjax(url, target, push) {
            if (!url || !target) return;
            window.showLoader();
            $(target).fadeTo(200, 0.5);
            $.get(url)
                .done(function (result) {
                    $(target).html(result);
                    $(target).fadeTo(200, 1);
                    $('html, body').animate({ scrollTop: $(target).offset().top - 100 }, 300);
                    if (push !== false) history.pushState({ url: url, target: target }, '', url);
                })
                .always(function () { window.hideLoader(); });
        }

        $(document).on('click', '.ajax-page', function (e) {
            e.preventDefault();
            loadWithAjax($(this).data('url'), $(this).data('target'));
        });

        $(document).on('submit', '.ajax-search-form', function (e) {
            e.preventDefault();
            var $f = $(this);
            loadWithAjax($f.attr('action') + '?' + $f.serialize(), $f.data('target') || '#cards-container');
        });

        $(document).on('change', '.ajax-filter', function () {
            var $f = $(this).closest('form.ajax-search-form');
            if ($f.length) $f.trigger('submit');
        });

        window.addEventListener('popstate', function (e) {
            if (e.state && e.state.url && e.state.target) loadWithAjax(e.state.url, e.state.target, false);
        });
    }

    window.VoxTics = {
        showLoading:    function (el, text)             { VoxTicsUtils.showLoading(el, text); },
        hideLoading:    function (el)                   { VoxTicsUtils.hideLoading(el); },
        formatCurrency: function (amt, cur, loc)        { return VoxTicsUtils.formatCurrency(amt, cur, loc); },
        formatDate:     function (date, opts, loc)      { return VoxTicsUtils.formatDate(date, opts, loc); },
        notify:         function (msg, type, opts)      { VoxTicsUtils.notify(msg, type, opts); }
    };

    function initPasswordToggles() {
        document.querySelectorAll('.toggle-password').forEach(function (btn) {
            btn.addEventListener('click', function () {
                var targetId = btn.getAttribute('data-target');
                var input = document.getElementById(targetId);
                if (!input) return;
                var isHidden = input.type === 'password';
                input.type = isHidden ? 'text' : 'password';
                var icon = btn.querySelector('i');
                if (icon) {
                    icon.classList.toggle('bi-eye', !isHidden);
                    icon.classList.toggle('bi-eye-slash', isHidden);
                }
            });
        });
    }

    document.addEventListener('DOMContentLoaded', function () {
        initPasswordToggles();
    });

})();
