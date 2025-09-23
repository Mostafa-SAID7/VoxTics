using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Helpers;

namespace VoxTics.Areas.Admin.Services.Interfaces
{
    public interface IAdminMovieService
    {
        // 🔹 Get paginated movies with optional search/sort
        Task<PaginatedList<MovieListItemViewModel>> GetPagedMoviesAsync(
            int pageIndex,
            int pageSize,
            string? search = null,
            string? sortColumn = null,
            bool sortDescending = false);

        // 🔹 Get movie details for viewing
        Task<MovieDetailViewModel?> GetMovieDetailsAsync(int id);

        // 🔹 Get movie for editing
        Task<MovieCreateEditViewModel?> GetByIdAsync(int id);

        // 🔹 Create a new movie
        Task<int> CreateMovieAsync(MovieCreateEditViewModel model);

        // 🔹 Update existing movie
        Task<bool> UpdateMovieAsync(MovieCreateEditViewModel model);

        // 🔹 Delete a movie by ID
        Task<bool> DeleteMovieAsync(int id);
    }
}
