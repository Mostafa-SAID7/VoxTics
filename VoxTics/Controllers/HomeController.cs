using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _homeService = homeService ?? throw new ArgumentNullException(nameof(homeService));
        }

        // GET: Home/Index
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
        {
            // Fetch data from service
            var nowShowing = await _homeService.GetNowShowingAsync();
            var comingSoon = await _homeService.GetComingSoonAsync();
            var featured = await _homeService.GetFeaturedMoviesAsync();
            var cinemas = await _homeService.GetCinemasAsync();

            // Map entities to view models (null-safe)
            var model = new HomeVM
            {
                NowShowing = nowShowing?.Select(m => new MovieVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    MainImageUrl = m.MovieImages?.FirstOrDefault()?.AltText ?? "/images/defaults/placeholder.png"
                }).ToList() ?? new List<MovieVM>(),

                ComingSoon = comingSoon?.Select(m => new MovieVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    MainImageUrl = m.MovieImages?.FirstOrDefault()?.AltText ?? "/images/defaults/placeholder.png",
                  
                }).ToList() ?? new List<MovieVM>(),

                Featured = featured?.Select(m => new MovieVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    MainImageUrl = m.MovieImages?.FirstOrDefault()?.AltText ?? "/images/defaults/placeholder.png"
                }).ToList() ?? new List<MovieVM>(),

                Cinemas = cinemas?.Select(c => new CinemaVM
                {
                    Id = c.Id,
                    Name = c.Name,
                    Country = string.IsNullOrWhiteSpace(c.City) ? "Unknown" : c.City
                }).ToList() ?? new List<CinemaVM>()
            };

            return View(model);
        }

        
    }
}
