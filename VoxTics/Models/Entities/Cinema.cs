using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace VoxTics.Models.Entities
{
    public class Cinema : BaseEntity
    {
        [Required, StringLength(120)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [EmailAddress, StringLength(100)]
        public string? Email { get; set; }

        [Phone, StringLength(20)]
        public string? Phone { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(100)]
        public string? State { get; set; }

        [MaxLength(100)]
        public string? Country { get; set; }

        [MaxLength(20)]
        public string? PostalCode { get; set; }

        [Url, StringLength(200)]
        public string? Website { get; set; }

        [Url, StringLength(200)]
        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual ICollection<Hall> Halls { get; set; } = new List<Hall>();
        public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
        public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();

        [NotMapped]
        public int TotalSeats => Halls?.Sum(h => h.Seats?.Count ?? 0) ?? 0;

        [NotMapped]
        public int HallCount => Halls?.Count ?? 0;

        [NotMapped]
        public int ShowtimeCount => Showtimes?.Count ?? 0;

        [NotMapped]
        public string DisplayImage => !string.IsNullOrEmpty(ImageUrl) ? ImageUrl : "/images/defaults/placeholder.jpg";
    }
}
