using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Areas.Admin.ViewModels.Booking;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;

namespace VoxTics.Services.Interfaces
{
    /// <summary>
    /// Service interface for Admin Dashboard operations.
    /// Provides metrics, statistics, recent items, and chart data.
    /// </summary>
    public interface IDashboardService
    {
        Task<AdminDashboardViewModel> GetDashboardDataAsync(int popularCount = 5, CancellationToken cancellationToken = default);
    }
}
