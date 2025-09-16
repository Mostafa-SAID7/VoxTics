using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Areas.Admin.Repositories.IRepositories
{
    public interface IAdminShowtimesRepository : IBaseRepository<Showtime>
    {
        #region Queries

        /// <summary>
        /// Get all showtimes with related Movie, Cinema, and Hall details.
        /// </summary>
        Task<IEnumerable<Showtime>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a showtime by its ID including related entities.
        /// </summary>
        Task<Showtime?> GetByIdWithDetailsAsync(int showtimeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Check if a showtime overlaps with existing showtimes in the same hall.
        /// </summary>
        Task<bool> IsOverlappingAsync(int hallId, DateTime startTime, int duration, int? excludeShowtimeId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all upcoming showtimes (StartTime >= now).
        /// </summary>
        Task<IEnumerable<Showtime>> GetUpcomingShowtimesAsync(int count = 10, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get showtimes for a specific movie.
        /// </summary>
        Task<IEnumerable<Showtime>> GetByMovieAsync(int movieId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get showtimes for a specific cinema.
        /// </summary>
        Task<IEnumerable<Showtime>> GetByCinemaAsync(int cinemaId, CancellationToken cancellationToken = default);

        #endregion

        #region Admin Operations

        /// <summary>
        /// Update the status of a showtime (Scheduled, Active, Cancelled, etc.)
        /// </summary>
        Task UpdateStatusAsync(int showtimeId, ShowtimeStatus status, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the pricing of a showtime.
        /// </summary>
        Task UpdatePriceAsync(int showtimeId, decimal newPrice, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a showtime and optionally cascade remove associated bookings.
        /// </summary>
        Task DeleteShowtimeAsync(int showtimeId, bool removeBookings = true, CancellationToken cancellationToken = default);

        #endregion

        #region Advanced Filtering / Search

        /// <summary>
        /// Filter showtimes based on date range, movie, cinema, hall, and status.
        /// </summary>
        Task<IEnumerable<Showtime>> FilterShowtimesAsync(
            DateTime? from = null,
            DateTime? to = null,
            int? movieId = null,
            int? cinemaId = null,
            int? hallId = null,
            ShowtimeStatus? status = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Search showtimes by movie title, cinema name, or hall name.
        /// </summary>
        Task<IEnumerable<Showtime>> SearchShowtimesAsync(string query, CancellationToken cancellationToken = default);

        #endregion
    }
}
