using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels; // BookingViewModel (for admin usages) - optional
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces; // BookingVM

namespace VoxTics.Controllers
{
    [Authorize]

    public class BookingController : Controller
    {
        private readonly IBookingService _service;
        public BookingController(IBookingService service) => _service = service;

        public async Task<IActionResult> MyBookings()
        {
            var allBookings = await _service.GetAllAsync();
            var myBookings = allBookings.Where(b => b.User.UserName == User.Identity!.Name);
            return View(myBookings);
        }

        [HttpGet]
        public IActionResult Create(int showtimeId) =>
            View(new Booking { ShowtimeId = showtimeId });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (!ModelState.IsValid) return View(booking);
            booking.BookingDate = DateTime.UtcNow;
            await _service.CreateAsync(booking);
            return RedirectToAction("MyBookings");
        }
    }

}
