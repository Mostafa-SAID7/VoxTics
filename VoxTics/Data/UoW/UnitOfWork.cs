using System;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Data;
using VoxTics.Repositories.IRepositories;

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

        // Admin
        public IAdminBookingsRepository AdminBookings { get; }
        public IAdminCategoriesRepository AdminCategories { get; }
        public IAdminCinemasRepository AdminCinemas { get; }
        public IAdminMoviesRepository AdminMovies { get; }
        public IAdminShowtimesRepository AdminShowtimes { get; }
        public IDashboardRepository Dashboard { get; }

        // NOTE: We _do not_ new-up repositories here. Repositories are injected by DI.
        public UnitOfWork(
            MovieDbContext context,
            IBookingRepository bookings,
            ICategoriesRepository categories,
            ICinemasRepository cinemas,
            IMoviesRepository movies,
            IShowtimesRepository showtimes,
            IHomeRepository home,
            IAdminBookingsRepository adminBookings,
            IAdminCategoriesRepository adminCategories,
            IAdminCinemasRepository adminCinemas,
            IAdminMoviesRepository adminMovies,
            IAdminShowtimesRepository adminShowtimes,
            IDashboardRepository dashboard)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Bookings = bookings ?? throw new ArgumentNullException(nameof(bookings));
            Categories = categories ?? throw new ArgumentNullException(nameof(categories));
            Cinemas = cinemas ?? throw new ArgumentNullException(nameof(cinemas));
            Movies = movies ?? throw new ArgumentNullException(nameof(movies));
            Showtimes = showtimes ?? throw new ArgumentNullException(nameof(showtimes));
            Home = home ?? throw new ArgumentNullException(nameof(home));

            AdminBookings = adminBookings ?? throw new ArgumentNullException(nameof(adminBookings));
            AdminCategories = adminCategories ?? throw new ArgumentNullException(nameof(adminCategories));
            AdminCinemas = adminCinemas ?? throw new ArgumentNullException(nameof(adminCinemas));
            AdminMovies = adminMovies ?? throw new ArgumentNullException(nameof(adminMovies));
            AdminShowtimes = adminShowtimes ?? throw new ArgumentNullException(nameof(adminShowtimes));
            Dashboard = dashboard ?? throw new ArgumentNullException(nameof(dashboard));
        }

        public async Task CommitAsync() => await _context.SaveChangesAsync().ConfigureAwait(false);

        public async Task CommitAsync<T>(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Update(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        #region Dispose
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) _context?.Dispose();
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
                if (_context != null) await _context.DisposeAsync().ConfigureAwait(false);
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }
        #endregion
    }
}
