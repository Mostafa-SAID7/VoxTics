using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly ICinemaRepository _cinemaRepo;
        private readonly IShowtimeRepository _showtimeRepo;
        private readonly IMapper _mapper;

        public HomeController(
            IMovieRepository movieRepo,
            ICinemaRepository cinemaRepo,
            IShowtimeRepository showtimeRepo,
            IMapper mapper)
        {
            _movieRepo = movieRepo;
            _cinemaRepo = cinemaRepo;
            _showtimeRepo = showtimeRepo;
            _mapper = mapper;
        }

        // Landing page
        public async Task<IActionResult> Index()
        {
            var movies = (await _movieRepo.GetAllAsync("Genre")).Take(6); // latest 6 movies
            var cinemas = (await _cinemaRepo.GetAllAsync()).Take(4);     // highlight 4 cinemas
            var showtimes = (await _showtimeRepo.GetAllAsync("Movie,Cinema"))
                            .OrderBy(s => s.StartTime)
                            .Take(6); // next 6 showtimes

            var vm = new HomeVM
            {
                Movies = movies.Select(m => _mapper.Map<MovieVM>(m)).ToList(),
                Cinemas = cinemas.Select(c => _mapper.Map<CinemaVM>(c)).ToList(),
                Showtimes = showtimes.Select(s => _mapper.Map<ShowtimeVM>(s)).ToList()
            };

            return View(vm);
        }

        public IActionResult About() => View();
        public IActionResult Contact() => View();
    }
}
