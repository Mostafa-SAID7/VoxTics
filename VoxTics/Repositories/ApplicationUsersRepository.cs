using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Data;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    public class ApplicationUsersRepository : BaseRepository<ApplicationUser>, IApplicationUsersRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUsersRepository(MovieDbContext context, UserManager<ApplicationUser> userManager)
            : base(context)
        {
            _userManager = userManager;
        }

        // 🔎 Find by email
        public async Task<ApplicationUser?> GetByEmailAsync(string email)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        // 🔎 Find by username
        public async Task<ApplicationUser?> GetByUserNameAsync(string userName)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        // 👥 Active users (not banned/locked out)
        public async Task<IEnumerable<ApplicationUser>> GetActiveUsersAsync()
        {
            return await _userManager.Users
                .Where(u => u.LockoutEnd == null || u.LockoutEnd <= DateTime.UtcNow)
                .ToListAsync();
        }

        // 👥 Banned users
        public async Task<IEnumerable<ApplicationUser>> GetBannedUsersAsync()
        {
            return await _userManager.Users
                .Where(u => u.LockoutEnd != null && u.LockoutEnd > DateTime.UtcNow)
                .ToListAsync();
        }

        // 🧮 Counts
        public async Task<int> GetActiveUsersCountAsync()
        {
            return await _userManager.Users
                .CountAsync(u => u.LockoutEnd == null || u.LockoutEnd <= DateTime.UtcNow);
        }

        public async Task<int> GetBannedUsersCountAsync()
        {
            return await _userManager.Users
                .CountAsync(u => u.LockoutEnd != null && u.LockoutEnd > DateTime.UtcNow);
        }

        // 🔐 Update last login
        public async Task UpdateLastLoginAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.LastLoginDate = DateTime.UtcNow;
                await _userManager.UpdateAsync(user);
            }
        }

        // 🚫 Ban user
        public async Task<bool> BanUserAsync(string userId, string reason)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            user.LockoutEnd = DateTime.UtcNow.AddYears(100); // effectively permanent ban
            user.LockoutEnabled = true;
            user.BanReason = reason;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        // ✅ Unban user
        public async Task<bool> UnbanUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            user.LockoutEnd = null;
            user.BanReason = null;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        // ⚙️ Update preferences
        public async Task<bool> UpdatePreferencesAsync(string userId, IDictionary<string, string> preferences)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            // Assumes ApplicationUser has Preferences JSON/string property
            user.PreferencesJson = System.Text.Json.JsonSerializer.Serialize(preferences);
            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        // ⚙️ Get a specific preference
        public async Task<string?> GetPreferenceAsync(string userId, string key)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user?.PreferencesJson == null) return null;

            var prefs = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(user.PreferencesJson);
            return prefs != null && prefs.ContainsKey(key) ? prefs[key] : null;
        }

        // 📧 Email confirmation helpers
        public async Task<bool> IsEmailConfirmedAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user != null && await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task SetEmailConfirmedAsync(string userId, bool confirmed)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                if (confirmed && !user.EmailConfirmed)
                {
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                }
            }
        }

        // 🔄 Password reset tracking (optional storage in user table)
        public async Task<DateTime?> GetLastPasswordResetRequestAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user?.LastPasswordResetRequest;
        }
    }
}
