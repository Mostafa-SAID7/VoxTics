using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Data.UoW;
using VoxTics.Helpers;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    /// <summary>
    /// User-facing category service for browsing and retrieving categories.
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<Category>> GetActiveCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _unitOfWork.Categories
                .FindAsync(c => c.IsActive, cancellationToken)
                .ConfigureAwait(false);

            return categories.OrderBy(c => c.Name);
        }

        public async Task<PaginatedList<Category>> GetPagedCategoriesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? sortOrder = null,
            CancellationToken cancellationToken = default)
        {
            var query = _unitOfWork.Categories.Query().Where(c => c.IsActive);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var sanitized = ValidationHelpers.SanitizeInput(searchTerm);
                query = query.Where(c => c.Name.Contains(sanitized));
            }

            //query = query.ApplySorting(sortOrder, c => c.Name);

            return await query.ToPaginatedListAsync(pageIndex, pageSize, cancellationToken)
                              .ConfigureAwait(false);
        }

        
    }
}

