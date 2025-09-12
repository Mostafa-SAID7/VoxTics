using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    /// <summary>
    /// Implementation of IApplicationUsersService.
    /// Delegates operations to IApplicationUsersRepository and adds business logic if needed.
    /// </summary>
    public class ApplicationUsersService : IApplicationUsersService
    {
        private readonly IApplicationUsersRepository _usersRepository;

        public ApplicationUsersService(IApplicationUsersRepository usersRepository)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
        }

        public Task<ApplicationUser?> GetByEmailAsync(string email) =>
            _usersRepository.GetByEmailAsync(email);

        public Task<ApplicationUser?> GetByUserNameAsync(string userName) =>
            _usersRepository.GetByUserNameAsync(userName);

        public Task<IEnumerable<ApplicationUser>> GetActiveUsersAsync() =>
            _usersRepository.GetActiveUsersAsync();

        public Task<IEnumerable<ApplicationUser>> GetBannedUsersAsync() =>
            _usersRepository.GetBannedUsersAsync();

        public Task<int> GetActiveUsersCountAsync() =>
            _usersRepository.GetActiveUsersCountAsync();

        public Task<int> GetBannedUsersCountAsync() =>
            _usersRepository.GetBannedUsersCountAsync();

        public Task UpdateLastLoginAsync(string userId) =>
            _usersRepository.UpdateLastLoginAsync(userId);

        public Task<bool> BanUserAsync(string userId, string reason) =>
            _usersRepository.BanUserAsync(userId, reason);

        public Task<bool> UnbanUserAsync(string userId) =>
            _usersRepository.UnbanUserAsync(userId);

        public Task<bool> UpdatePreferencesAsync(string userId, IDictionary<string, string> preferences) =>
            _usersRepository.UpdatePreferencesAsync(userId, preferences);

        public Task<string?> GetPreferenceAsync(string userId, string key) =>
            _usersRepository.GetPreferenceAsync(userId, key);

        public Task<bool> IsEmailConfirmedAsync(string userId) =>
            _usersRepository.IsEmailConfirmedAsync(userId);

        public Task SetEmailConfirmedAsync(string userId, bool confirmed) =>
            _usersRepository.SetEmailConfirmedAsync(userId, confirmed);

        public Task<DateTime?> GetLastPasswordResetRequestAsync(string userId) =>
            _usersRepository.GetLastPasswordResetRequestAsync(userId);
    }
}
