using System.Linq;

namespace VoxTics.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>Return an IQueryable you can further filter. includeProperties is comma separated (e.g. "MovieCategories.Category")</summary>
        IQueryable<T> Query(string? includeProperties = null, bool asNoTracking = true);

        Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null);
        Task<T?> GetAsync(object id, string? includeProperties = null);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(object id);
    }
}
