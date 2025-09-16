using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShowtimesController : Controller
    {
        private readonly IAdminShowtimeService _showtimeService;

        public ShowtimesController(IAdminShowtimeService showtimeService)
        {
            _showtimeService = showtimeService;
        }

        #region List / Paging

        public async Task<IActionResult> Index(string? searchTerm, int pageIndex = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var (showtimes, totalCount) = await _showtimeService.GetPagedShowtimesAsync(pageIndex - 1, pageSize, searchTerm, cancellationToken);

            ViewBag.TotalCount = totalCount;
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;

            return View(showtimes.ToList());
        }

        #endregion

        #region Details

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var showtime = await _showtimeService.GetByIdAsync(id, cancellationToken);
            if (showtime == null) return NotFound();

            return View(showtime);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Showtime showtime, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(showtime);

            var errors = await _showtimeService.AddShowtimeAsync(showtime, cancellationToken);
            if (errors.Any())
            {
                foreach (var err in errors) ModelState.AddModelError(string.Empty, err);
                return View(showtime);
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var showtime = await _showtimeService.GetByIdAsync(id, cancellationToken);
            if (showtime == null) return NotFound();

            return View(showtime);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Showtime showtime, CancellationToken cancellationToken)
        {
            if (id != showtime.Id) return BadRequest();

            if (!ModelState.IsValid)
                return View(showtime);

            var errors = await _showtimeService.UpdateShowtimeAsync(showtime, cancellationToken);
            if (errors.Any())
            {
                foreach (var err in errors) ModelState.AddModelError(string.Empty, err);
                return View(showtime);
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _showtimeService.DeleteShowtimeAsync(id, cancellationToken);
            if (!result) return BadRequest("Showtime not found or could not be deleted.");

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
