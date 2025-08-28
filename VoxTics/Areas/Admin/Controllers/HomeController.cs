using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Data;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Home/Index
        public async Task<IActionResult> Index()
        {
            // Example dashboard statistics
            var totalMovies = await _context.Movies.CountAsync();
            var totalActors = await _context.Actors.CountAsync();
            var totalCinemas = await _context.Cinemas.CountAsync();
            var totalCategories = await _context.Categories.CountAsync();

            var model = new DashboardViewModel
            {
                TotalMovies = totalMovies,
                TotalActors = totalActors,
                TotalCinemas = totalCinemas,
                TotalCategories = totalCategories
            };

            return View(model);
        }
    }
}
