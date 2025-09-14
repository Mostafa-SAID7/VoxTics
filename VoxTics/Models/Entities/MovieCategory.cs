using System.ComponentModel.DataAnnotations;

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
        public virtual Movie Movie { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}
