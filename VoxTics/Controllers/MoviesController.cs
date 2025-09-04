// Controllers/MoviesController.cs
using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;      // IWebHostEnvironment
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<MoviesController> _logger;
        private readonly IWebHostEnvironment _env;

        public MoviesController(IMovieRepository movieRepo, IMapper mapper, ILogger<MoviesController> logger, IWebHostEnvironment env)
        {
            _movieRepo = movieRepo;
            _mapper = mapper;
            _logger = logger;
            _env = env;
        }

        public async Task<IActionResult> Index(string? search, int? categoryId, int page = 1, int pageSize = 8)
        {
            try
            {
                var query = _movieRepo.Query("MovieCategories.Category,MovieActors.Actor,Images,Showtimes");
                if (query == null) throw new InvalidOperationException("MovieRepository.Query returned null");

                if (!string.IsNullOrWhiteSpace(search))
                    query = query.Where(m => m.Title.Contains(search) || m.Description.Contains(search));

                if (categoryId.HasValue)
                    query = query.Where(m => m.MovieCategories.Any(mc => mc.CategoryId == categoryId.Value));

                var paginated = await PaginatedList<Movie>.CreateAsync(query.OrderBy(m => m.Title), page, pageSize);
                var vmList = paginated.Select(m => _mapper.Map<MovieVM>(m)).ToList();

                ViewData["Search"] = search;
                ViewData["CategoryId"] = categoryId;
                ViewData["Paginated"] = paginated;

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return PartialView("~/Views/Movies/_MovieCards.cshtml", vmList);

                return View(vmList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Movies.Index error");
                // TEMPORARY: show full exception in browser while debugging
                if (_env.IsDevelopment())
                {
                    return Content($"Exception: {ex}\n\nStackTrace:\n{ex.StackTrace}", "text/plain");
                }

                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        // GET: /Movies/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                // Ensure your repo GetByIdAsync includes related data
                var movie = await _movieRepo.GetByIdAsync(id, "MovieCategories.Category,MovieActors.Actor,Images,Showtimes");
                if (movie == null) return NotFound();

                var vm = _mapper.Map<MovieVM>(movie);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return PartialView("~/Views/Movies/_DetailsPartial.cshtml", vm);

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Movies.Details error (id={MovieId})", id);
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
            }
        }
    }
}
