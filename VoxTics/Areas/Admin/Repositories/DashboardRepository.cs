using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Data;
using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
namespace VoxTics.Areas.Admin.Repositories
{
    /// <summary>
    /// Repository for admin dashboard analytics and KPIs.
    /// </summary>
    public class DashboardRepository : IDashboardRepository
    {
        private readonly MovieDbContext _context;

        public DashboardRepository(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<(decimal TodayRevenue, decimal WeeklyRevenue, decimal MonthlyRevenue,
                           int TodayBookings, int WeeklyBookings, int MonthlyBookings)>
            GetRevenueAndBookingStatsAsync(CancellationToken cancellationToken = default)
        {
            var today = DateTime.UtcNow.Date;
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            var startOfMonth = new DateTime(today.Year, today.Month, 1);

            var bookings = await _context.Bookings
                .AsNoTracking()
                .Where(b => b.BookingDate >= startOfMonth)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            decimal todayRevenue = bookings.Where(b => b.BookingDate.Date == today).Sum(b => b.TotalPrice);
            decimal weeklyRevenue = bookings.Where(b => b.BookingDate.Date >= startOfWeek).Sum(b => b.TotalPrice);
            decimal monthlyRevenue = bookings.Sum(b => b.TotalPrice);

            int todayBookings = bookings.Count(b => b.BookingDate.Date == today);
            int weeklyBookings = bookings.Count(b => b.BookingDate.Date >= startOfWeek);
            int monthlyBookings = bookings.Count;

            return (todayRevenue, weeklyRevenue, monthlyRevenue, todayBookings, weeklyBookings, monthlyBookings);
        }

        public async Task<IEnumerable<(Movie Movie, int BookingsCount, decimal TotalRevenue)>>
            GetTopMoviesAsync(int topN, DateTime? fromDate = null, DateTime? toDate = null,
                              CancellationToken cancellationToken = default)
        {
            fromDate ??= DateTime.UtcNow.AddMonths(-1);
            toDate ??= DateTime.UtcNow;

            return await _context.Bookings
                .AsNoTracking()
                .Where(b => b.BookingDate >= fromDate && b.BookingDate <= toDate)
                .GroupBy(b => b.Movie)
                .Select(g => new ValueTuple<Movie, int, decimal>(
                    g.Key, g.Count(), g.Sum(b => b.TotalPrice)))
                .OrderByDescending(x => x.Item2)
                .Take(topN)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<(Cinema Cinema, int BookingsCount)>>
            GetTopCinemasAsync(int topN, DateTime? fromDate = null, DateTime? toDate = null,
                               CancellationToken cancellationToken = default)
        {
            fromDate ??= DateTime.UtcNow.AddMonths(-1);
            toDate ??= DateTime.UtcNow;

            return await _context.Bookings
                .AsNoTracking()
                .Where(b => b.BookingDate >= fromDate && b.BookingDate <= toDate)
                .GroupBy(b => b.Cinema)
                .Select(g => new ValueTuple<Cinema, int>(g.Key, g.Count()))
                .OrderByDescending(x => x.Item2)
                .Take(topN)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<(int TotalMovies, int TotalCinemas, int TotalUsers, int TotalBookings)>
            GetEntityTotalsAsync(CancellationToken cancellationToken = default)
        {
            var totalMovies = await _context.Movies.CountAsync(cancellationToken).ConfigureAwait(false);
            var totalCinemas = await _context.Cinemas.CountAsync(cancellationToken).ConfigureAwait(false);
            var totalUsers = await _context.Users.CountAsync(cancellationToken).ConfigureAwait(false);
            var totalBookings = await _context.Bookings.CountAsync(cancellationToken).ConfigureAwait(false);

            return (totalMovies, totalCinemas, totalUsers, totalBookings);
        }

        public async Task<IEnumerable<Booking>> GetRecentBookingsAsync(int count = 10,
                                                                      CancellationToken cancellationToken = default) =>
            await _context.Bookings
                .AsNoTracking()
                .Include(b => b.Movie)
                .Include(b => b.Cinema)
                .OrderByDescending(b => b.BookingDate)
                .Take(count)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
    }
}
