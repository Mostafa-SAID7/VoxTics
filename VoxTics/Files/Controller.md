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
├─ Controllers/
	  BookingController
	  CategoriesController.cs
	  CinemasController
	  HomeController.cs
│  └─ MoviesController.cs           # Public-facing controller
	  ShowtimesController
	  UsersController


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
	  
