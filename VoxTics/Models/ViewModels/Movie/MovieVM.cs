using System;
using System.Collections.Generic;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels.Actor;

namespace VoxTics.Models.ViewModels.Movie
{
    public class MovieVM
    {
        // ------------------------------
        // Core movie properties
        // ------------------------------
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; } // unified name
        public int Duration { get; set; } // unified name
        public DateTime ReleaseDate { get; set; }


        public string? Rating { get; set; }




        // Main poster image
        public string? PosterImage { get; set; } // unified with ImageUrl

        // Status
        public MovieStatus Status { get; set; }



        // Categories and actors
        public List<string> Categories { get; set; } = new List<string>();
        public string CategoryNames { get; set; } = string.Empty;






        // Short description for cards

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
