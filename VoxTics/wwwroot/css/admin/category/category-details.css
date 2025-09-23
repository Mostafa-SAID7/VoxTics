/* ===== MOVIE DETAILS STYLES ===== */

/* CSS Variables for consistent theming */
:root {
    --primary-color: #007bff;
    --primary-hover: #0056b3;
    --danger-color: #dc3545;
    --danger-hover: #c82333;
    --success-color: #28a745;
    --warning-color: #ffc107;
    --info-color: #17a2b8;
    --dark-color: #343a40;
    --light-color: #f8f9fa;
    --border-color: #dee2e6;
    --shadow-light: 0 2px 4px rgba(0,0,0,0.1);
    --shadow-medium: 0 4px 8px rgba(0,0,0,0.15);
    --shadow-heavy: 0 8px 25px rgba(0,0,0,0.3);
    --border-radius: 8px;
    --transition: all 0.3s ease;
    --gradient-primary: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    --gradient-dark: linear-gradient(135deg, #2c3e50 0%, #34495e 100%);
}

/* Global Styles */
* {
    box-sizing: border-box;
}

body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    line-height: 1.6;
    color: #333;
}

.movie-details-container {
    min-height: 100vh;
    background: linear-gradient(to bottom, #f8f9fa, #e9ecef);
}

/* ===== HERO SECTION ===== */
.hero-section {
    position: relative;
    height: 50vh;
    min-height: 400px;
    display: flex;
    align-items: center;
    justify-content: center;
    overflow: hidden;
}

.hero-background {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-size: cover;
    background-position: center;
    background-repeat: no-repeat;
    filter: blur(5px) brightness(0.3);
    transform: scale(1.1);
    transition: var(--transition);
}

.hero-overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: linear-gradient(45deg, rgba(0,0,0,0.7), rgba(0,0,0,0.3));
}

.hero-content {
    position: relative;
    z-index: 2;
    width: 100%;
    max-width: 1200px;
    padding: 0 2rem;
    display: flex;
    justify-content: space-between;
    align-items: flex-start;
}

.breadcrumb-nav {
    flex: 1;
}

.breadcrumb {
    background: rgba(255,255,255,0.1);
    backdrop-filter: blur(10px);
    border-radius: 25px;
    padding: 0.75rem 1.5rem;
    margin: 0;
    border: 1px solid rgba(255,255,255,0.2);
}

.breadcrumb-item a {
    color: #fff;
    text-decoration: none;
    font-weight: 500;
    transition: var(--transition);
}

    .breadcrumb-item a:hover {
        color: var(--primary-color);
        text-shadow: 0 0 10px rgba(0,123,255,0.5);
    }

.breadcrumb-item.active {
    color: rgba(255,255,255,0.8);
}

.hero-actions {
    display: flex;
    gap: 1rem;
}

    .hero-actions .btn {
        backdrop-filter: blur(10px);
        border: 1px solid rgba(255,255,255,0.3);
        font-weight: 600;
        padding: 0.75rem 1.5rem;
        border-radius: 25px;
        transition: var(--transition);
        text-transform: uppercase;
        letter-spacing: 0.5px;
    }

        .hero-actions .btn:hover {
            transform: translateY(-2px);
            box-shadow: var(--shadow-heavy);
        }

/* ===== CONTENT WRAPPER ===== */
.content-wrapper {
    max-width: 1200px;
    margin: -100px auto 0;
    padding: 0 2rem 2rem;
    position: relative;
    z-index: 3;
}

/* ===== MOVIE HEADER ===== */
.movie-header {
    background: #fff;
    border-radius: var(--border-radius);
    padding: 2rem;
    margin-bottom: 2rem;
    box-shadow: var(--shadow-medium);
    border: 1px solid var(--border-color);
    position: relative;
    overflow: hidden;
}

    .movie-header::before {
        content: '';
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        height: 4px;
        background: var(--gradient-primary);
    }

.movie-title-section {
    margin-bottom: 2rem;
}

.movie-title {
    font-size: 2.5rem;
    font-weight: 700;
    margin-bottom: 1rem;
    color: var(--dark-color);
    text-shadow: 1px 1px 2px rgba(0,0,0,0.1);
}

.movie-meta {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    font-size: 1rem;
    color: #666;
    margin-bottom: 1rem;
}

.meta-item {
    display: flex;
    align-items: center;
    gap: 0.25rem;
}

.meta-separator {
    color: var(--border-color);
    font-weight: bold;
}

.movie-badges {
    display: flex;
    gap: 0.5rem;
    flex-wrap: wrap;
}

.badge {
    padding: 0.5rem 1rem;
    border-radius: 20px;
    font-size: 0.875rem;
    font-weight: 600;
    display: flex;
    align-items: center;
    gap: 0.25rem;
    text-transform: uppercase;
    letter-spacing: 0.5px;
}

.badge-featured {
    background: linear-gradient(135deg, #ffd700, #ffed4e);
    color: #333;
    animation: pulse 2s infinite;
}

.badge-status {
    color: #fff;
}

.badge-nowshowing {
    background: var(--success-color);
}

.badge-upcoming {
    background: var(--info-color);
}

.badge-ended {
    background: var(--dark-color);
}

@keyframes pulse {
    0%, 100% {
        transform: scale(1);
    }

    50% {
        transform: scale(1.05);
    }
}

/* ===== MOVIE STATS ===== */
.movie-stats {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(150px, 1fr));
    gap: 1rem;
    margin-top: 2rem;
}

.stat-card {
    background: linear-gradient(135deg, #f8f9fa, #e9ecef);
    border-radius: var(--border-radius);
    padding: 1.5rem;
    text-align: center;
    border: 1px solid var(--border-color);
    transition: var(--transition);
    position: relative;
    overflow: hidden;
}

    .stat-card::before {
        content: '';
        position: absolute;
        top: 0;
        left: -100%;
        width: 100%;
        height: 100%;
        background: linear-gradient(90deg, transparent, rgba(255,255,255,0.5), transparent);
        transition: left 0.5s;
    }

    .stat-card:hover {
        transform: translateY(-5px);
        box-shadow: var(--shadow-medium);
    }

        .stat-card:hover::before {
            left: 100%;
        }

.stat-icon {
    font-size: 2rem;
    color: var(--primary-color);
    margin-bottom: 0.5rem;
}

.stat-value {
    font-size: 1.5rem;
    font-weight: 700;
    color: var(--dark-color);
    margin-bottom: 0.25rem;
}

.stat-label {
    font-size: 0.875rem;
    color: #666;
    text-transform: uppercase;
    letter-spacing: 0.5px;
}

/* ===== CONTENT GRID ===== */
.content-grid {
    display: grid;
    grid-template-columns: 1fr 2fr;
    gap: 2rem;
    align-items: start;
}

/* ===== MEDIA SECTION ===== */
.media-section {
    display: flex;
    flex-direction: column;
    gap: 2rem;
}

/* Poster */
.poster-container {
    position: sticky;
    top: 2rem;
}

.poster-wrapper {
    position: relative;
    border-radius: var(--border-radius);
    overflow: hidden;
    box-shadow: var(--shadow-heavy);
    transition: var(--transition);
}

    .poster-wrapper:hover {
        transform: scale(1.02);
    }

.main-poster {
    width: 100%;
    height: auto;
    display: block;
    transition: var(--transition);
}

.poster-overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0,0,0,0.5);
    display: flex;
    align-items: center;
    justify-content: center;
    opacity: 0;
    transition: var(--transition);
}

.poster-wrapper:hover .poster-overlay {
    opacity: 1;
}

.btn-play {
    background: rgba(255,255,255,0.9);
    border: none;
    border-radius: 50%;
    width: 60px;
    height: 60px;
    display: flex;
    align-items: center;
    justify-content: center;
    font-size: 1.5rem;
    color: var(--primary-color);
    cursor: pointer;
    transition: var(--transition);
}

    .btn-play:hover {
        transform: scale(1.1);
        background: #fff;
    }

/* Trailer Section */
.trailer-section {
    background: #fff;
    border-radius: var(--border-radius);
    padding: 2rem;
    box-shadow: var(--shadow-light);
    border: 1px solid var(--border-color);
}

.section-title {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    font-size: 1.25rem;
    font-weight: 600;
    margin-bottom: 1.5rem;
    color: var(--dark-color);
}

    .section-title .count {
        color: #666;
        font-weight: 400;
    }

.video-wrapper {
    position: relative;
    width: 100%;
    height: 0;
    padding-bottom: 56.25%; /* 16:9 aspect ratio */
    border-radius: var(--border-radius);
    overflow: hidden;
    box-shadow: var(--shadow-medium);
}

    .video-wrapper iframe {
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        border: 0;
    }

/* Gallery Section */
.gallery-section {
    background: #fff;
    border-radius: var(--border-radius);
    padding: 2rem;
    box-shadow: var(--shadow-light);
    border: 1px solid var(--border-color);
}

.gallery-grid {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(120px, 1fr));
    gap: 1rem;
}

.gallery-item {
    position: relative;
    aspect-ratio: 1;
    border-radius: var(--border-radius);
    overflow: hidden;
    cursor: pointer;
    transition: var(--transition);
}

    .gallery-item:hover {
        transform: scale(1.05);
    }

.gallery-image {
    width: 100%;
    height: 100%;
    object-fit: cover;
    transition: var(--transition);
}

.gallery-overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0,0,0,0.5);
    display: flex;
    align-items: center;
    justify-content: center;
    opacity: 0;
    transition: var(--transition);
    color: #fff;
    font-size: 1.5rem;
}

.gallery-item:hover .gallery-overlay {
    opacity: 1;
}

.more-images {
    background: var(--gradient-dark);
    display: flex;
    align-items: center;
    justify-content: center;
}

.more-overlay {
    color: #fff;
    text-align: center;
    font-size: 1.5rem;
}

/* ===== DETAILS SECTION ===== */
.details-section {
    display: flex;
    flex-direction: column;
    gap: 2rem;
}

.description-card,
.info-card,
.actions-card {
    background: #fff;
    border-radius: var(--border-radius);
    padding: 2rem;
    box-shadow: var(--shadow-light);
    border: 1px solid var(--border-color);
    transition: var(--transition);
}

    .description-card:hover,
    .info-card:hover {
        box-shadow: var(--shadow-medium);
        transform: translateY(-2px);
    }

.description-content p {
    font-size: 1.1rem;
    line-height: 1.8;
    color: #444;
    margin: 0;
}

/* Info Grid */
.info-grid {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    gap: 1.5rem;
}

.info-item {
    display: flex;
    flex-direction: column;
    gap: 0.5rem;
}

.info-label {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    font-weight: 600;
    color: #666;
    text-transform: uppercase;
    font-size: 0.875rem;
    letter-spacing: 0.5px;
}

.info-value {
    font-size: 1.1rem;
    color: var(--dark-color);
    font-weight: 500;
}

.rating-display {
    display: flex;
    align-items: center;
    gap: 0.5rem;
}

.stars {
    display: flex;
    gap: 2px;
}

    .stars i {
        color: #ddd;
        font-size: 1rem;
    }

        .stars i.filled {
            color: #ffd700;
        }

.status-indicator {
    padding: 0.25rem 0.75rem;
    border-radius: 15px;
    font-size: 0.875rem;
    font-weight: 600;
    text-transform: uppercase;
    letter-spacing: 0.5px;
}

.status-nowshowing {
    background: var(--success-color);
    color: #fff;
}

.status-upcoming {
    background: var(--info-color);
    color: #fff;
}

.status-ended {
    background: var(--dark-color);
    color: #fff;
}

/* Action Buttons */
.action-buttons {
    display: flex;
    gap: 1rem;
    flex-wrap: wrap;
}

    .action-buttons .btn {
        flex: 1;
        min-width: 150px;
        padding: 0.75rem 1.5rem;
        font-weight: 600;
        border-radius: 25px;
        transition: var(--transition);
        text-transform: uppercase;
        letter-spacing: 0.5px;
    }

        .action-buttons .btn:hover {
            transform: translateY(-2px);
            box-shadow: var(--shadow-medium);
        }

/* ===== IMAGE VIEWER MODAL ===== */
.image-viewer-modal {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    z-index: 9999;
    display: none;
    background: rgba(0,0,0,0.9);
    backdrop-filter: blur(10px);
}

    .image-viewer-modal.active {
        display: flex;
        align-items: center;
        justify-content: center;
        animation: fadeIn 0.3s ease;
    }

@keyframes fadeIn {
    from {
        opacity: 0;
    }

    to {
        opacity: 1;
    }
}

.viewer-content {
    background: #fff;
    border-radius: var(--border-radius);
    max-width: 90vw;
    max-height: 90vh;
    display: flex;
    flex-direction: column;
    box-shadow: var(--shadow-heavy);
    animation: slideIn 0.3s ease;
}

@keyframes slideIn {
    from {
        opacity: 0;
        transform: scale(0.8) translateY(50px);
    }

    to {
        opacity: 1;
        transform: scale(1) translateY(0);
    }
}

.viewer-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 1rem 2rem;
    border-bottom: 1px solid var(--border-color);
    background: var(--gradient-primary);
    color: #fff;
    border-radius: var(--border-radius) var(--border-radius) 0 0;
}

.viewer-title {
    margin: 0;
    font-size: 1.25rem;
    font-weight: 600;
}

.viewer-controls {
    display: flex;
    gap: 0.5rem;
}

.btn-viewer {
    background: rgba(255,255,255,0.2);
    border: 1px solid rgba(255,255,255,0.3);
    color: #fff;
    border-radius: 50%;
    width: 40px;
    height: 40px;
    display: flex;
    align-items: center;
    justify-content: center;
    cursor: pointer;
    transition: var(--transition);
}

    .btn-viewer:hover {
        background: rgba(255,255,255,0.3);
        transform: scale(1.1);
    }

.viewer-body {
    flex: 1;
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 2rem;
    position: relative;
    min-height: 400px;
}

#viewerImage {
    max-width: 100%;
    max-height: 100%;
    border-radius: var(--border-radius);
    box-shadow: var(--shadow-medium);
}

.viewer-loading {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
}

.spinner {
    width: 40px;
    height: 40px;
    border: 4px solid #f3f3f3;
    border-top: 4px solid var(--primary-color);
    border-radius: 50%;
    animation: spin 1s linear infinite;
}

@keyframes spin {
    0% {
        transform: rotate(0deg);
    }

    100% {
        transform: rotate(360deg);
    }
}

.viewer-footer {
    padding: 1rem 2rem;
    border-top: 1px solid var(--border-color);
    background: var(--light-color);
    border-radius: 0 0 var(--border-radius) var(--border-radius);
}

.viewer-nav {
    display: flex;
    justify-content: center;
    align-items: center;
    gap: 1rem;
}

.btn-nav {
    background: var(--primary-color);
    border: none;
    color: #fff;
    border-radius: 50%;
    width: 40px;
    height: 40px;
    display: flex;
    align-items: center;
    justify-content: center;
    cursor: pointer;
    transition: var(--transition);
}

    .btn-nav:hover {
        background: var(--primary-hover);
        transform: scale(1.1);
    }

    .btn-nav:disabled {
        background: #ccc;
        cursor: not-allowed;
        transform: none;
    }

.image-counter {
    font-weight: 600;
    color: var(--dark-color);
}

/* ===== FLOATING ACTION BUTTON ===== */
.fab-container {
    position: fixed;
    bottom: 2rem;
    right: 2rem;
    z-index: 1000;
    display: none;
}

.fab {
    width: 60px;
    height: 60px;
    border-radius: 50%;
    background: var(--gradient-primary);
    border: none;
    color: #fff;
    font-size: 1.5rem;
    cursor: pointer;
    box-shadow: var(--shadow-heavy);
    transition: var(--transition);
}

    .fab:hover {
        transform: scale(1.1);
    }

.fab-menu {
    position: absolute;
    bottom: 70px;
    right: 0;
    display: flex;
    flex-direction: column;
    gap: 0.5rem;
    opacity: 0;
    visibility: hidden;
    transition: var(--transition);
}

.fab-container.active .fab-menu {
    opacity: 1;
    visibility: visible;
}

.fab-item {
    width: 50px;
    height: 50px;
    border-radius: 50%;
    background: #fff;
    border: 2px solid var(--primary-color);
    color: var(--primary-color);
    display: flex;
    align-items: center;
    justify-content: center;
    text-decoration: none;
    box-shadow: var(--shadow-medium);
    transition: var(--transition);
    transform: scale(0);
    animation: popIn 0.3s ease forwards;
}

    .fab-item:nth-child(1) {
        animation-delay: 0.1s;
    }

    .fab-item:nth-child(2) {
        animation-delay: 0.2s;
    }

    .fab-item:nth-child(3) {
        animation-delay: 0.3s;
    }

@keyframes popIn {
    to {
        transform: scale(1);
    }
}

.fab-item:hover {
    background: var(--primary-color);
    color: #fff;
    transform: scale(1.1);
}

/* ===== RESPONSIVE DESIGN ===== */
@media (max-width: 1024px) {
    .content-grid {
        grid-template-columns: 1fr;
        gap: 1.5rem;
    }

    .movie-stats {
        grid-template-columns: repeat(auto-fit, minmax(120px, 1fr));
    }

    .poster-container {
        position: static;
    }
}

@media (max-width: 768px) {
    .fab-container {
        display: block;
    }

    .hero-content {
        flex-direction: column;
        gap: 2rem;
        text-align: center;
    }

    .hero-actions {
        display: none;
    }

    .movie-title {
        font-size: 2rem;
    }

    .movie-meta {
        flex-wrap: wrap;
        justify-content: center;
    }

    .action-buttons {
        display: none;
    }

    .content-wrapper {
        margin-top: -50px;
        padding: 0 1rem 1rem;
    }

    .movie-header,
    .description-card,
    .info-card,
    .trailer-section,
    .gallery-section {
        padding: 1.5rem;
    }

    .info-grid {
        grid-template-columns: 1fr;
        gap: 1rem;
    }

    .gallery-grid {
        grid-template-columns: repeat(3, 1fr);
    }
}

@media (max-width: 480px) {
    .hero-section {
        height: 40vh;
        min-height: 300px;
    }

    .movie-title {
        font-size: 1.75rem;
    }

    .movie-header,
    .description-card,
    .info-card,
    .trailer-section,
    .gallery-section {
        padding: 1rem;
    }

    .viewer-content {
        max-width: 95vw;
        max-height: 95vh;
    }

    .viewer-header,
    .viewer-footer {
        padding: 1rem;
    }

    .viewer-body {
        padding: 1rem;
    }
}

/* ===== UTILITY CLASSES ===== */
.btn {
    display: inline-flex;
    align-items: center;
    justify-content: center;
    gap: 0.5rem;
    padding: 0.5rem 1rem;
    border: 1px solid transparent;
    border-radius: var(--border-radius);
    font-size: 0.875rem;
    font-weight: 500;
    text-decoration: none;
    cursor: pointer;
    transition: var(--transition);
    text-align: center;
    user-select: none;
}

.btn-primary {
    background: var(--primary-color);
    color: #fff;
    border-color: var(--primary-color);
}

    .btn-primary:hover {
        background: var(--primary-hover);
        border-color: var(--primary-hover);
        color: #fff;
    }

.btn-danger {
    background: var(--danger-color);
    color: #fff;
    border-color: var(--danger-color);
}

    .btn-danger:hover {
        background: var(--danger-hover);
        border-color: var(--danger-hover);
        color: #fff;
    }

.btn-secondary {
    background: #6c757d;
    color: #fff;
    border-color: #6c757d;
}

    .btn-secondary:hover {
        background: #545b62;
        border-color: #545b62;
        color: #fff;
    }

.btn-lg {
    padding: 0.75rem 1.5rem;
    font-size: 1rem;
}

/* ===== ANIMATIONS ===== */
@keyframes slideUp {
    from {
        opacity: 0;
        transform: translateY(50px);
    }

    to {
        opacity: 1;
        transform: translateY(0);
    }
}

.slide-up {
    animation: slideUp 0.6s ease forwards;
}

/* ===== LOADING STATES ===== */
.loading {
    opacity: 0.7;
    pointer-events: none;
}

.skeleton {
    background: linear-gradient(90deg, #f0f0f0 25%, #e0e0e0 50%, #f0f0f0 75%);
    background-size: 200% 100%;
    animation: loading 1.5s infinite;
}

@keyframes loading {
    0% {
        background-position: 200% 0;
    }

    100% {
        background-position: -200% 0;
    }
}

/* ===== TOOLTIP ===== */
[data-tooltip] {
    position: relative;
}

    [data-tooltip]:hover::after {
        content: attr(data-tooltip);
        position: absolute;
        bottom: 100%;
        left: 50%;
        transform: translateX(-50%);
        background: var(--dark-color);
        color: #fff;
        padding: 0.5rem;
        border-radius: 4px;
        font-size: 0.75rem;
        white-space: nowrap;
        z-index: 1000;
        margin-bottom: 5px;
    }

    [data-tooltip]:hover::before {
        content: '';
        position: absolute;
        bottom: 100%;
        left: 50%;
        transform: translateX(-50%);
        border: 5px solid transparent;
        border-top-color: var(--dark-color);
        z-index: 1000;
    }
