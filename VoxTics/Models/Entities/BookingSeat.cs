using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.Entities
{
    public class BookingSeat : BaseEntity
    {
        [Required]
        public int BookingId { get; set; }

        [Required]
        public int SeatId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Seat price must be positive")]
        public decimal SeatPrice { get; set; }

        // Navigation properties
        [ForeignKey(nameof(BookingId))]
        public virtual Booking Booking { get; set; } = null!;

        [ForeignKey(nameof(SeatId))]
        public virtual Seat Seat { get; set; } = null!;
    }
}
