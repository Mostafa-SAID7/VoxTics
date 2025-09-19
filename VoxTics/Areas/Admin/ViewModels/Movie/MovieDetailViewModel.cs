using System;
using System.Collections.Generic;
using VoxTics.Areas.Admin.ViewModels.Actor;
using VoxTics.Areas.Admin.ViewModels.Category;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels.Movie
{
    public class MovieDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public decimal? Rating { get; set; }
        public string Language { get; set; } = "EN";
        public string? Country { get; set; }
        public string? MainImageUrl { get; set; }
        public string? TrailerUrl { get; set; }
        public bool IsFeatured { get; set; }
        public MovieStatus Status { get; set; }
        public string Slug { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
    }
}
