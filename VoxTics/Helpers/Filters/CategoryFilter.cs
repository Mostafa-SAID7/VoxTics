using VoxTics.Helpers.Filters.Sorting;

namespace VoxTics.Helpers.Filters
{
    public class CategoryFilter : FilterBase<CategorySortBy>
    {
        public bool? IsActive { get; set; }
        public string? NameContains { get; set; }
    }
}
