using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Admin.Services.Interfaces;
using VoxTics.Areas.Admin.ViewModels.Category;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.SuperAdminRole)]
    [Route("admin/categories")]
    public class CategoriesController : Controller
    {
        private readonly IAdminCategoriesService _categoriesService;

        public CategoriesController(IAdminCategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        // GET: admin/categories
        [HttpGet("")]
        public async Task<IActionResult> Index(
            int page = 1,
            int pageSize = 10,
            string search = null,
            string sortColumn = null,
            bool sortDescending = false)
        {
            var categories = await _categoriesService.GetPagedAsync(page, pageSize, search, sortColumn, sortDescending);
            ViewBag.Search = search;
            ViewBag.SortColumn = sortColumn;
            ViewBag.SortDescending = sortDescending;
            return View(categories);
        }

        // GET: admin/categories/details/5
        [HttpGet("details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoriesService.GetDetailsByIdAsync(id);
            if (category == null) return NotFound();
            return View(category);
        }

        // GET: admin/categories/create
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(new CategoryCreateEditViewModel());
        }

        // POST: admin/categories/create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (await _categoriesService.SlugExistsAsync(model.Slug))
            {
                ModelState.AddModelError(nameof(model.Slug), "Slug already exists.");
                return View(model);
            }

            await _categoriesService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: admin/categories/edit/5
        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoriesService.GetDetailsByIdAsync(id);
            if (category == null) return NotFound();

            var model = new CategoryCreateEditViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Description = category.Description,
                IsActive = category.IsActive,
                MovieCount = category.MovieCount
            };
            return View(model);
        }

        // POST: admin/categories/edit/5
        [HttpPost("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryCreateEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (await _categoriesService.SlugExistsAsync(model.Slug, model.Id))
            {
                ModelState.AddModelError(nameof(model.Slug), "Slug already exists.");
                return View(model);
            }

            await _categoriesService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoriesService.DeleteAsync(id);
                TempData["SuccessMessage"] = "Category deleted successfully.";
            }
            catch (DbUpdateException ex)
            {
                // Check if the inner exception mentions a foreign key conflict
                if (ex.InnerException?.Message.Contains("REFERENCE constraint") == true)
                {
                    TempData["ErrorMessage"] =
                        "This category cannot be deleted because there are records linked to it. " +
                        "Please remove or reassign related items first.";
                }
                else
                {
                    TempData["ErrorMessage"] = "An error occurred while deleting the category.";
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred.";
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
