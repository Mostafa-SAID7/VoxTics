using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Models.Entities;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: /Admin/Movies
        public async Task<IActionResult> Index() =>
            View(await _movieService.GetAllAsync().ConfigureAwait(false));

        // GET: /Admin/Movies/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetByIdAsync(id).ConfigureAwait(false);
            if (movie == null) return NotFound();
            return View(movie);
        }

        // GET: /Admin/Movies/Create
        public IActionResult Create() => View();

        // POST: /Admin/Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (!ModelState.IsValid) return View(movie);
            await _movieService.CreateAsync(movie).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/Movies/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieService.GetByIdAsync(id).ConfigureAwait(false);
            if (movie == null) return NotFound();
            return View(movie);
        }

        // POST: /Admin/Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Movie movie)
        {
            if (!ModelState.IsValid) return View(movie);
            await _movieService.UpdateAsync(movie).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/Movies/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieService.GetByIdAsync(id).ConfigureAwait(false);
            if (movie == null) return NotFound();
            return View(movie);
        }

        // POST: /Admin/Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieService.DeleteAsync(id).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }
    }
}
