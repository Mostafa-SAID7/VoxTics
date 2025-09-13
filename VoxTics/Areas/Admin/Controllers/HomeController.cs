using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IDashboardService _dashboardService;
        public HomeController(IDashboardService dashboardService) => _dashboardService = dashboardService;

        public async Task<IActionResult> Index()
        {
            var stats = new
            {
                TotalBookings = await _dashboardService.GetTotalBookingsAsync(),
                TotalMovies = await _dashboardService.GetTotalMoviesAsync(),
                TotalUsers = await _dashboardService.GetTotalUsersAsync(),
                TotalRevenue = await _dashboardService.GetTotalRevenueAsync()
            };

            return View(stats);
        }
    }
}
