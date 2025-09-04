using Microsoft.EntityFrameworkCore;
using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Repositories.Implementations
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieDbContext context) : base(context)
        {
        }

        public IQueryable<Movie> Query(string includeProperties = "")
        {
            IQueryable<Movie> query = _dbSet.AsQueryable();

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }
            }

            return query;
        }

        public async Task<List<Movie>> GetAllWithIncludesAsync()
        {
            // include common navigation properties
            return await _dbSet
                .Include(m => m.Images)
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                .Include(m => m.Showtimes)
                .ToListAsync();
        }

        public async Task<Movie?> GetByIdWithIncludesAsync(int id)
        {
            return await _dbSet
                .Include(m => m.Images)
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                .Include(m => m.Showtimes)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
