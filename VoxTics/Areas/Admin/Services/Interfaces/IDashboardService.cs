using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Services.Interfaces
{
    public interface IDashboardService
    {
        /// <summary>
        /// Gets all relevant statistics for the admin dashboard.
        /// Includes bookings, revenue, movies, users, and showtimes metrics.
        /// </summary>
        /// <param name="cancellationToken">Optional cancellation token for async operations.</param>
        /// <returns>A DTO containing aggregated dashboard statistics.</returns>
        Task<DashboardStats> GetDashboardStatsAsync(CancellationToken cancellationToken = default);
    }

}
