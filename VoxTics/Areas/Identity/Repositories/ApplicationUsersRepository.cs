using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Repositories.IRepositories;
using VoxTics.Data;

namespace VoxTics.Areas.Identity.Repositories
{
    public class ApplicationUsersRepository : IApplicationUsersRepository
    {
        private readonly MovieDbContext _context;
        private readonly DbSet<ApplicationUser> _dbSet;

        public ApplicationUsersRepository(MovieDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<ApplicationUser>();
        }

        // Create user
        public async Task CreateAsync(ApplicationUser entity)
        {
            await _dbSet.AddAsync(entity).ConfigureAwait(false);
        }

        // AddAsync with cancellation support
        public async Task AddAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        }

        // Commit changes (Unit of Work)
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        // Update user
        public async Task UpdateAsync(ApplicationUser entity)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask.ConfigureAwait(false); // no DB call here
        }

        // Get filtered users
        public async Task<IEnumerable<ApplicationUser>> GetAsync(Expression<Func<ApplicationUser, bool>>? predicate = null)
        {
            IQueryable<ApplicationUser> query = _dbSet.AsNoTracking();
            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync().ConfigureAwait(false);
        }

        // Get all users
        public async Task<IEnumerable<ApplicationUser>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        // Find by PK
        public async Task<ApplicationUser?> FindAsync(params object[] keys)
        {
            return await _dbSet.FindAsync(keys).ConfigureAwait(false);
        }

        // Custom methods
        public async Task<ApplicationUser?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email).ConfigureAwait(false);
        }

        public async Task<ApplicationUser?> GetByIdAsync(string id)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Id == id).ConfigureAwait(false);
        }

        public async Task<ApplicationUser?> GetByUserNameAsync(string userName)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.UserName == userName).ConfigureAwait(false);
        }

        public async Task<ApplicationUser?> GetByUserNameOrEmailAsync(string emailOrUserName)
        {
            return await _dbSet.FirstOrDefaultAsync(u =>
                u.UserName == emailOrUserName || u.Email == emailOrUserName).ConfigureAwait(false);
        }

        public void Update(ApplicationUser entity) => _dbSet.Update(entity);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> FindAsync(Expression<Func<ApplicationUser, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<ApplicationUser, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<ApplicationUser, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<ApplicationUser> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRangeAsync(IEnumerable<ApplicationUser> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<ApplicationUser> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser?> GetFirstOrDefaultAsync(Expression<Func<ApplicationUser, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetAsync(Func<ApplicationUser, bool>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicationUser> Query()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser?> GetFirstOrDefaultAsync(Expression<Func<ApplicationUser, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser?> FindByKeysAsync(object[] keys, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
