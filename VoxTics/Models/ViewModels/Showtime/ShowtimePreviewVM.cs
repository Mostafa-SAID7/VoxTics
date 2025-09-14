namespace VoxTics.Models.ViewModels.Showtime
{
    public class ShowtimePreviewVM
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public string? MoviePoster { get; set; }

        public int HallId { get; set; }
        public string HallName { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public decimal Price { get; set; }
        public bool Is3D { get; set; }
        public string Language { get; set; } = "EN";
        public string ScreenType { get; set; } = "Standard";

        public string StartTimeFormatted => StartTime.ToString("yyyy-MM-dd HH:mm");
        public string EndTimeFormatted => EndTime.ToString("HH:mm");
    }
}
