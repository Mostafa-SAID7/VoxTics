using AutoMapper;
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
        private readonly IBookingService _bookingService;
        private readonly UserManager<IdentityUser> _userManager;

        public BookingsController(IBookingService bookingService, UserManager<IdentityUser> userManager)
        {
            _bookingService = bookingService;
            _userManager = userManager;
        }

        // GET: Admin/Bookings
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var bookings = await _bookingService.GetBookingsByUserAsync(userId!).ConfigureAwait(false);
            return View(bookings);
        }

        // GET: Admin/Bookings/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id).ConfigureAwait(false);
            if (booking == null) return NotFound();
            return View(booking);
        }

        // GET: Admin/Bookings/Create
        public IActionResult Create() => View();

        // POST: Admin/Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (!ModelState.IsValid) return View(booking);

            var userId = _userManager.GetUserId(User);
            await _bookingService.CreateBookingAsync(booking, userId!).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Bookings/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id).ConfigureAwait(false);
            if (booking == null) return NotFound();
            return View(booking);
        }

        // POST: Admin/Bookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Booking booking)
        {
            if (!ModelState.IsValid) return View(booking);

            var userId = _userManager.GetUserId(User);
            await _bookingService.UpdateBookingAsync(booking, userId!).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Bookings/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id).ConfigureAwait(false);
            if (booking == null) return NotFound();
            return View(booking);
        }

        // POST: Admin/Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = _userManager.GetUserId(User);
            await _bookingService.DeleteBookingAsync(id, userId!).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }
    }
}
