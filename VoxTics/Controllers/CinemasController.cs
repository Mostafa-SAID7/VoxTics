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

                if (!string.IsNullOrWhiteSpace(searchTerm))
                    cinemas = await _cinemaRepository.SearchCinemasAsync(searchTerm);
                else
                    cinemas = await _cinemaRepository.GetAllAsync();

                var vms = cinemas.Select(c => new CinemaVM
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Location = c.Address,
                    Email = c.Email,
                    Phone = c.Phone,
                    Website = c.Website,
                    ImageUrl = c.ImageUrl,
                    HallCount = c.Halls?.Count ?? 0
                }).ToList();

                return View(vms);
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
            try
            {
                var cinema = await _cinemaRepository.GetByIdWithIncludesAsync(
                    id,
                    c => c.Halls!,
                    c => c.SocialMediaLinks!
                );

                if (cinema == null) return NotFound();

                var upcomingShowtimes = await _showtimeRepository.GetUpcomingShowtimesAsync(id);

                var vm = new CinemaVM
                {
                    Id = cinema.Id,
                    Name = cinema.Name,
                    Description = cinema.Description,
                    Location = cinema.Address,
                    Email = cinema.Email,
                    Phone = cinema.Phone,
                    Website = cinema.Website,
                    ImageUrl = cinema.ImageUrl,
                    HallCount = cinema.Halls?.Count ?? 0,
                    SocialMediaLinks = cinema.SocialMediaLinks?
                        .Select(sm => new SocialMediaLinkVM
                        {
                            Platform = sm.Platform,
                            Url = sm.Url
                        }).ToList() ?? new List<SocialMediaLinkVM>(),
                    Showtimes = upcomingShowtimes.Select(st => new ShowtimeVM
                    {
                        Id = st.Id,
                        ShowDateTime = st.StartTime,
                        MovieTitle = st.Movie?.Title ?? "Unknown",
                        HallName = st.Hall?.Name ?? "N/A",
                        Price = st.Price
                    }).ToList()
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading cinema {CinemaId}", id);
                TempData["Error"] = "Unable to load cinema.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
