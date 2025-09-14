using System;
using System.Collections.Generic;
using System.Linq;
using VoxTics.Models.ViewModels.Actor;
using VoxTics.Models.ViewModels.Category;
using VoxTics.Models.ViewModels.Showtime;

namespace VoxTics.Models.ViewModels.Movie
{
    public class MovieDetailVM : MovieVM
    {
        // Detailed associations
        public List<ActorVM> DetailedActors { get; set; } = new List<ActorVM>();
        public List<CategoryVM> DetailedCategories { get; set; } = new List<CategoryVM>();
        public List<MovieImageVM> DetailedImages { get; set; } = new List<MovieImageVM>();

        // Showtimes
        public List<ShowtimeVM> Showtimes { get; set; } = new List<ShowtimeVM>();
        public bool HasShowtimes => Showtimes.Any();
        public bool CanBook => IsNowShowing && HasShowtimes;

        // Related movies
        public List<MovieVM> RelatedMovies { get; set; } = new List<MovieVM>();
        public List<MovieVM> SameCategoryMovies { get; set; } = new List<MovieVM>();
        public bool HasRelatedMovies => RelatedMovies.Any();

        // Additional images
        public List<MovieImageVM> MovieImages => DetailedImages;

        // Helpers for filtering showtimes
        public List<ShowtimeVM> UpcomingShowtimes => Showtimes
            .Where(s => s.ShowDateTime >= DateTime.Now && s.ShowDateTime <= DateTime.Now.AddDays(7))
            .OrderBy(s => s.ShowDateTime)
            .ToList();

        public List<ShowtimeVM> TodayShowtimes => Showtimes
            .Where(s => s.ShowDateTime.Date == DateTime.Today && s.ShowDateTime > DateTime.Now)
            .OrderBy(s => s.ShowDateTime)
            .ToList();

        public Dictionary<DateTime, List<ShowtimeVM>> ShowtimesByDate => Showtimes
            .Where(s => s.ShowDateTime >= DateTime.Now)
            .GroupBy(s => s.ShowDateTime.Date)
            .OrderBy(g => g.Key)
            .Take(7) // Next 7 days only
            .ToDictionary(g => g.Key, g => g.OrderBy(s => s.ShowDateTime).ToList());

        // Trailer helper
        public bool HasTrailer => !string.IsNullOrEmpty(TrailerUrl);
    }
}
