using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Data.UoW;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class ShowtimeService : IShowtimeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShowtimeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<Showtime>> GetUpcomingShowtimesAsync(
            int movieId,
            DateTime fromDate,
            CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Showtimes
                .Query()
                .Where(s => s.MovieId == movieId && s.StartTime >= fromDate && s.Status == Models.Enums.ShowtimeStatus.Scheduled)
                .OrderBy(s => s.StartTime)
                .ToListAsyncSafe(cancellationToken);
        }

        public async Task<IEnumerable<Showtime>> GetAvailableShowtimesForCinemaAsync(
            int cinemaId,
            DateTime fromDate,
            CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Showtimes
                .Query()
                .Where(s => s.CinemaId == cinemaId && s.StartTime >= fromDate && s.Status == Models.Enums.ShowtimeStatus.Scheduled)
                .OrderBy(s => s.StartTime)
                .ToListAsyncSafe(cancellationToken);
        }

        public async Task<Showtime?> GetShowtimeByIdAsync(int showtimeId, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Showtimes.GetByIdAsync(showtimeId, cancellationToken);
        }

        public async Task<int> GetAvailableSeatsAsync(int showtimeId, CancellationToken cancellationToken = default)
        {
            var showtime = await _unitOfWork.Showtimes.GetByIdAsync(showtimeId, cancellationToken);
            return showtime?.AvailableSeats ?? 0;
        }
    }
}
