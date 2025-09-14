using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Data.UoW;
using VoxTics.Helpers;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class CinemaService : ICinemaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CinemaService> _logger;

        public CinemaService(IUnitOfWork unitOfWork, ILogger<CinemaService> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Cinema>> GetActiveCinemasAsync(CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Cinemas
                .FindAsync(c => c.IsActive, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<PaginatedList<Cinema>> GetPagedCinemasAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? sortOrder = null,
            CancellationToken cancellationToken = default)
        {
            var query = _unitOfWork.Cinemas.Query().Where(c => c.IsActive);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string sanitized = ValidationHelpers.SanitizeInput(searchTerm);
                query = query.Where(c => c.Name.Contains(sanitized) || c.City.Contains(sanitized));
            }

            query = query.ApplySorting(sortOrder ?? "Name", c => c.Name);

            return await query.ToPaginatedListAsync(pageIndex, pageSize, cancellationToken);
        }

        public async Task<Cinema?> GetCinemaDetailsAsync(int cinemaId, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Cinemas.GetByIdAsync(cinemaId, cancellationToken);
        }

        public async Task<IEnumerable<Showtime>> GetUpcomingShowtimesAsync(
            int cinemaId,
            int daysAhead = 7,
            CancellationToken cancellationToken = default)
        {
            var startDate = DateTime.UtcNow;
            var endDate = startDate.AddDays(daysAhead);

            return await _unitOfWork.Showtimes.GetByCinemaAndDateRangeAsync(cinemaId, startDate, endDate, cancellationToken);
        }
    }
}
