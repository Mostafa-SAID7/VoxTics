using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Models.ViewModels.Cart;
using VoxTics.Models.ViewModels.Movie;

namespace VoxTics.Services.Interfaces
{
    public interface IMovieService
    {
        /// <summary>
        /// Gets all movies as MovieVM (list view) with Category name and main image URL.
        /// </summary>
        Task<List<MovieVM>> GetAllAsync();

        /// <summary>
        /// Gets detailed movie info including VariantImages, Category, Actors, and Showtimes.
        /// </summary>
        /// <param name="movieId">Movie Id</param>
        Task<MovieDetailsVM?> GetDetailsAsync(int movieId);
        Task<PaginatedList<MovieVM>> GetPagedAsync(
      int pageIndex,
      int pageSize,
      string? search = null,
      string? sortColumn = null,
      bool sortDescending = false);
        Task<List<SeatVM>> GetAvailableSeatsAsync(int showtimeId);


    }
}
