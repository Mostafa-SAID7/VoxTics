using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Helpers;
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

            var projected = query.OrderBy(s => s.StartTime).ProjectTo<ShowtimeVM>(_mapper.ConfigurationProvider);

            var paged = await PaginatedList<ShowtimeVM>.CreateAsync(projected, pageIndex, pageSize);

            paged.RouteValues = new Dictionary<string, object>
            {
                ["search"] = search ?? string.Empty
            };

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_ShowtimeCards", paged);

            return View(paged);
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
