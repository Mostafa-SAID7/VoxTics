namespace VoxTics.Models.ViewModels
{
    public class BookingFormVM
    {
        // Required ids for booking
        public int UserId { get; set; }      // Optional, if user is logged in
        public int MovieId { get; set; }
        public int ShowtimeId { get; set; }

        // Selected seats
        public IEnumerable<string> SelectedSeats { get; set; } = Enumerable.Empty<string>();

        // Pricing
        public decimal TotalAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal FinalAmount => TotalAmount - (DiscountAmount ?? 0);

        // Optional display info
        public string? MovieTitle { get; set; }
        public DateTime? ShowtimeStart { get; set; }
        public string? HallName { get; set; }
        public string? CinemaName { get; set; }

        // Computed
        public int SeatCount => SelectedSeats.Count();
    }
}
