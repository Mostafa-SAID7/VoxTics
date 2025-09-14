using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using VoxTics.Areas.Admin.Services.Interfaces;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Data.UoW;
using VoxTics.Helpers;

namespace VoxTics.Areas.Admin.Services.Implementations
{
    public class AdminCinemasService : IAdminCinemasService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AdminCinemasService> _logger;

        public AdminCinemasService(IUnitOfWork unitOfWork, ILogger<AdminCinemasService> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PaginatedList<Cinema>> GetPagedCinemasAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? sortOrder = null,
            CancellationToken cancellationToken = default)
        {
            var query = _unitOfWork.Cinemas.Query();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string sanitized = ValidationHelpers.SanitizeInput(searchTerm);
                query = query.Where(c => c.Name.Contains(sanitized) || c.City.Contains(sanitized));
            }

            query = query.ApplySorting(sortOrder ?? "Name", c => c.Name);

            return await query.ToPaginatedListAsync(pageIndex, pageSize, cancellationToken);
        }

        public async Task<Cinema> CreateCinemaAsync(Cinema cinema, CancellationToken cancellationToken = default)
        {
            if (cinema == null) throw new ArgumentNullException(nameof(cinema));
            cinema.Name = ValidationHelpers.SanitizeInput(cinema.Name);

            await _unitOfWork.Cinemas.AddAsync(cinema, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            _logger.LogInformation("Cinema created: {CinemaName}", cinema.Name);
            return cinema;
        }

        public async Task<bool> UpdateCinemaAsync(Cinema cinema, CancellationToken cancellationToken = default)
        {
            if (cinema == null) throw new ArgumentNullException(nameof(cinema));

            await _unitOfWork.Cinemas.UpdateAsync(cinema, cancellationToken);
            var result = await _unitOfWork.CommitAsync(cancellationToken);

            _logger.LogInformation("Cinema updated: {CinemaName}", cinema.Name);
            return result > 0;
        }

        public async Task<bool> DeleteCinemaAsync(int cinemaId, CancellationToken cancellationToken = default)
        {
            var cinema = await _unitOfWork.Cinemas.GetByIdAsync(cinemaId, cancellationToken);
            if (cinema == null) return false;

            // Check related showtimes or bookings before deletion
            if (await _unitOfWork.Showtimes.HasShowtimesForCinemaAsync(cinemaId, cancellationToken))
            {
                _logger.LogWarning("Cannot delete cinema {CinemaId} with active showtimes.", cinemaId);
                return false;
            }

            await _unitOfWork.Cinemas.RemoveAsync(cinema, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            _logger.LogInformation("Cinema deleted: {CinemaName}", cinema.Name);
            return true;
        }

        public async Task<Cinema?> GetCinemaByIdAsync(int cinemaId, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Cinemas.GetByIdAsync(cinemaId, cancellationToken);
        }

        public async Task<bool> ToggleCinemaStatusAsync(int cinemaId, bool isActive, CancellationToken cancellationToken = default)
        {
            var cinema = await _unitOfWork.Cinemas.GetByIdAsync(cinemaId, cancellationToken);
            if (cinema == null) return false;

            cinema.IsActive = isActive;
            await _unitOfWork.Cinemas.UpdateAsync(cinema, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            _logger.LogInformation("Cinema status toggled: {CinemaName}, Active: {Status}", cinema.Name, isActive);
            return true;
        }

        public async Task<bool> CinemaNameExistsAsync(string name, int? excludeId = null, CancellationToken cancellationToken = default)
        {
            name = ValidationHelpers.SanitizeInput(name);
            var cinemas = await _unitOfWork.Cinemas.FindAsync(
                c => c.Name == name && (!excludeId.HasValue || c.Id != excludeId),
                cancellationToken);

            return cinemas.Any();
        }
    }
}
