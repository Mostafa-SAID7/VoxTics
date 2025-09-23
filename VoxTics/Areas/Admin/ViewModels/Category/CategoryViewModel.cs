using System.Collections.Generic;

namespace VoxTics.Areas.Admin.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public int MovieCount { get; set; } = 0;

        // Display-friendly property
        public string StatusBadge => IsActive ? "badge bg-success" : "badge bg-secondary";

        // List of associated movies (can populate manually)
        public ICollection<string> Movies { get; set; } = new List<string>();
    }
}
