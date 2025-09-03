using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VoxTics.Helpers
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        /// <summary>Concrete items (same as the list content) — handy when you want a List{T} specifically.</summary>
        public List<T> Items { get; private set; }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public PaginatedList()
        {
            Items = new List<T>();
        }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            Items = items ?? new List<T>();
            TotalCount = count;
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            // populate base list for enumeration / LINQ
            AddRange(Items);
        }

        public static PaginatedList<T> Create(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        // create from repository result (items & count)
        public static PaginatedList<T> CreateFrom(IEnumerable<T> items, int totalCount, int pageIndex, int pageSize)
        {
            return new PaginatedList<T>(items.ToList(), totalCount, pageIndex, pageSize);
        }
    }
}
