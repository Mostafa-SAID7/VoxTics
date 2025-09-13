using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Admin/Categories
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync().ConfigureAwait(false);
            return View(categories);
        }

        // GET: Admin/Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryService.GetWithMoviesAsync(id).ConfigureAwait(false);
            if (category == null) return NotFound();
            return View(category);
        }

        // GET: Admin/Categories/Create
        public IActionResult Create() => View();

        // POST: Admin/Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid) return View(category);
            await _categoryService.CreateAsync(category).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetByIdAsync(id).ConfigureAwait(false);
            if (category == null) return NotFound();
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (!ModelState.IsValid) return View(category);
            await _categoryService.UpdateAsync(category).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id).ConfigureAwait(false);
            if (category == null) return NotFound();
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.DeleteAsync(id).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }
    }
}
