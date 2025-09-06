using Microsoft.AspNetCore.Identity; // optional: for IPasswordHasher<User>
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Data;                  // MovieDbContext
using VoxTics.Models.Entities;
using VoxTics.Helpers;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IPasswordHasher<User>? _passwordHasher;

        public UserRepository(MovieDbContext context, IPasswordHasher<User>? passwordHasher = null) : base(context)
        {
            _passwordHasher = passwordHasher;
        }

        // -------------------------
        // Authentication
        // -------------------------
        public async Task<User?> GetByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return null;
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return null;
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(u => u.FullName.ToLower() == username.ToLower());
        }

        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            var user = await _dbSet.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            if (user == null) return null;

            var ok = await VerifyPasswordAsync(user, password);
            if (!ok) return null;

            return user;
        }

        public Task<bool> VerifyPasswordAsync(User user, string password)
        {
            if (user == null) return Task.FromResult(false);

            if (_passwordHasher != null && !string.IsNullOrEmpty(user.PasswordHash))
            {
                var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
                return Task.FromResult(result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded);
            }

            return Task.FromResult(user.PasswordHash == password);
        }

        public async Task<User> UpdatePasswordAsync(int userId, string newPasswordHash)
        {
            var user = await _dbSet.FindAsync(userId) ?? throw new InvalidOperationException("User not found");
            user.PasswordHash = newPasswordHash;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return user;
        }

        // -------------------------
        // Profile & Bookings
        // -------------------------
        public async Task<User?> GetUserWithBookingsAsync(int userId)
        {
            return await _dbSet
                .Where(u => u.Id == userId)
                .Include(u => u.Bookings)
                    .ThenInclude(b => b.Showtime)
                        .ThenInclude(s => s.Movie)
                .Include(u => u.Bookings)
                    .ThenInclude(b => b.BookingSeats)
                        .ThenInclude(bs => bs.Seat)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserProfileAsync(int userId)
        {
            return await _dbSet
                .Where(u => u.Id == userId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<User> UpdateProfileAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var exists = await _dbSet.FindAsync(user.Id) ?? throw new InvalidOperationException("User not found");
            // update allowed fields - copy explicitly to avoid overwriting sensitive fields accidentally
            exists.FirstName = user.FirstName;
            exists.LastName = user.LastName;
            exists.Phone = user.Phone;
            exists.AvatarUrl = user.AvatarUrl;
            exists.UpdatedAt = DateTime.UtcNow;

            _dbSet.Update(exists);
            await _context.SaveChangesAsync();
            return exists;
        }

        public async Task<bool> UpdateEmailAsync(int userId, string newEmail)
        {
            var user = await _dbSet.FindAsync(userId);
            if (user == null) return false;

            if (!await IsEmailUniqueAsync(newEmail, userId)) return false;

            user.Email = newEmail;
            user.IsEmailConfirmed = false;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        // -------------------------
        // User Bookings helpers
        // -------------------------
        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.Showtime).ThenInclude(s => s.Movie)
                .Include(b => b.BookingSeats).ThenInclude(bs => bs.Seat)
                .OrderByDescending(b => b.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetUserUpcomingBookingsAsync(int userId)
        {
            var now = DateTime.UtcNow;
            return await _context.Bookings
                .Where(b => b.UserId == userId && b.Showtime.StartTime > now && b.Status != BookingStatus.Cancelled)
                .Include(b => b.Showtime).ThenInclude(s => s.Movie)
                .Include(b => b.BookingSeats).ThenInclude(bs => bs.Seat)
                .OrderBy(b => b.Showtime.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetUserPastBookingsAsync(int userId)
        {
            var now = DateTime.UtcNow;
            return await _context.Bookings
                .Where(b => b.UserId == userId && b.Showtime.StartTime <= now)
                .Include(b => b.Showtime).ThenInclude(s => s.Movie)
                .Include(b => b.BookingSeats).ThenInclude(bs => bs.Seat)
                .OrderByDescending(b => b.Showtime.StartTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> GetUserBookingCountAsync(int userId)
        {
            return await _context.Bookings.CountAsync(b => b.UserId == userId);
        }

        public async Task<decimal> GetUserTotalSpentAsync(int userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId && b.Status == BookingStatus.Confirmed)
                .SumAsync(b => b.TotalAmount);
        }

        // -------------------------
        // User Stats & favorites
        // -------------------------
        public async Task<Dictionary<string, int>> GetUserBookingStatsAsync(int userId)
        {
            var bookings = await _context.Bookings
                .Where(b => b.UserId == userId)
                .GroupBy(b => b.Status)
                .Select(g => new { Status = g.Key.ToString(), Count = g.Count() })
                .ToDictionaryAsync(x => x.Status, x => x.Count);

            return bookings;
        }

        public async Task<IEnumerable<(Movie movie, int count)>> GetUserFavoriteMoviesAsync(int userId, int count = 5)
        {
            var grouped = await _context.Bookings
                .Where(b => b.UserId == userId && b.Status != BookingStatus.Cancelled)
                .GroupBy(b => b.Showtime.Movie)
                .Select(g => new { Movie = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(count)
                .ToListAsync();

            return grouped.Select(x => (x.Movie, x.Count));
        }

        public async Task<IEnumerable<(Cinema cinema, int count)>> GetUserFavoriteCinemasAsync(int userId, int count = 5)
        {
            var grouped = await _context.Bookings
                .Where(b => b.UserId == userId && b.Status != BookingStatus.Cancelled)
                .GroupBy(b => b.Showtime.Hall.Cinema)
                .Select(g => new { Cinema = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(count)
                .ToListAsync();

            return grouped.Select(x => (x.Cinema, x.Count));
        }

        public async Task<IEnumerable<(Category category, int count)>> GetUserFavoriteCategoriesAsync(int userId, int count = 5)
        {
            var grouped = await _context.Bookings
                .Where(b => b.UserId == userId && b.Status != BookingStatus.Cancelled)
                .SelectMany(b => b.Showtime.Movie.MovieCategories)
                .GroupBy(mc => mc.Category)
                .Select(g => new { Category = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(count)
                .ToListAsync();

            return grouped.Select(x => (x.Category, x.Count));
        }

        // -------------------------
        // Admin & listing
        // -------------------------
        public async Task<IEnumerable<User>> GetUsersByRoleAsync(UserRole role)
        {
            return await _dbSet.Where(u => u.Role == role).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<User>> GetActiveUsersAsync()
        {
            return await _dbSet.Where(u => u.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<User>> GetInactiveUsersAsync()
        {
            return await _dbSet.Where(u => !u.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<User>> GetNewUsersAsync(int days = 30)
        {
            var start = DateTime.UtcNow.AddDays(-days);
            return await _dbSet.Where(u => u.CreatedAt >= start).AsNoTracking().ToListAsync();
        }

        public async Task<(IEnumerable<User> users, int totalCount)> GetPagedUsersAsync(BasePaginatedFilterVM filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));
            if (filter.PageNumber <= 0) filter.PageNumber = 1;
            if (filter.PageSize <= 0) filter.PageSize = 10;

            var baseQuery = _dbSet.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                var s = filter.SearchTerm.ToLower();
                baseQuery = baseQuery.Where(u => u.Email.ToLower().Contains(s) ||
                                                 u.Username.ToLower().Contains(s) ||
                                                 u.FirstName.ToLower().Contains(s) ||
                                                 u.LastName.ToLower().Contains(s));
            }

            var totalCount = await baseQuery.CountAsync();

            baseQuery = filter.SortBy?.ToLower() switch
            {
                "email" => filter.SortOrder == SortOrder.Desc ? baseQuery.OrderByDescending(u => u.Email) : baseQuery.OrderBy(u => u.Email),
                "username" => filter.SortOrder == SortOrder.Desc ? baseQuery.OrderByDescending(u => u.Username) : baseQuery.OrderBy(u => u.Username),
                "createdat" => filter.SortOrder == SortOrder.Desc ? baseQuery.OrderByDescending(u => u.CreatedAt) : baseQuery.OrderBy(u => u.CreatedAt),
                _ => baseQuery.OrderByDescending(u => u.CreatedAt)
            };

            var ids = await baseQuery.Select(u => u.Id)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            var users = await _dbSet.Where(u => ids.Contains(u.Id)).AsNoTracking().ToListAsync();
            var ordered = ids.Select(id => users.First(u => u.Id == id)).ToList();

            return (ordered, totalCount);
        }

        // -------------------------
        // Status & role management
        // -------------------------
        public async Task<bool> ActivateUserAsync(int userId)
        {
            var user = await _dbSet.FindAsync(userId);
            if (user == null) return false;
            user.IsActive = true;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeactivateUserAsync(int userId)
        {
            var user = await _dbSet.FindAsync(userId);
            if (user == null) return false;
            user.IsActive = false;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserRoleAsync(int userId, UserRole role)
        {
            var user = await _dbSet.FindAsync(userId);
            if (user == null) return false;
            user.Role = role;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> BanUserAsync(int userId, string reason)
        {
            var user = await _dbSet.FindAsync(userId);
            if (user == null) return false;
            user.IsBanned = true;
            user.BanReason = reason;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UnbanUserAsync(int userId)
        {
            var user = await _dbSet.FindAsync(userId);
            if (user == null) return false;
            user.IsBanned = false;
            user.BanReason = null;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        // -------------------------
        // Search & validation
        // -------------------------
        public async Task<IEnumerable<User>> SearchUsersAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllAsync();   // ✅ should just call the parameterless version

            var s = searchTerm.ToLower();
            return await _dbSet
                .Where(u => u.Email.ToLower().Contains(s) ||
                            u.Username.ToLower().Contains(s) ||
                            u.FirstName.ToLower().Contains(s) ||
                            u.LastName.ToLower().Contains(s))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByRegistrationDateAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(u => u.CreatedAt >= startDate && u.CreatedAt <= endDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> IsEmailUniqueAsync(string email, int? excludeUserId = null)
        {
            var q = _dbSet.Where(u => u.Email.ToLower() == email.ToLower());
            if (excludeUserId.HasValue) q = q.Where(u => u.Id != excludeUserId.Value);
            return !await q.AnyAsync();
        }

        public async Task<bool> IsUsernameUniqueAsync(string username, int? excludeUserId = null)
        {
            var q = _dbSet.Where(u => u.Username.ToLower() == username.ToLower());
            if (excludeUserId.HasValue) q = q.Where(u => u.Id != excludeUserId.Value);
            return !await q.AnyAsync();
        }

        public async Task<bool> IsPhoneUniqueAsync(string phone, int? excludeUserId = null)
        {
            if (string.IsNullOrWhiteSpace(phone)) return true;
            var q = _dbSet.Where(u => u.Phone == phone);
            if (excludeUserId.HasValue) q = q.Where(u => u.Id != excludeUserId.Value);
            return !await q.AnyAsync();
        }

        // -------------------------
        // Password reset & email verification
        // -------------------------
        public async Task<User?> GetUserByResetTokenAsync(string resetToken)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.PasswordResetToken == resetToken && u.PasswordResetExpires > DateTime.UtcNow);
        }

        public async Task<bool> SetPasswordResetTokenAsync(int userId, string token, DateTime expiry)
        {
            var user = await _dbSet.FindAsync(userId);
            if (user == null) return false;
            user.PasswordResetToken = token;
            user.PasswordResetExpires = expiry;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ClearPasswordResetTokenAsync(int userId)
        {
            var user = await _dbSet.FindAsync(userId);
            if (user == null) return false;
            user.PasswordResetToken = null;
            user.PasswordResetExpires = null;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ResetPasswordAsync(string token, string newPasswordHash)
        {
            var user = await _dbSet.FirstOrDefaultAsync(u => u.PasswordResetToken == token && u.PasswordResetExpires > DateTime.UtcNow);
            if (user == null) return false;
            user.PasswordHash = newPasswordHash;
            user.PasswordResetToken = null;
            user.PasswordResetExpires = null;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SetEmailVerificationTokenAsync(int userId, string token)
        {
            var user = await _dbSet.FindAsync(userId);
            if (user == null) return false;
            user.EmailConfirmationToken = token;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> VerifyEmailAsync(string token)
        {
            var user = await _dbSet.FirstOrDefaultAsync(u => u.EmailConfirmationToken == token);
            if (user == null) return false;
            user.IsEmailConfirmed = true;
            user.EmailConfirmationToken = null;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsEmailVerifiedAsync(int userId)
        {
            var user = await _dbSet.FindAsync(userId);
            return user?.IsEmailConfirmed ?? false;
        }

        // -------------------------
        // Activity tracking
        // -------------------------
        public async Task<DateTime?> GetLastLoginAsync(int userId)
        {
            var user = await _dbSet.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
            return user?.LastLoginDate;
        }

        public async Task<bool> UpdateLastLoginAsync(int userId)
        {
            var user = await _dbSet.FindAsync(userId);
            if (user == null) return false;
            user.LastLoginDate = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetRecentlyActiveUsersAsync(int hours = 24)
        {
            var since = DateTime.UtcNow.AddHours(-hours);
            return await _dbSet.Where(u => u.LastLoginDate.HasValue && u.LastLoginDate.Value >= since).AsNoTracking().ToListAsync();
        }

        // -------------------------
        // Analytics
        // -------------------------
        public async Task<int> GetTotalUsersCountAsync() => await _dbSet.CountAsync();

        public async Task<int> GetActiveUsersCountAsync() => await _dbSet.CountAsync(u => u.IsActive);

        public async Task<int> GetNewUsersCountAsync(int days = 30)
        {
            var since = DateTime.UtcNow.AddDays(-days);
            return await _dbSet.CountAsync(u => u.CreatedAt >= since);
        }

        public async Task<Dictionary<string, int>> GetUserRegistrationStatsAsync(int months = 12)
        {
            var today = DateTime.UtcNow.Date;
            var start = today.AddMonths(-months + 1);

            var grouped = await _dbSet
                .Where(u => u.CreatedAt >= start)
                .GroupBy(u => new { u.CreatedAt.Year, u.CreatedAt.Month })
                .Select(g => new { g.Key.Year, g.Key.Month, Count = g.Count() })
                .ToListAsync();

            var result = new Dictionary<string, int>();
            for (int i = 0; i < months; i++)
            {
                var dt = start.AddMonths(i);
                var key = $"{dt:yyyy-MM}";
                var item = grouped.FirstOrDefault(g => g.Year == dt.Year && g.Month == dt.Month);
                result[key] = item?.Count ?? 0;
            }
            return result;
        }

        public async Task<Dictionary<UserRole, int>> GetUserRoleStatsAsync()
        {
            var grouped = await _dbSet.GroupBy(u => u.Role).Select(g => new { Role = g.Key, Count = g.Count() }).ToListAsync();
            return grouped.ToDictionary(x => x.Role, x => x.Count);
        }

        public async Task<decimal> GetAverageUserSpendingAsync()
        {
            var total = await _context.Bookings.Where(b => b.Status == BookingStatus.Confirmed).SumAsync(b => b.TotalAmount);
            var users = await _dbSet.CountAsync();
            return users == 0 ? 0m : total / users;
        }

        public async Task<IEnumerable<(User user, decimal totalSpent)>> GetTopSpendingUsersAsync(int count = 10)
        {
            var grouped = await _context.Bookings
                .Where(b => b.Status == BookingStatus.Confirmed)
                .GroupBy(b => b.User)
                .Select(g => new { User = g.Key, Total = g.Sum(b => b.TotalAmount) })
                .OrderByDescending(x => x.Total)
                .Take(count)
                .ToListAsync();

            return grouped.Select(x => (x.User, x.Total));
        }

        public async Task<IEnumerable<(User user, int bookingCount)>> GetMostActiveUsersAsync(int count = 10)
        {
            var grouped = await _context.Bookings
                .GroupBy(b => b.User)
                .Select(g => new { User = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(count)
                .ToListAsync();

            return grouped.Select(x => (x.User, x.Count));
        }

        // -------------------------
        // Preferences (stored as JSON in User.PreferencesJson)
        // -------------------------
        public async Task<bool> UpdateUserPreferencesAsync(int userId, Dictionary<string, object> preferences)
        {
            var user = await _dbSet.FindAsync(userId);
            if (user == null) return false;
            user.PreferencesJson = JsonSerializer.Serialize(preferences);
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Dictionary<string, object>?> GetUserPreferencesAsync(int userId)
        {
            var user = await _dbSet.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null || string.IsNullOrWhiteSpace(user.PreferencesJson)) return null;

            try
            {
                return JsonSerializer.Deserialize<Dictionary<string, object>>(user.PreferencesJson);
            }
            catch
            {
                return null;
            }
        }

        // -------------------------
        // Admin Dashboard & helpers
        // -------------------------
        public async Task<Dictionary<string, object>> GetUserDashboardStatsAsync()
        {
            var total = await GetTotalUsersCountAsync();
            var active = await GetActiveUsersCountAsync();
            var new30 = await GetNewUsersCountAsync(30);
            var topSpenders = await GetTopSpendingUsersAsync(5);
            return new Dictionary<string, object>
            {
                ["TotalUsers"] = total,
                ["ActiveUsers"] = active,
                ["NewUsersLast30Days"] = new30,
                ["TopSpenders"] = topSpenders.Select(t => new { t.user.Id, t.user.Email, t.totalSpent }).ToList()
            };
        }

        public async Task<IEnumerable<User>> GetUsersForAdminAsync()
        {
            return await _dbSet.OrderByDescending(u => u.CreatedAt).AsNoTracking().ToListAsync();
        }

        // -------------------------
        // Validation & delete checks
        // -------------------------
        public async Task<bool> CanDeleteUserAsync(int userId)
        {
            // disallow delete if user has confirmed bookings
            var hasBookings = await _context.Bookings.AnyAsync(b => b.UserId == userId && b.Status == BookingStatus.Confirmed);
            return !hasBookings;
        }

        public async Task<bool> HasActiveBookingsAsync(int userId)
        {
            return await _context.Bookings.AnyAsync(b => b.UserId == userId && b.Status != BookingStatus.Cancelled);
        }
    }
}
