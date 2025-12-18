# VoxTics Cinema Booking System

A comprehensive cinema booking system built with ASP.NET Core MVC and the Apple Keyboard+ Design System. VoxTics provides a complete movie theater management solution with both customer-facing and administrative interfaces.

## 🎬 Features

### Customer Experience
- **Movie Browsing**: Discover movies with advanced search, filtering, and sorting
- **Cinema Locations**: Multiple cinema locations with detailed information
- **Seat Selection**: Interactive seat selection with real-time availability
- **Secure Payments**: Stripe integration for secure ticket purchases
- **User Accounts**: Registration, authentication, and profile management
- **Watchlist**: Save favorite movies for later booking

### Administrative Interface
- **Movie Management**: Full CRUD operations for movies, categories, and showtimes
- **Cinema Management**: Manage multiple locations, halls, and seating configurations
- **Booking Oversight**: Monitor and manage customer bookings
- **User Management**: Admin tools for user accounts and roles
- **Analytics Dashboard**: Comprehensive reporting and analytics
- **System Settings**: Configurable system parameters and preferences

## 🏗️ Architecture

### Technology Stack
- **Backend**: ASP.NET Core 9.0 MVC with Entity Framework Core
- **Frontend**: Razor Views with Apple Keyboard+ Design System
- **Database**: SQL Server with Entity Framework migrations
- **Styling**: TailwindCSS + Custom CSS with Apple-inspired design
- **Build Tools**: Webpack, PostCSS, npm scripts
- **Authentication**: ASP.NET Core Identity with social login support

### Design System
VoxTics uses the **Apple Keyboard+ Design System**, a custom design language inspired by Apple's Human Interface Guidelines:

- **Consistent Visual Language**: Apple-inspired colors, typography, and spacing
- **Component Library**: Reusable UI components with consistent behavior
- **Accessibility First**: WCAG compliance with reduced motion and high contrast support
- **Dark Mode**: Comprehensive dark mode implementation
- **Responsive Design**: Mobile-first approach with fluid layouts

## 🚀 Quick Start

### Prerequisites
- .NET 9.0 SDK
- Node.js 18+ and npm
- SQL Server (LocalDB for development)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-org/voxtics.git
   cd voxtics
   ```

2. **Install dependencies**
   ```bash
   # Install npm packages
   npm install
   
   # Restore .NET packages
   dotnet restore
   ```

3. **Configure the database**
   ```bash
   # Update connection string in appsettings.json
   # Run migrations
   dotnet ef database update --project VoxTics
   ```

4. **Start development**
   ```bash
   # Start with hot reload (CSS + .NET)
   npm run dev
   
   # Or start components separately
   npm run build-css    # Build CSS
   dotnet watch run --project VoxTics  # Start .NET with hot reload
   ```

5. **Access the application**
   - Main site: `https://localhost:7244`
   - Admin panel: `https://localhost:7244/Admin`

## 📁 Project Structure

```
VoxTics/
├── Areas/
│   ├── Admin/              # Administrative interface
│   └── Identity/           # Authentication & user management
├── Controllers/            # Main MVC controllers
├── Data/                   # Database context & configurations
├── Models/                 # Domain entities & view models
├── Services/               # Business logic layer
├── Repositories/           # Data access layer
├── Views/                  # Razor view templates
├── wwwroot/               # Static assets
│   ├── css/
│   │   ├── foundation/              # CSS variables & design tokens
│   │   ├── base/                    # Reset, typography, base styles
│   │   ├── components/              # Reusable UI components
│   │   ├── utilities/               # Layout & responsive utilities
│   │   ├── critical.css             # Critical above-fold styles
│   │   ├── input.css               # TailwindCSS source
│   │   └── voxtics-global.css      # Main compiled stylesheet
│   ├── js/                # JavaScript files
│   └── images/            # Static images
└── Program.cs             # Application entry point
```

## 🎨 Frontend Architecture

VoxTics uses a **modern frontend architecture** with both CSS and JavaScript organized for maintainability and performance:

### CSS Architecture
**Global Design System** that eliminates page-specific stylesheets:

#### Architecture Layers
1. **Foundation Layer**: CSS variables and design tokens (`foundation/*.css`)
2. **Base Layer**: Reset, typography, and base element styles (`base/*.css`)
3. **Component Layer**: Reusable UI components (`components/*.css`)
4. **Utility Layer**: Layout and responsive utilities (`utilities/*.css`)
5. **TailwindCSS Integration**: Custom tokens and utility classes

#### Key CSS Features ✨
- **🎯 Zero Page-Specific CSS**: All styling through global components and utilities
- **🎨 Comprehensive Design Tokens**: 100+ CSS variables for consistent theming
- **🌙 Automatic Dark Mode**: System preference detection with manual override
- **📱 Mobile-First Responsive**: Consistent breakpoints across all components
- **♿ Accessibility Built-In**: High contrast, reduced motion, and ARIA support
- **⚡ Performance Optimized**: CSS purging and critical path optimization

### JavaScript Architecture
**Modular JavaScript System** with ES6 classes and performance optimization:

#### Core Modules
- **Global Utilities** (`site.js`): Bootstrap initialization, lazy loading, utility functions
- **Public Site** (`main/main.js`): Search, filters, watchlist, rating system
- **Movie Details** (`main/movies/moviedetails.js`): Comprehensive movie page functionality
- **Admin Interface**: Dedicated admin JavaScript modules *(planned)*

#### Key JavaScript Features ⚡
- **🏗️ Modular Architecture**: ES6 classes with clear separation of concerns
- **🛡️ Comprehensive Error Handling**: Multi-tier fallback systems for reliability
- **📊 Performance Monitoring**: Built-in performance tracking and optimization
- **🔄 Modern APIs**: Clipboard API, Intersection Observer with legacy fallbacks
- **🎯 Event Delegation**: Efficient event handling for dynamic content
- **🌐 Cross-Browser Support**: Modern JavaScript with graceful degradation

### Component System
```css
/* Button Components */
.btn, .btn-primary, .btn-secondary, .btn-success, .btn-warning, .btn-danger

/* Form Components */
.form-control, .form-label, .form-group, .form-check, .form-switch

/* Card Components */
.card, .movie-card, .cinema-card, .booking-card, .admin-card

/* VoxTics-Specific */
.movie-poster, .seat-map, .showtime-grid, .admin-dashboard
```

### Recent Achievements 🚀
- **✅ Complete page-specific CSS elimination** - No more duplicate styles
- **✅ Global component library** - 50+ reusable components implemented
- **✅ Semantic design tokens** - VoxTics-specific tokens for movies, seats, admin
- **✅ Theme system** - Light/dark mode with accessibility preferences
- **✅ TailwindCSS integration** - Custom Apple Keyboard+ design system tokens
- **✅ Cross-browser compatibility** - Enhanced text truncation with standard line-clamp support
- **✅ JavaScript syntax fixes** - Resolved critical syntax errors in moviedetails.js (December 2024)
- **✅ Modular JavaScript architecture** - ES6 classes with performance monitoring and error isolation
- **✅ Error handling improvements** - Multi-tier notification system with graceful fallbacks
- **✅ Configuration validation** - Structured configuration objects with proper validation

## 🛠️ Development

### Available Scripts

```bash
# Development
npm run dev                 # Start development with hot reload
npm run build-css          # Build CSS only
dotnet watch run --project VoxTics  # Start .NET with hot reload

# Building
npm run build              # Production build
npm run build-fast         # Fast build (CSS + .NET)
npm run clean              # Clean build artifacts

# Code Quality
npm run format             # Format code
npm run lint-css           # Lint CSS
npm run security-audit     # Security audit

# Analysis
npm run bundle-analyze     # Analyze bundle size
npm run audit-duplicates   # Check for duplicate code
npm run accessibility-test # Accessibility testing
```

### Database Commands

```bash
# Add migration
dotnet ef migrations add MigrationName --project VoxTics

# Update database
dotnet ef database update --project VoxTics

# Drop database (development only)
dotnet ef database drop --project VoxTics
```

## 🔧 Configuration

### Environment Variables
- `ConnectionStrings:DefaultConnection` - Database connection string
- `Stripe:PublishableKey` - Stripe publishable key
- `Stripe:SecretKey` - Stripe secret key
- `EmailSettings:*` - SMTP configuration for notifications

### Admin Account
The system creates a default admin account on first run:
- **Username**: SuperAdmin
- **Email**: SuperAdmin@gmail.com
- **Password**: Admin123$

## 📚 Documentation

- [CSS Architecture Guide](docs/css-architecture.md) - Complete guide to the Apple Keyboard+ Design System
- [JavaScript Architecture Guide](docs/javascript-architecture.md) - Frontend JavaScript modules and functionality
- [CSS Optimization Report](ADMIN_CSS_ANALYSIS.md) - Recent refactoring and performance improvements
- [API Documentation](docs/api.md) *(coming soon)*
- [Deployment Guide](docs/deployment.md) *(coming soon)*

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Code Standards
- Follow C# naming conventions (PascalCase for classes, camelCase for variables)
- Use CSS custom properties for theming
- Write accessible HTML with proper ARIA attributes
- Include unit tests for new features

## 📄 License

This project is licensed under the MIT License - see the [LICENSE.txt](LICENSE.txt) file for details.

## 🙏 Acknowledgments

- Apple Human Interface Guidelines for design inspiration
- TailwindCSS for utility-first CSS framework
- ASP.NET Core team for the excellent web framework
- Bootstrap Icons for the icon library