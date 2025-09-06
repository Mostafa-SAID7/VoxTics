using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Repositories.Interfaces;
using VoxTics.Utility;

namespace MovieTickets.Areas.Admin.Controllers
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
                    categoryId: categoryId,
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
                    Categories = _mapper.Map<List<CategoryViewModel>>(categories),
                    ReleaseDate = DateTime.Now.Date,
                    Status = MovieStatus.ComingSoon
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
                    var existingMovie = await _movieRepository.GetByTitleAsync(viewModel.Title);
                    if (existingMovie != null)
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

                        // Handle trailer image upload
                        if (viewModel.TrailerImageFile != null)
                        {
                            var trailerImagePath = await SaveImageAsync(viewModel.TrailerImageFile, "movies");
                            movie.TrailerImageUrl = trailerImagePath;
                        }

                        movie.CreatedDate = DateTime.UtcNow;
                        movie.ModifiedDate = DateTime.UtcNow;

                        var result = await _movieRepository.AddAsync(movie);

                        if (result != null)
                        {
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
                var categories = await _categoryRepository.GetAllAsync();
                viewModel.Categories = _mapper.Map<List<CategoryViewModel>>(categories);

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

                var categories = await _categoryRepository.GetAllAsync();
                var viewModel = _mapper.Map<MovieViewModel>(movie);
                viewModel.Categories = _mapper.Map<List<CategoryViewModel>>(categories);

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
                    var duplicateMovie = await _movieRepository.GetByTitleAsync(viewModel.Title);
                    if (duplicateMovie != null && duplicateMovie.Id != id)
                    {
                        ModelState.AddModelError("Title", "A movie with this title already exists");
                    }
                    else
                    {
                        // Store old image paths for cleanup
                        var oldImagePath = existingMovie.ImageUrl;
                        var oldTrailerImagePath = existingMovie.TrailerImageUrl;

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

                        // Handle new trailer image upload
                        if (viewModel.TrailerImageFile != null)
                        {
                            var trailerImagePath = await SaveImageAsync(viewModel.TrailerImageFile, "movies");
                            existingMovie.TrailerImageUrl = trailerImagePath;

                            // Delete old trailer image
                            if (!string.IsNullOrEmpty(oldTrailerImagePath))
                            {
                                DeleteImage(oldTrailerImagePath);
                            }
                        }

                        existingMovie.ModifiedDate = DateTime.UtcNow;

                        var result = await _movieRepository.UpdateAsync(existingMovie);

                        if (result)
                        {
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
                var categories = await _categoryRepository.GetAllAsync();
                viewModel.Categories = _mapper.Map<List<CategoryViewModel>>(categories);

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

                // Store image paths for cleanup
                var imagePath = movie.ImageUrl;
                var trailerImagePath = movie.TrailerImageUrl;

                var result = await _movieRepository.DeleteAsync(id);

                if (result)
                {
                    // Delete associated images
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        DeleteImage(imagePath);
                    }

                    if (!string.IsNullOrEmpty(trailerImagePath))
                    {
                        DeleteImage(trailerImagePath);
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
                    MovieStatus.ComingSoon => MovieStatus.NowShowing,
                    MovieStatus.NowShowing => MovieStatus.ComingSoon,
                    _ => MovieStatus.ComingSoon
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
                        newStatus = movie.Status.ToString()
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
                                var trailerImagePath = movie.TrailerImageUrl;

                                var result = await _movieRepository.DeleteAsync(id);
                                if (result)
                                {
                                    // Delete associated images
                                    if (!string.IsNullOrEmpty(imagePath))
                                    {
                                        DeleteImage(imagePath);
                                    }

                                    if (!string.IsNullOrEmpty(trailerImagePath))
                                    {
                                        DeleteImage(trailerImagePath);
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
                    message += $" {errors.Count} movie(s) could not be deleted: {string.Join(", ", errors)}";
                }

                _logger.LogInformation("Bulk delete completed: {DeletedCount} movies deleted, {ErrorCount} errors",
                    deletedCount, errors.Count);

                return Json(new
                {
                    success = true,
                    message = message,
                    deletedCount = deletedCount,
                    errorCount = errors.Count
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

        #endregion
    }
}