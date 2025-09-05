using VoxTics.Models.Entities;

namespace VoxTics.Models.ViewModels
{
    public class BookingVM
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public DateTime Showtime { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ShowtimeId { get; set; }
        public int Quantity { get; set; }
        public int SeatsBooked { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
