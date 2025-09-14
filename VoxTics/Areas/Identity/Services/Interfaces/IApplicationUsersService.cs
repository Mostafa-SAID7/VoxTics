using Microsoft.AspNetCore.Identity;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;

namespace VoxTics.Areas.Identity.Services.Interfaces
{
    public interface IApplicationUsersService
    {
        #region User Queries

        /// <summary>
        /// Get a user by ID, including navigation properties.
        /// </summary>
        Task<ApplicationUser?> GetUserByIdAsync(
            string userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all users with optional search and paging.
        /// </summary>
        Task<PaginatedList<ApplicationUser>> GetAllUsersAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            CancellationToken cancellationToken = default);

        #endregion

        #region User Commands

        /// <summary>
        /// Creates a new user with a password and optional email confirmation.
        /// </summary>
        Task<ApplicationUser> CreateUserAsync(
            ApplicationUser newUser,
            string password,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing user's profile.
        /// </summary>
        Task<bool> UpdateUserAsync(
            ApplicationUser user,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        Task<bool> DeleteUserAsync(
            string userId,
            CancellationToken cancellationToken = default);

        #endregion

        #region Validation

        /// <summary>
        /// Checks if an email is already taken by another user.
        /// </summary>
        Task<bool> IsEmailTakenAsync(
            string email,
            string? excludingUserId = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if a phone number is already taken by another user.
        /// </summary>
        Task<bool> IsPhoneNumberTakenAsync(
            string phoneNumber,
            string? excludingUserId = null,
            CancellationToken cancellationToken = default);

        #endregion

        #region User Stats / Reporting

        /// <summary>
        /// Retrieves general statistics about users for dashboards or admin reporting.
        /// </summary>
        Task<UserManagementStats> GetUserStatsAsync(
            CancellationToken cancellationToken = default);

        #endregion
    }
}
