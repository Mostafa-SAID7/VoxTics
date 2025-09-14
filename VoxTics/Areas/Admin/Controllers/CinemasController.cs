using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CinemaController : Controller
    {
        private readonly ICinemaService _service;

        public CinemaController(ICinemaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var cinemas = await _service.GetAllAsync();
            return View(cinemas);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CinemaViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            await _service.CreateAsync(vm);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _service.GetByIdAsync(id);
            if (cinema == null) return NotFound();
            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CinemaViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            await _service.UpdateAsync(vm);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
