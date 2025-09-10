using VoxTics.Areas.Admin.ViewModels.Filter;
using VoxTics.Areas.Admin.ViewModels.Movie;
using MovieFilterVM = VoxTics.Areas.Admin.ViewModels.Filter.MovieFilterVM;

namespace VoxTics.Areas.Admin.Services.Interfaces
{
    public interface IMovieService
    {
        Task<PagedResultVM<MovieListItemViewModel>> GetPagedAsync(MovieFilterVM filter);
        Task<MovieDetailViewModel?> GetDetailsAsync(int id);
        Task<int> CreateAsync(MovieCreateEditViewModel vm);
        Task UpdateAsync(MovieCreateEditViewModel vm);
        Task DeleteAsync(int id);
    }
}
