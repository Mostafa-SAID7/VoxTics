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
│        └─ MovieViewModel.cs
│        └─ CategoryViewModel.cs
		views/
			Categories/
				  ├─ _CategoryForm.cshtml
				  ├─ _CategoriesTable.cshtml
				  ├─ Index.cshtml
				  ├─ Create.cshtml
				  ├─ Edit.cshtml
				  └─ Delete.cshtml

			Movies (include in scripts + styles css in the same file page)
				_MovieForm
				_MoviesTable
				Index.cshtml + (filter +search +pagination + card) with ajax live script 
				Create.cshtml as modal
				Edit.cshtml as modal
				Delete.cshtml as modal
			shared/
				_Layout.cshtml
				add scripts lib+ styles lib like animation.css +sweetalert2 +toastr +bootstrap +jquery +bt icons+ jquery validation +ajax
				_ValidationScriptsPartial
				Error
			_ViewImports.cshtml
			_ViewStart
├─ Controllers/
│  └─ MoviesController.cs           # Public-facing controller
	  BookingController
	  CinemasController
	  CategoriesController.cs
	  HomeController.cs
	  UsersController
	  ShowtimesController
├─ Data/
│  └─ MovieDbContext.cs
├─ Helpers/
│  └─ PaginatedList.cs
├─ MappingProfiles/
│  └─ MovieProfile.cs               # AutoMapper profile
	  CategoryProfile
	  BookingProfile
	  CinemaProfile
	  UserProfile


├─ Models/
│  ├─ Entities/
│  │  ├─ Actor.cs
│  │  ├─ Booking.cs
│  │  ├─ Category.cs
│  │  ├─ Cinema.cs
│  │  ├─ Movie.cs
│  │  ├─ MovieActor.cs
│  │  ├─ MovieCategory.cs
│  │  ├─ MovieImg.cs
│  │  └─ Showtime.cs
│  └─ Enums/
│     └─ MovieStatus.cs
	ViewModels/
		simple for public index/details
│     └─ MovieVM.cs                 # For public index/details
├─ Repositories/
│  ├─ Interfaces/
│  │  ├─ IMovieRepository.cs
│  │  ├─ ICinemaRepository.cs
│  │  ├─ ICategoryRepository.cs
│  │  └─ IUserRepository.cs
		IBaseRepository.cs
│  └─ Implementations/
│     ├─ MovieRepository.cs
│     ├─ CinemaRepository.cs
│     ├─ CategoryRepository.cs
│     └─ UserRepository.cs
		BaseRepository.cs
	  ServiceCollectionExtensions.cs
├── Utility
│   └── SD.cs                # Static details (constants, roles, etc.)
├─ Views/(include in scripts + styles css in the same file page)
│  ├─ Movies/
│  │  ├─ Index.cshtml (with filter +search +pagination + card) with ajax live script
│  │  ├─ _MovieCards.cshtml
│  │  └─ _DetailsPartial.cshtml as modal
│  └─ Shared/
		add scripts lib+ styles lib like animation.css +sweetalert2 +toastr +bootstrap +jquery +bt icons+ jquery validation +ajax 
│     └─ _Layout.cshtml
		_Pagination.cshtml
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
