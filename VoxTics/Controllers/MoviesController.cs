using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Data;
using VoxTics.Models.ViewModels;
using VoxTics.Helpers; // for PaginatedList<T>
using System.Collections.Generic;
using VoxTics.Models.Enums.Sorting;

namespace VoxTics.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDbContext _context;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(MovieDbContext context, ILogger<MoviesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /Movies
        // Accepts filter via query string. Example: /Movies?SearchTerm=batman&PageNumber=2&PageSize=12&SortBy=title&SortOrder=Desc&categoryId=3
        public async Task<IActionResult> Index([FromQuery] BasePaginatedFilterVM filter, int? categoryId)
        {
            try
            {
                // ensure sensible defaults
                var pageNumber = filter?.PageNumber ?? 1;
                var pageSize = filter?.PageSize ?? 12;
                var search = filter?.SearchTerm?.Trim();
                var sortBy = (filter?.SortBy ?? "releasedate").ToLowerInvariant();
                var sortOrder = filter?.SortOrder ?? SortOrder.Desc;

                // base query with includes
                var query = _context.Movies
                                    .AsNoTracking()
                                    .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                                    .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                                    .AsQueryable();

                // filter by category
                if (categoryId.HasValue && categoryId.Value > 0)
                {
                    query = query.Where(m => m.MovieCategories.Any(mc => mc.CategoryId == categoryId.Value));
                }

                // date range (uses ReleaseDate)
                if (filter?.StartDate != null)
                    query = query.Where(m => m.ReleaseDate >= filter.StartDate.Value.Date);
                if (filter?.EndDate != null)
                    query = query.Where(m => m.ReleaseDate <= filter.EndDate.Value.Date.AddDays(1).AddTicks(-1));

                // safe search only on translatable columns (Title, Description, Director)
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(m =>
                        EF.Functions.Like(m.Title, $"%{search}%") ||
                        EF.Functions.Like(m.Description, $"%{search}%") ||
                        EF.Functions.Like(m.Director, $"%{search}%")
                    );
                }

                // sorting
                IOrderedQueryable<Models.Entities.Movie> orderedQuery;
                bool desc = sortOrder == SortOrder.Desc;

                switch (sortBy)
                {
                    case "title":
                        orderedQuery = desc ? query.OrderByDescending(m => m.Title) : query.OrderBy(m => m.Title);
                        break;
                    case "price":
                    case "baseprice":
                        orderedQuery = desc ? query.OrderByDescending(m => m.Price) : query.OrderBy(m => m.Price);
                        break;
                    case "duration":
                        orderedQuery = desc ? query.OrderByDescending(m => m.Duration) : query.OrderBy(m => m.Duration);
                        break;
                    case "releasedate":
                    default:
                        orderedQuery = desc ? query.OrderByDescending(m => m.ReleaseDate) : query.OrderBy(m => m.ReleaseDate);
                        break;
                }

                // project to MovieVM (EF Core will translate the simple projections)
                var projected = orderedQuery.Select(m => new MovieVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    PosterImage = m.ImageUrl,
                    ReleaseDate = m.ReleaseDate,
                    Status = m.Status,
                    Categories = m.MovieCategories.Select(mc => mc.Category.Name).ToList(),
                    CategoryNames = string.Join(", ", m.MovieCategories.Select(mc => mc.Category.Name)),
                    ReleaseDateFormatted = m.ReleaseDate.ToString("MMM dd, yyyy"),
                    AgeRating = m.AgeRating, // if exists
                    BasePrice = m.Price,
                    DurationInMinutes = m.Duration
                });

                var paged = await PaginatedList<MovieVM>.CreateAsync(projected.AsNoTracking(), pageNumber, pageSize);

                // attach route values so you can build pager links (optional)
                var rv = new Dictionary<string, object?>();
                if (!string.IsNullOrEmpty(search)) rv["SearchTerm"] = search;
                if (categoryId.HasValue) rv["categoryId"] = categoryId.Value;
                if (!string.IsNullOrEmpty(filter?.SortBy)) rv["SortBy"] = filter.SortBy;
                rv["SortOrder"] = sortOrder.ToString();
                rv["PageSize"] = pageSize;
                paged.RouteValues = rv.ToDictionary(k => k.Key, k => (object)k.Value!);

                // pass helper data to view
                ViewBag.Filter = filter ?? new BasePaginatedFilterVM();
                ViewBag.SelectedCategoryId = categoryId ?? 0;
                ViewBag.Categories = await _context.Categories.AsNoTracking().OrderBy(c => c.Name).ToListAsync();

                return View(paged);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading movies list");
                return View(new PaginatedList<MovieVM>(new List<MovieVM>(), 0, 1, filter?.PageSize ?? 12));
            }
        }

        // GET: /Movies/Details/5 (modal partial)
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var movie = await _context.Movies
                    .AsNoTracking()
                    .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                    .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (movie == null) return NotFound();

                var vm = new MovieVM
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    BasePrice = movie.Price,                       // keep decimal
                    DurationInMinutes = movie.Duration,
                    ReleaseDate = movie.ReleaseDate,
                    Director = movie.Director,
                    Language = movie.Language,
                    Country = movie.Country,
                    AgeRating = movie.AgeRating,
                    TrailerUrl = movie.TrailerUrl,
                    PosterImage = movie.ImageUrl,
                    Status = movie.Status,

                    Categories = movie.MovieCategories.Select(mc => mc.Category.Name).ToList(),
                    CategoryNames = string.Join(", ", movie.MovieCategories.Select(mc => mc.Category.Name)),

                    Actors = movie.MovieActors.Select(ma => new ActorVM
                    {
                        Id = ma.Actor.Id,
                        FirstName = ma.Actor.FullName,
                        ImageUrl = ma.Actor.ImageUrl
                    }).ToList(),

                    // ? FIX: map images
                    AdditionalImages = movie.MovieImages.Select(mi => mi.ImageUrl).ToList(),

                    // ? formatting
                    ReleaseDateFormatted = movie.ReleaseDate.ToString("MMM dd, yyyy"),
                    FormattedDuration = $"{movie.Duration} min",
                    FormattedPrice = movie.Price.ToString("C")   // decimal ? string
                };


                return PartialView("_DetailsPartial", vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching movie details id={id}");
                return NotFound();
            }
        }

        // GET: /Movies/ByCategory/3 (keeps same behavior)
        public async Task<IActionResult> ByCategory(int id)
        {
            try
            {
                var category = await _context.Categories
                    .Include(c => c.MovieCategories)
                        .ThenInclude(mc => mc.Movie)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (category == null) return NotFound();

                var vmList = category.MovieCategories.Select(mc => new MovieVM
                {
                    Id = mc.Movie.Id,
                    Title = mc.Movie.Title,
                    Description = mc.Movie.Description,
                    PosterImage = mc.Movie.ImageUrl,
                    ReleaseDate = mc.Movie.ReleaseDate,
                    Status = mc.Movie.Status,
                    Categories = mc.Movie.MovieCategories.Select(x => x.Category.Name).ToList(),
                    CategoryNames = string.Join(", ", mc.Movie.MovieCategories.Select(x => x.Category.Name)),
                    ReleaseDateFormatted = mc.Movie.ReleaseDate.ToString("MMM dd, yyyy"),
                    ShortDescription = string.IsNullOrWhiteSpace(mc.Movie.Description) ? "" : (mc.Movie.Description.Length > 150 ? mc.Movie.Description[..147] + "..." : mc.Movie.Description)
                }).ToList();

                ViewBag.CategoryName = category.Name;
                return View("Index", vmList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching movies by category id={id}");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
