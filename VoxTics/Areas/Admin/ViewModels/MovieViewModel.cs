using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using VoxTics.Helpers;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels
{
    public class MovieViewModel
    {
        // ------------------------------
        // Core movie properties
        // ------------------------------
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        [Display(Name = "Movie Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes")]
        [Display(Name = "Duration (Minutes)")]
        public int DurationInMinutes { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [StringLength(100, ErrorMessage = "Director name cannot exceed 100 characters")]
        [Display(Name = "Director")]
        public string? Director { get; set; }

        [StringLength(100, ErrorMessage = "Language cannot exceed 100 characters")]
        [Display(Name = "Language")]
        public string? Language { get; set; }

        [StringLength(50, ErrorMessage = "Rating cannot exceed 50 characters")]
        [Display(Name = "Rating")]
        public string? Rating { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        [StringLength(500, ErrorMessage = "Trailer URL cannot exceed 500 characters")]
        [Display(Name = "Trailer URL")]
        public string? TrailerUrl { get; set; }

        [Range(0, 10, ErrorMessage = "IMDb rating must be between 0 and 10")]
        [Display(Name = "IMDb Rating")]
        public decimal? ImdbRating { get; set; }

        [Required(ErrorMessage = "Base price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        [Display(Name = "Base Price")]
        public decimal BasePrice { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Movie Status")]
        public MovieStatus Status { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Poster Image")]
        public IFormFile? PosterImageFile { get; set; }
        public IFormFile? TrailerImageFile { get; set; }
        public string? CurrentPosterImage { get; set; }

        [Display(Name = "Categories")]
        public List<int> SelectedCategoryIds { get; set; } = new List<int>();

        [Display(Name = "Actors")]
        public List<int> SelectedActorIds { get; set; } = new List<int>();

        [Display(Name = "Additional Images")]
        public List<IFormFile> AdditionalImages { get; set; } = new List<IFormFile>();

        public List<string> CurrentImages { get; set; } = new List<string>();

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // ------------------------------
        // Listing / pagination
        // ------------------------------
        public PaginatedList<MovieViewModel> Movies { get; set; } =
            new PaginatedList<MovieViewModel>(new List<MovieViewModel>(), 0, 1, 10);

        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        // Filters
        public string? SearchTerm { get; set; }
        public int SelectedCategoryId { get; set; }
        public MovieStatus? SelectedStatus { get; set; }

        // Pagination helpers
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount => Movies.TotalCount;
        public int TotalPages => Movies.TotalPages;
        public bool HasPreviousPage => Movies.HasPreviousPage;
        public bool HasNextPage => Movies.HasNextPage;

        // Sorting
        public string SortBy { get; set; } = "Title";
        public bool SortDescending { get; set; }
        public List<CategoryVM> MovieCategories { get; set; } = new();
        public int ShowtimesCount { get; set; }
        public int BookingsCount { get; set; }
        public List<ActorViewModel> MovieActors { get; set; } = new();
        public List<MovieImageViewModel> Images { get; set; } = new();
        // Dropdown options
        public List<SelectListItem> StatusOptions { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "All Status", Selected = true },
            new SelectListItem { Value = MovieStatus.Upcoming.ToString(), Text = "Upcoming" },
            new SelectListItem { Value = MovieStatus.NowShowing.ToString(), Text = "Now Showing" },
            new SelectListItem { Value = MovieStatus.EndedShowing.ToString(), Text = "Ended Showing" }
        };
        public IEnumerable<SelectListItem> AvailableCategories { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> CategoryOptions
        {
            get
            {
                var options = new List<SelectListItem>
                {
                    new SelectListItem { Value = "0", Text = "All Categories", Selected = SelectedCategoryId == 0 }
                };

                options.AddRange(Categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                    Selected = c.Id == SelectedCategoryId
                }));

                return options;
            }
        }
    }
}
