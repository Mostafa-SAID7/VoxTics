using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Repositories;

namespace VoxTics.Areas.Admin.Repositories
{
    /// <summary>
    /// Repository for admin-side booking management.
    /// Includes analytics, paging, revenue, and oversight operations.
    /// </summary>
    public class AdminBookingsRepository : BaseRepository<Booking>, IAdminBookingsRepository
    {
        private readonly MovieDbContext _context;

        public AdminBookingsRepository(MovieDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<(IEnumerable<Booking> Bookings, int TotalCount)> GetPagedBookingsAsync(
            int pageIndex,
            int pageSize,
            string? search = null,
            CancellationToken cancellationToken = default)
        {
            var query = _context.Bookings
                .AsNoTracking()
                .Include(b => b.Movie)
                .Include(b => b.Showtime)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(b =>
                    b.Movie.Title.Contains(search) ||
                    b.UserId.Contains(search));
            }

            var totalCount = await query.CountAsync(cancellationToken).ConfigureAwait(false);

            var bookings = await query
                .OrderByDescending(b => b.BookingDate)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return (bookings, totalCount);
        }

        public async Task<(int Total, int Today, decimal Revenue)> GetBookingStatsAsync(
            CancellationToken cancellationToken = default)
        {
            var today = DateTime.UtcNow.Date;
            var total = await _context.Bookings.CountAsync(cancellationToken).ConfigureAwait(false);
            var todayCount = await _context.Bookings
                .CountAsync(b => b.BookingDate.Date == today, cancellationToken)
                .ConfigureAwait(false);
            var revenue = await _context.Bookings
                .SumAsync(b => b.TotalPrice, cancellationToken)
                .ConfigureAwait(false);

            return (total, todayCount, revenue);
        }

        public async Task<bool> ForceCancelBookingAsync(
            int bookingId,
            CancellationToken cancellationToken = default)
        {
            var booking = await _context.Bookings
                .FindAsync(new object?[] { bookingId }, cancellationToken)
                .ConfigureAwait(false);

            if (booking == null) return false;

            _context.Bookings.Remove(booking);
            return true; // Commit handled by UnitOfWork
        }
    }
}
