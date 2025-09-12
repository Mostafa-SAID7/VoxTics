using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Models.Enums;
using VoxTics.Models.Entities;  // For Booking entity

namespace VoxTics.Repositories.IRepositories
{
    // Inherit generic repository for Booking entity
    public interface IDashboardRepository : IBaseRepository<Booking>
    {
        Task<int> GetTotalMoviesAsync(CancellationToken cancellationToken = default);
        Task<int> GetTotalUsersAsync(CancellationToken cancellationToken = default);
        Task<int> GetTotalBookingsAsync(CancellationToken cancellationToken = default);
        Task<int> GetTotalCategoriesAsync(CancellationToken cancellationToken = default);
        Task<decimal> GetTotalRevenueAsync(CancellationToken cancellationToken = default);

        Task<decimal> GetRevenueByDateRangeAsync(
            DateTime startDate,
            DateTime endDate,
            CancellationToken cancellationToken = default);

        Task<Dictionary<MovieStatus, int>> GetMoviesByStatusAsync(CancellationToken cancellationToken = default);
        Task<Dictionary<BookingStatus, int>> GetBookingsByStatusAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<MovieSummary>> GetRecentMoviesAsync(int count, CancellationToken cancellationToken = default);
        Task<IEnumerable<BookingSummary>> GetRecentBookingsAsync(int count, CancellationToken cancellationToken = default);
        Task<IEnumerable<UserSummary>> GetRecentUsersAsync(int count, CancellationToken cancellationToken = default);
    }
}
