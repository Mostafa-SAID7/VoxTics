using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.Enums;

namespace VoxTics.Models.Entities
{
    public class Booking : BaseEntity
    {
        // -------------------------
        // Required fields
        // -------------------------
        [Required(ErrorMessage = "Showtime is required")]
        public int ShowtimeId { get; set; }

        [Required(ErrorMessage = "Booking number is required")]
        [StringLength(50, ErrorMessage = "Booking number cannot exceed 50 characters")]
        public string BookingNumber { get; set; } = string.Empty;

        [Required]
        [Range(1, 20, ErrorMessage = "Number of tickets must be between 1 and 20")]
        public int NumberOfTickets { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be positive")]
        public decimal TotalAmount { get; set; }

        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal FinalAmount { get; set; }

        [Required]
        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        [Required]
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        [StringLength(100)]
        public string? PaymentMethod { get; set; }

        [StringLength(200)]
        public string? TransactionId { get; set; }

        public DateTime? PaymentDate { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        public DateTime? CancellationDate { get; set; }

        [StringLength(500)]
        public string? CancellationReason { get; set; }

        // -------------------------
        // Foreign keys
        // -------------------------
        [Required(ErrorMessage = "User is required")]
        public string UserId { get; set; } = default!;

        [Required]
        public int MovieId { get; set; }

        [Required]
        public int CinemaId { get; set; }

        // -------------------------
        // Navigation properties
        // -------------------------
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = default!;

        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; } = null!;

        [ForeignKey(nameof(CinemaId))]
        public virtual Cinema Cinema { get; set; } = null!;

        [ForeignKey(nameof(ShowtimeId))]
        public virtual Showtime Showtime { get; set; } = null!;

        public virtual ICollection<BookingSeat> BookingSeats { get; } = new List<BookingSeat>();

        // -------------------------
        // Additional / computed
        // -------------------------
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }  // for repository or reporting

        [NotMapped]
        public bool CanBeCancelled => Status == BookingStatus.Confirmed &&
                                     Showtime.EndTime > DateTime.UtcNow.AddHours(2);

        [NotMapped]
        public decimal SavingsAmount => TotalAmount - FinalAmount;

        [NotMapped]
        public string BookingReference => $"BK{Id:D6}";
    }
}
