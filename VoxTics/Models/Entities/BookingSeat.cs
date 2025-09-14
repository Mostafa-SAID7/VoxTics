using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.Entities
{
    public class BookingSeat : BaseEntity
    {
        // Foreign Keys
        [Required]
        public int BookingId { get; set; }

        [Required]
        public int SeatId { get; set; }

        // Extra data
        [Required, Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Seat price must be positive")]
        public decimal SeatPrice { get; set; }

        // Navigation properties
        public virtual Booking Booking { get; set; } = null!;
        public virtual Seat Seat { get; set; } = null!;
        public string SeatNumber { get; internal set; }
    }
}
