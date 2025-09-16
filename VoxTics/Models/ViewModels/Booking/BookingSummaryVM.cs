namespace VoxTics.Models.ViewModels.Booking
{
    /// <summary>
    /// Summary representation of a booking for paginated lists.
    /// </summary>
    public class BookingSummaryVM
    {
        public string BookingReference { get; set; } = string.Empty;
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public string HallName { get; set; } = string.Empty;
        public DateTime ShowTime { get; set; }
        public int NumberOfTickets { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public string Status { get; set; } = string.Empty;
        public bool CanBeCancelled { get; set; }
        public decimal SavingsAmount { get; set; }
        public List<string> SeatNumbers { get; set; } = new();
    }
}
