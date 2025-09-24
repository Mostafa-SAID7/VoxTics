using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Helpers;
using VoxTics.Models.Entities;

namespace VoxTics.Areas.Admin.Services.Interfaces
{
    public interface IAdminCinemasService
    {
        /// <summary>
        /// Returns a paginated list of CinemaViewModel for listing pages.
        /// </summary>
        Task<PaginatedList<CinemaViewModel>> GetPagedAsync(
            int pageIndex,
            int pageSize,
            string? search = null,
            string? sortColumn = null,
            bool sortDescending = false,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns details for a single cinema.
        /// </summary>
        Task<CinemaDetailsViewModel?> GetDetailsByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new cinema from a view model.
        /// </summary>
        Task CreateAsync(
            CinemaCreateEditViewModel model,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing cinema using data from a view model.
        /// </summary>
        Task UpdateAsync(
            CinemaCreateEditViewModel model,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a cinema by ID.
        /// </summary>
        Task DeleteAsync(
            int id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether a slug already exists (optionally excluding a cinema by ID).
        /// </summary>
        Task<bool> SlugExistsAsync(
            string slug,
            int? excludeId = null,
            CancellationToken cancellationToken = default);
    }
}
