using System;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Repositories;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Data.UoW
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        // General
        IBookingRepository Bookings { get; }
        ICategoriesRepository Categories { get; }
        ICinemasRepository Cinemas { get; }
        IMoviesRepository Movies { get; }
        IShowtimesRepository Showtimes { get; }
        IHomeRepository Home { get; }

        // Identity

        // Admin
        IAdminBookingsRepository AdminBookings { get; }
        IAdminCategoriesRepository AdminCategories { get; }
        IAdminCinemasRepository AdminCinemas { get; }
        IAdminMoviesRepository AdminMovies { get; }
        IAdminShowtimesRepository AdminShowtimes { get; }
        IDashboardRepository Dashboard { get; }

        Task CommitAsync<T>(T entity);
        Task CommitAsync();
    }
}
