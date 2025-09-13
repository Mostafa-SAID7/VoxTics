using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums.Sorting;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShowtimesController : Controller
    {
        private readonly IShowtimeService _showtimeService;

        public ShowtimesController(IShowtimeService showtimeService)
        {
            _showtimeService = showtimeService;
        }

        // GET: /Admin/Showtimes
        public async Task<IActionResult> Index() =>
            View(await _showtimeService.GetAllAsync().ConfigureAwait(false));

        // GET: /Admin/Showtimes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var showtime = await _showtimeService.GetByIdAsync(id).ConfigureAwait(false);
            if (showtime == null) return NotFound();
            return View(showtime);
        }

        // GET: /Admin/Showtimes/Create
        public IActionResult Create() => View();

        // POST: /Admin/Showtimes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Showtime showtime)
        {
            if (!ModelState.IsValid) return View(showtime);
            await _showtimeService.CreateAsync(showtime).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/Showtimes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var showtime = await _showtimeService.GetByIdAsync(id).ConfigureAwait(false);
            if (showtime == null) return NotFound();
            return View(showtime);
        }

        // POST: /Admin/Showtimes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Showtime showtime)
        {
            if (!ModelState.IsValid) return View(showtime);
            await _showtimeService.UpdateAsync(showtime).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/Showtimes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var showtime = await _showtimeService.GetByIdAsync(id).ConfigureAwait(false);
            if (showtime == null) return NotFound();
            return View(showtime);
        }

        // POST: /Admin/Showtimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _showtimeService.DeleteAsync(id).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }
    }
}
