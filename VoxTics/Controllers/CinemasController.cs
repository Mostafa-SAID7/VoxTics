using System.Diagnostics;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Helpers;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaRepository _cinemaRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<CinemasController> _logger;

        public CinemasController(ICinemaRepository cinemaRepo, IMapper mapper, ILogger<CinemasController> logger)
        {
            _cinemaRepo = cinemaRepo;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: /Cinemas
        public async Task<IActionResult> Index(string? search, string? location, int pageIndex = 1, int pageSize = 12)
        {
            try
            {
                var query = _cinemaRepo.Query(); // includeProperties if needed

                if (!string.IsNullOrWhiteSpace(search))
                    query = query.Where(c => c.Name.Contains(search));

                if (!string.IsNullOrWhiteSpace(location))
                    query = query.Where(c => c.Address.Contains(location));

                var projected = query
                    .OrderBy(c => c.Name)
                    .ProjectTo<CinemaVM>(_mapper.ConfigurationProvider);

                var paged = await PaginatedList<CinemaVM>.CreateAsync(projected, pageIndex, pageSize);

                paged.RouteValues = new Dictionary<string, object>
                {
                    ["search"] = search ?? string.Empty,
                    ["location"] = location ?? string.Empty
                };

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return PartialView("_CinemaCards", paged);

                return View(paged);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cinemas.Index error");
                return StatusCode(500);
            }
        }

        // GET: /Cinemas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var entity = await _cinemaRepo.GetByIdAsync(id, includeProperties: "Halls,Showtimes");
                if (entity == null) return NotFound();

                var vm = _mapper.Map<CinemaVM>(entity);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return PartialView("_DetailsPartial", vm);

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cinemas.Details error (id={CinemaId})", id);
                return StatusCode(500);
            }
        }
    }
}
