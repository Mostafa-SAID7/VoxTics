using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    /// <summary>
    /// Service implementation for admin-side category management.
    /// Handles business logic, validation, and interaction with repository.
    /// </summary>
    public class AdminCategoryService : IAdminCategoryService
    {
        private readonly IAdminCategoriesRepository _categoryRepository;

        public AdminCategoryService(IAdminCategoriesRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<(IEnumerable<Category> Categories, int TotalCount)> GetPagedCategoriesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            CancellationToken cancellationToken = default)
        {
            return await _categoryRepository
                .GetPagedCategoriesAsync(pageIndex, pageSize, searchTerm, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<bool> CategoryNameExistsAsync(
            string name,
            int? excludeId = null,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Category name cannot be empty.", nameof(name));

            return await _categoryRepository
                .CategoryNameExistsAsync(name, excludeId, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<(int Total, int Active)> GetCategoryStatsAsync(CancellationToken cancellationToken = default)
        {
            return await _categoryRepository
                .GetCategoryStatsAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _categoryRepository.GetByIdAsync(id, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task AddCategoryAsync(Category category, CancellationToken cancellationToken = default)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            await _categoryRepository.AddAsync(category, cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateCategoryAsync(Category category, CancellationToken cancellationToken = default)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            await _categoryRepository.UpdateAsync(category, cancellationToken).ConfigureAwait(false);
        }

        public async Task DeleteCategoryAsync(int id, CancellationToken cancellationToken = default)
        {
            var category = await _categoryRepository.GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
            if (category == null) return; // or throw if you prefer

            await _categoryRepository.RemoveAsync(category, cancellationToken).ConfigureAwait(false);
        }

    }
}
