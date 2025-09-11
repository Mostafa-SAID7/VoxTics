using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Enums;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IMoviesRepository _movieRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly ICategoriesRepository _categoryRepository;
        private readonly IShowtimesRepository _showtimeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
    IMoviesRepository movieRepository,
    IUserRepository userRepository,
    IBookingRepository bookingRepository,
    ICategoriesRepository categoryRepository,
    IShowtimesRepository showtimeRepository, 
    IMapper mapper,
    ILogger<HomeController> logger)
        {
            _movieRepository = movieRepository;
            _userRepository = userRepository;
            _bookingRepository = bookingRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;

            _showtimeRepository = showtimeRepository;
        }


        // GET: Admin/Home/Index
        public async Task<IActionResult> Index()
        {
            try
            {
                var vm = new AdminDashboardViewModel();

                // Totals
                vm.TotalMovies = await _movieRepository.CountAsync();
                vm.TotalUsers = await _userRepository.CountAsync();
                vm.TotalBookings = await _bookingRepository.CountAsync();
                vm.TotalCategories = await _categoryRepository.CountAsync();

                // If you have a cinema repo inject it; otherwise leave 0
                vm.TotalCinemas = 0;

                // Revenue
                var now = DateTime.UtcNow;
                vm.TotalRevenue = await _bookingRepository.GetTotalRevenueAsync();

                var startOfMonth = new DateTime(now.Year, now.Month, 1);
                vm.MonthlyRevenue = await _bookingRepository.GetRevenueByDateRangeAsync(startOfMonth, now);

                var startOfDay = now.Date;
                vm.DailyRevenue = await _bookingRepository.GetRevenueByDateRangeAsync(startOfDay, now);

                // Movies by status
                vm.UpcomingMovies = await _movieRepository.GetMovieCountByStatusAsync(MovieStatus.Upcoming);
                vm.EndedMovies = await _movieRepository.GetMovieCountByStatusAsync(MovieStatus.Ended);

                // Bookings by status
                vm.PendingBookings = await _bookingRepository.GetBookingCountByStatusAsync(BookingStatus.Pending);
                vm.ConfirmedBookings = await _bookingRepository.GetBookingCountByStatusAsync(BookingStatus.Confirmed);
                vm.CancelledBookings = await _bookingRepository.GetBookingCountByStatusAsync(BookingStatus.Cancelled);

                // Recent lists (map to viewmodels)
                var recentMovies = (await _movieRepository.GetMoviesForAdminAsync())
                    .OrderByDescending(m => m.CreatedAt)
                    .Take(5)
                    .ToList();
                vm.RecentMovies = recentMovies.Select(m => _mapper.Map<MovieViewModel>(m)).ToList();

                var recentBookings = (await _bookingRepository.GetBookingsForAdminAsync())
                    .OrderByDescending(b => b.CreatedAt)
                    .Take(5)
                    .ToList();
                vm.RecentBookings = recentBookings.Select(b => _mapper.Map<BookingViewModel>(b)).ToList();

                var recentUsers = (await _userRepository.GetUsersForAdminAsync())
                    .OrderByDescending(u => u.CreatedAt)
                    .Take(5)
                    .ToList();
                vm.RecentUsers = recentUsers.Select(u => _mapper.Map<UserViewModel>(u)).ToList();

                // Monthly bookings last 30 days — produce Dictionary<string,int> keyed by yyyy-MM-dd
                var start30 = DateTime.UtcNow.Date.AddDays(-29); // include today => 30 days
                var bookings30 = await _bookingRepository.GetBookingsByDateRangeAsync(start30, DateTime.UtcNow);

                // group by Date (DateTime.Date)
                var groupedByDate = bookings30
                    .GroupBy(b => b.BookingDate.Date)
                    .ToDictionary(g => g.Key, g => g.Count()); // Dictionary<DateTime,int>

                var monthlyBookings = new Dictionary<string, int>();
                for (int i = 0; i < 30; i++)
                {
                    var d = start30.AddDays(i).Date;
                    var key = d.ToString("yyyy-MM-dd");
                    monthlyBookings[key] = groupedByDate.TryGetValue(d, out var cnt) ? cnt : 0;
                }
                vm.MonthlyBookings = monthlyBookings;

                // Monthly revenue series from repository (assumes keys are strings)
                vm.MonthlyRevenueSeries = await _bookingRepository.GetMonthlyRevenueStatsAsync(now.Year);

                // Widgets dictionaries
                vm.MoviesByStatus = new Dictionary<MovieStatus, int>
                {
                    [MovieStatus.Upcoming] = vm.UpcomingMovies,
                    [MovieStatus.NowShowing] = vm.NowShowingMovies,
                    [MovieStatus.Ended] = vm.EndedMovies
                };

                vm.BookingsByStatus = new Dictionary<BookingStatus, int>
                {
                    [BookingStatus.Pending] = vm.PendingBookings,
                    [BookingStatus.Confirmed] = vm.ConfirmedBookings,
                    [BookingStatus.Cancelled] = vm.CancelledBookings
                };

                // Top movies and cinemas
                var topMovies = await _bookingRepository.GetTopMoviesByBookingsAsync(5);
                vm.PopularMovies = topMovies.Select(t => _mapper.Map<MovieViewModel>(t.movie)).ToList();


                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading admin dashboard");
                TempData["Error"] = "Unable to load dashboard data";
                return View(new AdminDashboardViewModel());
            }
        }
    }
}
