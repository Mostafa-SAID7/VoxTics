using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels.Actor;
using VoxTics.Models.ViewModels.Category;
using VoxTics.Models.ViewModels.Showtime;

namespace VoxTics.Models.ViewModels.Movie
{
    public class MovieDetailsVM
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string? Country { get; set; }
        public string Language { get; set; } = "EN";
        public string? AgeRating { get; set; }

        public string? ImageUrl { get; set; }
        public string? TrailerImageUrl { get; set; }
        public string? TrailerUrl { get; set; }

        public bool IsFeatured { get; set; }
        public MovieStatus Status { get; set; }

        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; } // minutes
        public decimal Price { get; set; }
        public decimal Rating { get; set; }

        public IReadOnlyList<ActorVM> Cast { get; set; } = new List<ActorVM>();
        public IReadOnlyList<CategoryVM> Categories { get; set; } = new List<CategoryVM>();
        public IReadOnlyList<string> GalleryImages { get; set; } = new List<string>();
        public IReadOnlyList<ShowtimeVM> Showtimes { get; set; } = new List<ShowtimeVM>();

        public bool IsAvailableForBooking =>
            Status == MovieStatus.NowShowing && ReleaseDate <= DateTime.Today;

        public int DaysSinceRelease =>
            (Status == MovieStatus.NowShowing && ReleaseDate <= DateTime.Today)
                ? (DateTime.Today - ReleaseDate).Days
                : 0;

        public string DisplayImage =>
            !string.IsNullOrEmpty(ImageUrl) ? ImageUrl : "/images/default-movie.jpg";
    }
}
