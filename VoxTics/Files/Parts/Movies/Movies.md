1️⃣ السيناريو العام لكل العمليات على Movie
A. Main App (للمستخدمين النهائيين)
1. عرض قائمة الأفلام (Index)

وظيفة: عرض الأفلام على شكل كروت أو جدول.

عمليات:

المستخدم يزور /movies?page=1&search=xyz&sort=releaseDate.

Controller يستدعي Service: GetMoviesAsync(search, sort, page, pageSize).

Service:

يقرأ بيانات من Repository (GetMoviesQueryable() + Include(Category, MovieActors, MovieImages)).

يطبق Search على العنوان أو المخرج.

يطبق Sorting حسب ReleaseDate أو Rating أو Price.

يطبق Pagination عبر QueryableExtensions.Paginate().

يحول كل Movie → MovieViewModel.

Controller يعرض View مع Model + Pagination Controls.

Helpers: PaginationHelper, SlugHelper, ImageHelper.

2. مشاهدة تفاصيل فيلم (Details)

وظيفة: عرض كل المعلومات عن فيلم معين.

عمليات:

المستخدم يضغط على زر “Details” في الكارد.

Controller يستدعي Service: GetMovieDetailsAsync(slug).

Service:

يقرأ Movie من Repository مع جميع العلاقات: Actors, Categories, MovieImages, Showtimes.

يحول Movie → MovieDetailViewModel.

View تعرض:

جميع الصور

قائمة الممثلين

الفئة كرابط يؤدي لصفحة تعرض كل الأفلام بنفس الفئة

زر الحجز (Book Now)

كل تفاصيل الفيلم: Duration, Price, Rating, Language.

3. الحجز (Booking)

وظيفة: السماح للمستخدم بحجز الفيلم.

عمليات:

المستخدم يضغط زر “Book Now”.

Controller يستدعي Service: CreateBooking(userId, movieId, showtimeId).

Service يتحقق من:

توفر التذاكر

صلاحية الوقت

يحفظ Booking في DB عبر UnitOfWork.

B. Admin Area (للمسؤولين)
1. إدارة الأفلام (CRUD)

وظيفة: إنشاء، تعديل، حذف، عرض الأفلام.

عمليات:

عملية	Flow
Create	Controller يستقبل MovieCreateViewModel → Service يتحقق من البيانات + SlugHelper + ImageHelper → Repository → UnitOfWork.SaveChanges()
Read / Index	Controller يستدعي Service → Repository → Mapping → ViewModel → عرض Pagination + Search + Sorting
Update	Controller يستقبل MovieEditViewModel → Service يتحقق ويطبق التغييرات + ImageHelper لتحديث الصور → Repository → UnitOfWork.SaveChanges()
Delete	Controller يستدعي Service.DeleteMovie(id) → Repository.Remove → UnitOfWork.SaveChanges()

Features إضافية:

Pagination + Search + Sorting

عرض الممثلين والفئات والصور المرتبطة في الجدول

إمكانية عرض تفاصيل الفيلم بشكل سريع داخل Admin قبل التعديل

2. إدارة الصور (MovieImages)

وظيفة: رفع، تعديل، حذف صور الأفلام.

عمليات:

المستخدم يرفع صورة في Form (Create/Edit).

Service يستخدم ImageHelper: resize, rename, save في المسار المناسب.

يحفظ المسار في MovieImages داخل DB.

3. إدارة الممثلين والفئات

وظيفة: ربط الفيلم بممثلين وفئات.

عمليات:

أثناء Create/Edit يتم اختيار الممثلين والفئات من List.

Service يقوم بإنشاء علاقات MovieActor و MovieCategory.

Repository يحفظ هذه العلاقات مع الـ Movie في DB.

C. Helpers المستخدمة
Helper	الاستخدام
SlugHelper	توليد slug للفيلم عند Create/Update
ImageHelper	معالجة الصور: resize, save, delete
PaginationHelper / QueryableExtensions	تقسيم النتائج في Index (Main & Admin)
ValidationHelper	التحقق من صحة البيانات قبل الحفظ
Mapping	تحويل Movie ↔ MovieViewModel / MovieDetailViewModel
D. Data Flow كامل (Main + Admin)
[DB: Movies, Categories, Actors, Images, Bookings, Showtimes]
      │
      ▼
[Repository: MovieRepository]
      │
      ▼
[Unit of Work]
      │
      ▼
[Service: MovieService / MovieAdminService]
      │---> Business Logic
      │---> Pagination / Search / Sorting
      │---> Helpers (Slug, Image, Validation)
      │---> Mapping to ViewModel
      ▼
[Controller: MoviesController (Main) / Admin/MoviesController]
      │
      ▼
[View: Index, Details, Create, Edit]
      │
      ▼
[User Interface / Admin Interface]

E. السيناريو الكامل عند الاستخدام

Main App:

المستخدم يدخل الصفحة الرئيسية أو صفحة الأفلام.

يبحث أو يرتب أو يختار صفحة محددة → Pagination.

يضغط Details → يعرض كل المعلومات والصور والممثلين والفئة.

يضغط Book Now → يتم الحجز.

Admin Area:

المسؤول يدخل صفحة الأفلام → عرض جميع الأفلام مع Pagination + Search + Sorting.

ينشئ فيلم جديد → يملأ البيانات + يرفع صور + يختار الممثلين والفئات.

يعدل فيلم → يغير البيانات أو الصور أو الفئات/الممثلين.

يحذف فيلم → حذف من DB + إزالة الصور المرتبطة.