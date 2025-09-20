namespace VoxTics.Models.ViewModels.Cart
{
    public class CartItemVM
    {
        public int CartItemId { get; set; }
        public string MovieTitle { get; set; } = "";
        public string Showtime { get; set; } = "";
        public List<string> SeatLabels { get; set; } = new();
        public decimal Price { get; set; }
    }
}
