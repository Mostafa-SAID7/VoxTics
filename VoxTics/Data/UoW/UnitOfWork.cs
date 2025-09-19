using System;
using System.Threading.Tasks;
using VoxTics.Data;
using VoxTics.Data.UoW;
using VoxTics.Repositories.IRepositories;
using VoxTics.Areas.Identity.Repositories.IRepositories;
using VoxTics.Areas.Admin.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDbContext _context;

        // General
        public IBookingRepository Bookings { get; }
        public ICategoriesRepository Categories { get; }
        public ICinemasRepository Cinemas { get; }
        public IMoviesRepository Movies { get; }
        public IShowtimesRepository Showtimes { get; }
        public IHomeRepository Home { get; }

        // Identity
        public IApplicationUsersRepository ApplicationUsers { get; }

        // Admin
        public IAdminBookingsRepository AdminBookings { get; }
        public IAdminCategoriesRepository AdminCategories { get; }
        public IAdminCinemasRepository AdminCinemas { get; }
        public IAdminMoviesRepository AdminMovies { get; }
        public IAdminShowtimesRepository AdminShowtimes { get; }
        public IDashboardRepository Dashboard { get; }

        public UnitOfWork(
            MovieDbContext context,
            IBookingRepository bookings,
            ICategoriesRepository categories,
            ICinemasRepository cinemas,
            IMoviesRepository movies,
            IShowtimesRepository showtimes,
            IHomeRepository home,
            IApplicationUsersRepository appUsers,
            IAdminBookingsRepository adminBookings,
            IAdminCategoriesRepository adminCategories,
            IAdminCinemasRepository adminCinemas,
            IAdminMoviesRepository adminMovies,
            IAdminShowtimesRepository adminShowtimes,
            IDashboardRepository dashboard)

        {
            _context = context;

            Bookings = bookings;
            Categories = categories;
            Cinemas = cinemas;
            Movies = movies;
            Showtimes = showtimes;
            Home = home;

            ApplicationUsers = appUsers;

            AdminBookings = adminBookings;
            AdminCategories = adminCategories;
            AdminCinemas = adminCinemas;
            AdminMovies = adminMovies;
            AdminShowtimes = adminShowtimes;
            Dashboard = dashboard;
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
        public async Task CommitAsync<T>(T entity)
        {
            _context.Update(entity); 
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        #region Dispose
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) _context.Dispose();
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public async ValueTask DisposeAsync()
        {
            if (!_disposed)
            {
                await _context.DisposeAsync();
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }
        #endregion
    }
}
