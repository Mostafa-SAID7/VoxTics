using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using VoxTics.Models.Enums;

namespace VoxTics.Models.Entities
{
    public class Showtime : BaseEntity
    {
        // -------------------------
        // Foreign Keys
        // -------------------------
        [Required]
        public int MovieId { get; set; }

        [Required]
        public int HallId { get; set; }

        [Required]
        public int CinemaId { get; set; }  // <-- EF Core requires a setter

        // -------------------------
        // Showtime details
        // -------------------------
        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be positive")]
        public int Duration { get; set; } // in minutes

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }

        [Required]
        public ShowtimeStatus Status { get; set; } = ShowtimeStatus.Scheduled;

        public bool Is3D { get; set; } = false;

        [MaxLength(50)]
        public string Language { get; set; } = "EN";

        [MaxLength(50)]
        public string ScreenType { get; set; } = "Standard";

        // -------------------------
        // Navigation properties
        // -------------------------
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; } = null!;

        [ForeignKey(nameof(HallId))]
        public virtual Hall Hall { get; set; } = null!;

        [ForeignKey(nameof(CinemaId))]
        public virtual Cinema Cinema { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();

        // -------------------------
        // Computed / NotMapped
        // -------------------------
        [NotMapped]
        public DateTime EndTime => StartTime.AddMinutes(Duration);

        [NotMapped]
        public int TotalSeats => Hall?.Seats?.Count ?? 0;

        [NotMapped]
        public int AvailableSeats => TotalSeats - (Bookings?.SelectMany(b => b.BookingSeats).Count() ?? 0);
    }
}
