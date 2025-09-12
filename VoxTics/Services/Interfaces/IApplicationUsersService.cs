
    using global::VoxTics.Areas.Identity.Models.Entities;
    using VoxTics.Areas.Identity.Models.Entities;

    namespace VoxTics.Services.Interfaces
    {
        /// <summary>
        /// Service layer for managing ApplicationUser operations.
        /// Wraps repository calls with additional business logic if needed.
        /// </summary>
        public interface IApplicationUsersService
        {
            Task<ApplicationUser?> GetByEmailAsync(string email);
            Task<ApplicationUser?> GetByUserNameAsync(string userName);

            Task<IEnumerable<ApplicationUser>> GetActiveUsersAsync();
            Task<IEnumerable<ApplicationUser>> GetBannedUsersAsync();
            Task<int> GetActiveUsersCountAsync();
            Task<int> GetBannedUsersCountAsync();

            Task UpdateLastLoginAsync(string userId);

            Task<bool> BanUserAsync(string userId, string reason);
            Task<bool> UnbanUserAsync(string userId);

            Task<bool> UpdatePreferencesAsync(string userId, IDictionary<string, string> preferences);
            Task<string?> GetPreferenceAsync(string userId, string key);

            Task<bool> IsEmailConfirmedAsync(string userId);
            Task SetEmailConfirmedAsync(string userId, bool confirmed);

            Task<DateTime?> GetLastPasswordResetRequestAsync(string userId);
        }
    }


