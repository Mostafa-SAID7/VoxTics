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
    public class AdminMovieService : IAdminMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Movie> _movieRepository;

        public AdminMovieService(IUnitOfWork unitOfWork, IBaseRepository<Movie> movieRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        public async Task<(IEnumerable<Movie> Movies, int TotalCount)> GetPagedMoviesAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            CancellationToken cancellationToken = default)
        {
            var query = _movieRepository.Query();

            if (!string.IsNullOrWhiteSpace(searchTerm))
                query = query.Where(m => m.Title.Contains(searchTerm));

            var totalCount = query.Count();
            var movies = query
                .OrderByDescending(m => m.ReleaseDate)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();

            return (movies, totalCount);
        }

        public async Task<Movie?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _movieRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<List<string>> AddMovieAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            var errors = ValidateMovie(movie);
            if (errors.Any()) return errors;

            await _movieRepository.AddAsync(movie, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return errors;
        }

        public async Task<List<string>> UpdateMovieAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            var errors = ValidateMovie(movie);
            if (errors.Any()) return errors;

            await _movieRepository.UpdateAsync(movie, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return errors;
        }

        public async Task<bool> DeleteMovieAsync(int id, CancellationToken cancellationToken = default)
        {
            var movie = await _movieRepository.GetByIdAsync(id, cancellationToken);
            if (movie == null) return false;

            await _movieRepository.RemoveAsync(movie, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }

        #region Private Helpers

        private List<string> ValidateMovie(Movie movie)
        {
            var errors = new List<string>();

            if (movie == null)
            {
                errors.Add("Movie cannot be null.");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(movie.Title))
                errors.Add("Title is required.");

            if (!ValidationHelpers.IsValidDateRange(movie.ReleaseDate, movie.DeletedAt))
                errors.Add("Release date must be before end date.");

            if (!ValidationHelpers.IsValidMovieDuration(movie.Duration))
                errors.Add("Duration is invalid.");

            if (!ValidationHelpers.IsValidRating((double?)movie.Rating))
                errors.Add("Rating must be between 0 and 10.");

            return errors;
        }

        #endregion
    }
}
