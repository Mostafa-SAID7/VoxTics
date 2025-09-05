using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly ICinemaRepository _cinemaRepo;
        private readonly IShowtimeRepository _showtimeRepo;
        private readonly IBookingRepository _bookingRepo;
        private readonly IUserRepository _userRepo;

        public HomeController(
            IMovieRepository movieRepo,
            ICinemaRepository cinemaRepo,
            IShowtimeRepository showtimeRepo,
            IBookingRepository bookingRepo,
            IUserRepository userRepo)
        {
            _movieRepo = movieRepo;
            _cinemaRepo = cinemaRepo;
            _showtimeRepo = showtimeRepo;
            _bookingRepo = bookingRepo;
            _userRepo = userRepo;
        }

        // Dashboard
        public async Task<IActionResult> Index()
        {
            var movies = await _movieRepo.GetAllAsync();
            var cinemas = await _cinemaRepo.GetAllAsync();
            var showtimes = await _showtimeRepo.GetAllAsync();
            var bookings = await _bookingRepo.GetAllAsync();
            var users = await _userRepo.GetAllAsync();

            var vm = new AdminDashboardVM
            {
                MovieCount = movies.Count(),
                CinemaCount = cinemas.Count(),
                ShowtimeCount = showtimes.Count(),
                BookingCount = bookings.Count(),
                UserCount = users.Count()
            };

            return View(vm);
        }
    }
}
