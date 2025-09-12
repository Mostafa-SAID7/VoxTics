namespace VoxTics.Areas.Admin.ViewModels.Admin
{
    public class MovieSummary
    {
        public int MovieId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public MovieStatus Status { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TotalBookings { get; set; }
    }
}
