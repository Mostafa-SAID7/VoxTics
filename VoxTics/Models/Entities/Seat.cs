using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VoxTics.Models.Enums;

namespace VoxTics.Models.Entities
{
    public class Seat : BaseEntity
    {
        // Foreign Key
        [Required]
        public int HallId { get; set; }

        // Seat details
        [Required]
        [StringLength(10)]
        public string SeatNumber { get; set; } = string.Empty;

        [Required]
        public int RowNumber { get; set; }
        public string? Row { get; set; }   // <-- add this if you want rows like "A", "B", etc.

        [Required]
        public int SeatNumberInRow { get; set; }

        [Required]
        public SeatType Type { get; set; } = SeatType.VIP;

        public bool IsActive { get; set; } = true;

        // Navigation properties
        [ForeignKey("HallId")]
        public virtual Hall Hall { get; set; } = null!;

        public virtual ICollection<BookingSeat> BookingSeats { get; set; } = new HashSet<BookingSeat>();

        // ✅ Optional: Social media links for special promotions
        public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();
    }
}
