using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Data;              // contains MovieDbContext
using VoxTics.Models.Entities;   // Category, MovieCategory, etc.
using VoxTics.Repositories.Interfaces;
using VoxTics.Models.ViewModels;        // BasePaginatedFilterVM

namespace VoxTics.Repositories.Implementations
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MovieDbContext context) : base(context)
        {
        }

        public async Task<Category?> GetBySlugAsync(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug)) return null;

            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Slug == slug);
        }

        public async Task<Category?> GetCategoryWithMoviesAsync(int categoryId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(c => c.Id == categoryId)
                .Include(c => c.MovieCategories!)        // assumes join entity MovieCategory exists
                    .ThenInclude(mc => mc.Movie)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> SearchAsync(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return await GetAllAsync();

            var lower = term.ToLower();
            return await _dbSet
                .AsNoTracking()
                .Where(c => EF.Functions.Like(c.Name.ToLower(), $"%{lower}%")
                         || EF.Functions.Like(c.Slug.ToLower(), $"%{lower}%")
                         || (c.Description != null && EF.Functions.Like(c.Description.ToLower(), $"%{lower}%")))
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Returns categories together with their movies count.
        /// Uses MovieCategories join table to compute counts (efficient).
        /// </summary>
        public async Task<IEnumerable<(Category category, int movieCount)>> GetAllWithMovieCountsAsync()
        {
            // If you have MovieCategory join set, use it for accurate counts
            var query = from c in _dbSet.AsNoTracking()
                        join mc in _context.Set<MovieCategory>() on c.Id equals mc.CategoryId into mcg
                        select new
                        {
                            Category = c,
                            MovieCount = mcg.Count()
                        };

            var list = await query.ToListAsync();

            return list.Select(x => (x.Category, x.MovieCount));
        }

        /// <summary>
        /// Safe paging: fetch IDs for the page first, then load includes to avoid duplication
        /// (useful when including collections like MovieCategories).
        /// </summary>
        public async Task<(IEnumerable<Category> categories, int totalCount)> GetPagedAsync(BasePaginatedFilterVM filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));
            if (filter.PageNumber <= 0) filter.PageNumber = 1;
            if (filter.PageSize <= 0) filter.PageSize = 10;

            var baseQuery = _dbSet.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                var s = filter.SearchTerm.ToLower();
                baseQuery = baseQuery.Where(c =>
                    c.Name.ToLower().Contains(s) ||
                    (c.Description != null && c.Description.ToLower().Contains(s)) ||
                    c.Slug.ToLower().Contains(s));
            }

            var totalCount = await baseQuery.CountAsync();

            baseQuery = filter.SortBy?.ToLower() switch
            {
                "name" => filter.SortOrder == Models.Enums.SortOrder.Desc ? baseQuery.OrderByDescending(c => c.Name) : baseQuery.OrderBy(c => c.Name),
                "createdat" => filter.SortOrder == Models.Enums.SortOrder.Desc ? baseQuery.OrderByDescending(c => c.CreatedAt) : baseQuery.OrderBy(c => c.CreatedAt),
                _ => baseQuery.OrderBy(c => c.Name)
            };

            // select page IDs first
            var ids = await baseQuery
                .Select(c => c.Id)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            // now fetch categories with includes
            var categories = await _dbSet
                .Where(c => ids.Contains(c.Id))
                .Include(c => c.MovieCategories!)
                    .ThenInclude(mc => mc.Movie)
                .AsNoTracking()
                .ToListAsync();

            // preserve original order
            var ordered = ids.Select(id => categories.First(c => c.Id == id)).ToList();

            return (ordered, totalCount);
        }

        public async Task<IEnumerable<(Category category, int movieCount)>> GetTopCategoriesByMoviesAsync(int count = 10)
        {
            // Group by join table for efficient aggregation
            var query = from mc in _context.Set<MovieCategory>()
                        group mc by mc.CategoryId into g
                        join c in _dbSet.AsNoTracking() on g.Key equals c.Id
                        orderby g.Count() descending
                        select new { Category = c, Count = g.Count() };

            var list = await query.Take(count).ToListAsync();

            return list.Select(x => (x.Category, x.Count));
        }
    }
}
