using System;
using System.Collections.Generic;

namespace VoxTics.Models.ViewModels.Home
{
    public class HomeVM
    {
        public IEnumerable<Movie> NowShowing { get; set; }
        public IEnumerable<Movie> ComingSoon { get; set; }
        public IEnumerable<Cinema> Cinemas { get; set; }
        public IEnumerable<Movie> Featured { get; set; }
    }
}
