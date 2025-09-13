using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces;

namespace VoxTics.Controllers
{
    public class ShowtimesController : Controller
    {
        private readonly IShowtimeService _service;
        public ShowtimesController(IShowtimeService service) => _service = service;

        public async Task<IActionResult> Index()
        {
            var showtimes = await _service.GetWithDetailsAsync();
            return View(showtimes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var showtime = await _service.GetWithMovieAsync(id);
            if (showtime == null) return NotFound();
            return View(showtime);
        }
    }
}
