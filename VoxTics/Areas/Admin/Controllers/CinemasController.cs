using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CinemasController : Controller
    {
        private readonly IAdminCinemaService _cinemaService;

        public CinemasController(IAdminCinemaService cinemaService)
        {
            _cinemaService = cinemaService ?? throw new ArgumentNullException(nameof(cinemaService));
        }

        #region List & Search

        public async Task<IActionResult> Index(
            string? searchTerm,
            string? city,
            bool? isActive,
            int pageIndex = 1,
            int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            var (cinemas, totalCount) = await _cinemaService.GetPagedCinemasAsync(
                pageIndex - 1,
                pageSize,
                searchTerm,
                city,
                isActive,
                cancellationToken);

            var vm = cinemas.Select(c => new CinemaViewModel(c)
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                Email = c.Email,
                Phone = c.Phone,
                IsActive = c.IsActive,
                TotalSeats = c.TotalSeats,
                HallCount = c.Halls?.Count ?? 0,
                ShowtimeCount = c.Showtimes?.Count ?? 0,
                ImageUrl = !string.IsNullOrEmpty(c.ImageUrl) ? new Uri(c.ImageUrl, UriKind.RelativeOrAbsolute) : null
            }).ToList();

            ViewBag.TotalCount = totalCount;
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;

            return View(vm);
        }

        #endregion

        #region Details

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken = default)
        {
            var cinema = await _cinemaService.GetByIdAsync(id, cancellationToken);
            if (cinema == null) return NotFound();

            var vm = new CinemaViewModel(cinema)
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Address = cinema.Address,
                Email = cinema.Email,
                Phone = cinema.Phone,
                IsActive = cinema.IsActive,
                TotalSeats = cinema.TotalSeats,
                HallCount = cinema.Halls?.Count ?? 0,
                ShowtimeCount = cinema.Showtimes?.Count ?? 0,
                ImageUrl = !string.IsNullOrEmpty(cinema.ImageUrl) ? new Uri(cinema.ImageUrl, UriKind.RelativeOrAbsolute) : null
            };

            return View(vm);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cinema cinema, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(cinema);

            var errors = await _cinemaService.AddCinemaAsync(cinema, cancellationToken);
            if (errors.Any())
            {
                foreach (var error in errors)
                    ModelState.AddModelError(string.Empty, error);

                return View(cinema);
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var cinema = await _cinemaService.GetByIdAsync(id, cancellationToken);
            if (cinema == null) return NotFound();

            var vm = new CinemaViewModel(cinema);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cinema cinema, CancellationToken cancellationToken)
        {
            if (id != cinema.Id) return BadRequest();

            if (!ModelState.IsValid)
                return View(cinema);

            var errors = await _cinemaService.UpdateCinemaAsync(cinema, cancellationToken);
            if (errors.Any())
            {
                foreach (var error in errors)
                    ModelState.AddModelError(string.Empty, error);

                return View(cinema);
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Activate / Deactivate

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(int id, bool isActive, CancellationToken cancellationToken)
        {
            var result = await _cinemaService.SetCinemaStatusAsync(id, isActive, cancellationToken);
            if (!result) return BadRequest("Could not change cinema status.");
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _cinemaService.DeleteCinemaAsync(id, cancellationToken);
            if (!result) return BadRequest("Could not delete cinema.");
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
