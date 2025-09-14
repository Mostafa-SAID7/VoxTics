using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Repositories.IRepositories
{

    public interface IMoviesRepository : IBaseRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetCurrentlyShowingAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<Movie>> GetUpcomingMoviesAsync(DateTime nowUtc, CancellationToken cancellationToken = default);

        Task<IEnumerable<Movie>> GetTopRatedMoviesAsync(int count, CancellationToken cancellationToken = default);

        Task<IEnumerable<Movie>> SearchMoviesAsync(string keyword, CancellationToken cancellationToken = default);

        Task<IEnumerable<Movie>> GetRecommendedMoviesAsync(
            string userId,
            CancellationToken cancellationToken = default);
    }
}
