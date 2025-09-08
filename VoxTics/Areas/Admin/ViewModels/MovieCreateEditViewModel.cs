using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels
{
    public class MovieCreateEditViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required, StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [StringLength(100)]
        public string Director { get; set; } = string.Empty;

        [StringLength(20)]
        public string Language { get; set; } = string.Empty;

        // External trailer URL (e.g., YouTube)
        public string? TrailerUrl { get; set; }

        // Optional trailer image (thumbnail) upload
        public IFormFile? TrailerImageFile { get; set; }
        public string? TrailerImageUrl { get; set; }    // existing stored trailer image url when editing

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        // Duration (minutes)
        [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes")]
        public int? DurationInMinutes { get; set; }

        // Price
        [Range(0, double.MaxValue, ErrorMessage = "Price must be non-negative")]
        public decimal Price { get; set; }

        // Rating (0.0 - 10.0)
        [Range(0.0, 10.0)]
        public decimal Rating { get; set; }

        // Short description shown in lists
        [StringLength(250)]
        public string? ShortDescription { get; set; }

        // Status (Upcoming, Released, etc.)
        public MovieStatus Status { get; set; } = MovieStatus.Upcoming;

        // Featured flag
        public bool IsFeatured { get; set; } = false;

        // primary poster
        public IFormFile? ImageFile { get; set; }
        public string? ImageUrl { get; set; }     // existing stored poster url (for edit)

        // additional images
        public List<IFormFile> AdditionalImageFiles { get; set; } = new();
        public List<MovieImageViewModel> ExistingImages { get; set; } = new();

        // categories
        public List<int> SelectedCategoryIds { get; set; } = new();
        public List<SelectListItem> AvailableCategories { get; set; } = new();

        // paging for Index view (optional)
        public int PageSize { get; set; } = 12;
        // in MovieCreateEditViewModel
        public List<SelectListItem> StatusList => Enum.GetValues(typeof(MovieStatus))
            .Cast<MovieStatus>()
            .Select(s => new SelectListItem
            {
                Text = s.GetType().GetMember(s.ToString())[0]
                .GetCustomAttribute<DisplayAttribute>()?.Name ?? s.ToString(),
                Value = ((int)s).ToString(),
                Selected = s == Status
            }).ToList();

    }
}
