namespace VoxTics.Models.ViewModels.Booking
{
    public class BookingSeatVM
    {
        public int SeatId { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public decimal SeatPrice { get; set; }
    }
}
