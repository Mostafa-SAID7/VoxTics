namespace VoxTics.Models.ViewModels
{
    public class MovieDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? TrailerUrl { get; set; }
        public decimal Price { get; set; }
        public string? ImgUrl { get; set; }
        public List<string> Images { get; set; } = new();

        // Cinema & Category
        public string CinemaName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;

        // Actors
        public List<string> Actors { get; set; } = new();
    }
}
