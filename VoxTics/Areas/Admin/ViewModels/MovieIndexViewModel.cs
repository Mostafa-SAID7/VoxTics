using System.Collections.Generic;

namespace VoxTics.Areas.Admin.ViewModels
{
    public class MovieIndexViewModel
    {
        public List<MovieListItemViewModel> Movies { get; set; } = new();
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public string? Search { get; set; }
        public string? Sort { get; set; }
    }
}
