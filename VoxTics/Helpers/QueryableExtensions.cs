using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace VoxTics.Helpers
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Returns a paginated list with optional search and sorting.
        /// </summary>
        public static PaginatedList<T> GetPaged<T>(
            this IQueryable<T> query,
            int pageIndex,
            int pageSize,
            string searchString = null,
            Func<IQueryable<T>, IQueryable<T>> searchFunc = null,
            string sortColumn = null,
            bool sortDescending = false)
        {
            if (!string.IsNullOrEmpty(searchString) && searchFunc != null)
            {
                query = searchFunc(query);
            }

            if (!string.IsNullOrEmpty(sortColumn))
            {
                var param = Expression.Parameter(typeof(T), "x");
                var property = Expression.PropertyOrField(param, sortColumn);
                var lambda = Expression.Lambda(property, param);

                string methodName = sortDescending ? "OrderByDescending" : "OrderBy";
                var result = Expression.Call(typeof(Queryable), methodName,
                    new Type[] { typeof(T), property.Type },
                    query.Expression, Expression.Quote(lambda));

                query = query.Provider.CreateQuery<T>(result);
            }

            int count = query.Count();
            var items = query.Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        /// <summary>
        /// Dynamically applies sorting based on a key selector.
        /// </summary>
        public static IQueryable<T> ApplySorting<T>(
         this IQueryable<T> query,
         string sortColumn,
         bool descending = false)
        {
            if (string.IsNullOrWhiteSpace(sortColumn)) return query;

            var param = Expression.Parameter(typeof(T), "x");
            var property = Expression.PropertyOrField(param, sortColumn);
            var lambda = Expression.Lambda(property, param);

            string methodName = descending ? "OrderByDescending" : "OrderBy";
            var result = Expression.Call(typeof(Queryable), methodName,
                new Type[] { typeof(T), property.Type },
                query.Expression, Expression.Quote(lambda));

            return query.Provider.CreateQuery<T>(result);
        }


        /// <summary>
        /// Converts IQueryable to a list asynchronously when possible (EF Core),
        /// otherwise falls back to synchronous enumeration.
        /// </summary>
        public static async Task<List<T>> ToListAsyncSafe<T>(
            this IQueryable<T> query,
            CancellationToken cancellationToken = default)
        {
            // If the provider is EF Core, use async. Otherwise, use sync to avoid runtime errors.
            if (query.Provider is IAsyncQueryProvider)
            {
                return await EntityFrameworkQueryableExtensions.ToListAsync(query, cancellationToken)
                                                               .ConfigureAwait(false);
            }

            return query.ToList();
        }
        /// <summary>
        /// Creates a paginated list from a queryable source.
        /// </summary>
        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(
            this IQueryable<T> query,
            int pageIndex,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            var count = await query.CountAsync(cancellationToken).ConfigureAwait(false);
            var items = await query.Skip((pageIndex - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsyncSafe(cancellationToken)
                                   .ConfigureAwait(false);

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
