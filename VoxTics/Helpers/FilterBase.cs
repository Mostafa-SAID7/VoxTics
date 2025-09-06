using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace VoxTics.Helpers
{
    /// <summary>
    /// Generic filter base class to apply common filtering logic on any entity.
    /// Supports Id, Search term, Date range, and custom search function.
    /// </summary>
    public class FilterBase<T>
    {
        private static readonly ConcurrentDictionary<string, PropertyInfo?> PropertyCache = new();

        public int? Id { get; set; }
        public string? Search { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string DatePropertyName { get; set; } = "CreatedAt"; // default property for date filtering

        public IQueryable<T> Apply(IQueryable<T> query, Func<IQueryable<T>, string?, IQueryable<T>>? searchFunc = null)
        {
            // Filter by Id
            if (Id.HasValue)
            {
                var idProp = GetPropertyCached("Id");
                if (idProp != null)
                    query = query.Where(x => (int)idProp.GetValue(x)! == Id.Value);
            }

            // Filter by DatePropertyName
            if (FromDate.HasValue || ToDate.HasValue)
            {
                var dateProp = GetPropertyCached(DatePropertyName);
                if (dateProp != null && dateProp.PropertyType == typeof(DateTime))
                {
                    if (FromDate.HasValue)
                        query = query.Where(x => (DateTime)dateProp.GetValue(x)! >= FromDate.Value);
                    if (ToDate.HasValue)
                        query = query.Where(x => (DateTime)dateProp.GetValue(x)! <= ToDate.Value);
                }
            }

            // Apply custom search or default string search
            if (!string.IsNullOrEmpty(Search))
            {
                query = searchFunc != null
                    ? searchFunc(query, Search)
                    : DefaultStringSearch(query, Search);
            }

            return query;
        }

        // Default search: search all string properties
        private IQueryable<T> DefaultStringSearch(IQueryable<T> query, string searchTerm)
        {
            var stringProps = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                       .Where(p => p.PropertyType == typeof(string));

            foreach (var prop in stringProps)
            {
                query = query.Where(x =>
                    ((string?)prop.GetValue(x)) != null &&
                    ((string?)prop.GetValue(x))!.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                );
            }

            return query;
        }

        // Property caching to reduce reflection overhead
        private static PropertyInfo? GetPropertyCached(string propertyName)
        {
            return PropertyCache.GetOrAdd(propertyName, name =>
                typeof(T).GetProperty(name, BindingFlags.Public | BindingFlags.Instance));
        }
    }
}
