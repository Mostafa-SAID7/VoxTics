using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Services.Interfaces;

namespace VoxTics.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemasController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var cinemas = await _cinemaService.GetActiveCinemasAsync(cancellationToken);
            return View(cinemas);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Browse(int page = 1, int pageSize = 10, string? search = null, string? sort = null, CancellationToken cancellationToken = default)
        {
            var pagedCinemas = await _cinemaService.GetPagedCinemasAsync(page, pageSize, search, sort, cancellationToken);
            return View(pagedCinemas);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var cinema = await _cinemaService.GetCinemaDetailsAsync(id, cancellationToken);
            if (cinema == null) return NotFound();

            var showtimes = await _cinemaService.GetUpcomingShowtimesAsync(id, cancellationToken: cancellationToken);
            ViewBag.Showtimes = showtimes;

            return View(cinema);
        }
    }
}
