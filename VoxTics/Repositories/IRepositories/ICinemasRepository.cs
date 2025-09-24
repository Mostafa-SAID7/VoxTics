using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.Entities;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories.IRepositories
{
    public interface ICinemasRepository : IBaseRepository<Cinema>
    {
        /// <summary>
        /// Get all active cinemas
        /// </summary>
        Task<IEnumerable<Cinema>> GetActiveCinemasAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get paged cinemas with optional search and sorting
        /// </summary>
        Task<(IEnumerable<Cinema> Items, int TotalCount)> GetPagedCinemasAsync(
            int page,
            int pageSize,
            string? search = null,
            string? sort = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get cinema details including halls, showtimes, and social media links
        /// </summary>
        Task<Cinema?> GetCinemaDetailsAsync(int id, CancellationToken cancellationToken = default);
    }
}
