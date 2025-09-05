using AutoMapper;
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

        public CinemasController(ICinemaRepository cinemaRepo, IMapper mapper)
        {
            _cinemaRepo = cinemaRepo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string? search, int pageIndex = 1, int pageSize = 12)
        {
            // Use Query() instead of GetAllQueryable()
            var query = _cinemaRepo.Query();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(c => c.Name.Contains(search));

            // 1. Paginate entities
            var pagedEntities = await PaginatedList<VoxTics.Models.Entities.Cinema>.CreateAsync(query, pageIndex, pageSize);

            // 2. Map to view models
            var mapped = pagedEntities.Select(c => _mapper.Map<CinemaVM>(c));

            // 3. Build PaginatedList<VM> with static Create
            var pagedVM = PaginatedList<CinemaVM>.Create(mapped, pageIndex, pageSize);

            // Handle AJAX request
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_CinemaCards", pagedVM);

            return View(pagedVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _cinemaRepo.GetByIdAsync(id);
            if (cinema == null) return NotFound();

            var vm = _mapper.Map<CinemaVM>(cinema);
            return View(vm);
        }
    }
}
