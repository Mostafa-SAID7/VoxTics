using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Models.Enums;
using VoxTics.Data;
using VoxTics.Repositories.IRepositories;
using VoxTics.Models.Entities;
using Microsoft.EntityFrameworkCore;
using VoxTics.Data;
namespace VoxTics.Repositories
{
    public class DashboardRepository : BaseRepository<Booking>, IDashboardRepository
    {

        public DashboardRepository(MovieDbContext context) : base(context) { }

        public async Task<int> GetTotalMoviesAsync()
        {
            return await _context.Movies.CountAsync();
        }

        public async Task<int> GetTotalUsersAsync()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<int> GetTotalBookingsAsync()
        {
            return await _context.Bookings.CountAsync();
        }

        public async Task<int> GetTotalCategoriesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Categories.CountAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _context.Bookings.SumAsync(b => b.TotalPrice);
        }

        public async Task<decimal> GetRevenueByDateRangeAsync(
            DateTime startDate,
            DateTime endDate,
            CancellationToken cancellationToken = default)
        {
            return await _context.Bookings
                .Where(b => b.BookingDate >= startDate && b.BookingDate <= endDate)
                .SumAsync(b => b.TotalPrice, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<Dictionary<MovieStatus, int>> GetMoviesByStatusAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Movies
                .GroupBy(m => m.Status)
                .ToDictionaryAsync(g => g.Key, g => g.Count(), cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<Dictionary<BookingStatus, int>> GetBookingsByStatusAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Bookings
                .GroupBy(b => b.Status)
                .ToDictionaryAsync(g => g.Key, g => g.Count(), cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<MovieSummary>> GetRecentMoviesAsync(int count, CancellationToken cancellationToken = default)
        {
            return await _context.Movies
                .OrderByDescending(m => m.CreatedAt)
                .Take(count)
                .Select(m => new MovieSummary
                {
                    Title = m.Title,
                    Status = m.Status,
                    CreatedAt = m.CreatedAt
                })
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<BookingSummary>> GetRecentBookingsAsync(int count, CancellationToken cancellationToken = default)
        {
            return await _context.Bookings
                .Include(b => b.Movie)
                .Include(b => b.User)
                .OrderByDescending(b => b.CreatedAt)
                .Take(count)
                .Select(b => new BookingSummary
                {
                    MovieTitle = b.Movie.Title,
                    UserName = b.User.UserName ?? string.Empty,
                    TotalAmount = b.TotalPrice,
                    CreatedAt = b.CreatedAt
                })
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<UserSummary>> GetRecentUsersAsync(int count, CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .OrderByDescending(u => u.UserName)
                .Take(count)
                .Select(u => new UserSummary
                {
                    UserId = u.Id,
                    Name = u.Name,
                    Email = u.Email ?? string.Empty,
                 
                })
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
