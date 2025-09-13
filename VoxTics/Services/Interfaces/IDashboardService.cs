using VoxTics.Areas.Admin.ViewModels.Admin;

namespace VoxTics.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<int> GetTotalBookingsAsync();
        Task<int> GetTotalMoviesAsync();
        Task<int> GetTotalUsersAsync();
        Task<decimal> GetTotalRevenueAsync();
    }
}
