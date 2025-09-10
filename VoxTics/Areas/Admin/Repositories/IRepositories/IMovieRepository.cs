using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels;

namespace VoxTics.Areas.Admin.Repositories.IRepositories
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        // Listing & details
        Task<IEnumerable<Movie>> GetMoviesByStatusAsync(MovieStatus status);
        Task<IEnumerable<Movie>> GetMoviesByCategoryAsync(int categoryId);
        Task<IEnumerable<Movie>> GetMoviesByCinemaAsync(int cinemaId);
        Task<Movie?> GetMovieWithDetailsAsync(int movieId);
        Task<bool> HasRelatedDataAsync(int movieId);

        Task<bool> IsMovieTitleUniqueAsync(string title, int? excludeId = null);

        Task<bool> IsTitleUniqueAsync(string title, int? excludeId = null);
        // Includes shortcuts

        Task<IEnumerable<Movie>> GetMoviesWithCategoriesAsync();
        Task<IEnumerable<Movie>> GetMoviesWithActorsAsync();
        Task<IEnumerable<Movie>> GetMoviesWithImagesAsync();

        // Featured / Popular / Latest / Upcoming
        Task<IEnumerable<Movie>> GetFeaturedMoviesAsync(int count = 6);
        Task<IEnumerable<Movie>> GetPopularMoviesAsync(int count = 10);
        Task<IEnumerable<Movie>> GetLatestMoviesAsync(int count = 10);
        Task<IEnumerable<Movie>> GetUpcomingMoviesAsync(int count = 10);

        // Search and filter
        Task<IEnumerable<Movie>> SearchMoviesAsync(string searchTerm);
        Task<IEnumerable<Movie>> GetFilteredMoviesAsync(MovieFilterVM filter);
        Task<(IEnumerable<Movie> movies, int totalCount)> GetPagedFilteredMoviesAsync(MovieFilterVM filter);

        // Statistics
        Task<int> GetMovieCountByStatusAsync(MovieStatus status);
        Task<decimal> GetAverageRatingAsync(int movieId);
        Task<int> GetTotalBookingsAsync(int movieId);

        // Images
        Task<IEnumerable<MovieImg>> GetMovieImagesAsync(int movieId);
        Task AddMovieImageAsync(MovieImg movieImage);
        Task RemoveMovieImageAsync(int movieImageId);

        // Categories
        Task<IEnumerable<Category>> GetMovieCategoriesAsync(int movieId);
        Task AddMovieCategoryAsync(int movieId, int categoryId);
        Task RemoveMovieCategoryAsync(int movieId, int categoryId);

        // Actors
        Task<IEnumerable<Actor>> GetMovieActorsAsync(int movieId);
        Task AddMovieActorAsync(int movieId, int actorId);
        Task RemoveMovieActorAsync(int movieId, int actorId);

        // Admin
        Task<IEnumerable<Movie>> GetMoviesForAdminAsync();
        Task<(IEnumerable<Movie> movies, int totalCount)> GetPagedMoviesForAdminAsync(BasePaginatedFilterVM filter);

        // Validation
        Task<bool> HasActiveShowtimesAsync(int movieId);
        Task<bool> CanDeleteMovieAsync(int movieId);
        
    }
}
