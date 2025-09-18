using System;
using System.Collections.Generic;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels.Actor;

namespace VoxTics.Models.ViewModels.Movie
{
    public class MovieVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal? Rating { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
        public bool IsFeatured { get; set; }

        // Status
        public MovieStatus Status { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

    }
}
