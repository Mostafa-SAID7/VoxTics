using VoxTics.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using VoxTics.Data;

namespace VoxTics.Repositories
{
    /// <summary>
    /// Repository for public-facing home page and movie discovery features.
    /// </summary>
    public class HomeRepository : IHomeRepository
    {
        private readonly MovieDbContext _context;

        public HomeRepository(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Movie>> GetFeaturedMoviesAsync(CancellationToken cancellationToken = default) =>
            await _context.Movies
                .AsNoTracking()
                .Where(m => m.IsFeatured && m.ReleaseDate <= DateTime.UtcNow)
                .OrderByDescending(m => m.Rating)
                .Take(10)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

        public async Task<IEnumerable<Movie>> GetTrendingMoviesAsync(int count = 5,
                                                                     CancellationToken cancellationToken = default) =>
            await _context.Bookings
                .AsNoTracking()
                .GroupBy(b => b.Movie)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(count)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

        public async Task<IEnumerable<Movie>> GetUpcomingMoviesAsync(DateTime fromDate, int count = 10,
                                                                     CancellationToken cancellationToken = default) =>
            await _context.Movies
                .AsNoTracking()
                .Where(m => m.ReleaseDate > fromDate)
                .OrderBy(m => m.ReleaseDate)
                .Take(count)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

        public async Task<IEnumerable<Movie>> GetRecommendedMoviesForUserAsync(
            string userId, int count = 5, CancellationToken cancellationToken = default)
        {
            // مثال بسيط: التوصيات بناءً على الفئات الأكثر حجزًا من قِبل المستخدم.
            var favoriteCategories = await _context.Bookings
                .Where(b => b.UserId == userId)
                .GroupBy(b => b.Movie.CategoryId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(2)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return await _context.Movies
                .AsNoTracking()
                .Where(m => favoriteCategories.Contains(m.CategoryId) && m.ReleaseDate <= DateTime.UtcNow)
                .OrderByDescending(m => m.Rating)
                .Take(count)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<IDictionary<Category, IEnumerable<Movie>>>
            GetCategoriesWithTopMoviesAsync(int topPerCategory = 5, CancellationToken cancellationToken = default)
        {
            var categories = await _context.Categories.AsNoTracking().ToListAsync(cancellationToken).ConfigureAwait(false);

            var result = new Dictionary<Category, IEnumerable<Movie>>();

            foreach (var category in categories)
            {
                var topMovies = await _context.Movies
                    .AsNoTracking()
                    .Where(m => m.CategoryId == category.Id)
                    .OrderByDescending(m => m.Rating)
                    .Take(topPerCategory)
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);

                result[category] = topMovies;
            }

            return result;
        }

        public async Task<IEnumerable<Movie>> SearchMoviesAsync(
            string searchTerm, int maxResults = 20, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return Enumerable.Empty<Movie>();

            searchTerm = searchTerm.Trim().ToLowerInvariant();

            return await _context.Movies
                .AsNoTracking()
                .Where(m =>
                    m.Title.ToLower().Contains(searchTerm) ||
                    m.Description!.ToLower().Contains(searchTerm) ||
                    m.Category.Name.ToLower().Contains(searchTerm))
                .OrderByDescending(m => m.Rating)
                .Take(maxResults)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
