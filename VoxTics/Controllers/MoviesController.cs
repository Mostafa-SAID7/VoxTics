using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.Enums;
using VoxTics.Services.Interfaces;

namespace VoxTics.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(
            int page = 1,
            int pageSize = 10,
            string? search = null,
            MovieStatus? status = null,
            string? sort = null,
            CancellationToken cancellationToken = default)
        {
            var movies = await _movieService.GetPagedMoviesAsync(page, pageSize, search, status, sort, cancellationToken);
            return View(movies);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Featured(CancellationToken cancellationToken)
        {
            var featured = await _movieService.GetFeaturedMoviesAsync(cancellationToken);
            return View(featured);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var movie = await _movieService.GetMovieDetailsAsync(id, cancellationToken);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ByCategory(int categoryId, CancellationToken cancellationToken)
        {
            var movies = await _movieService.GetMoviesByCategoryAsync(categoryId, cancellationToken);
            return View(movies);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ByReleaseDate(DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var movies = await _movieService.GetMoviesByReleaseDateRangeAsync(startDate, endDate, cancellationToken);
            return View(movies);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Search(string keyword, CancellationToken cancellationToken)
        {
            var movies = await _movieService.SearchMoviesAsync(keyword, cancellationToken);
            return View(movies);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> TopRated(int count = 10, CancellationToken cancellationToken = default)
        {
            var movies = await _movieService.GetTopRatedMoviesAsync(count, cancellationToken);
            return View(movies);
        }
    }
}
