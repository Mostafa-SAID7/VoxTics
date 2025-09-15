using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    /// <summary>
    /// User-facing repository for managing showtimes.
    /// Handles browsing, availability checks, and seat reservations.
    /// </summary>
    public class ShowtimesRepository : BaseRepository<Showtime>, IShowtimesRepository
    {
        private readonly MovieDbContext _context;

        public ShowtimesRepository(MovieDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Showtime>> GetUpcomingShowtimesForMovieAsync(
            int movieId, DateTime fromDate, CancellationToken cancellationToken = default) =>
            await _context.Showtimes
                .AsNoTracking()
                .Include(s => s.Movie)
                .Include(s => s.Cinema)
                .Where(s => s.MovieId == movieId && s.StartTime >= fromDate && !s.IsCancelled)
                .OrderBy(s => s.StartTime)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

        public async Task<IEnumerable<Showtime>> GetShowtimesByCinemaAndDateAsync(
            int cinemaId, DateTime date, CancellationToken cancellationToken = default) =>
            await _context.Showtimes
                .AsNoTracking()
                .Include(s => s.Movie)
                .Where(s => s.CinemaId == cinemaId &&
                            s.StartTime.Date == date.Date &&
                            !s.IsCancelled)
                .OrderBy(s => s.StartTime)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

        public async Task<bool> IsShowtimeAvailableAsync(int showtimeId, CancellationToken cancellationToken = default)
        {
            var showtime = await _context.Showtimes
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == showtimeId, cancellationToken)
                .ConfigureAwait(false);

            return showtime != null &&
                   !showtime.IsCancelled &&
                   showtime.AvailableSeats > 0 &&
                   showtime.StartTime > DateTime.UtcNow;
        }

        public async Task<Showtime?> GetShowtimeDetailsAsync(int showtimeId, CancellationToken cancellationToken = default) =>
            await _context.Showtimes
                .AsNoTracking()
                .Include(s => s.Movie)
                .Include(s => s.Cinema)
                .FirstOrDefaultAsync(s => s.Id == showtimeId, cancellationToken)
                .ConfigureAwait(false);

        public async Task<bool> ReserveSeatAsync(int showtimeId, int numberOfSeats, CancellationToken cancellationToken = default)
        {
            if (numberOfSeats <= 0) return false;

            var showtime = await _context.Showtimes
                .FirstOrDefaultAsync(s => s.Id == showtimeId && !s.IsCancelled, cancellationToken)
                .ConfigureAwait(false);

            if (showtime == null) return false;

            // simple availability check
            if (showtime.AvailableSeats < numberOfSeats) return false;

            // decrement
            showtime.AvailableSeats -= numberOfSeats;

            try
            {
                // Let UnitOfWork/DbContext track changes; we mark Update to be explicit.
                _context.Showtimes.Update(showtime);
                return true; // Commit/save will be handled by caller (UnitOfWork.CommitAsync)
            }
            catch (DbUpdateConcurrencyException)
            {
                // concurrency conflict — someone else modified seats. Caller should retry or return failure.
                return false;
            }
        }

        public async Task<bool> ReleaseSeatsAsync(int showtimeId, int numberOfSeats, CancellationToken cancellationToken = default)
        {
            if (numberOfSeats <= 0) return false;

            var showtime = await _context.Showtimes
                .FirstOrDefaultAsync(s => s.Id == showtimeId, cancellationToken)
                .ConfigureAwait(false);

            if (showtime == null) return false;

            showtime.AvailableSeats += numberOfSeats;

            try
            {
                _context.Showtimes.Update(showtime);
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }
}
