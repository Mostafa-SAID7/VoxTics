using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Data.UoW;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        /// <summary>
        /// Returns key metrics for the admin dashboard.
        /// </summary>
        public async Task<DashboardStats> GetDashboardStatsAsync(CancellationToken cancellationToken = default)
        {
            // --------------------------
            // Bookings
            // --------------------------
            var bookingsQuery = _unitOfWork.Bookings.Query();
            var totalBookings = await bookingsQuery.CountAsync(cancellationToken);
            var todayBookings = await bookingsQuery.CountAsync(
                b => b.BookingDate.Date == DateTime.UtcNow.Date, cancellationToken);
            var weeklyBookings = await bookingsQuery.CountAsync(
                b => b.BookingDate >= DateTime.UtcNow.AddDays(-7), cancellationToken);
            var totalRevenue = await bookingsQuery.SumAsync(b => b.FinalAmount, cancellationToken);

            // --------------------------
            // Movies
            // --------------------------
            var moviesQuery = _unitOfWork.Movies.Query();
            var totalMovies = await moviesQuery.CountAsync(cancellationToken);
            var upcomingMovies = await moviesQuery.CountAsync(m => m.Status == Models.Enums.MovieStatus.Upcoming, cancellationToken);
            var featuredMovies = await moviesQuery.CountAsync(m => m.IsFeatured, cancellationToken);

            // --------------------------
            // Users
            // --------------------------
            var usersQuery = _unitOfWork.ApplicationUsers.Query();
            var totalUsers = await usersQuery.CountAsync(cancellationToken);
            var newUsersToday = await usersQuery.CountAsync(u => u.CreatedAt.Date == DateTime.UtcNow.Date, cancellationToken).ConfigureAwait(false);

            // --------------------------
            // Showtimes
            // --------------------------
            var showtimesQuery = _unitOfWork.Showtimes.Query();
            var activeShowtimes = await showtimesQuery.CountAsync(s => s.Status == Models.Enums.ShowtimeStatus.Scheduled, cancellationToken);
            var showtimesToday = await showtimesQuery.CountAsync(s => s.StartTime.Date == DateTime.UtcNow.Date, cancellationToken);

            // --------------------------
            // Prepare stats object
            // --------------------------
            var stats = new DashboardStats
            {
                TotalBookings = totalBookings,
                TodayBookings = todayBookings,
                WeeklyBookings = weeklyBookings,
                TotalRevenue = totalRevenue,
                TotalMovies = totalMovies,
                UpcomingMovies = upcomingMovies,
                FeaturedMovies = featuredMovies,
                TotalUsers = totalUsers,
                NewUsersToday = newUsersToday,
                ActiveShowtimes = activeShowtimes,
                ShowtimesToday = showtimesToday
            };

            return stats;
        }
    }

    
}
