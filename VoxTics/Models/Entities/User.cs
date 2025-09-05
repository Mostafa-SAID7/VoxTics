using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Phone, StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(250)]
        public string? Address { get; set; }

        [Required, StringLength(20)]
        public string Role { get; set; } = "User";  // "User" | "Admin"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [StringLength(250)]
        public string? ImageUrl { get; set; }

        // Navigation property
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
