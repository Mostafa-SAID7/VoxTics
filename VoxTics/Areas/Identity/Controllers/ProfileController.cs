using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Areas.Identity.Services.Interfaces;

namespace VoxTics.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Authorize]
    public class AccountProfileController : Controller
    {
        private readonly IApplicationUsersService _usersService;
        private readonly IMapper _mapper;
        public AccountProfileController(IApplicationUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return NotFound();

            var user = await _usersService.GetByIdAsync(userId);
            if (user == null) return NotFound();

            var vm = _mapper.Map<PersonalInfoVM>(user);
            return View(vm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonalInfoVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return NotFound();

            var (succeeded, message) = await _usersService.UpdateProfileAsync(userId, vm);
            if (!succeeded)
            {
                TempData["error-notification"] = message;
                return View(vm);
            }

            TempData["success-notification"] = message;
            return RedirectToAction("Edit");
        }
    }
}
