namespace VoxTics.Models.ViewModels.Cart
{
    public class SeatVM
    {
        public int SeatId { get; set; }
        public string Label { get; set; } = "";
        public bool IsAvailable { get; set; }
    }
}
