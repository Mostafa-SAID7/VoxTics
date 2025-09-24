    // Showtime selection functionality
    function selectShowtime(movieTitle, startTime) {
        showNotification(`Selected: ${movieTitle} at ${startTime}`);
        // Here you would typically navigate to booking page or open a modal
        // window.location.href = `/Booking?movie=${encodeURIComponent(movieTitle)}&time=${encodeURIComponent(startTime)}`;
    }

    // Notification system
    function showNotification(message, type = 'info') {
        const notification = document.createElement('div');
    const bgColor = type === 'success' ? 'rgba(46, 204, 113, 0.9)' :
    type === 'error' ? 'rgba(231, 76, 60, 0.9)' :
    'rgba(52, 152, 219, 0.9)';

    notification.style.cssText = `
    position: fixed;
    top: 20px;
    right: 20px;
    background: ${bgColor};
    color: white;
    padding: 1rem 2rem;
    border-radius: 15px;
    z-index: 1000;
    animation: slideInRight 0.3s ease-out;
    backdrop-filter: blur(10px);
    box-shadow: 0 10px 25px rgba(0,0,0,0.2);
    max-width: 400px;
    font-weight: 500;
    `;
    notification.textContent = message;
    document.body.appendChild(notification);

        setTimeout(() => {
        notification.style.animation = 'slideOutRight 0.3s ease-in';
            setTimeout(() => notification.remove(), 300);
        }, 3000);
    }

    // Image loading with fallback
    document.querySelector('.cinema-image').addEventListener('error', function() {
        this.src = `data:image/svg+xml;base64,${btoa(`
            <svg width="400" height="400" xmlns="http://www.w3.org/2000/svg">
                <rect width="400" height="400" fill="#667eea"/>
                <text x="50%" y="50%" font-family="Arial" font-size="24" fill="white" text-anchor="middle" dy=".3em">
                    ?? ${this.alt}
                </text>
            </svg>
        `)}`;
    });

    // Smooth loading animation
    window.addEventListener('load', function() {
        const cards = document.querySelectorAll('.info-card, .stat-card');
        cards.forEach((card, index) => {
        card.style.opacity = '0';
    card.style.transform = 'translateY(30px)';

            setTimeout(() => {
        card.style.transition = 'all 0.6s ease-out';
    card.style.opacity = '1';
    card.style.transform = 'translateY(0)';
            }, index * 100);
        });
    });

    // Interactive hover effects
    document.querySelectorAll('.showtime-card').forEach(card => {
        card.addEventListener('click', function () {
            this.style.transform = 'scale(0.98)';
            setTimeout(() => {
                this.style.transform = 'translateY(-3px)';
            }, 150);
        });
    });

    // Add slide animations
    const style = document.createElement('style');
    style.textContent = `
    @keyframes slideInRight {
        from {transform: translateX(100%); opacity: 0; }
    to {transform: translateX(0); opacity: 1; }
        }
    @keyframes slideOutRight {
        from {transform: translateX(0); opacity: 1; }
    to {transform: translateX(100%); opacity: 0; }
        }
    `;
    document.head.appendChild(style);
