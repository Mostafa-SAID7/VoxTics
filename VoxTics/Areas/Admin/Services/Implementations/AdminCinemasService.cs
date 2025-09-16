using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;
using VoxTics.Data.UoW;

namespace VoxTics.Services.Implementations
{
    /// <summary>
    /// Service for admin-side cinema management.
    /// Handles CRUD, validation, status, stats, and audit info.
    /// </summary>
    public class AdminCinemaService : IAdminCinemaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdminCinemasRepository _cinemaRepository;

        public AdminCinemaService(IUnitOfWork unitOfWork, IAdminCinemasRepository cinemaRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _cinemaRepository = cinemaRepository ?? throw new ArgumentNullException(nameof(cinemaRepository));
        }

        #region Paging & Listing

        public async Task<(IEnumerable<Cinema> Cinemas, int TotalCount)> GetPagedCinemasAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? city = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default)
        {
            return await _cinemaRepository.GetPagedCinemasAsync(pageIndex, pageSize, searchTerm, city, isActive, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region CRUD Operations

        public async Task<Cinema?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _cinemaRepository.GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
        }

        public async Task<List<string>> AddCinemaAsync(Cinema cinema, CancellationToken cancellationToken = default)
        {
            var errors = ValidateCinema(cinema);
            if (errors.Any()) return errors;

            await _cinemaRepository.AddAsync(cinema, cancellationToken).ConfigureAwait(false);
            await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
            return errors;
        }

        public async Task<List<string>> UpdateCinemaAsync(Cinema cinema, CancellationToken cancellationToken = default)
        {
            var errors = ValidateCinema(cinema);
            if (errors.Any()) return errors;

            await _cinemaRepository.UpdateAsync(cinema, cancellationToken).ConfigureAwait(false);
            await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
            return errors;
        }

        public async Task<bool> DeleteCinemaAsync(int cinemaId, CancellationToken cancellationToken = default)
        {
            var success = await _cinemaRepository.HardDeleteCinemaAsync(cinemaId, cancellationToken).ConfigureAwait(false);
            if (success)
                await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
            return success;
        }

        #endregion

        #region Status Management

        public async Task<bool> SetCinemaStatusAsync(int cinemaId, bool isActive, CancellationToken cancellationToken = default)
        {
            var success = await _cinemaRepository.SetCinemaStatusAsync(cinemaId, isActive, cancellationToken).ConfigureAwait(false);
            if (success)
                await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
            return success;
        }

        #endregion

        #region Statistics & Audit

        public async Task<(int TotalShowtimes, int UpcomingMovies, decimal Revenue)> GetCinemaStatsAsync(int cinemaId, CancellationToken cancellationToken = default)
        {
            return await _cinemaRepository.GetCinemaDetailsStatsAsync(cinemaId, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(DateTime CreatedAt, DateTime? UpdatedAt, DateTime? LastShowtime)> GetCinemaAuditInfoAsync(int cinemaId, CancellationToken cancellationToken = default)
        {
            return await _cinemaRepository.GetCinemaAuditInfoAsync(cinemaId, cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Validates a Cinema entity and returns a list of validation errors.
        /// </summary>
        private List<string> ValidateCinema(Cinema cinema)
        {
            var errors = new List<string>();

            if (cinema == null)
            {
                errors.Add("Cinema cannot be null.");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(cinema.Name))
                errors.Add("Cinema name is required.");

            if (!string.IsNullOrWhiteSpace(cinema.Email) && !ValidationHelpers.IsValidEmail(cinema.Email))
                errors.Add("Invalid email format.");

            if (!string.IsNullOrWhiteSpace(cinema.Phone) && !ValidationHelpers.IsValidPhoneNumber(cinema.Phone))
                errors.Add("Invalid phone number.");

            if (cinema.TotalSeats <= 0)
                errors.Add("Total seats must be greater than zero.");

            if (!string.IsNullOrWhiteSpace(cinema.ImageUrl) && !ValidationHelpers.IsValidUrl(new Uri(cinema.ImageUrl, UriKind.RelativeOrAbsolute)))
                errors.Add("Invalid image URL.");

            return errors;
        }

        #endregion
    }
}
