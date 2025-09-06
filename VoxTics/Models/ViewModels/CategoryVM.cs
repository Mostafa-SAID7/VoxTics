using System.Collections.Generic;

namespace VoxTics.Models.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Image { get; set; }  // optional
        public int MovieCount { get; set; }
        public List<MovieVM> Movies { get; set; } = new List<MovieVM>();

        public string ShortDescription => string.IsNullOrEmpty(Description)
            ? ""
            : Description.Length > 100 ? Description[..100] + "..." : Description;
    }
}
