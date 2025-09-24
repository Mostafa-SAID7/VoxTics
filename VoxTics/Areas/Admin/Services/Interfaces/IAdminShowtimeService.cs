using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Showtime;
using VoxTics.Models.Entities;

namespace VoxTics.Services.Interfaces
{

    public interface IAdminShowtimeService
    {
        Task<IEnumerable<ShowtimeViewModel>> GetPagedShowtimesAsync(
            string? searchTerm = null,
            int pageNumber = 1,
            int pageSize = 10,
            CancellationToken cancellationToken = default);

        Task<int> CountShowtimesAsync(string? searchTerm = null, CancellationToken cancellationToken = default);

        Task<ShowtimeDetailsViewModel?> GetShowtimeDetailsAsync(int id, CancellationToken cancellationToken = default);

        Task<bool> ShowtimeExistsAsync(int id, CancellationToken cancellationToken = default);

        Task AddShowtimeAsync(Showtime showtime, CancellationToken cancellationToken = default);

        Task UpdateShowtimeAsync(Showtime showtime, CancellationToken cancellationToken = default);

        Task RemoveShowtimeAsync(int id, CancellationToken cancellationToken = default);
        Task<Showtime?> GetShowtimeByIdAsync(int id, CancellationToken cancellationToken = default);

    }
}
