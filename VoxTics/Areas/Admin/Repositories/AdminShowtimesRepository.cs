using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Data;

namespace VoxTics.Areas.Admin.Repositories
{
    public class AdminShowtimesRepository : IAdminShowtimesRepository
    {
        private readonly MovieDbContext _context;
        private readonly DbSet<Showtime> _dbSet;

        public AdminShowtimesRepository(MovieDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Showtime>();
        }

        #region IBaseRepository Implementation

        public IQueryable<Showtime> Query() => _dbSet.AsQueryable();

        public async Task<IEnumerable<Showtime>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbSet.ToListAsync(cancellationToken);

        public async Task<Showtime?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => await _dbSet.FindAsync(new object[] { id }, cancellationToken).ConfigureAwait(false);

        public async Task<Showtime?> GetFirstOrDefaultAsync(Expression<Func<Showtime, bool>> predicate, CancellationToken cancellationToken = default)
            => await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);

        public async Task<IEnumerable<Showtime>> FindAsync(Expression<Func<Showtime, bool>> predicate, CancellationToken cancellationToken = default)
            => await _dbSet.Where(predicate).ToListAsync(cancellationToken);

        public async Task<bool> AnyAsync(Expression<Func<Showtime, bool>> predicate, CancellationToken cancellationToken = default)
            => await _dbSet.AnyAsync(predicate, cancellationToken).ConfigureAwait(false);

        public async Task<int> CountAsync(Expression<Func<Showtime, bool>>? predicate = null, CancellationToken cancellationToken = default)
            => predicate == null ? await _dbSet.CountAsync(cancellationToken)
                                 : await _dbSet.CountAsync(predicate, cancellationToken);

        public async Task<Showtime?> FindByKeysAsync(object[] keys, CancellationToken cancellationToken = default)
            => await _dbSet.FindAsync(keys, cancellationToken).ConfigureAwait(false);

        public async Task AddAsync(Showtime entity, CancellationToken cancellationToken = default)
            => await _dbSet.AddAsync(entity, cancellationToken);

        public Task AddRangeAsync(IEnumerable<Showtime> entities, CancellationToken cancellationToken = default)
            => _dbSet.AddRangeAsync(entities, cancellationToken);

        public Task UpdateAsync(Showtime entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public Task UpdateRangeAsync(IEnumerable<Showtime> entities, CancellationToken cancellationToken = default)
        {
            _dbSet.UpdateRange(entities);
            return Task.CompletedTask;
        }

        public Task RemoveAsync(Showtime entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public Task RemoveRangeAsync(IEnumerable<Showtime> entities, CancellationToken cancellationToken = default)
        {
            _dbSet.RemoveRange(entities);
            return Task.CompletedTask;
        }

        #endregion

        #region IAdminShowtimesRepository Implementation

        public async Task<IEnumerable<Showtime>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default)
            => await _dbSet
                .Include(st => st.Movie)
                .Include(st => st.Cinema)
                .Include(st => st.Hall)
                .ToListAsync(cancellationToken);

        public async Task<Showtime?> GetByIdWithDetailsAsync(int showtimeId, CancellationToken cancellationToken = default)
            => await _dbSet
                .Include(st => st.Movie)
                .Include(st => st.Cinema)
                .Include(st => st.Hall)
                .FirstOrDefaultAsync(st => st.Id == showtimeId, cancellationToken);

        public async Task<bool> IsOverlappingAsync(int hallId, DateTime startTime, int duration, int? excludeShowtimeId = null, CancellationToken cancellationToken = default)
        {
            var endTime = startTime.AddMinutes(duration);
            var query = _dbSet.Where(st => st.HallId == hallId);

            if (excludeShowtimeId.HasValue)
                query = query.Where(st => st.Id != excludeShowtimeId.Value);

            return await query.AnyAsync(st => startTime < st.StartTime.AddMinutes(st.Duration) && endTime > st.StartTime, cancellationToken);
        }

        public async Task<IEnumerable<Showtime>> GetUpcomingShowtimesAsync(int count = 10, CancellationToken cancellationToken = default)
            => await _dbSet
                .Where(st => st.StartTime >= DateTime.Now)
                .OrderBy(st => st.StartTime)
                .Take(count)
                .Include(st => st.Movie)
                .Include(st => st.Cinema)
                .Include(st => st.Hall)
                .ToListAsync(cancellationToken);

        public async Task<IEnumerable<Showtime>> GetByMovieAsync(int movieId, CancellationToken cancellationToken = default)
            => await _dbSet
                .Where(st => st.MovieId == movieId)
                .Include(st => st.Cinema)
                .Include(st => st.Hall)
                .ToListAsync(cancellationToken);

        public async Task<IEnumerable<Showtime>> GetByCinemaAsync(int cinemaId, CancellationToken cancellationToken = default)
            => await _dbSet
                .Where(st => st.CinemaId == cinemaId)
                .Include(st => st.Movie)
                .Include(st => st.Hall)
                .ToListAsync(cancellationToken);

        public async Task UpdateStatusAsync(int showtimeId, ShowtimeStatus status, CancellationToken cancellationToken = default)
        {
            var showtime = await GetByIdAsync(showtimeId, cancellationToken);
            if (showtime == null) return;

            showtime.Status = status;
            _dbSet.Update(showtime);
        }

        public async Task UpdatePriceAsync(int showtimeId, decimal newPrice, CancellationToken cancellationToken = default)
        {
            var showtime = await GetByIdAsync(showtimeId, cancellationToken);
            if (showtime == null) return;

            showtime.Price = newPrice;
            _dbSet.Update(showtime);
        }

        public async Task DeleteShowtimeAsync(int showtimeId, bool removeBookings = true, CancellationToken cancellationToken = default)
        {
            var showtime = await _dbSet
                .Include(st => st.Bookings)
                .FirstOrDefaultAsync(st => st.Id == showtimeId, cancellationToken);

            if (showtime == null) return;

            if (removeBookings)
                _context.Set<Booking>().RemoveRange(showtime.Bookings);

            _dbSet.Remove(showtime);
        }

        public async Task<IEnumerable<Showtime>> FilterShowtimesAsync(
            DateTime? from = null,
            DateTime? to = null,
            int? movieId = null,
            int? cinemaId = null,
            int? hallId = null,
            ShowtimeStatus? status = null,
            CancellationToken cancellationToken = default)
        {
            var query = _dbSet.AsQueryable();

            if (from.HasValue) query = query.Where(st => st.StartTime >= from.Value);
            if (to.HasValue) query = query.Where(st => st.StartTime <= to.Value);
            if (movieId.HasValue) query = query.Where(st => st.MovieId == movieId.Value);
            if (cinemaId.HasValue) query = query.Where(st => st.CinemaId == cinemaId.Value);
            if (hallId.HasValue) query = query.Where(st => st.HallId == hallId.Value);
            if (status.HasValue) query = query.Where(st => st.Status == status.Value);

            return await query
                .Include(st => st.Movie)
                .Include(st => st.Cinema)
                .Include(st => st.Hall)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Showtime>> SearchShowtimesAsync(string queryStr, CancellationToken cancellationToken = default)
            => await _dbSet
                .Include(st => st.Movie)
                .Include(st => st.Cinema)
                .Include(st => st.Hall)
                .Where(st =>
                    st.Movie.Title.Contains(queryStr) ||
                    st.Cinema.Name.Contains(queryStr) ||
                    st.Hall.Name.Contains(queryStr))
                .ToListAsync(cancellationToken).ConfigureAwait(false);

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Showtime>> GetAsync(Func<Showtime, bool> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
