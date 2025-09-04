using Microsoft.EntityFrameworkCore;
using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Repositories.Implementations
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly MovieDbContext _movieDb;

        public MovieRepository(MovieDbContext context) : base(context)
        {
            _movieDb = context;
        }

        public async Task<IEnumerable<Movie>> GetAllWithIncludesAsync()
        {
            return await _movieDb.Movies
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                .Include(m => m.Images)
                .Include(m => m.Showtimes)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Movie?> GetByIdWithIncludesAsync(int id)
        {
            return await _movieDb.Movies
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                .Include(m => m.Images)
                .Include(m => m.Showtimes)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
