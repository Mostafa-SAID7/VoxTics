using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoxTics.Models.ViewModels.Movie;

namespace VoxTics.Models.ViewModels.Category
{
    public class CategoryVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(50, ErrorMessage = "Category name cannot exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        // Read-only properties
        public int MovieCount { get; set; }


    }
}
