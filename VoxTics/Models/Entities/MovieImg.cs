using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class MovieImg : BaseEntity
    {
        [Required]
        public int MovieId { get; set; }

        [Required, StringLength(500)]
        [Url]
        public string ImageUrl { get; set; } = string.Empty;

        [StringLength(200)]
        public string? AltText { get; set; }

        public bool IsMain { get; set; } = false;

        public virtual Movie Movie { get; set; } = null!;
    }
}
