Project/
├── Services
│   ├── Main
│   │   ├── Interfaces
│   │   │   ├── IMovieService.cs          # منطق جلب وعرض الأفلام + البحث والتفاصيل
│   │   │   ├── ICinemaService.cs         # إدارة وعرض بيانات السينمات
│   │   │   ├── IShowtimeService.cs       # إدارة الجداول الزمنية للأفلام
│   │   │   ├── IBookingService.cs        # الحجز ومعالجة بيانات التذاكر
│   │   │   ├── ICategoryService.cs       # جلب الفئات + توليد Slug
│   │   │   ├── IReviewService.cs         # إضافة/عرض التقييمات والمراجعات
│   │   │   ├── IPaymentService.cs        # معالجة عمليات الدفع
│   │   │   ├── IWishlistService.cs       # إدارة قائمة المفضلة
│   │   │   └── ICartService.cs           # منطق سلة التسوق (إضافة/حذف عناصر)
│   │   └── Implementations
│   │       ├── MovieService.cs           # تنفيذ منطق الأفلام
│   │       ├── CinemaService.cs          # تنفيذ منطق السينمات
│   │       ├── ShowtimeService.cs        # تنفيذ منطق الجداول الزمنية
│   │       ├── BookingService.cs         # تنفيذ منطق الحجز
│   │       ├── CategoryService.cs        # تنفيذ منطق الفئات وتوليد Slug
│   │       ├── ReviewService.cs          # تنفيذ منطق التقييمات
│   │       ├── PaymentService.cs         # تنفيذ منطق الدفع
│   │       ├── WishlistService.cs        # تنفيذ منطق المفضلة
│   │       └── CartService.cs            # تنفيذ منطق سلة التسوق
│
│   ├── Admin
│   │   ├── Interfaces
│   │   │   ├── IUserManagementService.cs  # CRUD للمستخدمين + تعيين أدوار
│   │   │   ├── IRoleManagementService.cs  # إدارة الأدوار والصلاحيات
│   │   │   ├── IReportService.cs          # إنشاء التقارير (حجوزات، أرباح..)
│   │   │   ├── INotificationService.cs    # إرسال الإشعارات للمستخدمين
│   │   │   ├── ISettingsService.cs        # التحكم في الإعدادات العامة
│   │   │   └── IAnalyticsService.cs       # إحصائيات وتحليلات الاستخدام
│   │   └── Implementations
│   │       ├── UserManagementService.cs   # تنفيذ منطق إدارة المستخدمين
│   │       ├── RoleManagementService.cs   # تنفيذ منطق الأدوار
│   │       ├── ReportService.cs           # تنفيذ منطق التقارير
│   │       ├── NotificationService.cs     # تنفيذ منطق الإشعارات
│   │       ├── SettingsService.cs         # تنفيذ منطق الإعدادات
│   │       └── AnalyticsService.cs        # تنفيذ منطق التحليلات
│
│   └── Identity
│       ├── Interfaces
│       │   ├── IAccountService.cs         # تسجيل الدخول/الخروج/التسجيل
│       │   ├── IExternalLoginService.cs   # تسجيل الدخول الخارجي (Google, Facebook) (اختياري)
│       │   └── IManageService.cs          # إدارة الحساب: كلمة المرور، البريد، البيانات
│       └── Implementations
│           ├── AccountService.cs          # تنفيذ منطق الحسابات
│           ├── ExternalLoginService.cs    # تنفيذ منطق تسجيل الدخول الخارجي (اختياري)
│           └── ManageService.cs           # تنفيذ منطق إدارة الحساب
