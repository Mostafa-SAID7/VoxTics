 IDisposable for resource management + 
		 IRepository pattern for abstraction + 
		 Task-based async pattern for non-blocking operations + 
		 IQueryable support for advanced querying + 
		 Unit of Work pattern for transaction management + 
		 caching support for performance optimization + 
		 logging support for monitoring + 
		 validation support for data integrity + 
		 custom exceptions for error handling + 

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

   ├── Repositories/
    │   ├── Interfaces/
                IBaseRepository.cs
    │   │   ├── IBookingsRepository.cs
    │   │   ├── ICategoriesRepository.cs
    │   │   ├── ICinemasRepository.cs
    │   │   ├── IMoviesRepository.cs
    │   │   ├── IShowtimesRepository.cs
    │   │   ├── IHomeRepository.cs
    │   │   
    │   │
    │   └──BaseRepository.cs
    │   ├── BookingsRepository.cs
    │   ├── CategoriesRepository.cs
    │   ├── CinemasRepository.cs
    │   ├── MoviesRepository.cs
    │   ├── ShowtimesRepository.cs
    │   ├── HomeRepository.cs
    

/Services/
    │   ├── Interfaces/
    │   │   ├── IBookingService.cs
    │   │   ├── ICategoryService.cs
    │   │   ├── ICinemaService.cs
    │   │   ├── IHomeService.cs
    │   │   ├── IMovieService.cs
    │   │   ├── IShowtimeService.cs
    │   │
    │   └── Implementations/
    │       ├── BookingService.cs
    │       ├── CategoryService.cs
    │       ├── CinemaService.cs
    │       ├── HomeService.cs
    │       ├── MovieService.cs
    │       ├── PaymentService.cs
    │       ├── ShowtimeService.cs

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

/MappingProfiles
├── BookingProfile.cs
├── CategoryProfile.cs
├── CinemaProfile.cs
├── MovieProfile.cs
├── ShowtimeProfile.cs


VoxTics/Models/Entities/
     ├─ Actor.cs
     ├─ BaseEntity.cs                 
     ├─ Booking.cs
     ├─ BookingSeat.cs
     ├─ Cart.cs
     ├─ CartItem.cs
     ├─ Category.cs
     ├─ Cinema.cs
     ├─ Hall.cs
     ├─ Movie.cs
     ├─ MovieActor.cs
     ├─ MovieCategory.cs
     ├─ MovieImg.cs
     ├─ Notification.cs
     ├─ Payment.cs
     ├─ Seat.cs
     ├─ Showtime.cs
     ├─ SocialMediaLink
     └─ UserMovieWatchlist
     └─ Watchlist.cs
        WatchlistItem.cs
├── Enums/
│   ├── Notifications/NotificationType.cs
│   ├── BookingStatus.cs
│   ├── MovieStatus.cs
│   ├── PaymentStatus.cs
│   ├── SeatType.cs
│   └── ShowtimeStatus.cs
└── ViewModels/
    ├── ActorVM.cs
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
