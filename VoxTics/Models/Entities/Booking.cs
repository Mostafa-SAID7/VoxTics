using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int ShowtimeId { get; set; }
        public virtual Showtime Showtime { get; set; } = default!;

        [Required, Range(1, 20)]
        public int NumberOfTickets { get; set; }

        [Required, Column(TypeName = "decimal(18,2)"), Range(0, double.MaxValue)]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18,2)"), Range(0, double.MaxValue)]
        public decimal DiscountAmount { get; set; } = 0;

        [Required, Column(TypeName = "decimal(18,2)"), Range(0, double.MaxValue)]
        public decimal FinalAmount { get; set; }

        [Required]
        public BookingStatus Status { get; set; } = BookingStatus.Pending;


        public DateTime BookingDate { get; init; } = DateTime.UtcNow;
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

        public virtual ICollection<BookingSeat> BookingSeats { get; set; } = new List<BookingSeat>();

        [NotMapped]
        public bool CanBeCancelled =>
            Status == BookingStatus.Confirmed &&
            !IsCheckedIn &&
            Showtime.EndTime > DateTime.UtcNow.AddHours(2);

        [NotMapped]
        public string BookingReference => $"BK{Id:D6}";

        public bool IsCheckedIn { get; set; }
    }
}
