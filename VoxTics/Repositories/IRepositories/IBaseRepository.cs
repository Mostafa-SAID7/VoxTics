using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace VoxTics.Repositories.IRepositories
{
    /// <summary>
    /// Generic repository interface for CRUD operations and advanced querying.
    /// Works in conjunction with IUnitOfWork for transaction management.
    /// </summary>
    public interface IBaseRepository<T> where T : class
    {
        #region Querying

        /// <summary>
        /// Returns an IQueryable for building LINQ queries (supports filters, sorting, includes, pagination).
        /// </summary>
        IQueryable<T> Query();

        /// <summary>
        /// Gets all entities without tracking (read-only performance).
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds entities matching a specific condition.
        /// </summary>
        Task<IEnumerable<T>> FindAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets an entity by its primary key (int).
        /// </summary>
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the first entity matching a condition or null.
        /// </summary>
        Task<T?> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether any entity matches a condition.
        /// </summary>
        Task<bool> AnyAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Counts all entities or those matching a condition.
        /// </summary>
        Task<int> CountAsync(
            Expression<Func<T, bool>>? predicate = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds an entity by composite keys or single key.
        /// </summary>
        Task<T?> FindByKeysAsync(
            object[] keys,
            CancellationToken cancellationToken = default);

        #endregion

        #region Commands (CRUD)

        /// <summary>
        /// Adds a new entity (changes saved via IUnitOfWork.CommitAsync).
        /// </summary>
        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds multiple new entities.
        /// </summary>
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates multiple entities.
        /// </summary>
        Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes an entity.
        /// </summary>
        Task RemoveAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes multiple entities.
        /// </summary>
        Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        #endregion
    }
}
