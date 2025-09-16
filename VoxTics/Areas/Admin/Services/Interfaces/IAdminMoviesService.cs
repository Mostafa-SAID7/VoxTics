using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.Entities;

namespace VoxTics.Services.Interfaces
{
    /// <summary>
    /// Admin service interface for movie management.
    /// Handles CRUD, validation, and business logic.
    /// </summary>
    public interface IAdminMovieService
    {
        Task<List<string>> AddMovieAsync(Movie movie, CancellationToken cancellationToken = default);
        Task<List<string>> UpdateMovieAsync(Movie movie, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Movie> Movies, int TotalCount)> GetPagedMoviesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            CancellationToken cancellationToken = default);
        Task<Movie?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> DeleteMovieAsync(int id, CancellationToken cancellationToken = default);
    }
}
