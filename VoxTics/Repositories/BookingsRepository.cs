using Microsoft.EntityFrameworkCore;
using VoxTics.Data;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels.Booking;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    /// <summary>
    /// Concrete EF Core repository for managing cinema bookings.
    /// Implements validation, transactional booking creation, analytics, and status handling.
    /// </summary>
    public class BookingsRepository : BaseRepository<Booking>, IBookingsRepository
    {
        private readonly MovieDbContext _context;

        public BookingsRepository(MovieDbContext context) : base(context)
        {
            _context = context;
        }

        #region Booking Creation & Validation

        public async Task<bool> AreSeatsAvailableAsync(int showtimeId, IEnumerable<int> seatIds, CancellationToken cancellationToken = default)
        {
            return !await _context.BookingSeats
                .AnyAsync(bs => bs.ShowtimeId == showtimeId && seatIds.Contains(bs.SeatId), cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<decimal> CalculateTotalPriceAsync(int showtimeId, int numberOfTickets, string? couponCode = null, CancellationToken cancellationToken = default)
        {
            var showtime = await _context.Showtimes
                .FirstOrDefaultAsync(s => s.Id == showtimeId, cancellationToken)
                .ConfigureAwait(false);

            if (showtime == null)
                throw new KeyNotFoundException("Showtime not found.");

            var basePrice = showtime.PricePerSeat * numberOfTickets;
            decimal discount = 0;

            if (!string.IsNullOrEmpty(couponCode))
            {
                //var coupon = await _context.Coupons
                //    .FirstOrDefaultAsync(c => c.Code == couponCode && c.ExpiryDate >= DateTime.UtcNow, cancellationToken)
                //    .ConfigureAwait(false);
                //if (coupon != null)
                //    discount = basePrice * (coupon.DiscountPercentage / 100m);
            }

            return basePrice - discount;
        }

        public async Task<BookingDetailsVM> CreateBookingAsync(BookingCreateVM model, string userId, string? couponCode = null, CancellationToken cancellationToken = default)
        {
            if (!await AreSeatsAvailableAsync(model.ShowtimeId, model.SelectedSeatIds, cancellationToken))
                throw new InvalidOperationException("Some selected seats are already booked.");

            var showtime = await _context.Showtimes
                .Include(s => s.Movie)
                .Include(s => s.CinemaHall)
                .FirstOrDefaultAsync(s => s.Id == model.ShowtimeId, cancellationToken)
                .ConfigureAwait(false);

            if (showtime == null)
                throw new KeyNotFoundException("Showtime not found.");

            var totalAmount = await CalculateTotalPriceAsync(model.ShowtimeId, model.SelectedSeatIds.Count, couponCode, cancellationToken);

            var booking = new Booking
            {
                UserId = userId,
                ShowtimeId = model.ShowtimeId,
                NumberOfTickets = model.SelectedSeatIds.Count,
                TotalAmount = totalAmount,
                Status = BookingStatus.Confirmed,
                PaymentStatus = PaymentStatus.Pending,
                BookingDate = DateTime.UtcNow
            };

            await _context.Bookings.AddAsync(booking, cancellationToken);

            foreach (var seatId in model.SelectedSeatIds)
            {
                _context.BookingSeats.Add(new BookingSeat
                {
                    Booking = booking,
                    ShowtimeId = model.ShowtimeId,
                    SeatId = seatId
                });
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new BookingDetailsVM
            {
                BookingReference = booking.BookingReference,
                MovieTitle = showtime.Movie.Title,

                ShowTime = showtime.StartTime,
                BookingDate = booking.BookingDate,
                NumberOfTickets = booking.NumberOfTickets,
                SeatNumbers = await GetBookingSeatsAsync(booking.BookingReference, cancellationToken).ConfigureAwait(false),
                TotalAmount = booking.TotalAmount,
                FinalAmount = booking.TotalAmount,
                Status = booking.Status,
                PaymentStatus = booking.PaymentStatus
            };
        }

        #endregion

        #region Retrieval

        public async Task<PaginatedList<BookingSummaryVM>> GetUserBookingsAsync(string userId, int pageIndex, int pageSize, string? search = null, string? sortColumn = "ShowTime", bool sortDescending = false, CancellationToken cancellationToken = default)
        {
            var query = _context.Bookings
                .Include(b => b.Showtime).ThenInclude(s => s.Movie)
                .Include(b => b.Showtime.CinemaHall)
                .Where(b => b.UserId == userId);

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(b => b.Showtime.Movie.Title.Contains(search) || b.BookingReference.Contains(search));

            var vmQuery = query.Select(b => new BookingSummaryVM
            {
                BookingReference = b.BookingReference,
                MovieTitle = b.Showtime.Movie.Title,

                ShowTime = b.Showtime.StartTime,
                NumberOfTickets = b.NumberOfTickets,
                TotalAmount = b.TotalAmount,
                DiscountAmount = 0,
                FinalAmount = b.TotalAmount,
                PaymentMethod = b.PaymentMethod,
                Status = b.Status.ToString(),
                CanBeCancelled = b.Showtime.StartTime > DateTime.UtcNow,
                SavingsAmount = 0,
                SeatNumbers = new List<string>()
            });

            return await vmQuery.ToPaginatedListAsync(pageIndex, pageSize, cancellationToken);
        }

        public async Task<BookingDetailsVM?> GetBookingDetailsAsync(string bookingReference, CancellationToken cancellationToken = default)
        {
            var booking = await _context.Bookings
                .Include(b => b.Showtime).ThenInclude(s => s.Movie)
                .Include(b => b.Showtime.CinemaHall)
                .FirstOrDefaultAsync(b => b.BookingReference == bookingReference, cancellationToken).ConfigureAwait(false);

            if (booking == null) return null;

            return new BookingDetailsVM
            {
                BookingReference = booking.BookingReference,
                MovieTitle = booking.Showtime.Movie.Title,
    
                ShowTime = booking.Showtime.StartTime,
                BookingDate = booking.BookingDate,
                NumberOfTickets = booking.NumberOfTickets,
                SeatNumbers = await GetBookingSeatsAsync(booking.BookingReference, cancellationToken).ConfigureAwait(false),
                TotalAmount = booking.TotalAmount,
                FinalAmount = booking.TotalAmount,
                Status = booking.Status,
                PaymentStatus = booking.PaymentStatus,
                PaymentMethod = booking.PaymentMethod
            };
        }

        public async Task<List<BookingSummaryVM>> GetUpcomingBookingsAsync(int count = 10, CancellationToken cancellationToken = default)
        {
            return await _context.Bookings
                .Include(b => b.Showtime.Movie)
                .Include(b => b.Showtime.CinemaHall)
                .Where(b => b.Showtime.StartTime > DateTime.UtcNow)
                .OrderBy(b => b.Showtime.StartTime)
                .Take(count)
                .Select(static b => new BookingSummaryVM
                {
                    BookingReference = b.BookingReference,
                    MovieTitle = b.Showtime.Movie.Title,

                    ShowTime = b.Showtime.StartTime,
                    NumberOfTickets = b.NumberOfTickets,
                    TotalAmount = b.TotalAmount,
                    FinalAmount = b.TotalAmount,
                    PaymentMethod = b.PaymentMethod,
                    Status = b.Status.ToString(),
                    CanBeCancelled = b.Showtime.StartTime > DateTime.UtcNow,
                    SavingsAmount = 0
                })
                .ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region Status Management

        public async Task<bool> CancelBookingAsync(string bookingReference, string reason, bool issueRefund = false, CancellationToken cancellationToken = default)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.BookingReference == bookingReference, cancellationToken);
            if (booking == null) return false;

            booking.Status = BookingStatus.Cancelled;
            booking.CancellationReason = reason;
            booking.CancellationDate = DateTime.UtcNow;

            if (issueRefund) booking.PaymentStatus = PaymentStatus.Refunded;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> UpdatePaymentStatusAsync(string bookingReference, PaymentStatus status, DateTime? paymentDate = null, CancellationToken cancellationToken = default)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.BookingReference == bookingReference, cancellationToken);
            if (booking == null) return false;

            booking.PaymentStatus = status;
            booking.PaymentDate = paymentDate ?? DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<int> AutoExpirePendingBookingsAsync(TimeSpan gracePeriod, CancellationToken cancellationToken = default)
        {
            var cutoff = DateTime.UtcNow - gracePeriod;

            var expired = await _context.Bookings
                .Where(b => b.Status == BookingStatus.Confirmed &&
                            b.PaymentStatus == PaymentStatus.Pending &&
                            b.BookingDate < cutoff)
                .ToListAsync(cancellationToken);

            foreach (var booking in expired)
            {
                booking.Status = BookingStatus.Cancelled;
                booking.CancellationReason = "Auto-expired due to non-payment.";
                booking.CancellationDate = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync(cancellationToken);
            return expired.Count;
        }

        #endregion

        #region Analytics & Reporting

        public async Task<decimal> GetRevenueAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            return await _context.Bookings
                .Where(b => b.BookingDate >= startDate && b.BookingDate <= endDate)
                .SumAsync(b => b.TotalAmount, cancellationToken);
        }

        public async Task<List<(string MovieTitle, int TicketsSold)>> GetTopMoviesAsync(int count, DateTime? from = null, DateTime? to = null, CancellationToken cancellationToken = default)
        {
            var query = _context.Bookings.Include(b => b.Showtime.Movie).AsQueryable();

            if (from.HasValue) query = query.Where(b => b.BookingDate >= from.Value);
            if (to.HasValue) query = query.Where(b => b.BookingDate <= to.Value);

            var result = await query
                .GroupBy(b => b.Showtime.Movie.Title)
                .Select(g => new { g.Key, TicketsSold = g.Sum(x => x.NumberOfTickets) })
                .OrderByDescending(x => x.TicketsSold)
                .Take(count)
                .ToListAsync(cancellationToken);

            return result.Select(x => (x.Key, x.TicketsSold)).ToList();
        }

        public async Task<Dictionary<DateTime, int>> GetBookingTrendsAsync(DateTime from, DateTime to, CancellationToken cancellationToken = default)
        {
            var trends = await _context.Bookings
                .Where(b => b.BookingDate >= from && b.BookingDate <= to)
                .GroupBy(b => b.BookingDate.Date)
                .Select(g => new { Date = g.Key, Count = g.Count() })
                .ToListAsync(cancellationToken);

            return trends.ToDictionary(x => x.Date, x => x.Count);
        }

        #endregion

        #region Utility

        public async Task<bool> ExistsAsync(string bookingReference, CancellationToken cancellationToken = default)
        {
            return await _context.Bookings.AnyAsync(b => b.BookingReference == bookingReference, cancellationToken);
        }

        public async Task<List<string>> GetBookingSeatsAsync(string bookingReference, CancellationToken cancellationToken = default)
        {
            return await _context.BookingSeats
                .Where(bs => bs.Booking.BookingReference == bookingReference)
                .Select(bs => bs.Seat.SeatNumber)
                .ToListAsync(cancellationToken);
        }

        #endregion
    }
}
