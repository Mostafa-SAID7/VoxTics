using System;
using System.Collections.Generic;

namespace VoxTics.Models.ViewModels
{
    public class HomeVM
    {
        public List<MovieVM> FeaturedMovies { get; set; } = new();
        public List<MovieVM> NowShowingMovies { get; set; } = new();
        public List<MovieVM> UpcomingMovies { get; set; } = new();
        public List<CategoryVM> PopularCategories { get; set; } = new();
        public List<ShowtimeVM> TodayShowtimes { get; set; } = new();

        public int TotalMovies { get; set; }
        public int TotalUpcoming { get; set; }
        public int TotalNowShowing { get; set; }
    }
}
