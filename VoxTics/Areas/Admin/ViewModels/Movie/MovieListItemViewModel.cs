using System;

namespace VoxTics.Areas.Admin.ViewModels.Movie
{
    public class MovieListItemViewModel
    {
        private Models.Entities.Movie m;

        public MovieListItemViewModel(Models.Entities.Movie m)
        {
            this.m = m;
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? PosterImage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Rating { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public string? TrailerUrl { get; set; }
        public MovieStatus Status { get; set; } 
        public bool IsFeatured { get; set; }
        public string Categories { get; set; } = string.Empty;
    }
}
