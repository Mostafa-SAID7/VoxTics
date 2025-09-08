using System;

namespace VoxTics.Areas.Admin.ViewModels
{
    public class MovieListItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Rating { get; set; }
        public bool IsFeatured { get; set; }
    }
}
