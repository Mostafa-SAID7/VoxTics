using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Helpers;

namespace VoxTics.Areas.Admin.Services.Interfaces
{
    /// <summary>
    /// Provides full CRUD and management functionality for cinemas in the admin area.
    /// </summary>
    public interface IAdminCinemasService
    {
        /// <summary>
        /// Gets a paginated list of cinemas with optional search and sorting.
        /// </summary>
        Task<PaginatedList<Cinema>> GetPagedCinemasAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? sortOrder = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new cinema and persists it to the database.
        /// </summary>
        Task<Cinema> CreateCinemaAsync(
            Cinema cinema,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the details of an existing cinema.
        /// </summary>
        Task<bool> UpdateCinemaAsync(
            Cinema cinema,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a cinema by ID. Optionally handles related showtimes or bookings.
        /// </summary>
        Task<bool> DeleteCinemaAsync(
            int cinemaId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a cinema by ID for editing or detail view.
        /// </summary>
        Task<Cinema?> GetCinemaByIdAsync(
            int cinemaId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Toggles the active status of a cinema (enable/disable in catalog).
        /// </summary>
        Task<bool> ToggleCinemaStatusAsync(
            int cinemaId,
            bool isActive,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if a cinema name already exists (to avoid duplicates).
        /// </summary>
        Task<bool> CinemaNameExistsAsync(
            string name,
            int? excludeId = null,
            CancellationToken cancellationToken = default);
    }
}
