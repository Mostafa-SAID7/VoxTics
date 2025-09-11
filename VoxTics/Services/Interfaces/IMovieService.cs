using VoxTics.Areas.Admin.ViewModels.Filter;
using VoxTics.Areas.Admin.ViewModels.Movie;
using MovieFilterVM = VoxTics.Areas.Admin.ViewModels.Filter.MovieFilterVM;

namespace VoxTics.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task<IEnumerable<Movie>> GetByCategoryAsync(int categoryId);
        Task<IEnumerable<Movie>> GetUpcomingAsync(DateTime fromDate);
        Task CreateAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(int id);
    }

}
