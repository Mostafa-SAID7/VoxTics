using System;
using System.Collections.Generic;
using VoxTics.Models.Enums;

namespace VoxTics.Models.ViewModels
{
    public class MovieVM
    {
        // ------------------------------
        // Core movie properties
        // ------------------------------
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal BasePrice { get; set; } // unified name
        public int DurationInMinutes { get; set; } // unified name
        public DateTime ReleaseDate { get; set; }
        public string? Director { get; set; }
        public string? Language { get; set; }
        public string? Country { get; set; }

        public string? Rating { get; set; }
        public string? AgeRating { get; set; }

        public string? TrailerUrl { get; set; }

        // Main poster image
        public string? PosterImage { get; set; } // unified with ImageUrl
        public bool HasImage => !string.IsNullOrEmpty(PosterImage);
        public string DefaultImage => "/images/default-movie-poster.jpg";
        public string DisplayImage => HasImage ? PosterImage! : DefaultImage;
        public string? ImageAlt => !string.IsNullOrEmpty(Title) ? $"{Title} poster" : "Movie poster";

        // Status
        public MovieStatus Status { get; set; }
        public bool IsUpcoming { get; set; }
        public bool IsNowShowing { get; set; }
        public bool IsEndedShowing { get; set; }
        public string StatusText { get; set; } = string.Empty;

        // Display formatting
        public string FormattedDuration { get; set; } = string.Empty;
        public string FormattedPrice { get; set; } = string.Empty;
        public string ReleaseDateFormatted { get; set; } = string.Empty;

        // Categories and actors
        public List<string> Categories { get; set; } = new List<string>();
        public string CategoryNames { get; set; } = string.Empty;
        public List<ActorVM> Actors { get; set; } = new List<ActorVM>();
        public List<string> ActorsNames => Actors.ConvertAll(a => a.FullName);

        // Additional images
        public List<string> AdditionalImages { get; set; } = new List<string>();
        public List<string> Images => AdditionalImages;

        // Rating and popularity
        public double AverageRating { get; set; }
        public int TotalRatings { get; set; }
        public int ViewCount { get; set; }
        public int BookingCount { get; set; }

        // Short description for cards
        private string? _shortDescription;
        public string ShortDescription
        {
            get
            {
                if (!string.IsNullOrEmpty(_shortDescription)) return _shortDescription;
                if (string.IsNullOrEmpty(Description)) return string.Empty;
                return Description.Length > 150 ? Description.Substring(0, 147) + "..." : Description;
            }
            set => _shortDescription = value;
        }
        // Badge helpers
        public string StatusBadgeClass => Status switch
        {
            MovieStatus.Upcoming => "badge bg-info",
            MovieStatus.NowShowing => "badge bg-success",
            MovieStatus.Ended => "badge bg-secondary",
            _ => "badge bg-secondary"
        };

        public string StatusIcon => Status switch
        {
            MovieStatus.Upcoming => "bi bi-clock-history",
            MovieStatus.NowShowing => "bi bi-play-circle",
            MovieStatus.Ended => "bi bi-stop-circle",
            _ => "bi bi-question-circle"
        };
    }
}
