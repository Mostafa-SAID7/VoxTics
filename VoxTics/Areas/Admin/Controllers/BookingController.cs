using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            var bookings = await _bookingRepo.GetAllAsync("Showtime.Movie,Showtime.Cinema,User");
            var vm = bookings.Select(b => _mapper.Map<BookingViewModel>(b));
            return View(vm);
        }

        public IActionResult Create()
        {
            return PartialView("_BookingForm", new BookingViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingViewModel vm)
        {
            if (!ModelState.IsValid) return PartialView("_BookingForm", vm);

            var entity = _mapper.Map<Booking>(vm);
            await _bookingRepo.AddAsync(entity);

            TempData["Success"] = "Booking created successfully.";
            return Json(new { success = true });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _bookingRepo.GetByIdAsync(id, "Showtime,User");
            if (entity == null) return NotFound();

            var vm = _mapper.Map<BookingViewModel>(entity);
            return PartialView("_BookingForm", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookingViewModel vm)
        {
            if (!ModelState.IsValid) return PartialView("_BookingForm", vm);

            var entity = await _bookingRepo.GetByIdAsync(id);
            if (entity == null) return NotFound();

            _mapper.Map(vm, entity);
            await _bookingRepo.UpdateAsync(entity);

            TempData["Success"] = "Booking updated successfully.";
            return Json(new { success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookingRepo.DeleteAsync(id);
            TempData["Success"] = "Booking deleted.";
            return Json(new { success = true });
        }
    }
}
