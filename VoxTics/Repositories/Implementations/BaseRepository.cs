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
        protected readonly MovieDbContext _db;

        public BaseRepository(MovieDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IQueryable<T> Query(string? includeProperties = null, bool asNoTracking = true)
        {
            IQueryable<T> query = _db.Set<T>();

            if (asNoTracking)
                query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                var includes = includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var include in includes)
                {
                    query = query.Include(include.Trim());
                }
            }

            return query;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null)
        {
            return await Query(includeProperties).ToListAsync();
        }

        public async Task<T?> GetAsync(object id, string? includeProperties = null)
        {
            if (string.IsNullOrWhiteSpace(includeProperties))
            {
                // Fast path: no includes, use FindAsync (works with EF Core keys)
                var found = await _db.Set<T>().FindAsync(new object[] { id });
                return found as T;
            }

            // When includes are requested, we need to query and match by key.
            // This implementation assumes the primary key property is named "Id".
            var prop = typeof(T).GetProperty("Id");
            if (prop == null)
            {
                // fallback to FirstOrDefault without predicate (not ideal)
                return await Query(includeProperties, asNoTracking: false).FirstOrDefaultAsync();
            }

            object convertedId;
            try
            {
                convertedId = Convert.ChangeType(id, prop.PropertyType);
            }
            catch
            {
                // can't convert id; return null
                return null;
            }

            // build lambda: e => e.Id == convertedId
            var param = Expression.Parameter(typeof(T), "e");
            var left = Expression.Property(param, prop);
            var right = Expression.Constant(convertedId, prop.PropertyType);
            var body = Expression.Equal(left, right);
            var lambda = Expression.Lambda<Func<T, bool>>(body, param);

            return await Query(includeProperties, asNoTracking: false).FirstOrDefaultAsync(lambda);
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var existing = await _db.Set<T>().FindAsync(new object[] { id });
            if (existing == null) return;
            _db.Set<T>().Remove(existing);
            await _db.SaveChangesAsync();
        }
    }
}
