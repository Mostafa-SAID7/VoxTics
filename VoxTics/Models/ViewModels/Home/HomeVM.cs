using System;
using System.Collections.Generic;
using VoxTics.Models.ViewModels.Cinema;
using VoxTics.Models.ViewModels.Movie;

namespace VoxTics.Models.ViewModels.Home
{
    public class HomeVM
    {
        public IEnumerable<MovieVM> NowShowing { get; set; }
        public IEnumerable<MovieVM> ComingSoon { get; set; }
        public IEnumerable<CinemaVM> Cinemas { get; set; }
        public IEnumerable<MovieVM> Featured { get; set; }
    }
}
