(function () {
    'use strict';

    document.addEventListener('DOMContentLoaded', function () {
        initMovieDetailsAdmin();
    });

    function initMovieDetailsAdmin() {
        const thumbnails = document.querySelectorAll('.movie-thumbnail');
        const mainImage = document.querySelector('#main-movie-image');

        thumbnails.forEach(function (thumb) {
            thumb.addEventListener('click', function () {
                if (mainImage) {
                    mainImage.src = this.dataset.fullsize || this.src;
                }
                thumbnails.forEach(function (t) { t.classList.remove('active'); });
                this.classList.add('active');
            });
        });
    }
})();
