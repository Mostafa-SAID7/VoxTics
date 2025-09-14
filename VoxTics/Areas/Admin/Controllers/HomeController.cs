using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IDashboardService _dashboardService;
        private readonly IMapper _mapper;

        public HomeController(IDashboardService dashboardService, IMapper mapper)
        {
            _dashboardService = dashboardService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            // Create strongly-typed ViewModel
            var dashboardVM = new AdminDashboardViewModel
            {
                // Overall statistics
                TotalMovies = await _dashboardService.GetTotalMoviesAsync(),
                TotalUsers = await _dashboardService.GetTotalUsersAsync(),
                TotalBookings = await _dashboardService.GetTotalBookingsAsync(),
                TotalCinemas = await _dashboardService.GetTotalCinemasAsync(),
                TotalCategories = await _dashboardService.GetTotalCategoriesAsync(),
                TotalShowtimes = await _dashboardService.GetTotalShowtimesAsync(),
                TotalHalls = await _dashboardService.GetTotalHallsAsync(),
                TotalRevenue = await _dashboardService.GetTotalRevenueAsync(),

                // Revenue statistics
                MonthlyRevenue = await _dashboardService.GetMonthlyRevenueAsync(),
                DailyRevenue = await _dashboardService.GetDailyRevenueAsync(),

                // Movie statistics
                UpcomingMovies = await _dashboardService.GetUpcomingMoviesCountAsync(),
                NowShowingMovies = await _dashboardService.GetNowShowingMoviesCountAsync(),
                EndedMovies = await _dashboardService.GetEndedMoviesCountAsync(),

                // Booking statistics
                PendingBookings = await _dashboardService.GetPendingBookingsCountAsync(),
                ConfirmedBookings = await _dashboardService.GetConfirmedBookingsCountAsync(),
                CancelledBookings = await _dashboardService.GetCancelledBookingsCountAsync()
            };

            // Populate read-only collections
            var recentMovies = await _dashboardService.GetRecentMoviesAsync();
            var recentBookings = await _dashboardService.GetRecentBookingsAsync();
            var recentUsers = await _dashboardService.GetRecentUsersAsync();
            var popularMovies = await _dashboardService.GetPopularMoviesAsync();
            var popularCinemas = await _dashboardService.GetPopularCinemasAsync();

            var monthlyBookings = await _dashboardService.GetMonthlyBookingsAsync();
            var monthlyRevenueSeries = await _dashboardService.GetMonthlyRevenueSeriesAsync();
            var moviesByStatus = await _dashboardService.GetMoviesByStatusAsync();
            var bookingsByStatus = await _dashboardService.GetBookingsByStatusAsync();

            // Map entities to ViewModels using AutoMapper
            ((List<MovieListItemViewModel>)dashboardVM.RecentMovies).AddRange(_mapper.Map<List<MovieListItemViewModel>>(recentMovies));
            ((List<BookingViewModel>)dashboardVM.RecentBookings).AddRange(_mapper.Map<List<BookingViewModel>>(recentBookings));
            ((List<ApplicationInfo>)dashboardVM.RecentUsers).AddRange(_mapper.Map<List<ApplicationInfo>>(recentUsers));
            ((List<MovieListItemViewModel>)dashboardVM.PopularMovies).AddRange(_mapper.Map<List<MovieListItemViewModel>>(popularMovies));
            ((List<CinemaViewModel>)dashboardVM.PopularCinemas).AddRange(_mapper.Map<List<CinemaViewModel>>(popularCinemas));

            ((Dictionary<string, int>)dashboardVM.MonthlyBookings).Clear();
            foreach (var kv in monthlyBookings) ((Dictionary<string, int>)dashboardVM.MonthlyBookings).Add(kv.Key, kv.Value);

            ((Dictionary<string, decimal>)dashboardVM.MonthlyRevenueSeries).Clear();
            foreach (var kv in monthlyRevenueSeries) ((Dictionary<string, decimal>)dashboardVM.MonthlyRevenueSeries).Add(kv.Key, kv.Value);

            ((Dictionary<MovieStatus, int>)dashboardVM.MoviesByStatus).Clear();
            foreach (var kv in moviesByStatus) ((Dictionary<MovieStatus, int>)dashboardVM.MoviesByStatus).Add(kv.Key, kv.Value);

            ((Dictionary<BookingStatus, int>)dashboardVM.BookingsByStatus).Clear();
            foreach (var kv in bookingsByStatus) ((Dictionary<BookingStatus, int>)dashboardVM.BookingsByStatus).Add(kv.Key, kv.Value);

            // Return strongly-typed ViewModel to the view
            return View(dashboardVM);
        }
    }
}
