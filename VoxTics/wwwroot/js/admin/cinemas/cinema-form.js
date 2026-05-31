(function () {
    'use strict';

    window.previewFile = function (input) {
        var file = input.files[0];
        if (!file) return;
        var reader = new FileReader();
        reader.onload = function (e) {
            var preview = document.getElementById('previewImage');
            if (preview) preview.src = e.target.result;
        };
        reader.readAsDataURL(file);
    };

})();
