using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Services;

namespace VoxTics.Controllers
{
    
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetActiveCategoriesAsync(cancellationToken);
            return View(categories);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Browse(int page = 1, int pageSize = 10, string? search = null, string? sort = null, CancellationToken cancellationToken = default)
        {
            var pagedCategories = await _categoryService.GetPagedCategoriesAsync(page, pageSize, search, sort, cancellationToken);
            return View(pagedCategories);
        }
    }
}
