using VoxTics.Areas.Admin.ViewModels.Filter;
using VoxTics.Areas.Admin.ViewModels.Movie;
using MovieFilterVM = VoxTics.Areas.Admin.ViewModels.Filter.MoviesFilterVM;

namespace VoxTics.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task<Movie?> GetByTitleAsync(string title);
        Task<IEnumerable<Movie>> GetWithCategoriesAsync();
        Task CreateAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(int id);
    }

}
