using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VoxTics.Areas.Admin.ViewModels.MovieVMs;
using VoxTics.Data;
using VoxTics.Models;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<MoviesController> _logger;

        // file upload policy
        private static readonly string[] _permittedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp", ".gif" };
        private const long _maxFileBytes = 5 * 1024 * 1024; // 5 MB

        public MoviesController(ApplicationDbContext context, IWebHostEnvironment env, ILogger<MoviesController> logger)
        {
            _context = context;
            _env = env;
            _logger = logger;
        }

        // ---------- INDEX (filter, sort, paging) ----------
        public async Task<IActionResult> Index([FromQuery] MovieFilterVM filter, CancellationToken cancellationToken)
        {
            // ensure filter defaults
            filter ??= new MovieFilterVM();

            var query = _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .AsQueryable();

            // Filtering (case-insensitive)
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var s = filter.Search.Trim().ToLower();
                query = query.Where(m => m.Title.ToLower().Contains(s) || (m.Description != null && m.Description.ToLower().Contains(s)));
            }
            if (filter.CategoryId.HasValue) query = query.Where(m => m.CategoryId == filter.CategoryId.Value);
            if (filter.CinemaId.HasValue) query = query.Where(m => m.CinemaId == filter.CinemaId.Value);
            if (filter.Status.HasValue) query = query.Where(m => m.MovieStatus == filter.Status.Value);
            if (filter.From.HasValue) query = query.Where(m => m.StartDate >= filter.From.Value);
            if (filter.To.HasValue) query = query.Where(m => m.EndDate <= filter.To.Value);
            if (filter.MinPrice.HasValue) query = query.Where(m => m.Price >= filter.MinPrice.Value);
            if (filter.MaxPrice.HasValue) query = query.Where(m => m.Price <= filter.MaxPrice.Value);

            // Sorting
            query = filter.SortBy switch
            {
                "Price" => query.OrderBy(m => m.Price),
                "StartDate" => query.OrderBy(m => m.StartDate),
                "EndDate" => query.OrderBy(m => m.EndDate),
                _ => query.OrderBy(m => m.Title),
            };

            var total = await query.CountAsync(cancellationToken);
            var page = Math.Max(filter.Page, 1);
            var pageSize = filter.PageSize <= 0 ? 10 : filter.PageSize;
            var skip = (page - 1) * pageSize;

            var items = await query.Skip(skip).Take(pageSize)
                .Select(m => new MovieListItemVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    TrailerUrl = m.TrailerUrl,
                    Price = m.Price,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    MovieStatus = m.MovieStatus,
                    ImgUrl = m.ImgUrl,
                    CategoryId = m.CategoryId,
                    CategoryName = m.Category != null ? m.Category.Name : null,
                    CinemaId = m.CinemaId,
                    CinemaName = m.Cinema != null ? m.Cinema.Name : null
                })
                .ToListAsync(cancellationToken);

            var categories = await _context.Categories.OrderBy(c => c.Name)
                .Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync(cancellationToken);
            var cinemas = await _context.Cinemas.OrderBy(c => c.Name)
                .Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync(cancellationToken);

            var vm = new MovieIndexVM
            {
                Movies = items,
                Filter = filter,
                TotalItems = total,
                TotalPages = (int)Math.Ceiling(total / (double)pageSize),
                Categories = categories,
                Cinemas = cinemas
            };

            return View(vm);
        }

        // ---------- CREATE (page-based) ----------
        [HttpGet]
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var vm = new MovieEditVM
            {
                Categories = await _context.Categories.OrderBy(c => c.Name)
                    .Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync(cancellationToken),
                Cinemas = await _context.Cinemas.OrderBy(c => c.Name)
                    .Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync(cancellationToken),
                Actors = await _context.Actors.OrderBy(a => a.FirstName)
                    .Select(a => new SelectListItem(a.FirstName + " " + a.LastName, a.Id.ToString())).ToListAsync(cancellationToken)
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieEditVM vm, CancellationToken cancellationToken)
        {
            // server-side sanity checks
            if (vm.EndDate < vm.StartDate)
            {
                ModelState.AddModelError(nameof(vm.EndDate), "End date must be after start date.");
            }
            if (vm.Price < 0) ModelState.AddModelError(nameof(vm.Price), "Price cannot be negative.");

            if (!ModelState.IsValid)
            {
                await RepopulateCreateEditSelects(vm, cancellationToken);
                return View(vm);
            }

            var movie = new Movie
            {
                Title = vm.Title.Trim(),
                Description = vm.Description,
                Price = vm.Price,
                TrailerUrl = vm.TrailerUrl,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                MovieStatus = vm.MovieStatus,
                CategoryId = vm.CategoryId,
                CinemaId = vm.CinemaId
            };

            // handle main image
            if (vm.MainImage != null && vm.MainImage.Length > 0)
            {
                var validationMsg = ValidateImageFile(vm.MainImage);
                if (validationMsg != null)
                {
                    ModelState.AddModelError(nameof(vm.MainImage), validationMsg);
                    await RepopulateCreateEditSelects(vm, cancellationToken);
                    return View(vm);
                }
                movie.ImgUrl = await SaveFile(vm.MainImage, cancellationToken);
            }

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync(cancellationToken);

            // actors (many-to-many)
            if (vm.SelectedActorIds?.Any() == true)
            {
                var actorsToAdd = vm.SelectedActorIds.Select(aid => new MovieActor { ActorId = aid, MovieId = movie.Id }).ToList();
                _context.MovieActors.AddRange(actorsToAdd);
            }

            // additional images
            if (vm.UploadedImages?.Any() == true)
            {
                foreach (var f in vm.UploadedImages)
                {
                    if (f == null || f.Length == 0) continue;
                    var vmsg = ValidateImageFile(f);
                    if (vmsg != null)
                    {
                        // ignore the problematic image and log - or you could add a model error and return
                        _logger.LogWarning("Skipping uploaded image for movie create due to validation: {Reason}", vmsg);
                        continue;
                    }
                    var path = await SaveFile(f, cancellationToken);
                    _context.MovieImgs.Add(new MovieImg { ImgUrl = path, MovieId = movie.Id });
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            TempData["SuccessMessage"] = "Movie created successfully.";
            return RedirectToAction(nameof(Index));
        }

        // ---------- EDIT (GET partial for modal, GET page for full page) ----------
        // GET: partial (modal) - used by AJAX / modal
        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies
                .Include(m => m.MovieImgs)
                .Include(m => m.MovieActors)
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

            if (movie == null) return NotFound();

            var vm = await BuildEditVmFromMovie(movie, cancellationToken);
            return PartialView("_MovieForm", vm);
        }

        // GET: full page Edit (if you want page-based edit)
        [HttpGet("Admin/Movies/Edit/{id}")]
        public async Task<IActionResult> EditPage(int id, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies
                .Include(m => m.MovieImgs)
                .Include(m => m.MovieActors)
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

            if (movie == null) return NotFound();

            var vm = await BuildEditVmFromMovie(movie, cancellationToken);
            return View("Edit", vm); // uses full-page Edit.cshtml
        }

        // POST Edit (handles both modal AJAX and full-page POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieEditVM vm, CancellationToken cancellationToken)
        {
            // validation
            if (vm.EndDate < vm.StartDate)
            {
                ModelState.AddModelError(nameof(vm.EndDate), "End date must be after start date.");
            }
            if (vm.Price < 0) ModelState.AddModelError(nameof(vm.Price), "Price cannot be negative.");

            if (!ModelState.IsValid)
            {
                await RepopulateCreateEditSelects(vm, cancellationToken);
                // if AJAX (modal) -> return partial with validation messages
                if (IsAjaxRequest()) return PartialView("_MovieForm", vm);
                return View("Edit", vm);
            }

            var movie = await _context.Movies.Include(m => m.MovieImgs).Include(m => m.MovieActors).FirstOrDefaultAsync(m => m.Id == vm.Id, cancellationToken);
            if (movie == null) return NotFound();

            movie.Title = vm.Title.Trim();
            movie.Description = vm.Description;
            movie.Price = vm.Price;
            movie.TrailerUrl = vm.TrailerUrl;
            movie.StartDate = vm.StartDate;
            movie.EndDate = vm.EndDate;
            movie.MovieStatus = vm.MovieStatus;
            movie.CategoryId = vm.CategoryId;
            movie.CinemaId = vm.CinemaId;

            // replace main image if provided
            if (vm.MainImage != null && vm.MainImage.Length > 0)
            {
                var vmsg = ValidateImageFile(vm.MainImage);
                if (vmsg != null)
                {
                    ModelState.AddModelError(nameof(vm.MainImage), vmsg);
                    await RepopulateCreateEditSelects(vm, cancellationToken);
                    if (IsAjaxRequest()) return PartialView("_MovieForm", vm);
                    return View("Edit", vm);
                }
                if (!string.IsNullOrWhiteSpace(movie.ImgUrl)) TryDeletePhysicalFile(movie.ImgUrl);
                movie.ImgUrl = await SaveFile(vm.MainImage, cancellationToken);
            }

            // add any new uploaded additional images
            if (vm.UploadedImages?.Any() == true)
            {
                foreach (var f in vm.UploadedImages)
                {
                    if (f == null || f.Length == 0) continue;
                    var vmsg = ValidateImageFile(f);
                    if (vmsg != null)
                    {
                        _logger.LogWarning("Skipping uploaded image during Edit due to validation: {Reason}", vmsg);
                        continue;
                    }
                    var path = await SaveFile(f, cancellationToken);
                    _context.MovieImgs.Add(new MovieImg { ImgUrl = path, MovieId = movie.Id });
                }
            }

            // replace actor associations
            var existing = _context.MovieActors.Where(ma => ma.MovieId == movie.Id).ToList();
            if (existing.Any()) _context.MovieActors.RemoveRange(existing);
            if (vm.SelectedActorIds?.Any() == true)
            {
                var newActors = vm.SelectedActorIds.Select(aid => new MovieActor { ActorId = aid, MovieId = movie.Id });
                _context.MovieActors.AddRange(newActors);
            }

            await _context.SaveChangesAsync(cancellationToken);

            // return JSON for AJAX (modal) flow, else redirect
            if (IsAjaxRequest()) return Json(new { success = true });

            TempData["SuccessMessage"] = "Movie updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        // ---------- DELETE ----------
        // GET delete partial (modal)
        [HttpGet]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.Include(m => m.Category).Include(m => m.Cinema).FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
            if (movie == null) return NotFound();
            return PartialView("_MovieDelete", movie);
        }

        // GET delete full page
        [HttpGet("Admin/Movies/Delete/{id}")]
        public async Task<IActionResult> DeletePage(int id, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.Include(m => m.Category).Include(m => m.Cinema).Include(m => m.MovieImgs).FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
            if (movie == null) return NotFound();
            return View("Delete", movie);
        }

        // POST delete (handles modal AJAX and full-page)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.Include(m => m.MovieImgs).FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
            if (movie == null) return NotFound();

            if (!string.IsNullOrWhiteSpace(movie.ImgUrl)) TryDeletePhysicalFile(movie.ImgUrl);
            foreach (var img in movie.MovieImgs ?? Enumerable.Empty<MovieImg>()) TryDeletePhysicalFile(img.ImgUrl);

            _context.MovieImgs.RemoveRange(movie.MovieImgs ?? Enumerable.Empty<MovieImg>());
            _context.MovieActors.RemoveRange(_context.MovieActors.Where(ma => ma.MovieId == id).ToList());
            _context.Movies.Remove(movie);

            await _context.SaveChangesAsync(cancellationToken);

            if (IsAjaxRequest()) return Json(new { success = true });

            TempData["SuccessMessage"] = "Movie deleted successfully.";
            return RedirectToAction(nameof(Index));
        }

        

        // ---------- Remove single additional image (AJAX) ----------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveImage(int id, CancellationToken cancellationToken)
        {
            var img = await _context.MovieImgs.FindAsync(new object[] { id }, cancellationToken);
            if (img == null) return NotFound();

            TryDeletePhysicalFile(img.ImgUrl);
            _context.MovieImgs.Remove(img);
            await _context.SaveChangesAsync(cancellationToken);

            return Json(new { success = true });
        }

        // ---------- Helpers ----------
        private bool IsAjaxRequest()
        {
            if (Request?.Headers == null) return false;
            return Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        private async Task RepopulateCreateEditSelects(MovieEditVM vm, CancellationToken cancellationToken)
        {
            vm.Categories = await _context.Categories.OrderBy(c => c.Name).Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync(cancellationToken);
            vm.Cinemas = await _context.Cinemas.OrderBy(c => c.Name).Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync(cancellationToken);
            vm.Actors = await _context.Actors.OrderBy(a => a.FirstName).Select(a => new SelectListItem(a.FirstName + " " + a.LastName, a.Id.ToString())).ToListAsync(cancellationToken);
        }

        private async Task<MovieEditVM> BuildEditVmFromMovie(Movie movie, CancellationToken cancellationToken)
        {
            var vm = new MovieEditVM
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Price = movie.Price,
                ImgUrl = movie.ImgUrl,
                TrailerUrl = movie.TrailerUrl,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                MovieStatus = movie.MovieStatus,
                CategoryId = movie.CategoryId,
                CinemaId = movie.CinemaId,
                CategoryName = movie.Category?.Name,
                CinemaName = movie.Cinema?.Name,
                SelectedActorIds = movie.MovieActors?.Select(ma => ma.ActorId).ToList() ?? new List<int>(),
                ExistingImages = movie.MovieImgs?.Select(i => new MovieImgVM { Id = i.Id, ImgUrl = i.ImgUrl }).ToList() ?? new List<MovieImgVM>(),
            };

            // populate selects
            vm.Categories = await _context.Categories.OrderBy(c => c.Name).Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync(cancellationToken);
            vm.Cinemas = await _context.Cinemas.OrderBy(c => c.Name).Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync(cancellationToken);
            vm.Actors = await _context.Actors.OrderBy(a => a.FirstName).Select(a => new SelectListItem(a.FirstName + " " + a.LastName, a.Id.ToString())).ToListAsync(cancellationToken);

            return vm;
        }

        private string? ValidateImageFile(IFormFile file)
        {
            if (file == null) return "File is null.";
            if (file.Length == 0) return "File is empty.";
            if (file.Length > _maxFileBytes) return $"File is too large. Max {_maxFileBytes / (1024 * 1024)} MB.";

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !_permittedExtensions.Contains(ext))
                return "Unsupported file extension. Allowed: " + string.Join(", ", _permittedExtensions);

            // basic content-type check - not perfect but helps
            if (!string.IsNullOrWhiteSpace(file.ContentType) && !file.ContentType.StartsWith("image/"))
            {
                // allow some servers that may set content-type differently
                return "File content type does not look like an image.";
            }

            // optional: read first bytes to check signature (magic bytes) - omitted for brevity
            return null;
        }

        private async Task<string> SaveFile(IFormFile file, CancellationToken cancellationToken)
        {
            // ensure uploads folder exists
            var uploadsRoot = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads", "movies");
            if (!Directory.Exists(uploadsRoot))
            {
                Directory.CreateDirectory(uploadsRoot);
            }

            // sanitize filename & create unique file name
            var ext = Path.GetExtension(file.FileName);
            var safeName = SanitizeFileName(Path.GetFileNameWithoutExtension(file.FileName));
            var fileName = $"{Guid.NewGuid():N}_{safeName}{ext}".ToLowerInvariant();
            var fullPath = Path.Combine(uploadsRoot, fileName);

            // write file
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream, cancellationToken);
            }

            // return web-relative path
            var relativePath = $"/uploads/movies/{fileName}";
            return relativePath;
        }

        private void TryDeletePhysicalFile(string relativePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(relativePath)) return;
                // remove leading slash(es)
                var trimmed = relativePath.TrimStart('/', '\\');
                var full = Path.Combine(_env.WebRootPath ?? "wwwroot", trimmed.Replace('/', Path.DirectorySeparatorChar));
                if (System.IO.File.Exists(full)) System.IO.File.Delete(full);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to delete file {Path}", relativePath);
            }
        }

        private static string SanitizeFileName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "file";
            // remove invalid chars, keep letters, numbers, -, _
            var cleaned = Regex.Replace(name, @"[^\w\-]", "_");
            return cleaned.Length > 40 ? cleaned.Substring(0, 40) : cleaned;
        }
    }
}
