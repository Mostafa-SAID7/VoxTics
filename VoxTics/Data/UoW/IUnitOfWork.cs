using System;
using System.Threading.Tasks;
using VoxTics.Repositories.IRepositories;
using VoxTics.Areas.Identity.Repositories.IRepositories;
using VoxTics.Areas.Admin.Repositories.IRepositories;

namespace VoxTics.Data.UoW
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        // General
        IBookingsRepository Bookings { get; }
        ICategoriesRepository Categories { get; }
        ICinemasRepository Cinemas { get; }
        IMoviesRepository Movies { get; }
        IShowtimesRepository Showtimes { get; }
        IHomeRepository Home { get; }

        // Identity
        IApplicationUsersRepository ApplicationUsers { get; }

        // Admin
        IAdminBookingsRepository AdminBookings { get; }
        IAdminCategoriesRepository AdminCategories { get; }
        IAdminCinemasRepository AdminCinemas { get; }
        IAdminMoviesRepository AdminMovies { get; }
        IAdminShowtimesRepository AdminShowtimes { get; }
        IDashboardRepository Dashboard { get; }

        Task<int> CompleteAsync();
        Task CommitAsync<T>(T entity);
    }
}
