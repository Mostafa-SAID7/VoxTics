using System;
using System.Collections.Generic;
using VoxTics.Models.ViewModels.Cinema;
using VoxTics.Models.ViewModels.Movie;

namespace VoxTics.Models.ViewModels.Home
{
    public class HomeVM
    {
        public IEnumerable<MovieVM> NowShowing { get; set; } = Enumerable.Empty<MovieVM>();
        public IEnumerable<MovieVM> ComingSoon { get; set; } = Enumerable.Empty<MovieVM>();
        public IEnumerable<CinemaVM> Cinemas { get; set; } = Enumerable.Empty<CinemaVM>();
        public IEnumerable<MovieVM> Featured { get; set; } = Enumerable.Empty<MovieVM>();
    }
}
