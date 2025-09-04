using System.Collections.Generic;

namespace VoxTics.Models.ViewModels
{
    public class CategoryMoviesVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<MovieVM> Movies { get; set; } = new();
    }
    public class CategoryItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
