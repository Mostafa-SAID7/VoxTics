namespace VoxTics.Models.ViewModels.Cart
{
    public class CheckoutItemVM
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;

        public int ShowtimeId { get; set; }
        public DateTime Showtime { get; set; }

        public List<string> SeatLabels { get; set; } = new(); // e.g., ["A1","A2"]
        public decimal TicketPrice { get; set; }
        public int Quantity => SeatLabels.Count;
        public decimal TotalPrice => TicketPrice * Quantity;
    }
}
