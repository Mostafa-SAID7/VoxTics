# VoxTics Technology Stack

## Backend Framework
- **ASP.NET Core 9.0 MVC** - Main web framework
- **Entity Framework Core 9.0** - ORM with SQL Server provider
- **ASP.NET Core Identity** - Authentication and user management
- **AutoMapper** - Object-to-object mapping

## Frontend Technologies
- **Razor Views** - Server-side rendering with .cshtml templates
- **TailwindCSS** - Utility-first CSS framework with Apple Keyboard+ design system
- **Alpine.js** - Lightweight JavaScript framework for interactivity
- **HTMX** - Modern HTML-driven interactions

## Database & Storage
- **SQL Server** - Primary database
- **Entity Framework Migrations** - Database schema management
- **Image Storage** - File system based image management

## External Services
- **Stripe** - Payment processing
- **Email Services** - SMTP-based email notifications
- **Social Authentication** - Google and Facebook OAuth

## Build Tools & Asset Pipeline
- **Webpack** - JavaScript bundling and optimization
- **PostCSS** - CSS processing with autoprefixer
- **Stylelint** - CSS linting and formatting
- **npm scripts** - Build automation

## Development Tools
- **BCrypt.Net** - Password hashing
- **QRCoder** - QR code generation
- **ImageSharp** - Image processing

## Common Commands

### Development
```bash
# Start development with hot reload
npm run dev

# Build CSS only
npm run build-css

# Run .NET application with watch
dotnet watch run --project VoxTics
```

### Building
```bash
# Production build
npm run build

# Fast build (CSS + .NET)
npm run build-fast

# Clean build artifacts
npm run clean
```

### Database
```bash
# Add migration
dotnet ef migrations add MigrationName --project VoxTics

# Update database
dotnet ef database update --project VoxTics

# Drop database
dotnet ef database drop --project VoxTics
```

### Code Quality
```bash
# Format code
npm run format

# Lint CSS
npm run lint-css

# Security audit
npm run security-audit
```

### Testing & Analysis
```bash
# Analyze bundle size
npm run bundle-analyze

# Check for duplicate code
npm run audit-duplicates

# Accessibility testing
npm run accessibility-test
```