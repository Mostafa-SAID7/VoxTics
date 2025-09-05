using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShowtimesController : Controller
    {
        private readonly IShowtimeRepository _showtimeRepo;
        private readonly IMapper _mapper;

        public ShowtimesController(IShowtimeRepository showtimeRepo, IMapper mapper)
        {
            _showtimeRepo = showtimeRepo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var showtimes = await _showtimeRepo.GetAllAsync("Movie,Cinema");
            return View(showtimes);
        }

        public IActionResult Create()
        {
            var vm = new ShowtimeViewModel();
            return PartialView("_ShowtimeForm", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShowtimeViewModel vm)
        {
            if (!ModelState.IsValid)
                return PartialView("_ShowtimeForm", vm);

            var entity = _mapper.Map<Showtime>(vm);
            await _showtimeRepo.AddAsync(entity);

            TempData["Success"] = "Showtime created successfully.";
            return Json(new { success = true });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _showtimeRepo.GetByIdAsync(id, "Movie,Cinema");
            if (entity == null) return NotFound();

            var vm = _mapper.Map<ShowtimeViewModel>(entity);
            return PartialView("_ShowtimeForm", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ShowtimeViewModel vm)
        {
            if (!ModelState.IsValid)
                return PartialView("_ShowtimeForm", vm);

            var entity = await _showtimeRepo.GetByIdAsync(id);
            if (entity == null) return NotFound();

            _mapper.Map(vm, entity);
            await _showtimeRepo.UpdateAsync(entity);

            TempData["Success"] = "Showtime updated successfully.";
            return Json(new { success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _showtimeRepo.DeleteAsync(id);

            TempData["Success"] = "Showtime deleted.";
            return Json(new { success = true });
        }

        public async Task<IActionResult> Details(int id)
        {
            var entity = await _showtimeRepo.GetByIdAsync(id, "Movie,Cinema");
            if (entity == null) return NotFound();

            return PartialView("_DetailsPartial", entity);
        }
    }
}
