using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Admin.ViewModels.Category;
using VoxTics.Repositories;

namespace VoxTics.Areas.Admin.Repositories
{
    public class AdminCategoriesRepository : IAdminCategoriesRepository
    {
        private readonly IBaseRepository<Category> _baseRepository;
        private readonly IMapper _mapper;

        public AdminCategoriesRepository(IBaseRepository<Category> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CategoryViewModel>> GetPagedAsync(
            int pageIndex,
            int pageSize,
            string searchString = null,
            string sortColumn = null,
            bool sortDescending = false,
            CancellationToken cancellationToken = default)
        {
            // Start query
            var query = _baseRepository.Query();

            // Search
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(c => c.Name.Contains(searchString) || c.Slug.Contains(searchString));
            }

            // Sorting
            if (!string.IsNullOrEmpty(sortColumn))
            {
                query = query.ApplySorting(sortColumn, sortDescending);
            }
            else
            {
                query = query.OrderBy(c => c.Name); // default sorting
            }

            // Pagination
            var pagedEntities = await query.ToPaginatedListAsync(pageIndex, pageSize, cancellationToken);

            // Map to ViewModel
            var pagedViewModels = pagedEntities.Items
                .Select(c => _mapper.Map<CategoryViewModel>(c))
                .ToList();

            return new PaginatedList<CategoryViewModel>(pagedViewModels, pagedEntities.TotalCount, pageIndex, pageSize);
        }

        public async Task<CategoryDetailsViewModel?> GetDetailsByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var category = await _baseRepository.GetByIdAsync(id, cancellationToken);
            return category == null ? null : _mapper.Map<CategoryDetailsViewModel>(category);
        }

        public async Task CreateAsync(CategoryCreateEditViewModel model, CancellationToken cancellationToken = default)
        {
            var category = _mapper.Map<Category>(model);
            await _baseRepository.AddAsync(category, cancellationToken);
            await _baseRepository.CommitAsync();
        }

        public async Task UpdateAsync(CategoryCreateEditViewModel model, CancellationToken cancellationToken = default)
        {
            var category = await _baseRepository.GetByIdAsync(model.Id, cancellationToken);
            if (category == null)
                throw new KeyNotFoundException($"Category with ID {model.Id} not found.");

            _mapper.Map(model, category);
            await _baseRepository.UpdateAsync(category, cancellationToken);
            await _baseRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var category = await _baseRepository.GetByIdAsync(id, cancellationToken);
            if (category == null)
                throw new KeyNotFoundException($"Category with ID {id} not found.");

            await _baseRepository.RemoveAsync(category, cancellationToken);
            await _baseRepository.CommitAsync();
        }

        public async Task<bool> SlugExistsAsync(string slug, int? excludeId = null, CancellationToken cancellationToken = default)
        {
            return await _baseRepository.AnyAsync(c => c.Slug == slug && (!excludeId.HasValue || c.Id != excludeId.Value), cancellationToken);
        }
    }
}
