using VoxTics.Repositories.IRepositories;

namespace VoxTics.Areas.Admin.Repositories.IRepositories
{
    /// <summary>
    /// Admin-focused repository for managing and auditing showtimes.
    /// Includes scheduling, cancellation, and analytics.
    /// </summary>
    public interface IAdminShowtimesRepository : IBaseRepository<Showtime>
    {
        #region Management

        /// <summary>
        /// Schedules a new showtime for a movie in a cinema.
        /// </summary>
        Task<Showtime> ScheduleShowtimeAsync(
            int movieId,
            int cinemaId,
            DateTime startTime,
            int totalSeats,
            decimal price,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels an existing showtime (soft delete or flag).
        /// </summary>
        Task<bool> CancelShowtimeAsync(
            int showtimeId,
            string reason,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates pricing or timing for an existing showtime.
        /// </summary>
        Task<bool> UpdateShowtimeDetailsAsync(
            int showtimeId,
            DateTime? newStartTime = null,
            decimal? newPrice = null,
            int? updatedSeats = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves showtimes with pagination, search, and filters (e.g., by movie or cinema).
        /// </summary>
        Task<(IEnumerable<Showtime> Showtimes, int TotalCount)> GetPagedShowtimesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            int? movieId = null,
            int? cinemaId = null,
            DateTime? date = null,
            CancellationToken cancellationToken = default);

        #endregion

        #region Analytics

        /// <summary>
        /// Gets booking statistics for a showtime (total seats sold, revenue).
        /// </summary>
        Task<(int SoldSeats, decimal Revenue)> GetShowtimeStatsAsync(
            int showtimeId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets occupancy rate across all showtimes for a specific movie.
        /// </summary>
        Task<double> GetMovieOccupancyRateAsync(
            int movieId,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
