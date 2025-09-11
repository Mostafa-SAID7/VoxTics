using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasRepository _cinemaRepository;
        private readonly IShowtimesRepository _showtimeRepository;
        private readonly ILogger<CinemasController> _logger;

        public CinemasController(
            ICinemasRepository cinemaRepository,
            IShowtimesRepository showtimeRepository,
            ILogger<CinemasController> logger)
        {
            _cinemaRepository = cinemaRepository ?? throw new ArgumentNullException(nameof(cinemaRepository));
            _showtimeRepository = showtimeRepository ?? throw new ArgumentNullException(nameof(showtimeRepository));
            _logger = logger;
        }

        // GET: /Cinemas
        public async Task<IActionResult> Index(string? searchTerm)
        {
            try
            {
                IEnumerable<Cinema> cinemas;

             
             
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading cinemas");
                TempData["Error"] = "Unable to load cinemas.";
                return View(new List<CinemaVM>());
            }
        }

        // GET: /Cinemas/Details/5
        public async Task<IActionResult> Details(int id)
        {
          return View();
        }
    }
}
