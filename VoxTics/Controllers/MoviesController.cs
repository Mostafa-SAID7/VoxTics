using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(
            IMovieRepository movieRepository,
            ICategoryRepository categoryRepository,
            ILogger<MoviesController> logger)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        // GET: /Movies
        public async Task<IActionResult> Index(string? searchTerm, int? categoryId)
        {
            try
            {
                var movies = await _movieRepository.GetAllWithIncludesAsync(m => m.Categories);

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    movies = movies.Where(m => m.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
                }

                if (categoryId.HasValue)
                {
                    movies = movies.Where(m => m.Categories.Any(c => c.Id == categoryId.Value));
                }

                var vm = movies.Select(m => new MovieVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    BasePrice = m.BasePrice,
                    DurationInMinutes = m.Duration,
                    ReleaseDate = m.ReleaseDate,
                    PosterImage = m.PosterUrl,
                    Status = m.Status,
                    IsUpcoming = m.Status == Models.Enums.MovieStatus.Upcoming,
                    IsNowShowing = m.Status == Models.Enums.MovieStatus.NowShowing,
                    IsEndedShowing = m.Status == Models.Enums.MovieStatus.EndedShowing,
                    AverageRating = m.AverageRating,
                    TotalRatings = m.TotalRatings,
                    ViewCount = m.ViewCount,
                    BookingCount = m.BookingCount,
                    Categories = m.Categories.Select(c => c.Name).ToList(),
                    CategoryNames = string.Join(", ", m.Categories.Select(c => c.Name))
                }).ToList();

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching movies");
                TempData["Error"] = "Unable to load movies.";
                return View(Enumerable.Empty<MovieVM>());
            }
        }

        // GET: /Movies/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var movie = await _movieRepository.GetByIdWithIncludesAsync(id, m => m.MovieCategories, m => m.Actors);

                if (movie == null)
                {
                    return NotFound();
                }

                var vm = new MovieVM
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    BasePrice = movie.BasePrice,
                    DurationInMinutes = movie.Duration,
                    ReleaseDate = movie.ReleaseDate,
                    Director = movie.Director,
                    Language = movie.Language,
                    Country = movie.Country,
                    Rating = movie.Rating,
                    AgeRating = movie.AgeRating,
                    TrailerUrl = movie.TrailerUrl,
                    PosterImage = movie.PosterUrl,
                    Status = movie.Status,
                    AverageRating = movie.AverageRating,
                    TotalRatings = movie.TotalRatings,
                    ViewCount = movie.ViewCount,
                    BookingCount = movie.BookingCount,
                    Categories = movie.Categories.Select(c => c.Name).ToList(),
                    CategoryNames = string.Join(", ", movie.Categories.Select(c => c.Name)),
                    Actors = movie.Actors.Select(a => new ActorVM
                    {
                        Id = a.Id,
                        FirstName = a.FullName,
                        ImageUrl = a.ProfileImage
                    }).ToList()
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching movie details for id={id}");
                TempData["Error"] = "Unable to load movie details.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: /Movies/ByCategory/3
        public async Task<IActionResult> ByCategory(int id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdWithIncludesAsync(id, c => c.Movies);

                if (category == null)
                {
                    return NotFound();
                }

                var vm = category.Movies.Select(m => new MovieVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    PosterImage = m.PosterUrl,
                    ReleaseDate = m.ReleaseDate,
                    Status = m.Status,
                    Categories = m.Categories.Select(c => c.Name).ToList(),
                    CategoryNames = string.Join(", ", m.Categories.Select(c => c.Name))
                }).ToList();

                ViewBag.CategoryName = category.Name;
                return View("Index", vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching movies by category id={id}");
                TempData["Error"] = "Unable to load category movies.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
