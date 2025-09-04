using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int ShowtimeId { get; set; }
        public Showtime Showtime { get; set; } = null!;

        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [StringLength(120)]
        public string? UserName { get; set; }   

        [EmailAddress]
        public string? UserEmail { get; set; }  

        [Range(1, 20)]
        public int SeatsBooked { get; set; } = 1;

        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
