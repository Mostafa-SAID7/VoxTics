using VoxTics.Repositories.IRepositories;

namespace VoxTics.Areas.Admin.Repositories.IRepositories
{
    /// <summary>
    /// Repository interface for managing cinemas in the admin area.
    /// Provides advanced management operations beyond the public-facing repository.
    /// </summary>
    public interface IAdminCinemasRepository : IBaseRepository<Cinema>
    {
        /// <summary>
        /// Retrieves all cinemas with optional filtering by status or city.
        /// Supports paging and search for admin dashboard grids.
        /// </summary>
        Task<(IEnumerable<Cinema> Cinemas, int TotalCount)> GetPagedCinemasAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? city = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Activates or deactivates a cinema.
        /// </summary>
        Task<bool> SetCinemaStatusAsync(
            int cinemaId,
            bool isActive,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves detailed stats for a specific cinema, 
        /// including total showtimes, upcoming movies, and revenue data.
        /// </summary>
        Task<(int TotalShowtimes, int UpcomingMovies, decimal Revenue)> GetCinemaDetailsStatsAsync(
            int cinemaId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets audit information for a cinema (e.g., created/updated timestamps, last activity).
        /// </summary>
        Task<(DateTime CreatedAt, DateTime? UpdatedAt, DateTime? LastShowtime)> GetCinemaAuditInfoAsync(
            int cinemaId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Hard-deletes a cinema and all related showtimes and bookings (use with caution).
        /// </summary>
        Task<bool> HardDeleteCinemaAsync(
            int cinemaId,
            CancellationToken cancellationToken = default);
    }
}
