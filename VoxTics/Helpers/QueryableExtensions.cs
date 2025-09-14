using System.Linq.Expressions;

namespace VoxTics.Helpers
{
    public static class QueryableExtensions
    {
        public static PaginatedList<T> GetPaged<T>(
            this IQueryable<T> query,
            int pageIndex,
            int pageSize,
            string searchString = null,
            Func<IQueryable<T>, IQueryable<T>> searchFunc = null,
            string sortColumn = null,
            bool sortDescending = false)
        {
            // 1. Apply Search
            if (!string.IsNullOrEmpty(searchString) && searchFunc != null)
            {
                query = searchFunc(query);
            }

            // 2. Apply Sorting
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

            // 3. Pagination
            int count = query.Count();
            var items = query.Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
