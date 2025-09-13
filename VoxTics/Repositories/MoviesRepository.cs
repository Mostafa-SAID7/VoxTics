using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums.Sorting;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    public class MoviesRepository : BaseRepository<Movie>, IMoviesRepository
    {
        public MoviesRepository(MovieDbContext context) : base(context) { }

        public async Task<Movie?> GetByTitleAsync(string title)
        {
            return await _context.Movies
                .Include(m => m.MovieCategories)
                .ThenInclude(mc => mc.Category)
                .FirstOrDefaultAsync(m => m.Title.ToLower() == title.ToLower());
        }

        public async Task<IEnumerable<Movie>> GetWithCategoriesAsync()
        {
            return await _context.Movies
                .Include(m => m.MovieCategories)
                .ThenInclude(mc => mc.Category)
                .AsNoTracking()
                .ToListAsync();
        }
    }

}

