using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VoxTics.Areas.Admin.ViewModels; // BookingViewModel (for admin usages) - optional
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.IRepositories; // BookingVM

namespace VoxTics.Controllers
{
    [Authorize]
   public class bookingController : Controller
    {
        private readonly IBookingsRepository _bookingsRepository;
        private readonly IShowtimesRepository _showtimesRepository;
        private readonly ICinemasRepository _cinemasRepository;
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;
       
        // GET: /Booking/MyBookings
        public async Task<IActionResult> MyBookings()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }
                var bookings = await _bookingsRepository.GetBookingsByUserIdAsync(userId);
                var bookingViewModels = new List<BookingViewModel>();
                foreach (var booking in bookings)
                {
                    var showtime = await _showtimesRepository.GetByIdAsync(booking.ShowtimeId);
                    if (showtime == null) continue;
                    var cinema = await _cinemasRepository.GetByIdAsync(showtime.CinemaId);
                    var movie = await _moviesRepository.GetByIdAsync(showtime.MovieId);
                    var bookingVM = new BookingViewModel
                    {
                        MovieTitle = movie?.Title ?? "Unknown",
                        CinemaName = cinema?.Name ?? "Unknown",
                    };
                    bookingViewModels.Add(bookingVM);
                }
                return View(bookingViewModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
