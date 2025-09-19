using VoxTics.Models.Enums;

namespace VoxTics.Models.ViewModels.Booking
{
    /// <summary>
    /// Detailed view of a booking for confirmation or history.
    /// </summary>
    public class BookingDetailsVM
    {
        public int BookingId { get; set; }
        public string BookingReference { get; set; } = string.Empty;

        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public DateTime ShowtimeStart { get; set; }

        public int NumberOfTickets { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public BookingStatus Status { get; set; }

        public DateTime BookingDate { get; set; }

        public IEnumerable<BookingSeatVM> Seats { get; set; } = new List<BookingSeatVM>();
    }
}
