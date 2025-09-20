using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VoxTics.Areas.Admin.Services.Interfaces;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Services;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/movies")]
    public class MoviesController : Controller
    {
        private readonly IAdminMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public MoviesController(IAdminMovieService movieService, IMapper mapper, ICategoryService categoryService)
        {
            _movieService = movieService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int page = 1, string? search = null, string? sortColumn = null, bool sortDescending = false)
        {
            const int pageSize = 10;
            var movies = await _movieService.GetPagedMoviesAsync(page, pageSize, search, sortColumn, sortDescending);
            return View(movies);
        }
        private async Task PopulateCategoriesAsync(MovieCreateEditViewModel model)
        {
            var categories = await _categoryService.GetActiveCategoriesAsync(); // your category service
            model.Categories = categories
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList();
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var model = new MovieCreateEditViewModel();
            await PopulateCategoriesAsync(model);
            return View("create", model);
        }
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieCreateEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            await _movieService.CreateMovieAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();

            var model = movie;
            await PopulateCategoriesAsync(model);
            return View("Edit", movie);
        }

        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieCreateEditViewModel model)
        {
            if (id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);

            var updated = await _movieService.UpdateMovieAsync(model);
            if (!updated) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetailsAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _movieService.DeleteMovieAsync(id);

                if (!result) return NotFound();

                TempData["Message"] = "The movie was successfully deleted.";
            }
            catch (InvalidOperationException ex)
            {
  
                TempData["Error"] = ex.Message;
            }
            catch
            {
                TempData["Error"] = "An error occurred while trying to delete the movie.";
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
