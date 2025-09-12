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
        IDashboardRepository AdminDashboard { get; }
        IHomeRepository Home { get; }
        Task<int> CompleteAsync();
    }

}
