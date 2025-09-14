using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Data.UoW;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Areas.Admin.Services.Interfaces;

namespace VoxTics.Areas.Admin.Services.Implementations
{
    public class AdminShowtimesService : IAdminShowtimesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminShowtimesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<Showtime>> GetPagedShowtimesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? sortOrder = null,
            CancellationToken cancellationToken = default)
        {
            var query = _unitOfWork.Showtimes.Query();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var search = searchTerm.ToLower();
                query = query.Where(s => s.Movie.Title.ToLower().Contains(search) ||
                                         s.Cinema.Name.ToLower().Contains(search));
            }

            query = query.ApplySorting(sortOrder ?? "asc", s => s.StartTime);

            var totalCount = await _unitOfWork.Showtimes.CountAsync(cancellationToken: cancellationToken);
            var items = await query.Skip((pageIndex - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsyncSafe(cancellationToken);

            return items;
        }

        public async Task<Showtime?> GetShowtimeByIdAsync(int showtimeId, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Showtimes.GetByIdAsync(showtimeId, cancellationToken);
        }

        public async Task<bool> CreateShowtimeAsync(Showtime showtime, CancellationToken cancellationToken = default)
        {
            if (!ValidationHelpers.IsValidShowtime(showtime.StartTime))
                throw new ArgumentException("Invalid showtime date.");

            await _unitOfWork.Showtimes.AddAsync(showtime, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }

        public async Task<bool> UpdateShowtimeAsync(Showtime showtime, CancellationToken cancellationToken = default)
        {
            var existing = await _unitOfWork.Showtimes.GetByIdAsync(showtime.Id, cancellationToken);
            if (existing == null) return false;

            existing.StartTime = showtime.StartTime;
            existing.Duration = showtime.Duration;
            existing.Price = showtime.Price;
            existing.Status = showtime.Status;
            existing.Is3D = showtime.Is3D;
            existing.Language = showtime.Language;
            existing.ScreenType = showtime.ScreenType;

            await _unitOfWork.Showtimes.UpdateAsync(existing, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteShowtimeAsync(int showtimeId, CancellationToken cancellationToken = default)
        {
            var existing = await _unitOfWork.Showtimes.GetByIdAsync(showtimeId, cancellationToken);
            if (existing == null) return false;

            await _unitOfWork.Showtimes.RemoveAsync(existing, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }

        public async Task<int> GetAvailableSeatsAsync(int showtimeId, CancellationToken cancellationToken = default)
        {
            var showtime = await _unitOfWork.Showtimes.GetByIdAsync(showtimeId, cancellationToken);
            return showtime?.AvailableSeats ?? 0;
        }
    }
}
