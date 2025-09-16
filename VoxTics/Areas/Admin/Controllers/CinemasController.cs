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

            var vm = cinemas.Select(c => new CinemaTableViewModel
            {
                Id = c.Id,
                Name = c.Name,
                City = c.City ?? string.Empty,
                State = c.State ?? string.Empty,
                Country = c.Country ?? string.Empty,
                IsActive = c.IsActive,
                HallCount = c.Halls?.Count ?? 0,
                TotalSeats = c.TotalSeats,
                ShowtimeCount = c.Showtimes?.Count ?? 0
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

            var vm = new CinemaDetailsViewModel
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Description = cinema.Description,
                Email = cinema.Email,
                Phone = cinema.Phone,
                Address = cinema.Address,
                City = cinema.City,
                State = cinema.State,
                Country = cinema.Country,
                PostalCode = cinema.PostalCode,
                Website = cinema.Website,
                ImageUrl = cinema.ImageUrl,
                IsActive = cinema.IsActive,
                HallCount = cinema.Halls?.Count ?? 0,
                ShowtimeCount = cinema.Showtimes?.Count ?? 0,
                TotalSeats = cinema.TotalSeats,
                Halls = cinema.Halls?.Select(h => h.Name).ToList() ?? new List<string>(),
                Showtimes = cinema.Showtimes?.Select(s => s.Movie?.Title ?? string.Empty).ToList() ?? new List<string>()
            };

            return View(vm);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CinemaCreateEditViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CinemaCreateEditViewModel vm, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var cinema = new Cinema
            {
                Name = vm.Name,
                Description = vm.Description,
                Email = vm.Email,
                Phone = vm.Phone,
                Address = vm.Address,
                City = vm.City,
                State = vm.State,
                Country = vm.Country,
                PostalCode = vm.PostalCode,
                Website = vm.Website,
                ImageUrl = vm.ImageUrl,
                IsActive = vm.IsActive,
            };

            var errors = await _cinemaService.AddCinemaAsync(cinema, cancellationToken);
            if (errors.Any())
            {
                foreach (var error in errors)
                    ModelState.AddModelError(string.Empty, error);

                return View(vm);
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

            var vm = new CinemaCreateEditViewModel
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Description = cinema.Description,
                Email = cinema.Email,
                Phone = cinema.Phone,
                Address = cinema.Address,
                City = cinema.City,
                State = cinema.State,
                Country = cinema.Country,
                PostalCode = cinema.PostalCode,
                Website = cinema.Website,
                ImageUrl = cinema.ImageUrl,
                IsActive = cinema.IsActive,
                TotalSeats = cinema.TotalSeats
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CinemaCreateEditViewModel vm, CancellationToken cancellationToken)
        {
            if (id != vm.Id) return BadRequest();

            if (!ModelState.IsValid)
                return View(vm);

            var cinema = new Cinema
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                Email = vm.Email,
                Phone = vm.Phone,
                Address = vm.Address,
                City = vm.City,
                State = vm.State,
                Country = vm.Country,
                PostalCode = vm.PostalCode,
                Website = vm.Website,
                ImageUrl = vm.ImageUrl,
                IsActive = vm.IsActive,
            };

            var errors = await _cinemaService.UpdateCinemaAsync(cinema, cancellationToken);
            if (errors.Any())
            {
                foreach (var error in errors)
                    ModelState.AddModelError(string.Empty, error);

                return View(vm);
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Activate / Deactivate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id, CancellationToken cancellationToken)
        {
            var cinema = await _cinemaService.GetByIdAsync(id, cancellationToken);
            if (cinema == null) return NotFound();

            var result = await _cinemaService.SetCinemaStatusAsync(id, !cinema.IsActive, cancellationToken);
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
