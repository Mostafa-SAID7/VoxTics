VoxTics/
│
├── Areas/
│   ├── Identity/
│   │   ├── Controllers/
│   │   │   ├── AccountController.cs
│   │   │   └── ProfileController.cs
│   │   ├── Models/
│   │   │   ├── Entities/
│   │   │   │   ├── ApplicationUser.cs
│   │   │   │   ├── UserOTP.cs
│   │   │   │   └── UserMovieWatchlist.cs
│   │   │   └── ViewModels/
│   │   │       ├── ConfirmOTPVM.cs
│   │   │       ├── ForgetPasswordVM.cs
│   │   │       ├── LoginVM.cs
│   │   │       ├── ManageProfileVM.cs
│   │   │       ├── NewPasswordVM.cs
│   │   │       ├── PersonalInfoVM.cs
│   │   │       ├── RegisterVM.cs
│   │   │       └── ResendEmailConfirmationVM.cs
│   │   ├── Repositories/
│   │   │   ├── IRepositories/
│   │   │   │   └── IApplicationUsersRepository.cs
│   │   │   └── ApplicationUsersRepository.cs
│   │   └── Services/
│   │       ├── Interfaces/
│   │       │   └── IAccountService.cs
│   │       └── AccountService.cs
│   │
│   └── Admin/
│       ├── Controllers/
│       │   ├── BookingsController.cs
│       │   ├── CategoriesController.cs
│       │   ├── CinemasController.cs
│       │   ├── MoviesController.cs
│       │   ├── ShowtimesController.cs
│       │   ├── UsersController.cs
│       │   └── HomeController.cs
│       ├── Views/
│       │   ├── Bookings/
│       │   ├── Categories/
│       │   ├── Cinemas/
│       │   ├── Movies/
│       │   ├── Showtimes/
│       │   ├── Users/
│       │   ├── Home/
│       │   └── Shared/
│       │       ├── _Layout.cshtml
│       │       ├── _Sidebar.cshtml
│       │       ├── _Topbar.cshtml
│       │       ├── _ValidationScriptsPartial.cshtml
│       │       └── Error.cshtml
│       ├── ViewModels/
│       │   ├── AdminDashboardViewModel.cs
│       │   ├── BookingViewModels/
│       │   ├── MovieViewModels/
│       │   ├── CategoryViewModels/
│       │   ├── CinemaViewModels/
│       │   ├── ShowtimeViewModels/
│       │   └── UserManagementStats.cs
│       ├── Services/
│       │   ├── Interfaces/
│       │   └── Implementations/
│       ├── Repositories/
│       │   ├── Interfaces/
│       │   └── Implementations/
│       └── Profiles/
│           ├── BookingAdminProfile.cs
│           ├── CategoryAdminProfile.cs
│           ├── CinemaAdminProfile.cs
│           ├── MovieAdminProfile.cs
│           ├── ShowtimeAdminProfile.cs
│           └── UserAdminProfile.cs
│
├── Controllers/
│   ├── BookingController.cs
│   ├── CinemaController.cs
│   ├── HomeController.cs
│   ├── MovieController.cs
│   ├── ShowtimeController.cs
│   ├── ProfileController.cs
│   └── CategoriesController.cs
│
├── Data/
│   ├── MovieDbContext.cs
│   ├── DbInitializer.cs
│   └── UnitOfWork/
│       ├── IUnitOfWork.cs
│       └── UnitOfWork.cs
│
├── Helpers/
│   ├── BookingRulesHelper.cs
│   ├── DateTimeExtensions.cs
│   ├── EmailTemplateHelper.cs
│   ├── EnumExtensions.cs
│   ├── IEmailService.cs
│   ├── ImageHelper.cs
│   ├── PaginatedList.cs
│   ├── QueryableExtensions.cs
│   ├── SmtpEmailSender.cs
│   ├── SmtpEmailService.cs
│   ├── SmtpOptions.cs
│   ├── PriceFormatter.cs
│   └── ValidationHelpers.cs
│
├── MappingProfiles/
│   ├── IdentityProfile.cs
│   ├── BookingProfile.cs
│   ├── CategoryProfile.cs
│   ├── CinemaProfile.cs
│   ├── MovieProfile.cs
│   └── ShowtimeProfile.cs
│
├── Models/
│   ├── Entities/
│   │   ├── Actor.cs
│   │   ├── BaseEntity.cs
│   │   ├── Booking.cs
│   │   ├── BookingSeat.cs
│   │   ├── Cart/
│   │   │   ├── Cart.cs
│   │   │   └── CartItem.cs
│   │   ├── Category.cs
│   │   ├── Cinema.cs
│   │   ├── Hall.cs
│   │   ├── Movie.cs
│   │   ├── MovieActor.cs
│   │   ├── MovieCategory.cs
│   │   ├── MovieImg.cs
│   │   ├── Notification/
│   │   │   └── Notification.cs
│   │   ├── Payment/
│   │   │   └── Payment.cs
│   │   ├── Seat.cs
│   │   ├── Showtime.cs
│   │   ├── Watchlist/
│   │   │   ├── Watchlist.cs
│   │   │   └── WatchlistItem.cs
│   │   ├── SocialMediaLink.cs
│   │   └── UserMovieWatchlist.cs
│   ├── Enums/
│   │   ├── BookingStatus.cs
│   │   ├── MovieStatus.cs
│   │   ├── PaymentMethod.cs
│   │   ├── PaymentStatus.cs
│   │   ├── SeatType.cs
│   │   ├── ShowtimeStatus.cs
│   │   └── Notifications/
│   │       └── NotificationType.cs
│   └── ViewModels/
│       ├── ActorVM.cs
│       ├── BookingVM.cs
│       ├── CategoryVM.cs
│       ├── CinemaVM.cs
│       ├── HallVM.cs
│       ├── HomeVM.cs
│       ├── MovieListVM.cs
│       ├── MovieDetailVM.cs
│       ├── MovieActorVM.cs
│       ├── MovieCategoryVM.cs
│       ├── MovieImgVM.cs
│       ├── SeatVM.cs
│       ├── ShowtimeVM.cs
│       └── SocialMediaLinkVM.cs
│
├── Repositories/
│   ├── IRepositories/
│   │   ├── IBaseRepository.cs
│   │   ├── IBookingsRepository.cs
│   │   ├── ICategoriesRepository.cs
│   │   ├── ICinemasRepository.cs
│   │   ├── IMoviesRepository.cs
│   │   ├── IShowtimesRepository.cs
│   │   └── IHomeRepository.cs
│   └── 
│     ├── BaseRepository.cs
│     ├── BookingsRepository.cs
│     ├── CategoriesRepository.cs
│     ├── CinemasRepository.cs
│     ├── MoviesRepository.cs
│     ├── ShowtimesRepository.cs
│     └── HomeRepository.cs
│
├── Services/
│   ├── Interfaces/
│   │   ├── IBookingService.cs
│   │   ├── ICategoryService.cs
│   │   ├── ICinemaService.cs
│   │   ├── IHomeService.cs
│   │   ├── IMovieService.cs
│   │   ├── IShowtimeService.cs
│   └── Implementations/
│       ├── BookingService.cs
│       ├── CategoryService.cs
│       ├── CinemaService.cs
│       ├── HomeService.cs
│       ├── MovieService.cs
│       ├── PaymentService.cs
│       └── ShowtimeService.cs
│
├── TempHtml/
│   ├── EmailTemplates/
│   │   ├── WelcomeEmail.html
│   │   ├── OTPConfirmation.html
│   │   ├── PasswordReset.html
│   │   └── ...
│   └── BookingConfirmation/
│
├── Utility/
│   └── SD.cs
│
├── Views/
│   ├── Booking/
│   ├── Cinema/
│   ├── Home/
│   │   ├── Index.cshtml
│   │   ├── About.cshtml
│   │   ├── Contact.cshtml
│   │   ├── FAQ.cshtml
│   │   ├── Terms.cshtml
│   │   ├── News.cshtml
│   │   ├── Privacy.cshtml
│   │   └── RefoundPolicy.cshtml
│   ├── Movie/
│   ├── Showtime/
│   ├── Profile/
│   ├── Categories/
│   └── Shared/
│       ├── Components/
│       ├── _Layout.cshtml
│       ├── _ValidationScriptsPartial.cshtml
│       ├── Error.cshtml
│       ├── _Search.cshtml
│       ├── _Footer.cshtml
│       ├── _Header.cshtml
│       ├── _Loader.cshtml
│       ├── _NotificationPartial.cshtml
│       └── _Pagination.cshtml
│
├── wwwroot/
│   ├── css/
│   ├── js/
│   ├── lib/
│   ├── images/
│   │   └── logo.png
│   └── uploads/
│       ├── movies/
│       ├── actors/
│       ├── cinemas/
│       ├── users/
│       └── banners/
│
├── GlobalUsings.cs
├── Program.cs
├── ServiceCollectionExtensions.cs
├── appsettings.json
└── SeedData.cs   # optional database seeding
