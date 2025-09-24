using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Showtime;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.SuperAdminRole}")]
    public class ShowtimesController : Controller
    {
        private readonly IAdminShowtimeService _showtimeService;
        private readonly IMovieService _movieService;
        private readonly ICinemaService _cinemaService;
        private readonly IHallService _hallService;

        public ShowtimesController(
            IAdminShowtimeService showtimeService,
            IMovieService movieService,
            ICinemaService cinemaService,
            IHallService hallService)
        {
            _showtimeService = showtimeService;
            _movieService = movieService;
            _cinemaService = cinemaService;
            _hallService = hallService;
        }

        // ---------------------- INDEX ----------------------
        public async Task<IActionResult> Index(string? search, int page = 1, int pageSize = 10)
        {
            var showtimes = await _showtimeService.GetPagedShowtimesAsync(search, page, pageSize);
            var totalCount = await _showtimeService.CountShowtimesAsync(search);

            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = totalCount;
            ViewBag.Search = search;

            return View(showtimes);
        }

        // ---------------------- DETAILS ----------------------
        public async Task<IActionResult> Details(int id)
        {
            var showtime = await _showtimeService.GetShowtimeDetailsAsync(id);
            if (showtime == null)
                return NotFound();

            return View(showtime);
        }

        // ---------------------- CREATE ----------------------
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ShowtimeCreateEditViewModel();
            await PopulateDropdownsAsync(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShowtimeCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdownsAsync(model);
                return View(model);
            }

            var hall = await _hallService.GetByIdAsync(model.HallId);
            if (hall == null)
            {
                ModelState.AddModelError("", "Selected hall does not exist.");
                await PopulateDropdownsAsync(model);
                return View(model);
            }

            var showtime = new Showtime
            {
                MovieId = model.MovieId,
                CinemaId = model.CinemaId,
                HallId = model.HallId,
                StartTime = model.StartTime,
                Duration = model.Duration,
                Price = model.Price,
                Is3D = model.Is3D,
                Language = model.Language,
                ScreenType = model.ScreenType,
                Status = model.Status,
              
            };

            await _showtimeService.AddShowtimeAsync(showtime);
            return RedirectToAction(nameof(Index));
        }

        // ---------------------- EDIT ----------------------
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var showtime = await _showtimeService.GetShowtimeByIdAsync(id);
            if (showtime == null) return NotFound();

            var model = new ShowtimeCreateEditViewModel
            {
                Id = showtime.Id,
                MovieId = showtime.MovieId,
                CinemaId = showtime.CinemaId,
                HallId = showtime.HallId,
                StartTime = showtime.StartTime,
                Duration = showtime.Duration,
                Price = showtime.Price,
                Is3D = showtime.Is3D,
                Language = showtime.Language,
                ScreenType = showtime.ScreenType,
                Status = showtime.Status
            };

            await PopulateDropdownsAsync(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ShowtimeCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdownsAsync(model);
                return View(model);
            }

            if (!await _showtimeService.ShowtimeExistsAsync(model.Id))
                return NotFound();

            var showtime = new Showtime
            {
                Id = model.Id,
                MovieId = model.MovieId,
                CinemaId = model.CinemaId,
                HallId = model.HallId,
                StartTime = model.StartTime,
                Duration = model.Duration,
                Price = model.Price,
                Is3D = model.Is3D,
                Language = model.Language,
                ScreenType = model.ScreenType,
                Status = model.Status
            };

            await _showtimeService.UpdateShowtimeAsync(showtime);
            return RedirectToAction(nameof(Index));
        }

        // ---------------------- DELETE ----------------------
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var showtime = await _showtimeService.GetShowtimeDetailsAsync(id);
            if (showtime == null) return NotFound();
            return View(showtime);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _showtimeService.RemoveShowtimeAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // ---------------------- HELPER ----------------------
        private async Task PopulateDropdownsAsync(ShowtimeCreateEditViewModel model)
        {
            var movies = await _movieService.GetAllAsync();
            var cinemas = await _cinemaService.GetActiveCinemasAsync();
            var halls = await _hallService.GetAllAsync();

            model.Movies = movies.Select(m => new SelectListItem(m.Title, m.Id.ToString())).ToList();
            model.Cinemas = cinemas.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();
            model.Halls = halls.Select(h => new SelectListItem(h.Name, h.Id.ToString())).ToList();
        }
    }
}
