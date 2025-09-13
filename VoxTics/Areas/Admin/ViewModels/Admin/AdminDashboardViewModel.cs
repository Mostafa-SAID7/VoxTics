using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        // Revenue
        public decimal TotalRevenue { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public decimal DailyRevenue { get; set; }

        // Movie statistics
        public int UpcomingMovies { get; set; }
        public int NowShowingMovies { get; set; }
        public int EndedMovies { get; set; }

        // Booking statistics
        public int PendingBookings { get; set; }
        public int ConfirmedBookings { get; set; }
        public int CancelledBookings { get; set; }

        // Recent activities (Read-only)
        public IReadOnlyList<MovieListItemViewModel> RecentMovies { get; } = new List<MovieListItemViewModel>();
        public IReadOnlyList<BookingViewModel> RecentBookings { get; } = new List<BookingViewModel>();
        public IReadOnlyList<ApplicationInfo> RecentUsers { get; } = new List<ApplicationInfo>();

        // Charts data (Read-only)
        public IReadOnlyDictionary<string, int> MonthlyBookings { get; } = new Dictionary<string, int>();
        public IReadOnlyDictionary<string, decimal> MonthlyRevenueSeries { get; } = new Dictionary<string, decimal>();
        public IReadOnlyDictionary<MovieStatus, int> MoviesByStatus { get; } = new Dictionary<MovieStatus, int>();
        public IReadOnlyDictionary<BookingStatus, int> BookingsByStatus { get; } = new Dictionary<BookingStatus, int>();

        // Popular items (Read-only)
        public IReadOnlyList<MovieListItemViewModel> PopularMovies { get; } = new List<MovieListItemViewModel>();
        public IReadOnlyList<CinemaViewModel> PopularCinemas { get; } = new List<CinemaViewModel>();

        // Display properties
        public string FormattedTotalRevenue => TotalRevenue.ToString("C", CultureInfo.InvariantCulture);
        public string FormattedMonthlyRevenue => MonthlyRevenue.ToString("C", CultureInfo.InvariantCulture);
        public string FormattedDailyRevenue => DailyRevenue.ToString("C", CultureInfo.InvariantCulture);
    }
}
