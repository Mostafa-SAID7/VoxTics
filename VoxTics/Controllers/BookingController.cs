using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Helpers;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IMapper _mapper;

        public BookingController(IBookingRepository bookingRepo, IMapper mapper)
        {
            _bookingRepo = bookingRepo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int userId, int pageIndex = 1, int pageSize = 10)
        {
            var query = _bookingRepo.Query("Showtime.Movie,Showtime.Cinema")
                .Where(b => b.UserId == userId);

            var pagedEntities = await PaginatedList<VoxTics.Models.Entities.Booking>.CreateAsync(query, pageIndex, pageSize);

            var mapped = pagedEntities.Select(b => _mapper.Map<BookingVM>(b));
            var pagedVM = PaginatedList<BookingVM>.Create(mapped, pageIndex, pageSize);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_BookingCards", pagedVM);

            return View(pagedVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var booking = await _bookingRepo.GetByIdAsync(id, "Showtime.Movie,Showtime.Cinema");
            if (booking == null) return NotFound();

            var vm = _mapper.Map<BookingVM>(booking);
            return View(vm);
        }
    }
}
