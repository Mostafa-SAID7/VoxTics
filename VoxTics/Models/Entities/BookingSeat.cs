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

        [Required, Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue)]
        public decimal SeatPrice { get; set; }

        public virtual Booking Booking { get; set; } = null!;
        public virtual Seat Seat { get; set; } = null!;

        [NotMapped]
        public string SeatLabel => Seat?.SeatNumber ?? string.Empty;
    }
}
