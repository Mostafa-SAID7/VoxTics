using Microsoft.Data.SqlClient;

namespace VoxTics.Models.ViewModels
{
    public class MovieFilterVM
    {
        // Search and filter criteria
        public string? SearchTerm { get; set; }
        public List<int> CategoryIds { get; set; } = new();
        public MovieStatus? Status { get; set; }
        public string? Language { get; set; }
        public int? ReleaseYear { get; set; }
        public double? MinRating { get; set; }

        // Sorting
        public MovieSortBy SortBy { get; set; } = MovieSortBy.Title;
        public VoxTics.Models.Enums.SortOrder SortOrder { get; set; } = VoxTics.Models.Enums.SortOrder.Asc;

        // Optional: Available options for dropdowns
        public List<CategoryVM> AvailableCategories { get; set; } = new();
        public List<string> AvailableLanguages { get; set; } = new();
        public List<int> AvailableYears { get; set; } = new();
    }
}
