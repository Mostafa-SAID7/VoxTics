namespace VoxTics.Models.ViewModels.Movie
{
    public class MoviePreviewVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? PosterImage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Rating { get; set; }
        public decimal Price { get; set; }

        public string ReleaseDateFormatted => ReleaseDate.ToString("yyyy-MM-dd");
    }
}
