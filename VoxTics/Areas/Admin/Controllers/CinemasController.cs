using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Admin.Services.Interfaces;
using VoxTics.Areas.Admin.ViewModels.Cinema;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/cinemas")]
    [Authorize(Roles = "SuperAdmin")] // Adjust role if needed
    public class CinemasController : Controller
    {
        private readonly IAdminCinemasService _cinemaService;

        public CinemasController(IAdminCinemasService cinemaService)
        {
            _cinemaService = cinemaService ?? throw new ArgumentNullException(nameof(cinemaService));
        }

        // ---------- Index ----------
        [HttpGet("")]
        public async Task<IActionResult> Index(string? search, int page = 1, int pageSize = 10)
        {
            var pagedCinemas = await _cinemaService.GetPagedAsync(page, pageSize, search);
            ViewBag.Search = search;
            return View(pagedCinemas);
        }

        // ---------- Details ----------
        [HttpGet("details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _cinemaService.GetDetailsByIdAsync(id);
            if (cinema == null) return NotFound();
            return View(cinema);
        }

        // ---------- Create ----------
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(new CinemaCreateEditViewModel());
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CinemaCreateEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (await _cinemaService.SlugExistsAsync(model.Slug))
            {
                ModelState.AddModelError("Slug", "Slug already exists.");
                return View(model);
            }

            await _cinemaService.CreateAsync(model);
            TempData["Success"] = "Cinema created successfully.";
            return RedirectToAction(nameof(Index));
        }

        // ---------- Edit ----------
        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var details = await _cinemaService.GetDetailsByIdAsync(id);
            if (details == null) return NotFound();

            var model = new CinemaCreateEditViewModel
            {
                Id = details.Id,
                Name = details.Name,
                Description = details.Description,
                Email = details.Email,
                Phone = details.Phone,
                Address = details.Address,
                City = details.City,
                State = details.State,
                Country = details.Country,
                PostalCode = details.PostalCode,
                Website = details.Website,
                ImageUrl = details.ImageUrl,
                Slug = details.Slug,
                IsActive = details.IsActive
            };

            return View(model);
        }

        [HttpPost("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CinemaCreateEditViewModel model)
        {
            if (id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);

            if (await _cinemaService.SlugExistsAsync(model.Slug, id))
            {
                ModelState.AddModelError("Slug", "Slug already exists.");
                return View(model);
            }

            await _cinemaService.UpdateAsync(model);
            TempData["Success"] = "Cinema updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        // ---------- Delete ----------
        [HttpPost("delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _cinemaService.DeleteAsync(id);
            TempData["Success"] = "Cinema deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
