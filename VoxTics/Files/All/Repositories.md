Project/
├── Repositories
│   ├── Main
│   │   ├── Interfaces
│   │   │   ├── IMovieRepository.cs         # عمليات القراءة/الكتابة للأفلام من قاعدة البيانات
│   │   │   ├── ICinemaRepository.cs        # الوصول لبيانات السينمات
│   │   │   ├── IShowtimeRepository.cs      # CRUD للجداول الزمنية
│   │   │   ├── IBookingRepository.cs       # CRUD للحجوزات
│   │   │   ├── ICategoryRepository.cs      # CRUD للفئات + البحث بالـ Slug
│   │   │   ├── IReviewRepository.cs        # CRUD للتقييمات
│   │   │   ├── IPaymentRepository.cs       # عمليات الدفع وتخزين السجلات
│   │   │   ├── IWishlistRepository.cs      # الوصول لقوائم المفضلة
│   │   │   └── ICartRepository.cs          # CRUD لسلة التسوق
│   │   └── Implementations
│   │       ├── MovieRepository.cs          # تنفيذ عمليات الأفلام باستخدام EF Core
│   │       ├── CinemaRepository.cs         # تنفيذ عمليات السينمات
│   │       ├── ShowtimeRepository.cs       # تنفيذ عمليات الجداول الزمنية
│   │       ├── BookingRepository.cs        # تنفيذ عمليات الحجوزات
│   │       ├── CategoryRepository.cs       # تنفيذ عمليات الفئات
│   │       ├── ReviewRepository.cs         # تنفيذ عمليات التقييمات
│   │       ├── PaymentRepository.cs        # تنفيذ عمليات الدفع
│   │       ├── WishlistRepository.cs       # تنفيذ عمليات المفضلة
│   │       └── CartRepository.cs           # تنفيذ عمليات السلة
│
│   ├── Admin
│   │   ├── Interfaces
│   │   │   ├── IUserRepository.cs          # CRUD للمستخدمين
│   │   │   ├── IRoleRepository.cs          # CRUD للأدوار
│   │   │   ├── IReportRepository.cs        # الاستعلام عن البيانات للتقارير
│   │   │   ├── INotificationRepository.cs  # تخزين وإدارة الإشعارات
│   │   │   ├── ISettingsRepository.cs      # حفظ واسترجاع الإعدادات
│   │   │   └── IAnalyticsRepository.cs     # جلب بيانات التحليلات
│   │   └── Implementations
│   │       ├── UserRepository.cs           # تنفيذ منطق المستخدمين
│   │       ├── RoleRepository.cs           # تنفيذ منطق الأدوار
│   │       ├── ReportRepository.cs         # تنفيذ منطق التقارير
│   │       ├── NotificationRepository.cs   # تنفيذ منطق الإشعارات
│   │       ├── SettingsRepository.cs       # تنفيذ منطق الإعدادات
│   │       └── AnalyticsRepository.cs      # تنفيذ منطق التحليلات
│
│   └── Identity
│       ├── Interfaces
│       │   ├── IAccountRepository.cs       # الوصول لجداول الحسابات
│       │   ├── IExternalLoginRepository.cs # بيانات تسجيل الدخول الخارجي (اختياري)
│       │   └── IManageRepository.cs        # تحديث بيانات الحساب وكلمة المرور
│       └── Implementations
│           ├── AccountRepository.cs        # تنفيذ عمليات الحساب
│           ├── ExternalLoginRepository.cs  # تنفيذ عمليات الدخول الخارجي
│           └── ManageRepository.cs         # تنفيذ عمليات إدارة الحساب
