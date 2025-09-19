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
                .Include(b => b.User)
                .Include(b => b.Movie)
                //.ThenInclude(m => m.Cinema) // if Movie has a Cinema navigation
                .Include(b => b.BookingSeats)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(b =>
                    b.User.Name.Contains(search) ||
                    b.User.Email.Contains(search) ||
                    b.Movie.Title.Contains(search));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var bookings = await query
                .OrderByDescending(b => b.Id) // latest first
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return (bookings, totalCount);
        }

        public async Task<Booking?> GetBookingDetailsAsync(int bookingId, CancellationToken cancellationToken = default)
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Movie)
                //.ThenInclude(m => m.Cinema) // if exists
                .Include(b => b.BookingSeats)
                .FirstOrDefaultAsync(b => b.Id == bookingId, cancellationToken);
        }
    }
}
