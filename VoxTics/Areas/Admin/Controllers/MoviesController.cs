using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
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

        public MoviesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // -------------------------
        // INDEX (page with filters)
        // -------------------------
        public async Task<IActionResult> Index(string? search, int? categoryId, string? sort, int page = 1, int pageSize = 10)
        {
            // reuse List logic to build paged data but return full view model
            if (page < 1) page = 1;
            if (pageSize <= 0) pageSize = 10;

            // Build base query
            var query = BuildFilteredQuery(search, categoryId, sort);

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new MovieListItemVm
                {
                    Id = m.Id,
                    Title = m.Title,
                    CinemaName = m.Cinema != null ? m.Cinema.Name : "",
                    CategoryName = m.Category != null ? m.Category.Name : "",
                    MovieStatus = m.MovieStatus.ToString(),
                    ThumbnailUrl = m.ImgUrl,
                    ImagesCount = m.MovieImgs.Count(),
                    StartDate = m.StartDate,
                    Price = m.Price
                })
                .ToListAsync();

            var vm = new MovieIndexVm
            {
                Search = search,
                CategoryId = categoryId,
                Sort = sort,
                Page = page,
                PageSize = pageSize,
                PagedMovies = new PagedResult<MovieListItemVm>
                {
                    Items = items,
                    Page = page,
                    PageSize = pageSize,
                    TotalItems = totalItems
                },
                Categories = await _context.Categories
                    .AsNoTracking()
                    .OrderBy(c => c.Name)
                    .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
                    .ToListAsync(),
                PageSizeOptions = new List<SelectListItem>
                {
                    new SelectListItem("5","5"),
                    new SelectListItem("10","10"),
                    new SelectListItem("20","20"),
                    new SelectListItem("50","50")
                }
            };

            return View(vm);
        }

        // -------------------------
        // LIST (partial for AJAX)
        // -------------------------
        [HttpGet]
        public async Task<IActionResult> List(string? search, int? categoryId, string? sort, int page = 1, int pageSize = 10)
        {
            if (page < 1) page = 1;
            if (pageSize <= 0) pageSize = 10;

            var query = BuildFilteredQuery(search, categoryId, sort);

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new MovieListItemVm
                {
                    Id = m.Id,
                    Title = m.Title,
                    CinemaName = m.Cinema != null ? m.Cinema.Name : "",
                    CategoryName = m.Category != null ? m.Category.Name : "",
                    MovieStatus = m.MovieStatus.ToString(),
                    ThumbnailUrl = m.ImgUrl,
                    ImagesCount = m.MovieImgs.Count(),
                    StartDate = m.StartDate,
                    Price = m.Price
                })
                .ToListAsync();

            // Expose paging meta to client via headers (used by the client-side JS)
            Response.Headers["X-Total-Pages"] = totalPages.ToString();
            Response.Headers["X-Total-Items"] = totalItems.ToString();

            return PartialView("_MovieList", items);
        }

        // -------------------------
        // CREATE
        // -------------------------
        // GET
        public IActionResult Create()
        {
            var vm = new MovieFormVm
            {
                Cinemas = _context.Cinemas.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList(),
                Categories = _context.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList(),
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddMonths(1),
                MovieStatus = "Available"
            };
            return View(vm);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieFormVm vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Cinemas = _context.Cinemas.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();
                vm.Categories = _context.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();
                return View(vm);
            }

            var movie = new Movie
            {
                Title = vm.Title,
                Description = vm.Description,
                Price = vm.Price,
                ImgUrl = vm.ImgUrl,
                TrailerUrl = vm.TrailerUrl,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                MovieStatus = ParseStatus(vm.MovieStatus),
                CinemaId = vm.CinemaId,
                CategoryId = vm.CategoryId,
                MovieImgs = new List<MovieImg>()
            };

            // handle files
            if (vm.UploadedImages != null && vm.UploadedImages.Any())
            {
                var saved = await SaveUploadedFiles(vm.UploadedImages);
                foreach (var url in saved)
                    movie.MovieImgs.Add(new MovieImg { ImgUrl = url });
            }

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // -------------------------
        // EDIT
        // -------------------------
        // GET
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.MovieImgs)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null) return NotFound();

            var vm = new MovieFormVm
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Price = movie.Price,
                ImgUrl = movie.ImgUrl,
                TrailerUrl = movie.TrailerUrl,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                MovieStatus = movie.MovieStatus.ToString(),
                CinemaId = movie.CinemaId,
                CategoryId = movie.CategoryId,
                Cinemas = _context.Cinemas.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList(),
                Categories = _context.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList(),
                ExistingImages = movie.MovieImgs.Select(i => new MovieImgVm { Id = i.Id, ImgUrl = i.ImgUrl }).ToList()
            };

            return View(vm);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieFormVm vm)
        {
            if (id != vm.Id) return BadRequest();
            if (!ModelState.IsValid)
            {
                vm.Cinemas = _context.Cinemas.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();
                vm.Categories = _context.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();
                return View(vm);
            }

            var dbMovie = await _context.Movies
                .Include(m => m.MovieImgs)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (dbMovie == null) return NotFound();

            // update fields
            dbMovie.Title = vm.Title;
            dbMovie.Description = vm.Description;
            dbMovie.Price = vm.Price;
            dbMovie.ImgUrl = vm.ImgUrl;
            dbMovie.TrailerUrl = vm.TrailerUrl;
            dbMovie.StartDate = vm.StartDate;
            dbMovie.EndDate = vm.EndDate;
            dbMovie.MovieStatus = ParseStatus(vm.MovieStatus);
            dbMovie.CinemaId = vm.CinemaId;
            dbMovie.CategoryId = vm.CategoryId;

            // handle new uploads: remove old files + rows then save new
            if (vm.UploadedImages != null && vm.UploadedImages.Any())
            {
                // delete physical files
                foreach (var img in dbMovie.MovieImgs.ToList())
                {
                    DeletePhysicalFileIfExists(img.ImgUrl);
                }

                // remove DB rows (call RemoveRange on DbSet with List)
                _context.MovieImgs.RemoveRange(dbMovie.MovieImgs.ToList());

                // add new images
                var saved = await SaveUploadedFiles(vm.UploadedImages);
                dbMovie.MovieImgs = saved.Select(url => new MovieImg { ImgUrl = url }).ToList();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // -------------------------
        // DELETE
        // -------------------------
        // GET
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Cinema)
                .Include(m => m.Category)
                .Include(m => m.MovieImgs)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null) return NotFound();

            var vm = new MovieDeleteVm
            {
                Id = movie.Id,
                Title = movie.Title,
                CinemaName = movie.Cinema?.Name,
                CategoryName = movie.Category?.Name,
                ImgUrl = movie.ImgUrl,
                Images = movie.MovieImgs.Select(i => new MovieImgVm { Id = i.Id, ImgUrl = i.ImgUrl }).ToList()
            };

            return View(vm);
        }

        // POST
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.MovieImgs)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null) return NotFound();

            // delete physical files
            foreach (var img in movie.MovieImgs.ToList())
            {
                DeletePhysicalFileIfExists(img.ImgUrl);
            }

            // remove DB rows
            _context.MovieImgs.RemoveRange(movie.MovieImgs.ToList());
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // -------------------------
        // Helper methods
        // -------------------------
        /// <summary> Build filtered, sorted IQueryable<Movie> (includes Cinema, Category, MovieImgs) </summary>
        private IQueryable<Movie> BuildFilteredQuery(string? search, int? categoryId, string? sort)
        {
            var q = _context.Movies
                .AsNoTracking()
                .Include(m => m.Cinema)
                .Include(m => m.Category)
                .Include(m => m.MovieImgs)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var s = search.Trim();
                q = q.Where(m => EF.Functions.Like(m.Title, $"%{s}%") || EF.Functions.Like(m.Description, $"%{s}%"));
            }

            if (categoryId.HasValue && categoryId > 0)
            {
                q = q.Where(m => m.CategoryId == categoryId.Value);
            }

            switch (sort)
            {
                case "title_desc": q = q.OrderByDescending(m => m.Title); break;
                case "date_asc": q = q.OrderBy(m => m.StartDate); break;
                case "date_desc": q = q.OrderByDescending(m => m.StartDate); break;
                case "price_asc": q = q.OrderBy(m => m.Price); break;
                case "price_desc": q = q.OrderByDescending(m => m.Price); break;
                default: q = q.OrderBy(m => m.Title); break;
            }

            return q;
        }

        /// <summary> Save uploaded IFormFile list to wwwroot/images/movies and return list of relative URLs ("/images/movies/filename") </summary>
        private async Task<List<string>> SaveUploadedFiles(IEnumerable<Microsoft.AspNetCore.Http.IFormFile> files)
        {
            var savedUrls = new List<string>();
            var imagesFolder = Path.Combine(_env.WebRootPath, "images", "movies");
            if (!Directory.Exists(imagesFolder)) Directory.CreateDirectory(imagesFolder);

            foreach (var file in files)
            {
                if (file == null || file.Length == 0) continue;

                // create unique file name
                var fileName = Path.GetFileName(file.FileName);
                var unique = $"{Guid.NewGuid():N}_{fileName}";
                var filePath = Path.Combine(imagesFolder, unique);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                savedUrls.Add($"/images/movies/{unique}");
            }

            return savedUrls;
        }

        /// <summary> Delete file under wwwroot if exists (imgUrl must be like "/images/movies/xxx") </summary>
        private void DeletePhysicalFileIfExists(string imgUrl)
        {
            if (string.IsNullOrWhiteSpace(imgUrl)) return;

            var trimmed = imgUrl.TrimStart('/');
            var physicalPath = Path.Combine(_env.WebRootPath, trimmed.Replace("/", Path.DirectorySeparatorChar.ToString()));
            if (System.IO.File.Exists(physicalPath))
            {
                try
                {
                    System.IO.File.Delete(physicalPath);
                }
                catch
                {
                    // optionally log
                }
            }
        }

        /// <summary> Parse MovieStatus from string safely (fallback to Available) </summary>
        private VoxTics.Models.Enums.MovieStatus ParseStatus(string? status)
        {
            if (string.IsNullOrWhiteSpace(status)) return VoxTics.Models.Enums.MovieStatus.Available;
            if (Enum.TryParse<VoxTics.Models.Enums.MovieStatus>(status, out var s)) return s;
            return VoxTics.Models.Enums.MovieStatus.Available;
        }
    }
}
