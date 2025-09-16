using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Data;

namespace VoxTics.Areas.Admin.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly MovieDbContext _context;

        public DashboardRepository(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region General Statistics

        public async Task<int> GetTotalMoviesAsync(CancellationToken cancellationToken = default)
            => await _context.Movies.CountAsync(cancellationToken).ConfigureAwait(false);

    
        public async Task<int> GetTotalBookingsAsync(CancellationToken cancellationToken = default)
            => await _context.Bookings.CountAsync(cancellationToken).ConfigureAwait(false);

        public async Task<int> GetTotalCinemasAsync(CancellationToken cancellationToken = default)
            => await _context.Cinemas.CountAsync(cancellationToken).ConfigureAwait(false);

        public async Task<int> GetTotalCategoriesAsync(CancellationToken cancellationToken = default)
            => await _context.Categories.CountAsync(cancellationToken).ConfigureAwait(false);

        public async Task<int> GetTotalShowtimesAsync(CancellationToken cancellationToken = default)
            => await _context.Showtimes.CountAsync(cancellationToken).ConfigureAwait(false);

        public async Task<int> GetTotalHallsAsync(CancellationToken cancellationToken = default)
            => await _context.Halls.CountAsync(cancellationToken).ConfigureAwait(false);

        public async Task<decimal> GetTotalRevenueAsync(CancellationToken cancellationToken = default)
            => await _context.Bookings.SumAsync(b => b.TotalAmount - b.DiscountAmount, cancellationToken).ConfigureAwait(false);

        #endregion

        #region Revenue Tracking

        public async Task<decimal> GetMonthlyRevenueAsync(int year, int month, CancellationToken cancellationToken = default)
            => await _context.Bookings
                .Where(b => b.CreatedAt.Year == year && b.CreatedAt.Month == month)
                .SumAsync(b => b.TotalAmount - b.DiscountAmount, cancellationToken)
                .ConfigureAwait(false);

        public async Task<decimal> GetDailyRevenueAsync(DateTime date, CancellationToken cancellationToken = default)
            => await _context.Bookings
                .Where(b => b.CreatedAt.Date == date.Date)
                .SumAsync(b => b.TotalAmount - b.DiscountAmount, cancellationToken)
                .ConfigureAwait(false);

        #endregion

        #region Movie Statistics

        public async Task<int> GetUpcomingMoviesCountAsync(CancellationToken cancellationToken = default)
            => await _context.Movies.CountAsync(m => m.Status == MovieStatus.Upcoming, cancellationToken)
                .ConfigureAwait(false);

        public async Task<int> GetNowShowingMoviesCountAsync(CancellationToken cancellationToken = default)
            => await _context.Movies.CountAsync(m => m.Status == MovieStatus.NowShowing, cancellationToken)
                .ConfigureAwait(false);

        public async Task<int> GetEndedMoviesCountAsync(CancellationToken cancellationToken = default)
            => await _context.Movies.CountAsync(m => m.Status == MovieStatus.Ended, cancellationToken)
                .ConfigureAwait(false);

        public async Task<Dictionary<MovieStatus, int>> GetMoviesByStatusAsync(CancellationToken cancellationToken = default)
            => await _context.Movies
                .GroupBy(m => m.Status)
                .Select(g => new { g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Key, x => x.Count, cancellationToken)
                .ConfigureAwait(false);

        #endregion

        #region Booking Statistics

        public async Task<int> GetPendingBookingsCountAsync(CancellationToken cancellationToken = default)
            => await _context.Bookings.CountAsync(b => b.Status == BookingStatus.Pending, cancellationToken)
                .ConfigureAwait(false);

        public async Task<int> GetConfirmedBookingsCountAsync(CancellationToken cancellationToken = default)
            => await _context.Bookings.CountAsync(b => b.Status == BookingStatus.Confirmed, cancellationToken)
                .ConfigureAwait(false);

        public async Task<int> GetCancelledBookingsCountAsync(CancellationToken cancellationToken = default)
            => await _context.Bookings.CountAsync(b => b.Status == BookingStatus.Cancelled, cancellationToken)
                .ConfigureAwait(false);

        public async Task<Dictionary<BookingStatus, int>> GetBookingsByStatusAsync(CancellationToken cancellationToken = default)
            => await _context.Bookings
                .GroupBy(b => b.Status)
                .Select(g => new { g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Key, x => x.Count, cancellationToken)
                .ConfigureAwait(false);

        #endregion

        #region Recent / Popular Items

        public async Task<IEnumerable<Movie>> GetRecentMoviesAsync(int count = 5, CancellationToken cancellationToken = default)
        {
            var result = await _context.Movies
                .OrderByDescending(m => m.CreatedAt)
                .Take(count)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return result;
        }

        public async Task<IEnumerable<Booking>> GetRecentBookingsAsync(int count = 5, CancellationToken cancellationToken = default)
        {
            var result = await _context.Bookings
                .OrderByDescending(b => b.CreatedAt)
                .Take(count)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return result;
        }

   

        public async Task<IEnumerable<Movie>> GetPopularMoviesAsync(int count = 5, CancellationToken cancellationToken = default)
        {
            var result = await _context.Movies
                .Include(m => m.Showtimes)
                .ThenInclude(st => st.Bookings)
                .OrderByDescending(m => m.Showtimes.Sum(st => st.Bookings.Count))
                .Take(count)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return result;
        }

        public async Task<IEnumerable<Cinema>> GetPopularCinemasAsync(int count = 5, CancellationToken cancellationToken = default)
        {
            var result = await _context.Cinemas
                .Include(c => c.Showtimes)
                .ThenInclude(st => st.Bookings)
                .OrderByDescending(c => c.Showtimes.Sum(st => st.Bookings.Count))
                .Take(count)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return result;
        }

        #endregion

        #region Chart Data

        public async Task<Dictionary<string, int>> GetMonthlyBookingsSeriesAsync(int year, CancellationToken cancellationToken = default)
            => await _context.Bookings
                .Where(b => b.CreatedAt.Year == year)
                .GroupBy(b => b.CreatedAt.Month)
                .Select(g => new { Month = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => new DateTime(year, x.Month, 1).ToString("MMM"), x => x.Count, cancellationToken)
                .ConfigureAwait(false);

        public async Task<Dictionary<string, decimal>> GetMonthlyRevenueSeriesAsync(int year, CancellationToken cancellationToken = default)
            => await _context.Bookings
                .Where(b => b.CreatedAt.Year == year)
                .GroupBy(b => b.CreatedAt.Month)
                .Select(g => new { Month = g.Key, Revenue = g.Sum(b => b.TotalAmount - b.DiscountAmount) })
                .ToDictionaryAsync(x => new DateTime(year, x.Month, 1).ToString("MMM"), x => x.Revenue, cancellationToken)
                .ConfigureAwait(false);

        public Task<int> GetTotalUsersAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetRecentUsersAsync(int count = 5, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
