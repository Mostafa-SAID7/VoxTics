using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Category;
using VoxTics.Models.Entities;

namespace VoxTics.Services.Interfaces
{
    public interface IAdminCategoriesService
    {
        Task<PaginatedList<CategoryViewModel>> GetPagedAsync(
            int pageIndex,
            int pageSize,
            string searchString = null,
            string sortColumn = null,
            bool sortDescending = false,
            CancellationToken cancellationToken = default);

        Task<CategoryDetailsViewModel?> GetDetailsByIdAsync(int id, CancellationToken cancellationToken = default);

        Task CreateAsync(CategoryCreateEditViewModel model, CancellationToken cancellationToken = default);

        Task UpdateAsync(CategoryCreateEditViewModel model, CancellationToken cancellationToken = default);

        Task DeleteAsync(int id, CancellationToken cancellationToken = default);

        Task<bool> SlugExistsAsync(string slug, int? excludeId = null, CancellationToken cancellationToken = default);
    }
}
