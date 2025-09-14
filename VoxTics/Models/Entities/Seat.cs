using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.Entities
{
    public class Seat : BaseEntity
    {
        [Required]
        public int HallId { get; set; }

        [Required]
        [StringLength(10)]
        public string SeatNumber { get; set; } = string.Empty;

        [Required]
        public int RowNumber { get; set; }

        public string? Row { get; set; } // optional "A", "B", etc.

        [Required]
        public int SeatNumberInRow { get; set; }

        [Required]
        public SeatType Type { get; set; } = SeatType.VIP;

        public bool IsActive { get; set; } = true;

        // Navigation properties
        [ForeignKey(nameof(HallId))]
        public virtual Hall Hall { get; set; } = null!;

        public virtual ICollection<BookingSeat> BookingSeats { get; set; } = new HashSet<BookingSeat>();

    }
}
