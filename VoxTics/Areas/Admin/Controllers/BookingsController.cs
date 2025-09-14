using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingsController : Controller
    {
        private readonly IBookingService _service;
        public BookingsController(IBookingService service) => _service = service;

        public async Task<IActionResult> Index()
        {
            var bookings = await _service.GetAllAsync().ConfigureAwait(false);
            return View(bookings);
        }
        public async Task<IActionResult> Details(int id)
        {
            var booking = await _service.GetByIdAsync(id).ConfigureAwait(false);
            if (booking == null) return NotFound();
            return View(booking);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var booking = await _service.GetByIdAsync(id).ConfigureAwait(false);
            if (booking == null) return NotFound();
            return View(booking);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Booking booking)
        {
            if (!ModelState.IsValid) return View(booking);
            await _service.UpdateAsync(booking).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, BookingStatus status)
        {
            await _service.UpdateStatusAsync(id, status).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int id, string reason)
        {
            await _service.CancelAsync(id, reason).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }
    }

}
