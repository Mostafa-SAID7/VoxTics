using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public MoviesController(IMovieRepository movieRepo, IMapper mapper, ILogger<MoviesController> logger)
        {
            _movieRepo = movieRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string? search, int? categoryId, int page = 1, int pageSize = 8)
        {
            try
            {
                var query = _movieRepo.Query("MovieCategories.Category,MovieActors.Actor,Images,Showtimes");

                if (!string.IsNullOrWhiteSpace(search))
                    query = query.Where(m => m.Title.Contains(search) || m.Description.Contains(search));

                if (categoryId.HasValue)
                    query = query.Where(m => m.MovieCategories.Any(mc => mc.CategoryId == categoryId.Value));

                var paginated = await PaginatedList<Movie>.CreateAsync(query.OrderBy(m => m.Title), page, pageSize);
                var vmList = paginated.Select(m => _mapper.Map<MovieVM>(m)).ToList();

                ViewData["Search"] = search;
                ViewData["CategoryId"] = categoryId;
                ViewData["Paginated"] = paginated; // if you want to use paging metadata in view

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return PartialView("~/Views/Movies/_MovieCards.cshtml", vmList);

                return View(vmList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Movies.Index error");
                return View("Error");
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieRepo.GetByIdAsync(id, "MovieCategories.Category,MovieActors.Actor,Images,Showtimes");
            if (movie == null) return NotFound();

            var vm = _mapper.Map<MovieVM>(movie);
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("~/Views/Movies/_DetailsPartial.cshtml", vm);
            return View(vm);
        }
    }
}
