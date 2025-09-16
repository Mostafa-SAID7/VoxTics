using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Services.Interfaces;

namespace VoxTics.Controllers
{
    public class ShowtimesController : Controller
    {
        private readonly IShowtimeService _showtimeService;

        public ShowtimesController(IShowtimeService showtimeService)
        {
            _showtimeService = showtimeService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Upcoming(int movieId, DateTime? fromDate = null, CancellationToken cancellationToken = default)
        {
            var date = fromDate ?? DateTime.UtcNow;
            var showtimes = await _showtimeService.GetUpcomingShowtimesAsync(movieId, date, cancellationToken);
            return View(showtimes);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ByCinema(int cinemaId, DateTime? fromDate = null, CancellationToken cancellationToken = default)
        {
            var date = fromDate ?? DateTime.UtcNow;
            var showtimes = await _showtimeService.GetAvailableShowtimesForCinemaAsync(cinemaId, date, cancellationToken);
            return View(showtimes);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var showtime = await _showtimeService.GetShowtimeByIdAsync(id, cancellationToken);
            if (showtime == null) return NotFound();

            var availableSeats = await _showtimeService.GetAvailableSeatsAsync(id, cancellationToken);
            ViewBag.AvailableSeats = availableSeats;

            return View(showtime);
        }
    }
}
