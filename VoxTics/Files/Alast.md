add loader in layout
MovieTickets/
├─ Areas/
│  └─ Admin/
│     ├─ Controllers/
			BookingController
			CinemasController
│     │  └─ MoviesController.cs
	  │  └─ CategoriesController.cs
			HomeController.cs
			UsersController
			ShowtimesController
│     └─ ViewModels/
			add validation attribute
			AdminDashboardVM
			BookingViewModel
			CinemaViewModel
│        └─ MovieViewModel.cs
			ShowtimeViewModel
			UserViewModel
│        └─ CategoryViewModel.cs
		views/
			Categories/
				  ├─ _CategoryForm.cshtml
				  ├─ _CategoriesTable.cshtml
				  ├─ Index.cshtml
				  ├─ Create.cshtml
				  ├─ Edit.cshtml
				  └─ Delete.cshtml
			Booking/
				_BookingsTable.cshtml
				Index.cshtml + (filter +search +pagination + card) with ajax live script for admin mangage approval,reject
			Categories/
			_CategoryForm.cshtml
			_CategoriesTable.cshtml
			Index.cshtml + (filter +search +pagination + card) with ajax live script
			Create.cshtml as modal
			Edit.cshtml as modal
			Delete.cshtml as modal
			Cinemas/
				_CinemaForm.cshtml
				_CinemasTable.cshtml
				Index.cshtml + (filter +search +pagination + card) with ajax live script 
				Create.cshtml as modal
				Edit.cshtml as modal
				Delete.cshtml as modal
			Home/
			AdminDashboard.cshtml
			Users/
				_UsersTable.cshtml
				Index.cshtml + (filter +search +pagination + card) with ajax live script for admin mangage active,deactive,role
			Movies (include in scripts + styles css in the same file page)
				_MovieForm
				_MoviesTable
				Index.cshtml + (filter +search +pagination + card) with ajax live script 
				_Create.cshtml as modal
				_Edit.cshtml as modal
				_Delete.cshtml as modal
			shared/
				_AdminLayout.cshtml
				add scripts lib+ styles lib like animation.css +sweetalert2 +toastr +bootstrap +jquery +bt icons+ jquery validation +ajax
				_ValidationScriptsPartial
				Error
			Users/
				_UserForm.cshtml
				_UsersTable.cshtml
				Index.cshtml + (filter +search +pagination + card) with ajax live script for admin mangage active,deactive,role
				Create.cshtml as modal
				Edit.cshtml as modal
				Delete.cshtml as modal
			_ViewImports.cshtml
			_ViewStart
├─ Controllers/
	  BookingController
	  CategoriesController.cs
	  CinemasController
	  HomeController.cs
│  └─ MoviesController.cs           # Public-facing controller
	  ShowtimesController
	  UsersController
├─ Data/
│  └─ MovieDbContext.cs
├─ Helpers/
│  └─ PaginatedList.cs
├─ MappingProfiles/
	  BookingProfile
	  CategoryProfile
	  CinemaProfile
│  └─ MovieProfile.cs               # AutoMapper profile
	  ShowtimeProfile
	  UserProfile


├─ Models/
│  ├─ Entities/
│  │  ├─ Actor.cs
│  │  ├─ Booking.cs
│  │  ├─ Category.cs
│  │  ├─ Cinema.cs
		 Hall
│  │  ├─ Movie.cs
│  │  ├─ MovieActor.cs
│  │  ├─ MovieCategory.cs
│  │  ├─ MovieImg.cs
│  │  ├─ User.cs	
		 Seat
│  │  └─ Showtime.cs
│  └─ Enums/
│     └─ MovieStatus.cs
	ViewModels/
		simple for public index/details
		BookingVM
		CategoryVM
		CinemaVM
		HomeVM
│     └─ MovieVM.cs                 # For public index/details
		ShowtimeVM
		UserVM
├─ Repositories/
│  ├─ Interfaces/
		IBaseRepository.cs
		IBookingRepository
│  │  ├─ ICategoryRepository.cs
│  │  ├─ ICinemaRepository.cs
│  │  ├─ IMovieRepository.cs
		IShowtimeRepository
│  │  └─ IUserRepository.cs
│  └─ Implementations/
		BaseRepository.cs
		BookingRepository
│     ├─ CategoryRepository.cs
│     ├─ CinemaRepository.cs
│     ├─ MovieRepository.cs
		ShowtimeRepository
│     └─ UserRepository.cs
	  ServiceCollectionExtensions.cs
├── Utility
│   └── SD.cs                # Static details (constants, roles, etc.)
├─ Views/(include in scripts + styles css in the same file page)
│  ├─ Movies/
│  │  ├─ Index.cshtml (with filter +search +pagination + card) with ajax live script
│  │  ├─ _MovieCards.cshtml
│  │  └─ _DetailsPartial.cshtml as modal
│  ├─ Cinemas/
│  │  ├─ Index.cshtml (with filter +search +pagination + card) with ajax live script
│  │  ├─ _CinemaCards.cshtml
│  │  └─ _DetailsPartial.cshtml as modal
│  ├─ Categories/
│  │  ├─ Index.cshtml (with filter +search +pagination + card) with ajax live script
│  │  └─ Details.cshtml page Related Movies by only this category
│  ├─ Showtimes/
│  │  ├─ Index.cshtml (with filter +search +pagination + card) with ajax live script
│  │  ├─ _ShowtimeCards.cshtml
│  │  └─ _DetailsPartial.cshtml as modal
│  ├─ Bookings/
│  │  ├─ Index.cshtml (with filter +search +pagination + card) with ajax live script for user to book ticket
│  │  ├─ _BookingCards.cshtml
│  │  └─ _CreatePartial.cshtml as modal from user clicked book now
		 _EditPartial.cshtml as modal for user from User Profile
		 _DetailsPartial.cshtml as modal for user from User Profile
			
│  ├─ Users/
│  │  ├─ Index.cshtml (with filter +search +pagination + card) with ajax live script for user mangage profile
│  │  ├─ _LoginForm.cshtml
│  │  ├─ _RegisterForm.cshtml
│  │  ├─ _EditCards.cshtml
		 _PorfileView.cshtml	
	  Home/for (static page)
	  │     └─ Index.cshtml Landing page with ajax live script for search movie + upcoming movie + cinema + category + banner
			   About.cshtml
			   Contact.cshtml
			   FAQ.cshtml
			   Terms.cshtml
			   News.cshtml 
			   Privacy.cshtml
			   RefoundPolicy.cshtml
│  └─ Shared/
		add scripts lib+ styles lib like animation.css +sweetalert2 +toastr +bootstrap +jquery +bt icons+ jquery validation +ajax 
│     └─ _Layout.cshtml
		_Pagination.cshtml
		_Loader
		_Header
		_Footer
		_ValidationScriptsPartial
		Error
	_ViewImports.cshtml
	__ViewStart
├─ wwwroot/
│  ├─ css/
│  ├─ js/
│  └─ lib/
	images/
		logo.png

	uploads/
	├─ movies/
	├─ actors/
	├─ cinemas/
	├─ users/
	├─ banners/
└─ Program.cs
	appsettings
└── GlobalUsings.cs
