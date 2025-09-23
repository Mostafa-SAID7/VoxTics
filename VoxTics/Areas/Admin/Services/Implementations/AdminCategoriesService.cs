using System;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Admin.ViewModels.Category;
using VoxTics.Helpers;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class AdminCategoriesService : IAdminCategoriesService
    {
        private readonly IAdminCategoriesRepository _repository;

        public AdminCategoriesService(IAdminCategoriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedList<CategoryViewModel>> GetPagedAsync(
            int pageIndex,
            int pageSize,
            string searchString = null,
            string sortColumn = null,
            bool sortDescending = false,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await _repository.GetPagedAsync(
                    pageIndex, pageSize, searchString, sortColumn, sortDescending, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load categories.", ex);
            }
        }

        public async Task<CategoryDetailsViewModel?> GetDetailsByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await _repository.GetDetailsByIdAsync(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to fetch details for Category ID {id}.", ex);
            }
        }

        public async Task CreateAsync(
            CategoryCreateEditViewModel model,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (await SlugExistsAsync(model.Slug, null, cancellationToken))
                    throw new InvalidOperationException($"Slug '{model.Slug}' already exists.");

                await _repository.CreateAsync(model, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to create category.", ex);
            }
        }

        public async Task UpdateAsync(
            CategoryCreateEditViewModel model,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (await SlugExistsAsync(model.Slug, model.Id, cancellationToken))
                    throw new InvalidOperationException($"Slug '{model.Slug}' already exists.");

                await _repository.UpdateAsync(model, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to update Category ID {model.Id}.", ex);
            }
        }

        public async Task DeleteAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await _repository.DeleteAsync(id, cancellationToken);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx) when
                (dbEx.InnerException?.Message.Contains("REFERENCE constraint") == true)
            {
                // Handle foreign key conflicts gracefully
                throw new InvalidOperationException(
                    "This category cannot be deleted because related records exist. Remove or reassign them first.", dbEx);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to delete Category ID {id}.", ex);
            }
        }

        public async Task<bool> SlugExistsAsync(
            string slug,
            int? excludeId = null,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await _repository.SlugExistsAsync(slug, excludeId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to check if slug '{slug}' exists.", ex);
            }
        }
    }
}
