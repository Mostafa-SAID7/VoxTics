using System;

namespace VoxTics.Areas.Admin.ViewModels.Movie
{
    public class MovieImageViewModel
    {
        public int Id { get; set; }

        // Changed to System.Uri
        public Uri ImageUrl { get; set; } = new Uri("about:blank");

        public string? AltText { get; set; }
    }
}
