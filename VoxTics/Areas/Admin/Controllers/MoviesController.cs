using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(
            IMovieRepository movieRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment,
            ILogger<MoviesController> logger)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        // GET: Admin/Movies
        public async Task<IActionResult> Index(string? searchTerm = null, int categoryId = 0,
            int page = 1, int pageSize = 10, string? sortBy = "createdat", SortOrder sortOrder = SortOrder.Desc)
        {
            try
            {
                var filter = new BasePaginatedFilterVM
                {
                    PageNumber = page,
                    PageSize = pageSize,
                    SearchTerm = searchTerm,
                    SortBy = sortBy,
                    SortOrder = sortOrder
                };

                // Use the admin paging helper from repository
                var (movies, totalCount) = await _movieRepository.GetPagedMoviesForAdminAsync(filter);

                // Map results
                var mapped = movies.Select(m => _mapper.Map<MovieViewModel>(m)).ToList();
                var paged = new PaginatedList<MovieViewModel>(mapped, totalCount, page, pageSize);

                // categories for filters
                var categories = await _categoryRepository.GetAllAsync(null);
                var categoryVms = _mapper.Map<List<CategoryViewModel>>(categories);

                var vm = new MovieViewModel
                {
                    Movies = paged,
                    Categories = categoryVms,
                    SearchTerm = searchTerm,
                    SelectedCategoryId = categoryId,
                    CurrentPage = page,
                    PageSize = pageSize,
                    SortBy = sortBy ?? "createdat",
                    SortDescending = sortOrder == SortOrder.Desc
                };

                // Populate AvailableCategories for drop-down (used in Create/Edit forms if needed)
                vm.AvailableCategories = categoryVms.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                    Selected = c.Id == categoryId
                }).ToList();

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("_MoviesTable", vm);
                }

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading movies index page");
                TempData["Error"] = "Error loading movies data";
                return View(new MovieViewModel());
            }
        }

        // GET: Admin/Movies/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var movie = await _movieRepository.GetMovieWithDetailsAsync(id);
                if (movie == null) return NotFound();

                var vm = _mapper.Map<MovieViewModel>(movie);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return PartialView("_DetailsPartial", vm);

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading movie details for ID {MovieId}", id);
                TempData["Error"] = "Error loading movie details";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Admin/Movies/Create
        public async Task<IActionResult> Create()
        {
            var vm = new MovieViewModel
            {
                ReleaseDate = DateTime.Today,
                Status = VoxTics.Models.Enums.MovieStatus.Upcoming
            };

            await PopulateCategoriesAsync(vm);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_Create", vm);

            return PartialView("_Create", vm);
        }

        // POST: Admin/Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await PopulateCategoriesAsync(viewModel);
                    return View(viewModel);
                }

                // title unique check (use repository method that exists)
                var ok = await _movieRepository.IsMovieTitleUniqueAsync(viewModel.Title, null);
                if (!ok)
                {
                    ModelState.AddModelError(nameof(viewModel.Title), "A movie with this title already exists.");
                    await PopulateCategoriesAsync(viewModel);
                    return View(viewModel);
                }

                var movie = _mapper.Map<Movie>(viewModel);

                // copy/ensure duration mapping if property names differ (safe fallback)
                // e.g. if entity has DurationMinutes but VM has DurationInMinutes
                var durProp = movie.GetType().GetProperty("DurationMinutes");
                if (durProp != null)
                {
                    durProp.SetValue(movie, viewModel.DurationInMinutes);
                }

                // handle poster upload
                if (viewModel.PosterImageFile != null)
                {
                    var imagePath = await SaveImageAsync(viewModel.PosterImageFile, "movies");
                    movie.ImageUrl = imagePath;
                }

                movie.CreatedAt = DateTime.UtcNow;
                movie.UpdatedAt = DateTime.UtcNow;

                var added = await _movieRepository.AddAsync(movie);
                await _movieRepository.SaveChangesAsync();

                // update categories (repo methods handle persistence)
                await UpdateMovieCategoriesAsync(added.Id, viewModel.SelectedCategoryIds);

                _logger.LogInformation("Movie created with id {MovieId}", added.Id);
                TempData["Success"] = "Movie created successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating movie");
                ModelState.AddModelError("", "Error creating movie");
                await PopulateCategoriesAsync(viewModel);
                return View(viewModel);
            }
        }

        // GET: Admin/Movies/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var movie = await _movieRepository.GetMovieWithDetailsAsync(id) ?? await _movieRepository.GetByIdAsync(id);
                if (movie == null) return NotFound();

                var vm = _mapper.Map<MovieViewModel>(movie);

                // ensure duration field on vm is set (if mapping didn't)
                vm.DurationInMinutes = vm.DurationInMinutes == 0
                    ? (int?)movie.GetType().GetProperty("DurationMinutes")?.GetValue(movie) ?? vm.DurationInMinutes
                    : vm.DurationInMinutes;

                // selected categories from relation
                var categories = await _movieRepository.GetMovieCategoriesAsync(id);
                vm.SelectedCategoryIds = categories.Select(c => c.Id).ToList();

                await PopulateCategoriesAsync(vm);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return PartialView("_Edit", vm);

                return PartialView("_Edit", vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading edit form for movie id {MovieId}", id);
                TempData["Error"] = "Error loading edit form";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Admin/Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieViewModel viewModel)
        {
            if (id != viewModel.Id) return BadRequest();

            try
            {
                if (!ModelState.IsValid)
                {
                    await PopulateCategoriesAsync(viewModel);
                    return View(viewModel);
                }

                var existing = await _movieRepository.GetByIdAsync(id);
                if (existing == null) return NotFound();

                // title uniqueness excluding current movie
                var unique = await _movieRepository.IsMovieTitleUniqueAsync(viewModel.Title, id);
                if (!unique)
                {
                    ModelState.AddModelError(nameof(viewModel.Title), "A movie with this title already exists.");
                    await PopulateCategoriesAsync(viewModel);
                    return View(viewModel);
                }

                // preserve old image path
                var oldImage = existing.ImageUrl;

                // map fields from VM to entity
                _mapper.Map(viewModel, existing);

                // ensure duration mapping if properties differ
                var durProp = existing.GetType().GetProperty("DurationMinutes");
                if (durProp != null)
                {
                    durProp.SetValue(existing, viewModel.DurationInMinutes);
                }

                // handle new poster
                if (viewModel.PosterImageFile != null)
                {
                    var newPath = await SaveImageAsync(viewModel.PosterImageFile, "movies");
                    existing.ImageUrl = newPath;

                    if (!string.IsNullOrWhiteSpace(oldImage))
                    {
                        DeleteImage(oldImage);
                    }
                }

                existing.UpdatedAt = DateTime.UtcNow;

                await _movieRepository.UpdateAsync(existing);
                await _movieRepository.SaveChangesAsync();

                // update categories
                await UpdateMovieCategoriesAsync(id, viewModel.SelectedCategoryIds);

                _logger.LogInformation("Movie updated id {MovieId}", id);
                TempData["Success"] = "Movie updated successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating movie id {MovieId}", id);
                ModelState.AddModelError("", "Error updating movie");
                await PopulateCategoriesAsync(viewModel);
                return View(viewModel);
            }
        }

        // GET: Admin/Movies/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null) return NotFound();

            var vm = _mapper.Map<MovieViewModel>(movie);
            return PartialView("_Delete", vm);
        }

        // POST: Admin/Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var movie = await _movieRepository.GetByIdAsync(id);
                if (movie == null) return NotFound();

                var hasRelated = await _movieRepository.HasRelatedDataAsync(id);
                if (hasRelated)
                {
                    TempData["Error"] = "Cannot delete movie. It has associated data (showtimes/bookings/etc).";
                    return RedirectToAction(nameof(Index));
                }

                var imagePath = movie.ImageUrl;

                await _movieRepository.DeleteAsync(movie);
                await _movie_repository_SaveChanges();

                if (!string.IsNullOrWhiteSpace(imagePath))
                {
                    DeleteImage(imagePath);
                }

                _logger.LogInformation("Movie deleted id {MovieId}", id);
                TempData["Success"] = "Movie deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting movie id {MovieId}", id);
                TempData["Error"] = "Error deleting movie";
                return RedirectToAction(nameof(Index));
            }

            // local helper to avoid duplicate await lines (keeps code DRY)
            async Task _movie_repository_SaveChanges()
            {
                await _movieRepository.SaveChangesAsync();
            }
        }

        // POST: Admin/Movies/ToggleStatus/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            try
            {
                var movie = await _movieRepository.GetByIdAsync(id);
                if (movie == null) return Json(new { success = false, message = "Movie not found" });

                movie.Status = movie.Status switch
                {
                    VoxTics.Models.Enums.MovieStatus.Upcoming => VoxTics.Models.Enums.MovieStatus.NowShowing,
                    VoxTics.Models.Enums.MovieStatus.NowShowing => VoxTics.Models.Enums.MovieStatus.EndedShowing,
                    VoxTics.Models.Enums.MovieStatus.EndedShowing => VoxTics.Models.Enums.MovieStatus.Upcoming,
                    _ => VoxTics.Models.Enums.MovieStatus.Upcoming
                };

                movie.UpdatedAt = DateTime.UtcNow;

                await _movieRepository.UpdateAsync(movie);
                await _movieRepository.SaveChangesAsync();

                _logger.LogInformation("Movie status toggled id {MovieId} -> {Status}", id, movie.Status);
                return Json(new { success = true, newStatus = movie.Status.ToString() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error toggling status for movie {MovieId}", id);
                return Json(new { success = false, message = "Error updating status" });
            }
        }

        // POST: Admin/Movies/BulkDelete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BulkDelete(List<int> movieIds)
        {
            if (movieIds == null || !movieIds.Any())
                return Json(new { success = false, message = "No movies selected" });

            var deleted = 0;
            var errors = new List<string>();

            foreach (var id in movieIds)
            {
                try
                {
                    var movie = await _movieRepository.GetByIdAsync(id);
                    if (movie == null) continue;

                    if (await _movieRepository.HasRelatedDataAsync(id))
                    {
                        errors.Add($"'{movie.Title}' has related data and cannot be deleted");
                        continue;
                    }

                    var imagePath = movie.ImageUrl;
                    await _movieRepository.DeleteAsync(movie);
                    await _movieRepository.SaveChangesAsync();

                    if (!string.IsNullOrWhiteSpace(imagePath))
                        DeleteImage(imagePath);

                    deleted++;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error deleting movie id {Id}", id);
                    errors.Add($"Error deleting movie id {id}");
                }
            }

            var message = $"{deleted} movie(s) deleted.";
            if (errors.Any()) message += $" {errors.Count} failed.";

            return Json(new { success = true, message, deletedCount = deleted, errors });
        }

        #region Private Helpers

        private async Task<string> SaveImageAsync(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0) return string.Empty;

            var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowed.Contains(ext)) throw new InvalidOperationException("Invalid image type.");

            if (file.Length > 5 * 1024 * 1024) throw new InvalidOperationException("Image too large (max 5MB).");

            var filename = $"{Guid.NewGuid()}{ext}";
            var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", folder);
            if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

            var full = Path.Combine(uploads, filename);
            using (var fs = new FileStream(full, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            return $"/uploads/{folder}/{filename}";
        }

        private void DeleteImage(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath)) return;

            var full = Path.Combine(_webHostEnvironment.WebRootPath, imagePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
            try
            {
                if (System.IO.File.Exists(full)) System.IO.File.Delete(full);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting image {ImagePath}", imagePath);
            }
        }

        private async Task PopulateCategoriesAsync(MovieViewModel vm)
        {
            var categories = await _categoryRepository.GetAllAsync(null);
            vm.AvailableCategories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = vm.SelectedCategoryIds.Contains(c.Id)
            }).ToList();
        }

        private async Task UpdateMovieCategoriesAsync(int movieId, List<int> categoryIds)
        {
            // Get current categories
            var current = (await _movieRepository.GetMovieCategoriesAsync(movieId)).Select(c => c.Id).ToList();

            // Remove ones that are no longer selected
            var toRemove = current.Except(categoryIds ?? new List<int>()).ToList();
            foreach (var catId in toRemove)
            {
                await _movieRepository.RemoveMovieCategoryAsync(movieId, catId);
            }

            // Add new ones
            var toAdd = (categoryIds ?? new List<int>()).Except(current).ToList();
            foreach (var catId in toAdd)
            {
                await _movieRepository.AddMovieCategoryAsync(movieId, catId);
            }
        }

        #endregion
    }
}
