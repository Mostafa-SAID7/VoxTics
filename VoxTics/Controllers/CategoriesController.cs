using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Repositories.Interfaces;
using VoxTics.Models.ViewModels;

namespace VoxTics.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMovieRepository _movieRepo;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepo,
                                    IMovieRepository movieRepo,
                                    IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _movieRepo = movieRepo;
            _mapper = mapper;
        }

        // GET: /Categories
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return View(categories);
        }

        // GET: /Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryRepo.GetByIdWithMoviesAsync(id);
            if (category == null) return NotFound();

            var vm = new CategoryMoviesVM
            {
                Id = category.Id,
                Name = category.Name,
                Movies = category.MovieCategories
                    .Select(mc => new MovieVM
                    {
                        Id = mc.Movie.Id,
                        Title = mc.Movie.Title,
                        ImageUrl = mc.Movie.Images.FirstOrDefault()?.ImageUrl,
                        Duration = mc.Movie.Duration,
                        Categories = mc.Movie.MovieCategories
                            .Select(inner => new CategoryItemVM
                            {
                                Id = inner.CategoryId,
                                Name = inner.Category.Name
                            }).ToList()
                    }).ToList()
            };

            return View(vm);
        }

    }
}
