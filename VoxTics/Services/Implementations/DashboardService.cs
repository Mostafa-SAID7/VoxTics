using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Data.UoW;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{


    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _uow;
        public DashboardService(IUnitOfWork uow) => _uow = uow;

        public Task<int> GetTotalBookingsAsync() => _uow.Dashboard.GetTotalBookingsAsync();
        public Task<int> GetTotalMoviesAsync() => _uow.Dashboard.GetTotalMoviesAsync();
        public Task<int> GetTotalUsersAsync() => _uow.Dashboard.GetTotalUsersAsync();
        public Task<decimal> GetTotalRevenueAsync() => _uow.Dashboard.GetTotalRevenueAsync();
    }
}
