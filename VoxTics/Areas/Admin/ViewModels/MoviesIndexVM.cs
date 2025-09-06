// Areas/Admin/ViewModels/MoviesIndexVM.cs
using System.Collections.Generic;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels
{
    public class MoviesIndexVM
    {
        // list of movie DTOs for the UI
        public List<MovieViewModel> Movies { get; set; } = new List<MovieViewModel>();

        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        // filters/pagination state
        public string? SearchTerm { get; set; }
        public int SelectedCategoryId { get; set; }
        public MovieStatus? SelectedStatus { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; } = 0;
    }
}
