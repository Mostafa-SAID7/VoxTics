using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Models.Enums;
using VoxTics.Models.Entities;  // For Booking entity

namespace VoxTics.Repositories.IRepositories
{
    // Inherit generic repository for Booking entity
    public interface IDashboardRepository
    {
        Task<int> GetTotalBookingsAsync();
        Task<int> GetTotalMoviesAsync();
        Task<int> GetTotalUsersAsync();
        Task<decimal> GetTotalRevenueAsync();
    }
}
