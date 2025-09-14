using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Data;              // contains MovieDbContext
using VoxTics.Models.Entities;   // Category, MovieCategory, etc.
using VoxTics.Models.ViewModels;
using VoxTics.Models.Enums;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    /// <summary>
    /// Repository for handling category queries for end-users (read-only).
    /// </summary>
    public class CategoriesRepository : BaseRepository<Category>, ICategoriesRepository
    {
        private readonly MovieDbContext _context;

        public CategoriesRepository(MovieDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Category>> GetActiveCategoriesAsync(
            CancellationToken cancellationToken = default) =>
            await _context.Categories
                .AsNoTracking()
                .Where(c => c.IsActive)
                .OrderBy(c => c.Name)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

        public async Task<IEnumerable<Category>> SearchCategoriesAsync(
            string searchTerm,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetActiveCategoriesAsync(cancellationToken).ConfigureAwait(false);

            searchTerm = searchTerm.Trim().ToLower();
            return await _context.Categories
                .AsNoTracking()
                .Where(c => c.IsActive && c.Name.ToLower().Contains(searchTerm))
                .OrderBy(c => c.Name)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }

}
