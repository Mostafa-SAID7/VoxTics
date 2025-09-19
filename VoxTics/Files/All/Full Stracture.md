Project/
├── Controllers
│   ├── HomeController.cs             # صفحات ثابتة + الرئيسية
│   ├── MoviesController.cs           # عرض الأفلام والتفاصيل
│   ├── CinemasController.cs          # عرض السينمات
│   ├── ShowtimesController.cs        # الجداول الزمنية
│   ├── BookingsController.cs         # الحجز والشراء
│   ├── CategoriesController.cs       # عرض الفئات باستخدام Slug
│   ├── ReviewsController.cs
│   ├── PaymentsController.cs
│   ├── WishlistController.cs
│   └── CartController.cs
│
├── Areas
│   ├── Admin
│   │   ├── Controllers
│   │   │   ├── DashboardController.cs
│   │   │   ├── AnalyticsController.cs
│   │   │   ├── MoviesController.cs           # إدارة الأفلام + ربط الممثلين
│   │   │   ├── CategoriesController.cs       # CRUD + Slug
│   │   │   ├── CinemasController.cs
│   │   │   ├── ShowtimesController.cs
│   │   │   ├── BookingsController.cs
│   │   │   ├── UsersController.cs            # إدارة المستخدمين
│   │   │   ├── RolesController.cs            # إدارة الأدوار
│   │   │   ├── SettingsController.cs
│   │   │   ├── LogsController.cs
│   │   │   ├── NotificationsController.cs
│   │   │   ├── ReportsController.cs
│   │   │   └── ActorsController.cs
│   │   └── Views
│   │       └── (Views لكل Controller)
│   │
│   └── Identity
│       ├── Controllers
│       │   ├── AccountController.cs
│       │   ├── ManageController.cs
│       │   ├── RolesController.cs (اختياري)
│       │   └── ExternalLoginController.cs (اختياري)
│       └── Views
│           └── (Login, Register, Manage, Password Reset)
│
├── Models
│   ├── Category.cs
│   ├── Actor.cs
│   ├── Movie.cs
│   ├── MovieActor.cs
│   ├── Cinema.cs
│   ├── Showtime.cs
│   ├── Booking.cs
│   ├── Payment.cs
│   ├── Review.cs
│   ├── Wishlist.cs
│   ├── CartItem.cs
│   └── ApplicationUser.cs
│
├── ViewModels
│   ├── MovieViewModel.cs
│   ├── CategoryViewModel.cs
│   ├── CinemaViewModel.cs
│   ├── ShowtimeViewModel.cs
│   ├── BookingViewModel.cs
│   ├── ReviewViewModel.cs
│   ├── PaymentViewModel.cs
│   ├── WishlistViewModel.cs
│   └── CartViewModel.cs
│
├── Mappings
│   ├── MovieMapping.cs
│   ├── CategoryMapping.cs
│   ├── CinemaMapping.cs
│   ├── ShowtimeMapping.cs
│   ├── BookingMapping.cs
│   ├── ReviewMapping.cs
│   ├── PaymentMapping.cs
│   ├── WishlistMapping.cs
│   └── CartMapping.cs
│
├── Services
│   ├── Main
│   │   ├── Interfaces
│   │   │   ├── IMovieService.cs
│   │   │   ├── ICinemaService.cs
│   │   │   ├── IShowtimeService.cs
│   │   │   ├── IBookingService.cs
│   │   │   ├── ICategoryService.cs
│   │   │   ├── IReviewService.cs
│   │   │   ├── IPaymentService.cs
│   │   │   ├── IWishlistService.cs
│   │   │   └── ICartService.cs
│   │   └── Implementations
│   │       ├── MovieService.cs
│   │       ├── CinemaService.cs
│   │       ├── ShowtimeService.cs
│   │       ├── BookingService.cs
│   │       ├── CategoryService.cs
│   │       ├── ReviewService.cs
│   │       ├── PaymentService.cs
│   │       ├── WishlistService.cs
│   │       └── CartService.cs
│   │
│   ├── Admin
│   │   ├── Interfaces
│   │   │   ├── IUserManagementService.cs
│   │   │   ├── IRoleManagementService.cs
│   │   │   ├── IReportService.cs
│   │   │   ├── INotificationService.cs
│   │   │   ├── ISettingsService.cs
│   │   │   └── IAnalyticsService.cs
│   │   └── Implementations
│   │       ├── UserManagementService.cs
│   │       ├── RoleManagementService.cs
│   │       ├── ReportService.cs
│   │       ├── NotificationService.cs
│   │       ├── SettingsService.cs
│   │       └── AnalyticsService.cs
│   │
│   └── Identity
│       ├── Interfaces
│       │   ├── IAccountService.cs
│       │   ├── IExternalLoginService.cs (اختياري)
│       │   └── IManageService.cs
│       └── Implementations
│           ├── AccountService.cs
│           ├── ExternalLoginService.cs (اختياري)
│           └── ManageService.cs
│
├── Repositories
│   ├── Base
│   │   ├── IBaseRepository.cs
│   │   ├── BaseRepository.cs
│   │   └── IUnitOfWork.cs
│   │
│   ├── Main
│   │   ├── IMovieRepository.cs
│   │   ├── ICategoryRepository.cs
│   │   ├── ICinemaRepository.cs
│   │   ├── IShowtimeRepository.cs
│   │   ├── IBookingRepository.cs
│   │   ├── IReviewRepository.cs
│   │   ├── IPaymentRepository.cs
│   │   ├── IWishlistRepository.cs
│   │   └── ICartRepository.cs
│   │
│   ├── Admin
│   │   ├── IUserRepository.cs
│   │   ├── IRoleRepository.cs
│   │   ├── IReportRepository.cs
│   │   ├── INotificationRepository.cs
│   │   ├── ISettingsRepository.cs
│   │   └── IAnalyticsRepository.cs
│   │
│   └── Identity
│       ├── IAccountRepository.cs
│       ├── IExternalLoginRepository.cs (اختياري)
│       └── IManageRepository.cs
│
├── Helpers
│   ├── SlugHelper.cs
│   ├── ImageHelper.cs
│   ├── DateTimeHelper.cs
│   ├── EmailHelper.cs
│   ├── FileHelper.cs
│   ├── PaginationHelper.cs
│   ├── QueryableExtensions.cs
│   ├── ValidationHelper.cs
│   ├── ReportHelper.cs
│   ├── NotificationHelper.cs
│   └── Identity
│       ├── PasswordHelper.cs
│       ├── TokenHelper.cs
│       ├── ClaimsHelper.cs
│       ├── RoleHelper.cs
│       └── TwoFactorHelper.cs
│
├── EmailSystem
│   ├── IEmailService.cs
│   ├── SmtpEmailService.cs
│   ├── SmtpEmailSender.cs
│   └── SmtpOptions.cs
