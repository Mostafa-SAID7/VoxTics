using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Services.Interfaces;
using VoxTics.Areas.Admin.ViewModels.Movie;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/movies")]
    public class AdminMovieController : Controller
    {
        private readonly IAdminMovieService _movieService;
        private readonly IMapper _mapper;

        public AdminMovieController(IAdminMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        // 🔹 List movies with pagination, search & sorting
        [HttpGet("")]
        public async Task<IActionResult> Index(int page = 1, string? search = null, string? sortColumn = null, bool sortDescending = false)
        {
            const int pageSize = 10;

            var movies = await _movieService.GetPagedMoviesAsync(
                page, pageSize, search, sortColumn, sortDescending);

            return View(movies);
        }

        // 🔹 Show create movie form
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(new MovieCreateEditViewModel());
        }

        // 🔹 Handle create movie POST
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var movieId = await _movieService.CreateMovieAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // 🔹 Show edit movie form
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();

            var model = _mapper.Map<MovieCreateEditViewModel>(movie);
            return View(model);
        }

        // 🔹 Handle edit movie POST
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieCreateEditViewModel model)
        {
            if (id != model.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(model);

            var result = await _movieService.UpdateMovieAsync(model);
            if (!result) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // 🔹 Show movie details
        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetailsAsync(id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        // 🔹 Delete movie
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _movieService.DeleteMovieAsync(id);
            if (!result) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
