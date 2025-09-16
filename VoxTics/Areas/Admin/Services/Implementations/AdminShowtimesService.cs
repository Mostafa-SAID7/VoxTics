using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Data.UoW;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class AdminShowtimeService : IAdminShowtimeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Showtime> _showtimeRepository;

        public AdminShowtimeService(IUnitOfWork unitOfWork, IBaseRepository<Showtime> showtimeRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _showtimeRepository = showtimeRepository ?? throw new ArgumentNullException(nameof(showtimeRepository));
        }

        public async Task<(IEnumerable<Showtime> Showtimes, int TotalCount)> GetPagedShowtimesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            CancellationToken cancellationToken = default)
        {
            var query = _showtimeRepository.Query();

            if (!string.IsNullOrWhiteSpace(searchTerm))
                query = query.Where(s =>
                    s.Movie.Title.Contains(searchTerm) ||
                    s.Cinema.Name.Contains(searchTerm));

            var totalCount = query.Count();
            var showtimes = query
                .OrderByDescending(s => s.StartTime)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();

            return (showtimes, totalCount);
        }

        public async Task<Showtime?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _showtimeRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<List<string>> AddShowtimeAsync(Showtime showtime, CancellationToken cancellationToken = default)
        {
            var errors = ValidateShowtime(showtime);
            if (errors.Any()) return errors;

            await _showtimeRepository.AddAsync(showtime, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return errors;
        }

        public async Task<List<string>> UpdateShowtimeAsync(Showtime showtime, CancellationToken cancellationToken = default)
        {
            var errors = ValidateShowtime(showtime);
            if (errors.Any()) return errors;

            await _showtimeRepository.UpdateAsync(showtime, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return errors;
        }

        public async Task<bool> DeleteShowtimeAsync(int id, CancellationToken cancellationToken = default)
        {
            var showtime = await _showtimeRepository.GetByIdAsync(id, cancellationToken);
            if (showtime == null) return false;

            await _showtimeRepository.RemoveAsync(showtime, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }

        #region Private Helpers

        private List<string> ValidateShowtime(Showtime showtime)
        {
            var errors = new List<string>();

            if (showtime == null)
            {
                errors.Add("Showtime cannot be null.");
                return errors;
            }

            if (!ValidationHelpers.IsValidShowtime(showtime.StartTime))
                errors.Add("Showtime must be in the future and not more than 1 year ahead.");

            if (showtime.MovieId <= 0)
                errors.Add("Invalid Movie.");

            if (showtime.CinemaId <= 0)
                errors.Add("Invalid Cinema.");

            if (showtime.HallId <= 0)
                errors.Add("Invalid Hall.");

            return errors;
        }

        #endregion
    }
}
