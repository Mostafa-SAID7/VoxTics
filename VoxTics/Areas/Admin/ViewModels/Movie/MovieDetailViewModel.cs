using System;
using System.Collections.Generic;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels.Movie
{
    public class MovieDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Rating { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsFeatured { get; set; }
        public decimal Price { get; set; }
        public string Director { get; set; } = string.Empty;
        public string? Language { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Changed to System.Uri
        public Uri? TrailerUrl { get; set; }

        public int ShowtimesCount { get; set; }
        public int BookingsCount { get; set; }
        public MovieStatus Status { get; set; }

        // Read-only collections
        public List<MovieImageViewModel> Images { get; } = new();
        public List<ActorViewModel> Actors { get; } = new();
        public List<CategoryViewModel> Categories { get; } = new();
    }
}
