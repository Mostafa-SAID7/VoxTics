namespace VoxTics.Areas.Admin.ViewModels.Admin
{
    public class BookingSummary
    {
        public int BookingId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public DateTime Showtime { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
