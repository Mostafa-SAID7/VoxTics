    // Create animated particles
    function createParticles() {
        const particlesContainer = document.getElementById('particles');
    const particleCount = 20;

    for (let i = 0; i < particleCount; i++) {
            const particle = document.createElement('div');
    particle.className = 'particle';
    particle.style.width = Math.random() * 4 + 2 + 'px';
    particle.style.height = particle.style.width;
    particle.style.left = Math.random() * 100 + '%';
    particle.style.top = Math.random() * 100 + '%';
    particle.style.animationDelay = Math.random() * 6 + 's';
    particle.style.animationDuration = (Math.random() * 3 + 3) + 's';
    particlesContainer.appendChild(particle);
        }
    }

    // Enhanced search with loading animation
    let searchTimeout;
    document.getElementById('searchInput').addEventListener('input', function(e) {
        const term = e.target.value.toLowerCase();
    const loadingSpinner = document.getElementById('loadingSpinner');
    const movieList = document.getElementById('movieList');

    clearTimeout(searchTimeout);

        if (term.length > 0) {
        loadingSpinner.style.display = 'block';
    movieList.style.opacity = '0.5';
        }

        searchTimeout = setTimeout(() => {
        document.querySelectorAll('#movieList .movie-card').forEach(card => {
            const shouldShow = card.dataset.title.includes(term);
            const cardColumn = card.closest('.col-xl-3, .col-lg-4, .col-md-6, .col-sm-12');

            if (shouldShow) {
                cardColumn.style.display = 'block';
                cardColumn.style.animation = 'fadeInUp 0.5s ease-out';
            } else {
                cardColumn.style.display = 'none';
            }
        });

    loadingSpinner.style.display = 'none';
    movieList.style.opacity = '1';
        }, term.length > 0 ? 500 : 0);
    });

    // Enhanced card interactions
    document.querySelectorAll('.movie-card').forEach((card, index) => {
        // Staggered animation delay
        card.style.animationDelay = (index * 0.1) + 's';

    card.addEventListener('click', function(e) {
            if (!e.target.closest('a') && !e.target.closest('.play-btn')) {
                const url = this.querySelector('.btn-details').href;

    // Add click animation
    this.style.transform = 'scale(0.95)';
                setTimeout(() => {
        this.style.transform = '';
    window.location.href = url;
                }, 150);
            }
        });

    // Play button special effect
    const playBtn = card.querySelector('.play-btn');
    playBtn.addEventListener('click', function(e) {
        e.stopPropagation();

    // Create ripple effect
    const ripple = document.createElement('div');
    ripple.style.cssText = `
    position: absolute;
    border-radius: 50%;
    background: rgba(255, 255, 255, 0.6);
    transform: scale(0);
    animation: ripple 0.6s linear;
    pointer-events: none;
    `;

    const rect = this.getBoundingClientRect();
    const size = 100;
    ripple.style.width = ripple.style.height = size + 'px';
    ripple.style.left = (rect.width / 2 - size / 2) + 'px';
    ripple.style.top = (rect.height / 2 - size / 2) + 'px';

    this.appendChild(ripple);

            setTimeout(() => ripple.remove(), 600);
        });
    });

    // Initialize particles
    createParticles();

    // Smooth scroll for pagination
    document.querySelectorAll('.pagination .page-link').forEach(link => {
        link.addEventListener('click', function (e) {
            if (this.getAttribute('href') && this.getAttribute('href').includes('page=')) {
                e.preventDefault();
                document.body.style.opacity = '0.8';
                setTimeout(() => {
                    window.location.href = this.href;
                }, 200);
            }
        });
    });

    // Add CSS for ripple animation
    const style = document.createElement('style');
    style.textContent = `
    @keyframes ripple {
        to {
        transform: scale(4);
    opacity: 0;
            }
        }
    `;
    document.head.appendChild(style);
