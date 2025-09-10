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

        public List<int> PageNumbers { get; set; } = new();

        public PagedResultVM(PaginatedList<T> paginatedList)
        {
            Items = paginatedList.Items;
            PageIndex = paginatedList.PageIndex;
            PageSize = paginatedList.PageSize;
            TotalCount = paginatedList.TotalCount;
            TotalPages = paginatedList.TotalPages;
            PageNumbers = paginatedList.GetPageNumbers();
        }

        public PagedResultVM() { }
    }
}
