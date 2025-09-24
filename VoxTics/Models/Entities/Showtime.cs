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
        public virtual Movie Movie { get; set; } = null!;

        [Required]
        public int HallId { get; set; }
        public virtual Hall Hall { get; set; } = null!;

        [Required]
        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; } = null!;

        [Required]
        public DateTime StartTime { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Duration { get; set; }

        [Required, Column(TypeName = "decimal(8,2)"), Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public bool Is3D { get; set; } = false;
        [MaxLength(50)]
        public string Language { get; set; } = "EN";
        [MaxLength(50)]
        public string ScreenType { get; set; } = "Standard";
        public ShowtimeStatus Status { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        [NotMapped]
        public DateTime EndTime => StartTime.AddMinutes(Duration);
        [Required]
        public bool IsCancelled { get; set; } = false; // for cancellation tracking

        [Required]
        public int AvailableSeats { get; set; }
    }

}
