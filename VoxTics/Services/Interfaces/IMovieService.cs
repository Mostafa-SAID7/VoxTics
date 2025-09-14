using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;

namespace VoxTics.Services.Interfaces
{
    /// <summary>
    /// Service for exposing movie-related functionality to the user-facing site.
    /// Focuses on search, filtering, featured movies, and details.
    /// </summary>
    public interface IMovieService
    {
        /// <summary>
        /// Gets a paginated list of currently active or upcoming movies with optional filters.
        /// </summary>
        Task<PaginatedList<Movie>> GetPagedMoviesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            MovieStatus? status = null,
            string? sortOrder = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves featured movies for banners or highlights.
        /// </summary>
        Task<IEnumerable<Movie>> GetFeaturedMoviesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets detailed information about a movie, including related entities.
        /// </summary>
        Task<Movie?> GetMovieDetailsAsync(int movieId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets movies filtered by category.
        /// </summary>
        Task<IEnumerable<Movie>> GetMoviesByCategoryAsync(
            int categoryId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns movies released within a given date range.
        /// </summary>
        Task<IEnumerable<Movie>> GetMoviesByReleaseDateRangeAsync(
            DateTime startDate,
            DateTime endDate,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches movies by title or description.
        /// </summary>
        Task<IEnumerable<Movie>> SearchMoviesAsync(
            string keyword,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns top-rated movies.
        /// </summary>
        Task<IEnumerable<Movie>> GetTopRatedMoviesAsync(
            int count,
            CancellationToken cancellationToken = default);
    }
}
