using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
   

    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository ?? throw new ArgumentNullException(nameof(dashboardRepository));
        }

        public async Task<AdminDashboardViewModel> GetDashboardSummaryAsync(CancellationToken cancellationToken = default)
        {
            var totalMoviesTask = _dashboardRepository.GetTotalMoviesAsync(cancellationToken);
            var totalUsersTask = _dashboardRepository.GetTotalUsersAsync(cancellationToken);
            var totalBookingsTask = _dashboardRepository.GetTotalBookingsAsync(cancellationToken);
            var totalCategoriesTask = _dashboardRepository.GetTotalCategoriesAsync(cancellationToken);
            var totalRevenueTask = _dashboardRepository.GetTotalRevenueAsync(cancellationToken);

            var moviesByStatusTask = _dashboardRepository.GetMoviesByStatusAsync(cancellationToken);
            var bookingsByStatusTask = _dashboardRepository.GetBookingsByStatusAsync(cancellationToken);

            var recentMoviesTask = _dashboardRepository.GetRecentMoviesAsync(5, cancellationToken);
            var recentBookingsTask = _dashboardRepository.GetRecentBookingsAsync(5, cancellationToken);
            var recentUsersTask = _dashboardRepository.GetRecentUsersAsync(5, cancellationToken);

            await Task.WhenAll(
                totalMoviesTask, totalUsersTask, totalBookingsTask,
                totalCategoriesTask, totalRevenueTask,
                moviesByStatusTask, bookingsByStatusTask,
                recentMoviesTask, recentBookingsTask, recentUsersTask
            ).ConfigureAwait(false);

            // Manual conversion from summary DTOs to ViewModels
            var bookingViewModels = recentBookingsTask.Result.Select(b => new BookingViewModel
            {
                MovieTitle = b.MovieTitle,
                UserName = b.UserName,
                TotalAmount = b.TotalAmount,
                CreatedAt = b.CreatedAt
            }).ToList();

            var userViewModels = recentUsersTask.Result.Select(u => new PersonalInfoVM
            {
    
            }).ToList();

            return new AdminDashboardViewModel
            {
                TotalMovies = totalMoviesTask.Result,
                TotalUsers = totalUsersTask.Result,
                TotalBookings = totalBookingsTask.Result,
                TotalCategories = totalCategoriesTask.Result,
                TotalRevenue = totalRevenueTask.Result,

         

                //RecentMovies = recentMoviesTask.Result.ToList(), // if AdminDashboardViewModel expects List<MovieSummary>
            
            };
        }
    }
}
