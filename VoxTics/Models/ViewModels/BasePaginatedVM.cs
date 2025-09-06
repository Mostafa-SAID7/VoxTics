namespace VoxTics.Models.ViewModels
{
    public class BasePaginatedVM<TItem>
    {
        // البيانات
        public List<TItem> Items { get; set; } = new List<TItem>();

        // Pagination metadata
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; } = 0;
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        // Helpers for UI
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public int StartItem => TotalCount == 0 ? 0 : ((CurrentPage - 1) * PageSize) + 1;
        public int EndItem => Math.Min(CurrentPage * PageSize, TotalCount);

        // Optional filters
        public string? SearchQuery { get; set; }
        public int? CategoryId { get; set; }
        public string? Language { get; set; }
        public MovieStatus? Status { get; set; }
    }
}
