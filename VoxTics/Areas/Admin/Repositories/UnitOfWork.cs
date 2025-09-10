using Microsoft.EntityFrameworkCore.Storage;
using System;
using VoxTics.Areas.Admin.Repositories.IRepositories;

namespace VoxTics.Areas.Admin.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDbContext _ctx;
        private IMovieRepository? _movies;
        private IBaseRepository<Actor>? _actors;
        private IBaseRepository<Category>? _categories;
        private IBaseRepository<MovieImg>? _movieImgs;

        public UnitOfWork(MovieDbContext ctx)
        {
            _ctx = ctx;
        }

        public IMovieRepository Movies => _movies ??= new MovieRepository(_ctx);
        public IBaseRepository<Actor> Actors => _actors ??= new BaseRepository<Actor>(_ctx);
        public IBaseRepository<Category> Categories => _categories ??= new BaseRepository<Category>(_ctx);
        public IBaseRepository<MovieImg> MovieImgs => _movieImgs ??= new BaseRepository<MovieImg>(_ctx);

        public async Task<int> SaveAsync()
        {
            return await _ctx.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _ctx.Database.BeginTransactionAsync();
        }

        public void Dispose()
        {
            _ctx?.Dispose();
        }
    }
}
