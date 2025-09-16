using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.Entities;

namespace VoxTics.Services.Interfaces
{
    /// <summary>
    /// Service interface for admin-side category operations.
    /// </summary>
    public interface IAdminCategoryService
    {
        Task<(IEnumerable<Category> Categories, int TotalCount)> GetPagedCategoriesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            CancellationToken cancellationToken = default);

        Task<bool> CategoryNameExistsAsync(
            string name,
            int? excludeId = null,
            CancellationToken cancellationToken = default);

        Task<(int Total, int Active)> GetCategoryStatsAsync(CancellationToken cancellationToken = default);

        Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task AddCategoryAsync(Category category, CancellationToken cancellationToken = default);

        Task UpdateCategoryAsync(Category category, CancellationToken cancellationToken = default);

        Task DeleteCategoryAsync(int id, CancellationToken cancellationToken = default);
    }
}
