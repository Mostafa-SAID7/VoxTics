using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Helpers;

namespace VoxTics.Services
{
    /// <summary>
    /// Service interface for managing movie categories.
    /// Supports both user-facing and admin use cases.
    /// </summary>
    public interface ICategoryService
    {
        #region User Area

        /// <summary>
        /// Gets all active categories for displaying to users.
        /// </summary>
        Task<IEnumerable<Category>> GetActiveCategoriesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets paginated categories for a user search or browse page.
        /// </summary>
        Task<PaginatedList<Category>> GetPagedCategoriesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? sortOrder = null,
            CancellationToken cancellationToken = default);

        #endregion

     
    }
}
