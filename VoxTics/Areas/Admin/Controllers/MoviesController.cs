using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Models.Entities;

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
        public async Task<IActionResult> Index()
        {
            try
            {
                var movies = await _movieRepository.GetMoviesForAdminAsync();
                var vmList = _mapper.Map<List<MovieViewModel>>(movies);
                return View(vmList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading movies list");
                return View(new List<MovieViewModel>());
            }
        }

        // GET: Admin/Movies/Details/5  -> returns partial HTML for modal
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieRepository.GetMovieWithDetailsAsync(id);
            if (movie == null) return NotFound();
            var vm = _mapper.Map<MovieViewModel>(movie);
            return PartialView("_DetailsPartial", vm);
        }

        // GET: Admin/Movies/Create -> return partial for modal
        public async Task<IActionResult> Create()
        {
            var vm = new MovieViewModel
            {
                ReleaseDate = DateTime.Today
            };
            await PopulateCategoriesAsync(vm);
            return PartialView("_MovieForm", vm);
        }

        // POST: Admin/Movies/Create -> returns JSON on success, partial (HTML) when validation fails
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                await PopulateCategoriesAsync(viewModel);
                return PartialView("_MovieForm", viewModel);
            }

            if (!await _movieRepository.IsMovieTitleUniqueAsync(viewModel.Title, null))
            {
                ModelState.AddModelError(nameof(viewModel.Title), "A movie with this title already exists.");
                await PopulateCategoriesAsync(viewModel);
                return PartialView("_MovieForm", viewModel);
            }

            var movie = _mapper.Map<Movie>(viewModel);

            // set DurationMinutes if entity property exists
            var durProp = movie.GetType().GetProperty("DurationMinutes");
            if (durProp != null) durProp.SetValue(movie, viewModel.DurationInMinutes);

            if (viewModel.PosterImageFile != null)
            {
                var imagePath = await SaveImageAsync(viewModel.PosterImageFile, "movies");
                movie.ImageUrl = imagePath;
            }

            movie.CreatedAt = DateTime.UtcNow;
            movie.UpdatedAt = DateTime.UtcNow;

            var added = await _movieRepository.AddAsync(movie);
            await _movie_repository_save();

            await UpdateMovieCategoriesAsync(added.Id, viewModel.SelectedCategoryIds);

            return Json(new { success = true, message = "Movie created successfully" });

            // local helper to ensure SaveChangesAsync called on repository implementation
            async Task _movie_repository_save() => await _movieRepository.SaveChangesAsync();
        }

        // GET: Admin/Movies/Edit/5 -> partial for modal
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieRepository.GetMovieWithDetailsAsync(id) ?? await _movieRepository.GetByIdAsync(id);
            if (movie == null) return NotFound();

            var vm = _mapper.Map<MovieViewModel>(movie);

            var categories = await _movieRepository.GetMovieCategoriesAsync(id);
            vm.SelectedCategoryIds = categories.Select(c => c.Id).ToList();

            await PopulateCategoriesAsync(vm);
            return PartialView("_MovieForm", vm); // reuse same partial for Create/Edit
        }

        // POST: Admin/Movies/Edit/5 -> JSON on success, partial HTML when invalid (re-render form)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieViewModel viewModel)
        {
            if (id != viewModel.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                await PopulateCategoriesAsync(viewModel);
                // return full view (not partial), so validation messages show correctly
                return View(viewModel);
            }

            var existing = await _movieRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            // check for duplicate title
            if (!await _movieRepository.IsMovieTitleUniqueAsync(viewModel.Title, id))
            {
                ModelState.AddModelError(nameof(viewModel.Title), "A movie with this title already exists.");
                await PopulateCategoriesAsync(viewModel);
                return View(viewModel);
            }

            // Map fields using AutoMapper
            _mapper.Map(viewModel, existing);

            // safeguard: keep DB values if viewmodel sends empty/whitespace
            existing.Director = string.IsNullOrWhiteSpace(viewModel.Director) ? existing.Director : viewModel.Director;
            existing.Language = string.IsNullOrWhiteSpace(viewModel.Language) ? existing.Language : viewModel.Language;
            existing.TrailerUrl = string.IsNullOrWhiteSpace(viewModel.TrailerUrl) ? existing.TrailerUrl : viewModel.TrailerUrl;

            // handle duration
            var durProp = existing.GetType().GetProperty("DurationMinutes");
            if (durProp != null)
                durProp.SetValue(existing, viewModel.DurationInMinutes);

            // handle poster image upload
            var oldImage = existing.ImageUrl;
            if (viewModel.PosterImageFile != null)
            {
                var newPath = await SaveImageAsync(viewModel.PosterImageFile, "movies");
                existing.ImageUrl = newPath;

                if (!string.IsNullOrWhiteSpace(oldImage))
                    DeleteImage(oldImage);
            }

            // audit fields
            existing.UpdatedAt = DateTime.UtcNow;

            // save
            await _movieRepository.UpdateAsync(existing);
            await _movieRepository.SaveChangesAsync();

            // update categories
            await UpdateMovieCategoriesAsync(id, viewModel.SelectedCategoryIds);

            // ✅ Redirect to Index (PRG pattern) instead of returning JSON
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Movies/Delete/5 -> confirmation partial
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null) return NotFound();
            var vm = _mapper.Map<MovieViewModel>(movie);
            return PartialView("_DeletePartial", vm);
        }

        // POST: Admin/Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null) return NotFound();

            if (await _movieRepository.HasRelatedDataAsync(id))
            {
                // cannot delete
                return Json(new { success = false, message = "Cannot delete movie. It has related data (showtimes/bookings/etc.)." });
            }

            var imagePath = movie.ImageUrl;

            await _movieRepository.DeleteAsync(movie);
            await _movieRepository.SaveChangesAsync();

            if (!string.IsNullOrWhiteSpace(imagePath))
                DeleteImage(imagePath);

            return Json(new { success = true, message = "Movie deleted successfully" });
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
                await file.CopyToAsync(fs);

            return $"/uploads/{folder}/{filename}";
        }

        private void DeleteImage(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath)) return;
            var full = Path.Combine(_webHostEnvironment.WebRootPath, imagePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
            try { if (System.IO.File.Exists(full)) System.IO.File.Delete(full); } catch { /* logging if desired */ }
        }

        private async Task PopulateCategoriesAsync(MovieViewModel vm)
        {
            var categories = await _category_repository_getall();
            vm.AvailableCategories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = vm.SelectedCategoryIds.Contains(c.Id)
            }).ToList();
            vm.Categories = _mapper.Map<List<CategoryViewModel>>(categories);

            async Task<IEnumerable<Category>> _category_repository_getall() => await _categoryRepository.GetAllAsync(null);
        }

        private async Task UpdateMovieCategoriesAsync(int movieId, List<int> categoryIds)
        {
            var current = (await _movieRepository.GetMovieCategoriesAsync(movieId)).Select(c => c.Id).ToList();

            var toRemove = current.Except(categoryIds ?? new List<int>()).ToList();
            foreach (var catId in toRemove) await _movieRepository.RemoveMovieCategoryAsync(movieId, catId);

            var toAdd = (categoryIds ?? new List<int>()).Except(current).ToList();
            foreach (var catId in toAdd) await _movieRepository.AddMovieCategoryAsync(movieId, catId);
        }

        #endregion
    }
}
