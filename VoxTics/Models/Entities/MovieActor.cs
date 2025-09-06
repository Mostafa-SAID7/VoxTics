using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.Entities
{
    public class MovieActor : BaseEntity
    {
        // Foreign Keys
        [Required]
        public int MovieId { get; set; }

        [Required]
        public int ActorId { get; set; }

        // Role details
        [MaxLength(100)]
        public string? RoleName { get; set; }

        public bool IsMainRole { get; set; } = false;

        // Navigation properties
        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; } = null!;

        [ForeignKey("ActorId")]
        public virtual Actor Actor { get; set; } = null!;

        // ✅ Optional: Social media links for promotion
        public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();
    }
}
