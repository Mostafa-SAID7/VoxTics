using System;

namespace VoxTics.Models.ViewModels
{
    public class BasePaginatedFilterVM
    {
        private int _pageNumber = 1;
        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value <= 0) ? 1 : value;
        }

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value <= 0) ? 10 : (value > 100 ? 100 : value);
        }

        public string? SearchTerm { get; set; }
        public string? SortBy { get; set; }
        public SortOrder SortOrder { get; set; } = SortOrder.Asc;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

}
