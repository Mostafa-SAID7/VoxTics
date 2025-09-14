using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Services.Interfaces;
using VoxTics.Data.UoW;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.Services.Implementations
{
    /// <summary>
    /// Handles admin-level movie management (CRUD, bulk import, status toggling).
    /// </summary>
    public class AdminMoviesService : IAdminMoviesService
    {
        private readonly IUnitOfWork _uow;

        public AdminMoviesService(IUnitOfWork uow)
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

            query = sortOrder switch
            {
                "price" => query.OrderBy(m => m.Price),
                "price_desc" => query.OrderByDescending(m => m.Price),
                "rating_desc" => query.OrderByDescending(m => m.Rating),
                "date_desc" => query.OrderByDescending(m => m.ReleaseDate),
                _ => query.OrderBy(m => m.Title)
            };

            return await query.ToPaginatedListAsync(pageIndex, pageSize, cancellationToken);
        }

        public async Task<Movie> CreateMovieAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            if (!ValidationHelpers.IsValidRating((double)movie.Rating))
                throw new ArgumentException("Invalid rating value.");

            await _uow.Movies.AddAsync(movie, cancellationToken);
            await _uow.CommitAsync(cancellationToken);
            return movie;
        }

        public async Task<bool> UpdateMovieAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            await _uow.Movies.UpdateAsync(movie, cancellationToken);
            await _uow.CommitAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteMovieAsync(int movieId, CancellationToken cancellationToken = default)
        {
            var movie = await _uow.Movies.GetByIdAsync(movieId, cancellationToken);
            if (movie == null) return false;

            await _uow.Movies.RemoveAsync(movie, cancellationToken);
            await _uow.CommitAsync(cancellationToken);
            return true;
        }

        public async Task<bool> ToggleFeaturedAsync(int movieId, bool isFeatured, CancellationToken cancellationToken = default)
        {
            var movie = await _uow.Movies.GetByIdAsync(movieId, cancellationToken);
            if (movie == null) return false;

            movie.IsFeatured = isFeatured;
            await _uow.Movies.UpdateAsync(movie, cancellationToken);
            await _uow.CommitAsync(cancellationToken);
            return true;
        }

        public async Task<bool> ChangeStatusAsync(int movieId, MovieStatus status, CancellationToken cancellationToken = default)
        {
            var movie = await _uow.Movies.GetByIdAsync(movieId, cancellationToken);
            if (movie == null) return false;

            movie.Status = status;
            await _uow.Movies.UpdateAsync(movie, cancellationToken);
            await _uow.CommitAsync(cancellationToken);
            return true;
        }

        public async Task<Movie?> GetMovieByIdAsync(int movieId, CancellationToken cancellationToken = default)
        {
            return await _uow.Movies.GetByIdAsync(movieId, cancellationToken);
        }

        public async Task<bool> MovieTitleExistsAsync(string title, int? excludeId = null, CancellationToken cancellationToken = default)
        {
            var movies = await _uow.Movies.FindAsync(m => m.Title == title, cancellationToken);
            return excludeId.HasValue
                ? movies.Any(m => m.Id != excludeId.Value)
                : movies.Any();
        }

        public async Task<bool> UpdateMovieMediaAsync(
            int movieId,
            string? imageUrl = null,
            string? trailerUrl = null,
            string? trailerImageUrl = null,
            CancellationToken cancellationToken = default)
        {
            var movie = await _uow.Movies.GetByIdAsync(movieId, cancellationToken);
            if (movie == null) return false;

            if (!string.IsNullOrWhiteSpace(imageUrl))
                movie.ImageUrl = imageUrl;
            if (!string.IsNullOrWhiteSpace(trailerUrl))
                movie.TrailerUrl = trailerUrl;
            if (!string.IsNullOrWhiteSpace(trailerImageUrl))
                movie.TrailerImageUrl = trailerImageUrl;

            await _uow.Movies.UpdateAsync(movie, cancellationToken);
            await _uow.CommitAsync(cancellationToken);
            return true;
        }

        public async Task<int> BulkImportMoviesAsync(IEnumerable<Movie> movies, CancellationToken cancellationToken = default)
        {
            foreach (var movie in movies)
            {
                if (!ValidationHelpers.IsValidRating((double)movie.Rating))
                    throw new ArgumentException($"Invalid rating for movie: {movie.Title}");

                await _uow.Movies.AddAsync(movie, cancellationToken);
            }
            return await _uow.CommitAsync(cancellationToken);
        }
    }
}
