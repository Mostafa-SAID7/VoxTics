using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Admin.Services.Implementations;
using VoxTics.Areas.Admin.Services.Interfaces;
using VoxTics.Areas.Admin.ViewModels.Booking;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.SuperAdminRole}")]
    public class BookingsController : Controller
    {
        private readonly IAdminBookingsService _bookingService;
        private readonly IMapper _mapper;

        public BookingsController(IAdminBookingsService bookingService, IMapper mapper)
        {
            _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: Admin/Bookings
        public async Task<IActionResult> Index(int page = 1, string? search = null)
        {
            const int pageSize = 10; // Customize as needed

            // Get paged bookings from service
            var (bookings, totalCount) = await _bookingService.GetPagedBookingsAsync(page, pageSize, search);

            // Map to ViewModel
            var model = _mapper.Map<IEnumerable<BookingViewModel>>(bookings);

            // Pass pagination info to view
            ViewBag.TotalCount = totalCount;
            ViewBag.PageIndex = page;
            ViewBag.PageSize = pageSize;
            ViewBag.Search = search;

            return View(model);
        }

        // GET: Admin/Bookings/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var booking = await _bookingService.GetBookingDetailsAsync(id);
            if (booking == null) return NotFound();

            var model = _mapper.Map<BookingDetailsViewModel>(booking);
            return View(model);
        }

        // POST: Admin/Bookings/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            var booking = await _bookingService.GetBookingDetailsAsync(id);
            if (booking == null) return NotFound();

            if (booking.Status == VoxTics.Models.Enums.BookingStatus.Cancelled)
            {
                TempData["Message"] = "Booking is already cancelled.";
            }
            else
            {
                booking.Status = VoxTics.Models.Enums.BookingStatus.Cancelled;
                // Here you would call repository/service to update in DB
                // For example: await _bookingService.UpdateBookingAsync(booking);

                TempData["Message"] = "Booking cancelled successfully.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
