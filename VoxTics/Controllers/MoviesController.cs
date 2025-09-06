using System.Diagnostics;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Helpers;
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

        public MoviesController(
            IMovieRepository movieRepo,
            IMapper mapper,
            ILogger<MoviesController> logger,
            IWebHostEnvironment env)
        {
            _movieRepo = movieRepo;
            _mapper = mapper;
            _logger = logger;
            _env = env;
        }

        // GET: /Movies
        public async Task<IActionResult> Index(string? search, int? categoryId, int pageIndex = 1, int pageSize = 8)
        {
            var query = _movieRepo.Query(includeProperties: "MovieCategories.Category,MovieActors.Actor,Images,Showtimes");

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(m => m.Title.Contains(search) || m.Description.Contains(search));

            if (categoryId.HasValue)
                query = query.Where(m => m.MovieCategories.Any(mc => mc.CategoryId == categoryId.Value));

            var projected = query.OrderBy(m => m.Title).ProjectTo<MovieVM>(_mapper.ConfigurationProvider);

            var paged = await PaginatedList<MovieVM>.CreateAsync(projected, pageIndex, pageSize);

            paged.RouteValues = new Dictionary<string, object>
            {
                ["search"] = search ?? string.Empty,
                ["categoryId"] = categoryId ?? 0
            };

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_MovieCards", paged);

            return View(paged);
        }
        // GET: /Movies/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
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
