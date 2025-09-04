using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public MoviesController(IMovieRepository movieRepo,
                                ICategoryRepository categoryRepo,
                                IMapper mapper,
                                IWebHostEnvironment env)
        {
            _movieRepo = movieRepo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieRepo.GetAllWithIncludesAsync();
            var vm = movies.Select(m => _mapper.Map<MovieViewModel>(m)).ToList();
            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            var vm = new MovieViewModel
            {
                AvailableCategories = (await _categoryRepo.GetAllAsync())
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList()
            };
            return PartialView("_Create", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.AvailableCategories = (await _categoryRepo.GetAllAsync())
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList();

                return PartialView("_Create", vm);
            }

            var movie = _mapper.Map<Movie>(vm);

            // handle uploading poster (if present)
            if (vm.ImageFile != null && vm.ImageFile.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(vm.ImageFile.FileName)}";
                var dest = Path.Combine(_env.WebRootPath, "uploads", "movies");
                if (!Directory.Exists(dest)) Directory.CreateDirectory(dest);
                var fullPath = Path.Combine(dest, fileName);
                using var stream = new FileStream(fullPath, FileMode.Create);
                await vm.ImageFile.CopyToAsync(stream);

                movie.Images.Add(new MovieImg { ImageUrl = $"/uploads/movies/{fileName}", IsPrimary = true });
            }

            // categories: create links
            foreach (var catId in vm.SelectedCategoryIds.Distinct())
            {
                movie.MovieCategories.Add(new MovieCategory { CategoryId = catId });
            }

            await _movieRepo.AddAsync(movie);
            return Json(new { success = true, id = movie.Id });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieRepo.GetByIdWithIncludesAsync(id);
            if (movie == null) return NotFound();

            var vm = _mapper.Map<MovieViewModel>(movie);
            vm.AvailableCategories = (await _categoryRepo.GetAllAsync())
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                    Selected = vm.SelectedCategoryIds.Contains(c.Id)
                }).ToList();

            return PartialView("_Edit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.AvailableCategories = (await _categoryRepo.GetAllAsync())
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList();
                return PartialView("_Edit", vm);
            }

            var movie = await _movieRepo.GetByIdWithIncludesAsync(vm.Id);
            if (movie == null) return NotFound();

            _mapper.Map(vm, movie);

            // update poster if new provided
            if (vm.ImageFile != null && vm.ImageFile.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(vm.ImageFile.FileName)}";
                var dest = Path.Combine(_env.WebRootPath, "uploads", "movies");
                if (!Directory.Exists(dest)) Directory.CreateDirectory(dest);
                var fullPath = Path.Combine(dest, fileName);
                using var stream = new FileStream(fullPath, FileMode.Create);
                await vm.ImageFile.CopyToAsync(stream);
                movie.Images.Add(new MovieImg { ImageUrl = $"/uploads/movies/{fileName}", IsPrimary = true });
            }

            // update categories
            movie.MovieCategories.Clear();
            foreach (var catId in vm.SelectedCategoryIds.Distinct())
            {
                movie.MovieCategories.Add(new MovieCategory { CategoryId = catId });
            }

            await _movieRepo.UpdateAsync(movie);
            return Json(new { success = true });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieRepo.GetByIdWithIncludesAsync(id);
            if (movie == null) return NotFound();
            var vm = _mapper.Map<MovieViewModel>(movie);
            return PartialView("_Delete", vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieRepo.DeleteAsync(id);
            return Json(new { success = true });
        }
    }
}
