using System;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Repositories.IRepositories;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Data.UoW
{
    /// <summary>
    /// Defines a contract for the Unit of Work pattern to manage
    /// transactions and repository access within VoxTics.
    /// </summary>
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        #region Repository Accessors

        /// <summary>Manages booking-related operations.</summary>
        IBookingsRepository Bookings { get; }

        /// <summary>Manages category-related operations.</summary>
        ICategoriesRepository Categories { get; }

        /// <summary>Manages cinema-related operations.</summary>
        ICinemasRepository Cinemas { get; }

        /// <summary>Manages movie-related operations.</summary>
        IMoviesRepository Movies { get; }

        /// <summary>Manages showtime-related operations.</summary>
        IShowtimesRepository Showtimes { get; }

        /// <summary>Manages dashboard-specific operations.</summary>
        IDashboardRepository Dashboard { get; }

        /// <summary>Manages home page-specific operations.</summary>
        IHomeRepository Home { get; }

        /// <summary>Manages application user operations.</summary>
        IApplicationUsersRepository ApplicationUsers { get; }

        /// <summary>Manages user OTP operations via a generic base repository.</summary>
        IBaseRepository<UserOTP> UserOTPs { get; }

        /// <summary>
        /// Provides a generic repository for any entity type.
        /// Useful for avoiding repetitive repository properties.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <returns>A repository for the specified entity.</returns>
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        #endregion

        #region Transaction Management

        /// <summary>
        /// Saves all changes made in the current transaction.
        /// </summary>
        /// <param name="cancellationToken">Optional token for cancellation.</param>
        /// <returns>The number of state entries written to the database.</returns>
        Task<int> CommitAsync(CancellationToken cancellationToken = default);

        #endregion
    }
}
