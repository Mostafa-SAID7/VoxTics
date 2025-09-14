using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MovieDbContext _context;
        private readonly DbSet<T> _dbSet;
        private DbContext context;

        public BaseRepository(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public BaseRepository(DbContext context)
        {
            this.context = context;
        }

        #region Querying

        public IQueryable<T> Query() => _dbSet.AsQueryable();

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _dbSet.AsNoTracking().ToListAsync(cancellationToken).ConfigureAwait(false);

        public async Task<IEnumerable<T>> FindAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return await _dbSet.AsNoTracking()
                .Where(predicate)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            await _dbSet.FindAsync(new object?[] { id }, cancellationToken).ConfigureAwait(false);

        public async Task<T?> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return await _dbSet.AsNoTracking()
                .FirstOrDefaultAsync(predicate, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<bool> AnyAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return await _dbSet.AnyAsync(predicate, cancellationToken).ConfigureAwait(false);
        }

        public async Task<int> CountAsync(
            Expression<Func<T, bool>>? predicate = null,
            CancellationToken cancellationToken = default) =>
            predicate == null
                ? await _dbSet.CountAsync(cancellationToken).ConfigureAwait(false)
                : await _dbSet.CountAsync(predicate, cancellationToken).ConfigureAwait(false);

        public async Task<T?> FindByKeysAsync(
            object[] keys,
            CancellationToken cancellationToken = default)
        {
            if (keys == null || keys.Length == 0) throw new ArgumentException("Keys must not be null or empty.", nameof(keys));
            return await _dbSet.FindAsync(keys, cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region Commands (CRUD)

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _dbSet.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            await _dbSet.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await Task.Run(() => _dbSet.Update(entity), cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            await Task.Run(() => _dbSet.UpdateRange(entities), cancellationToken).ConfigureAwait(false);
        }

        public async Task RemoveAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await Task.Run(() => _dbSet.Remove(entity), cancellationToken).ConfigureAwait(false);
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            await Task.Run(() => _dbSet.RemoveRange(entities), cancellationToken).ConfigureAwait(false);
        }

        #endregion
    }
}
