using Microsoft.EntityFrameworkCore;
using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    /// <summary>
    /// EF Core repository for bookings.
    /// </summary>
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        private readonly MovieDbContext _context;

        public BookingRepository(MovieDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(
            string userId,
            CancellationToken cancellationToken = default)
        {
            return await _context.Bookings
                .Include(b => b.Showtime)
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.BookingDate)
                .ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Booking?> GetBookingDetailsAsync(
            int bookingId,
            string userId,
            CancellationToken cancellationToken = default)
        {
            return await _context.Bookings

                .Include(b => b.Showtime)
                .Include(b => b.BookingSeats)
                    .ThenInclude(bs => bs.Seat)
                .FirstOrDefaultAsync(
                    b => b.Id == bookingId && b.UserId == userId,
                    cancellationToken).ConfigureAwait(false);
        }

        public async Task<Booking?> GetBookingDetailsAsync(
            int bookingId,
            CancellationToken cancellationToken = default)
        {
            return await _context.Bookings

                .Include(b => b.Showtime)
                .Include(b => b.BookingSeats)
                    .ThenInclude(bs => bs.Seat)
                .FirstOrDefaultAsync(b => b.Id == bookingId, cancellationToken).ConfigureAwait(false);
        }
    }
}
