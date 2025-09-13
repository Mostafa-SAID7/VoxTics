using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Repositories;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Data.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MovieDbContext _context;
        private bool _disposed ;
        private IApplicationUsersRepository? _applicationUsers;
        private IBaseRepository<UserOTP>? _userOTP;

        // Non-nullable properties must be initialized
        public IBookingsRepository Bookings { get; }
        public ICategoriesRepository Categories { get; }
        public ICinemasRepository Cinemas { get; }
        public IMoviesRepository Movies { get; }
        public IShowtimesRepository Showtimes { get; }
        public IDashboardRepository Dashboard { get; }
        public IApplicationUsersRepository ApplicationUsers { get; }
        public IHomeRepository Home { get; }

        public UnitOfWork(
            MovieDbContext context,
            IBookingsRepository bookings,
            ICategoriesRepository categories,
            ICinemasRepository cinemas,
            IMoviesRepository movies,
            IShowtimesRepository showtimes,
            IApplicationUsersRepository applicationUsers,
            IDashboardRepository adminDashboard,
            IHomeRepository home)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Bookings = bookings ?? throw new ArgumentNullException(nameof(bookings));
            Categories = categories ?? throw new ArgumentNullException(nameof(categories));
            Cinemas = cinemas ?? throw new ArgumentNullException(nameof(cinemas));
            Movies = movies ?? throw new ArgumentNullException(nameof(movies));
            Showtimes = showtimes ?? throw new ArgumentNullException(nameof(showtimes));
            Dashboard = adminDashboard ?? throw new ArgumentNullException(nameof(adminDashboard));
            Home = home ?? throw new ArgumentNullException(nameof(home));
        }

        public IBaseRepository<UserOTP> UserOTPs => _userOTP ??= new BaseRepository<UserOTP>(_context);
        public IApplicationUsersRepository ApplicationUser
          => _applicationUsers ??= new ApplicationUsersRepository(_context);


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        // Proper IDisposable pattern
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
