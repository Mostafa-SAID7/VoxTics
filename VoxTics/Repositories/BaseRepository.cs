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
        protected readonly MovieDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        #region Querying
        public IQueryable<T> Query() => _dbSet.AsQueryable();

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
            }
            catch (TaskCanceledException)
            {
                // المهمة أُلغيّت، إرجاع قائمة فارغة بدلًا من رفع استثناء
                return Enumerable.Empty<T>();
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            try
            {
                return await _dbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
            }
            catch (TaskCanceledException)
            {
                return Enumerable.Empty<T>();
            }
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.FindAsync(new object?[] { id }, cancellationToken);
            }
            catch (TaskCanceledException)
            {
                return null;
            }
        }

        public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            try
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate, cancellationToken);
            }
            catch (TaskCanceledException)
            {
                return null;
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            try
            {
                return await _dbSet.AnyAsync(predicate, cancellationToken);
            }
            catch (TaskCanceledException)
            {
                return false;
            }
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            try
            {
                return predicate == null
                    ? await _dbSet.CountAsync(cancellationToken)
                    : await _dbSet.CountAsync(predicate, cancellationToken);
            }
            catch (TaskCanceledException)
            {
                return 0;
            }
        }

        #endregion

        #region Commands (CRUD)

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            try
            {
                await _dbSet.AddAsync(entity, cancellationToken);
            }
            catch (TaskCanceledException) { /* يمكن تسجيل الحدث إذا أحببت */ }
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            try
            {
                await _dbSet.AddRangeAsync(entities, cancellationToken);
            }
            catch (TaskCanceledException) { }
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            _dbSet.UpdateRange(entities);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            _dbSet.RemoveRange(entities);
            await Task.CompletedTask;
        }

        public async Task<T?> FindByKeysAsync(object[] keys, CancellationToken cancellationToken = default)
        {
            if (keys == null || keys.Length == 0)
                throw new ArgumentException("Keys must not be null or empty.", nameof(keys));

            try
            {
                return await _dbSet.FindAsync(keys, cancellationToken);
            }
            catch (TaskCanceledException)
            {
                return null;
            }
        }

        #endregion
    }
}
