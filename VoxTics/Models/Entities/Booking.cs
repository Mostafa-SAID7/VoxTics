using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int ShowtimeId { get; set; }
        public Showtime Showtime { get; set; } = null!;

        // optional user reference; if you have a User entity, replace string with UserId type
        public string? UserId { get; set; }

        [Required, StringLength(120)]
        public string CustomerName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string CustomerEmail { get; set; } = string.Empty;

        [Range(1, 20)]
        public int SeatsBooked { get; set; } = 1;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
