using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class MovieImg : BaseEntity
    {
        // Foreign Key
        [Required(ErrorMessage = "Movie is required")]
        public int MovieId { get; set; }

        // Image information
        [Required(ErrorMessage = "Image URL is required")]
        [StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters")]
        public string ImageUrl { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Alt text cannot exceed 200 characters")]
        public string? AltText { get; set; }

        // Navigation property
        public virtual Movie Movie { get; set; } = null!;
    }
}
