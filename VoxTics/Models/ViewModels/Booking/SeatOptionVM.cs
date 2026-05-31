namespace VoxTics.Models.ViewModels.Booking
{
    public class SeatOptionVM
    {
        public int SeatId { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public string Row { get; set; } = string.Empty;
        public int NumberInRow { get; set; }
        public string SeatType { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
    }
}
