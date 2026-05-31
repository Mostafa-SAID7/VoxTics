# 🏗️ VoxTics Architecture

Complete system architecture and technology stack overview for VoxTics.

## System Overview

VoxTics is a modern, scalable cinema booking system built with a clean architecture pattern:

```
┌─────────────────────────────────────────────────────────────┐
│                    Presentation Layer                        │
│  (Razor Views + Apple Keyboard+ Design System)              │
└─────────────────────────────────────────────────────────────┘
                            ↓
┌─────────────────────────────────────────────────────────────┐
│                    Application Layer                         │
│  (Controllers, Services, DTOs, Business Logic)              │
└─────────────────────────────────────────────────────────────┘
                            ↓
┌─────────────────────────────────────────────────────────────┐
│                    Domain Layer                              │
│  (Entities, Interfaces, Domain Services)                    │
└─────────────────────────────────────────────────────────────┘
                            ↓
┌─────────────────────────────────────────────────────────────┐
│                    Infrastructure Layer                      │
│  (Database, External Services, Repositories)                │
└─────────────────────────────────────────────────────────────┘
```

## Technology Stack

### Backend

| Component | Technology | Version |
|-----------|-----------|---------|
| **Framework** | ASP.NET Core | 9.0 |
| **ORM** | Entity Framework Core | 9.0 |
| **Database** | SQL Server | 2019+ |
| **Authentication** | ASP.NET Core Identity | 9.0 |
| **Mapping** | AutoMapper | Latest |
| **Validation** | FluentValidation | Latest |
| **Payments** | Stripe.NET | Latest |
| **Logging** | Serilog | Latest |

### Frontend

| Component | Technology | Purpose |
|-----------|-----------|---------|
| **View Engine** | Razor | Server-side templating |
| **CSS Framework** | TailwindCSS | Utility-first styling |
| **Design System** | Apple Keyboard+ | Custom design tokens |
| **JavaScript** | ES6+ | Frontend interactivity |
| **Build Tools** | Webpack | Asset bundling |
| **CSS Processing** | PostCSS | CSS transformation |

### Infrastructure

| Component | Technology | Purpose |
|-----------|-----------|---------|
| **Web Server** | Kestrel | HTTP server |
| **Hosting** | IIS / Azure App Service | Production hosting |
| **CDN** | Azure CDN | Static asset delivery |
| **Monitoring** | Application Insights | Performance monitoring |

## Project Structure

```
VoxTics/
├── VoxTics/                          # Main application
│   ├── Areas/
│   │   ├── Admin/                    # Admin dashboard
│   │   │   ├── Controllers/
│   │   │   ├── Models/
│   │   │   └── Views/
│   │   └── Identity/                 # Authentication
│   │       ├── Controllers/
│   │       ├── Models/
│   │       └── Views/
│   ├── Controllers/                  # Main MVC controllers
│   │   ├── HomeController.cs
│   │   ├── MoviesController.cs
│   │   ├── CinemasController.cs
│   │   ├── BookingsController.cs
│   │   └── PaymentsController.cs
│   ├── Data/                         # Database layer
│   │   ├── MovieDbContext.cs         # EF Core context
│   │   ├── Configurations/           # Entity configurations
│   │   ├── DBInitializer/            # Database seeding
│   │   └── Seeds/                    # Seed data
│   ├── Models/
│   │   ├── Entities/                 # Domain entities
│   │   │   ├── Movie.cs
│   │   │   ├── Cinema.cs
│   │   │   ├── Booking.cs
│   │   │   ├── User.cs
│   │   │   └── ...
│   │   ├── Enums/                    # Enumerations
│   │   │   ├── BookingStatus.cs
│   │   │   ├── PaymentStatus.cs
│   │   │   └── ...
│   │   └── ViewModels/               # View models
│   │       ├── MovieViewModel.cs
│   │       ├── BookingViewModel.cs
│   │       └── ...
│   ├── Services/                     # Business logic
│   │   ├── IMovieService.cs
│   │   ├── MovieService.cs
│   │   ├── IBookingService.cs
│   │   ├── BookingService.cs
│   │   ├── IPaymentService.cs
│   │   ├── PaymentService.cs
│   │   └── ...
│   ├── Repositories/                 # Data access
│   │   ├── IRepository.cs
│   │   ├── Repository.cs
│   │   ├── IUnitOfWork.cs
│   │   ├── UnitOfWork.cs
│   │   └── ...
│   ├── Views/                        # Razor views
│   │   ├── Shared/
│   │   ├── Home/
│   │   ├── Movies/
│   │   ├── Cinemas/
│   │   ├── Bookings/
│   │   └── ...
│   ├── wwwroot/                      # Static files
│   │   ├── css/                      # Global design system
│   │   │   ├── foundation/           # CSS variables & tokens
│   │   │   ├── base/                 # Reset & typography
│   │   │   ├── components/           # UI components
│   │   │   ├── utilities/            # Layout utilities
│   │   │   └── voxtics-global.css    # Main stylesheet
│   │   ├── js/                       # JavaScript modules
│   │   │   ├── main/                 # Public site JS
│   │   │   ├── admin/                # Admin JS
│   │   │   ├── utils/                # Utilities
│   │   │   └── site.js               # Global utilities
│   │   ├── images/                   # Static images
│   │   └── lib/                      # Third-party libraries
│   ├── Program.cs                    # Application entry point
│   ├── appsettings.json              # Configuration
│   └── VoxTics.csproj                # Project file
├── docs/                             # Documentation
├── scripts/                          # Build scripts
└── VoxTics.sln                       # Solution file
```

## Core Layers

### 1. Presentation Layer

**Responsibility**: User interface and HTTP request handling

**Components**:
- **Controllers** - Handle HTTP requests and responses
- **Views** - Razor templates for rendering HTML
- **ViewModels** - Data transfer objects for views
- **Design System** - CSS components and styling

**Key Controllers**:
- `HomeController` - Home page and general navigation
- `MoviesController` - Movie browsing and details
- `CinemasController` - Cinema listings and details
- `BookingsController` - Booking management
- `PaymentsController` - Payment processing
- `AdminController` - Admin dashboard

### 2. Application Layer

**Responsibility**: Business logic orchestration and request processing

**Components**:
- **Services** - Business logic implementation
- **DTOs** - Data transfer objects
- **Validators** - Input validation
- **Mappers** - Object mapping (AutoMapper)

**Key Services**:
- `MovieService` - Movie management
- `CinemaService` - Cinema management
- `BookingService` - Booking operations
- `PaymentService` - Payment processing
- `UserService` - User management
- `EmailService` - Email notifications

### 3. Domain Layer

**Responsibility**: Core business rules and domain logic

**Components**:
- **Entities** - Domain models
- **Enums** - Domain enumerations
- **Interfaces** - Service contracts
- **Specifications** - Business rules

**Key Entities**:
- `Movie` - Movie information
- `Cinema` - Cinema location
- `Hall` - Cinema hall
- `Showtime` - Movie showtime
- `Booking` - Customer booking
- `User` - User account
- `Payment` - Payment record

### 4. Infrastructure Layer

**Responsibility**: External services and data persistence

**Components**:
- **DbContext** - Entity Framework Core context
- **Repositories** - Data access patterns
- **Unit of Work** - Transaction management
- **External Services** - Stripe, Email, etc.

**Key Repositories**:
- `MovieRepository` - Movie data access
- `CinemaRepository` - Cinema data access
- `BookingRepository` - Booking data access
- `UserRepository` - User data access

## Design Patterns

### 1. Repository Pattern

Abstracts data access logic:

```csharp
public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
```

### 2. Unit of Work Pattern

Manages transactions across repositories:

```csharp
public interface IUnitOfWork : IDisposable
{
    IMovieRepository Movies { get; }
    ICinemaRepository Cinemas { get; }
    IBookingRepository Bookings { get; }
    
    Task<int> SaveChangesAsync();
}
```

### 3. Service Layer Pattern

Encapsulates business logic:

```csharp
public interface IMovieService
{
    Task<MovieDto> GetMovieByIdAsync(int id);
    Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
    Task<MovieDto> CreateMovieAsync(CreateMovieDto dto);
    Task UpdateMovieAsync(int id, UpdateMovieDto dto);
    Task DeleteMovieAsync(int id);
}
```

### 4. Dependency Injection

Loose coupling through DI container:

```csharp
services.AddScoped<IMovieService, MovieService>();
services.AddScoped<IMovieRepository, MovieRepository>();
services.AddScoped<IUnitOfWork, UnitOfWork>();
```

## Database Schema

### Core Entities

**Movies**
- MovieId (PK)
- Title
- Description
- Genre
- ReleaseDate
- Duration
- Rating
- PosterUrl
- TrailerUrl

**Cinemas**
- CinemaId (PK)
- Name
- Location
- Address
- Phone
- Email
- Amenities

**Halls**
- HallId (PK)
- CinemaId (FK)
- Name
- Capacity
- SeatConfiguration

**Showtimes**
- ShowtimeId (PK)
- MovieId (FK)
- HallId (FK)
- StartTime
- EndTime
- Price

**Bookings**
- BookingId (PK)
- UserId (FK)
- ShowtimeId (FK)
- BookingDate
- Status
- TotalPrice

**Seats**
- SeatId (PK)
- HallId (FK)
- SeatNumber
- Row
- Column

**Payments**
- PaymentId (PK)
- BookingId (FK)
- Amount
- Status
- PaymentMethod
- TransactionId

**Users** (ASP.NET Core Identity)
- Id (PK)
- Email
- UserName
- PasswordHash
- PhoneNumber
- CreatedDate

## Authentication & Authorization

### ASP.NET Core Identity

- User registration and login
- Password hashing and validation
- Email confirmation
- Two-factor authentication support
- Role-based authorization

### Roles

- **Admin** - Full system access
- **User** - Customer access
- **Manager** - Cinema manager access

### Authorization Policies

```csharp
[Authorize(Roles = "Admin")]
public IActionResult AdminDashboard() { }

[Authorize]
public IActionResult MyBookings() { }

[AllowAnonymous]
public IActionResult Home() { }
```

## Payment Integration

### Stripe Integration

- Secure payment processing
- Payment intent creation
- Webhook handling for payment events
- Refund processing
- Payment history tracking

### Payment Flow

1. User adds items to cart
2. Proceeds to checkout
3. Enters payment details
4. Creates payment intent with Stripe
5. Stripe processes payment
6. Webhook confirms payment
7. Booking is confirmed

## Email Notifications

### Automated Emails

- Booking confirmation
- Booking cancellation
- Password reset
- Account verification
- Payment receipt

### Email Configuration

- SMTP server configuration
- Email templates
- Async email sending
- Error handling and retries

## Frontend Architecture

### CSS Architecture

**Global Design System** with 100+ CSS variables:

- **Foundation** - Colors, spacing, typography
- **Base** - Reset, typography, base styles
- **Components** - Reusable UI components
- **Utilities** - Layout and responsive utilities
- **TailwindCSS** - Utility-first CSS framework

### JavaScript Architecture

**Modular JavaScript** with ES6 classes:

- **Global Utilities** - Common functions and classes
- **Public Site** - Customer-facing functionality
- **Admin Interface** - Admin-specific features
- **Performance Monitoring** - Execution timing and optimization

## Security Considerations

### Authentication
- Secure password hashing (ASP.NET Core Identity)
- HTTPS/TLS encryption
- CSRF protection on forms
- Session management

### Authorization
- Role-based access control
- Policy-based authorization
- Resource-level authorization

### Data Protection
- SQL injection prevention (EF Core parameterized queries)
- XSS prevention (Razor HTML encoding)
- CORS configuration
- API rate limiting

### Payment Security
- PCI DSS compliance through Stripe
- No sensitive payment data stored locally
- Secure webhook verification
- HTTPS for all payment endpoints

## Performance Optimization

### Caching
- Output caching for static content
- Database query caching
- HTTP caching headers

### Database
- Query optimization with indexes
- Lazy loading and eager loading strategies
- Connection pooling

### Frontend
- CSS minification and purging
- JavaScript bundling and minification
- Image optimization
- Lazy loading for images

## Monitoring & Logging

### Logging
- Structured logging with Serilog
- Log levels (Debug, Information, Warning, Error)
- File and console logging
- Application Insights integration

### Monitoring
- Application performance monitoring
- Error tracking and alerting
- User activity tracking
- Database performance monitoring

## Deployment Architecture

### Development
- Local SQL Server (LocalDB)
- IIS Express or Kestrel
- Hot reload enabled

### Staging
- Azure SQL Database
- Azure App Service
- Staging slots for testing

### Production
- Azure SQL Database (replicated)
- Azure App Service (scaled)
- Azure CDN for static assets
- Application Insights monitoring

## Scalability Considerations

### Horizontal Scaling
- Stateless application design
- Session state in distributed cache
- Load balancing across instances

### Vertical Scaling
- Database optimization
- Query caching
- Connection pooling

### Database Scaling
- Read replicas for reporting
- Partitioning for large tables
- Archive old data

## Future Enhancements

### Planned Features
- Mobile app (iOS/Android)
- Real-time notifications (SignalR)
- Advanced analytics dashboard
- Machine learning recommendations
- Microservices architecture

### Technology Upgrades
- TypeScript for frontend
- GraphQL API
- Docker containerization
- Kubernetes orchestration

---

**Last Updated**: May 31, 2026  
**Status**: ✅ Production Ready
