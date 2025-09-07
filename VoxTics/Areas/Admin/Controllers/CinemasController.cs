using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CinemasController : Controller
    {
        private readonly ICinemaRepository _cinemaRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CinemasController(ICinemaRepository cinemaRepo, IMapper mapper, IWebHostEnvironment env)
        {
            _cinemaRepo = cinemaRepo;
            _mapper = mapper;
            _env = env;
        }

        // GET: Admin/Cinemas
        public async Task<IActionResult> Index()
        {
            var cinemas = await _cinemaRepo.GetAllAsync();
            var vmList = _mapper.Map<List<CinemaViewModel>>(cinemas); // Map entities -> viewmodels
            return View(vmList); // now the types match
        }

        // GET: Admin/Cinemas/Create
        public IActionResult Create()
        {
            var vm = new CinemaViewModel();
            return PartialView("_CinemaForm", vm);
        }

        // POST: Admin/Cinemas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CinemaViewModel vm)
        {
            if (!ModelState.IsValid)
                return PartialView("_CinemaForm", vm);

            var entity = _mapper.Map<Cinema>(vm);

            // handle upload
            if (vm.ImageFile != null)
            {
                var fileName = await SaveImageAsync(vm.ImageFile);
                entity.ImageUrl = $"/uploads/cinemas/{fileName}";
            }

            await _cinemaRepo.AddAsync(entity);

            TempData["Success"] = "Cinema created successfully.";
            return Json(new { success = true });
        }

        // GET: Admin/Cinemas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _cinemaRepo.GetByIdAsync(id);
            if (entity == null) return NotFound();

            var vm = _mapper.Map<CinemaViewModel>(entity);
            return PartialView("_CinemaForm", vm);
        }

        // POST: Admin/Cinemas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CinemaViewModel vm)
        {
            if (!ModelState.IsValid)
                return PartialView("_CinemaForm", vm);

            var entity = await _cinemaRepo.GetByIdAsync(id);
            if (entity == null) return NotFound();

            _mapper.Map(vm, entity);

            if (vm.ImageFile != null)
            {
                // delete old file
                if (!string.IsNullOrEmpty(entity.ImageUrl))
                {
                    var oldPath = Path.Combine(_env.WebRootPath, entity.ImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                    if (System.IO.File.Exists(oldPath)) System.IO.File.Delete(oldPath);
                }

                var fileName = await SaveImageAsync(vm.ImageFile);
                entity.ImageUrl = $"/uploads/cinemas/{fileName}";
            }

            await _cinemaRepo.UpdateAsync(entity);

            TempData["Success"] = "Cinema updated successfully.";
            return Json(new { success = true });
        }

        // POST: Admin/Cinemas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _cinemaRepo.GetByIdAsync(id);
            if (entity == null) return Json(new { success = false, message = "Not found" });

            if (!string.IsNullOrEmpty(entity.ImageUrl))
            {
                var oldPath = Path.Combine(_env.WebRootPath, entity.ImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (System.IO.File.Exists(oldPath)) System.IO.File.Delete(oldPath);
            }

            await _cinemaRepo.DeleteAsync(id);

            TempData["Success"] = "Cinema deleted.";
            return Json(new { success = true });
        }

        // AJAX helper: quick details for modal
        public async Task<IActionResult> Details(int id)
        {
            var entity = await _cinemaRepo.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return PartialView("_DetailsPartial", entity);
        }

        private async Task<string> SaveImageAsync(IFormFile file)
        {
            var uploads = Path.Combine(_env.WebRootPath, "uploads", "cinemas");
            if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

            var ext = Path.GetExtension(file.FileName);
            var filename = $"{Guid.NewGuid()}{ext}";
            var filePath = Path.Combine(uploads, filename);

            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            return filename;
        }
    }
}
