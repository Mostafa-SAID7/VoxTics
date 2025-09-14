using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.Entities;  // For Booking entity
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.Repositories.IRepositories
{
    // Inherit generic repository for Booking entity
    /// <summary>
    /// Repository interface for the admin dashboard.
    /// Provides analytics, KPIs, and summary data for business insights.
    /// </summary>
    public interface IDashboardRepository
    {
        #region Booking & Revenue Stats

        /// <summary>
        /// Gets revenue and booking stats for today, this week, and this month.
        /// </summary>
        Task<(decimal TodayRevenue, decimal WeeklyRevenue, decimal MonthlyRevenue,
              int TodayBookings, int WeeklyBookings, int MonthlyBookings)>
            GetRevenueAndBookingStatsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the top N movies by revenue or bookings.
        /// </summary>
        Task<IEnumerable<(Movie Movie, int BookingsCount, decimal TotalRevenue)>>
            GetTopMoviesAsync(int topN, DateTime? fromDate = null, DateTime? toDate = null,
                              CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the most active cinemas based on bookings.
        /// </summary>
        Task<IEnumerable<(Cinema Cinema, int BookingsCount)>>
            GetTopCinemasAsync(int topN, DateTime? fromDate = null, DateTime? toDate = null,
                               CancellationToken cancellationToken = default);

        #endregion

        #region System Health & Misc

        /// <summary>
        /// Gets total counts for main entities (movies, cinemas, users, bookings).
        /// </summary>
        Task<(int TotalMovies, int TotalCinemas, int TotalUsers, int TotalBookings)>
            GetEntityTotalsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets recent bookings for quick review.
        /// </summary>
        Task<IEnumerable<Booking>> GetRecentBookingsAsync(int count = 10,
                                                          CancellationToken cancellationToken = default);
        #endregion
    }
}
