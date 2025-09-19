using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Data; // Assuming your DbContext is here
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels.Movie;
using VoxTics.Repositories;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Areas.Admin.Repositories
{
    public class AdminMoviesRepository : BaseRepository<Movie>, IAdminMoviesRepository
    {
        private readonly MovieDbContext _context;

        public AdminMoviesRepository(MovieDbContext context) : base(context)
        {
            _context = context;
        }

        // ✅ Get a movie with related data for editing or details
        public async Task<Movie?> GetMovieWithDetailsAsync(int id)
        {
            return await _context.Movies
                .Include(m => m.Category)
                .Include(m => m.MovieImages)
                .Include(m => m.Showtimes)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        // ✅ Get all movies with their categories for listing in Admin
        public async Task<IEnumerable<Movie>> GetAllWithCategoryAsync()
        {
            return await _context.Movies
                .Include(m => m.Category)
                .OrderByDescending(m => m.ReleaseDate)
                .ToListAsync();
        }

        // ✅ Check for slug uniqueness (exclude a specific Id on update)
        public async Task<bool> MovieExistsBySlugAsync(string slug, int? excludeId = null)
        {
            return await _context.Movies
                .AnyAsync(m => m.Slug == slug && (!excludeId.HasValue || m.Id != excludeId.Value));
        }
        public IQueryable<Movie> GetMoviesWithCategory()
        {
            return _context.Movies.Include(m => m.Category);
        }
    }
}
