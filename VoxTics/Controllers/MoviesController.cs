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
                var movies = await _movieRepository.GetAllWithIncludesAsync(m => m.MovieCategories);

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    movies = movies.Where(m => m.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
                }
                if (categoryId.HasValue)
                {
                    movies = movies.Where(m => m.MovieCategories.Any(mc => mc.CategoryId == categoryId.Value));
                }
                var vm = movies.Select(m => new MovieVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    PosterImage = m.ImageUrl,
                    ReleaseDate = m.ReleaseDate,
                    Status = m.Status,
                    Categories = m.MovieCategories.Select(mc => mc.Category.Name).ToList(),
                    CategoryNames = string.Join(", ", m.MovieCategories.Select(mc => mc.Category.Name))
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
                var movie = await _movieRepository.GetByIdWithIncludesAsync(id, m => m.MovieCategories, m => m.MovieActors);

                if (movie == null)
                {
                    return NotFound();
                }

                

                var vm = new MovieVM
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    BasePrice = movie.Price,
                    DurationInMinutes = movie.DurationMinutes,
                    ReleaseDate = movie.ReleaseDate,
                    Director = movie.Director,
                    Language = movie.Language,
                    Country = movie.Country,
                    AgeRating = movie.AgeRating,
                    TrailerUrl = movie.TrailerImageUrl,
                    PosterImage = movie.ImageUrl,
                    Status = movie.Status,
                    Categories = movie.MovieCategories.Select(mc => mc.Category.Name).ToList(),
                    CategoryNames = string.Join(", ", movie.MovieCategories.Select(mc => mc.Category.Name)),
                    Actors = movie.MovieActors.Select(ma => new ActorVM
                    {
                        Id = ma.Actor.Id,
                        FirstName = ma.Actor.FullName,
                        ImageUrl = ma.Actor.ImageUrl
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
                var category = await _categoryRepository.GetByIdWithIncludesAsync(id, c => c.MovieCategories);

                if (category == null)
                {
                    return NotFound();
                }

                var vm = category.MovieCategories.Select(mc => new MovieVM
                {
                    Id = mc.Movie.Id,
                    Title = mc.Movie.Title,
                    Description = mc.Movie.Description,
                    PosterImage = mc.Movie.ImageUrl,
                    ReleaseDate = mc.Movie.ReleaseDate,
                    Status = mc.Movie.Status,
                    Categories = mc.Movie.MovieCategories.Select(x => x.Category.Name).ToList(),
                    CategoryNames = string.Join(", ", mc.Movie.MovieCategories.Select(x => x.Category.Name))
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
