    (function() {
        // Enhanced AJAX loading with error handling
        function loadWithAjax(url, target, push = true) {
            if (!url || !target) {
                console.error('Missing URL or target for AJAX pagination');
                return;
            }

            // Show loading state
            const $pagination = $(target).closest('.pagination-container').find('.pagination');
            $pagination.addClass('disabled');
            window.showLoader?.();
            $(target).fadeTo(200, 0.5);

            $.get(url)
                .done(function (result) {
                    $(target).html(result);
                    $(target).fadeTo(200, 1);

                    // Smooth scroll to target
                    const targetPosition = $(target).offset().top - 100;
                    $('html, body').animate({ scrollTop: targetPosition }, 300);

                    // Update browser history
                    if (push && history.pushState) {
                        history.pushState({ url: url, target: target }, "", url);
                    }

                    // Trigger custom event for other components
                    $(document).trigger('ajaxPaginationComplete', [url, target]);
                })
                .fail(function (xhr, status, error) {
                    console.error('Pagination AJAX error:', error);
                    // Show error message
                    const errorMsg = `<div class="alert alert-danger mt-3">Failed to load content. Please try again.</div>`;
                    $(target).html(errorMsg);
                })
                .always(function () {
                    $pagination.removeClass('disabled');
                    window.hideLoader?.();
                });
        }

        // Page click handler
        $(document).on("click", ".ajax-page:not(.disabled)", function(e) {
        e.preventDefault();
    const url = $(this).data("url");
    const target = $(this).data("target");
    loadWithAjax(url, target);
        });

    // Page size change handler
    $(document).on("change", ".ajax-page-size", function() {
            const pageSize = $(this).val();
    const $form = $(this).closest("form.ajax-search-form");
    const target = $form.data("target") || "#cards-container";

    if ($form.length) {
        // Add pageSize to form and submit
        $('<input>').attr({
            type: 'hidden',
            name: 'pageSize',
            value: pageSize
        }).appendTo($form);
    $form.trigger("submit");
            } else {
                // Update current URL with pageSize parameter
                const url = new URL(window.location.href);
    url.searchParams.set('pageSize', pageSize);
    url.searchParams.set('pageIndex', '1'); // Reset to first page
    loadWithAjax(url.toString(), target);
            }
        });

    // Form submission handler
    $(document).on("submit", ".ajax-search-form", function(e) {
        e.preventDefault();
    const $form = $(this);
    const url = $form.attr("action") + "?" + $form.serialize();
    const target = $form.data("target") || "#cards-container";
    loadWithAjax(url, target);
        });

    // Filter change handler
    $(document).on("change", ".ajax-filter", function() {
            const $form = $(this).closest("form.ajax-search-form");
    if ($form.length) {
        // Reset to first page when filters change
        $form.find('input[name="pageIndex"]').remove();
    $('<input>').attr({
        type: 'hidden',
        name: 'pageIndex',
        value: '1'
                }).appendTo($form);
        $form.trigger("submit");
            }
        });

        // Browser history navigation
        window.addEventListener("popstate", function(event) {
            if (event.state && event.state.url && event.state.target) {
            loadWithAjax(event.state.url, event.state.target, false);
            }
        });

        // Keyboard navigation
        $(document).on('keydown', function(e) {
            if (e.ctrlKey) {
                const $pagination = $('.pagination-container:visible');
        if ($pagination.length) {
                    switch(e.key) {
                        case 'ArrowLeft':
        e.preventDefault();
        $pagination.find('.ajax-page:not(.disabled)').first().click();
        break;
        case 'ArrowRight':
        e.preventDefault();
        $pagination.find('.ajax-page:not(.disabled)').last().click();
        break;
                    }
                }
            }
        });
    })();


//// Basic usage
//@await Html.PartialAsync("_Pagination", Model)

//// Advanced usage with options
//@await Html.PartialAsync("_Pagination", Model, new ViewDataDictionary(ViewData) {
//    { "ShowItemCount", true },
//    { "ShowPageSizeSelector", true },
//    { "Alignment", "start" },
//    { "Size", "sm" },
//    { "MaxVisiblePages", 7 }
//})