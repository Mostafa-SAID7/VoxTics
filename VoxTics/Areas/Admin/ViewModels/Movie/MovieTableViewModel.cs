namespace VoxTics.Areas.Admin.ViewModels.Movie
{
    public class MovieTableViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? PosterImage { get; set; }

        public DateTime ReleaseDate { get; set; }

        // Display-friendly formatted date
        public string ReleaseDateFormatted => ReleaseDate.ToString("yyyy-MM-dd");

        public decimal Rating { get; set; }

        public int Duration { get; set; } // in minutes

        public decimal Price { get; set; }

        // Formatted price for display
        public string FormattedPrice => Price.ToString("0.00");

        public MovieStatus Status { get; set; }

        // Bootstrap badge for status
        public string StatusBadge => Status switch
        {
            MovieStatus.Upcoming => "badge bg-info",
            MovieStatus.NowShowing => "badge bg-success",
            MovieStatus.Ended => "badge bg-secondary",
            MovieStatus.Cancelled => "badge bg-dark",
            _ => "badge bg-secondary"
        };

        public bool IsFeatured { get; set; }

        public string FeaturedBadge => IsFeatured ? "badge bg-warning text-dark" : string.Empty;

        // Comma-separated categories for table
        public string Categories { get; set; } = string.Empty;

        // Optional: Count of associated showtimes
        public int ShowtimeCount { get; set; }

    }
}
