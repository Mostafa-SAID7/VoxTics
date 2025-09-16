using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.ViewModels.Cinema;
using VoxTics.Models.ViewModels.Home;
using VoxTics.Models.ViewModels.Movie;
using VoxTics.Services.Interfaces;

namespace VoxTics.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
        {
            // Fetch data from service
            var nowShowing = await _homeService.GetNowShowingAsync();
            var comingSoon = await _homeService.GetComingSoonAsync();
            var featured = await _homeService.GetFeaturedMoviesAsync();
            var cinemas = await _homeService.GetCinemasAsync();

            // Map entities to view models
            var model = new HomeVM
            {
                NowShowing = nowShowing.Select(m => new MovieVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    PosterImage = m.MovieImages.FirstOrDefault()?.AltText
                }).ToList(),

                ComingSoon = comingSoon.Select(m => new MovieVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    PosterImage = m.MovieImages.FirstOrDefault()?.AltText,
                    ReleaseDate = m.Showtimes.Min(s => s.StartTime)
                }).ToList(),

                Featured = featured.Select(m => new MovieVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    PosterImage = m.MovieImages.FirstOrDefault()?.AltText
                }).ToList(),

                Cinemas = cinemas.Select(c => new CinemaVM
                {
                    Id = c.Id,
                    Name = c.Name,
                    Country = c.City
                }).ToList()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> NowShowing(CancellationToken cancellationToken = default)
        {
            var movies = await _homeService.GetNowShowingAsync();
            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> ComingSoon(CancellationToken cancellationToken = default)
        {
            var movies = await _homeService.GetComingSoonAsync();
            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Featured(CancellationToken cancellationToken = default)
        {
            var movies = await _homeService.GetFeaturedMoviesAsync();
            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Cinemas(CancellationToken cancellationToken = default)
        {
            var cinemas = await _homeService.GetCinemasAsync();
            return View(cinemas);
        }
    }
}
