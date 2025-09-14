using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels.Booking
{
    public class BookingCreateEditViewModel
    {
        public int Id { get; set; } // For edit scenarios

        [Required(ErrorMessage = "Showtime is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid showtime selection")]
        public int ShowtimeId { get; set; }

        [Required(ErrorMessage = "Number of tickets is required")]
        [Range(1, 20, ErrorMessage = "Number of tickets must be between 1 and 20")]
        public int NumberOfTickets { get; set; }

        [Required(ErrorMessage = "Total amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be greater than 0")]
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Discount amount cannot be negative")]
        [DataType(DataType.Currency)]
        public decimal DiscountAmount { get; set; } = 0;

        [Required(ErrorMessage = "Final amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Final amount must be greater than 0")]
        [DataType(DataType.Currency)]
        public decimal FinalAmount { get; set; }

        [Required(ErrorMessage = "Booking status is required")]
        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        [Required(ErrorMessage = "Payment status is required")]
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        [StringLength(100, ErrorMessage = "Payment method cannot exceed 100 characters")]
        public string? PaymentMethod { get; set; }

        [StringLength(200, ErrorMessage = "Transaction ID cannot exceed 200 characters")]
        public string? TransactionId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? PaymentDate { get; set; }

        [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters")]
        public string? Notes { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTime? CancellationDate { get; set; }

        [StringLength(500, ErrorMessage = "Cancellation reason cannot exceed 500 characters")]
        public string? CancellationReason { get; set; }

        [Required(ErrorMessage = "User is required")]
        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Movie is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid movie selection")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Cinema is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid cinema selection")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "At least one seat must be selected")]
        public List<int> SelectedSeatIds { get; set; } = new List<int>();

        // -------------------------
        // Computed / Display properties
        // -------------------------
        [Display(Name = "Booking Reference")]
        public string BookingReference => $"BK{Id:D6}";

        [Display(Name = "Can Be Cancelled")]
        public bool CanBeCancelled { get; set; }

        [Display(Name = "Savings Amount")]
        [DataType(DataType.Currency)]
        public decimal SavingsAmount => TotalAmount - FinalAmount;

        // Optional display helpers for admin tables
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public string HallName { get; set; } = string.Empty;
        public DateTime ShowDateTime { get; set; }
        public string ShowDateTimeFormatted => ShowDateTime.ToString("yyyy-MM-dd HH:mm");
        public string BookingDateFormatted => BookingDate.ToString("yyyy-MM-dd");
    }
}
