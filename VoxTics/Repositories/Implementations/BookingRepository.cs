using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Repositories.Implementations
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        private readonly MovieDbContext _context;

        public BookingRepository(MovieDbContext context) : base(context)
        {
            _context = context;
        }

        // =============================
        // Booking-specific queries
        // =============================

        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId) =>
            await _context.Bookings
                .Include(b => b.Showtime).ThenInclude(s => s.Movie)
                .Include(b => b.BookingSeats).ThenInclude(bs => bs.Seat)
                .Where(b => b.UserId == userId)
                .ToListAsync();

        public async Task<Booking?> GetBookingWithDetailsAsync(int bookingId) =>
            await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Showtime).ThenInclude(s => s.Cinema)
                .Include(b => b.BookingSeats).ThenInclude(bs => bs.Seat)
                .FirstOrDefaultAsync(b => b.Id == bookingId);

        public async Task<IEnumerable<Booking>> GetBookingsByStatusAsync(BookingStatus status) =>
            await _context.Bookings
                .Where(b => b.Status == status)
                .ToListAsync();

        public async Task<IEnumerable<Booking>> GetBookingsByShowtimeAsync(int showtimeId) =>
            await _context.Bookings
                .Where(b => b.ShowtimeId == showtimeId)
                .ToListAsync();

        public async Task<IEnumerable<Booking>> GetBookingsByMovieAsync(int movieId) =>
            await _context.Bookings
                .Include(b => b.Showtime)
                .Where(b => b.Showtime.MovieId == movieId)
                .ToListAsync();

        public async Task<IEnumerable<Booking>> GetBookingsByCinemaAsync(int cinemaId) =>
            await _context.Bookings
                .Include(b => b.Showtime)
                .Where(b => b.Showtime.CinemaId == cinemaId)
                .ToListAsync();

        // =============================
        // Booking Seats
        // =============================

        public async Task<IEnumerable<BookingSeat>> GetBookingSeatsAsync(int bookingId) =>
            await _context.BookingSeats
                .Include(bs => bs.Seat)
                .Where(bs => bs.BookingId == bookingId)
                .ToListAsync();

        public async Task<IEnumerable<Seat>> GetBookedSeatsAsync(int showtimeId) =>
            await _context.BookingSeats
                .Where(bs => bs.Booking.ShowtimeId == showtimeId)
                .Select(bs => bs.Seat)
                .ToListAsync();

        public async Task<IEnumerable<Seat>> GetAvailableSeatsAsync(int showtimeId)
        {
            var booked = await GetBookedSeatsAsync(showtimeId);
            return await _context.Seats
                .Where(s => s.Hall.Showtimes.Any(st => st.Id == showtimeId) && !booked.Contains(s))
                .ToListAsync();
        }

        public async Task<bool> AreSeatsAvailableAsync(int showtimeId, IEnumerable<int> seatIds)
        {
            var bookedIds = await _context.BookingSeats
                .Where(bs => bs.Booking.ShowtimeId == showtimeId)
                .Select(bs => bs.SeatId)
                .ToListAsync();

            return !seatIds.Any(id => bookedIds.Contains(id));
        }

        // =============================
        // Date-based queries
        // =============================

        public async Task<IEnumerable<Booking>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate) =>
            await _context.Bookings
                .Where(b => b.CreatedAt >= startDate && b.CreatedAt <= endDate)
                .ToListAsync();

        public async Task<IEnumerable<Booking>> GetTodaysBookingsAsync()
        {
            var today = DateTime.UtcNow.Date;
            return await _context.Bookings
                .Where(b => b.CreatedAt.Date == today)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetUpcomingBookingsAsync(int userId) =>
            await _context.Bookings
                .Include(b => b.Showtime)
                .Where(b => b.UserId == userId && b.Showtime.StartTime > DateTime.UtcNow)
                .ToListAsync();

        public async Task<IEnumerable<Booking>> GetPastBookingsAsync(int userId) =>
            await _context.Bookings
                .Include(b => b.Showtime)
                .Where(b => b.UserId == userId && b.Showtime.StartTime <= DateTime.UtcNow)
                .ToListAsync();

        // =============================
        // Search and Filter
        // =============================

        public async Task<IEnumerable<Booking>> SearchBookingsAsync(string searchTerm) =>
            await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Showtime).ThenInclude(s => s.Movie)
                .Where(b =>
                    b.BookingNumber.Contains(searchTerm) ||
                    b.User.Email.Contains(searchTerm) ||
                    b.Showtime.Movie.Title.Contains(searchTerm))
                .ToListAsync();

        public async Task<(IEnumerable<Booking>, int)> GetPagedBookingsAsync(BasePaginatedFilterVM filter)
        {
            var query = _context.Bookings.AsQueryable();

            if (!string.IsNullOrEmpty(filter.SearchTerm))
                query = query.Where(b => b.BookingNumber.Contains(filter.SearchTerm));

            var total = await query.CountAsync();
            var data = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return (data, total);
        }

        public async Task<(IEnumerable<Booking>, int)> GetPagedUserBookingsAsync(int userId, BasePaginatedFilterVM filter)
        {
            var query = _context.Bookings.Where(b => b.UserId == userId);

            if (!string.IsNullOrEmpty(filter.SearchTerm))
                query = query.Where(b => b.BookingNumber.Contains(filter.SearchTerm));

            var total = await query.CountAsync();
            var data = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return (data, total);
        }

        // =============================
        // Other methods (Statistics, Analytics, Payment, Admin)
        // =============================
        // 👉 You can scaffold these in the same EF Core style:
        //   - _context.Bookings.Where(...)
        //   - GroupBy / Select
        //   - SumAsync, CountAsync, AverageAsync
        //   - Returning tuples (movie, count), (cinema, revenue)

        // Example:
        public async Task<decimal> GetTotalRevenueAsync() =>
            await _context.Bookings.SumAsync(b => b.TotalPrice);

        // TODO: implement the rest following this structure
    }
}
