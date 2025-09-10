namespace VoxTics.Areas.Admin.ViewModels.Movie
{
    public class MovieDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Rating { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsFeatured { get; set; }
        public decimal Price { get; set; }
        public string Director { get; set; } = string.Empty;
        public string? Language { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? TrailerUrl { get; set; }
        public int ShowtimesCount { get; set; }
        public int BookingsCount { get; set; }
        public MovieStatus Status { get; set; }
        public List<MovieImageViewModel> Images { get; set; } = new();
        public List<ActorViewModel> Actors { get; set; } = new();
        public List<CategoryViewModel> Categories { get; set; } = new();
    }
}
