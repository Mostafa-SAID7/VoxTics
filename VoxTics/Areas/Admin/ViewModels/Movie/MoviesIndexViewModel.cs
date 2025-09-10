using Microsoft.AspNetCore.Mvc.Rendering;

namespace VoxTics.Areas.Admin.ViewModels.Movie
{
    public class MoviesIndexViewModel
    {
        public PaginatedList<MovieViewModel> Movies { get; set; } 
        public List<CategoryViewModel> Categories { get; set; } = new();

        // Filters
        public string? SearchTerm { get; set; }
        public int SelectedCategoryId { get; set; }
        public MovieStatus? SelectedStatus { get; set; }

        // Sorting
        public string SortBy { get; set; } = "createdat";
        public bool SortDescending { get; set; }

        // Dropdowns
        public IEnumerable<SelectListItem> CategoryOptions => Categories
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = c.Id == SelectedCategoryId
            });
        public IEnumerable<SelectListItem> StatusOptions => Enum.GetValues(typeof(MovieStatus))
            .Cast<MovieStatus>()
            .Select(s => new SelectListItem
            {
                Value = s.ToString(),
                Text = s.ToString(),
                Selected = SelectedStatus.HasValue && SelectedStatus.Value == s
            });

    }

}
