using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels;      // BasePaginatedFilterVM
using VoxTics.Areas.Admin.ViewModels; // if you use admin filters here

namespace VoxTics.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        // Authentication
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> AuthenticateAsync(string email, string password);
        Task<bool> VerifyPasswordAsync(User user, string password);
        Task<User> UpdatePasswordAsync(int userId, string newPasswordHash);

        // User Profile
        Task<User?> GetUserWithBookingsAsync(int userId);
        Task<User?> GetUserProfileAsync(int userId);
        Task<User> UpdateProfileAsync(User user);
        Task<bool> UpdateEmailAsync(int userId, string newEmail);

        // User Bookings
        Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId);
        Task<IEnumerable<Booking>> GetUserUpcomingBookingsAsync(int userId);
        Task<IEnumerable<Booking>> GetUserPastBookingsAsync(int userId);
        Task<int> GetUserBookingCountAsync(int userId);
        Task<decimal> GetUserTotalSpentAsync(int userId);

        // User Statistics
        Task<Dictionary<string, int>> GetUserBookingStatsAsync(int userId);
        Task<IEnumerable<(Movie movie, int count)>> GetUserFavoriteMoviesAsync(int userId, int count = 5);
        Task<IEnumerable<(Cinema cinema, int count)>> GetUserFavoriteCinemasAsync(int userId, int count = 5);
        Task<IEnumerable<(Category category, int count)>> GetUserFavoriteCategoriesAsync(int userId, int count = 5);

        // Admin User Management
        Task<IEnumerable<User>> GetUsersByRoleAsync(UserRole role);
        Task<IEnumerable<User>> GetActiveUsersAsync();
        Task<IEnumerable<User>> GetInactiveUsersAsync();
        Task<IEnumerable<User>> GetNewUsersAsync(int days = 30);
        Task<(IEnumerable<User> users, int totalCount)> GetPagedUsersAsync(BasePaginatedFilterVM filter);

        // User Status Management
        Task<bool> ActivateUserAsync(int userId);
        Task<bool> DeactivateUserAsync(int userId);
        Task<bool> UpdateUserRoleAsync(int userId, UserRole role);
        Task<bool> BanUserAsync(int userId, string reason);
        Task<bool> UnbanUserAsync(int userId);

        // Search and Filter
        Task<IEnumerable<User>> SearchUsersAsync(string searchTerm);
        Task<IEnumerable<User>> GetUsersByRegistrationDateAsync(DateTime startDate, DateTime endDate);

        // Email and Username Validation
        Task<bool> IsEmailUniqueAsync(string email, int? excludeUserId = null);
        Task<bool> IsUsernameUniqueAsync(string username, int? excludeUserId = null);
        Task<bool> IsPhoneUniqueAsync(string phone, int? excludeUserId = null);

        // Password Reset
        Task<User?> GetUserByResetTokenAsync(string resetToken);
        Task<bool> SetPasswordResetTokenAsync(int userId, string token, DateTime expiry);
        Task<bool> ClearPasswordResetTokenAsync(int userId);
        Task<bool> ResetPasswordAsync(string token, string newPasswordHash);

        // Email Verification
        Task<bool> SetEmailVerificationTokenAsync(int userId, string token);
        Task<bool> VerifyEmailAsync(string token);
        Task<bool> IsEmailVerifiedAsync(int userId);

        // User Activity
        Task<DateTime?> GetLastLoginAsync(int userId);
        Task<bool> UpdateLastLoginAsync(int userId);
        Task<IEnumerable<User>> GetRecentlyActiveUsersAsync(int hours = 24);

        // Analytics
        Task<int> GetTotalUsersCountAsync();
        Task<int> GetActiveUsersCountAsync();
        Task<int> GetNewUsersCountAsync(int days = 30);
        Task<Dictionary<string, int>> GetUserRegistrationStatsAsync(int months = 12);
        Task<Dictionary<UserRole, int>> GetUserRoleStatsAsync();
        Task<decimal> GetAverageUserSpendingAsync();
        Task<IEnumerable<(User user, decimal totalSpent)>> GetTopSpendingUsersAsync(int count = 10);
        Task<IEnumerable<(User user, int bookingCount)>> GetMostActiveUsersAsync(int count = 10);

        // Preferences and Settings
        Task<bool> UpdateUserPreferencesAsync(int userId, Dictionary<string, object> preferences);
        Task<Dictionary<string, object>?> GetUserPreferencesAsync(int userId);

        // Admin Dashboard
        Task<Dictionary<string, object>> GetUserDashboardStatsAsync();
        Task<IEnumerable<User>> GetUsersForAdminAsync();

        // Validation
        Task<bool> CanDeleteUserAsync(int userId);
        Task<bool> HasActiveBookingsAsync(int userId);
    }
}
