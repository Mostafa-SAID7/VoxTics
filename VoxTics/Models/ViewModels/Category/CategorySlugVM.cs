using VoxTics.Models.ViewModels.Movie;

namespace VoxTics.Models.ViewModels.Category
{
    public class CategorySlugVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Description { get; set; }

        // All movies in this category (can paginate)

        // Total number of movies
        public int TotalMovies { get; set; }
    }
}
