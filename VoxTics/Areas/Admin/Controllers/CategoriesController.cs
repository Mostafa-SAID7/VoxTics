using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string? search)
        {
            var cats = await _categoryRepo.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(search))
                cats = cats.Where(c => c.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            var vm = cats.Select(c => _mapper.Map<CategoryViewModel>(c)).ToList();
            return View(vm);
        }

        public IActionResult Create() => PartialView("_CategoryForm", new CategoryViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel vm)
        {
            if (!ModelState.IsValid) return PartialView("_CategoryForm", vm);

            var category = _mapper.Map<Category>(vm);
            await _categoryRepo.AddAsync(category);

            return Json(new { success = true, message = "Category created successfully!" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null) return NotFound();

            var vm = _mapper.Map<CategoryViewModel>(category);
            return PartialView("_CategoryForm", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryViewModel vm)
        {
            if (!ModelState.IsValid) return PartialView("_CategoryForm", vm);

            var cat = await _categoryRepo.GetByIdAsync(vm.Id);
            if (cat == null) return NotFound();

            _mapper.Map(vm, cat);
            await _categoryRepo.UpdateAsync(cat);

            return Json(new { success = true, message = "Category updated successfully!" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null) return NotFound();

            var vm = _mapper.Map<CategoryViewModel>(category);
            return PartialView("_Delete", vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryRepo.DeleteAsync(id);
            return Json(new { success = true, message = "Category deleted successfully!" });
        }
    }
}
