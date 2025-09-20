namespace VoxTics.Models.ViewModels
{
    public class MovieBookingVM
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public string? CustomerName { get; set; }
        public int Seats { get; set; }
    }

}
