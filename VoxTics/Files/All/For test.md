[Controllers]
   │
   ▼
[Services] --------------------------- Helpers ----------------------------
   │                                     │
   │                                     │
   │                              +-----------------+
   │                              | ValidationHelper| <-- تحقق من البيانات
   │                              +-----------------+
   │
   ├── Main Services                  +----------------+
   │    │                             | PaginationHelper | <-- تقسيم النتائج
   │    │                             +----------------+
   │    │
   │    ├── MovieService  <-----------| SlugHelper      | <-- توليد Slug
   │    ├── CategoryService --------->| FileHelper      | <-- رفع/حفظ الملفات
   │    ├── CinemaService             | ImageHelper     | <-- تعديل الصور
   │    ├── ShowtimeService           | DateTimeHelper  | <-- تنسيقات الوقت
   │    ├── BookingService            | EmailHelper     | <-- إرسال البريد العام
   │    ├── ReviewService             | ReportHelper    | <-- تجهيز تقارير Admin
   │    ├── PaymentService            | NotificationHelper | <-- إشعارات
   │    ├── WishlistService
   │    └── CartService
   │
   ├── Admin Services
   │    ├── UserManagementService
   │    ├── RoleManagementService
   │    ├── ReportService
   │    ├── NotificationService
   │    ├── SettingsService
   │    └── AnalyticsService
   │
   └── Identity Services
        ├── AccountService
        ├── ExternalLoginService
        └── ManageService
               │
               ▼
         [Email System Helpers]
               │
               ├── IEmailService.cs
               ├── SmtpEmailService.cs
               ├── SmtpEmailSender.cs
               └── SmtpOptions.cs

[Repositories]
   │
   ├── Main Repositories
   │    ├── MovieRepository
   │    ├── CategoryRepository
   │    ├── CinemaRepository
   │    ├── ShowtimeRepository
   │    ├── BookingRepository
   │    ├── ReviewRepository
   │    ├── PaymentRepository
   │    ├── WishlistRepository
   │    └── CartRepository
   │
   ├── Admin Repositories
   │    ├── UserRepository
   │    ├── RoleRepository
   │    ├── ReportRepository
   │    ├── NotificationRepository
   │    ├── SettingsRepository
   │    └── AnalyticsRepository
   │
   └── Identity Repositories
        ├── AccountRepository
        ├── ExternalLoginRepository
        └── ManageRepository

[Mappings]
   │
   ├── MovieMapping.cs          # Movie ↔ MovieViewModel
   ├── CategoryMapping.cs       # Category ↔ CategoryViewModel
   ├── CinemaMapping.cs         # Cinema ↔ CinemaViewModel
   ├── ShowtimeMapping.cs       # Showtime ↔ ShowtimeViewModel
   ├── BookingMapping.cs        # Booking ↔ BookingViewModel
   ├── ReviewMapping.cs         # Review ↔ ReviewViewModel
   ├── PaymentMapping.cs        # Payment ↔ PaymentViewModel
   ├── WishlistMapping.cs       # Wishlist ↔ WishlistViewModel
   └── CartMapping.cs           # CartItem ↔ CartItemViewModel

[ViewModels]
   ├── MovieViewModel.cs
   ├── CategoryViewModel.cs
   ├── CinemaViewModel.cs
   ├── ShowtimeViewModel.cs
   ├── BookingViewModel.cs
   ├── ReviewViewModel.cs
   ├── PaymentViewModel.cs
   ├── WishlistViewModel.cs
   └── CartViewModel.cs
