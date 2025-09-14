using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.Enums;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Areas.Identity.Services.Interfaces;
using VoxTics.Data.UoW;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Areas.Identity.Services.Implementations
{
    public class ApplicationUsersService : IApplicationUsersService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _uow;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationUsersService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUnitOfWork uow,
            IEmailSender emailSender,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        #region User Queries

        public async Task<ApplicationUser?> GetUserByIdAsync(string userId, CancellationToken cancellationToken = default)
        {
            return await _uow.ApplicationUsers.Query()
                .Include(u => u.Bookings)
                .Include(u => u.Watchlists)
                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        }

        public async Task<PaginatedList<ApplicationUser>> GetAllUsersAsync(int pageIndex, int pageSize, string? searchTerm = null, CancellationToken cancellationToken = default)
        {
            var query = _uow.ApplicationUsers.Query().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(u =>
                    u.UserName.Contains(searchTerm) ||
                    u.Email.Contains(searchTerm) ||
                    u.Name.Contains(searchTerm));
            }

            var count = await query.CountAsync(cancellationToken);
            var items = await query
                .OrderBy(u => u.UserName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsyncSafe(cancellationToken);

            return new PaginatedList<ApplicationUser>(items, count, pageIndex, pageSize);
        }

        #endregion

        #region User Commands

        public async Task<ApplicationUser> CreateUserAsync(ApplicationUser newUser, string password, CancellationToken cancellationToken = default)
        {
            if (!ValidationHelpers.IsValidEmail(newUser.Email!))
                throw new ArgumentException("Invalid email format");

            if (!ValidationHelpers.IsValidPassword(password))
                throw new ArgumentException("Password does not meet minimum requirements");

            var result = await _userManager.CreateAsync(newUser, password);
            if (!result.Succeeded)
                throw new InvalidOperationException(string.Join("; ", result.Errors.Select(e => e.Description)));

            // Optionally send welcome email
            await _emailSender.SendEmailAsync(newUser.Email, "Welcome!", "Your account has been created.");

            return newUser;
        }

        public async Task<bool> UpdateUserAsync(ApplicationUser user, CancellationToken cancellationToken = default)
        {
            var existingUser = await _uow.ApplicationUsers.GetByIdAsync(user.Id, cancellationToken);
            if (existingUser == null)
                return false;

            existingUser.Name = user.Name;
            existingUser.DateOfBirth = user.DateOfBirth;
            existingUser.Gender = user.Gender;
            existingUser.Address = user.Address;
            existingUser.State = user.State;
            existingUser.City = user.City;
            existingUser.Street = user.Street;
            existingUser.ZipCode = user.ZipCode;
            existingUser.AvatarUrl = user.AvatarUrl;

            await _uow.ApplicationUsers.UpdateAsync(existingUser, cancellationToken);
            await _uow.CommitAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteUserAsync(string userId, CancellationToken cancellationToken = default)
        {
            var user = await _uow.ApplicationUsers.GetByIdAsync(userId, cancellationToken);
            if (user == null) return false;

            await _uow.ApplicationUsers.RemoveAsync(user, cancellationToken);
            await _uow.CommitAsync(cancellationToken);

            return true;
        }

        #endregion

        #region User Validation

        public async Task<bool> IsEmailTakenAsync(string email, string? excludingUserId = null, CancellationToken cancellationToken = default)
        {
            return await _uow.ApplicationUsers.Query()
                .AnyAsync(u => u.Email == email && u.Id != excludingUserId, cancellationToken);
        }

        public async Task<bool> IsPhoneNumberTakenAsync(string phoneNumber, string? excludingUserId = null, CancellationToken cancellationToken = default)
        {
            return await _uow.ApplicationUsers.Query()
                .AnyAsync(u => u.PhoneNumber == phoneNumber && u.Id != excludingUserId, cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region User Stats

        public async Task<UserManagementStats> GetUserStatsAsync(CancellationToken cancellationToken = default)
        {
            var totalUsers = await _uow.ApplicationUsers.CountAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            var activeUsers = await _uow.ApplicationUsers.CountAsync(u => u.LockoutEnd == null || u.LockoutEnd <= DateTime.UtcNow, cancellationToken).ConfigureAwait(false);
            var inactiveUsers = totalUsers - activeUsers;
            var newUsersToday = await _uow.ApplicationUsers.CountAsync(u => u.CreatedAt != null && ((DateTime)u.CreatedAt).Date == DateTime.UtcNow.Date, cancellationToken).ConfigureAwait(false);
            var usersWithPendingBookings = await _uow.Bookings.CountAsync(b => b.Status == BookingStatus.Pending, cancellationToken).ConfigureAwait(false);

            return new UserManagementStats
            {
                TotalUsers = totalUsers,
                ActiveUsers = activeUsers,
                InactiveUsers = inactiveUsers,
                NewUsersToday = newUsersToday,
                UsersWithPendingBookings = usersWithPendingBookings
            };
        }

        #endregion
    }
}
