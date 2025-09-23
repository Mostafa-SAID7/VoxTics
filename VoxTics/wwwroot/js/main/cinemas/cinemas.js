    // Search functionality
    const searchInput = document.getElementById('searchInput');
    const cinemasGrid = document.getElementById('cinemasGrid');
    const noResults = document.getElementById('noResults');
    const cinemaCards = document.querySelectorAll('.cinema-card');

    searchInput.addEventListener('input', function() {
        const searchTerm = this.value.toLowerCase().trim();
    let visibleCards = 0;

        cinemaCards.forEach(card => {
            const name = card.dataset.name;
    const country = card.dataset.country;

    if (name.includes(searchTerm) || country.includes(searchTerm)) {
        card.style.display = 'block';
    card.style.animation = 'fadeInUp 0.5s ease-out';
    visibleCards++;
            } else {
        card.style.display = 'none';
            }
        });

    if (visibleCards === 0 && searchTerm !== '') {
        noResults.style.display = 'block';
    noResults.style.animation = 'fadeInUp 0.5s ease-out';
        } else {
        noResults.style.display = 'none';
        }
    });

    // Favorite functionality
    function toggleFavorite(cinemaId) {
        const button = event.target;
    const isFavorite = button.textContent.includes('??');

    if (isFavorite) {
        button.innerHTML = '?? Favorite';
    button.style.background = 'rgba(255,255,255,0.1)';
    showNotification(`Removed from favorites`);
        } else {
        button.innerHTML = '?? Favorite';
    button.style.background = 'linear-gradient(45deg, #ff6b6b, #ee5a24)';
    showNotification(`Added to favorites!`);
        }

        // Here you would typically make an AJAX call to update the server
        // Example:
        // fetch(`/Cinemas/ToggleFavorite/${cinemaId}`, {method: 'POST' })
        //     .then(response => response.json())
        //     .then(data => console.log(data));
    }

    // Notification system
    function showNotification(message) {
        const notification = document.createElement('div');
    notification.style.cssText = `
    position: fixed;
    top: 20px;
    right: 20px;
    background: rgba(0,0,0,0.8);
    color: white;
    padding: 1rem 1.5rem;
    border-radius: 10px;
    z-index: 1000;
    animation: slideInRight 0.3s ease-out;
    backdrop-filter: blur(10px);
    `;
    notification.textContent = message;
    document.body.appendChild(notification);

        setTimeout(() => {
        notification.style.animation = 'slideOutRight 0.3s ease-in';
            setTimeout(() => notification.remove(), 300);
        }, 2000);
    }

    // Add slide animations
    const style = document.createElement('style');
    style.textContent = `
    @@keyframes slideInRight {
        from {transform: translateX(100%); opacity: 0; }
    to {transform: translateX(0); opacity: 1; }
        }
    @@keyframes slideOutRight {
        from {transform: translateX(0); opacity: 1; }
    to {transform: translateX(100%); opacity: 0; }
        }
    `;
    document.head.appendChild(style);

    // Card hover effects
    cinemaCards.forEach(card => {
        card.addEventListener('mouseenter', function () {
            this.style.transform = 'translateY(-8px) scale(1.02)';
        });

    card.addEventListener('mouseleave', function() {
        this.style.transform = 'translateY(0) scale(1)';
        });
    });

    // Smooth loading animation
    window.addEventListener('load', function() {
        cinemaCards.forEach((card, index) => {
            card.style.opacity = '0';
            card.style.transform = 'translateY(30px)';

            setTimeout(() => {
                card.style.transition = 'all 0.6s ease-out';
                card.style.opacity = '1';
                card.style.transform = 'translateY(0)';
            }, index * 100);
        });
    });
