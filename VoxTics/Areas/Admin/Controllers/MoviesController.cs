using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Movie;
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
            ViewBag.IsActiveOptions = new SelectList(new[]
{
    new { Value = "", Text = "All" },
    new { Value = "true", Text = "Active" },
    new { Value = "false", Text = "Inactive" }
}, "Value", "Text");
            ViewBag.StatusOptions = new SelectList(new[]
{
    new { Value = "", Text = "All" },
    new { Value = ((int)MovieStatus.Upcoming).ToString(), Text = "Upcoming" },
    new { Value = ((int)MovieStatus.NowShowing).ToString(), Text = "Now Showing" },
    new { Value = ((int)MovieStatus.Ended).ToString(), Text = "Ended" },
    new { Value = ((int)MovieStatus.Cancelled).ToString(), Text = "Cancelled" }
}, "Value", "Text".ToString());

            // Map entities to view models
            var movieViewModels = movies.Select(m => new MovieListItemViewModel(m)).ToList();

            return View(movieViewModels);
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
        public IActionResult Create()
        {
            var model = new MovieCreateEditViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieCreateEditViewModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(model);

            var movie = new Movie
            {
                Title = model.Title,
                Description = model.Description,
                Director = model.Director,
                ReleaseDate = model.ReleaseDate,
                Language = model.Language,
                Rating = model.Rating,
                Duration = model.Duration,
                Price = model.Price,
                IsFeatured = model.IsFeatured,
                TrailerUrl = model.TrailerUrl,
                ImageUrl = model.PosterImage
                // Map actors, categories, images if needed
            };

            var errors = await _movieService.AddMovieAsync(movie, cancellationToken);
            if (errors.Any())
            {
                foreach (var err in errors) ModelState.AddModelError(string.Empty, err);
                return View(model);
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
          
            var model = new MovieCreateEditViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Director = movie.Director,
                ReleaseDate = movie.ReleaseDate,
                Language = movie.Language,
                Rating = movie.Rating,
                Duration = movie.Duration,
                Price = movie.Price,
                IsFeatured = movie.IsFeatured,
                TrailerUrl = movie.TrailerUrl,
                PosterImage = movie.ImageUrl,
                SelectedActorIds = movie.MovieActors?.Select(a => a.Id).ToList() ?? new List<int>(),
                SelectedCategoryIds = movie.MovieCategories?.Select(c => c.Id).ToList() ?? new List<int>(),
                ImageUrls = movie.MovieImages?.Select(i => i.ImageUrl.ToString()).ToList() ?? new List<string>()
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieCreateEditViewModel model, CancellationToken cancellationToken)
        {
            if (id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);

            var movie = await _movieService.GetByIdAsync(id, cancellationToken);
            if (movie == null) return NotFound();

            // Map values from ViewModel to entity
            movie.Title = model.Title;
            movie.Description = model.Description;
            movie.Director = model.Director;
            movie.ReleaseDate = model.ReleaseDate;
            movie.Language = model.Language;
            movie.Rating = model.Rating;
            movie.Duration = model.Duration;
            movie.Price = model.Price;
            movie.IsFeatured = model.IsFeatured;
            movie.TrailerUrl = model.TrailerUrl;
            movie.ImageUrl = model.PosterImage;
            // You may need to handle actors, categories, images separately

            var errors = await _movieService.UpdateMovieAsync(movie, cancellationToken);
            if (errors.Any())
            {
                foreach (var err in errors) ModelState.AddModelError(string.Empty, err);
                return View(model);
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
