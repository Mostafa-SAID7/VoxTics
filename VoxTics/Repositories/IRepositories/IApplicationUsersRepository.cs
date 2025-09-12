using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Repositories.IRepositories
{
    /// <summary>
    /// Repository contract for managing ApplicationUser entities and related user-specific operations.
    /// Extends the generic IBaseRepository for common CRUD and adds Identity-specific methods.
    /// </summary>
    public interface IApplicationUsersRepository : IBaseRepository<ApplicationUser>
    {
        // 🔎 Retrieval
        Task<ApplicationUser?> GetByEmailAsync(string email);
        Task<ApplicationUser?> GetByUserNameAsync(string userName);

        // 👥 Active / Banned Users
        Task<IEnumerable<ApplicationUser>> GetActiveUsersAsync();
        Task<IEnumerable<ApplicationUser>> GetBannedUsersAsync();
        Task<int> GetActiveUsersCountAsync();
        Task<int> GetBannedUsersCountAsync();

        // 🔐 Authentication / Login Tracking
        Task UpdateLastLoginAsync(string userId);

        // 🚫 Ban Management
        Task<bool> BanUserAsync(string userId, string reason);
        Task<bool> UnbanUserAsync(string userId);

        // ⚙️ Preferences (generic key/value)
        Task<bool> UpdatePreferencesAsync(string userId, IDictionary<string, string> preferences);
        Task<string?> GetPreferenceAsync(string userId, string key);

        // ✅ Email Confirmation Helpers (Optional but useful for AccountController)
        Task<bool> IsEmailConfirmedAsync(string userId);
        Task SetEmailConfirmedAsync(string userId, bool confirmed);

        // 🔄 Password Reset Helper
        Task<DateTime?> GetLastPasswordResetRequestAsync(string userId);
    }
}
