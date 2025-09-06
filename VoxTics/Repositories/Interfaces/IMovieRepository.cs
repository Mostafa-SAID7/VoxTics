using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Helpers;

namespace VoxTics.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<int> CountAsync();
    }

    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<PaginatedList<Movie>> GetAllAsync(
            string? searchTerm = null,
            int? categoryId = null,
            MovieStatus? status = null,
            int pageNumber = 1,
            int pageSize = 10,
            string sortBy = "Title",
            bool sortDescending = false);

        Task<Movie?> GetByTitleAsync(string title);
        Task<IEnumerable<Movie>> GetByStatusAsync(MovieStatus status);
        Task<IEnumerable<Movie>> GetByCategoryAsync(int categoryId);
        Task<IEnumerable<Movie>> GetUpcomingMoviesAsync();
        Task<IEnumerable<Movie>> GetNowShowingMoviesAsync();
        Task<IEnumerable<Movie>> GetFeaturedMoviesAsync(int count = 10);
        Task<bool> HasRelatedDataAsync(int movieId);
        Task<IEnumerable<Movie>> SearchMoviesAsync(string searchTerm);
        Task<bool> IsTitleUniqueAsync(string title, int? excludeId = null);
        Task<IEnumerable<Movie>> GetMoviesByCategoriesAsync(List<int> categoryIds);
        Task<Dictionary<MovieStatus, int>> GetMovieCountByStatusAsync();
        Task<IEnumerable<Movie>> GetRecentMoviesAsync(int count = 5);
        Task<decimal> GetAveragePriceAsync();
        Task<Movie?> GetMovieWithDetailsAsync(int id);
    }
}