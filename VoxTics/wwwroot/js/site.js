// Enhanced interactivity for the movie booking system
        document.addEventListener('DOMContentLoaded', function() {
            // View toggle functionality
            const viewButtons = document.querySelectorAll('.view-btn');
            viewButtons.forEach(button => {
                button.addEventListener('click', function() {
                    viewButtons.forEach(btn => btn.classList.remove('active'));
                    this.classList.add('active');
                    
                    // Here you would toggle between grid and list view
                    const movieGrid = document.querySelector('.movie-grid');
                    if (this.textContent.includes('List')) {
                        movieGrid.style.gridTemplateColumns = '1fr';
                    } else {
                        movieGrid.style.gridTemplateColumns = 'repeat(auto-fill, minmax(300px, 1fr))';
                    }
                });
            });
            
            // Favorite button functionality
            const favoriteButtons = document.querySelectorAll('.btn-secondary');
            favoriteButtons.forEach(button => {
                button.addEventListener('click', function() {
                    const icon = this.querySelector('i');
                    if (icon.classList.contains('far')) {
                        icon.classList.replace('far', 'fas');
                        this.style.color = '#e74c3c';
                    } else {
                        icon.classList.replace('fas', 'far');
                        this.style.color = '';
                    }
                });
            });
            
            // Search functionality
            const searchBox = document.querySelector('.search-box input');
            searchBox.addEventListener('keyup', function() {
                const searchTerm = this.value.toLowerCase();
                const movieCards = document.querySelectorAll('.movie-card');
                
                movieCards.forEach(card => {
                    const title = card.querySelector('.movie-title').textContent.toLowerCase();
                    if (title.includes(searchTerm)) {
                        card.style.display = 'block';
                    } else {
                        card.style.display = 'none';
                    }
                });
            });
            
            // Advanced filters toggle
            const toggleAdvanced = document.getElementById('toggleAdvanced');
            const advancedFilters = document.getElementById('advancedFilters');
            
            toggleAdvanced.addEventListener('click', function() {
                advancedFilters.classList.toggle('active');
                
                if (advancedFilters.classList.contains('active')) {
                    this.innerHTML = '<i class="fas fa-times"></i> Close Filters';
                } else {
                    this.innerHTML = '<i class="fas fa-cog"></i> Advanced Filters';
                }
            });
            
            // Rating slider
            const ratingSlider = document.getElementById('rating');
            const ratingValue = document.getElementById('ratingValue');
            
            ratingSlider.addEventListener('input', function() {
                ratingValue.textContent = this.value;
            });
            
            // Date selection
            const dateOptions = document.querySelectorAll('.date-option');
            dateOptions.forEach(option => {
                option.addEventListener('click', function() {
                    dateOptions.forEach(opt => opt.classList.remove('active'));
                    this.classList.add('active');
                });
            });
            
            // Time slot selection
            const timeSlots = document.querySelectorAll('.time-slot');
            timeSlots.forEach(slot => {
                slot.addEventListener('click', function() {
                    timeSlots.forEach(s => s.style.backgroundColor = '');
                    timeSlots.forEach(s => s.style.color = '');
                    
                    this.style.backgroundColor = var(--accent);
                    this.style.color = 'white';
                });
            });
            
            // Animate elements on scroll
            const animatedElements = document.querySelectorAll('.animated');
            
            const observer = new IntersectionObserver((entries) => {
                entries.forEach(entry => {
                    if (entry.isIntersecting) {
                        entry.target.style.opacity = 1;
                    }
                });
            }, { threshold: 0.1 });
            
            animatedElements.forEach(el => {
                el.style.opacity = 0;
                el.style.transition = 'opacity 0.5s ease-in-out';
                observer.observe(el);
            });
        });