using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoviesController : Controller
    {
        private readonly IAdminMovieService _movieService;

        public MoviesController(IAdminMovieService movieService)
        {
            _movieService = movieService;
        }

        #region List / Paging

        public async Task<IActionResult> Index(string? searchTerm, int pageIndex = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var (movies, totalCount) = await _movieService.GetPagedMoviesAsync(pageIndex - 1, pageSize, searchTerm, cancellationToken);

            ViewBag.TotalCount = totalCount;
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;

            return View(movies.ToList());
        }

        #endregion

        #region Details

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var movie = await _movieService.GetByIdAsync(id, cancellationToken);
            if (movie == null) return NotFound();

            return View(movie);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(movie);

            var errors = await _movieService.AddMovieAsync(movie, cancellationToken);
            if (errors.Any())
            {
                foreach (var err in errors) ModelState.AddModelError(string.Empty, err);
                return View(movie);
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var movie = await _movieService.GetByIdAsync(id, cancellationToken);
            if (movie == null) return NotFound();

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie, CancellationToken cancellationToken)
        {
            if (id != movie.Id) return BadRequest();

            if (!ModelState.IsValid)
                return View(movie);

            var errors = await _movieService.UpdateMovieAsync(movie, cancellationToken);
            if (errors.Any())
            {
                foreach (var err in errors) ModelState.AddModelError(string.Empty, err);
                return View(movie);
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _movieService.DeleteMovieAsync(id, cancellationToken);
            if (!result) return BadRequest("Movie not found or could not be deleted.");

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
