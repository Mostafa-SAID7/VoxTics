using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;
using BCrypt.Net;

namespace VoxTics.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        // GET: /Users/Register
        public IActionResult Register() => View();

        // POST: /Users/Register
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = _mapper.Map<User>(vm);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(vm.Password);

            await _userRepo.AddAsync(user);

            TempData["Success"] = "Account created. Please log in.";
            return RedirectToAction("Login");
        }

        // GET: /Users/Login
        public IActionResult Login() => View();

        // POST: /Users/Login
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = (await _userRepo.FindAsync(u => u.Email == vm.Email)).FirstOrDefault();
            if (user == null || !BCrypt.Net.BCrypt.Verify(vm.Password, user.PasswordHash))
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(vm);
            }

            // fake session (replace with Identity / Auth cookie in real app)
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.FullName);
            HttpContext.Session.SetString("UserRole", user.Role);

            return RedirectToAction("Profile");
        }

        // GET: /Users/Profile
        public async Task<IActionResult> Profile()
        {
            var id = HttpContext.Session.GetInt32("UserId");
            if (id == null) return RedirectToAction("Login");

            var user = await _userRepo.GetByIdAsync(id.Value);
            if (user == null) return RedirectToAction("Login");

            var vm = _mapper.Map<UserVM>(user);
            return View(vm);
        }

        // GET: /Users/EditProfile
        public async Task<IActionResult> EditProfile()
        {
            var id = HttpContext.Session.GetInt32("UserId");
            if (id == null) return RedirectToAction("Login");

            var user = await _userRepo.GetByIdAsync(id.Value);
            if (user == null) return RedirectToAction("Login");

            var vm = _mapper.Map<UserEditVM>(user);
            return View(vm);
        }

        // POST: /Users/EditProfile
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(UserEditVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = await _userRepo.GetByIdAsync(vm.Id);
            if (user == null) return RedirectToAction("Login");

            _mapper.Map(vm, user);
            await _userRepo.UpdateAsync(user);

            TempData["Success"] = "Profile updated.";
            return RedirectToAction("Profile");
        }

        // GET: /Users/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
