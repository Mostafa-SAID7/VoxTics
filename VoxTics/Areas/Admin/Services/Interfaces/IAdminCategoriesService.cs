namespace VoxTics.Areas.Admin.Services.Interfaces
{
    public interface IAdminCategoriesService
    {
        #region Admin Area

        /// <summary>
        /// Creates a new category after validating its data.
        /// </summary>

        Task<PaginatedList<Category>> GetPagedCategoriesAsync(
           int pageIndex,
           int pageSize,
           string? searchTerm = null,
           string? sortOrder = null,
           CancellationToken cancellationToken = default);

        Task<Category> CreateCategoryAsync(
            Category category,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing category with new details.
        /// </summary>
        Task<bool> UpdateCategoryAsync(
            Category category,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Soft deletes or deactivates a category.
        /// </summary>
        Task<bool> DeleteCategoryAsync(
            int categoryId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets category details for editing in the admin panel.
        /// </summary>
        Task<Category?> GetCategoryByIdAsync(
            int categoryId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if a category name already exists (case-insensitive).
        /// </summary>
        Task<bool> CategoryNameExistsAsync(
            string categoryName,
            int? excludeId = null,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
