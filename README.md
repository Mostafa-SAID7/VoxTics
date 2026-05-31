# 🎬 VoxTics - Cinema Booking System

A comprehensive, production-ready cinema booking system built with **ASP.NET Core 9.0** and the **Apple Keyboard+ Design System**. VoxTics provides a complete movie theater management solution with both customer-facing and administrative interfaces.

## ✨ Key Features

### 🎭 Customer Experience
- **Movie Browsing** - Advanced search, filtering, and sorting
- **Cinema Locations** - Multiple locations with detailed information
- **Seat Selection** - Interactive real-time seat availability
- **Secure Payments** - Stripe integration for ticket purchases
- **User Accounts** - Registration, authentication, and profile management
- **Watchlist** - Save favorite movies for later booking

### 👨‍💼 Admin Dashboard
- **Movie Management** - Full CRUD operations for movies and showtimes
- **Cinema Management** - Multiple locations, halls, and seating configurations
- **Booking Oversight** - Monitor and manage customer bookings
- **User Management** - Admin tools for accounts and roles
- **Analytics** - Comprehensive reporting and insights
- **System Settings** - Configurable parameters and preferences

## 🚀 Quick Start

### Prerequisites
- .NET 9.0 SDK
- SQL Server (LocalDB for development)
- Node.js 18+ (for CSS build tools)

### Get Started
```bash
# 1. Navigate to project
cd VoxTics/VoxTics

# 2. Run the application
dotnet run

# 3. Access the application
# Main site: https://localhost:7244
# Admin: https://localhost:7244/Admin
```

**Default Admin Account:**
- Email: SuperAdmin@gmail.com
- Password: Admin123$

## 📚 Documentation

| Document | Purpose |
|----------|---------|
| [Setup Guide](docs/SETUP.md) | Installation, configuration, and database setup |
| [Architecture](docs/ARCHITECTURE.md) | System design and technology stack overview |
| [CSS Architecture](docs/CSS.md) | Design system, components, and styling |
| [JavaScript Architecture](docs/JAVASCRIPT.md) | Frontend modules and functionality |
| [Implementation Status](docs/STATUS.md) | Progress tracking and completion metrics |
| [Changelog](docs/CHANGELOG.md) | Recent updates and improvements |

## 🏗️ Technology Stack

- **Backend**: ASP.NET Core 9.0 MVC with Entity Framework Core 9.0
- **Frontend**: Razor Views with Apple Keyboard+ Design System
- **Database**: SQL Server with Entity Framework migrations
- **Styling**: TailwindCSS + Custom CSS (100+ design tokens)
- **Authentication**: ASP.NET Core Identity with social login
- **Payments**: Stripe integration for secure transactions
- **Build Tools**: Webpack, PostCSS, npm scripts

## 🎨 Design System

VoxTics uses the **Apple Keyboard+ Design System** - a custom design language inspired by Apple's Human Interface Guidelines:

- ✅ **Consistent Visual Language** - Apple-inspired colors, typography, spacing
- ✅ **Component Library** - 50+ reusable UI components
- ✅ **Accessibility First** - WCAG 2.1 AA compliance built-in
- ✅ **Dark Mode** - Automatic system preference detection
- ✅ **Responsive Design** - Mobile-first approach with fluid layouts
- ✅ **Zero Page-Specific CSS** - All styling through global components

## 📁 Project Structure

```
VoxTics/
├── Areas/
│   ├── Admin/              # Admin dashboard & management
│   └── Identity/           # Authentication & user management
├── Controllers/            # MVC controllers
├── Data/                   # Database context & configurations
├── Models/                 # Domain entities & view models
├── Services/               # Business logic layer
├── Repositories/           # Data access layer
├── Views/                  # Razor view templates
├── wwwroot/
│   ├── css/                # Global design system
│   ├── js/                 # Modular JavaScript
│   └── images/             # Static assets
└── Program.cs              # Application entry point
```

## 🛠️ Development

### Available Commands

```bash
# Development
npm run dev                 # Start with hot reload
npm run build-css          # Build CSS only
dotnet watch run           # Start .NET with hot reload

# Building
npm run build              # Production build
npm run clean              # Clean build artifacts

# Code Quality
npm run lint-css           # Lint CSS
npm run format             # Format code
npm run security-audit     # Security audit
```

### Database Migrations

```bash
# Add migration
dotnet ef migrations add MigrationName --project VoxTics

# Update database
dotnet ef database update --project VoxTics

# Drop database (development only)
dotnet ef database drop --project VoxTics
```

## 🔐 Configuration

Edit `appsettings.json` to configure:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=VoxTicsDB;Trusted_Connection=True;..."
  },
  "Stripe": {
    "SecretKey": "sk_test_...",
    "PublishableKey": "pk_test_..."
  },
  "Email": {
    "From": "no-reply@voxtics.com",
    "Smtp": {
      "Host": "smtp.gmail.com",
      "Port": 587,
      "User": "your-email@gmail.com",
      "Pass": "your-app-password"
    }
  }
}
```

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

This project is licensed under the MIT License - see [LICENSE.txt](LICENSE.txt) for details.

## 🙏 Acknowledgments

- Apple Human Interface Guidelines for design inspiration
- TailwindCSS for utility-first CSS framework
- ASP.NET Core team for the excellent web framework
- Bootstrap Icons for the icon library

---

**Status**: ✅ Production Ready | **Framework**: ASP.NET Core 9.0 | **Database**: SQL Server | **Last Updated**: May 31, 2026