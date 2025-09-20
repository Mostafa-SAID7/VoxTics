using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Models.ViewModels.Booking;
using VoxTics.Services.Interfaces;
using VoxTics.Services.IServices;

namespace VoxTics.Controllers
{
    [Authorize] 
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IMovieService _movieService;

        public BookingsController(IBookingService bookingService, IMovieService movieService)
        {
            _bookingService = bookingService;
            _movieService = movieService;
        }

        // GET: Bookings/MyBookings
        public async Task<IActionResult> MyBookings()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            var bookings = await _bookingService.GetUserBookingsAsync(userId);
            return View(bookings); // View: Views/Bookings/MyBookings.cshtml
        }

        // GET: Bookings/Create?movieId=5
        [HttpGet]
        public async Task<IActionResult> Create(int movieId)
        {
            var movie = await _movieService.GetDetailsAsync(movieId);
            if (movie == null) return NotFound();

            var model = new BookingCreateVM
            {
                MovieId = movieId,
                CinemaId = movie.CinemaId, 
                ShowtimeId = movie.Showtimes.FirstOrDefault()?.Id ?? 0,
                SeatIds = new List<int>(),
                SeatPrice = movie.Price,
                TotalAmount = 0,
                DiscountAmount = 0,
                FinalAmount = 0,
                PaymentMethod = VoxTics.Models.Enums.PaymentMethod.Undefined
            };

            return View(model); // View: Views/Bookings/Create.cshtml
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingCreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            var booking = await _bookingService.CreateBookingAsync(model, userId);

            return RedirectToAction(nameof(Details), new { id = booking.BookingId });
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            var booking = await _bookingService.GetBookingDetailsAsync(id, userId);
            if (booking == null) return NotFound();

            return View(booking); // View: Views/Bookings/Details.cshtml
        }

        // POST: Bookings/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            var success = await _bookingService.CancelBookingAsync(id, userId);

            TempData["Message"] = success ? "Booking cancelled successfully." : "Unable to cancel booking.";
            return RedirectToAction(nameof(MyBookings));
        }
    }
}
