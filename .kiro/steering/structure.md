# VoxTics Project Structure

## Architecture Pattern
The project follows **Clean Architecture** principles with **Repository Pattern** and **Unit of Work** pattern for data access.

## Root Structure
```
VoxTics/                    # Main ASP.NET Core project
├── Areas/                  # Feature-based organization
├── Controllers/            # Main MVC controllers
├── Data/                   # Database context and configurations
├── Models/                 # Domain entities and view models
├── Services/               # Business logic layer
├── Repositories/           # Data access layer
├── Helpers/                # Utility classes and extensions
├── Views/                  # Razor view templates
├── wwwroot/                # Static assets
└── Program.cs              # Application entry point
```

## Areas Organization
- **Admin/** - Administrative interface with full CRUD operations
- **Identity/** - Authentication, registration, and user management

Each area contains:
- `Controllers/` - Area-specific controllers
- `Views/` - Area-specific Razor views
- `ViewModels/` - Area-specific view models
- `Services/` - Area-specific business logic
- `Repositories/` - Area-specific data access

## Data Layer Structure
```
Data/
├── Configurations/         # Entity Framework configurations
├── Seeds/                  # Database seeding classes
├── UoW/                    # Unit of Work implementation
├── MovieDbContext.cs       # Main database context
└── DBInitializer/          # Database initialization
```

## Models Organization
```
Models/
├── Entities/               # Domain entities (Movie, Cinema, Booking, etc.)
├── Enums/                  # Enumeration types
└── ViewModels/             # Data transfer objects for views
    ├── Movie/
    ├── Cinema/
    ├── Booking/
    └── [Feature]/
```

## Service Layer Pattern
- **Interfaces/** - Service contracts
- **Implementations/** - Concrete service implementations
- Services handle business logic and coordinate between controllers and repositories

## Repository Pattern
- **IRepositories/** - Repository interfaces
- **Concrete Repositories** - Entity-specific data access
- **BaseRepository** - Generic CRUD operations
- **UnitOfWork** - Transaction management across repositories

## Helpers & Utilities
```
Helpers/
├── Filters/                # Query filtering and sorting
├── booking/                # Booking-specific utilities
├── ImgsHelper/             # Image management
└── [Utility].cs            # Extension methods and helpers
```

## Frontend Asset Structure
```
wwwroot/
├── css/
│   ├── components/         # Component-specific styles
│   ├── input.css           # TailwindCSS source
│   └── voxtics-design-system.css
├── js/
│   ├── admin/              # Admin-specific JavaScript
│   └── main/               # Public-facing JavaScript
├── images/                 # Static images
└── uploads/                # User-uploaded content
```

## Naming Conventions

### Controllers
- `[Entity]Controller.cs` for main controllers
- `[Entity]sController.cs` for plural entities (MoviesController)

### Services & Repositories
- `I[Entity]Service.cs` for interfaces
- `[Entity]Service.cs` for implementations
- `I[Entity]Repository.cs` for repository interfaces
- `[Entity]Repository.cs` for repository implementations

### View Models
- `[Entity]VM.cs` for basic view models
- `[Entity]DetailsVM.cs` for detailed views
- `[Entity]CreateVM.cs` for creation forms
- `[Entity]ListVM.cs` for list views

### Areas
- Admin area uses `Admin[Entity]` prefix for disambiguation
- Identity area follows ASP.NET Core Identity conventions

## Configuration Files
- `appsettings.json` - Main configuration
- `appsettings.Development.json` - Development overrides
- Connection strings, Stripe keys, and email settings stored in configuration