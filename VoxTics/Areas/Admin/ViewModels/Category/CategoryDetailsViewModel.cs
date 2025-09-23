using System;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Admin.ViewModels.Category
{
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters")]
        [Display(Name = "Category Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Slug")]
        public string Slug { get; set; } = string.Empty;

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        public int MovieCount { get; set; } = 0;

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Display-friendly properties
        public string CreatedAtFormatted => CreatedAt.HasValue ? CreatedAt.Value.ToString("MMM dd, yyyy") : string.Empty;
        public string UpdatedAtFormatted => UpdatedAt.HasValue ? UpdatedAt.Value.ToString("MMM dd, yyyy") : string.Empty;
        public string StatusBadge => IsActive ? "badge bg-success" : "badge bg-secondary";
    }
}
