using System.Collections.Generic;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels.Admin
{
    public class AdminDashboardViewModel
    {
        // Statistics
        public int TotalMovies { get; set; }
        public int TotalUsers { get; set; }
        public int TotalBookings { get; set; }
        public int TotalCinemas { get; set; }
        public int TotalCategories { get; set; }
        public int TotalShowtimes { get; set; }

        // Revenue (scalar values)
        public decimal TotalRevenue { get; set; }
        public decimal MonthlyRevenue { get; set; }   // e.g. revenue for current month
        public decimal DailyRevenue { get; set; }     // e.g. revenue for today

        // Movie statistics
        public int UpcomingMovies { get; set; }
        public int NowShowingMovies { get; set; }
        public int EndedMovies { get; set; }

        // Booking statistics
        public int PendingBookings { get; set; }
        public int ConfirmedBookings { get; set; }
        public int CancelledBookings { get; set; }

        // Recent activities
        public List<MovieListItemViewModel> RecentMovies { get; set; } = new List<MovieListItemViewModel>();
        public List<BookingViewModel> RecentBookings { get; set; } = new List<BookingViewModel>();
        public List<UserViewModel> RecentUsers { get; set; } = new List<UserViewModel>();

        // Charts data
        public Dictionary<string, int> MonthlyBookings { get; set; } = new Dictionary<string, int>();

        // RENAMED: previously had name collision with decimal MonthlyRevenue
        public Dictionary<string, decimal> MonthlyRevenueSeries { get; set; } = new Dictionary<string, decimal>();

        public Dictionary<MovieStatus, int> MoviesByStatus { get; set; } = new Dictionary<MovieStatus, int>();
        public Dictionary<BookingStatus, int> BookingsByStatus { get; set; } = new Dictionary<BookingStatus, int>();

        // Popular items
        public List<MovieListItemViewModel> PopularMovies { get; set; } = new List<MovieListItemViewModel>();
        public List<CinemaViewModel> PopularCinemas { get; set; } = new List<CinemaViewModel>();

        // Display properties
        public string FormattedTotalRevenue => TotalRevenue.ToString("C");
        public string FormattedMonthlyRevenue => MonthlyRevenue.ToString("C");
        public string FormattedDailyRevenue => DailyRevenue.ToString("C");
    }
}
