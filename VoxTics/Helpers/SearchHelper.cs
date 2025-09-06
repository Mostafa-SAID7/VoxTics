using System.Linq;
using System.Reflection;

namespace VoxTics.Helpers
{
    public static class SearchHelper
    {
        /// <summary>
        /// Searches all string properties of the entity that contain the search term.
        /// </summary>
        public static IQueryable<T> SearchAllStrings<T>(this IQueryable<T> source, string searchTerm)
        {
            var stringProps = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(string));

            if (!stringProps.Any() || string.IsNullOrEmpty(searchTerm))
                return source;

            var query = source.Where(x =>
                stringProps.Any(p => ((string?)p.GetValue(x)) != null &&
                                     ((string?)p.GetValue(x))!.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)));

            return query;
        }
    }
}
