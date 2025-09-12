using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VoxTics.Data;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly MovieDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(predicate).ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(predicate, cancellationToken).ConfigureAwait(false);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            return predicate == null
                ? await _dbSet.CountAsync(cancellationToken).ConfigureAwait(false)
                : await _dbSet.CountAsync(predicate, cancellationToken).ConfigureAwait(false);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _dbSet.Update(entity), cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _dbSet.UpdateRange(entities), cancellationToken).ConfigureAwait(false);
        }

        public async Task RemoveAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _dbSet.Remove(entity), cancellationToken).ConfigureAwait(false);
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _dbSet.RemoveRange(entities), cancellationToken).ConfigureAwait(false);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
