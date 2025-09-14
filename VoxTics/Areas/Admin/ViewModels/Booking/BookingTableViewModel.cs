namespace VoxTics.Areas.Admin.ViewModels.Booking
{
    public class BookingTableViewModel
    {
        public int Id { get; set; }
        public string BookingNumber { get; set; } = string.Empty;
        public string UserFullName { get; set; } = string.Empty;
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
        public int NumberOfTickets { get; set; }
        public decimal TotalAmount { get; set; }
        public BookingStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public bool CanBeCancelled { get; set; }
    }
}
