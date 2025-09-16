using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Areas.Admin.ViewModels.Booking;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
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

        public async Task<AdminDashboardViewModel> GetDashboardDataAsync(int popularCount = 5, CancellationToken cancellationToken = default)
        {
            var dashboard = new AdminDashboardViewModel(_dashboardRepository);

            // Load all data asynchronously
            await dashboard.LoadAsync(popularCount);

            return dashboard;
        }
    }
}
