using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using VoxTics.Repositories.Interfaces;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Utility;
using VoxTics.Helpers;

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
        public async Task<IActionResult> Index(string? searchTerm = "", int categoryId = 0,
            MovieStatus? status = null, int page = 1, int pageSize = 10)
        {
            try
            {
                var movies = await _movieRepository.GetAllAsync(
                    searchTerm: searchTerm,
                    categoryId: categoryId > 0 ? categoryId : null,
                    status: status,
                    pageNumber: page,
                    pageSize: pageSize);

                var categories = await _categoryRepository.GetAllAsync();

                var viewModel = new MovieViewModel
                {
                    Movies = _mapper.Map<PaginatedList<MovieViewModel>>(movies),
                    Categories = _mapper.Map<List<CategoryViewModel>>(categories),
                    SearchTerm = searchTerm,
                    SelectedCategoryId = categoryId,
                    SelectedStatus = status,
                    CurrentPage = page,
                    PageSize = pageSize
                };

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("_MoviesTable", viewModel);
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading movies index page");

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { success = false, message = "Error loading movies data" });
                }

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
                if (movie == null)
                {
                    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return Json(new { success = false, message = "Movie not found" });
                    }
                    return NotFound();
                }

                var viewModel = _mapper.Map<MovieViewModel>(movie);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("_DetailsPartial", viewModel);
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading movie details for ID: {MovieId}", id);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { success = false, message = "Error loading movie details" });
                }

                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Admin/Movies/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                var categories = await _categoryRepository.GetAllAsync();
                var viewModel = new MovieViewModel
                {
                    AvailableCategories = categories.Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList(),
                    ReleaseDate = DateTime.Today,
                    Status = MovieStatus.Upcoming
                };

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("_Create", viewModel);
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading create movie form");

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { success = false, message = "Error loading create form" });
                }

                TempData["Error"] = "Error loading create form";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Admin/Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Check if movie with same title already exists
                    var isUnique = await _movieRepository.IsTitleUniqueAsync(viewModel.Title);
                    if (!isUnique)
                    {
                        ModelState.AddModelError("Title", "A movie with this title already exists");
                    }
                    else
                    {
                        var movie = _mapper.Map<Movie>(viewModel);

                        // Handle image upload
                        if (viewModel.ImageFile != null)
                        {
                            var imagePath = await SaveImageAsync(viewModel.ImageFile, "movies");
                            movie.ImageUrl = imagePath;
                        }

                        movie.CreatedDate = DateTime.UtcNow;
                        movie.ModifiedDate = DateTime.UtcNow;

                        var result = await _movieRepository.AddAsync(movie);

                        if (result != null)
                        {
                            // Handle movie categories
                            await UpdateMovieCategoriesAsync(result.Id, viewModel.SelectedCategoryIds);

                            _logger.LogInformation("Movie created successfully with ID: {MovieId}", result.Id);

                            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                            {
                                return Json(new
                                {
                                    success = true,
                                    message = "Movie created successfully!",
                                    movieId = result.Id
                                });
                            }

                            TempData["Success"] = "Movie created successfully!";
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }

                // If we got this far, something failed, redisplay form
                await PopulateCategoriesAsync(viewModel);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("_Create", viewModel);
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating movie");

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { success = false, message = "Error creating movie" });
                }

                TempData["Error"] = "Error creating movie";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Admin/Movies/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var movie = await _movieRepository.GetByIdAsync(id);
                if (movie == null)
                {
                    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return Json(new { success = false, message = "Movie not found" });
                    }
                    return NotFound();
                }

                var viewModel = _mapper.Map<MovieViewModel>(movie);
                await PopulateCategoriesAsync(viewModel);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("_Edit", viewModel);
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading edit movie form for ID: {MovieId}", id);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { success = false, message = "Error loading edit form" });
                }

                TempData["Error"] = "Error loading edit form";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Admin/Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { success = false, message = "Invalid movie ID" });
                }
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var existingMovie = await _movieRepository.GetByIdAsync(id);
                    if (existingMovie == null)
                    {
                        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                        {
                            return Json(new { success = false, message = "Movie not found" });
                        }
                        return NotFound();
                    }

                    // Check if another movie with same title exists (excluding current movie)
                    var isUnique = await _movieRepository.IsTitleUniqueAsync(viewModel.Title, id);
                    if (!isUnique)
                    {
                        ModelState.AddModelError("Title", "A movie with this title already exists");
                    }
                    else
                    {
                        // Store old image path for cleanup
                        var oldImagePath = existingMovie.ImageUrl;

                        // Map updated values
                        _mapper.Map(viewModel, existingMovie);

                        // Handle new image upload
                        if (viewModel.ImageFile != null)
                        {
                            var imagePath = await SaveImageAsync(viewModel.ImageFile, "movies");
                            existingMovie.ImageUrl = imagePath;

                            // Delete old image
                            if (!string.IsNullOrEmpty(oldImagePath))
                            {
                                DeleteImage(oldImagePath);
                            }
                        }

                        existingMovie.ModifiedDate = DateTime.UtcNow;

                        var result = await _movieRepository.UpdateAsync(existingMovie);

                        if (result)
                        {
                            // Update movie categories
                            await UpdateMovieCategoriesAsync(id, viewModel.SelectedCategoryIds);

                            _logger.LogInformation("Movie updated successfully with ID: {MovieId}", id);

                            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                            {
                                return Json(new
                                {
                                    success = true,
                                    message = "Movie updated successfully!"
                                });
                            }

                            TempData["Success"] = "Movie updated successfully!";
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }

                // If we got this far, something failed, redisplay form
                await PopulateCategoriesAsync(viewModel);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("_Edit", viewModel);
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating movie with ID: {MovieId}", id);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { success = false, message = "Error updating movie" });
                }

                TempData["Error"] = "Error updating movie";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Admin/Movies/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var movie = await _movieRepository.GetByIdAsync(id);
                if (movie == null)
                {
                    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return Json(new { success = false, message = "Movie not found" });
                    }
                    return NotFound();
                }

                var viewModel = _mapper.Map<MovieViewModel>(movie);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("_Delete", viewModel);
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading delete movie form for ID: {MovieId}", id);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { success = false, message = "Error loading delete form" });
                }

                TempData["Error"] = "Error loading delete form";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Admin/Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var movie = await _movieRepository.GetByIdAsync(id);
                if (movie == null)
                {
                    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return Json(new { success = false, message = "Movie not found" });
                    }
                    return NotFound();
                }

                // Check if movie has related data (showtimes, bookings)
                var hasRelatedData = await _movieRepository.HasRelatedDataAsync(id);
                if (hasRelatedData)
                {
                    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return Json(new
                        {
                            success = false,
                            message = "Cannot delete movie. It has associated showtimes or bookings."
                        });
                    }

                    TempData["Error"] = "Cannot delete movie. It has associated showtimes or bookings.";
                    return RedirectToAction(nameof(Index));
                }

                // Store image path for cleanup
                var imagePath = movie.ImageUrl;

                var result = await _movieRepository.DeleteAsync(id);

                if (result)
                {
                    // Delete associated image
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        DeleteImage(imagePath);
                    }

                    _logger.LogInformation("Movie deleted successfully with ID: {MovieId}", id);

                    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return Json(new
                        {
                            success = true,
                            message = "Movie deleted successfully!"
                        });
                    }

                    TempData["Success"] = "Movie deleted successfully!";
                }
                else
                {
                    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return Json(new { success = false, message = "Error deleting movie" });
                    }

                    TempData["Error"] = "Error deleting movie";
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting movie with ID: {MovieId}", id);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { success = false, message = "Error deleting movie" });
                }

                TempData["Error"] = "Error deleting movie";
                return RedirectToAction(nameof(Index));
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
                if (movie == null)
                {
                    return Json(new { success = false, message = "Movie not found" });
                }

                // Toggle status logic
                movie.Status = movie.Status switch
                {
                    MovieStatus.Upcoming => MovieStatus.NowShowing,
                    MovieStatus.NowShowing => MovieStatus.EndedShowing,
                    MovieStatus.EndedShowing => MovieStatus.Upcoming,
                    _ => MovieStatus.Upcoming
                };

                movie.ModifiedDate = DateTime.UtcNow;

                var result = await _movieRepository.UpdateAsync(movie);

                if (result)
                {
                    _logger.LogInformation("Movie status toggled successfully for ID: {MovieId} to {Status}",
                        id, movie.Status);

                    return Json(new
                    {
                        success = true,
                        message = $"Movie status changed to {movie.Status}",
                        newStatus = movie.Status.ToString(),
                        statusText = movie.Status.ToString()
                    });
                }

                return Json(new { success = false, message = "Error updating movie status" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while toggling movie status for ID: {MovieId}", id);
                return Json(new { success = false, message = "Error updating movie status" });
            }
        }

        // POST: Admin/Movies/BulkDelete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BulkDelete(List<int> movieIds)
        {
            try
            {
                if (movieIds == null || !movieIds.Any())
                {
                    return Json(new { success = false, message = "No movies selected" });
                }

                var deletedCount = 0;
                var errors = new List<string>();

                foreach (var id in movieIds)
                {
                    try
                    {
                        var movie = await _movieRepository.GetByIdAsync(id);
                        if (movie != null)
                        {
                            var hasRelatedData = await _movieRepository.HasRelatedDataAsync(id);
                            if (!hasRelatedData)
                            {
                                var imagePath = movie.ImageUrl;

                                var result = await _movieRepository.DeleteAsync(id);
                                if (result)
                                {
                                    // Delete associated image
                                    if (!string.IsNullOrEmpty(imagePath))
                                    {
                                        DeleteImage(imagePath);
                                    }

                                    deletedCount++;
                                }
                            }
                            else
                            {
                                errors.Add($"Movie '{movie.Title}' has associated data and cannot be deleted");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error deleting movie with ID: {MovieId}", id);
                        errors.Add($"Error deleting movie with ID: {id}");
                    }
                }

                var message = $"{deletedCount} movie(s) deleted successfully.";
                if (errors.Any())
                {
                    message += $" {errors.Count} movie(s) could not be deleted.";
                }

                _logger.LogInformation("Bulk delete completed: {DeletedCount} movies deleted, {ErrorCount} errors",
                    deletedCount, errors.Count);

                return Json(new
                {
                    success = true,
                    message = message,
                    deletedCount = deletedCount,
                    errorCount = errors.Count,
                    errors = errors
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during bulk delete operation");
                return Json(new { success = false, message = "Error during bulk delete operation" });
            }
        }

        #region Private Helper Methods

        private async Task<string> SaveImageAsync(IFormFile file, string folder)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return string.Empty;

                // Validate file type
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                    throw new InvalidOperationException("Invalid file type. Only image files are allowed.");

                // Validate file size (max 5MB)
                if (file.Length > 5 * 1024 * 1024)
                    throw new InvalidOperationException("File size cannot exceed 5MB.");

                // Generate unique filename
                var fileName = $"{Guid.NewGuid()}{extension}";
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", folder);

                // Create directory if it doesn't exist
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return $"/uploads/{folder}/{fileName}";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving image file");
                throw;
            }
        }

        private void DeleteImage(string imagePath)
        {
            try
            {
                if (string.IsNullOrEmpty(imagePath))
                    return;

                var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath.TrimStart('/'));

                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                    _logger.LogInformation("Image deleted: {ImagePath}", imagePath);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting image: {ImagePath}", imagePath);
                // Don't throw - image deletion failure shouldn't break the main operation
            }
        }

        private async Task PopulateCategoriesAsync(MovieViewModel viewModel)
        {
            var categories = await _categoryRepository.GetAllAsync();
            viewModel.AvailableCategories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = viewModel.SelectedCategoryIds.Contains(c.Id)
            }).ToList();
        }

        private async Task UpdateMovieCategoriesAsync(int movieId, List<int> categoryIds)
        {
            try
            {
                // This would typically be handled in the repository or through a separate service
                // For now, we'll assume the repository handles this relationship
                var movie = await _movieRepository.GetByIdAsync(movieId);
                if (movie != null && categoryIds != null && categoryIds.Any())
                {
                    // Remove existing categories
                    var existingCategories = movie.MovieCategories?.ToList() ?? new List<MovieCategory>();
                    foreach (var existingCategory in existingCategories)
                    {
                        movie.MovieCategories?.Remove(existingCategory);
                    }

                    // Add new categories
                    foreach (var categoryId in categoryIds)
                    {
                        movie.MovieCategories?.Add(new MovieCategory
                        {
                            MovieId = movieId,
                            CategoryId = categoryId
                        });
                    }

                    await _movieRepository.UpdateAsync(movie);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating movie categories for movie ID: {MovieId}", movieId);
                throw;
            }
        }

        #endregion
    }
}