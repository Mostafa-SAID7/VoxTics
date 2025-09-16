using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.Entities;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Areas.Admin.Repositories.IRepositories
{
    /// <summary>
    /// Repository interface for admin-specific movie operations.
    /// Extends generic IBaseRepository for CRUD and adds admin-specific queries.
    /// </summary>
    public interface IAdminMoviesRepository : IBaseRepository<Movie>
    {
        #region Movie Queries

        /// <summary>
        /// Gets all movies including related categories, actors, and showtimes.
        /// </summary>
        Task<IEnumerable<Movie>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a movie by its ID including related entities.
        /// </summary>
        Task<Movie?> GetByIdWithDetailsAsync(int movieId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if a movie title already exists (case-insensitive).
        /// </summary>
        Task<bool> TitleExistsAsync(string title, int? excludeMovieId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns upcoming movies ordered by release date.
        /// </summary>
        Task<IEnumerable<Movie>> GetUpcomingMoviesAsync(int count = 10, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns featured movies.
        /// </summary>
        Task<IEnumerable<Movie>> GetFeaturedMoviesAsync(int count = 10, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns movies by category.
        /// </summary>
        Task<IEnumerable<Movie>> GetMoviesByCategoryAsync(int categoryId, CancellationToken cancellationToken = default);

        #endregion

        #region Admin Operations

        /// <summary>
        /// Updates movie status (Upcoming, NowShowing, Ended, etc.).
        /// </summary>
        Task UpdateStatusAsync(int movieId, Models.Enums.MovieStatus status, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the featured flag for a movie.
        /// </summary>
        Task SetFeaturedAsync(int movieId, bool isFeatured, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates movie images (poster or gallery) in bulk.
        /// </summary>
        Task UpdateImagesAsync(int movieId, IEnumerable<string> imageUrls, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a movie along with its related showtimes and images.
        /// </summary>
        Task DeleteMovieAsync(int movieId, CancellationToken cancellationToken = default);

        #endregion

        #region Search & Filtering

        /// <summary>
        /// Searches movies by title, director, or actor name.
        /// </summary>
        Task<IEnumerable<Movie>> SearchMoviesAsync(string query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Filters movies based on status, category, or release date range.
        /// </summary>
        Task<IEnumerable<Movie>> FilterMoviesAsync(
            Models.Enums.MovieStatus? status = null,
            int? categoryId = null,
            DateTime? releaseFrom = null,
            DateTime? releaseTo = null,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
