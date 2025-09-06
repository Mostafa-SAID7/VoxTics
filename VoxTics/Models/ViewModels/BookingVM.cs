using System.Linq;

namespace VoxTics.Models.ViewModels
{
    public class BookingVM
    {
        // Core booking info
        public int Id { get; set; }
        public string BookingNumber { get; set; } = string.Empty;
        public int Quantity => SeatNumbers.Count();
        public IEnumerable<string> SeatNumbers { get; set; } = Enumerable.Empty<string>();

        // Pricing
        public decimal TotalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount => TotalPrice - DiscountAmount;

        // Status
        public BookingStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string? PaymentMethod { get; set; }
        public bool CanBeCancelled { get; set; }

        // Dates
        public DateTime BookingDate { get; set; }
        public DateTime? PaymentDate { get; set; }

        // Related entities
        public string MovieTitle { get; set; } = string.Empty;
        public string? MoviePoster { get; set; }
        public string CinemaName { get; set; } = string.Empty;
        public string HallName { get; set; } = string.Empty;
        public DateTime ShowtimeStart { get; set; }
        public int ShowtimeId { get; set; }

        // Computed / formatted helpers
        public string FormattedTotalPrice => TotalPrice.ToString("C");
        public string FormattedFinalAmount => FinalAmount.ToString("C");
        public string FormattedBookingDate => BookingDate.ToFullDateTimeString();  // using DateTimeExtensions
        public string FormattedShowtime => ShowtimeStart.ToFullDateTimeString();

        public string StatusDisplay => Status.GetDisplayName();
        public string PaymentStatusDisplay => PaymentStatus.GetDisplayName();
    }
}
