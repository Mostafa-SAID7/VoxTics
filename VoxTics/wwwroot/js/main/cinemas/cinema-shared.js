// VoxTics - Cinema Shared Utilities
// Common cinema interaction handlers reused across the cinemas list and detail pages

(function(window) {
    'use strict';

    window.CinemaShared = {
        handleCall: function(e) {
            e.preventDefault();
            e.stopPropagation();
            const phone = (e.currentTarget || e.target).dataset.phone;
            if (phone) window.location.href = 'tel:' + phone;
        },

        toggleFavorite: function(btn, updateButtonFn) {
            const cinemaId = btn.dataset.cinemaId;
            VoxTicsUtils.showLoading(btn, 'Updating...');
            new VoxTicsUtils.ApiService()
                .post('/Cinemas/ToggleFavorite', { cinemaId: cinemaId })
                .then(function(data) {
                    if (data.success) {
                        updateButtonFn(btn, data.isFavorite);
                        VoxTicsUtils.notify(data.message, 'success');
                    } else {
                        VoxTicsUtils.notify(data.message || 'Error updating favorite', 'error');
                    }
                })
                .catch(function(error) {
                    console.error('Error:', error);
                    VoxTicsUtils.notify('Error updating favorite', 'error');
                })
                .finally(function() {
                    VoxTicsUtils.hideLoading(btn);
                });
        }
    };

})(window);
