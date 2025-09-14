using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories;

namespace VoxTics.Repositories.IRepositories
{
    /// <summary>
    /// Repository interface for end-user category queries (read-only operations).
    /// </summary>
    public interface ICategoriesRepository : IBaseRepository<Category>
    {
        /// <summary>
        /// Gets all active categories (used for filtering movies on the public site).
        /// </summary>
        Task<IEnumerable<Category>> GetActiveCategoriesAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches categories by name (case-insensitive).
        /// </summary>
        Task<IEnumerable<Category>> SearchCategoriesAsync(
            string searchTerm,
            CancellationToken cancellationToken = default);
    }

}
