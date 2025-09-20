using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels.Cinema;

namespace VoxTics.Models.Entities
{
    public class Showtime : BaseEntity
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        public int HallId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Duration { get; set; } // Minutes

        [Required, Column(TypeName = "decimal(8,2)"), Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public ShowtimeStatus Status { get; set; } = ShowtimeStatus.Scheduled;

        public bool Is3D { get; set; } = false;

        [MaxLength(50)]
        public string Language { get; set; } = "EN";

        [MaxLength(50)]
        public string ScreenType { get; set; } = "Standard";

        [Required]
        public int AvailableSeats { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; } // Concurrency token

        public bool IsCancelled { get; set; } = false;

        [NotMapped]
        public DateTime EndTime => StartTime.AddMinutes(Duration);

        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; } = null!;

        [ForeignKey(nameof(HallId))]
        public virtual Hall Hall { get; set; } = null!;
        [Required]
        public int CinemaId { get; set; }
        [ForeignKey(nameof(CinemaId))]
        public virtual Cinema Cinema { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
