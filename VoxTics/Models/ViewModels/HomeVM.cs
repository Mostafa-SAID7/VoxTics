using System;
using System.Collections.Generic;

namespace VoxTics.Models.ViewModels
{
    public class HomeVM
    {
        public List<MovieVM> FeaturedMovies { get; set; } = new();
        public List<MovieVM> UpcomingMovies { get; set; } = new();
        public List<CategoryVM> PopularCategories { get; set; } = new();
        public List<ShowtimeVM> TodayShowtimes { get; set; } = new();

        public int TotalMovies { get; set; }
        public int TotalUpcoming { get; set; }
        public int TotalNowShowing { get; set; }
        // Featured & categorized movies
        public List<MovieVM> NowPlayingMovies { get; set; } = new List<MovieVM>();
        public List<MovieVM> NowShowingMovies
        {
            get => NowPlayingMovies;
            set => NowPlayingMovies = value;
        }

        // Cinemas and categories
        public List<CinemaVM> FeaturedCinemas { get; set; } = new List<CinemaVM>();

        // Showtimes

       

        // Statistics for dashboard

        public int TotalCinemas { get; set; }
    }
}
