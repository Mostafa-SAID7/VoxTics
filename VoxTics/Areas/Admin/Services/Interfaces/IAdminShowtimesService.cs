using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.Entities;

namespace VoxTics.Areas.Admin.Services.Interfaces
{
    public interface IAdminShowtimesService
    {
        Task<IEnumerable<Showtime>> GetPagedShowtimesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? sortOrder = null,
            CancellationToken cancellationToken = default);

        Task<Showtime?> GetShowtimeByIdAsync(int showtimeId, CancellationToken cancellationToken = default);

        Task<bool> CreateShowtimeAsync(Showtime showtime, CancellationToken cancellationToken = default);

        Task<bool> UpdateShowtimeAsync(Showtime showtime, CancellationToken cancellationToken = default);

        Task<bool> DeleteShowtimeAsync(int showtimeId, CancellationToken cancellationToken = default);

        Task<int> GetAvailableSeatsAsync(int showtimeId, CancellationToken cancellationToken = default);
    }
}
