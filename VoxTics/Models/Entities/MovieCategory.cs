using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.Entities
{
    public class MovieCategory : BaseEntity
    {
        // Foreign Keys
        [Required]
        public int MovieId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        // Navigation properties
        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; } = null!;

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } = null!;

        // ✅ Optional: Additional properties for future use
        // e.g., Featured flag, DisplayOrder
        public bool IsFeatured { get; set; } = false;

        public int DisplayOrder { get; set; } = 0;
    }
}
