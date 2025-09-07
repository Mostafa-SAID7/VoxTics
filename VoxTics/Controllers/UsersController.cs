using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;

namespace VoxTics.Controllers
{
    public class UsersController : Controller
    {
        private readonly MovieDbContext _db;
        private readonly ILogger<UsersController> _logger;

        public UsersController(MovieDbContext db, ILogger<UsersController> logger)
        {
            _db = db;
            _logger = logger;
        }
        
        // -----------------------
        // Register
        // -----------------------
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                if (await _db.Users.AnyAsync(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("", "Email already registered.");
                    return View(model);
                }

                var user = new User
                {
                    FirstName = model.FirstName,  // ✅ make sure RegisterVM has these
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                };

                _db.Users.Add(user);
                await _db.SaveChangesAsync();

                // TODO: Save user ID in session or cookie for "login"
                HttpContext.Session.SetInt32("UserId", user.Id);

                _logger.LogInformation("New user registered: {Email}", model.Email);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration for {Email}", model.Email);
                ModelState.AddModelError("", "An unexpected error occurred.");
            }

            return View(model);
        }

        // -----------------------
        // Login
        // -----------------------
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            if (!user.IsActive)
            {
                ModelState.AddModelError("", "Your account is inactive.");
                return View(model);
            }

            // Save login session
            HttpContext.Session.SetInt32("UserId", user.Id);
            user.LastLoginDate = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            _logger.LogInformation("User logged in: {Email}", model.Email);
            return RedirectToLocal(returnUrl);
        }

        // -----------------------
        // Logout
        // -----------------------
        [HttpPost]
        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Index", "Home");
        }

        // -----------------------
        // Profile
        // -----------------------
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login");

            var user = await _db.Users.FindAsync(userId.Value);
            if (user == null) return RedirectToAction("Login");

            var vm = new UserVM
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                Role = user.Role,
                IsActive = user.IsActive,
                IsEmailConfirmed = user.IsEmailConfirmed,
                RegistrationDate = user.CreatedAt,
                LastLoginDate = user.LastLoginDate
            };

            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditProfile(UserEditVM model)
        {
            if (!ModelState.IsValid)
                return View("Profile", model);

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login");

            var user = await _db.Users.FindAsync(userId.Value);
            if (user == null) return RedirectToAction("Login");

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.Phone;

            _db.Users.Update(user);
            await _db.SaveChangesAsync();

            TempData["Success"] = "Profile updated successfully.";
            return RedirectToAction("Profile");
        }

        // -----------------------
        // Helpers
        // -----------------------
        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }
    }
}
