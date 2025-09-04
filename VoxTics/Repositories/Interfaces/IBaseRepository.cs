using System.Linq.Expressions;

namespace VoxTics.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Query(string? includeProperties = null, bool asNoTracking = true);

        Task<T?> GetByIdAsync(object id, string? includeProperties = null);

        Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, string? includeProperties = null);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(object id);
    }
}
