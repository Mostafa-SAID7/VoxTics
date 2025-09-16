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
        private readonly IMapper _mapper;

        public HomeController(IDashboardService dashboardService, IMapper mapper)
        {
            _dashboardService = dashboardService;
            _mapper = mapper;
        }

        /// <summary>
        /// Shows the main dashboard page.
        /// Loads all metrics, recent/popular items, and chart data.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            // Load dashboard data
            var dashboardViewModel = await _dashboardService.GetDashboardDataAsync(popularCount: 5);

            // Optionally, map entities to ViewModels using AutoMapper
            // Example: dashboardViewModel.RecentMovies is already List<MovieListItemViewModel>
            // If you want extra mapping for some entities, you can do it here:
            // dashboardViewModel.RecentUsers = dashboardViewModel.RecentUsers
            //     .Select(u => _mapper.Map<PersonalInfoVM>(u)).ToList();

            return View(dashboardViewModel);
        }

        /// <summary>
        /// Optionally provide JSON data for charts (monthly bookings/revenue)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ChartData()
        {
            var dashboard = await _dashboardService.GetDashboardDataAsync();

            return Json(new
            {
                MonthlyBookings = dashboard.MonthlyBookings,
                MonthlyRevenue = dashboard.MonthlyRevenueSeries
            });
        }
    }
}
