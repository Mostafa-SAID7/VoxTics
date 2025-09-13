using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = await _dashboardService.GetDashboardSummaryAsync().ConfigureAwait(false);
            return View(vm);
        }
    }
}
