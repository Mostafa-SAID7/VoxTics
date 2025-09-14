using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Services.Interfaces;
using AutoMapper;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingController : Controller
    {
        private readonly IBookingService _service;
        private readonly IMapper _mapper;

        public BookingController(IBookingService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: Admin/Booking
        public async Task<IActionResult> Index()
        {
            var bookings = await _service.GetAllAsync();
            var adminVMs = _mapper.Map<BookingViewModel[]>(bookings);
            return View(adminVMs);
        }

        // GET: Admin/Booking/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var booking = await _service.GetByIdAsync(id);
            if (booking == null) return NotFound();
            var vm = _mapper.Map<BookingViewModel>(booking);
            return View(vm);
        }

        // POST: Admin/Booking/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id, string? reason = "Cancelled by admin")
        {
            await _service.CancelAsync(id, reason ?? "Cancelled by admin");
            TempData["Success"] = "Booking cancelled successfully!";
            return RedirectToAction(nameof(Index));
        }

        // POST: Admin/Booking/UpdateStatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            if (!Enum.TryParse<Models.Enums.BookingStatus>(status, out var newStatus))
            {
                TempData["Error"] = "Invalid status!";
                return RedirectToAction(nameof(Index));
            }

            await _service.UpdateStatusAsync(id, newStatus);
            TempData["Success"] = "Booking status updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Booking/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var booking = await _service.GetByIdAsync(id);
            if (booking == null) return NotFound();
            var vm = _mapper.Map<BookingViewModel>(booking);
            return View(vm);
        }

        // POST: Admin/Booking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookingViewModel vm)
        {
            if (vm == null)
                throw new ArgumentNullException(nameof(vm));

            if (id != vm.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(vm);

            var booking = _mapper.Map<Booking>(vm);
            await _service.UpdateAsync(booking).ConfigureAwait(false);
            TempData["Success"] = "Booking updated successfully!";
            return RedirectToAction(nameof(Index));
        }

    }
}
