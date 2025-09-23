using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VoxTics.Areas.Admin.Services.Interfaces;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/movies")]
    [Authorize(Roles = $"{SD.SuperAdminRole}")]
    public class MoviesController : Controller
    {
        private readonly IAdminMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public MoviesController(
            IAdminMovieService movieService,
            IMapper mapper,
            ICategoryService categoryService)
        {
            _movieService = movieService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        #region Index
        [HttpGet("")]
        public async Task<IActionResult> Index(int page = 1, string? search = null, string? sortColumn = null, bool sortDescending = false)
        {
            const int pageSize = 10;
            var pagedMovies = await _movieService.GetPagedMoviesAsync(page, pageSize, search, sortColumn, sortDescending);
            return View(pagedMovies);
        }
        #endregion

        #region Details
        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetailsAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }
        #endregion

        #region Create
        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var model = new MovieCreateEditViewModel();
            await PopulateCategoriesAsync(model);
            return View(model);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateCategoriesAsync(model);
                return View(model);
            }

            try
            {
                await _movieService.CreateMovieAsync(model);
                TempData["Success"] = "Movie created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                await PopulateCategoriesAsync(model);
                return View(model);
            }
        }
        #endregion

        #region Edit
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _movieService.GetByIdAsync(id);
            if (model == null) return NotFound();

            await PopulateCategoriesAsync(model);
            return View(model);
        }

        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieCreateEditViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid)
            {
                await PopulateCategoriesAsync(model);
                return View(model);
            }

            try
            {
                var updated = await _movieService.UpdateMovieAsync(model);
                if (!updated) return NotFound();

                TempData["Success"] = "Movie updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                await PopulateCategoriesAsync(model);
                return View(model);
            }
        }
        #endregion

        #region Delete
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieService.GetMovieDetailsAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var deleted = await _movieService.DeleteMovieAsync(id);
                if (!deleted) return NotFound();

                TempData["Success"] = "Movie deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
        #endregion

        #region Helpers
        private async Task PopulateCategoriesAsync(MovieCreateEditViewModel model)
        {
            var categories = await _categoryService.GetActiveCategoriesAsync();
            model.Categories = categories
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList();
        }
        #endregion
    }
}
