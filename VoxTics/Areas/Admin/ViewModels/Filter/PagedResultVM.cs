using System;
using System.Collections.Generic;

namespace VoxTics.Areas.Admin.ViewModels.Filter
{
    public class PagedResultVM<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        // PageNumbers read-only now
        public List<int> PageNumbers { get; }

        public PagedResultVM(PaginatedList<T> paginatedList)
        {
            if (paginatedList == null)
                throw new ArgumentNullException(nameof(paginatedList));

            Items = paginatedList.Items;
            PageIndex = paginatedList.PageIndex;
            PageSize = paginatedList.PageSize;
            TotalCount = paginatedList.TotalCount;
            TotalPages = paginatedList.TotalPages;
            PageNumbers = paginatedList.GetPageNumbers();
        }

        public PagedResultVM()
        {
            PageNumbers = new List<int>();
        }
    }
}
