using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using VoxTics.Areas.Admin.ViewModels.Booking;
using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels.Admin
{
    public class AdminDashboardViewModel
    {
        // -------------------------
        // General Statistics
        // -------------------------
        public int TotalMovies { get; set; }
        public int TotalUsers { get; set; }
        public int TotalBookings { get; set; }
        public int TotalCinemas { get; set; }
        public int TotalCategories { get; set; }
        public int TotalShowtimes { get; set; }
        public int TotalHalls { get; set; }
        public decimal TotalRevenue { get; set; }

        // -------------------------
        // Revenue Tracking
        // -------------------------
        public decimal MonthlyRevenue { get; set; }
        public decimal DailyRevenue { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public string FormattedTotalRevenue => TotalRevenue.ToString("C", CultureInfo.InvariantCulture);

        [DisplayFormat(DataFormatString = "{0:C}")]
        public string FormattedMonthlyRevenue => MonthlyRevenue.ToString("C", CultureInfo.InvariantCulture);

        [DisplayFormat(DataFormatString = "{0:C}")]
        public string FormattedDailyRevenue => DailyRevenue.ToString("C", CultureInfo.InvariantCulture);

        // -------------------------
        // Movie Statistics
        // -------------------------
        public int UpcomingMovies { get; set; }
        public int NowShowingMovies { get; set; }
        public int EndedMovies { get; set; }

        public IReadOnlyDictionary<MovieStatus, string> MovieStatusBadges => new Dictionary<MovieStatus, string>
        {
            { MovieStatus.Upcoming, "badge bg-info" },
            { MovieStatus.NowShowing, "badge bg-success" },
            { MovieStatus.Ended, "badge bg-secondary" }
        };

        // -------------------------
        // Booking Statistics
        // -------------------------
        public int PendingBookings { get; set; }
        public int ConfirmedBookings { get; set; }
        public int CancelledBookings { get; set; }

        public IReadOnlyDictionary<BookingStatus, string> BookingStatusBadges => new Dictionary<BookingStatus, string>
        {
            { BookingStatus.Pending, "badge bg-warning" },
            { BookingStatus.Confirmed, "badge bg-success" },
            { BookingStatus.Cancelled, "badge bg-danger" }
        };

        // -------------------------
        // Recent Activities (Read-only)
        // -------------------------
        public IReadOnlyList<MovieListItemViewModel> RecentMovies { get; } = new List<MovieListItemViewModel>();
        public IReadOnlyList<BookingViewModel> RecentBookings { get; } = new List<BookingViewModel>();
        public IReadOnlyList<ApplicationInfo> RecentUsers { get; } = new List<ApplicationInfo>();

        // -------------------------
        // Popular Items (Read-only)
        // -------------------------
        public IReadOnlyList<MovieListItemViewModel> PopularMovies { get; } = new List<MovieListItemViewModel>();
        public IReadOnlyList<CinemaViewModel> PopularCinemas { get; } = new List<CinemaViewModel>();

        // -------------------------
        // Chart Data for Admin Dashboard
        // -------------------------
        public IReadOnlyDictionary<string, int> MonthlyBookings { get; } = new Dictionary<string, int>();
        public IReadOnlyDictionary<string, decimal> MonthlyRevenueSeries { get; } = new Dictionary<string, decimal>();
        public IReadOnlyDictionary<MovieStatus, int> MoviesByStatus { get; } = new Dictionary<MovieStatus, int>();
        public IReadOnlyDictionary<BookingStatus, int> BookingsByStatus { get; } = new Dictionary<BookingStatus, int>();

        // -------------------------
        // Computed / Derived Properties
        // -------------------------
        public int TotalSeats => PopularCinemas.Sum(c => c.TotalSeats);

        public decimal AverageBookingValue => TotalBookings > 0 ? TotalRevenue / TotalBookings : 0;

        public int TotalActiveMovies => UpcomingMovies + NowShowingMovies;

        public string TotalRevenueFormatted => TotalRevenue.ToString("C", CultureInfo.InvariantCulture);
        public string AverageBookingValueFormatted => AverageBookingValue.ToString("C", CultureInfo.InvariantCulture);
    }
}
