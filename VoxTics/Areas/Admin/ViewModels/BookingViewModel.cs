using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User is required")]
        [Display(Name = "User")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Showtime is required")]
        public int ShowtimeId { get; set; }

        [Required(ErrorMessage = "Number of seats is required")]
        [Range(1, 10, ErrorMessage = "Number of seats must be between 1 and 10")]
        [Display(Name = "Number of Seats")]
        public int NumberOfSeats { get; set; }

        [Required(ErrorMessage = "Total price is required")]
        [Range(0.01, 100000, ErrorMessage = "Total price must be greater than 0")]
        [DataType(DataType.Currency)]
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now;

        [Required]
        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        // Navigation properties for display
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public string HallName { get; set; } = string.Empty;
        public DateTime ShowDateTime { get; set; }

        // Display properties with invariant culture
        public string BookingDateFormatted => BookingDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        public string ShowDateTimeFormatted => ShowDateTime.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
        public string FormattedTotalPrice => TotalPrice.ToString("0.00", CultureInfo.InvariantCulture);
        public string BookingReference => $"BK{Id:D6}";

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Booking Status")]
        public string StatusBadge => Status switch
        {
            BookingStatus.Pending => "badge bg-warning",
            BookingStatus.Confirmed => "badge bg-success",
            BookingStatus.Cancelled => "badge bg-danger",
            _ => "badge bg-secondary"
        };

        // Read-only collections
        public IReadOnlyList<PersonalInfoVM> Users { get; } = new List<PersonalInfoVM>();
        public IReadOnlyList<ShowtimeViewModel> Showtimes { get; } = new List<ShowtimeViewModel>();
        public IReadOnlyList<string> SeatNumbers { get; } = new List<string>();

        public string BookingNumber { get; set; } = string.Empty;

        [Range(1, 20, ErrorMessage = "Number of tickets must be between 1 and 20")]
        [Display(Name = "Number of Tickets")]
        public int NumberOfTickets { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be a positive value")]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Discount amount cannot be negative")]
        [Display(Name = "Discount Amount")]
        public decimal DiscountAmount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Final amount must be a positive value")]
        [Display(Name = "Final Amount")]
        public decimal FinalAmount { get; set; }

        [Required(ErrorMessage = "Payment status is required")]
        [Display(Name = "Payment Status")]
        public PaymentStatus PaymentStatus { get; set; }

        [StringLength(100, ErrorMessage = "Payment method cannot exceed 100 characters")]
        [Display(Name = "Payment Method")]
        public string? PaymentMethod { get; set; }

        [StringLength(200, ErrorMessage = "Transaction ID cannot exceed 200 characters")]
        [Display(Name = "Transaction ID")]
        public string? TransactionId { get; set; }

        [Display(Name = "Payment Date")]
        public DateTime? PaymentDate { get; set; }

        [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters")]
        [Display(Name = "Notes")]
        public string? Notes { get; set; }

        [StringLength(500, ErrorMessage = "Cancellation reason cannot exceed 500 characters")]
        [Display(Name = "Cancellation Reason")]
        public string? CancellationReason { get; set; }

        public DateTime? CancellationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Display properties
        public DateTime ShowtimeStart { get; set; }
        public bool CanBeCancelled { get; set; }
        public decimal SavingsAmount { get; set; }
    }
}
