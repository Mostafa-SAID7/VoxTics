using VoxTics.Models.Entities;

namespace VoxTics.Models.ViewModels.Cart
{
    public class TicketSelectionVM
    {
        public int MovieId { get; set; }
        public int ShowtimeId { get; set; }
        public string MovieTitle { get; set; } = "";
        public List<SeatVM> AvailableSeats { get; set; } = new();
        public List<int> SelectedSeatIds { get; set; } = new();
    }
}
