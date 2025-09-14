namespace VoxTics.Models.ViewModels.Booking
{
    public class BookingDetailsVM
    {
        public string BookingReference { get; set; } = string.Empty;
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public string HallName { get; set; } = string.Empty;
        public DateTime ShowTime { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfTickets { get; set; }
        public List<string> SeatNumbers { get; set; } = new List<string>();

        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }

        public BookingStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime? PaymentDate { get; set; }

        public bool CanBeCancelled { get; set; }
        public decimal SavingsAmount { get; set; }

        public string? CancellationReason { get; set; }
        public DateTime? CancellationDate { get; set; }
    }
}
