using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Data;              // contains MovieDbContext
using VoxTics.Models.Entities;   // Category, MovieCategory, etc.
using VoxTics.Models.ViewModels;
using VoxTics.Models.Enums.Sorting;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    public class CategoriesRepository : BaseRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(MovieDbContext context) : base(context) { }

        public async Task<Category?> GetCategoryWithMoviesAsync(int categoryId)
        {
            return await _context.Categories
                //.Include(c => c.Movies)
                .FirstOrDefaultAsync(c => c.Id == categoryId);
        }
    }

}
