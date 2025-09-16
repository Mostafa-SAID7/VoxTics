using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.Entities;

namespace VoxTics.Services.Interfaces
{
    /// <summary>
    /// Admin service interface for managing showtimes.
    /// Handles CRUD, validation, and business logic.
    /// </summary>
    public interface IAdminShowtimeService
    {
        Task<List<string>> AddShowtimeAsync(Showtime showtime, CancellationToken cancellationToken = default);
        Task<List<string>> UpdateShowtimeAsync(Showtime showtime, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Showtime> Showtimes, int TotalCount)> GetPagedShowtimesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            CancellationToken cancellationToken = default);
        Task<Showtime?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> DeleteShowtimeAsync(int id, CancellationToken cancellationToken = default);
    }
}
