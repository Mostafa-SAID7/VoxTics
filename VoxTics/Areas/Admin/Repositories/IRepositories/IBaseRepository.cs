using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VoxTics.Models.Entities;

namespace VoxTics.Areas.Admin.Repositories.IRepositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly MovieDbContext _ctx;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(MovieDbContext ctx)
        {
            _ctx = ctx;
            _dbSet = ctx.Set<T>();
        }

        public IQueryable<T> GetAll(bool asNoTracking = true)
        {
            return asNoTracking ? _dbSet.AsNoTracking() : _dbSet;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            // assumes single-key named Id; override in specific repo if necessary
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public void Add(T entity) => _dbSet.Add(entity);
        public void AddRange(IEnumerable<T> entities) => _dbSet.AddRange(entities);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Remove(T entity) => _dbSet.Remove(entity);
        public void RemoveRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);
    }
}
