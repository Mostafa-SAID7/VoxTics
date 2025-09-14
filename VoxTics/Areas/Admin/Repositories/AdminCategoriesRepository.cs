using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Repositories;

namespace VoxTics.Areas.Admin.Repositories
{
    /// <summary>
    /// Repository for category management in Admin Area.
    /// </summary>
    public class AdminCategoriesRepository : BaseRepository<Category>, IAdminCategoriesRepository
    {
        private readonly MovieDbContext _context;

        public AdminCategoriesRepository(MovieDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<(IEnumerable<Category> Categories, int TotalCount)> GetPagedCategoriesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            CancellationToken cancellationToken = default)
        {
            if (pageIndex < 0) pageIndex = 0;
            if (pageSize <= 0) pageSize = 10;

            IQueryable<Category> query = _context.Categories.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.Trim().ToLower();
                query = query.Where(c => c.Name.ToLower().Contains(searchTerm));
            }

            int totalCount = await query.CountAsync(cancellationToken).ConfigureAwait(false);

            var categories = await query
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return (categories, totalCount);
        }

        public async Task<bool> CategoryNameExistsAsync(
            string name,
            int? excludeId = null,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Category name cannot be empty.", nameof(name));

            name = name.Trim().ToLower();
            return await _context.Categories
                .AnyAsync(c =>
                    c.Name.ToLower() == name &&
                    (!excludeId.HasValue || c.Id != excludeId.Value),
                    cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<(int Total, int Active)> GetCategoryStatsAsync(
            CancellationToken cancellationToken = default)
        {
            int total = await _context.Categories.CountAsync(cancellationToken).ConfigureAwait(false);
            int active = await _context.Categories.CountAsync(c => c.IsActive, cancellationToken).ConfigureAwait(false);
            return (total, active);
        }
    }
}
