using Microsoft.AspNetCore.Mvc;
using VoxTics.Helpers.ImgsHelper;
using VoxTics.Models.ViewModels.Movie;
using VoxTics.Services.Interfaces;

namespace VoxTics.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ImageManager _imgManager;

        public MoviesController(IMovieService movieService, ImageManager imgManager)
        {
            _movieService = movieService;
            _imgManager = imgManager;
        }

        // Index Page: List Movies
        public async Task<IActionResult> Index(
            int page = 1,
            int pageSize = 10,
            string? search = null,
            string? sortColumn = null,
            bool sortDesc = false)
        {
            var pagedMovies = await _movieService.GetPagedAsync(page, pageSize, search, sortColumn, sortDesc);

            ViewData["CurrentSearch"] = search;
            ViewData["CurrentSort"] = sortColumn;
            ViewData["SortDesc"] = sortDesc;

            return View(pagedMovies);
        }

        // Details Page
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetDetailsAsync(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }
    }
}
