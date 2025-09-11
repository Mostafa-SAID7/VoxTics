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
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieDbContext ctx) : base(ctx) { }

        public IQueryable<Movie> QueryWithIncludes(bool asNoTracking = true)
        {
            var query = _dbSet
                .Include(m => m.MovieImages)
                .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category);

            return asNoTracking ? query.AsNoTracking() : query;
        }

        public async Task<Movie?> GetByIdWithDetailsAsync(int id)
        {
            return await QueryWithIncludes()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        /// <summary>
        /// Builds query using MovieFilterVM and returns paginated list
        /// </summary>
        public async Task<PaginatedList<Movie>> GetPagedAsync(MovieFilterVM filter)
        {
            var query = QueryWithIncludes();

            // Id filter
            if (filter.Id.HasValue)
                query = query.Where(m => m.Id == filter.Id.Value);

            // Date range: use DatePropertyName or ReleaseDate
            if (filter.FromDate.HasValue)
            {
                if (!string.IsNullOrEmpty(filter.DatePropertyName) && filter.DatePropertyName != "ReleaseDate")
                {
                    // try dynamic property filtering (fallback to CreatedAt if exists)
                    var prop = typeof(Movie).GetProperty(filter.DatePropertyName);
                    if (prop != null && prop.PropertyType == typeof(DateTime))
                    {
                        var from = filter.FromDate.Value;
                        query = query.Where(m => EF.Property<DateTime>(m, filter.DatePropertyName) >= from);
                    }
                }
                else
                {
                    var from = filter.FromDate.Value;
                    query = query.Where(m => m.ReleaseDate >= from);
                }
            }

            if (filter.ToDate.HasValue)
            {
                if (!string.IsNullOrEmpty(filter.DatePropertyName) && filter.DatePropertyName != "ReleaseDate")
                {
                    var prop = typeof(Movie).GetProperty(filter.DatePropertyName);
                    if (prop != null && prop.PropertyType == typeof(DateTime))
                    {
                        var to = filter.ToDate.Value;
                        query = query.Where(m => EF.Property<DateTime>(m, filter.DatePropertyName) <= to);
                    }
                }
                else
                {
                    var to = filter.ToDate.Value;
                    query = query.Where(m => m.ReleaseDate <= to);
                }
            }

            // Search (use SearchHelper extension if you have it)
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                // Search in Title, Description and actor name and category name
                var searchTerm = filter.Search.Trim();
                query = query.Where(m =>
                    EF.Functions.Like(m.Title, $"%{searchTerm}%") ||
                    EF.Functions.Like(m.Description, $"%{searchTerm}%") ||
                    m.MovieActors.Any(ma => EF.Functions.Like(ma.Actor.FullName, $"%{searchTerm}%")) ||
                    m.MovieCategories.Any(mc => EF.Functions.Like(mc.Category.Name, $"%{searchTerm}%"))
                );
            }

            // MovieStatus filter (if you use a property like Status)
            if (filter.Status.HasValue)
            {
                var status = filter.Status.Value;
                // assumes Movie has Status property of type MovieStatus
                query = query.Where(m => m.Status == status);
            }

            // Rating filters
            if (filter.MinRating.HasValue)
                query = query.Where(m => m.Rating >= filter.MinRating.Value);
            if (filter.MaxRating.HasValue)
                query = query.Where(m => m.Rating <= filter.MaxRating.Value);

            // Release date specific range
            if (filter.ReleaseFrom.HasValue)
                query = query.Where(m => m.ReleaseDate >= filter.ReleaseFrom.Value);
            if (filter.ReleaseTo.HasValue)
                query = query.Where(m => m.ReleaseDate <= filter.ReleaseTo.Value);

            // Featured
            if (filter.IsFeatured.HasValue)
                query = query.Where(m => m.IsFeatured == filter.IsFeatured.Value);

            // Category filter
            if (filter.CategoryId.HasValue)
                query = query.Where(m => m.MovieCategories.Any(mc => mc.CategoryId == filter.CategoryId.Value));

            // Sorting
            query = ApplySorting(query, filter.SortBy, filter.SortOrder);

            // Pagination using your helper
            var pageIndex = Math.Max(1, filter.PageIndex);
            var pageSize = filter.PageSize <= 0 ? 10 : filter.PageSize;
            return await PaginatedList<Movie>.CreateAsync(query, pageIndex, pageSize);
        }

        private IQueryable<Movie> ApplySorting(IQueryable<Movie> query, MovieSortBy sortBy, Models.Enums.SortOrder sortOrder)
        {
            // Map enum to property expressions
            Expression<Func<Movie, object>>? keySelector = sortBy switch
            {
                MovieSortBy.Title => m => m.Title,
                MovieSortBy.ReleaseDate => m => m.ReleaseDate,
                MovieSortBy.Rating => m => m.Rating,
                MovieSortBy.Duration => m => m.Duration,
                _ => m => m.Title
            };

            if (sortOrder == SortOrder.Asc)
                return query.OrderBy(keySelector);
            else
                return query.OrderByDescending(keySelector);
        }
    } 
}

