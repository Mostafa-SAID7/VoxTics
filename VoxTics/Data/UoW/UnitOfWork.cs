using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Repositories;
using VoxTics.Areas.Identity.Repositories.IRepositories;
using VoxTics.Repositories;
using VoxTics.Repositories.IRepositories;
using VoxTics.Repositories.UserArea;

namespace VoxTics.Data.UoW
{
    /// <summary>
    /// Concrete implementation of IUnitOfWork using MovieDbContext.
    /// Handles repository access and transaction management.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDbContext _context;
        private readonly ILogger<UnitOfWork> _logger;
        private readonly IMemoryCache? _cache;

        private IBookingsRepository? _bookings;
        private ICategoriesRepository? _categories;
        private ICinemasRepository? _cinemas;
        private IMoviesRepository? _movies;
        private IShowtimesRepository? _showtimes;
        private IDashboardRepository? _dashboard;
        private IHomeRepository? _home;
        private IApplicationUsersRepository? _applicationUsers;
        private IBaseRepository<UserOTP>? _userOtps;

        private IAdminBookingsRepository? _adminBookings;
        private IAdminMoviesRepository? _adminMovies;
        private IAdminCategoriesRepository? _adminCategories;
        private IAdminCinemasRepository? _adminCinemas;
        private bool _disposed;

        public UnitOfWork(MovieDbContext context, ILogger<UnitOfWork> logger, IMemoryCache? cache = null)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cache = cache;
        }

        #region Repository Accessors
        public IActorsRepository Actors { get; }
  
        public IBookingsRepository Bookings => _bookings ??= new BookingsRepository(_context);
        public ICategoriesRepository Categories => _categories ??= new CategoriesRepository(_context);
        public ICinemasRepository Cinemas => _cinemas ??= new CinemasRepository(_context);
        public IMoviesRepository Movies => _movies ??= new MoviesRepository(_context);
        public IShowtimesRepository Showtimes => _showtimes ??= new ShowtimesRepository(_context);
        public IDashboardRepository Dashboard => _dashboard ??= new DashboardRepository(_context);
        public IHomeRepository Home => _home ??= new HomeRepository(_context);
        public IApplicationUsersRepository ApplicationUsers => _applicationUsers ??= new ApplicationUsersRepository(_context);
        public IBaseRepository<UserOTP> UserOTPs => _userOtps ??= new BaseRepository<UserOTP>(_context);

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class =>
            new BaseRepository<TEntity>(_context);

        #endregion

        #region Transaction Management
        // -------- Admin Repos --------
        public IAdminCinemasRepository AdminCinemas =>
            _adminCinemas ??= new AdminCinemasRepository(_context, _logger);
        public IAdminBookingsRepository AdminBookings =>
    _adminBookings ??= new AdminBookingsRepository(_context);
        public IAdminCategoriesRepository AdminCategories =>
            _adminCategories ??= new AdminCategoriesRepository(_context);
        public IAdminMoviesRepository AdminMovies =>
            _adminMovies ??= new AdminMoviesRepository(_context);
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                var result = await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
                _logger.LogInformation("Transaction committed successfully with {Count} changes.", result);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Transaction failed. Rolling back...");
                await transaction.RollbackAsync(cancellationToken).ConfigureAwait(false);
                throw;
            }
        }

        #endregion

        #region Disposal

        /// <summary>
        /// Core dispose logic.
        /// Dispose(true): Releases managed and unmanaged resources.
        /// Dispose(false): Releases unmanaged resources only.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Managed resources
                    _context.Dispose();
                }
                // Unmanaged resources cleanup (if any) here
                _disposed = true;
            }
        }

        /// <summary>
        /// Public Dispose: cleans managed/unmanaged resources and suppresses finalization.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Async core dispose for IAsyncDisposable.
        /// </summary>
        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (_context != null)
            {
                await _context.DisposeAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Public async dispose: calls DisposeAsyncCore and unmanaged cleanup, suppresses finalization.
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            if (!_disposed)
            {
                await DisposeAsyncCore().ConfigureAwait(false);
                Dispose(false); // Unmanaged cleanup
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        #endregion
    }
}
