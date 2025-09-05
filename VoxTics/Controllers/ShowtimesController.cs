using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Controllers
{
    public class ShowtimesController : Controller
    {
        private readonly IShowtimeRepository _showtimeRepo;
        private readonly IMapper _mapper;

        public ShowtimesController(IShowtimeRepository showtimeRepo, IMapper mapper)
        {
            _showtimeRepo = showtimeRepo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string? search, int pageIndex = 1, int pageSize = 12)
        {
            var query = _showtimeRepo.Query(includeProperties: "Movie,Cinema");

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(s => s.Movie.Title.Contains(search) || s.Cinema.Name.Contains(search));

            var pagedEntities = await PaginatedList<VoxTics.Models.Entities.Showtime>.CreateAsync(query, pageIndex, pageSize);

            var mapped = pagedEntities.Select(s => _mapper.Map<ShowtimeVM>(s));
            var pagedVM = PaginatedList<ShowtimeVM>.Create(mapped, pageIndex, pageSize);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_ShowtimeCards", pagedVM);

            return View(pagedVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var showtime = await _showtimeRepo.GetByIdAsync(id, includeProperties: "Movie,Cinema");
            if (showtime == null) return NotFound();

            var vm = _mapper.Map<ShowtimeVM>(showtime);
            return View(vm);
        }
    }
}
