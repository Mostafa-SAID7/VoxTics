using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Repositories;

namespace VoxTics.Areas.Admin.Repositories
{
    public class AdminMoviesRepository : BaseRepository<Movie>, IAdminMoviesRepository
    {
        private readonly MovieDbContext _context;

        public AdminMoviesRepository(MovieDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Movie> Movies, int TotalCount)> GetPagedMoviesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            CancellationToken cancellationToken = default)
        {
            var query = _context.Movies.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(m => m.Title.Contains(searchTerm));
            }

            var total = await query.CountAsync(cancellationToken).ConfigureAwait(false);

            var movies = await query
                .OrderByDescending(m => m.ReleaseDate)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return (movies, total);
        }

        public async Task<(int Total, int Active, int Upcoming)> GetMovieStatsAsync(CancellationToken cancellationToken = default)
        {
            var total = await _context.Movies.CountAsync(cancellationToken).ConfigureAwait(false);
            var active = await _context.Movies.CountAsync(m => m.IsFeatured, cancellationToken).ConfigureAwait(false);
            var upcoming = await _context.Movies.CountAsync(m => m.ReleaseDate > System.DateTime.UtcNow, cancellationToken).ConfigureAwait(false);

            return (total, active, upcoming);
        }

        public async Task<bool> ArchiveMovieAsync(int movieId, CancellationToken cancellationToken = default)
        {
            var movie = await _context.Movies.FindAsync(new object?[] { movieId }, cancellationToken).ConfigureAwait(false);
            if (movie == null) return false;

            movie.IsFeatured = true;
            _context.Movies.Update(movie);
            return true;
        }

        public async Task<bool> ToggleMovieVisibilityAsync(int movieId, bool isFeatured, CancellationToken cancellationToken = default)
        {
            var movie = await _context.Movies.FindAsync(new object?[] { movieId }, cancellationToken).ConfigureAwait(false);
            if (movie == null) return false;

            movie.IsFeatured = isFeatured;
            _context.Movies.Update(movie);
            return true;
        }
    }
}
