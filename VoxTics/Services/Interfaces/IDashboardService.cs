using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Services.Interfaces
{
    public interface IDashboardService
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

        Task<List<Movie>> GetRecentMoviesAsync();
        Task<List<Booking>> GetRecentBookingsAsync();
        Task<List<ApplicationUser>> GetRecentUsersAsync();

        Task<List<Movie>> GetPopularMoviesAsync();
        Task<List<Cinema>> GetPopularCinemasAsync();

        Task<Dictionary<string, int>> GetMonthlyBookingsAsync();
        Task<Dictionary<string, decimal>> GetMonthlyRevenueSeriesAsync();
        Task<Dictionary<MovieStatus, int>> GetMoviesByStatusAsync();
        Task<Dictionary<BookingStatus, int>> GetBookingsByStatusAsync();
    }
}
