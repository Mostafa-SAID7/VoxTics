using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.ViewModels.Booking;
using VoxTics.Models.ViewModels.Cinema;
using VoxTics.Models.ViewModels.Filter;
using VoxTics.Models.ViewModels.Showtime;
using VoxTics.Services.Interfaces;

namespace VoxTics.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemasController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            try
            {
                var cinemaEntities = await _cinemaService.GetActiveCinemasAsync(cancellationToken);

                var cinemas = cinemaEntities.Select(c => new CinemaVM
                {
                    Id = c.Id,
                    Name = c.Name,
                    Country = string.IsNullOrEmpty(c.Country) ? "Unknown" : c.Country,
                    DisplayImage = string.IsNullOrEmpty(c.DisplayImage)
                        ? "/images/default-cinema.jpg"
                        : c.DisplayImage
                }).ToList();

                return View(cinemas);
            }
            catch (TaskCanceledException)
            {
                return View(Enumerable.Empty<CinemaVM>());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching cinemas: {ex.Message}");
                return View(Enumerable.Empty<CinemaVM>());
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Browse(
            int page = 1,
            int pageSize = 10,
            string? search = null,
            string? sort = null,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var pagedCinemas = await _cinemaService.GetPagedCinemasAsync(page, pageSize, search, sort, cancellationToken);
                return View(pagedCinemas);
            }
            catch (TaskCanceledException)
            {
                return View(null); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error browsing cinemas: {ex.Message}");
                return View(null);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            try
            {
                var cinemaEntity = await _cinemaService.GetCinemaDetailsAsync(id, cancellationToken);

                if (cinemaEntity == null)
                {
                    var emptyCinema = new CinemaDetailsVM
                    {
                        Id = id,
                        Name = "Cinema not found",
                        DisplayImage = "/images/default-cinema.jpg",
                        Country = "Unknown",
                        Halls = new List<HallVM>(),
                        Showtimes = new List<ShowtimeVM>(),
                        Bookings = new List<BookingDetailsVM>(),
                        SocialMediaLinks = new List<SocialMediaLinkVM>()
                    };
                    ViewBag.Showtimes = new List<ShowtimeVM>();
                    return View(emptyCinema);
                }

                // تحويل Entity → ViewModel
                var cinema = new CinemaDetailsVM
                {
                    Id = cinemaEntity.Id,
                    Name = cinemaEntity.Name ?? "Unknown",
                    Description = cinemaEntity.Description ?? string.Empty,
                    Email = cinemaEntity.Email ?? string.Empty,
                    Phone = cinemaEntity.Phone ?? string.Empty,
                    Address = cinemaEntity.Address ?? string.Empty,
                    City = cinemaEntity.City ?? string.Empty,
                    State = cinemaEntity.State ?? string.Empty,
                    Country = cinemaEntity.Country ?? "Unknown",
                    PostalCode = cinemaEntity.PostalCode ?? string.Empty,
                    Website = cinemaEntity.Website ?? string.Empty,
                    DisplayImage = string.IsNullOrEmpty(cinemaEntity.DisplayImage)
                        ? "/images/default-cinema.jpg"
                        : cinemaEntity.DisplayImage,
                    IsActive = cinemaEntity.IsActive,
                    Halls = cinemaEntity.Halls?.Select(h => new HallVM
                    {
                        Id = h.Id,
                        Name = h.Name,
                    }).ToList() ?? new List<HallVM>(),
                    Showtimes = cinemaEntity.Showtimes?.Select(s => new ShowtimeVM
                    {
                        Id = s.Id,
                        StartTime = s.StartTime,
                        MovieId = s.MovieId
                    }).ToList() ?? new List<ShowtimeVM>(),
                    
                   
                };

            

                return View(cinema);
            }
            catch (TaskCanceledException)
            {
                // المهمة أُلغيّت، إنشاء نموذج افتراضي للعرض
                var canceledCinema = new CinemaDetailsVM
                {
                    Id = id,
                    Name = "Operation canceled",
                    DisplayImage = "/images/default-cinema.jpg",
                    Country = "Unknown",
                    Halls = new List<HallVM>(),
                    Showtimes = new List<ShowtimeVM>(),
                    Bookings = new List<BookingDetailsVM>(),
                    SocialMediaLinks = new List<SocialMediaLinkVM>()
                };
                ViewBag.Showtimes = new List<ShowtimeVM>();
                return View(canceledCinema);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching cinema details: {ex.Message}");

                var errorCinema = new CinemaDetailsVM
                {
                    Id = id,
                    Name = "Error loading cinema",
                    DisplayImage = "/images/default-cinema.jpg",
                    Country = "Unknown",
                    Halls = new List<HallVM>(),
                    Showtimes = new List<ShowtimeVM>(),
                    Bookings = new List<BookingDetailsVM>(),
                    SocialMediaLinks = new List<SocialMediaLinkVM>()
                };
                ViewBag.Showtimes = new List<ShowtimeVM>();
                return View(errorCinema);
            }
        }
    }
}
