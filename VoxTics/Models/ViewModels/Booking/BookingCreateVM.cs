namespace VoxTics.Models.ViewModels.Booking
{
    public class BookingCreateVM
    {
        [Required(ErrorMessage = "Showtime is required")]
        public int ShowtimeId { get; set; }

        [Required(ErrorMessage = "Number of tickets is required")]
        [Range(1, 20, ErrorMessage = "You can book between 1 and 20 tickets")]
        public int NumberOfTickets { get; set; }

        [Required(ErrorMessage = "Please select seats")]
        public List<int> SelectedSeatIds { get; set; } = new List<int>();

        [Required(ErrorMessage = "Payment method is required")]
        public string PaymentMethod { get; set; } = string.Empty;

        public string? Notes { get; set; }

        // Read-only info for display
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public string HallName { get; set; } = string.Empty;
        public DateTime ShowTime { get; set; }
        public decimal PricePerSeat { get; set; }

        // Computed
        public decimal TotalAmount => PricePerSeat * SelectedSeatIds.Count;
    }
}
