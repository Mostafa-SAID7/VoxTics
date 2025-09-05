using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        // GET: Admin/Users
        public async Task<IActionResult> Index(string? search, int pageIndex = 1, int pageSize = 10)
        {
            var query = _userRepo.Query();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(u => u.FullName.Contains(search) || u.Email.Contains(search));

            var paged = await PaginatedList<User>.CreateAsync(query, pageIndex, pageSize);
            var mapped = paged.Select(u => _mapper.Map<UserAdminVM>(u)).ToList();
            var vm = new PaginatedList<UserAdminVM>(mapped, paged.TotalCount, paged.PageIndex, paged.PageSize);

            return View(vm);
        }

        // GET: Admin/Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return NotFound();

            var vm = _mapper.Map<UserAdminVM>(user);
            return View(vm);
        }

        // POST: Admin/Users/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserAdminVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = await _userRepo.GetByIdAsync(vm.Id);
            if (user == null) return NotFound();

            _mapper.Map(vm, user);
            await _userRepo.UpdateAsync(user);

            TempData["Success"] = "User updated.";
            return RedirectToAction("Index");
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRepo.DeleteAsync(id);
            TempData["Success"] = "User deleted.";
            return RedirectToAction("Index");
        }
    }
}
