using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.ViewModels.Booking
{
    /// <summary>
    /// Input model for creating a booking.
    /// </summary>
    public class BookingCreateVM
    {
        [Required(ErrorMessage = "Showtime is required")]
        public int ShowtimeId { get; set; }

        [Required(ErrorMessage = "At least one seat must be selected.")]
        [MinLength(1, ErrorMessage = "At least one seat must be selected.")]
        public List<int> SelectedSeatIds { get; set; } = new();

        [Required(ErrorMessage = "Number of tickets is required")]
        [Range(1, 20, ErrorMessage = "Number of tickets must be between 1 and 20")]
        public int NumberOfTickets { get; set; }

        [Required(ErrorMessage = "Total amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be positive")]
        public decimal TotalAmount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Discount must be positive")]
        public decimal DiscountAmount { get; set; } = 0;

        [Required(ErrorMessage = "Final amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Final amount must be positive")]
        public decimal FinalAmount { get; set; }

        public string? CouponCode { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Movie is required")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Cinema is required")]
        public int CinemaId { get; set; }

        // Optional payment info
        public string? PaymentMethod { get; set; }
        public string? TransactionId { get; set; }
    }
}
