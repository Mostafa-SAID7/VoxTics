using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Areas.Admin.ViewModels.Booking;

namespace VoxTics.Areas.Admin.ViewModels.Admin
{
    public class AdminDashboardViewModel
    {
        private readonly IDashboardRepository _dashboardRepository;

        public AdminDashboardViewModel(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository ?? throw new ArgumentNullException(nameof(dashboardRepository));
        }

        #region Dashboard Data

        public int TotalMovies { get; private set; }
        public int TotalUsers { get; private set; }
        public int TotalBookings { get; private set; }
        public int TotalCinemas { get; private set; }
        public int TotalCategories { get; private set; }
        public int TotalShowtimes { get; private set; }
        public int TotalHalls { get; private set; }
        public decimal TotalRevenue { get; private set; }

        public decimal MonthlyRevenue { get; private set; }
        public decimal DailyRevenue { get; private set; }

        public int UpcomingMovies { get; private set; }
        public int NowShowingMovies { get; private set; }
        public int EndedMovies { get; private set; }
        public Dictionary<MovieStatus, int> MoviesByStatus { get; private set; } = new();

        public int PendingBookings { get; private set; }
        public int ConfirmedBookings { get; private set; }
        public int CancelledBookings { get; private set; }
        public Dictionary<BookingStatus, int> BookingsByStatus { get; private set; } = new();

        public IReadOnlyList<MovieListItemViewModel> RecentMovies { get; private set; } = new List<MovieListItemViewModel>();
        public IReadOnlyList<BookingViewModel> RecentBookings { get; private set; } = new List<BookingViewModel>();
        public IReadOnlyList<ApplicationUser> RecentUsers { get; private set; } = new List<ApplicationUser>();

        public IReadOnlyList<MovieListItemViewModel> PopularMovies { get; private set; } = new List<MovieListItemViewModel>();
        public IReadOnlyList<CinemaViewModel> PopularCinemas { get; private set; } = new List<CinemaViewModel>();

        public Dictionary<string, int> MonthlyBookings { get; private set; } = new();
        public Dictionary<string, decimal> MonthlyRevenueSeries { get; private set; } = new();

        #endregion

        #region Computed Properties

        public string FormattedTotalRevenue => TotalRevenue.ToString("C", CultureInfo.InvariantCulture);
        public string FormattedMonthlyRevenue => MonthlyRevenue.ToString("C", CultureInfo.InvariantCulture);
        public string FormattedDailyRevenue => DailyRevenue.ToString("C", CultureInfo.InvariantCulture);

        public int TotalActiveMovies => UpcomingMovies + NowShowingMovies;
        public decimal AverageBookingValue => TotalBookings > 0 ? TotalRevenue / TotalBookings : 0;
        public string AverageBookingValueFormatted => AverageBookingValue.ToString("C", CultureInfo.InvariantCulture);

        public int TotalSeats => PopularCinemas.Sum(c => c.TotalSeats);

        #endregion

        #region Initialization

        public async Task LoadAsync(int popularCount = 5)
        {
            // General stats
            TotalMovies = await _dashboardRepository.GetTotalMoviesAsync();
            TotalUsers = await _dashboardRepository.GetTotalUsersAsync();
            TotalBookings = await _dashboardRepository.GetTotalBookingsAsync();
            TotalCinemas = await _dashboardRepository.GetTotalCinemasAsync();
            TotalCategories = await _dashboardRepository.GetTotalCategoriesAsync();
            TotalShowtimes = await _dashboardRepository.GetTotalShowtimesAsync();
            TotalHalls = await _dashboardRepository.GetTotalHallsAsync();
            TotalRevenue = await _dashboardRepository.GetTotalRevenueAsync();

            // Revenue
            var today = DateTime.UtcNow;
            MonthlyRevenue = await _dashboardRepository.GetMonthlyRevenueAsync(today.Year, today.Month);
            DailyRevenue = await _dashboardRepository.GetDailyRevenueAsync(today);

            // Movie stats
            UpcomingMovies = await _dashboardRepository.GetUpcomingMoviesCountAsync();
            NowShowingMovies = await _dashboardRepository.GetNowShowingMoviesCountAsync();
            EndedMovies = await _dashboardRepository.GetEndedMoviesCountAsync();
            MoviesByStatus = await _dashboardRepository.GetMoviesByStatusAsync();

            // Booking stats
            PendingBookings = await _dashboardRepository.GetPendingBookingsCountAsync();
            ConfirmedBookings = await _dashboardRepository.GetConfirmedBookingsCountAsync();
            CancelledBookings = await _dashboardRepository.GetCancelledBookingsCountAsync().ConfigureAwait(false);
            BookingsByStatus = await _dashboardRepository.GetBookingsByStatusAsync();

            // Recent / popular items
      

            PopularCinemas = (await _dashboardRepository.GetPopularCinemasAsync(popularCount))
                .Select(c => new CinemaViewModel(c))
                .ToList();

            // Chart data
            MonthlyBookings = await _dashboardRepository.GetMonthlyBookingsSeriesAsync(today.Year);
            MonthlyRevenueSeries = await _dashboardRepository.GetMonthlyRevenueSeriesAsync(today.Year);
        }

        #endregion
    }
}
