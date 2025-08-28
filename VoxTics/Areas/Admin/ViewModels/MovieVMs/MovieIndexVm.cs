using Microsoft.AspNetCore.Mvc.Rendering;

namespace VoxTics.Areas.Admin.ViewModels.MovieVMs
{
    public class MovieIndexVm
    {
        public PagedResult<MovieListItemVm> PagedMovies { get; set; } = new PagedResult<MovieListItemVm>();

        // Filters & sorts (preserve in query)
        public string? Search { get; set; }
        public int? CategoryId { get; set; }
        public string? Sort { get; set; }            // e.g. "title_asc", "price_desc", "date_desc"
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        // Dropdowns
        public IEnumerable<SelectListItem>? Categories { get; set; }
        public IEnumerable<SelectListItem>? PageSizeOptions { get; set; }
    }
}
