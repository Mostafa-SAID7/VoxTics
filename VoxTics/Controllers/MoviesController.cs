using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using VoxTics.Areas.Admin.ViewModels.MovieVMs;
using VoxTics.Data;
using VoxTics.Helpers;
using VoxTics.Models;
using VoxTics.Areas.Admin.ViewModels;

namespace VoxTics.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public MoviesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // INDEX with filtering & pagination
        public async Task<IActionResult> Index([FromQuery] MovieFilterVM filter)
        {
            var query = _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .AsQueryable();

            // filtering
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var s = filter.Search.Trim().ToLower();
                query = query.Where(m => m.Title.ToLower().Contains(s) || (m.Description != null && m.Description.ToLower().Contains(s)));
            }
            if (filter.CategoryId.HasValue)
                query = query.Where(m => m.CategoryId == filter.CategoryId.Value);
            if (filter.CinemaId.HasValue)
                query = query.Where(m => m.CinemaId == filter.CinemaId.Value);
            if (filter.Status.HasValue)
                query = query.Where(m => m.MovieStatus == filter.Status.Value);
            if (filter.From.HasValue)
                query = query.Where(m => m.StartDate >= filter.From.Value);
            if (filter.To.HasValue)
                query = query.Where(m => m.EndDate <= filter.To.Value);
            if (filter.MinPrice.HasValue)
                query = query.Where(m => m.Price >= filter.MinPrice.Value);
            if (filter.MaxPrice.HasValue)
                query = query.Where(m => m.Price <= filter.MaxPrice.Value);

            // total count
            var totalCount = await query.CountAsync();

            // sorting
            query = filter.SortBy switch
            {
                "Price" => query.OrderBy(m => m.Price),
                "StartDate" => query.OrderBy(m => m.StartDate),
                "EndDate" => query.OrderBy(m => m.EndDate),
                _ => query.OrderBy(m => m.Title),
            };

            // paging
            var skip = (Math.Max(filter.Page, 1) - 1) * filter.PageSize;
            var items = await query.Skip(skip).Take(filter.PageSize)
                .Select(m => new MovieListItemVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    CategoryName = m.Category != null ? m.Category.Name : "",
                    CinemaName = m.Cinema != null ? m.Cinema.Name : "",
                    Price = m.Price,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    MovieStatus = m.MovieStatus,
                    ImgUrl = m.ImgUrl
                }).ToListAsync();

            // prepare select lists
            var categories = await _context.Categories.OrderBy(c => c.Name)
                .Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync();
            var cinemas = await _context.Cinemas.OrderBy(c => c.Name)
                .Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync();

            var vm = new MovieIndexVM
            {
                Movies = items,
                Filter = filter,
                TotalItems = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize),
                Categories = categories,
                Cinemas = cinemas
            };

            return View(vm);
        }

        // GET: Create form partial
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new MovieEditVM
            {
                Categories = await _context.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync(),
                Cinemas = await _context.Cinemas.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync(),
                Actors = await _context.Actors.Select(a => new SelectListItem(a.Name, a.Id.ToString())).ToListAsync()
            };
            return PartialView("_MovieForm", vm);
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieEditVM vm)
        {
            if (!ModelState.IsValid)
            {
                // re-populate selects
                vm.Categories = await _context.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync();
                vm.Cinemas = await _context.Cinemas.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync();
                vm.Actors = await _context.Actors.Select(a => new SelectListItem(a.Name, a.Id.ToString())).ToListAsync();
                return PartialView("_MovieForm", vm);
            }

            var movie = new Movie
            {
                Title = vm.Title,
                Description = vm.Description,
                Price = vm.Price,
                TrailerUrl = vm.TrailerUrl,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                MovieStatus = vm.MovieStatus,
                CategoryId = vm.CategoryId,
                CinemaId = vm.CinemaId
            };

            // main image
            if (vm.MainImage != null && vm.MainImage.Length > 0)
            {
                var mainPath = await SaveFile(vm.MainImage);
                movie.ImgUrl = mainPath;
            }

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            // actors
            if (vm.SelectedActorIds?.Any() == true)
            {
                foreach (var aid in vm.SelectedActorIds)
                {
                    _context.MovieActors.Add(new MovieActor { ActorId = aid, MovieId = movie.Id });
                }
            }

            // additional images
            if (vm.UploadedImages?.Any() == true)
            {
                foreach (var file in vm.UploadedImages)
                {
                    if (file != null && file.Length > 0)
                    {
                        var path = await SaveFile(file);
                        _context.MovieImgs.Add(new MovieImg { ImgUrl = path, MovieId = movie.Id });
                    }
                }
            }

            await _context.SaveChangesAsync();

            // AJAX caller expects success JSON
            return Json(new { success = true });
        }

        // GET: Edit partial
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.MovieImgs)
                .Include(m => m.MovieActors)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) return NotFound();

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
                SelectedActorIds = movie.MovieActors?.Select(ma => ma.ActorId).ToList() ?? new List<int>(),
                ExistingImages = movie.MovieImgs?.Select(i => new MovieImgVM { Id = i.Id, ImgUrl = i.ImgUrl }).ToList() ?? new List<MovieImgVM>(),
                Categories = await _context.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync(),
                Cinemas = await _context.Cinemas.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync(),
                Actors = await _context.Actors.Select(a => new SelectListItem(a.Name, a.Id.ToString())).ToListAsync()
            };

            return PartialView("_MovieForm", vm);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieEditVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = await _context.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync();
                vm.Cinemas = await _context.Cinemas.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync();
                vm.Actors = await _context.Actors.Select(a => new SelectListItem(a.Name, a.Id.ToString())).ToListAsync();
                return PartialView("_MovieForm", vm);
            }

            var movie = await _context.Movies
                .Include(m => m.MovieImgs)
                .Include(m => m.MovieActors)
                .FirstOrDefaultAsync(m => m.Id == vm.Id);

            if (movie == null) return NotFound();

            movie.Title = vm.Title;
            movie.Description = vm.Description;
            movie.Price = vm.Price;
            movie.TrailerUrl = vm.TrailerUrl;
            movie.StartDate = vm.StartDate;
            movie.EndDate = vm.EndDate;
            movie.MovieStatus = vm.MovieStatus;
            movie.CategoryId = vm.CategoryId;
            movie.CinemaId = vm.CinemaId;

            // main image replace
            if (vm.MainImage != null && vm.MainImage.Length > 0)
            {
                // optionally remove old main image file
                if (!string.IsNullOrWhiteSpace(movie.ImgUrl))
                {
                    TryDeletePhysicalFile(movie.ImgUrl);
                }
                movie.ImgUrl = await SaveFile(vm.MainImage);
            }

            // add new images
            if (vm.UploadedImages?.Any() == true)
            {
                foreach (var f in vm.UploadedImages)
                {
                    if (f != null && f.Length > 0)
                    {
                        var path = await SaveFile(f);
                        _context.MovieImgs.Add(new MovieImg { ImgUrl = path, MovieId = movie.Id });
                    }
                }
            }

            // update actors: simple strategy: remove existing and re-add
            var existingActors = _context.MovieActors.Where(ma => ma.MovieId == movie.Id);
            _context.MovieActors.RemoveRange(existingActors);
            if (vm.SelectedActorIds?.Any() == true)
            {
                foreach (var aId in vm.SelectedActorIds)
                    _context.MovieActors.Add(new MovieActor { ActorId = aId, MovieId = movie.Id });
            }

            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        // GET delete confirmation partial
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) return NotFound();
            return PartialView("_MovieDelete", movie);
        }

        // POST delete
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.Include(m => m.MovieImgs).FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) return NotFound();

            // delete physical images
            if (!string.IsNullOrWhiteSpace(movie.ImgUrl))
                TryDeletePhysicalFile(movie.ImgUrl);
            if (movie.MovieImgs != null)
            {
                foreach (var img in movie.MovieImgs)
                    TryDeletePhysicalFile(img.ImgUrl);
            }

            _context.MovieImgs.RemoveRange(movie.MovieImgs);
            _context.MovieActors.RemoveRange(_context.MovieActors.Where(ma => ma.MovieId == id));
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        // Remove a single extra image via AJAX
        [HttpPost]
        public async Task<IActionResult> RemoveImage(int id)
        {
            var img = await _context.MovieImgs.FindAsync(id);
            if (img == null) return NotFound();
            TryDeletePhysicalFile(img.ImgUrl);
            _context.MovieImgs.Remove(img);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        // Details partial
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .Include(m => m.MovieImgs)
                .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null) return NotFound();
            return PartialView("_MovieDetails", movie);
        }

        #region Helpers
        private async Task<string> SaveFile(IFormFile file)
        {
            var uploadsRoot = Path.Combine(_env.WebRootPath, "uploads", "movies");
            if (!Directory.Exists(uploadsRoot)) Directory.CreateDirectory(uploadsRoot);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var relativePath = $"/uploads/movies/{fileName}";
            var fullPath = Path.Combine(uploadsRoot, fileName);

            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);
            return relativePath;
        }

        private void TryDeletePhysicalFile(string relativePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(relativePath)) return;
                // remove leading slash if present
                var trimmed = relativePath.TrimStart('/');
                var full = Path.Combine(_env.WebRootPath, trimmed.Replace('/', Path.DirectorySeparatorChar));
                if (System.IO.File.Exists(full)) System.IO.File.Delete(full);
            }
            catch
            {
                // swallow for safety (or log)
            }
        }
        #endregion
    }
}
