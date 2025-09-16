using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Data.UoW;
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

        public async Task<IEnumerable<Showtime>> GetUpcomingShowtimesAsync(int movieId, DateTime fromDate, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Showtimes
                .Query()
                .Include(s => s.Hall)
                .Include(s => s.Movie)
                .Where(s => s.MovieId == movieId
                            && s.StartTime >= fromDate
                            && s.Status == Models.Enums.ShowtimeStatus.Scheduled)
                .OrderBy(s => s.StartTime)
                .ToListAsyncSafe(cancellationToken);
        }

        public async Task<IEnumerable<Showtime>> GetAvailableShowtimesForCinemaAsync(int cinemaId, DateTime fromDate, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Showtimes
                .Query()
                .Include(s => s.Hall)
                .Include(s => s.Movie)
                .Where(s => s.CinemaId == cinemaId
                            && s.StartTime >= fromDate
                            && s.Status == Models.Enums.ShowtimeStatus.Scheduled)
                .OrderBy(s => s.StartTime)
                .ToListAsyncSafe(cancellationToken);
        }

        public async Task<Showtime?> GetShowtimeByIdAsync(int showtimeId, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Showtimes
                .Query()
                .Include(s => s.Hall)
                .Include(s => s.Movie)
                .FirstOrDefaultAsync(s => s.Id == showtimeId, cancellationToken);
        }

        public async Task<IEnumerable<Showtime>> GetShowtimesAsync(int? movieId = null, int? cinemaId = null, int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            IQueryable<Showtime> query = _unitOfWork.Showtimes
                .Query()
                .Include(s => s.Hall)
                .Include(s => s.Movie)
                .Where(s => s.Status == Models.Enums.ShowtimeStatus.Scheduled);

            if (movieId.HasValue)
                query = query.Where(s => s.MovieId == movieId.Value);

            if (cinemaId.HasValue)
                query = query.Where(s => s.CinemaId == cinemaId.Value);

            query = query.OrderBy(s => s.StartTime);

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> CountShowtimesAsync(int? movieId = null, int? cinemaId = null, CancellationToken cancellationToken = default)
        {
            IQueryable<Showtime> query = _unitOfWork.Showtimes
                .Query()
                .Where(s => s.Status == Models.Enums.ShowtimeStatus.Scheduled);

            if (movieId.HasValue)
                query = query.Where(s => s.MovieId == movieId.Value);

            if (cinemaId.HasValue)
                query = query.Where(s => s.CinemaId == cinemaId.Value);

            return await query.CountAsync(cancellationToken);
        }

        public async Task<int> GetAvailableSeatsAsync(int showtimeId, CancellationToken cancellationToken = default)
        {
            var showtime = await _unitOfWork.Showtimes.GetByIdAsync(showtimeId, cancellationToken);
            return showtime?.AvailableSeats ?? 0;
        }
    }
}
