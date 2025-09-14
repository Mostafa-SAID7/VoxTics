using VoxTics.Helpers.Filters.Sorting;

namespace VoxTics.Areas.Admin.ViewModels.Filter
{
    public class MoviesFilterVM
    {
        public int? Id { get; set; }
        public string? Search { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string DatePropertyName { get; set; } = "CreatedAt";
        public MovieStatus? Status { get; set; }
        public decimal? MinRating { get; set; }
        public decimal? MaxRating { get; set; }
        public DateTime? ReleaseFrom { get; set; }
        public DateTime? ReleaseTo { get; set; }
        public bool? IsFeatured { get; set; }
        public int? CategoryId { get; set; }

        // Sorting
        public MovieSortBy SortBy { get; set; } = MovieSortBy.Title;
        public SortOrder SortOrder { get; set; } = SortOrder.Asc;

        // Pagination
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
