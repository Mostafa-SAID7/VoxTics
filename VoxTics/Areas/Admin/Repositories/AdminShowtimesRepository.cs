using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Repositories;

namespace VoxTics.Areas.Admin.Repositories
{
    /// <summary>
    /// Admin-facing repository for advanced showtime management and analytics.
    /// </summary>
    public class AdminShowtimesRepository : BaseRepository<Showtime>, IAdminShowtimesRepository
    {
        private readonly MovieDbContext _context;

        public AdminShowtimesRepository(MovieDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Showtime> ScheduleShowtimeAsync(
            int movieId, int cinemaId, DateTime startTime, int totalSeats, decimal price,
            CancellationToken cancellationToken = default)
        {
            var showtime = new Showtime
            {
                MovieId = movieId,
                CinemaId = cinemaId,
                StartTime = startTime,
                TotalSeats = totalSeats,
                AvailableSeats = totalSeats,
                Price = price,
                IsCancelled = false
            };

            await _context.Showtimes.AddAsync(showtime, cancellationToken).ConfigureAwait(false);
            return showtime; // Commit handled by UnitOfWork
        }

        public async Task<bool> CancelShowtimeAsync(
            int showtimeId, string reason, CancellationToken cancellationToken = default)
        {
            var showtime = await _context.Showtimes
                .FirstOrDefaultAsync(s => s.Id == showtimeId, cancellationToken)
                .ConfigureAwait(false);

            if (showtime == null) return false;

            showtime.IsCancelled = true;
            showtime.CancellationReason = reason;
            _context.Showtimes.Update(showtime);
            return true;
        }

        public async Task<bool> UpdateShowtimeDetailsAsync(
            int showtimeId, DateTime? newStartTime = null, decimal? newPrice = null,
            int? updatedSeats = null, CancellationToken cancellationToken = default)
        {
            var showtime = await _context.Showtimes
                .FirstOrDefaultAsync(s => s.Id == showtimeId, cancellationToken)
                .ConfigureAwait(false);

            if (showtime == null) return false;

            if (newStartTime.HasValue) showtime.StartTime = newStartTime.Value;
            if (newPrice.HasValue) showtime.Price = newPrice.Value;
            if (updatedSeats.HasValue)
            {
                var seatDiff = updatedSeats.Value - showtime.TotalSeats;
                showtime.TotalSeats = updatedSeats.Value;
                showtime.AvailableSeats += seatDiff;
            }

            _context.Showtimes.Update(showtime);
            return true;
        }

        public async Task<(IEnumerable<Showtime> Showtimes, int TotalCount)> GetPagedShowtimesAsync(
            int pageIndex, int pageSize, string? searchTerm = null, int? movieId = null,
            int? cinemaId = null, DateTime? date = null, CancellationToken cancellationToken = default)
        {
            var query = _context.Showtimes
                .AsNoTracking()
                .Include(s => s.Movie)
                .Include(s => s.Cinema)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
                query = query.Where(s => s.Movie.Title.Contains(searchTerm) ||
                                         s.Cinema.Name.Contains(searchTerm));

            if (movieId.HasValue) query = query.Where(s => s.MovieId == movieId.Value);
            if (cinemaId.HasValue) query = query.Where(s => s.CinemaId == cinemaId.Value);
            if (date.HasValue) query = query.Where(s => s.StartTime.Date == date.Value.Date);

            var total = await query.CountAsync(cancellationToken).ConfigureAwait(false);
            var items = await query.OrderByDescending(s => s.StartTime)
                                   .Skip(pageIndex * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync(cancellationToken)
                                   .ConfigureAwait(false);

            return (items, total);
        }

        public async Task<(int SoldSeats, decimal Revenue)> GetShowtimeStatsAsync(
            int showtimeId, CancellationToken cancellationToken = default)
        {
            var bookings = await _context.Bookings
                .AsNoTracking()
                .Where(b => b.ShowtimeId == showtimeId)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            var soldSeats = bookings.Sum(b => b.BookingSeats);
            var revenue = bookings.Sum(b => b.TotalPrice);

            return (soldSeats, revenue);
        }

        public async Task<double> GetMovieOccupancyRateAsync(
            int movieId, CancellationToken cancellationToken = default)
        {
            var showtimes = await _context.Showtimes
                .AsNoTracking()
                .Where(s => s.MovieId == movieId && !s.IsDeleted)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            if (!showtimes.Any()) return 0;

            var totalSeats = showtimes.Sum(s => s.TotalSeats);
            var bookedSeats = totalSeats - showtimes.Sum(s => s.AvailableSeats);

            return totalSeats == 0 ? 0 : (double)bookedSeats / totalSeats * 100;
        }
    }
}
