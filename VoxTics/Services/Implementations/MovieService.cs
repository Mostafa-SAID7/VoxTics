using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Data.UoW;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    /// <summary>
    /// Handles user-facing movie operations (search, featured, details, etc.).
    /// </summary>
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _uow;

        public MovieService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
        }

        public async Task<PaginatedList<Movie>> GetPagedMoviesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            MovieStatus? status = null,
            string? sortOrder = null,
            CancellationToken cancellationToken = default)
        {
            var query = _uow.Movies.Query();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(m => m.Title.Contains(searchTerm) || m.Description.Contains(searchTerm));
            }

            if (status.HasValue)
            {
                query = query.Where(m => m.Status == status.Value);
            }

            // Sorting
            query = sortOrder switch
            {
                "title_desc" => query.OrderByDescending(m => m.Title),
                "date" => query.OrderBy(m => m.ReleaseDate),
                "date_desc" => query.OrderByDescending(m => m.ReleaseDate),
                _ => query.OrderBy(m => m.Title)
            };

            return await query.ToPaginatedListAsync(pageIndex, pageSize, cancellationToken);
        }

        public async Task<IEnumerable<Movie>> GetFeaturedMoviesAsync(CancellationToken cancellationToken = default)
        {
            return await _uow.Movies.FindAsync(m => m.IsFeatured && m.Status == MovieStatus.NowShowing, cancellationToken);
        }

        public async Task<Movie?> GetMovieDetailsAsync(int movieId, CancellationToken cancellationToken = default)
        {
            return await _uow.Movies.GetByIdAsync(movieId, cancellationToken);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
        {
            var query = _uow.Movies.Query()
                                   .Where(m => m.MovieCategories.Any(mc => mc.CategoryId == categoryId));
            return await query.ToListAsyncSafe(cancellationToken);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByReleaseDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            return await _uow.Movies.FindAsync(m => m.ReleaseDate >= startDate && m.ReleaseDate <= endDate, cancellationToken);
        }

        public async Task<IEnumerable<Movie>> SearchMoviesAsync(string keyword, CancellationToken cancellationToken = default)
        {
            return await _uow.Movies.FindAsync(m => m.Title.Contains(keyword) || m.Description.Contains(keyword), cancellationToken);
        }

        public async Task<IEnumerable<Movie>> GetTopRatedMoviesAsync(int count, CancellationToken cancellationToken = default)
        {
            var query = _uow.Movies.Query().OrderByDescending(m => m.Rating).Take(count);
            return await query.ToListAsyncSafe(cancellationToken);
        }
    }
}
