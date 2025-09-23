using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Category;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.SuperAdminRole}")]

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

            categories ??= new List<Category>();

            var tableViewModels = categories.Select(c => new CategoryTableViewModel
            {
                Id = c.Id,
                Name = c.Name ?? "",
                Slug = c.Slug ?? "",
                IsActive = c.IsActive,
            }).ToList();

            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = totalCount;
            ViewBag.Search = search;

            return View(tableViewModels);
        }


        // GET: Admin/Categories/Create
        public IActionResult Create()
        {
            // Pass a new ViewModel instance to the view
            var model = new CategoryCreateEditViewModel();
            return View(model);
        }

        // POST: Admin/Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateEditViewModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return View(model);

            // Check if category name exists
            if (await _categoryService.CategoryNameExistsAsync(model.Name, null, cancellationToken))
            {
                ModelState.AddModelError(nameof(model.Name), "Category name already exists.");
                return View(model);
            }

            // Map ViewModel → Entity
            var category = new Category
            {
                Name = model.Name,
                Slug = model.Slug,
                Description = model.Description,
                IsActive = model.IsActive
            };

            await _categoryService.AddCategoryAsync(category, cancellationToken).ConfigureAwait(false);

            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetByIdAsync(id, cancellationToken)
                .ConfigureAwait(false);

            if (category == null) return NotFound();

            // Map Entity → ViewModel
            var model = new CategoryCreateEditViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Description = category.Description,
                IsActive = category.IsActive
            };

            return View(model);
        }

        // POST: Admin/Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryCreateEditViewModel model, CancellationToken cancellationToken)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid) return View(model);

            // Check if another category with the same name exists
            if (await _categoryService.CategoryNameExistsAsync(model.Name, model.Id, cancellationToken))
            {
                ModelState.AddModelError(nameof(model.Name), "Category name already exists.");
                return View(model);
            }

            // Map ViewModel → Entity
            var category = new Category
            {
                Id = model.Id,
                Name = model.Name,
                Slug = model.Slug,
                Description = model.Description,
                IsActive = model.IsActive
            };

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
