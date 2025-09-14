using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.Entities;  // For Booking entity
using VoxTics.Models.Enums;

namespace VoxTics.Repositories.IRepositories
{
    // Inherit generic repository for Booking entity
    public interface IDashboardRepository
    {
        Task<int> GetTotalMoviesAsync();
        Task<int> GetTotalUsersAsync();
        Task<int> GetTotalBookingsAsync();
        Task<int> GetTotalCinemasAsync();
        Task<int> GetTotalCategoriesAsync();
        Task<int> GetTotalShowtimesAsync();
        Task<int> GetTotalHallsAsync();
        Task<decimal> GetTotalRevenueAsync();

        Task<decimal> GetMonthlyRevenueAsync();
        Task<decimal> GetDailyRevenueAsync();

        Task<int> GetUpcomingMoviesCountAsync();
        Task<int> GetNowShowingMoviesCountAsync();
        Task<int> GetEndedMoviesCountAsync();

        Task<int> GetPendingBookingsCountAsync();
        Task<int> GetConfirmedBookingsCountAsync();
        Task<int> GetCancelledBookingsCountAsync();

        Task<List<Movie>> GetRecentMoviesAsync(int count = 5);
        Task<List<Booking>> GetRecentBookingsAsync(int count = 5);
        Task<List<ApplicationUser>> GetRecentUsersAsync(int count = 5);

        Task<List<Movie>> GetPopularMoviesAsync(int count = 5);
        Task<List<Cinema>> GetPopularCinemasAsync(int count = 5);

        Task<Dictionary<string, int>> GetMonthlyBookingsAsync();
        Task<Dictionary<string, decimal>> GetMonthlyRevenueSeriesAsync();
        Task<Dictionary<MovieStatus, int>> GetMoviesByStatusAsync();
        Task<Dictionary<BookingStatus, int>> GetBookingsByStatusAsync();
    }
}
