using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Data;
using VoxTics.Models.Entities;

namespace VoxTics.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll(bool asNoTracking = true);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
