using System.Globalization;

namespace VoxTics.Models.ViewModels.Booking
{
    public class BookingTableVM
    {
        public int Id { get; set; }

        // Booking reference
        public string BookingReference { get; set; } = string.Empty;

        // Basic info
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public string HallName { get; set; } = string.Empty;
        public DateTime ShowDateTime { get; set; }
        public int NumberOfTickets { get; set; }
        public List<string> SeatNumbers { get; set; } = new List<string>();

        // Payment & amounts
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
        public BookingStatus Status { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;

        // Booking date
        public DateTime BookingDate { get; set; }

        // Cancellation info
        public bool CanBeCancelled { get; set; }
        public string? CancellationReason { get; set; }
        public DateTime? CancellationDate { get; set; }

        // Read-only computed display properties
        public string ShowDateTimeFormatted => ShowDateTime.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
        public string BookingDateFormatted => BookingDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        public string FormattedTotalAmount => TotalAmount.ToString("C", CultureInfo.InvariantCulture);
        public string FormattedFinalAmount => FinalAmount.ToString("C", CultureInfo.InvariantCulture);

        public string StatusBadge => Status switch
        {
            BookingStatus.Pending => "badge bg-warning",
            BookingStatus.Confirmed => "badge bg-success",
            BookingStatus.Cancelled => "badge bg-danger",
            _ => "badge bg-secondary"
        };

        public string PaymentStatusBadge => PaymentStatus switch
        {
            PaymentStatus.Pending => "badge bg-warning",
            PaymentStatus.Processing => "badge bg-success",
            PaymentStatus.Failed => "badge bg-danger",
            _ => "badge bg-secondary"
        };
    }
}
