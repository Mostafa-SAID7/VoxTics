using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICinemaRepository _cinemaRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IShowtimeRepository _showtimeRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IMovieRepository movieRepository,
            ICinemaRepository cinemaRepository,
            ICategoryRepository categoryRepository,
            IShowtimeRepository showtimeRepository,
            ILogger<HomeController> logger)
        {
            _movieRepository = movieRepository;
            _cinemaRepository = cinemaRepository;
            _categoryRepository = categoryRepository;
            _showtimeRepository = showtimeRepository;
            _logger = logger;
        }

        // GET: /
        public async Task<IActionResult> Index()
        {
            try
            {
                var featuredMovies = await _movieRepository.GetFeaturedMoviesAsync(6);
                var nowShowing = await _movieRepository.GetFeaturedMoviesAsync(12);
                var upcoming = await _movieRepository.GetUpcomingMoviesAsync(12);
                var categories = await _categoryRepository.GetTopCategoriesByMoviesAsync(6);
                var todayShowtimes = await _showtimeRepository.GetTodaysShowtimesAsync();

                var vm = new HomeVM
                {
                    FeaturedMovies = featuredMovies.Select(m => new MovieVM
                    {
                        Id = m.Id,
                        Title = m.Title,
                        PosterImage = m.ImageUrl,
                        ReleaseDate = m.ReleaseDate,
                        Status = m.Status,
                        DurationInMinutes = m.Duration
                    }).ToList(),

                    NowShowingMovies = nowShowing.Select(m => new MovieVM
                    {
                        Id = m.Id,
                        Title = m.Title,
                        PosterImage = m.ImageUrl,
                        ReleaseDate = m.ReleaseDate,
                        Status = m.Status,
                        DurationInMinutes = m.Duration
                    }).ToList(),

                    UpcomingMovies = upcoming.Select(m => new MovieVM
                    {
                        Id = m.Id,
                        Title = m.Title,
                        PosterImage = m.ImageUrl,
                        ReleaseDate = m.ReleaseDate,
                        Status = m.Status,
                        DurationInMinutes = m.Duration
                    }).ToList(),

                  

                    PopularCategories = categories.Select(c => new CategoryVM
                    {
                        Id = c.category.Id,
                        Name = c.category.Name,
                        Description = c.category.Description,
                        MovieCount = c.movieCount
                    }).ToList(),

                    TodayShowtimes = todayShowtimes.Select(st => new ShowtimeVM
                    {
                        Id = st.Id,
                        ShowDateTime = st.StartTime,
                        MovieTitle = st.Movie?.Title ?? "Unknown",
                        HallName = st.Hall?.Name ?? "N/A",
                        CinemaName = st.Hall?.Cinema?.Name ?? "N/A",
                        Price = st.Price
                    }).ToList(),

                    TotalMovies = featuredMovies.Count(),
                    TotalUpcoming = upcoming.Count(),
                    TotalNowShowing = nowShowing.Count()
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading home page");
                TempData["Error"] = "Unable to load home page data.";
                return View(new HomeVM());
            }
        }
    }
}
