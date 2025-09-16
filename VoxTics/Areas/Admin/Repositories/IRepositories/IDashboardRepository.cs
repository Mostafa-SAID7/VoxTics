using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.Repositories.IRepositories
{
    /// <summary>
    /// Repository for retrieving aggregated statistics and dashboard-specific data for the admin panel.
    /// Provides counts, revenue, recent/popular items, and chart data.
    /// </summary>
    public interface IDashboardRepository
    {
        #region General Statistics

        /// <summary>
        /// Gets the total number of movies.
        /// </summary>
        Task<int> GetTotalMoviesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the total number of registered users.
        /// </summary>
        Task<int> GetTotalUsersAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the total number of bookings.
        /// </summary>
        Task<int> GetTotalBookingsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the total number of cinemas.
        /// </summary>
        Task<int> GetTotalCinemasAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the total number of categories.
        /// </summary>
        Task<int> GetTotalCategoriesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the total number of showtimes.
        /// </summary>
        Task<int> GetTotalShowtimesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the total number of halls.
        /// </summary>
        Task<int> GetTotalHallsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the total revenue across all bookings.
        /// </summary>
        Task<decimal> GetTotalRevenueAsync(CancellationToken cancellationToken = default);

        #endregion

        #region Revenue Tracking

        /// <summary>
        /// Gets the total revenue for a specific month of a year.
        /// </summary>
        Task<decimal> GetMonthlyRevenueAsync(int year, int month, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the total revenue for a specific day.
        /// </summary>
        Task<decimal> GetDailyRevenueAsync(DateTime date, CancellationToken cancellationToken = default);

        #endregion

        #region Movie Statistics

        /// <summary>
        /// Gets the count of upcoming movies.
        /// </summary>
        Task<int> GetUpcomingMoviesCountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the count of currently showing movies.
        /// </summary>
        Task<int> GetNowShowingMoviesCountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the count of ended movies.
        /// </summary>
        Task<int> GetEndedMoviesCountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a dictionary of movie counts grouped by their status.
        /// </summary>
        Task<Dictionary<MovieStatus, int>> GetMoviesByStatusAsync(CancellationToken cancellationToken = default);

        #endregion

        #region Booking Statistics

        /// <summary>
        /// Gets the count of pending bookings.
        /// </summary>
        Task<int> GetPendingBookingsCountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the count of confirmed bookings.
        /// </summary>
        Task<int> GetConfirmedBookingsCountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the count of cancelled bookings.
        /// </summary>
        Task<int> GetCancelledBookingsCountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a dictionary of booking counts grouped by their status.
        /// </summary>
        Task<Dictionary<BookingStatus, int>> GetBookingsByStatusAsync(CancellationToken cancellationToken = default);

        #endregion

        #region Recent / Popular Items

        /// <summary>
        /// Gets the most recent movies.
        /// </summary>
        Task<IEnumerable<Movie>> GetRecentMoviesAsync(int count = 5, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the most recent bookings.
        /// </summary>
        Task<IEnumerable<Booking>> GetRecentBookingsAsync(int count = 5, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the most recent registered users.
        /// </summary>
        Task<IEnumerable<ApplicationUser>> GetRecentUsersAsync(int count = 5, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the most popular movies by booking count.
        /// </summary>
        Task<IEnumerable<Movie>> GetPopularMoviesAsync(int count = 5, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the most popular cinemas by total bookings.
        /// </summary>
        Task<IEnumerable<Cinema>> GetPopularCinemasAsync(int count = 5, CancellationToken cancellationToken = default);

        #endregion

        #region Chart Data

        /// <summary>
        /// Gets the monthly booking count series for a given year.
        /// Returns a dictionary where key = month name (e.g., "Jan") and value = booking count.
        /// </summary>
        Task<Dictionary<string, int>> GetMonthlyBookingsSeriesAsync(int year, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the monthly revenue series for a given year.
        /// Returns a dictionary where key = month name (e.g., "Jan") and value = revenue amount.
        /// </summary>
        Task<Dictionary<string, decimal>> GetMonthlyRevenueSeriesAsync(int year, CancellationToken cancellationToken = default);

        #endregion
    }
}
