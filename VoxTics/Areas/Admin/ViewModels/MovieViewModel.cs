using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10000")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Status is required")]

        [Display(Name = "Poster")]
        public IFormFile? ImageFile { get; set; }

        // editable only as URL if you want to show existing image
        public string? ImageUrl { get; set; }

        [Display(Name = "Categories")]
        [MinLength(1, ErrorMessage = "Select at least one category")]
        public List<int> SelectedCategoryIds { get; set; } = new List<int>();

        // helper for populating dropdown / checkbox list in view
        public List<SelectListItem> AvailableCategories { get; set; } = new List<SelectListItem>();
        public VoxTics.Models.Enums.MovieStatus Status { get; set; } = VoxTics.Models.Enums.MovieStatus.Upcoming;

    }
}
