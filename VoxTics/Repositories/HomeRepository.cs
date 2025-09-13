using VoxTics.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using VoxTics.Data;

namespace VoxTics.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly MovieDbContext _context;

        public HomeRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetNowShowingAsync()
        {
            return await _context.Movies
                .Where(m => m.ReleaseDate <= DateTime.Now)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetComingSoonAsync()
        {
            return await _context.Movies
                .Where(m => m.ReleaseDate > DateTime.Now)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cinema>> GetCinemasAsync()
        {
            return await _context.Cinemas.ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetFeaturedMoviesAsync()
        {
            // Example implementation: featured movies could be flagged in the DB
            return await _context.Movies
                .Where(m => m.IsFeatured) // adjust based on your schema
                .ToListAsync();
        }
    }
}
