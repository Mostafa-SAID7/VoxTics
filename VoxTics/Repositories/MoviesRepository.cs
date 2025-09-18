using Microsoft.EntityFrameworkCore;
using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Repositories.IRepositories;
using System.Threading.Tasks;

namespace VoxTics.Repositories
{
    public class MoviesRepository : BaseRepository<Movie>, IMoviesRepository
    {
        private readonly MovieDbContext _context;

        public MoviesRepository(MovieDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Get movie by slug (for SEO-friendly URLs)
        /// </summary>
        public async Task<Movie?> GetBySlugAsync(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
                return null;

            return await _context.Movies
                                 .Include(m => m.Category)
                                 .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                                 .Include(m => m.Showtimes)
                                 .Include(m => m.MovieImages)
                                 .FirstOrDefaultAsync(m => m.Slug == slug);
        }

        // You can add more movie-specific queries here, e.g., featured movies, upcoming, etc.
    }
}
