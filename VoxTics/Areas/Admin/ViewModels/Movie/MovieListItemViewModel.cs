using System;

namespace VoxTics.Areas.Admin.ViewModels.Movie
{
    public class MovieListItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public MovieStatus Status { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public bool IsFeatured { get; set; }
        public string? MainImageUrl { get; set; }
        public int ShowtimeCount { get; set; }
    }
}
