namespace VoxTics.Areas.Admin.ViewModels.Category
{
    public class CategoryTableViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // Display-friendly property for UI
        public string StatusBadge => IsActive ? "badge bg-success" : "badge bg-secondary";

        // Optional: count of associated movies
        public int MovieCount { get; set; }
    }
}
