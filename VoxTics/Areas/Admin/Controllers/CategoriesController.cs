using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IAdminCategoryService _categoryService;

        public CategoriesController(IAdminCategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new System.ArgumentNullException(nameof(categoryService));
        }

        // GET: Admin/Categories
        public async Task<IActionResult> Index(
            int pageIndex = 0,
            int pageSize = 10,
            string? search = null,
            CancellationToken cancellationToken = default)
        {
            var (categories, totalCount) = await _categoryService
                .GetPagedCategoriesAsync(pageIndex, pageSize, search, cancellationToken)
                .ConfigureAwait(false);

            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = totalCount;
            ViewBag.Search = search;

            return View(categories);
        }

        // GET: Admin/Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return View(category);

            if (await _categoryService.CategoryNameExistsAsync(category.Name, null, cancellationToken))
            {
                ModelState.AddModelError(nameof(category.Name), "Category name already exists.");
                return View(category);
            }

            await _categoryService.AddCategoryAsync(category, cancellationToken).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetByIdAsync(id, cancellationToken)
                .ConfigureAwait(false);

            if (category == null) return NotFound();
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category, CancellationToken cancellationToken)
        {
            if (id != category.Id) return BadRequest();

            if (!ModelState.IsValid) return View(category);

            if (await _categoryService.CategoryNameExistsAsync(category.Name, category.Id, cancellationToken))
            {
                ModelState.AddModelError(nameof(category.Name), "Category name already exists.");
                return View(category);
            }

            await _categoryService.UpdateCategoryAsync(category, cancellationToken).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _categoryService.DeleteCategoryAsync(id, cancellationToken).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Categories/Stats
        public async Task<IActionResult> Stats(CancellationToken cancellationToken)
        {
            var stats = await _categoryService.GetCategoryStatsAsync(cancellationToken).ConfigureAwait(false);
            return Json(new { stats.Total, stats.Active });
        }
    }
}
