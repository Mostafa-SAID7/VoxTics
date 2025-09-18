// Document ready function
$(document).ready(function () {
    // Hide loading overlay
    $("#loadingOverlay").fadeOut(500);

    // Initialize tooltips
    $('[data-bs-toggle="tooltip"]').tooltip();

    // Back to top button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $('#backToTop').fadeIn();
        } else {
            $('#backToTop').fadeOut();
        }
    });

    $('#backToTop').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 800);
        return false;
    });

    // Navbar scroll effect
    $(window).scroll(function () {
        if ($(window).scrollTop() > 50) {
            $('#mainNavbar').addClass('scrolled');
        } else {
            $('#mainNavbar').removeClass('scrolled');
        }
    });

    // Animate elements on scroll
    function animateOnScroll() {
        $('.animate-on-scroll').each(function () {
            var position = $(this).offset().top;
            var scroll = $(window).scrollTop();
            var windowHeight = $(window).height();

            if (scroll + windowHeight - 100 > position) {
                $(this).addClass('animate-visible');
            }
        });
    }

    // Initial call
    animateOnScroll();

    // Call on scroll
    $(window).scroll(function () {
        animateOnScroll();
    });

    // Search form animation
    $('.search-input').focus(function () {
        $(this).parent().addClass('focused');
    }).blur(function () {
        $(this).parent().removeClass('focused');
    });

    // User dropdown animation
    $('.user-dropdown').hover(function () {
        $(this).find('.dropdown-menu').stop(true, true).fadeIn(300);
    }, function () {
        $(this).find('.dropdown-menu').stop(true, true).fadeOut(200);
    });

    // Mobile menu close on click
    $('.navbar-nav li a').on('click', function () {
        $('.navbar-collapse').collapse('hide');
    });

    // Toastr notification configuration
    toastr.options = {
        closeButton: true,
        progressBar: true,
        positionClass: "toast-bottom-right",
        timeOut: 5000
    };

    // Example notification (can be removed)
    // toastr.success('Welcome to VoxTics Cinema!');

    // Initialize any carousels
    $('.carousel').carousel({
        interval: 5000,
        pause: 'hover'
    });

    // Lazy loading for images
    $('img').each(function () {
        if ($(this).attr('data-src')) {
            $(this).attr('src', $(this).attr('data-src'));
        }
    });

    // Form validation enhancement
    $('form').on('submit', function () {
        $(this).find('button[type="submit"]').prop('disabled', true).html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Loading...');
    });
});

// Page transition effect
$(window).on('beforeunload', function () {
    $("#loadingOverlay").fadeIn(300);
});

// Handle browser back button
window.onpageshow = function (event) {
    if (event.persisted) {
        $("#loadingOverlay").fadeOut(300);
    }
};