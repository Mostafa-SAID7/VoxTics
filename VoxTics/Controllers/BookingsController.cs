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
        private readonly IShowtimeService _showtimeService;

        public BookingsController(IBookingService bookingService, IShowtimeService showtimeService)
        {
            _bookingService = bookingService;
            _showtimeService = showtimeService;
        }

        // GET: Bookings/MyBookings
        public async Task<IActionResult> MyBookings()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            var bookings = await _bookingService.GetUserBookingsAsync(userId);
            return View(bookings);
        }

        // GET: Bookings/Create?showtimeId=5
        [HttpGet]
        public async Task<IActionResult> Create(int showtimeId)
        {
            if (showtimeId <= 0) return BadRequest("A valid showtime must be selected.");

            var showtime = await _showtimeService.GetShowtimeByIdAsync(showtimeId);
            if (showtime == null) return NotFound("Showtime not found.");
            if (showtime.IsCancelled) return BadRequest("This showtime has been cancelled.");

            var seats = showtime.Hall?.Seats?
                .Where(s => s.IsActive)
                .OrderBy(s => s.Row)
                .ThenBy(s => s.NumberInRow)
                .Select(s => new SeatOptionVM
                {
                    SeatId      = s.Id,
                    SeatNumber  = s.SeatNumber,
                    Row         = s.Row,
                    NumberInRow = s.NumberInRow,
                    SeatType    = s.Type.ToString(),
                    IsAvailable = s.IsAvailable
                })
                .ToList() ?? new List<SeatOptionVM>();

            var model = new BookingCreateVM
            {
                MovieId          = showtime.MovieId,
                CinemaId         = showtime.CinemaId,
                ShowtimeId       = showtime.Id,
                SeatPrice        = showtime.Price,
                TotalAmount      = 0,
                DiscountAmount   = 0,
                FinalAmount      = 0,
                PaymentMethod    = VoxTics.Models.Enums.PaymentMethod.Undefined,
                MovieTitle       = showtime.Movie?.Title ?? string.Empty,
                MovieMainImage   = showtime.Movie?.MainImage ?? string.Empty,
                CinemaName       = showtime.Cinema?.Name ?? string.Empty,
                HallName         = showtime.Hall?.Name ?? string.Empty,
                ShowtimeStart    = showtime.StartTime,
                ShowtimeDuration = showtime.Duration,
                AvailableSeatsCount = showtime.AvailableSeats,
                AvailableSeats   = seats,
                SeatIds          = new List<int>()
            };

            return View(model);
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingCreateVM model)
        {
            // Re-populate display fields on validation failure
            if (!ModelState.IsValid)
            {
                if (model.ShowtimeId > 0)
                {
                    var showtime = await _showtimeService.GetShowtimeByIdAsync(model.ShowtimeId);
                    if (showtime != null)
                    {
                        model.MovieTitle        = showtime.Movie?.Title ?? string.Empty;
                        model.MovieMainImage    = showtime.Movie?.MainImage ?? string.Empty;
                        model.CinemaName        = showtime.Cinema?.Name ?? string.Empty;
                        model.HallName          = showtime.Hall?.Name ?? string.Empty;
                        model.ShowtimeStart     = showtime.StartTime;
                        model.ShowtimeDuration  = showtime.Duration;
                        model.AvailableSeatsCount = showtime.AvailableSeats;
                        model.SeatPrice         = showtime.Price;
                        model.AvailableSeats    = showtime.Hall?.Seats?
                            .Where(s => s.IsActive)
                            .OrderBy(s => s.Row).ThenBy(s => s.NumberInRow)
                            .Select(s => new SeatOptionVM
                            {
                                SeatId      = s.Id,
                                SeatNumber  = s.SeatNumber,
                                Row         = s.Row,
                                NumberInRow = s.NumberInRow,
                                SeatType    = s.Type.ToString(),
                                IsAvailable = s.IsAvailable
                            }).ToList() ?? new List<SeatOptionVM>();
                    }
                }
                return View(model);
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            var booking = await _bookingService.CreateBookingAsync(model, userId);
            TempData["BookingSuccess"] = "Your booking is confirmed!";
            return RedirectToAction(nameof(Details), new { id = booking.BookingId });
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            var booking = await _bookingService.GetBookingDetailsAsync(id, userId);
            if (booking == null) return NotFound();
            return View(booking);
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
