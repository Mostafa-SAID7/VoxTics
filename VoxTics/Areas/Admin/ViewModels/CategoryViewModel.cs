using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace VoxTics.Areas.Admin.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters")]
        [Display(Name = "Category Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Category Image")]


        public string Slug { get; set; } = string.Empty;

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int MovieCount { get; set; }

        // Display-friendly properties
        public string CreatedAtFormatted => CreatedAt.ToString("MMM dd, yyyy");
        public string? UpdatedAtFormatted => UpdatedAt?.ToString("MMM dd, yyyy");
    }
}
