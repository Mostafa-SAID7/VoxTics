using Microsoft.EntityFrameworkCore;
using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Repositories.Implementations
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly MovieDbContext _context;

        public CategoryRepository(MovieDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category?> GetByIdWithMoviesAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.MovieCategories)
                    .ThenInclude(mc => mc.Movie)
                        .ThenInclude(m => m.Images) // include poster
                .Include(c => c.MovieCategories)
                    .ThenInclude(mc => mc.Movie)
                        .ThenInclude(m => m.MovieCategories)
                            .ThenInclude(mc => mc.Category) // categories of each movie
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
