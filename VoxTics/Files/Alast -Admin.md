/Data
├── MovieDbContext.cs
└── UnitOfWork
    ├── IUnitOfWork.cs
    └── UnitOfWork.cs

/Areas
└── Admin
    ├── Controllers
    │   ├── BookingsController.cs
    │   ├── CategoriesController.cs
    │   ├── CinemasController.cs
    │   ├── HomeController.cs
    │   ├── MoviesController.cs
    │   └── ShowtimesController.cs
    │
    ├── Views
    │   ├── Bookings/
    │   ├── Categories/
    │   ├── Cinemas/
    │   ├── Home/
    │   ├── Movies/
    │   ├── Showtimes/
    │   └── Shared/
    │       ├── _Layout.cshtml
    │       ├── _Sidebar.cshtml
    │       ├── _Topbar.cshtml
    │       ├── _ValidationScriptsPartial.cshtml
    │       └── Error.cshtml
    │
    ├── ViewModels
    │   ├── Admin/
    │   │   ├── AdminDashboardViewModel.cs
    │   │   ├── AdminLoginVM.cs
    │   │   ├── AdminProfileVM.cs
    │   │   ├── BookingSummary.cs
    │   │   ├── MovieSummary.cs
    │   │   └── UserSummary.cs
    │   │
    │   ├── Filter/
    │   │   ├── MovieAdminVM.cs
    │   │   ├── MovieFilterVM.cs
    │   │   └── PagedResultVM.cs
    │   │
    │   ├── Movie/
    │   │   ├── MovieCreateEditViewModel.cs
    │   │   ├── MovieDetailViewModel.cs
    │   │   ├── MovieImageViewModel.cs
    │   │   └── MovieListItemViewModel.cs
    │   │
    │   ├── ActorViewModel.cs
    │   ├── BookingViewModel.cs
    │   ├── CategoryViewModel.cs
    │   ├── CinemaViewModel.cs
    │   ├── HallViewModel.cs
    │   ├── ShowtimeViewModel.cs
    │
    ├── Services
    │   ├── Interfaces
    │   │   ├── IBookingService.cs
    │   │   ├── ICategoryService.cs
    │   │   ├── ICinemaService.cs
    │   │   ├── IDashboardService.cs
    │   │   ├── IHomeService.cs
    │   │   ├── IMovieService.cs
    │   │   └── IShowtimeService.cs
    │   │
    │   └── Implementations
    │       ├── BookingService.cs
    │       ├── CategoryService.cs
    │       ├── CinemaService.cs
    │       ├── DashboardService.cs
    │       ├── HomeService.cs
    │       ├── MovieService.cs
    │       ├── PaymentService.cs
    │       └── ShowtimeService.cs
    │
    ├── Repositories
    │   ├── IRepositories
    │   │   ├── IBaseRepository.cs
    │   │   ├── IBookingRepository.cs
    │   │   ├── ICategoryRepository.cs
    │   │   ├── ICinemaRepository.cs
    │   │   ├── IDashboardRepository.cs
    │   │   ├── IHomeRepository.cs
    │   │   ├── IMovieRepository.cs
    │   │   └── IShowtimeRepository.cs
    │   │
    │   ├── BaseRepository.cs
    │   ├── BookingRepository.cs
    │   ├── CategoryRepository.cs
    │   ├── CinemaRepository.cs
    │   ├── DashboardRepository.cs
    │   ├── HomeRepository.cs
    │   ├── MovieRepository.cs
    │   └── ShowtimeRepository.cs
    │
    ├── MappingProfiles
    │   └── AdminProfile/
    │       ├── BaseAdminProfile.cs
    │       ├── BookingAdminProfile.cs
    │       ├── CategoryAdminProfile.cs
    │       ├── CinemaAdminProfile.cs
    │       ├── MovieAdminProfile.cs
    │       └── ShowtimeAdminProfile.cs

/Helpers
├── Filters/
│   ├── BookingFilter.cs
│   ├── CategoryFilter.cs
│   ├── CinemaFilter.cs
│   ├── MovieFilter.cs
│   ├── ShowtimeFilter.cs
│   └── UserFilter.cs
├── FilterBase.cs
├── IFileService.cs
├── ImageHelper.cs
├── PaginatedList.cs
├── PriceFormatter.cs
├── SearchHelper.cs
├── ValidationHelpers.cs
├── EnumExtensions.cs
├── DateTimeExtensions.cs
└── IEmailService.cs

/Models
├── Entities/
│   ├── Actor.cs
│   ├── BaseEntity.cs
│   ├── Booking.cs
│   ├── BookingSeat.cs
│   ├── Category.cs
│   ├── Cinema.cs
│   ├── Hall.cs
│   ├── Movie.cs
│   ├── MovieActor.cs
│   ├── MovieCategory.cs
│   ├── MovieImg.cs
│   ├── Seat.cs
│   ├── Showtime.cs
│   └── SocialMediaLink.cs
├── Enums/
│   ├── Notifications/
│   │   └── NotificationType.cs
│   ├── Sorting/
│   │   ├── ActorSortBy.cs
│   │   ├── BookingSortBy.cs
│   │   ├── CategorySortBy.cs
│   │   ├── CinemaSortBy.cs
│   │   ├── MovieSortBy.cs
│   │   ├── ShowtimeSortBy.cs
│   │   ├── SortOrder.cs
│   │   └── UserSortBy.cs
│   ├── TimeRange/
│   │   ├── TimeOfDayRange.cs
│   │   └── TimeRange.cs
│   ├── BookingStatus.cs
│   ├── MovieStatus.cs
│   ├── PaymentStatus.cs
│   ├── SeatType.cs
│   └── ShowtimeStatus.cs
ServiceCollectionExtensions.cs
