using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VoxTics.Services.Interfaces;

namespace VoxTics.Controllers
{

    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService) => _homeService = homeService;

        public async Task<IActionResult> Index()
        {
            var nowShowing = await _homeService.GetNowShowingAsync();
            var comingSoon = await _homeService.GetComingSoonAsync();
            var cinemas = await _homeService.GetCinemasAsync();

            var viewModel = new
            {
                NowShowing = nowShowing,
                ComingSoon = comingSoon,
                Cinemas = cinemas
            };

            return View(viewModel);
        }

        public IActionResult Contact() => View();
        public IActionResult About() => View();
    }

}
