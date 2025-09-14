namespace VoxTics.Models.ViewModels.Movie
{
    public class MovieImageVM
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string? AltText { get; set; }
        public bool IsPrimary { get; set; }
        public int SortOrder { get; set; }
        public int MovieId { get; set; }
        public string? Caption { get; set; }
        public bool IsMain { get; set; }
    }
}
