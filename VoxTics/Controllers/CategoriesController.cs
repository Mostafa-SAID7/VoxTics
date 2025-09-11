using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesRepository _categoryRepository;
        private readonly IMoviesRepository _movieRepository;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(
            ICategoriesRepository categoryRepository,
            IMoviesRepository movieRepository,
            ILogger<CategoriesController> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
            _logger = logger;
        }

        // GET: /Categories
        public async Task<IActionResult> Index(string? searchTerm)
        {
            try
            {
                IEnumerable<Category> categories;

                if (!string.IsNullOrWhiteSpace(searchTerm))
                    categories = await _categoryRepository.SearchAsync(searchTerm);
                else
                    categories = await _categoryRepository.GetAllAsync();

                var withCounts = await _categoryRepository.GetAllWithMovieCountsAsync();

                var vms = withCounts.Select(x => new CategoryVM
                {
                    Id = x.category.Id,
                    Name = x.category.Name,
                    Description = x.category.Description,
                    MovieCount = x.movieCount
                }).ToList();

                return View(vms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading categories");
                TempData["Error"] = "Unable to load categories.";
                return View(new List<CategoryVM>());
            }
        }

        // GET: /Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryWithMoviesAsync(id);
                if (category == null) return NotFound();

                var vm = new CategoryVM
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    MovieCount = category.MovieCategories?.Count ?? 0,
                    Movies = category.MovieCategories?
                        .Select(mc => new MovieVM
                        {
                            Id = mc.Movie.Id,
                            Title = mc.Movie.Title,
                            Description = mc.Movie.Description,
                            PosterImage = mc.Movie.ImageUrl,
                            ReleaseDate = mc.Movie.ReleaseDate,
                            DurationInMinutes = mc.Movie.Duration
                        }).ToList() ?? new List<MovieVM>()
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading category {CategoryId}", id);
                TempData["Error"] = "Unable to load category.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: /Categories/BySlug/action
        [Route("categories/{slug}")]
        public async Task<IActionResult> BySlug(string slug)
        {
            try
            {
                var category = await _categoryRepository.GetBySlugAsync(slug);
                if (category == null) return NotFound();

                return RedirectToAction(nameof(Details), new { id = category.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading category by slug {Slug}", slug);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
