using Microsoft.EntityFrameworkCore;
using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Repositories.Implementations
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MovieDbContext context) : base(context)
        {
        }

        public async Task<Category?> GetByIdWithMoviesAsync(int id)
        {
            return await _dbSet
                .Include(c => c.MovieCategories)
                    .ThenInclude(mc => mc.Movie)
                        .ThenInclude(m => m.Images)
                .Include(c => c.MovieCategories)
                    .ThenInclude(mc => mc.Movie)
                        .ThenInclude(m => m.MovieCategories)
                            .ThenInclude(mc => mc.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
