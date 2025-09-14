using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class SocialMediaLink
    {
        // -------------------------
        // Primary Key
        // -------------------------
        public int Id { get; set; }

        // -------------------------
        // Required fields
        // -------------------------
        [Required, MaxLength(50)]
        public string Platform { get; set; } = string.Empty;  // Example: Twitter, Instagram

        [Required, MaxLength(250)]
        public string Url { get; set; } = string.Empty;

        // -------------------------
        // Foreign keys
        // -------------------------
        public int ActorId { get; set; }
        public int? CinemaId { get; set; }

        // -------------------------
        // Navigation properties
        // -------------------------
        public virtual Actor Actor { get; set; } = null!;
        public virtual Cinema? Cinema { get; set; }
    }
}
