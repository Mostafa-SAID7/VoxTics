namespace VoxTics.Models.Entities
{
    public class SocialMediaLink
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Platform { get; set; } = string.Empty;  // مثال: Twitter, Instagram

        [Required]
        [MaxLength(250)]
        public string Url { get; set; } = string.Empty;
        // Foreign key to Cinema
        public int? CinemaId { get; set; }
        public Cinema? Cinema { get; set; }
        public int ActorId { get; set; }  // Foreign key
        public Actor Actor { get; set; } = null!;
    }
}
