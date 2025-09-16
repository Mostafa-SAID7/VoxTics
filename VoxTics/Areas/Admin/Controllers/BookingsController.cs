using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Services.Interfaces;
using VoxTics.Models.Entities;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class BookingsController : Controller
    {
        private readonly IAdminBookingService _bookingService;

        public BookingsController(IAdminBookingService bookingService)
        {
            _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
        }

        // GET: Admin/Bookings/Index?pageIndex=0&pageSize=10&search=
        public async Task<IActionResult> Index(int pageIndex = 0, int pageSize = 10, string? search = null, CancellationToken cancellationToken = default)
        {
            var (bookings, totalCount) = await _bookingService
                .GetPagedBookingsAsync(pageIndex, pageSize, search, cancellationToken)
                .ConfigureAwait(false);

            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = totalCount;
            ViewBag.Search = search;

            return View(bookings);
        }

        // GET: Admin/Bookings/Stats
        public async Task<IActionResult> Stats(CancellationToken cancellationToken = default)
        {
            var (total, today, revenue) = await _bookingService
                .GetBookingStatsAsync(cancellationToken)
                .ConfigureAwait(false);

            return Json(new
            {
                TotalBookings = total,
                TodayBookings = today,
                TotalRevenue = revenue
            });
        }

        // POST: Admin/Bookings/ForceCancel/5
        [HttpPost]
        public async Task<IActionResult> ForceCancel(int bookingId, CancellationToken cancellationToken = default)
        {
            if (bookingId <= 0) return BadRequest("Invalid booking ID.");

            var result = await _bookingService
                .ForceCancelBookingAsync(bookingId, cancellationToken)
                .ConfigureAwait(false);

            if (!result) return NotFound($"Booking with ID {bookingId} not found.");

            return Ok(new { Message = "Booking successfully cancelled." });
        }
    }
}
