Admin/
├── Helpers
│   ├── SlugHelper.cs           # لتوليد وتحويل النصوص إلى Slug صديق للروابط
│   ├── ImageHelper.cs          # لرفع الصور، تغيير حجمها أو حفظها
│   ├── DateTimeHelper.cs       # تنسيقات التاريخ/الوقت أو التحويل بين المناطق الزمنية
│   ├── EmailHelper.cs          # لإرسال البريد الإلكتروني (التأكيدات، الإشعارات)
│   ├── PaginationHelper.cs     # منطق تقسيم النتائج إلى صفحات
│   ├── ValidationHelper.cs     # عمليات تحقق إضافية أو مخصصة
│   ├── FileHelper.cs           # تعامل عام مع الملفات (رفع، حذف، قراءة)
│   ├── ReportHelper.cs         # تجهيز البيانات لتقارير الـ Admin (اختياري)
│   └── NotificationHelper.cs   # تنسيق أو إعداد الإشعارات قبل الإرسال (اختياري)

│   ├── Identity
│   │   ├── PasswordHelper.cs        # التحقق من قوة كلمة المرور أو إنشاء كلمات مرور عشوائية آمنة
│   │   ├── TokenHelper.cs           # إنشاء/تحقق من رموز التأكيد (Email Confirmation, Password Reset)
│   │   ├── ClaimsHelper.cs          # استخراج المطالبات (Claims) أو الأدوار من المستخدم
│   │   ├── RoleHelper.cs            # اختصارات للتحقق أو إنشاء الأدوار والصلاحيات
│   │   └── TwoFactorHelper.cs       # منطق مساعد لإعداد وإرسال رموز المصادقة الثنائية (2FA)