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

        public async Task<IActionResult> Index() =>
            View(await _showtimeService.GetAllAsync());

        public async Task<IActionResult> Details(int id)
        {
            var showtime = await _showtimeService.GetByIdAsync(id);
            if (showtime == null) return NotFound();
            return View(showtime);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Showtime showtime)
        {
            if (!ModelState.IsValid) return View(showtime);
            await _showtimeService.CreateAsync(showtime);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var showtime = await _showtimeService.GetByIdAsync(id);
            if (showtime == null) return NotFound();
            return View(showtime);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Showtime showtime)
        {
            if (!ModelState.IsValid) return View(showtime);
            await _showtimeService.UpdateAsync(showtime);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var showtime = await _showtimeService.GetByIdAsync(id);
            if (showtime == null) return NotFound();
            return View(showtime);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _showtimeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
