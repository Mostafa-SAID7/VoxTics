using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Repositories.IRepositories
{
    /// <summary>
    /// Repository interface for managing showtimes in the user-facing area.
    /// Provides CRUD, advanced queries, and availability checks.
    /// </summary>
    public interface IShowtimesRepository : IBaseRepository<Showtime>
    {
        #region Queries

        /// <summary>
        /// Retrieves all upcoming showtimes for a specific movie.
        /// </summary>
        Task<IEnumerable<Showtime>> GetUpcomingShowtimesForMovieAsync(
            int movieId,
            DateTime fromDate,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets showtimes by cinema and date for browsing schedules.
        /// </summary>
        Task<IEnumerable<Showtime>> GetShowtimesByCinemaAndDateAsync(
            int cinemaId,
            DateTime date,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if a showtime is available for booking (not sold out or cancelled).
        /// </summary>
        Task<bool> IsShowtimeAvailableAsync(
            int showtimeId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets detailed info about a showtime including movie, cinema, and seat map.
        /// </summary>
        Task<Showtime?> GetShowtimeDetailsAsync(
            int showtimeId,
            CancellationToken cancellationToken = default);

        #endregion

        #region Commands

        /// <summary>
        /// Decreases available seats when a booking is made.
        /// </summary>
        Task<bool> ReserveSeatAsync(
            int showtimeId,
            int numberOfSeats,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Reverts seat reservation if booking is canceled.
        /// </summary>
        Task<bool> ReleaseSeatsAsync(
            int showtimeId,
            int numberOfSeats,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
