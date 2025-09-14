using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.Services.Interfaces
{
    /// <summary>
    /// Service for managing movies in the admin dashboard.
    /// Includes create, update, delete, and status management.
    /// </summary>
    public interface IAdminMoviesService
    {
        /// <summary>
        /// Gets a paginated list of movies with search and sorting for admin.
        /// </summary>
        Task<PaginatedList<Movie>> GetPagedMoviesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            MovieStatus? status = null,
            string? sortOrder = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new movie entry.
        /// </summary>
        Task<Movie> CreateMovieAsync(Movie movie, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing movie entry.
        /// </summary>
        Task<bool> UpdateMovieAsync(Movie movie, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a movie, ensuring no dependencies break (e.g., showtimes/bookings).
        /// </summary>
        Task<bool> DeleteMovieAsync(int movieId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Toggles the featured status of a movie.
        /// </summary>
        Task<bool> ToggleFeaturedAsync(int movieId, bool isFeatured, CancellationToken cancellationToken = default);

        /// <summary>
        /// Changes the status (Upcoming, NowShowing, Archived) of a movie.
        /// </summary>
        Task<bool> ChangeStatusAsync(int movieId, MovieStatus status, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a movie by its Id.
        /// </summary>
        Task<Movie?> GetMovieByIdAsync(int movieId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if a movie title already exists (optional exclude by ID).
        /// </summary>
        Task<bool> MovieTitleExistsAsync(string title, int? excludeId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates movie media assets like posters or trailers.
        /// </summary>
        Task<bool> UpdateMovieMediaAsync(
            int movieId,
            string? imageUrl = null,
            string? trailerUrl = null,
            string? trailerImageUrl = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Bulk import of movies (e.g., from CSV or external sources).
        /// </summary>
        Task<int> BulkImportMoviesAsync(IEnumerable<Movie> movies, CancellationToken cancellationToken = default);
    }
}
