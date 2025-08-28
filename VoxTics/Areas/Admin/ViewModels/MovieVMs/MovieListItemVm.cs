namespace VoxTics.Areas.Admin.ViewModels.MovieVMs
{
    public class MovieListItemVm
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string CinemaName { get; set; } = "";
        public string CategoryName { get; set; } = "";
        public string MovieStatus { get; set; } = "";
        public string? ThumbnailUrl { get; set; }
        public int ImagesCount { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }
    }
}
