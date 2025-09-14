using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace VoxTics.Areas.Admin.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        // Display-friendly property for UI
        public string StatusBadge => IsActive ? "badge bg-success" : "badge bg-secondary";

        // List of associated movies
        public ICollection<string> Movies { get; set; } = new List<string>();
    }
}
