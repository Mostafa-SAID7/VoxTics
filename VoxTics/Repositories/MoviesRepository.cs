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

        public async Task<IEnumerable<Movie>> GetMoviesByCategoryAsync(int categoryId)
        {
            return await _context.Movies
                //.Where(m => m.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetUpcomingMoviesAsync(DateTime fromDate)
        {
            return await _context.Movies
                .Where(m => m.ReleaseDate >= fromDate)
                .OrderBy(m => m.ReleaseDate)
                .ToListAsync();
        }
    }

}

