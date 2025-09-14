 IDisposable for resource management + 
		 IRepository pattern for abstraction + 
		 Task-based async pattern for non-blocking operations + 
		 IQueryable support for advanced querying + 
		 Unit of Work pattern for transaction management + 
		 caching support for performance optimization + 
		 logging support for monitoring + 
		 validation support for data integrity + 
		 custom exceptions for error handling + 
/Areas
├── Admin
│   ├── Controllers/
│   │   ├── BookingsController.cs
│   │   ├── CategoriesController.cs
│   │   ├── CinemasController.cs
│   │   ├── HomeController.cs
│   │   ├── MoviesController.cs
│   │   └── ShowtimesController.cs
│   ├── Views/
│   │   └── Shared/
│   │       └── Components/
│   │           └── Movie/
│   │               ├── Card.cshtml
│   │               ├── Details.cshtml
│   │               ├── Form.cshtml
│   │               └── Table.cshtml
│   ├── ViewModels/
│   ├── Services/
│   │   ├── Interfaces/
│   │   └── Implementations/
│   ├── Repositories/
│   │   ├── Interfaces/
│   │   └── Implementations/
│   └── AdminProfiles/

├── Account
│   ├── Controllers/
│   ├── Views/
│   ├── ViewModels/
│   ├── Services/
│   │   ├── Interfaces/
│   │   └── Implementations/
│   ├── Repositories/
│   └── IdentityProfiles/

/Controllers
├── BookingController.cs
├── CinemaController.cs
├── HomeController.cs
├── MovieController.cs
├── ShowtimeController.cs
├── ProfileController.cs
└── CategoriesController.cs

/Data
├── MovieDbContext.cs
├── DbInitializer.cs
└── UnitOfWork/
    ├── IUnitOfWork.cs
    └── UnitOfWork.cs

/Repositories
├── Interfaces/
├── Implementations/

/Services
├── Interfaces/
├── Implementations/

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

/MappingProfiles
├── BaseProfile.cs
├── BookingProfile.cs
├── CategoryProfile.cs
├── CinemaProfile.cs
├── MovieProfile.cs
├── ShowtimeProfile.cs
└── IdentityProfiles/

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
│   ├── Notifications/NotificationType.cs
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
└── ViewModels/
    ├── ActorVM.cs
    ├── PaginatedFilterVM.cs
    ├── BaseVM.cs
    ├── BookingVM.cs
    ├── CategoryVM.cs
    ├── CinemaVM.cs
    ├── HallVM.cs
    ├── HomeVM.cs
    ├── MovieListVM.cs
    ├── MovieDetailVM.cs
    ├── MovieActorVM.cs
    ├── MovieCategoryVM.cs
    ├── MovieImgVM.cs
    ├── SeatVM.cs
    ├── ShowtimeVM.cs
    └── SocialMediaLinkVM.cs

/Views
├── Booking/
│   └── Index.cshtml
├── Cinema/
│   └── Index.cshtml
├── Home/
│   ├── Index.cshtml
│   ├── About.cshtml
│   ├── Contact.cshtml
│   ├── FAQ.cshtml
│   ├── Terms.cshtml
│   ├── News.cshtml
│   ├── Privacy.cshtml
│   └── RefoundPolicy.cshtml
├── Movie/
│   └── Index.cshtml
├── Showtime/
│   └── Index.cshtml
├── Profile/
│   └── Index.cshtml
├── Categories/
│   ├── Index.cshtml
│   └── Slug.cshtml
└── Shared/
    ├── Components/
    │   ├── Booking/
    │   │   ├── Card.cshtml
    │   │   ├── Details.cshtml
    │   │   ├── CreateBooking.cshtml
    │   │   └── EditBooking.cshtml
    │   ├── Movie/
    │   │   ├── Card.cshtml
    │   │   └── Details.cshtml
    │   ├── Cinema/
    │   │   ├── Card.cshtml
    │   │   └── Details.cshtml
    │   └── Showtime/
    │       ├── Card.cshtml
    │       └── Details.cshtml
    ├── _Layout.cshtml
    ├── _ValidationScriptsPartial.cshtml
    ├── Error.cshtml
    ├── _Search.cshtml
    ├── _Footer.cshtml
    ├── _Header.cshtml
    ├── _Loader.cshtml
    ├── _NotificationPartial.cshtml
    └── _Pagination.cshtml

/Utility
└── SD.cs

/wwwroot
├── css/
├── js/
├── lib/
├── images/
│   └── logo.png
└── uploads/
    ├── movies/
    ├── actors/
    ├── cinemas/
    ├── users/
    └── banners/

/ServiceCollectionExtensions.cs
/Program.cs
/GlobalUsings.cs
/appsettings.json
