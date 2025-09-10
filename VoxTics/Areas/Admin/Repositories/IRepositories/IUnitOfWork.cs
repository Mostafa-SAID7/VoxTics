using Microsoft.EntityFrameworkCore.Storage;

namespace VoxTics.Areas.Admin.Repositories.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository Movies { get; }
        IBaseRepository<Actor> Actors { get; }
        IBaseRepository<Category> Categories { get; }
        IBaseRepository<MovieImg> MovieImgs { get; }

        Task<int> SaveAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
