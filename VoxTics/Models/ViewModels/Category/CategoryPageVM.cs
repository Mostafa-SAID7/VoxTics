using VoxTics.Models.Enums.Sorting;
using VoxTics.Models.ViewModels.Movie;

namespace VoxTics.Models.ViewModels.Category
{
    public class CategoryPageVM
    {
        // -------------------------
        // Category info
        // -------------------------
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Description { get; set; }

        // -------------------------
        // Movies in this category
        // -------------------------
        public List<MoviePreviewVM> Movies { get; set; } = new List<MoviePreviewVM>();
        public int TotalMovies => Movies?.Count ?? 0;

        // -------------------------
        // Filtering / Sorting
        // -------------------------
        public string? SearchTerm { get; set; }
        public SortOrder SortOrder { get; set; } = SortOrder.Asc;
        public string? SortBy { get; set; } = "Title"; // default sort

        // Optional price range filter
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        // Optional release date filter
        public DateTime? StartReleaseDate { get; set; }
        public DateTime? EndReleaseDate { get; set; }

        // -------------------------
        // Pagination
        // -------------------------
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 12;
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public List<int> PageNumbers { get; set; } = new List<int>();
    }
}
