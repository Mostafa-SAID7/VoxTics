using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public UsersController(IUserRepository userRepo, IMapper mapper, IWebHostEnvironment env)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userRepo.GetAllAsync();
            var vm = users.Select(u => _mapper.Map<UserViewModel>(u));
            return View(vm);
        }

        public IActionResult Create()
        {
            return PartialView("_UserForm", new UserViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel vm)
        {
            if (!ModelState.IsValid) return PartialView("_UserForm", vm);

            var entity = _mapper.Map<User>(vm);

            if (vm.ImageFile != null)
            {
                var fileName = await SaveImageAsync(vm.ImageFile);
                entity.ImageUrl = $"/uploads/users/{fileName}";
            }

            await _userRepo.AddAsync(entity);
            TempData["Success"] = "User created successfully.";
            return Json(new { success = true });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _userRepo.GetByIdAsync(id);
            if (entity == null) return NotFound();

            var vm = _mapper.Map<UserViewModel>(entity);
            return PartialView("_UserForm", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserViewModel vm)
        {
            if (!ModelState.IsValid) return PartialView("_UserForm", vm);

            var entity = await _userRepo.GetByIdAsync(id);
            if (entity == null) return NotFound();

            _mapper.Map(vm, entity);

            if (vm.ImageFile != null)
            {
                if (!string.IsNullOrEmpty(entity.ImageUrl))
                {
                    var oldPath = Path.Combine(_env.WebRootPath, entity.ImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                    if (System.IO.File.Exists(oldPath)) System.IO.File.Delete(oldPath);
                }

                var fileName = await SaveImageAsync(vm.ImageFile);
                entity.ImageUrl = $"/uploads/users/{fileName}";
            }

            await _userRepo.UpdateAsync(entity);
            TempData["Success"] = "User updated successfully.";
            return Json(new { success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRepo.DeleteAsync(id);
            TempData["Success"] = "User deleted.";
            return Json(new { success = true });
        }

        private async Task<string> SaveImageAsync(IFormFile file)
        {
            var uploads = Path.Combine(_env.WebRootPath, "uploads", "users");
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
