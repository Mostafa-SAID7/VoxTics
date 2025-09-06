using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingsController : Controller
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IUserRepository _userRepo;
        private readonly IShowtimeRepository _showtimeRepo;
        private readonly IMapper _mapper;

        public BookingsController(
            IBookingRepository bookingRepo,
            IUserRepository userRepo,
            IShowtimeRepository showtimeRepo,
            IMapper mapper)
        {
            _bookingRepo = bookingRepo;
            _userRepo = userRepo;
            _showtimeRepo = showtimeRepo;
            _mapper = mapper;
        }

        // GET: Admin/Bookings
        public async Task<IActionResult> Index(string? search, int pageNumber = 1, int pageSize = 10)
        {
            var filter = new BasePaginatedFilterVM
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchTerm = search,
                SortBy = "BookingDate",
                SortOrder = SortOrder.Desc
            };

            var (bookings, totalCount) = await _bookingRepo.GetPagedBookingsForAdminAsync(filter);
            var vmList = bookings.Select(b => _mapper.Map<BookingViewModel>(b)).ToList();

            var vm = new PaginatedList<BookingViewModel>(vmList, totalCount, pageNumber, pageSize);
            return View(vm);
        }

        // GET: Admin/Bookings/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var booking = await _bookingRepo.GetBookingWithDetailsAsync(id);
            if (booking == null) return NotFound();

            var vm = _mapper.Map<BookingViewModel>(booking);
            return View(vm);
        }

        // GET: Admin/Bookings/Create
        public async Task<IActionResult> Create()
        {
            var vm = new BookingViewModel
            {
                Users = (await _userRepo.GetAllAsync(null))
                    .Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.FullName })
                    .ToList(),
                Showtimes = (await _showtimeRepo.GetAllAsync(null))
                    .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = $"{s.Movie.Title} - {s.StartTime:g}" })
                    .ToList()
            };

            return View(vm);
        }

        // POST: Admin/Bookings/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns(vm);
                return View(vm);
            }

            var booking = _mapper.Map<Booking>(vm);
            booking.BookingNumber = await _bookingRepo.GenerateBookingNumberAsync();

            await _bookingRepo.AddAsync(booking);
            await _bookingRepo.SaveChangesAsync();

            TempData["Success"] = "Booking created successfully.";
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Bookings/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var booking = await _bookingRepo.GetByIdAsync(id);
            if (booking == null) return NotFound();

            var vm = _mapper.Map<BookingViewModel>(booking);
            await PopulateDropdowns(vm);
            return View(vm);
        }

        // POST: Admin/Bookings/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookingViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns(vm);
                return View(vm);
            }

            var booking = await _bookingRepo.GetByIdAsync(vm.Id);
            if (booking == null) return NotFound();

            _mapper.Map(vm, booking);
            await _bookingRepo.UpdateAsync(booking);
            await _bookingRepo.SaveChangesAsync();

            TempData["Success"] = "Booking updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Bookings/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _bookingRepo.GetBookingWithDetailsAsync(id);
            if (booking == null) return NotFound();

            var vm = _mapper.Map<BookingViewModel>(booking);
            return View(vm);
        }

        // POST: Admin/Bookings/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookingRepo.DeleteAsync(id);
            await _bookingRepo.SaveChangesAsync();

            TempData["Success"] = "Booking deleted successfully.";
            return RedirectToAction(nameof(Index));
        }

        // -------------------------
        // Helper
        // -------------------------
        private async Task PopulateDropdowns(BookingViewModel vm)
        {
            vm.Users = (await _userRepo.GetAllAsync(null))
                .Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.FullName })
                .ToList();

            vm.Showtimes = (await _showtimeRepo.GetAllAsync(null))
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = $"{s.Movie.Title} - {s.StartTime:g}" })
                .ToList();
        }
    }
}
