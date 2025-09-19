using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Models.Entities;

namespace VoxTics.Areas.Admin.Services.Interfaces
{
    /// <summary>
    /// Admin service interface for movie management.
    /// Handles CRUD, validation, and business logic.
    /// </summary>
    public interface IAdminMovieService
    {
        Task<PaginatedList<MovieListItemViewModel>> GetPagedMoviesAsync(
                    int pageIndex,
                    int pageSize,
                    string? search = null,
                    string? sortColumn = null,
                    bool sortDescending = false);

        Task<MovieDetailViewModel?> GetMovieDetailsAsync(int id);
        Task<int> AddMovieAsync(MovieCreateEditViewModel model);
        Task<MovieDetailViewModel?> GetByIdAsync(int id);
        Task<int> CreateMovieAsync(MovieCreateEditViewModel model);
        Task<bool> UpdateMovieAsync(MovieCreateEditViewModel model);
        Task<bool> DeleteMovieAsync(int id);
    }
}
