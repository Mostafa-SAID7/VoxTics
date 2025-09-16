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
        public async Task<IActionResult> Index(
            int? movieId = null,
            int? cinemaId = null,
            int page = 1,
            int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            // Fetch paged showtimes
            var showtimes = await _showtimeService.GetShowtimesAsync(movieId, cinemaId, page, pageSize, cancellationToken);

            // Count total showtimes for pagination
            var totalCount = await _showtimeService.CountShowtimesAsync(movieId, cinemaId, cancellationToken);

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = totalCount;
            ViewBag.MovieId = movieId;
            ViewBag.CinemaId = cinemaId;

            return View(showtimes);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Upcoming(int movieId, DateTime? fromDate = null, CancellationToken cancellationToken = default)
        {
            var date = fromDate ?? DateTime.UtcNow;

            // Include Hall and Movie to prevent NullReferenceException
            var showtimes = await _showtimeService.GetUpcomingShowtimesAsync(movieId, date, cancellationToken);

            return View(showtimes);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ByCinema(int cinemaId, DateTime? fromDate = null, CancellationToken cancellationToken = default)
        {
            var date = fromDate ?? DateTime.UtcNow;

            // Include Hall and Movie to prevent NullReferenceException
            var showtimes = await _showtimeService.GetAvailableShowtimesForCinemaAsync(cinemaId, date, cancellationToken);

            return View(showtimes);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken = default)
        {
            var showtime = await _showtimeService.GetShowtimeByIdAsync(id, cancellationToken);
            if (showtime == null) return NotFound();

            // Fetch available seats
            var availableSeats = await _showtimeService.GetAvailableSeatsAsync(id, cancellationToken);
            ViewBag.AvailableSeats = availableSeats;

            return View(showtime);
        }
    }
}
