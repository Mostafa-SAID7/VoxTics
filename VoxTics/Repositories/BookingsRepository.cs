using Microsoft.Extensions.Logging;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    public class BookingsRepository : BaseRepository<Booking>, IBookingsRepository
    {
        private readonly MovieDbContext _context;
        private readonly ILogger<BookingsRepository>? _logger;

        public BookingsRepository(MovieDbContext context, ILogger<BookingsRepository>? logger = null)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(
            string userId,
            CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation("Fetching bookings for user {UserId}", userId);

            return await _context.Bookings
                .AsNoTracking()
                .Include(b => b.Showtime)
                .Include(b => b.Movie)
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.BookingDate)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Booking>> GetUpcomingUserBookingsAsync(
            string userId,
            DateTime nowUtc,
            CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation("Fetching upcoming bookings for {UserId}", userId);

            return await _context.Bookings
                .AsNoTracking()
                .Include(b => b.Showtime)
                .Where(b => b.UserId == userId && b.Showtime.StartTime > nowUtc)
                .OrderBy(b => b.Showtime.StartTime)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<bool> CancelUserBookingAsync(
            int bookingId,
            string userId,
            CancellationToken cancellationToken = default)
        {
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.Id == bookingId && b.UserId == userId, cancellationToken)
                .ConfigureAwait(false);

            if (booking == null) return false;

            _context.Bookings.Remove(booking);
            _logger?.LogWarning("Booking {BookingId} for user {UserId} was cancelled", bookingId, userId);

            return true; // الحفظ يتم في UnitOfWork
        }

        // TODO: أكمل هذه الطرق عند الحاجة
        public Task<IEnumerable<Booking>> GetBookingsByUserAsync(string userId, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public Task<IEnumerable<Booking>> GetBookingsByShowtimeAsync(int showtimeId, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public Task<bool> IsSeatBookedAsync(int showtimeId, string seatNumber, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public Task<IEnumerable<Booking>> GetUpcomingBookingsForUserAsync(string userId, DateTime currentDate, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public Task<(IEnumerable<Booking> Bookings, int TotalCount)> GetPagedBookingsAsync(int pageIndex, int pageSize, string? searchTerm = null, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public Task<(int TotalBookings, int TodayBookings, int WeeklyBookings)> GetBookingSummaryAsync(CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public Task<bool> CancelBookingAsync(int bookingId, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public Task<bool> MarkAsCheckedInAsync(int bookingId, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();
    }
}
