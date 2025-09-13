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
        private readonly MovieDbContext _context;
        public CategoriesRepository(MovieDbContext context) : base(context) => _context = context;

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }
    }

}
