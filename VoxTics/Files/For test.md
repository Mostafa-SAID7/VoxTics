VoxTics/
├─ Areas/
│  └─ Admin/
│     ├─ Controllers/
│     │  └─ MoviesController.cs
			HomeController.cs
│     └─ ViewModels/
			add validation attribute
			AdminDashboardViewModel.cs
			MovieActorViewModel.cs
			MovieCreateEditViewModel (used Validation))
			MovieListItemViewModel
│        └─ MovieCategoryViewModel.cs
			MovieImgViewModel.cs
		views/
			Home/
					AdminDashboard.cshtml
			Movies (include in scripts + styles css in the same file page)
					_MovieForm
					_MoviesTable
					Index.cshtml + (filter +search +pagination + card) with ajax live script 
					_Create.cshtml as modal
					_Edit.cshtml as modal
					_Delete.cshtml as modal
					_Details.cshtml
			shared/
				_AdminLayout.cshtml
				add scripts lib+ styles lib like animation.css +sweetalert2 +toastr +bootstrap +jquery +bt icons+ jquery validation +ajax
				_ValidationScriptsPartial
				Error
			_ViewImports.cshtml
			_ViewStart
├─ Controllers/
	  HomeController.cs
│  └─ MoviesController.cs           # Public-facing controller

├─ Data/
│  └─ MovieDbContext.cs
├─ Helpers/
 ├─ FilterBase.cs
 ├─ PaginatedList.cs
 ├─ SearchHelper.cs
 └─ ValidationHelpers.cs
	ImageHelper.cs
Models/
	Entities/
		BaseEntity
		IAuditable
		Movie
		MovieActor
		MovieCategory
		MovieImg
	Enums/
		MovieSortBy
		SortOrder
		MovieStatus
├─ MappingProfiles/
      BaseProfile.cs
│  └─ MovieProfile.cs               # AutoMapper profile
├─ Repositories or Services/
│  ├─ Interfaces/
		 IBaseRepository.cs					
		 save changes method to commit changes to the database +
│  │  ├─ IMovieRepository.cs
│  └─ Implementations/
		 BaseRepository.cs
│     ├─ MovieRepository.cs
├── Utility
│   └── SD.cs                # Static details (constants, roles, etc.)
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
    ServiceCollectionExtensions.cs(For collect all services in one class + Mapper)

when movie model 

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VoxTics.Models.Enums;

namespace VoxTics.Models.Entities
{
    public class Movie : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Director { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes")]
        public int Duration { get; set; } // match repo’s DurationMinutes usage

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }

        [Range(0.0, 10.0)]
        public decimal Rating { get; set; }  // repo expects decimal, not nullable double

        [Required]
        [StringLength(20)]
        public string Language { get; set; } = "EN";

        [StringLength(50)]
        public string? Country { get; set; }

        [StringLength(10)]
        public string? AgeRating { get; set; }

        public string? ImageUrl { get; set; }
        public string? TrailerImageUrl { get; set; }

        public bool IsFeatured { get; set; } = false; // repo uses this for GetFeaturedMoviesAsync

        [Required]
        public MovieStatus Status { get; set; } = MovieStatus.Upcoming;
        public string? TrailerUrl { get; set; }
        public string ShortDescription { get; set; } = string.Empty;
        // Navigation properties
        public virtual ICollection<MovieCategory> MovieCategories { get; set; } = new List<MovieCategory>();
        public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
        public virtual ICollection<MovieImg> MovieImages { get; set; } = new List<MovieImg>();
        public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        // ✅ Optional: Social media links for the movie
        public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();
    }
}
                        ┌───────────────┐
                        │  MovieRepo    │
                        │ IMovieRepository│
                        └──────┬────────┘
                               │
           ┌───────────────────┴───────────────────┐
           │                                       │
   ┌───────▼────────┐                     ┌────────▼─────────┐
   │  IBaseRepository│                     │ Movie-specific   │             Services\
   │      CRUD       │                     │    Methods       │                 MovieService.cs
   └───────┬────────┘                     └────────┬─────────┘              
           │                                       │                        Helpers\
 ┌─────────┴─────────┐          ┌─────────────────┴─────────────────┐           PaginatedList
 │ GetByIdAsync(id)  │          │ GetMovieCountByStatusAsync(status)│           SearchHelper
 │ GetAllAsync(term) │          │ GetMoviesForAdminAsync(includeDel)│           ImageHelper
 │ AddAsync(entity)  │          │ GetFeaturedMoviesAsync(take)      │           FilterBase
 │ UpdateAsync(entity)│         │ GetAllWithIncludesAsync(includeDel)   │       ValidationHelpers
 │ DeleteAsync(id)   │          │ GetPagedMoviesAsync(search,sort,...)  │
 │ DeleteAsync(entity)│         │ GetAllCategories()                    │   MappingProfiles\
 └─────────┬─────────┘          └─────────────────┬─────────────────┘           BaseProfile
           │                                       │                            MovieProfile
           ▼                                       ▼
   ┌──────────────┐                       ┌───────────────┐                 models\
   │ Query(),      │                       │ IncludeOps    │                    Movie.cs
   │ FindAsync(...)│                       │ GetByIdWithIncludesAsync(...) │    MovieImg.cs    
   │ FirstOrDefault│                       │ FindWithIncludesAsync(...)   │     MovieCategory.cs
   └──────────────┘                       └───────────────┘                     MovieActor.cs
           │                                       │                            BaseEntity.cs
           ▼                                       ▼                            IAuditable.cs
   ┌──────────────┐                       ┌───────────────┐                  Enums\
   │ CountAsync() │                       │ BulkOps       │                      MovieStatus.cs   
   │ ExistsAsync()│                       │ AddRangeAsync │                      SortOrder.cs
   └──────────────┘                       │ UpdateRangeAsync │                   MovieSortBy.cs
                                          │ DeleteRangeAsync │                   PageSize.cs
                                           │ Update(entity)   │                  SearchOptions.cs
                                          │ Remove(entity)   │   Area\Admin\ViewModels\
                                          │ SaveChangesAsync │                   MovieCreateEditViewModel.cs
                                          └───────────────┘                      MovieListItemViewModel.cs
                                                                                 MovieCategoryViewModel.cs
                                                                                 MovieActorViewModel.cs
                                                                                 MovieImgViewModel.cs
                                                                                 
