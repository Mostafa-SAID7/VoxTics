using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VoxTics.Areas.Admin.Services.Interfaces;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Helpers.ImgsHelper;
using VoxTics.Models.Enums;
using VoxTics.Models.Entities;
using System.Text;
using System.Text.RegularExpressions;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/movies")]
    [Authorize(Roles = $"{SD.SuperAdminRole}")]
    public class MoviesController : Controller
    {
        private readonly IAdminMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly ImageManager _imageManager;

        public MoviesController(
            IAdminMovieService movieService,
            IMapper mapper,
            ICategoryService categoryService,
            ImageManager imageManager)
        {
            _movieService = movieService;
            _mapper = mapper;
            _categoryService = categoryService;
            _imageManager = imageManager;
        }

        #region Index
        [HttpGet("")]
        public async Task<IActionResult> Index(int page = 1, string? search = null, string? sortColumn = null, bool sortDescending = false)
        {
            const int pageSize = 10;
            var pagedMovies = await _movieService.GetPagedMoviesAsync(page, pageSize, search, sortColumn, sortDescending);
            
            ViewBag.CurrentSearch = search;
            ViewBag.SortColumn = sortColumn;
            ViewBag.SortDescending = sortDescending;
            
            return View(pagedMovies);
        }
        #endregion

        #region Details
        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetailsAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }
        #endregion

        #region Create
        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var model = new MovieCreateEditViewModel
            {
                ReleaseDate = DateTime.Today
            };
            await PopulateCategoriesAsync(model);
            return View(model);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateCategoriesAsync(model);
                return View(model);
            }

            // Ensure slug (generate from title if missing)
            EnsureSlug(model);

            try
            {
                // Save main image if provided
                if (model.MainImage != null && model.MainImage.Length > 0)
                {
                    var mainFileName = await _imageManager.SaveImageAsync(model.MainImage, ImageType.Movie, model.Slug, setAsMain: true);
                    model.ExistingPosterUrl = mainFileName;
                }

                // Save additional images if any
                if (model.AdditionalImages != null && model.AdditionalImages.Any())
                {
                    foreach (var file in model.AdditionalImages)
                    {
                        if (file == null || file.Length == 0) continue;
                        var fileName = await _imageManager.SaveImageAsync(file, ImageType.Movie, model.Slug);
                        model.ExistingImageUrls.Add(fileName);
                    }
                }

                await _movieService.CreateMovieAsync(model);
                TempData["Success"] = "Movie created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                // Log exception in real app
                ModelState.AddModelError("", "An unexpected error occurred while creating the movie.");
            }

            await PopulateCategoriesAsync(model);
            return View(model);
        }
        #endregion

        #region Edit
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _movieService.GetByIdAsync(id);
            if (model == null) return NotFound();

            // Populate existing image lists from disk (if service didn't provide them)
            try
            {
                var files = _imageManager.GetImageFileNames(ImageType.Movie, model.Slug);
                model.ExistingImageUrls = files.ToList();
                // If ExistingPosterUrl not set but "main.*" exists, prefer that (optional)
                var main = files.FirstOrDefault(f => Path.GetFileNameWithoutExtension(f).Equals("main", StringComparison.OrdinalIgnoreCase));
                if (!string.IsNullOrEmpty(main)) model.ExistingPosterUrl = main;
            }
            catch
            {
                // ignore image read errors, view will fallback to defaults
            }

            await PopulateCategoriesAsync(model);
            return View(model);
        }

        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieCreateEditViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid)
            {
                await PopulateCategoriesAsync(model);
                return View(model);
            }

            // Ensure slug (if changed or empty)
            EnsureSlug(model);

            try
            {
                // If a new main image is uploaded, save and set as main
                if (model.MainImage != null && model.MainImage.Length > 0)
                {
                    var mainFileName = await _imageManager.SaveImageAsync(model.MainImage, ImageType.Movie, model.Slug, setAsMain: true);
                    model.ExistingPosterUrl = mainFileName;
                }

                // Save additional images if any
                if (model.AdditionalImages != null && model.AdditionalImages.Any())
                {
                    foreach (var file in model.AdditionalImages)
                    {
                        if (file == null || file.Length == 0) continue;
                        var fileName = await _imageManager.SaveImageAsync(file, ImageType.Movie, model.Slug);
                        model.ExistingImageUrls.Add(fileName);
                    }
                }

                var updated = await _movieService.UpdateMovieAsync(model);
                if (!updated) return NotFound();

                TempData["Success"] = "Movie updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An unexpected error occurred while updating the movie.");
            }

            await PopulateCategoriesAsync(model);
            return View(model);
        }
        #endregion

        #region Delete
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieService.GetMovieDetailsAsync(id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        [HttpPost("delete/{id}")]
        [ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // Check for bookings before deleting
                if (await _movieService.MovieHasBookingsAsync(id))
                {
                    TempData["Error"] = "Cannot delete this movie because it has existing bookings.";
                    return RedirectToAction(nameof(Index));
                }

                var deleted = await _movieService.DeleteMovieAsync(id);
                if (!deleted)
                {
                    TempData["Error"] = "Movie not found or could not be deleted.";
                    return RedirectToAction(nameof(Index));
                }

                TempData["Success"] = "Movie deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Error"] = "An unexpected error occurred while deleting the movie.";
                return RedirectToAction(nameof(Index));
            }
        }
        #endregion

        #region Helpers
        private async Task PopulateCategoriesAsync(MovieCreateEditViewModel model)
        {
            var categories = await _category_service_get();
            model.Categories = categories
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList();
        }

        // small wrapper to await _categoryService safely and allow unit testing easily
        private async Task<IEnumerable<Category>> _category_service_get()
        {
            return await _category_service_get_impl();
        }

        private Task<IEnumerable<Category>> _category_service_get_impl()
        {
            return _categoryService.GetActiveCategoriesAsync();
        }

        private void EnsureSlug(MovieCreateEditViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Slug) && !string.IsNullOrWhiteSpace(model.Title))
            {
                model.Slug = GenerateSlug(model.Title);
            }
            // Normalize slug: lower, replace spaces w/ hyphens, remove invalid chars
            model.Slug = GenerateSlug(model.Slug);
        }

        private static string GenerateSlug(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase)) return string.Empty;

            var str = phrase.ToLowerInvariant().Trim();
            // replace spaces with hyphens
            str = Regex.Replace(str, @"\s+", "-");
            // remove invalid chars
            str = Regex.Replace(str, @"[^a-z0-9\-]", "");
            // collapse multiple hyphens
            str = Regex.Replace(str, @"-+", "-").Trim('-');
            // limit length
            return str.Length <= 150 ? str : str.Substring(0, 150);
        }
        #endregion
    }
}
