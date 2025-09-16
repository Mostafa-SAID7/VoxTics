using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
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
            var nowShowing = await _homeService.GetNowShowingAsync();
            var comingSoon = await _homeService.GetComingSoonAsync();
            var featured = await _homeService.GetFeaturedMoviesAsync();
            var cinemas = await _homeService.GetCinemasAsync();

            var model = new
            {
                NowShowing = nowShowing,
                ComingSoon = comingSoon,
                Featured = featured,
                Cinemas = cinemas
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
