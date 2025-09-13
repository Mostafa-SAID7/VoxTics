using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IBookingsRepository Bookings { get; }
        ICategoriesRepository Categories { get; }
        ICinemasRepository Cinemas { get; }
        IMoviesRepository Movies { get; }
        IShowtimesRepository Showtimes { get; }
        IDashboardRepository Dashboard { get; }
        IHomeRepository Home { get; }
        IBaseRepository<UserOTP> UserOTP { get; }
        Task<int> CompleteAsync();
        Task SaveAsync();
    }

}
