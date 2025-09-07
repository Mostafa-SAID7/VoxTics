using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Controllers
{
    public class ShowtimesController : Controller
    {
        private readonly IShowtimeRepository _showtimeRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ICinemaRepository _cinemaRepository;
        private readonly ILogger<ShowtimesController> _logger;

        public ShowtimesController(
            IShowtimeRepository showtimeRepository,
            IMovieRepository movieRepository,
            ICinemaRepository cinemaRepository,
            ILogger<ShowtimesController> logger)
        {
            _showtimeRepository = showtimeRepository;
            _movieRepository = movieRepository;
            _cinemaRepository = cinemaRepository;
            _logger = logger;
        }

        // GET: /Showtimes
        public async Task<IActionResult> Index(DateTime? date)
        {
            try
            {
                var showtimes = await _showtimeRepository.GetAllWithIncludesAsync(
                    s => s.Movie, s => s.Cinema, s => s.Hall);

                if (date.HasValue)
                {
                    var selectedDate = date.Value.Date;
                    showtimes = showtimes.Where(s => s.StartTime.Date == selectedDate);
                }
                else
                {
                    showtimes = showtimes.Where(s => s.StartTime >= DateTime.Now);
                }

                var vm = showtimes.OrderBy(s => s.StartTime).Select(s => new ShowtimeVM
                {
                    Id = s.Id,
                    MovieId = s.MovieId,
                    MovieTitle = s.Movie.Title,
                    MoviePosterImage = s.Movie.ImageUrl ?? "/images/default-movie-poster.jpg",
                    MovieDuration = s.Movie.Duration,
                    CinemaId = s.CinemaId,
                    CinemaName = s.Cinema.Name,
                    CinemaAddress = s.Cinema.Address,
                    HallId = s.HallId,
                    HallName = s.Hall.Name,
                    ShowDateTime = s.StartTime,
                    Price = s.Price,
                    Status = s.Status,
                    AvailableSeats = s.AvailableSeats,
                    TotalSeats = s.TotalSeats
                }).ToList();

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching showtimes");
                TempData["Error"] = "Unable to load showtimes.";
                return View(Enumerable.Empty<ShowtimeVM>());
            }
        }

        // GET: /Showtimes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var showtime = await _showtimeRepository.GetByIdWithIncludesAsync(
                    id, s => s.Movie, s => s.Cinema, s => s.Hall);

                if (showtime == null)
                    return NotFound();

                var vm = new ShowtimeVM
                {
                    Id = showtime.Id,
                    MovieId = showtime.MovieId,
                    MovieTitle = showtime.Movie.Title,
                    MoviePosterImage = showtime.Movie.ImageUrl ?? "/images/default-movie-poster.jpg",
                    MovieDuration = showtime.Movie.Duration,
                    CinemaId = showtime.CinemaId,
                    CinemaName = showtime.Cinema.Name,
                    CinemaAddress = showtime.Cinema.Address,
                    HallId = showtime.HallId,
                    HallName = showtime.Hall.Name,
                    ShowDateTime = showtime.StartTime,
                    Price = showtime.Price,
                    Status = showtime.Status,
                    AvailableSeats = showtime.AvailableSeats,
                    TotalSeats = showtime.TotalSeats
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching showtime details for id={id}");
                TempData["Error"] = "Unable to load showtime details.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: /Showtimes/ByMovie/3
        public async Task<IActionResult> ByMovie(int movieId)
        {
            try
            {
                var showtimes = await _showtimeRepository.FindWithIncludesAsync(
                    s => s.MovieId == movieId,
                    s => s.Movie, s => s.Cinema, s => s.Hall);

                if (!showtimes.Any())
                    return NotFound();

                var vm = showtimes.Select(s => new ShowtimeVM
                {
                    Id = s.Id,
                    MovieId = s.MovieId,
                    MovieTitle = s.Movie.Title,
                    MoviePosterImage = s.Movie.ImageUrl ?? "/images/default-movie-poster.jpg",
                    MovieDuration = s.Movie.Duration,
                    CinemaId = s.CinemaId,
                    CinemaName = s.Cinema.Name,
                    CinemaAddress = s.Cinema.Address,
                    HallId = s.HallId,
                    HallName = s.Hall.Name,
                    ShowDateTime = s.StartTime,
                    Price = s.Price,
                    Status = s.Status,
                    AvailableSeats = s.AvailableSeats,
                    TotalSeats = s.TotalSeats
                }).OrderBy(s => s.ShowDateTime).ToList();

                ViewBag.MovieTitle = showtimes.First().Movie.Title;
                return View("Index", vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching showtimes for movieId={movieId}");
                TempData["Error"] = "Unable to load movie showtimes.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: /Showtimes/ByCinema/2
        public async Task<IActionResult> ByCinema(int cinemaId)
        {
            try
            {
                var showtimes = await _showtimeRepository.FindWithIncludesAsync(
                    s => s.CinemaId == cinemaId,
                    s => s.Movie, s => s.Cinema, s => s.Hall);

                if (!showtimes.Any())
                    return NotFound();

                var vm = showtimes.Select(s => new ShowtimeVM
                {
                    Id = s.Id,
                    MovieId = s.MovieId,
                    MovieTitle = s.Movie.Title,
                    MoviePosterImage = s.Movie.ImageUrl ?? "/images/default-movie-poster.jpg",
                    MovieDuration = s.Movie.Duration,
                    CinemaId = s.CinemaId,
                    CinemaName = s.Cinema.Name,
                    CinemaAddress = s.Cinema.Address,
                    HallId = s.HallId,
                    HallName = s.Hall.Name,
                    ShowDateTime = s.StartTime,
                    Price = s.Price,
                    Status = s.Status,
                    AvailableSeats = s.AvailableSeats,
                    TotalSeats = s.TotalSeats
                }).OrderBy(s => s.ShowDateTime).ToList();

                ViewBag.CinemaName = showtimes.First().Cinema.Name;
                return View("Index", vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching showtimes for cinemaId={cinemaId}");
                TempData["Error"] = "Unable to load cinema showtimes.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
