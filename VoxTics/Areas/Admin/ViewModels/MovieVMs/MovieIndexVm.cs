using Microsoft.AspNetCore.Mvc.Rendering;

namespace VoxTics.Areas.Admin.ViewModels.MovieVMs
{
    public class MovieIndexVM
    {
        // the list of movies to display
        public IEnumerable<MovieListItemVM> Movies { get; set; } = Enumerable.Empty<MovieListItemVM>();

        // nested filter model
        public MovieFilterVM Filter { get; set; } = new MovieFilterVM();

        // convenience/pagination helpers (avoid referencing Filter.Page everywhere)
        public int CurrentPage => Math.Max(Filter?.Page ?? 1, 1);
        public int PageSize => Filter?.PageSize ?? 10;

        public int TotalItems { get; set; } = 0;
        public int TotalPages { get; set; } = 0;

        // selects for filters
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Cinemas { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
