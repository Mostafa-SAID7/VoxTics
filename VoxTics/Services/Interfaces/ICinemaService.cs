using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Helpers;

namespace VoxTics.Services.Interfaces
{
    /// <summary>
    /// Provides cinema-related functionality for user-facing operations such as browsing and searching.
    /// </summary>
    public interface ICinemaService
    {
        /// <summary>
        /// Gets all active cinemas ordered by name or city.
        /// </summary>
        Task<IEnumerable<Cinema>> GetActiveCinemasAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets paged and optionally filtered cinemas for the user-facing catalog.
        /// </summary>
        Task<PaginatedList<Cinema>> GetPagedCinemasAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? sortOrder = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets details of a specific cinema, including location and available showtimes.
        /// </summary>
        Task<Cinema?> GetCinemaDetailsAsync(
            int cinemaId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all showtimes for a cinema for the current and upcoming days.
        /// </summary>
        Task<IEnumerable<Showtime>> GetUpcomingShowtimesAsync(
            int cinemaId,
            int daysAhead = 7,
            CancellationToken cancellationToken = default);
    }
}
