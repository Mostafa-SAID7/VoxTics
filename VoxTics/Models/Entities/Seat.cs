using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.Entities
{
    public class Seat : BaseEntity
    {
        [Required]
        public int HallId { get; set; }

        [Required, MaxLength(1)]
        public string Row { get; set; } = string.Empty;

        [Required, Range(1, 100)]
        public int NumberInRow { get; set; }

        [Required]
        public SeatType Type { get; set; } = SeatType.VIP;

        public bool IsActive { get; set; } = true;
        public bool IsAvailable { get; set; } = true;

        [ForeignKey(nameof(HallId))]
        public virtual Hall Hall { get; set; } = null!;
        [Required]
        [StringLength(10)]
        public string SeatNumber { get; set; } = string.Empty;
        public virtual ICollection<BookingSeat> BookingSeats { get; set; } = new HashSet<BookingSeat>();
    }
}
