using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using VoxTics.Models.Enums;

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

        //public static IQueryable<T> ApplySearch<T>(
        //    this IQueryable<T> query,
        //    FilterBase<Enum> filter,
        //    params Func<T, string?>[] properties)
        //{
        //    if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
        //    {
        //        var term = filter.SearchTerm.ToLower();
        //        query = query.Where(item =>
        //            properties.Any(prop => (prop(item) ?? string.Empty).ToLower().Contains(term))
        //        );
        //    }

        //    return query;
        //}


    }
    //public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, FilterBase<Enum> filter)
    //{
    //    var skip = (filter.PageIndex - 1) * filter.PageSize;
    //    return query.Skip(skip).Take(filter.PageSize);
    //}
}
}
//using System;
//using System.Linq;
//using System.Linq.Expressions;
//using VoxTics.Helpers.Filters;
//using VoxTics.Models.Enums;

//namespace VoxTics.Helpers
//{
//    public static class SearchHelper
//    {
//        /// <summary>
//        /// Apply search term on multiple string properties
//        /// </summary>
//        public static IQueryable<T> ApplySearch<T>(
//            this IQueryable<T> query,
//            FilterBase<Enum> filter,
//            params Expression<Func<T, string?>>[] properties)
//        {
//            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
//            {
//                var term = filter.SearchTerm.ToLower();
//                foreach (var prop in properties)
//                {
//                    query = query.Where(item =>
//                        properties.Any(p =>
//                            EF.Property<string>(item!, ((MemberExpression)p.Body).Member.Name)
//                                .ToLower()
//                                .Contains(term)
//                        )
//                    );
//                }
//            }

//            return query;
//        }

//        /// <summary>
//        /// Apply sorting based on SortBy & SortOrder
//        /// </summary>
//        public static IQueryable<T> ApplySorting<T, TSortBy>(
//            this IQueryable<T> query,
//            FilterBase<TSortBy> filter,
//            Func<TSortBy, Expression<Func<T, object>>> sortMap
//        ) where TSortBy : Enum
//        {
//            if (filter.SortBy == null) return query;

//            var sortExpr = sortMap(filter.SortBy);
//            return filter.SortOrder == SortOrder.Desc
//                ? query.OrderByDescending(sortExpr)
//                : query.OrderBy(sortExpr);
//        }

//        /// <summary>
//        /// Apply pagination
//        /// </summary>
//        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, FilterBase<Enum> filter)
//        {
//            var skip = (filter.PageIndex - 1) * filter.PageSize;
//            return query.Skip(skip).Take(filter.PageSize);
//        }
//    }
//}
