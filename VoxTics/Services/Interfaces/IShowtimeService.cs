using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.Entities;

namespace VoxTics.Services.Interfaces
{
    public interface IShowtimeService
    {
        Task<IEnumerable<Showtime>> GetUpcomingShowtimesAsync(
            int movieId,
            DateTime fromDate,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<Showtime>> GetAvailableShowtimesForCinemaAsync(
            int cinemaId,
            DateTime fromDate,
            CancellationToken cancellationToken = default);

        Task<Showtime?> GetShowtimeByIdAsync(int showtimeId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Showtime>> GetShowtimesAsync(
    int? movieId = null,
    int? cinemaId = null,
    int page = 1,
    int pageSize = 10,
    CancellationToken cancellationToken = default);

        Task<int> CountShowtimesAsync(
            int? movieId = null,
            int? cinemaId = null,
            CancellationToken cancellationToken = default);
        Task<int> GetAvailableSeatsAsync(int showtimeId, CancellationToken cancellationToken = default);
    }
}
