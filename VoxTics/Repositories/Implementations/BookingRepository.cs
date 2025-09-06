using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public BookingRepository(MovieDbContext context) : base(context)
        {
        }

        // -------------------------
        // Booking Queries
        // -------------------------
        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId)
        {
            return await _dbSet
                .Where(b => b.UserId == userId)
                .Include(b => b.Showtime).ThenInclude(s => s.Hall).ThenInclude(h => h.Cinema)
                .Include(b => b.BookingSeats)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Booking?> GetBookingWithDetailsAsync(int bookingId)
        {
            return await _dbSet
                .Where(b => b.Id == bookingId)
                .Include(b => b.Showtime).ThenInclude(s => s.Hall).ThenInclude(h => h.Cinema)
                .Include(b => b.BookingSeats)
                .Include(b => b.User)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByStatusAsync(BookingStatus status)
        {
            return await _dbSet
                .Where(b => b.Status == status)
                .Include(b => b.Showtime).ThenInclude(s => s.Hall).ThenInclude(h => h.Cinema)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByShowtimeAsync(int showtimeId)
        {
            return await _dbSet
                .Where(b => b.ShowtimeId == showtimeId)
                .Include(b => b.User)
                .Include(b => b.BookingSeats)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByMovieAsync(int movieId)
        {
            return await _dbSet
                .Where(b => b.Showtime.MovieId == movieId)
                .Include(b => b.Showtime).ThenInclude(s => s.Hall).ThenInclude(h => h.Cinema)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByCinemaAsync(int cinemaId)
        {
            return await _dbSet
                .Where(b => b.Showtime.Hall.CinemaId == cinemaId)
                .Include(b => b.Showtime).ThenInclude(s => s.Hall)
                .Include(b => b.User)
                .AsNoTracking()
                .ToListAsync();
        }

        // -------------------------
        // Booking Seats
        // -------------------------
        public async Task<IEnumerable<BookingSeat>> GetBookingSeatsAsync(int bookingId)
        {
            return await _context.BookingSeats
                .Where(bs => bs.BookingId == bookingId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Seat>> GetBookedSeatsAsync(int showtimeId)
        {
            return await _context.BookingSeats
                .Where(bs => bs.Booking.ShowtimeId == showtimeId)
                .Select(bs => bs.Seat)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Seat>> GetAvailableSeatsAsync(int showtimeId)
        {
            var bookedSeatIds = await _context.BookingSeats
                .Where(bs => bs.Booking.ShowtimeId == showtimeId)
                .Select(bs => bs.SeatId)
                .ToListAsync();

            return await _context.Seats
                .Where(s => !bookedSeatIds.Contains(s.Id))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> AreSeatsAvailableAsync(int showtimeId, IEnumerable<int> seatIds)
        {
            var bookedSeatIds = await _context.BookingSeats
                .Where(bs => bs.Booking.ShowtimeId == showtimeId)
                .Select(bs => bs.SeatId)
                .ToListAsync();

            return !seatIds.Any(id => bookedSeatIds.Contains(id));
        }

        // -------------------------
        // Date-based queries
        // -------------------------
        public async Task<IEnumerable<Booking>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(b => b.BookingDate >= startDate && b.BookingDate <= endDate)
                .Include(b => b.Showtime).ThenInclude(s => s.Hall)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetTodaysBookingsAsync()
        {
            var today = DateTime.UtcNow.Date;
            return await GetBookingsByDateRangeAsync(today, today.AddDays(1));
        }

        public async Task<IEnumerable<Booking>> GetUpcomingBookingsAsync(int userId)
        {
            var now = DateTime.UtcNow;
            return await _dbSet
                .Where(b => b.UserId == userId && b.Showtime.StartTime > now)
                .Include(b => b.Showtime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetPastBookingsAsync(int userId)
        {
            var now = DateTime.UtcNow;
            return await _dbSet
                .Where(b => b.UserId == userId && b.Showtime.StartTime <= now)
                .Include(b => b.Showtime)
                .AsNoTracking()
                .ToListAsync();
        }

        // -------------------------
        // Search and Filter
        // -------------------------
        public async Task<IEnumerable<Booking>> SearchBookingsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await _dbSet.AsNoTracking().ToListAsync();

            var lower = searchTerm.ToLower();
            return await _dbSet
                .Where(b => b.BookingNumber.ToLower().Contains(lower) ||
                            b.User.Email.ToLower().Contains(lower))
                .Include(b => b.Showtime)
                .Include(b => b.User)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<(IEnumerable<Booking> bookings, int totalCount)> GetPagedBookingsAsync(BasePaginatedFilterVM filter)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                var s = filter.SearchTerm.ToLower();
                query = query.Where(b => b.BookingNumber.ToLower().Contains(s) ||
                                         b.User.Email.ToLower().Contains(s));
            }

            var totalCount = await query.CountAsync();

            query = filter.SortBy?.ToLower() switch
            {
                "bookingdate" => filter.SortOrder == SortOrder.Desc ? query.OrderByDescending(b => b.BookingDate) : query.OrderBy(b => b.BookingDate),
                "finalamount" => filter.SortOrder == SortOrder.Desc ? query.OrderByDescending(b => b.FinalAmount) : query.OrderBy(b => b.FinalAmount),
                _ => query.OrderByDescending(b => b.BookingDate)
            };

            var bookings = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Include(b => b.Showtime).ThenInclude(s => s.Hall).ThenInclude(h => h.Cinema)
                .Include(b => b.User)
                .AsNoTracking()
                .ToListAsync();

            return (bookings, totalCount);
        }

        public async Task<(IEnumerable<Booking> bookings, int totalCount)> GetPagedUserBookingsAsync(int userId, BasePaginatedFilterVM filter)
        {
            var query = _dbSet.Where(b => b.UserId == userId);
            var totalCount = await query.CountAsync();

            query = filter.SortBy?.ToLower() switch
            {
                "bookingdate" => filter.SortOrder == SortOrder.Desc ? query.OrderByDescending(b => b.BookingDate) : query.OrderBy(b => b.BookingDate),
                _ => query.OrderByDescending(b => b.BookingDate)
            };

            var bookings = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Include(b => b.Showtime).ThenInclude(s => s.Hall).ThenInclude(h => h.Cinema)
                .Include(b => b.User)
                .AsNoTracking()
                .ToListAsync();

            return (bookings, totalCount);
        }

        // -------------------------
        // Statistics
        // -------------------------
        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _dbSet.SumAsync(b => b.FinalAmount);
        }

        public async Task<decimal> GetRevenueByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(b => b.BookingDate >= startDate && b.BookingDate <= endDate)
                .SumAsync(b => b.FinalAmount);
        }

        public async Task<decimal> GetRevenueByMovieAsync(int movieId)
        {
            return await _dbSet
                .Where(b => b.Showtime.MovieId == movieId)
                .SumAsync(b => b.FinalAmount);
        }

        public async Task<decimal> GetRevenueByCinemaAsync(int cinemaId)
        {
            return await _dbSet
                .Where(b => b.Showtime.Hall.CinemaId == cinemaId)
                .SumAsync(b => b.FinalAmount);
        }

        public async Task<int> GetBookingCountByStatusAsync(BookingStatus status)
        {
            return await _dbSet.CountAsync(b => b.Status == status);
        }

        public async Task<int> GetTotalTicketsSoldAsync()
        {
            return await _dbSet.SumAsync(b => b.NumberOfTickets);
        }

        public async Task<Dictionary<string, int>> GetBookingStatusStatsAsync()
        {
            return await _dbSet
                .GroupBy(b => b.Status)
                .Select(g => new { Status = g.Key.ToString(), Count = g.Count() })
                .ToDictionaryAsync(x => x.Status, x => x.Count);
        }

        public async Task<Dictionary<string, decimal>> GetMonthlyRevenueStatsAsync(int year)
        {
            return await _dbSet
                .Where(b => b.BookingDate.Year == year)
                .GroupBy(b => b.BookingDate.Month)
                .Select(g => new { Month = g.Key, Revenue = g.Sum(b => b.FinalAmount) })
                .ToDictionaryAsync(x => x.Month.ToString(), x => x.Revenue);
        }

        public async Task<double> GetShowtimeOccupancyRateAsync(int showtimeId)
        {
            var showtime = await _context.Showtimes
                .Include(s => s.Hall).ThenInclude(h => h.Seats)
                .Include(s => s.Bookings).ThenInclude(b => b.BookingSeats)
                .FirstOrDefaultAsync(s => s.Id == showtimeId);

            if (showtime == null || showtime.Hall.Seats.Count == 0) return 0;

            var bookedSeats = showtime.Bookings.Sum(b => b.NumberOfTickets);
            return (double)bookedSeats / showtime.Hall.Seats.Count * 100;
        }

        public async Task<double> GetAverageOccupancyRateAsync()
        {
            var showtimes = await _context.Showtimes
                .Include(s => s.Hall).ThenInclude(h => h.Seats)
                .Include(s => s.Bookings)
                .ToListAsync();

            if (!showtimes.Any()) return 0;

            double totalSeats = showtimes.Sum(s => s.Hall.Seats.Count);
            double bookedSeats = showtimes.Sum(s => s.Bookings.Sum(b => b.NumberOfTickets));

            return totalSeats == 0 ? 0 : (bookedSeats / totalSeats) * 100;
        }

        public async Task<IEnumerable<(Movie movie, int bookingCount)>> GetTopMoviesByBookingsAsync(int count = 10)
        {
            var result = await _dbSet
                .GroupBy(b => b.Showtime.Movie)
                .Select(g => new { Movie = g.Key, BookingCount = g.Sum(b => b.NumberOfTickets) })
                .OrderByDescending(x => x.BookingCount)
                .Take(count)
                .ToListAsync(); // fetch from DB first

            // convert to tuple in-memory
            return result.Select(x => (x.Movie, x.BookingCount));
        }

        public async Task<IEnumerable<(Cinema cinema, decimal revenue)>> GetTopCinemasByRevenueAsync(int count = 5)
        {
            var result = await _dbSet
                .GroupBy(b => b.Showtime.Hall.Cinema)
                .Select(g => new { Cinema = g.Key, Revenue = g.Sum(b => b.FinalAmount) })
                .OrderByDescending(x => x.Revenue)
                .Take(count)
                .ToListAsync(); // fetch first

            return result.Select(x => (x.Cinema, x.Revenue));
        }

        // -------------------------
        // Booking Management
        // -------------------------
        public async Task<bool> CanCancelBookingAsync(int bookingId)
        {
            var booking = await _dbSet.FindAsync(bookingId);
            return booking != null && booking.CanBeCancelled;
        }

        public async Task<bool> CancelBookingAsync(int bookingId)
        {
            var booking = await _dbSet.FindAsync(bookingId);
            if (booking == null || !booking.CanBeCancelled) return false;

            booking.Status = BookingStatus.Cancelled;
            booking.CancellationDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ConfirmBookingAsync(int bookingId)
        {
            var booking = await _dbSet.FindAsync(bookingId);
            if (booking == null) return false;

            booking.Status = BookingStatus.Confirmed;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBookingStatusAsync(int bookingId, BookingStatus status)
        {
            var booking = await _dbSet.FindAsync(bookingId);
            if (booking == null) return false;

            booking.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }

        // -------------------------
        // Payment Management
        // -------------------------
        public async Task<IEnumerable<Booking>> GetPendingPaymentBookingsAsync()
        {
            return await _dbSet
                .Where(b => b.PaymentStatus == PaymentStatus.Pending)
                .Include(b => b.User)
                .Include(b => b.Showtime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetExpiredBookingsAsync()
        {
            var now = DateTime.UtcNow;
            return await _dbSet
                .Where(b => b.PaymentStatus == PaymentStatus.Pending && b.Showtime.StartTime < now)
                .Include(b => b.User)
                .Include(b => b.Showtime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> MarkPaymentCompletedAsync(int bookingId, string paymentReference)
        {
            var booking = await _dbSet.FindAsync(bookingId);
            if (booking == null) return false;

            booking.PaymentStatus = PaymentStatus.Completed;
            booking.TransactionId = paymentReference;
            booking.PaymentDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        // -------------------------
        // Validation
        // -------------------------
        public async Task<bool> IsBookingNumberUniqueAsync(string bookingNumber)
        {
            return !await _dbSet.AnyAsync(b => b.BookingNumber == bookingNumber);
        }

        public async Task<bool> CanUserBookAsync(int userId, int showtimeId)
        {
            return !await _dbSet.AnyAsync(b => b.UserId == userId && b.ShowtimeId == showtimeId && b.Status == BookingStatus.Confirmed);
        }

        public async Task<string> GenerateBookingNumberAsync()
        {
            string bookingNumber;
            do
            {
                bookingNumber = $"BK-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
            } while (!await IsBookingNumberUniqueAsync(bookingNumber));

            return bookingNumber;
        }

        // -------------------------
        // Admin
        // -------------------------
        public async Task<IEnumerable<Booking>> GetBookingsForAdminAsync()
        {
            return await _dbSet
                .Include(b => b.User)
                .Include(b => b.Showtime).ThenInclude(s => s.Hall).ThenInclude(h => h.Cinema)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<(IEnumerable<Booking> bookings, int totalCount)> GetPagedBookingsForAdminAsync(BasePaginatedFilterVM filter)
        {
            return await GetPagedBookingsAsync(filter);
        }

        public async Task<Dictionary<string, object>> GetBookingDashboardStatsAsync()
        {
            var totalRevenue = await GetTotalRevenueAsync();
            var totalBookings = await _dbSet.CountAsync();
            var confirmedBookings = await GetBookingCountByStatusAsync(BookingStatus.Confirmed);
            var pendingPayments = await _dbSet.CountAsync(b => b.PaymentStatus == PaymentStatus.Pending);

            return new Dictionary<string, object>
            {
                { "TotalRevenue", totalRevenue },
                { "TotalBookings", totalBookings },
                { "ConfirmedBookings", confirmedBookings },
                { "PendingPayments", pendingPayments }
            };
        }
    }
}
