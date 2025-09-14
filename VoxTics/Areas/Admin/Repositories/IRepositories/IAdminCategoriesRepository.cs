using VoxTics.Repositories.IRepositories;

namespace VoxTics.Areas.Admin.Repositories.IRepositories
{
    /// <summary>
    /// Repository interface for category management in the Admin Area.
    /// </summary>
    public interface IAdminCategoriesRepository : IBaseRepository<Category>
    {
        /// <summary>
        /// Retrieves paginated categories with optional search term.
        /// </summary>
        Task<(IEnumerable<Category> Categories, int TotalCount)> GetPagedCategoriesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if a category name already exists (to prevent duplicates).
        /// </summary>
        Task<bool> CategoryNameExistsAsync(
            string name,
            int? excludeId = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets statistics for categories (e.g., total count, active count).
        /// </summary>
        Task<(int Total, int Active)> GetCategoryStatsAsync(
            CancellationToken cancellationToken = default);
    }
}
