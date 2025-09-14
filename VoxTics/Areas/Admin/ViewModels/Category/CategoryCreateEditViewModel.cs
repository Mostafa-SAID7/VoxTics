using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Admin.ViewModels.Category
{
    public class CategoryCreateEditViewModel
    {
        public int Id { get; set; } // For Edit only

        [Required(ErrorMessage = "Category name is required")]
        [MaxLength(50, ErrorMessage = "Category name cannot exceed 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Slug is required")]
        [MaxLength(60, ErrorMessage = "Slug cannot exceed 60 characters")]
        [RegularExpression("^[a-z0-9-]+$", ErrorMessage = "Slug can only contain lowercase letters, numbers, and hyphens")]
        public string Slug { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        // Optional display helper
        public int MovieCount { get; set; } = 0; // Count of movies under this category
        public string StatusBadge => IsActive ? "badge bg-success" : "badge bg-secondary";
    }
}
