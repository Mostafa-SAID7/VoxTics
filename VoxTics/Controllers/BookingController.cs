using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Models.ViewModels.Booking;
using VoxTics.Services.IServices;
using System.Threading;
using System.Threading.Tasks;

namespace VoxTics.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(string bookingReference, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(bookingReference))
                return BadRequest();

            var booking = await _bookingService.GetBookingDetailsAsync(bookingReference, cancellationToken);
            if (booking == null) return NotFound();

            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingCreateVM model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return View(model);

            var userId = User.FindFirst("sub")?.Value ?? User.Identity?.Name ?? string.Empty;

            var booking = await _bookingService.CreateBookingAsync(
                model,
                userId,
                model.CouponCode,
                cancellationToken);

            return RedirectToAction(nameof(Details), new { bookingReference = booking.BookingReference });
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(string bookingReference, string reason, CancellationToken cancellationToken)
        {
            var success = await _bookingService.CancelBookingAsync(bookingReference, reason, true, cancellationToken);
            if (!success) return NotFound();

            TempData["Message"] = "Booking cancelled successfully.";
            return RedirectToAction(nameof(UserBookings));
        }

        [HttpGet]
        public async Task<IActionResult> UserBookings(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var userId = User.FindFirst("sub")?.Value ?? User.Identity?.Name ?? string.Empty;
            var bookings = await _bookingService.GetUserBookingsAsync(userId, page, pageSize, cancellationToken);
            return View(bookings);
        }
    }
}
