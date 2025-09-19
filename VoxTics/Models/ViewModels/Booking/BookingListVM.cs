namespace VoxTics.Models.ViewModels.Booking
{
    /// <summary>
    /// Summary representation of a booking for paginated lists.
    /// </summary>
    public class BookingListVM
    {
        public int BookingId { get; set; }
        public string BookingReference { get; set; } = string.Empty;

        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;

        public DateTime ShowtimeStart { get; set; }
        public BookingStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public decimal FinalAmount { get; set; }
    }
}
