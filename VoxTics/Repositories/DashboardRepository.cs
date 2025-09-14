using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Data;
using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Repositories.IRepositories;
namespace VoxTics.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly MovieDbContext _context;

        public DashboardRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalMoviesAsync() => await _context.Movies.CountAsync();
        public async Task<int> GetTotalUsersAsync() => await _context.Users.CountAsync().ConfigureAwait(false);
        public async Task<int> GetTotalBookingsAsync() => await _context.Bookings.CountAsync();
        public async Task<int> GetTotalCinemasAsync() => await _context.Cinemas.CountAsync().ConfigureAwait(false);
        public async Task<int> GetTotalCategoriesAsync() => await _context.Categories.CountAsync();
        public async Task<int> GetTotalShowtimesAsync() => await _context.Showtimes.CountAsync();
        public async Task<int> GetTotalHallsAsync() => await _context.Halls.CountAsync();
        public async Task<decimal> GetTotalRevenueAsync() => await _context.Bookings.SumAsync(b => b.TotalPrice);

        public async Task<decimal> GetMonthlyRevenueAsync()
        {
            var now = DateTime.UtcNow;
            return await _context.Bookings
                .Where(b => b.CreatedAt.Month == now.Month && b.CreatedAt.Year == now.Year)
                .SumAsync(b => b.TotalPrice);
        }

        public async Task<decimal> GetDailyRevenueAsync()
        {
            var today = DateTime.UtcNow.Date;
            return await _context.Bookings
                .Where(b => b.CreatedAt.Date == today)
                .SumAsync(b => b.TotalPrice);
        }

        public async Task<int> GetUpcomingMoviesCountAsync() =>
            await _context.Movies.CountAsync(m => m.Status == MovieStatus.Upcoming).ConfigureAwait(false);

        public async Task<int> GetNowShowingMoviesCountAsync() =>
            await _context.Movies.CountAsync(m => m.Status == MovieStatus.NowShowing).ConfigureAwait(false);

        public async Task<int> GetEndedMoviesCountAsync() =>
            await _context.Movies.CountAsync(m => m.Status == MovieStatus.Ended).ConfigureAwait(false);

        public async Task<int> GetPendingBookingsCountAsync() =>
            await _context.Bookings.CountAsync(b => b.Status == BookingStatus.Pending).ConfigureAwait(false);

        public async Task<int> GetConfirmedBookingsCountAsync() =>
            await _context.Bookings.CountAsync(b => b.Status == BookingStatus.Confirmed).ConfigureAwait(false);

        public async Task<int> GetCancelledBookingsCountAsync() =>
            await _context.Bookings.CountAsync(b => b.Status == BookingStatus.Cancelled).ConfigureAwait(false);

        public async Task<List<Movie>> GetRecentMoviesAsync(int count = 5) =>
            await _context.Movies.OrderByDescending(m => m.CreatedAt).Take(count).ToListAsync().ConfigureAwait(false);

        public async Task<List<Booking>> GetRecentBookingsAsync(int count = 5) =>
            await _context.Bookings.Include(b => b.Cinema).Include(b => b.Movie)
                .OrderByDescending(b => b.CreatedAt).Take(count).ToListAsync().ConfigureAwait(false);

        public async Task<List<ApplicationUser>> GetRecentUsersAsync(int count = 5)
        {
            return await _context.Users
                .OrderByDescending(u => u.Bookings.Max(b => (DateTime?)b.BookingDate)) // most recent booking
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<Movie>> GetPopularMoviesAsync(int count = 5) =>
            await _context.Movies.OrderByDescending(m => m.Bookings.Count).Take(count).ToListAsync().ConfigureAwait(false);

        public async Task<List<Cinema>> GetPopularCinemasAsync(int count = 5) =>
            await _context.Cinemas.OrderByDescending(c => c.Bookings.Count).Take(count).ToListAsync().ConfigureAwait(false);

        public async Task<Dictionary<string, int>> GetMonthlyBookingsAsync()
        {
            var bookings = await _context.Bookings
                .GroupBy(b => new { b.CreatedAt.Year, b.CreatedAt.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Count = g.Count()
                })
                .ToListAsync();

            // Convert to "MMM yyyy" format in memory
            return bookings.ToDictionary(
                x => new DateTime(x.Year, x.Month, 1).ToString("MMM yyyy"),
                x => x.Count
            );
        }


        public async Task<Dictionary<string, decimal>> GetMonthlyRevenueSeriesAsync()
        {
            var revenueData = await _context.Bookings
                .GroupBy(b => new { b.CreatedAt.Year, b.CreatedAt.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Revenue = g.Sum(b => b.TotalPrice)
                })
                .ToListAsync();

            // Format "MMM yyyy" in memory
            return revenueData.ToDictionary(
                x => new DateTime(x.Year, x.Month, 1).ToString("MMM yyyy"),
                x => x.Revenue
            );
        }


        public async Task<Dictionary<MovieStatus, int>> GetMoviesByStatusAsync()
        {
            return await _context.Movies
                .GroupBy(m => m.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToDictionaryAsync(r => r.Status, r => r.Count);
        }

        public async Task<Dictionary<BookingStatus, int>> GetBookingsByStatusAsync()
        {
            return await _context.Bookings
                .GroupBy(b => b.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToDictionaryAsync(r => r.Status, r => r.Count);
        }
    }
}
