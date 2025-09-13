using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CinemasController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemasController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        // GET: Admin/Cinemas
        public async Task<IActionResult> Index()
        {
            var cinemas = await _cinemaService.GetAllAsync().ConfigureAwait(false);
            return View(cinemas);
        }

        // GET: Admin/Cinemas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id).ConfigureAwait(false);
            if (cinema == null) return NotFound();
            return View(cinema);
        }

        // GET: Admin/Cinemas/Create
        public IActionResult Create() => View();

        // POST: Admin/Cinemas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);

            await _cinemaService.CreateAsync(cinema).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Cinemas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id).ConfigureAwait(false);
            if (cinema == null) return NotFound();
            return View(cinema);
        }

        // POST: Admin/Cinemas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);

            await _cinemaService.UpdateAsync(cinema).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Cinemas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id).ConfigureAwait(false);
            if (cinema == null) return NotFound();
            return View(cinema);
        }

        // POST: Admin/Cinemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _cinemaService.DeleteAsync(id).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }
    }
}
