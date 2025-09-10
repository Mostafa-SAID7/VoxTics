VoxTics/
│
├── 📂 Models
│   ├── 📂 Entities
│   │   ├── Movie.cs
│   │   ├── Booking.cs
│   │   ├── Seat.cs
│   │   ├── Showtime.cs
│   │   └── ...
│   │
│   ├── 📂 Enums
│   │   ├── BookingStatus.cs
│   │   ├── BookingSortBy.cs
│   │   ├── MovieStatus.cs
│   │   ├── MovieSortBy.cs
│   │   ├── PaymentStatus.cs
│   │   ├── SeatType.cs
│   │   ├── ShowtimeStatus.cs
│   │   ├── SortOrder.cs
│   │   └── ...
│   │
│   └── BaseEntity.cs
│
├── 📂 ViewModels
│   ├── 📂 Filters
│   │   ├── FilterBase.cs
│   │   ├── MovieFilterVM.cs
│   │   ├── BookingFilterVM.cs
│   │   └── ...
│   │
│   ├── 📂 DTOs
│   │   ├── MovieDto.cs
│   │   ├── BookingDto.cs
│   │   └── ...
│   │
│   └── 📂 Responses
│       ├── PagedResponse.cs
│       ├── ApiResponse.cs
│       └── ...
│
├── 📂 Helpers
│   ├── PaginatedList.cs
│   ├── SearchHelper.cs
│   ├── SortingHelper.cs
│   ├── DateTimeExtensions.cs
│   └── QueryExtensions.cs
│
├── 📂 Repositories
│   ├── 📂 Interfaces
│   │   ├── IMovieRepository.cs
│   │   ├── IBookingRepository.cs
│   │   └── ...
│   │
│   └── 📂 Implementations
│       ├── MovieRepository.cs
│       ├── BookingRepository.cs
│       └── ...
│
├── 📂 Services
│   ├── 📂 Interfaces
│   │   ├── IMovieService.cs
│   │   └── ...
│   │
│   └── 📂 Implementations
│       ├── MovieService.cs
│       └── ...
│
├── 📂 Controllers
│   ├── MoviesController.cs
│   ├── BookingsController.cs
│   └── ...
│
├── 📂 Data
│   ├── MovieDbContext.cs
│   └── Migrations/
│
├── 📂 Views  (لو MVC)
│   ├── Movies
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── ...
│   │
│   └── Shared
│       ├── _Layout.cshtml
│       ├── _PaginationPartial.cshtml
│       └── ...
│
└── VoxTics.csproj
