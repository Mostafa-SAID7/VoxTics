// Areas/Identity/Repositories/ApplicationUsersRepository.cs
using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Repositories.IRepositories;
using VoxTics.Data;
using VoxTics.Repositories;

namespace VoxTics.Areas.Identity.Repositories
{
    public class ApplicationUsersRepository : BaseRepository<ApplicationUser>, IApplicationUsersRepository
    {

        public ApplicationUsersRepository(MovieDbContext context) : base(context) { }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            return await _context.Users
                .Include(u => u.Bookings)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ApplicationUser> AddAsync(ApplicationUser entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(ApplicationUser entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> IsEmailUniqueAsync(string email, string excludeUserId = null)
        {
            return !await _context.Users
                .AnyAsync(u => u.Email == email && u.Id != excludeUserId);
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersWithBookingsAsync()
        {
            return await _context.Users
                .Include(u => u.Bookings)
                .Where(u => u.Bookings.Any())
                .ToListAsync();
        }
    }
}