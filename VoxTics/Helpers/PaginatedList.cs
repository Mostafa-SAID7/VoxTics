using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoxTics.Helpers
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }     // 1-based page index
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        public List<T> Items { get; private set; } = new List<T>();
        public Dictionary<string, object>? RouteValues { get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex <= 0 ? 1 : pageIndex;
            PageSize = pageSize <= 0 ? 10 : pageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            Items = items ?? new List<T>();
            this.AddRange(Items);
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public int StartItem => TotalCount == 0 ? 0 : ((PageIndex - 1) * PageSize) + 1;
        public int EndItem => Math.Min(PageIndex * PageSize, TotalCount);

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        public static PaginatedList<T> CreateFromList(List<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count;
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        public List<int> GetPageNumbers(int maxPages = 10)
        {
            var pages = new List<int>();
            if (TotalPages == 0) return pages;

            var half = maxPages / 2;
            var start = Math.Max(1, PageIndex - half);
            var end = Math.Min(TotalPages, start + maxPages - 1);

            if (end - start + 1 < maxPages)
                start = Math.Max(1, end - maxPages + 1);

            for (int i = start; i <= end; i++)
                pages.Add(i);

            return pages;
        }
    }
}
