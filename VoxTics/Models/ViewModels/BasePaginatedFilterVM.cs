using System;

namespace VoxTics.Models.ViewModels
{
    public class BasePaginatedFilterVM
    {
        // Page number (1-based)
        private int _pageNumber = 1;
        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value <= 0) ? 1 : value;
        }

        // Page size (items per page)
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value <= 0) ? 10 : (value > 100 ? 100 : value);
        }

        // General search term (optional)
        public string? SearchTerm { get; set; }

        // Sorting direction (true = ASC, false = DESC)
        public bool SortAscending { get; set; } = true;

        // Optional: filtering by date range
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? SortBy { get; set; }
        public SortOrder SortOrder { get; set; } = SortOrder.Asc;

    }
}
