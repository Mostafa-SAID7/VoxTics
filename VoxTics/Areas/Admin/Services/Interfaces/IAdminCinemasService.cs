using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Models.Entities;

namespace VoxTics.Services.Interfaces
{
    /// <summary>
    /// Service interface for admin-side cinema management.
    /// Handles business logic, validation, and interaction with the repository.
    /// </summary>
    public interface IAdminCinemaService
    {
        /// <summary>
        /// Retrieves paged cinemas with optional search, city filter, and status filter.
        /// </summary>
        Task<(IEnumerable<Cinema> Cinemas, int TotalCount)> GetPagedCinemasAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? city = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a single cinema by its ID.
        /// </summary>
        Task<Cinema?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new cinema.
        /// Returns list of validation errors if any, empty list if successful.
        /// </summary>
        Task<List<string>> AddCinemaAsync(Cinema cinema, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing cinema.
        /// Returns list of validation errors if any, empty list if successful.
        /// </summary>
        Task<List<string>> UpdateCinemaAsync(Cinema cinema, CancellationToken cancellationToken = default);

        /// <summary>
        /// Activates or deactivates a cinema.
        /// Returns true if operation succeeded.
        /// </summary>
        Task<bool> SetCinemaStatusAsync(int cinemaId, bool isActive, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a cinema (hard delete).
        /// Returns true if operation succeeded.
        /// </summary>
        Task<bool> DeleteCinemaAsync(int cinemaId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves statistics for a specific cinema.
        /// </summary>
        Task<(int TotalShowtimes, int UpcomingMovies, decimal Revenue)> GetCinemaStatsAsync(
            int cinemaId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves audit info for a cinema (created, updated, last showtime).
        /// </summary>
        Task<(DateTime CreatedAt, DateTime? UpdatedAt, DateTime? LastShowtime)> GetCinemaAuditInfoAsync(
            int cinemaId,
            CancellationToken cancellationToken = default);
    }
}
