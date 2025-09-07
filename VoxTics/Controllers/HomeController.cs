using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace VoxTics.Controllers
{
    // Replace this with your real DbContext namespace/type if different
    using VoxTics.Data; // <-- change or remove if your ApplicationDbContext is in a different namespace
    using VoxTics.Models.Entities; // entity namespace (change if different)

    public class HomeController : Controller
    {
        private readonly MovieDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(MovieDbContext db, ILogger<HomeController> logger)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: /
        public async Task<IActionResult> Index()
        {
            try
            {
                // Defensive approach:
                // 1. Grab a reasonable number of movies into memory (so we can use reflection safely).
                // 2. Filter/massage them in-memory to avoid compile-time SQL translation issues if DB schema differs.
                var movieFetchLimit = 200; // adjust if you have many movies
                var rawMovies = await _db.Movies
                    .AsNoTracking()
                    .Take(movieFetchLimit)
                    .ToListAsync();


            

                var today = DateTime.UtcNow.Date;
                var upcomingMovies = rawMovies
                    .Where(m =>
                    {
                        var rel = GetDateProp(m, "ReleaseDate");
                        if (rel.HasValue) return rel.Value.Date > today;
                        // fallback to Status enum: treat  (int)MovieStatus.Upcoming == some value (use 1 as common default)
                        var status = GetIntProp(m, "Status");
                        return status.HasValue && status.Value == 1;
                    })
                    .OrderBy(m => GetDateProp(m, "ReleaseDate") ?? DateTime.MaxValue)
                    .Take(12)
                    .ToList();

                var nowShowing = rawMovies
                    .Where(m =>
                    {
                        var rel = GetDateProp(m, "ReleaseDate");
                        if (rel.HasValue) return rel.Value.Date <= today;
                        var status = GetIntProp(m, "Status");
                        return status.HasValue && status.Value != 1; // not Upcoming
                    })
                    .Take(12)
                    .ToList();

                // Fetch today's showtimes with navigation (movie/hall/cinema). This query uses known properties,
                // StartTime should exist in your schema. If not, change accordingly.
                var startDay = DateTime.UtcNow.Date;
                var endDay = startDay.AddDays(1);

                var todayShowtimes = await _db.Showtimes
                    .AsNoTracking()
                    .Include(s => s.Movie)
                    .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                    .Where(s => s.StartTime >= startDay && s.StartTime < endDay)
                    .OrderBy(s => s.StartTime)
                    .ToListAsync();

                // Map to view model (use reflection-based mapping for movies too)
                var vm = new HomeVM
                {
                    NowShowingMovies = nowShowing.Select(m => MapMovieToVM(m)).ToList(),
                    UpcomingMovies = upcomingMovies.Select(m => MapMovieToVM(m)).ToList(),
                    TodayShowtimes = todayShowtimes.Select(s => MapShowtimeToVM(s)).ToList(),
                    TotalMovies = rawMovies.Count,
                    TotalUpcoming = upcomingMovies.Count,
                    TotalNowShowing = nowShowing.Count
                };

                // Optionally fetch categories if you have Categories in DbContext
                if (TableExists(nameof(_db.Categories)))
                {
                    // simple top categories by movie count
                    var categories = await _db.Categories
                        .AsNoTracking()
                        .Select(c => new
                        {
                            Category = c,
                            MovieCount = c.MovieCategories.Count
                        })
                        .OrderByDescending(x => x.MovieCount)
                        .Take(6)
                        .ToListAsync();

                    vm.PopularCategories = categories.Select(x => new CategoryVM
                    {
                        Id = GetIntProp(x.Category, "Id") ?? 0,
                        Name = GetStringProp(x.Category, "Name") ?? string.Empty,
                        Description = GetStringProp(x.Category, "Description"),
                        MovieCount = x.MovieCount
                    }).ToList();
                }

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to build HomeVM for Index");
                TempData["Error"] = "Unable to load home page data.";
                return View(new HomeVM()); // return empty VM to avoid crash
            }
        }

        #region Mapping helpers (reflection - run in-memory)
        private MovieVM MapMovieToVM(object movieEntity)
        {
            if (movieEntity == null) return new MovieVM();

            var id = GetIntProp(movieEntity, "Id") ?? 0;
            var title = GetStringProp(movieEntity, "Title") ?? "Untitled";
            var poster = GetStringProp(movieEntity, "ImageUrl") ?? GetStringProp(movieEntity, "PosterImage");
            var release = GetDateProp(movieEntity, "ReleaseDate") ?? DateTime.MinValue;
            var duration = GetIntProp(movieEntity, "Duration") ?? GetIntProp(movieEntity, "DurationMinutes");
            var price = GetDecimalProp(movieEntity, "Price");
            var status = GetPropertyValue(movieEntity, "Status");

            return new MovieVM
            {
                Id = id,
                Title = title,
                PosterImage = poster,
                ReleaseDate = release,
             
            };
        }

        private ShowtimeVM MapShowtimeToVM(object showtimeEntity)
        {
            if (showtimeEntity == null) return new ShowtimeVM();

            var id = GetIntProp(showtimeEntity, "Id") ?? 0;
            var date = GetDateProp(showtimeEntity, "StartTime") ?? GetDateProp(showtimeEntity, "ShowDateTime") ?? DateTime.MinValue;
            var price = GetDecimalProp(showtimeEntity, "Price");

            // try navigation props
            var movieObj = GetPropertyValue(showtimeEntity, "Movie");
            var movieTitle = movieObj != null ? GetStringProp(movieObj, "Title") ?? "(Unknown)" : GetStringProp(showtimeEntity, "MovieTitle") ?? "(Unknown)";

            var hallObj = GetPropertyValue(showtimeEntity, "Hall");
            var hallName = hallObj != null ? GetStringProp(hallObj, "Name") ?? "N/A" : GetStringProp(showtimeEntity, "HallName") ?? "N/A";

            var cinemaName = "N/A";
            if (hallObj != null)
            {
                var cinemaObj = GetPropertyValue(hallObj, "Cinema");
                if (cinemaObj != null) cinemaName = GetStringProp(cinemaObj, "Name") ?? "N/A";
            }
            else
            {
                cinemaName = GetStringProp(showtimeEntity, "CinemaName") ?? "N/A";
            }

            return new ShowtimeVM
            {
                Id = id,
                ShowDateTime = date,
                MovieTitle = movieTitle,
                HallName = hallName,
                CinemaName = cinemaName,
            };
        }

        private bool TableExists(string propName)
        {
            try
            {
                // check if DbContext has a DbSet property with the given name
                var prop = _db.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                return prop != null;
            }
            catch { return false; }
        }

        // reflection helpers: accept either object or typed entity
        private string? GetStringProp(object obj, string propName)
        {
            if (obj == null) return null;
            var p = obj.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (p == null) return null;
            var v = p.GetValue(obj);
            return v?.ToString();
        }

        private int? GetIntProp(object obj, string propName)
        {
            if (obj == null) return null;
            var p = obj.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (p == null) return null;
            var v = p.GetValue(obj);
            if (v == null) return null;
            try { return Convert.ToInt32(v); } catch { return null; }
        }

        private decimal? GetDecimalProp(object obj, string propName)
        {
            if (obj == null) return null;
            var p = obj.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (p == null) return null;
            var v = p.GetValue(obj);
            if (v == null) return null;
            try { return Convert.ToDecimal(v); } catch { return null; }
        }

        private DateTime? GetDateProp(object obj, string propName)
        {
            if (obj == null) return null;
            var p = obj.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (p == null) return null;
            var v = p.GetValue(obj);
            if (v == null) return null;
            try { return Convert.ToDateTime(v); } catch { return null; }
        }

        private object? GetPropertyValue(object obj, string propName)
        {
            if (obj == null) return null;
            var p = obj.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (p == null) return null;
            return p.GetValue(obj);
        }
        #endregion
    }

}
