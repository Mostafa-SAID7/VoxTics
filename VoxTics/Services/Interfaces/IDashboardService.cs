using VoxTics.Areas.Admin.ViewModels.Admin;

namespace VoxTics.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<AdminDashboardViewModel> GetDashboardSummaryAsync(CancellationToken cancellationToken = default);
    }
}
