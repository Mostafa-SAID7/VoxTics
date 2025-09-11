/Data
  ├── ApplicationDbContext.cs
  ├── UnitOfWork
  │    ├── IUnitOfWork.cs
  │    └── UnitOfWork.cs
  ├── Repositories
  │    ├── BaseRepository.cs
  │    ├── IBaseRepository.cs
  │    ├── BookingsRepository.cs
  │    ├── IBookingsRepository.cs
  │    ├── CategoriesRepository.cs
  │    ├── ICategoriesRepository.cs
  │    └── ... (Cinemas, Movies, Showtimes)
  └── Services
       ├── IBookingService.cs
       ├── BookingService.cs
       ├── ICategoryService.cs
       ├── CategoryService.cs
       └── ... (Cinemas, Movies, Showtimes)

/Controllers
  ├── Admin
  │    └── BookingsController.cs ...
  ├── Identity
  │    └── AccountController.cs
  └── Main
       └── BookingController.cs ...
