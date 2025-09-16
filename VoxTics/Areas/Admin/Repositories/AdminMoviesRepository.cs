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

        #region Movie Queries

        public async Task<IEnumerable<Movie>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Movies
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                .Include(m => m.Showtimes)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Movie?> GetByIdWithDetailsAsync(int movieId, CancellationToken cancellationToken = default)
        {
            return await _context.Movies
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                .Include(m => m.Showtimes)
                .FirstOrDefaultAsync(m => m.Id == movieId, cancellationToken);
        }

        public async Task<bool> TitleExistsAsync(string title, int? excludeMovieId = null, CancellationToken cancellationToken = default)
        {
            return await _context.Movies
                .AnyAsync(m => m.Title.ToLower() == title.ToLower() &&
                               (!excludeMovieId.HasValue || m.Id != excludeMovieId.Value), cancellationToken);
        }

        public async Task<IEnumerable<Movie>> GetUpcomingMoviesAsync(int count = 10, CancellationToken cancellationToken = default)
        {
            return await _context.Movies
                .Where(m => m.Status == MovieStatus.Upcoming)
                .OrderBy(m => m.ReleaseDate)
                .Take(count)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Movie>> GetFeaturedMoviesAsync(int count = 10, CancellationToken cancellationToken = default)
        {
            return await _context.Movies
                .Where(m => m.IsFeatured)
                .OrderByDescending(m => m.ReleaseDate)
                .Take(count)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
        {
            return await _context.MovieCategories
                .Where(mc => mc.CategoryId == categoryId)
                .Select(mc => mc.Movie)
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        #endregion

        #region Admin Operations

        public async Task UpdateStatusAsync(int movieId, MovieStatus status, CancellationToken cancellationToken = default)
        {
            var movie = await _context.Movies.FindAsync(new object[] { movieId }, cancellationToken);
            if (movie != null)
            {
                movie.Status = status;
                _context.Movies.Update(movie);
            }
        }

        public async Task SetFeaturedAsync(int movieId, bool isFeatured, CancellationToken cancellationToken = default)
        {
            var movie = await _context.Movies.FindAsync(new object[] { movieId }, cancellationToken);
            if (movie != null)
            {
                movie.IsFeatured = isFeatured;
                _context.Movies.Update(movie);
            }
        }

        public async Task UpdateImagesAsync(int movieId, IEnumerable<string> imageUrls, CancellationToken cancellationToken = default)
        {
            var movie = await _context.Movies
                .Include(m => m.MovieImages)
                .FirstOrDefaultAsync(m => m.Id == movieId, cancellationToken).ConfigureAwait(false);

            if (movie != null)
            {
                // Remove existing images
                _context.MovieImages.RemoveRange(movie.MovieImages);

                // Add new images
                foreach (var url in imageUrls)
                {
                    movie.MovieImages.Add(new MovieImg { MovieId = movieId, ImageUrl = url });
                }
            }
        }

        public async Task DeleteMovieAsync(int movieId, CancellationToken cancellationToken = default)
        {
            var movie = await _context.Movies
                .Include(m => m.Showtimes)
                .Include(m => m.MovieImages)
                .FirstOrDefaultAsync(m => m.Id == movieId, cancellationToken).ConfigureAwait(false);

            if (movie != null)
            {
                // Remove related entities first
                _context.MovieImages.RemoveRange(movie.MovieImages);
                _context.Showtimes.RemoveRange(movie.Showtimes);

                // Remove the movie itself
                _context.Movies.Remove(movie);
            }
        }

        #endregion

        #region Search & Filtering

        public async Task<IEnumerable<Movie>> SearchMoviesAsync(string query, CancellationToken cancellationToken = default)
        {
            query = query.ToLower();
            return await _context.Movies
                .Where(m => m.Title.ToLower().Contains(query) ||
                            m.Director.ToLower().Contains(query) ||
                            m.MovieActors.Any(ma => ma.Actor.FullName.ToLower().Contains(query)))
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Movie>> FilterMoviesAsync(
            MovieStatus? status = null,
            int? categoryId = null,
            DateTime? releaseFrom = null,
            DateTime? releaseTo = null,
            CancellationToken cancellationToken = default)
        {
            var query = _context.Movies.AsQueryable();

            if (status.HasValue)
                query = query.Where(m => m.Status == status.Value);

            if (categoryId.HasValue)
                query = query.Where(m => m.MovieCategories.Any(mc => mc.CategoryId == categoryId.Value));

            if (releaseFrom.HasValue)
                query = query.Where(m => m.ReleaseDate >= releaseFrom.Value);

            if (releaseTo.HasValue)
                query = query.Where(m => m.ReleaseDate <= releaseTo.Value);

            return await query
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        #endregion
    }
}
