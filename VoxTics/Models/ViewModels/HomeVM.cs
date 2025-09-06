using System;
using System.Collections.Generic;

namespace VoxTics.Models.ViewModels
{
    public class HomeVM
    {
        // Featured & categorized movies
        public List<MovieVM> FeaturedMovies { get; set; } = new List<MovieVM>();
        public List<MovieVM> NowPlayingMovies { get; set; } = new List<MovieVM>();
        public List<MovieVM> NowShowingMovies
        {
            get => NowPlayingMovies;
            set => NowPlayingMovies = value;
        }
        public List<MovieVM> UpcomingMovies { get; set; } = new List<MovieVM>();

        // Cinemas and categories
        public List<CinemaVM> FeaturedCinemas { get; set; } = new List<CinemaVM>();
        public List<CategoryVM> PopularCategories { get; set; } = new List<CategoryVM>();

        // Showtimes
        public List<ShowtimeVM> TodayShowtimes { get; set; } = new List<ShowtimeVM>();

        // Search
        public SearchResultVM SearchForm { get; set; } = new();

        // Statistics for dashboard
        public int TotalMovies { get; set; }
        public int TotalUpcoming { get; set; }
        public int TotalNowShowing { get; set; }
        public int TotalCinemas { get; set; }
    }
}
