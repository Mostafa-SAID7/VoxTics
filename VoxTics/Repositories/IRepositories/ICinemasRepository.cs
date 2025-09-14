using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Repositories.IRepositories
{
    /// <summary>
    /// Contract for advanced Cinema repository operations with caching and logging.
    /// </summary>
    public interface ICinemasRepository : IBaseRepository<Cinema>
    {
        /// <summary>
        /// Retrieves all active cinemas sorted by name (with optional caching).
        /// </summary>
        Task<IEnumerable<Cinema>> GetActiveCinemasAsync(
            bool useCache = true,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches cinemas by name or city with paging support.
        /// </summary>
        Task<(IEnumerable<Cinema> Cinemas, int TotalCount)> SearchCinemasAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? city = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves cinema details including related showtimes and movies.
        /// </summary>
        Task<Cinema?> GetCinemaDetailsAsync(
            int cinemaId,
            bool useCache = true,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if a cinema name already exists (for validation).
        /// </summary>
        Task<bool> CinemaNameExistsAsync(
            string name,
            int? excludeId = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves basic stats for dashboard display.
        /// </summary>
        Task<(int Total, int Active, int WithUpcomingShowtimes)> GetCinemaStatsAsync(
            bool useCache = true,
            CancellationToken cancellationToken = default);
    }
}
