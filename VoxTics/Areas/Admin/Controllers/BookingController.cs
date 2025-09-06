using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IMapper _mapper;

        public BookingController(IBookingRepository bookingRepo, IMapper mapper)
        {
            _bookingRepo = bookingRepo;
            _mapper = mapper;
        }

        // GET: Admin/Booking
        public async Task<IActionResult> Index()
        {
            // use repo method that returns admin list with includes
            var bookings = await _bookingRepo.GetBookingsForAdminAsync();
            var vmList = bookings.Select(b => _mapper.Map<BookingViewModel>(b)).ToList();
            return View(vmList);
        }

        // GET: Admin/Booking/Create
        public IActionResult Create()
        {
            var vm = new BookingViewModel
            {
                BookingDate = DateTime.UtcNow
            };
            return PartialView("_BookingForm", vm);
        }

        // POST: Admin/Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingViewModel vm)
        {
            if (!ModelState.IsValid)
                return PartialView("_BookingForm", vm);

            // map vm to entity
            var entity = _mapper.Map<Booking>(vm);

            // generate unique booking number if repository supports it
            if (string.IsNullOrWhiteSpace(entity.BookingNumber) && _bookingRepo != null)
            {
                try
                {
                    entity.BookingNumber = await _bookingRepo.GenerateBookingNumberAsync();
                }
                catch
                {
                    // fallback to GUID-style number
                    entity.BookingNumber = $"BK-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
                }
            }

            entity.CreatedAt = DateTime.UtcNow;
            if (vm.BookingDate == default) entity.BookingDate = DateTime.UtcNow;

            // save
            var added = await _bookingRepo.AddAsync(entity);

            TempData["Success"] = "Booking created successfully.";
            return Json(new { success = true });
        }

        // GET: Admin/Booking/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            // use repo method that returns booking with related details
            var entity = await _bookingRepo.GetBookingWithDetailsAsync(id);
            if (entity == null) return NotFound();

            var vm = _mapper.Map<BookingViewModel>(entity);
            return PartialView("_BookingForm", vm);
        }

        // POST: Admin/Booking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookingViewModel vm)
        {
            if (!ModelState.IsValid) return PartialView("_BookingForm", vm);

            var entity = await _bookingRepo.GetBookingWithDetailsAsync(id);
            if (entity == null) return NotFound();

            // map updated fields from vm into the existing entity
            _mapper.Map(vm, entity);

            // persist
            await _bookingRepo.UpdateAsync(entity);

            TempData["Success"] = "Booking updated successfully.";
            return Json(new { success = true });
        }

        // POST: Admin/Booking/Delete/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _bookingRepo.DeleteAsync(id);

            if (!deleted)
            {
                TempData["Error"] = "Booking could not be deleted.";
                return Json(new { success = false });
            }

            TempData["Success"] = "Booking deleted.";
            return Json(new { success = true });
        }

    }
}
