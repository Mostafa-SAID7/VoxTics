using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VoxTics.Data;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly MovieDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _context.Database.SetCommandTimeout(180);

            _context.ChangeTracker.LazyLoadingEnabled = false;
        }

        public IQueryable<T> Query(string? includeProperties = null, bool asNoTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (asNoTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var include in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    var propName = include.Trim();
                    var prop = typeof(T).GetProperty(propName);

                    if (prop != null) // property exists on the entity
                    {
                        query = query.Include(propName);
                    }
                    else
                    {
                        // optional: log warning instead of throwing
                        Console.WriteLine($"⚠️ Warning: '{propName}' is not a navigation property of {typeof(T).Name}");
                    }
                }
            }

            return query;
        }


        public async Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null)
            => await Query(includeProperties).ToListAsync();

        public async Task<T?> GetByIdAsync(object id, string? includeProperties = null)
        {
            if (string.IsNullOrWhiteSpace(includeProperties))
            {
                var found = await _dbSet.FindAsync(id);
                return found;
            }

            var prop = typeof(T).GetProperty("Id");
            if (prop == null)
                return await Query(includeProperties, asNoTracking: false).FirstOrDefaultAsync();

            object convertedId;
            try { convertedId = Convert.ChangeType(id, prop.PropertyType); }
            catch { return null; }

            var param = Expression.Parameter(typeof(T), "e");
            var left = Expression.Property(param, prop);
            var right = Expression.Constant(convertedId, prop.PropertyType);
            var body = Expression.Equal(left, right);
            var lambda = Expression.Lambda<Func<T, bool>>(body, param);

            return await Query(includeProperties, asNoTracking: false).FirstOrDefaultAsync(lambda);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, string? includeProperties = null)
            => await Query(includeProperties, asNoTracking: false).Where(predicate).ToListAsync();

        public async Task AddAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var existing = await _dbSet.FindAsync(id);
            if (existing == null) return;
            _dbSet.Remove(existing);
            await _context.SaveChangesAsync();
        }
    }
}
