using System.ComponentModel.DataAnnotations.Schema;
using VoxTics.Areas.Identity.Models.Entities;
namespace VoxTics.Models.Entities
{
    public class Booking : BaseEntity
    {
        [Required]
        public string UserId { get; set; } = default!;
        public virtual ApplicationUser User { get; set; } = default!;

        [Required]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; } = default!;

        [Required]
        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; } = default!;

        [Required]
        public int ShowtimeId { get; set; }
        public virtual Showtime Showtime { get; set; } = default!;

        [Required, Range(1, 20)]
        public int NumberOfTickets { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; } = 0;

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal FinalAmount { get; set; }

        [Required]
        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        [Required]
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        [StringLength(100)]
        public PaymentMethod PaymentMethod { get; set; }

        [StringLength(200)]
        public string? TransactionId { get; set; }

        public DateTime? PaymentDate { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        public virtual ICollection<BookingSeat> BookingSeats { get; set; } = new List<BookingSeat>();

        [NotMapped]
        public bool CanBeCancelled =>
            Status == BookingStatus.Confirmed &&
            Showtime.EndTime > DateTime.UtcNow.AddHours(2);

        [NotMapped]
        public string BookingReference => $"BK{Id:D6}";

        public bool IsCheckedIn { get; set; }
    }
}