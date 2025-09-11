using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Controllers
{
    public class ShowtimesController : Controller
    {
        private readonly IShowtimesRepository _showtimeRepository;
        private readonly IMoviesRepository _movieRepository;
        private readonly ICinemasRepository _cinemaRepository;
        private readonly ILogger<ShowtimesController> _logger;

        public ShowtimesController(
            IShowtimesRepository showtimeRepository,
            IMoviesRepository movieRepository,
            ICinemasRepository cinemaRepository,
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
           return View();
        }

        // GET: /Showtimes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            
                return RedirectToAction(nameof(Index));
            
        }

        // GET: /Showtimes/ByMovie/3
        public async Task<IActionResult> ByMovie(int movieId)
        {
         return View();
        }

        // GET: /Showtimes/ByCinema/2
        public async Task<IActionResult> ByCinema(int cinemaId)
        {
         return View();
        }
    }
}
