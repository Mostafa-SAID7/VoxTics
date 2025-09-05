namespace VoxTics.Models.ViewModels
{
    public class ShowtimeVM
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public decimal Price { get; set; }
    }
}
