Project/
├── Areas
│   └── Admin
│       ├── Controllers
│       │   ├── DashboardController.cs
│       │   ├── AnalyticsController.cs
│       │   ├── MoviesController.cs           # إدارة الأفلام + ربط الممثلين
│       │   ├── CategoriesController.cs       # CRUD + Slug Generation
│       │   ├── CinemasController.cs
│       │   ├── ShowtimesController.cs
│       │   ├── BookingsController.cs
│       │   ├── UsersController.cs            # إدارة المستخدمين
│       │   ├── RolesController.cs            # إدارة الأدوار
│       │   ├── SettingsController.cs         # إعدادات عامة
│       │   ├── LogsController.cs
│       │   ├── NotificationsController.cs
│       │   ├── ReportsController.cs
│       │   ├── ActorsController.cs           # إدارة الممثلين وربطهم بالأفلام
│       │   └── PaymentsController.cs (اختياري لو إدارة المدفوعات)
│       │
│       ├── Views
│       │   ├── Dashboard
│       │   ├── Analytics
│       │   ├── Movies
│       │   ├── Categories
│       │   ├── Cinemas
│       │   ├── Showtimes
│       │   ├── Bookings
│       │   ├── Users
│       │   ├── Roles
│       │   ├── Settings
│       │   ├── Logs
│       │   ├── Notifications
│       │   ├── Reports
│       │   └── Actors
│       │
│       ├── Admin.csproj
│       ├── _ViewImports.cshtml
│       └── _ViewStart.cshtml
│
│   └── Identity
│       ├── Controllers
│       │   ├── AccountController.cs
│       │   ├── ManageController.cs
│       │   ├── RolesController.cs (اختياري)
│       │   └── ExternalLoginController.cs (اختياري)
│       ├── Views
│       │   ├── Account
│       │   ├── Manage
│       │   └── Shared
│       └── IdentityHostingStartup.cs
│
├── Controllers
│   ├── HomeController.cs                # صفحات ثابتة + الرئيسية
│   ├── MoviesController.cs              # عرض الأفلام والتفاصيل
│   ├── CinemasController.cs             # عرض السينمات
│   ├── ShowtimesController.cs           # الجداول الزمنية
│   ├── BookingsController.cs            # الحجز والشراء
│   ├── CategoriesController.cs          # للعرض فقط باستخدام Slug
│   ├── ReviewsController.cs
│   ├── PaymentsController.cs
│   ├── WishlistController.cs
│   └── CartController.cs
│
├── Models
│   ├── Movie.cs
│   ├── Category.cs                      # يحتوي على Slug
│   ├── Cinema.cs
│   ├── Showtime.cs
│   ├── Booking.cs
│   ├── Review.cs
│   ├── Payment.cs
│   ├── Wishlist.cs
│   ├── CartItem.cs
│   └── ApplicationUser.cs               # توسيع الهوية
│
├── ViewModels
│   ├── MovieViewModel.cs
│   ├── CategoryViewModel.cs
│   ├── BookingViewModel.cs
│   ├── PaymentViewModel.cs
│   └── UserViewModel.cs
│
├── Services
│   ├── Interfaces
│   │   ├── IMovieService.cs
│   │   ├── ICategoryService.cs
│   │   ├── IBookingService.cs
│   │   └── IPaymentService.cs
│   └── Implementations
│       ├── MovieService.cs
│       ├── CategoryService.cs           # يتعامل مع Slug Generation
│       ├── BookingService.cs
│       └── PaymentService.cs
│
├── Data
│   ├── ApplicationDbContext.cs
│   └── SeedData.cs                      # بيانات أولية مثل الفئات والأفلام
│
├── Migrations
│
├── wwwroot
│   ├── css
│   ├── js
│   ├── images
│   └── lib
│
├── Views
│   ├── Shared
│   │   ├── _Layout.cshtml
│   │   ├── _ValidationScriptsPartial.cshtml
│   │   └── _PartialComponents.cshtml
│   ├── Home
│   ├── Movies
│   ├── Cinemas
│   ├── Showtimes
│   ├── Bookings
│   ├── Categories                       # تعرض الفئات باستخدام Slug
│   ├── Reviews
│   ├── Payments
│   ├── Wishlist
│   └── Cart
│
├── Program.cs
├── Startup.cs
└── appsettings.json
