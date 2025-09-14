using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Data.UoW;
using VoxTics.Helpers;
using VoxTics.Services;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Services.Implementations
{
    /// <summary>
    /// Admin service for full CRUD and validation of movie categories.
    /// </summary>
    public class AdminCategoriesService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminCategoriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        #region User area placeholders (handled by CategoryService)

        public Task<IEnumerable<Category>> GetActiveCategoriesAsync(CancellationToken cancellationToken = default) =>
            throw new NotImplementedException("Use CategoryService for user-facing operations.");

        public Task<PaginatedList<Category>> GetPagedCategoriesAsync(
            int pageIndex, int pageSize, string? searchTerm = null, string? sortOrder = null,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException("Use CategoryService for user-facing operations.");

        #endregion

        public async Task<Category> CreateCategoryAsync(Category category, CancellationToken cancellationToken = default)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            category.Name = ValidationHelpers.SanitizeInput(category.Name);

            if (!ValidationHelpers.ContainsOnlyLettersAndSpaces(category.Name))
                throw new ArgumentException("Category name contains invalid characters.");

            if (await CategoryNameExistsAsync(category.Name, null, cancellationToken))
                throw new InvalidOperationException("A category with the same name already exists.");

            await _unitOfWork.Categories.AddAsync(category, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return category;
        }

        public async Task<bool> UpdateCategoryAsync(Category category, CancellationToken cancellationToken = default)
        {
            var existing = await _unitOfWork.Categories.GetByIdAsync(category.Id, cancellationToken);
            if (existing == null) return false;

            category.Name = ValidationHelpers.SanitizeInput(category.Name);

            if (!ValidationHelpers.ContainsOnlyLettersAndSpaces(category.Name))
                throw new ArgumentException("Category name contains invalid characters.");

            if (await CategoryNameExistsAsync(category.Name, category.Id, cancellationToken))
                throw new InvalidOperationException("A category with the same name already exists.");

            existing.Name = category.Name;
            existing.IsActive = category.IsActive;

            await _unitOfWork.Categories.UpdateAsync(existing, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(categoryId, cancellationToken);
            if (category == null) return false;

            await _unitOfWork.Categories.RemoveAsync(category, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }

        public async Task<Category?> GetCategoryByIdAsync(int categoryId, CancellationToken cancellationToken = default) =>
            await _unitOfWork.Categories.GetByIdAsync(categoryId, cancellationToken);

        public async Task<bool> CategoryNameExistsAsync(
            string categoryName, int? excludeId = null, CancellationToken cancellationToken = default)
        {
            var sanitized = ValidationHelpers.SanitizeInput(categoryName);
            var exists = await _unitOfWork.Categories.AnyAsync(
                c => c.Name.ToLower() == sanitized.ToLower() &&
                     (!excludeId.HasValue || c.Id != excludeId.Value),
                cancellationToken);

            return exists;
        }
    }
}
