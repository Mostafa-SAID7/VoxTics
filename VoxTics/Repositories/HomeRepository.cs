using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly MovieDbContext _context;

        public HomeRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetNowShowingMoviesAsync(int count)
        {
            return await _context.Movies
                .Where(m => m.Status == Models.Enums.MovieStatus.NowShowing)
                .OrderByDescending(m => m.ReleaseDate)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetUpcomingMoviesAsync(int count)
        {
            return await _context.Movies
                .Where(m => m.Status == Models.Enums.MovieStatus.Upcoming)
                .OrderBy(m => m.ReleaseDate)
                .Take(count)
                .ToListAsync();
        }
    }
}
