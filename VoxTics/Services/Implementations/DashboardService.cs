using AutoMapper;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Data.UoW;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{


    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _repo;
        private readonly IMapper _mapper;

        public DashboardService(IDashboardRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task<int> GetTotalMoviesAsync() => _repo.GetTotalMoviesAsync();
        public Task<int> GetTotalUsersAsync() => _repo.GetTotalUsersAsync();
        public Task<int> GetTotalBookingsAsync() => _repo.GetTotalBookingsAsync();
        public Task<int> GetTotalCinemasAsync() => _repo.GetTotalCinemasAsync();
        public Task<int> GetTotalCategoriesAsync() => _repo.GetTotalCategoriesAsync();
        public Task<int> GetTotalShowtimesAsync() => _repo.GetTotalShowtimesAsync();
        public Task<int> GetTotalHallsAsync() => _repo.GetTotalHallsAsync();
        public Task<decimal> GetTotalRevenueAsync() => _repo.GetTotalRevenueAsync();

        public Task<decimal> GetMonthlyRevenueAsync() => _repo.GetMonthlyRevenueAsync();
        public Task<decimal> GetDailyRevenueAsync() => _repo.GetDailyRevenueAsync();

        public Task<int> GetUpcomingMoviesCountAsync() => _repo.GetUpcomingMoviesCountAsync();
        public Task<int> GetNowShowingMoviesCountAsync() => _repo.GetNowShowingMoviesCountAsync();
        public Task<int> GetEndedMoviesCountAsync() => _repo.GetEndedMoviesCountAsync();

        public Task<int> GetPendingBookingsCountAsync() => _repo.GetPendingBookingsCountAsync();
        public Task<int> GetConfirmedBookingsCountAsync() => _repo.GetConfirmedBookingsCountAsync();
        public Task<int> GetCancelledBookingsCountAsync() => _repo.GetCancelledBookingsCountAsync();

        public async Task<List<Movie>> GetRecentMoviesAsync()
        {
            return await _repo.GetRecentMoviesAsync();
        }

        public async Task<List<Booking>> GetRecentBookingsAsync()
        {
            return await _repo.GetRecentBookingsAsync();
        }

        public async Task<List<ApplicationUser>> GetRecentUsersAsync()
        {
            return await _repo.GetRecentUsersAsync();
        }

        public async Task<List<Movie>> GetPopularMoviesAsync() => await _repo.GetPopularMoviesAsync();
        public async Task<List<Cinema>> GetPopularCinemasAsync() => await _repo.GetPopularCinemasAsync();

        public Task<Dictionary<string, int>> GetMonthlyBookingsAsync() => _repo.GetMonthlyBookingsAsync();
        public Task<Dictionary<string, decimal>> GetMonthlyRevenueSeriesAsync() => _repo.GetMonthlyRevenueSeriesAsync();
        public Task<Dictionary<MovieStatus, int>> GetMoviesByStatusAsync() => _repo.GetMoviesByStatusAsync();
        public Task<Dictionary<BookingStatus, int>> GetBookingsByStatusAsync() => _repo.GetBookingsByStatusAsync();
    }
}
