/Data
├── MovieDbContext.cs
├── UnitOfWork
│   ├── IUnitOfWork.cs
│   └── UnitOfWork.cs
├── Migrations/          # EF Core migrations folder
└── SeedData.cs          # Optional: database seeding

/Areas
└── Admin
    ├── Controllers/
    │   ├── BookingsController.cs
    │   ├── CategoriesController.cs
    │   ├── CinemasController.cs
    │   ├── HomeController.cs
    │   ├── MoviesController.cs
    │   ├── ShowtimesController.cs
    │   └── UsersController.cs
    │
    ├── Views/
    │   ├── Bookings/
    │   ├── Categories/
    │   ├── Cinemas/
    │   ├── Home/
    │   ├── Movies/
    │   ├── Showtimes/
    │   ├── Users/
    │   └── Shared/
    │       ├── _Layout.cshtml
    │       ├── _Sidebar.cshtml
    │       ├── _Topbar.cshtml
    │       ├── _ValidationScriptsPartial.cshtml
    │       └── Error.cshtml
    │
    ├── ViewModels/
    │   ├── Admin/
    │   │   ├── Dashboard/
    │   │   │   ├── AdminDashboardViewModel.cs
    │   │   │   ├── BookingSummary.cs
    │   │   │   ├── MovieSummary.cs
    │   │   │   └── UserSummary.cs
    │   │   ├── Authentication/
    │   │   │   └── AdminLoginVM.cs
    │   │   ├── Profile/
    │   │   │   └── AdminProfileVM.cs
    │   │
    │   ├── Movie/
    │   │   ├── MovieCreateEditViewModel.cs
    │   │   ├── MovieDetailViewModel.cs
    │   │   ├── MovieImageViewModel.cs
    │   │   ├── MovieListItemViewModel.cs
    │   │   └── MovieTableViewModel.cs
    │   │
    │   ├── Booking/
    │   │   ├── BookingViewModel.cs
    │   │   ├── BookingCreateEditViewModel.cs
    │   │   ├── BookingDetailViewModel.cs
    │   │   └── BookingTableViewModel.cs
    │   │
    │   ├── Actor/
    │   │   ├── ActorViewModel.cs
    │   │   ├── ActorCreateEditViewModel.cs
    │   │   ├── ActorDetailViewModel.cs
    │   │   └── ActorTableViewModel.cs
    │   │
    │   ├── Category/
    │   │   ├── CategoryViewModel.cs
    │   │   ├── CategoryCreateEditViewModel.cs
    │   │   ├── CategoryDetailViewModel.cs
    │   │   └── CategoryTableViewModel.cs
    │   │
    │   ├── Cinema/
    │   │   ├── CinemaViewModel.cs
    │   │   ├── CinemaCreateEditViewModel.cs
    │   │   ├── CinemaDetailViewModel.cs
    │   │   └── CinemaTableViewModel.cs
    │   │
    │   ├── Showtime/
    │   │   ├── ShowtimeViewModel.cs
    │   │   ├── ShowtimeCreateEditViewModel.cs
    │   │   ├── ShowtimeDetailViewModel.cs
    │   │   └── ShowtimeTableViewModel.cs
    │   │
    │   ├── Hall/
    │   │   └── HallViewModel.cs
    │   │
    │   └── User/
    │       └── UserManagementStats.cs
    │
    ├── Services/
    │   ├── Interfaces/
    │   │   ├── IAdminBookingService.cs
    │   │   ├── IAdminCategoryService.cs
    │   │   ├── IAdminCinemaService.cs
    │   │   ├── IDashboardService.cs
    │   │   ├── IAdminHomeService.cs
    │   │   ├── IAdminMovieService.cs
    │   │   ├── IAdminShowtimeService.cs
    │   │   └── IAdminUserService.cs
    │   │
    │   └── Implementations/
    │       ├── AdminBookingService.cs
    │       ├── AdminCategoryService.cs
    │       ├── AdminCinemaService.cs
    │       ├── DashboardService.cs
    │       ├── AdminHomeService.cs
    │       ├── AdminMovieService.cs
    │       ├── AdminPaymentService.cs
    │       ├── AdminShowtimeService.cs
    │       └── AdminUserService.cs
    │
    ├── Repositories/
    │   ├── IRepositories/
    │   │   ├── IAdminBookingsRepository.cs
    │   │   ├── IAdminCategoriesRepository.cs
    │   │   ├── IAdminCinemasRepository.cs
    │   │   ├── IAdminMoviesRepository.cs
    │   │   ├── IAdminShowtimesRepository.cs
    │   │   ├── IDashboardRepository.cs
    │   │   └── IAdminUserRepository.cs
    │   │
    │   ├── AdminBookingsRepository.cs
    │   ├── AdminCategoriesRepository.cs
    │   ├── AdminCinemasRepository.cs
    │   ├── AdminMoviesRepository.cs
    │   ├── AdminShowtimesRepository.cs
    │   ├── DashboardRepository.cs
    │   └── AdminUserRepository.cs
    │
    └── Profiles/
        ├── BookingAdminProfile.cs
        ├── CategoryAdminProfile.cs
        ├── CinemaAdminProfile.cs
        ├── MovieAdminProfile.cs
        ├── ShowtimeAdminProfile.cs
        └── UserAdminProfile.cs

/Helpers
├── BookingRulesHelper.cs
├── DateTimeExtensions.cs
├── EmailTemplateHelper.cs
├── EnumExtensions.cs
├── IEmailService.cs
├── ImageHelper.cs
├── PaginatedList.cs
├── QueryableExtensions.cs
├── SmtpEmailSender.cs
├── SmtpEmailService.cs
├── SmtpOptions.cs
├── PriceFormatter.cs
└── ValidationHelpers.cs

/TempHtml/
└── BookingConfirmation/

/Models
├── Entities/
│   ├── Actor.cs
│   ├── BaseEntity.cs
│   ├── Booking.cs
│   ├── BookingSeat.cs
│   ├── Cart/
│   │   ├── Cart.cs
│   │   └── CartItem.cs
│   ├── Category.cs
│   ├── Cinema.cs
│   ├── Hall.cs
│   ├── Movie.cs
│   ├── MovieActor.cs
│   ├── MovieCategory.cs
│   ├── MovieImg.cs
│   ├── Notification/
│   │   └── Notification.cs
│   ├── Payment/
│   │   └── Payment.cs
│   ├── Seat.cs
│   ├── Showtime.cs
│   ├── Watchlist/
│   │   ├── Watchlist.cs
│   │   └── WatchlistItem.cs
│   └── SocialMediaLink.cs
│
├── Enums/
│   ├── Notifications/
│   │   └── NotificationType.cs
│   ├── BookingStatus.cs
│   ├── MovieStatus.cs
│   ├── PaymentMethod.cs
│   ├── PaymentStatus.cs
│   ├── SeatType.cs
│   └── ShowtimeStatus.cs

ServiceCollectionExtensions.cs   # Dependency injection registrations
