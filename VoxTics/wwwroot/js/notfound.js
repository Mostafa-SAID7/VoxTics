    // Optional: Particle animation background
    document.addEventListener('DOMContentLoaded', () => {
        const body = document.body;
    const particles = 50;

    for (let i = 0; i < particles; i++) {
            const span = document.createElement('span');
    span.style.position = 'absolute';
    span.style.background = '#007bff';
    span.style.width = `${Math.random() * 5 + 3}px`;
    span.style.height = `${Math.random() * 5 + 3}px`;
    span.style.borderRadius = '50%';
    span.style.top = `${Math.random() * window.innerHeight}px`;
    span.style.left = `${Math.random() * window.innerWidth}px`;
    span.style.opacity = Math.random();
    span.style.animation = `particleMove ${Math.random() * 5 + 3}s linear infinite`;
    body.appendChild(span);
        }
    });

    // Particle animation keyframes dynamically injected
    const style = document.createElement('style');
    style.innerHTML = `
    @keyframes particleMove {
        0 % { transform: translateY(0); opacity: 0.5; }
            50% {transform: translateY(-50px); opacity: 1; }
    100% {transform: translateY(0); opacity: 0.5; }
        }
    `;
    document.head.appendChild(style);
