namespace VoxTics.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        // Navigation property for the many-to-many relationship with Movie
        public ICollection<MovieCategory> MovieCategories { get; set; } = new List<MovieCategory>();
    }
}
