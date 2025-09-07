using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        // -------------------------
        // Showtime details
        // -------------------------
        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be positive")]
        public int Duration { get; set; }  // in minutes

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }

        [Required]
        public ShowtimeStatus Status { get; set; } = ShowtimeStatus.Scheduled;

        // -------------------------
        // Computed property
        // -------------------------
        [NotMapped]
        public DateTime EndTime => StartTime.AddMinutes(Duration);

        // -------------------------
        // Extended / Optional
        // -------------------------
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

       [NotMapped]
        public int CinemaId => Hall?.CinemaId ?? 0;
        public virtual Cinema Cinema { get; set; } = null!;   // ✅ Reference
        [NotMapped]
        public int TotalSeats => Hall?.Seats?.Count ?? 0;

        [NotMapped]
        public int AvailableSeats => TotalSeats - (Bookings?.SelectMany(b => b.BookingSeats).Count() ?? 0);

        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

        // Optional: marketing hooks
        public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();
    }
}
