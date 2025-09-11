using AutoMapper;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Areas.Admin.ViewModels.Filter;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Data.UoW;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces;
using MovieFilterVM = VoxTics.Areas.Admin.ViewModels.Filter.MovieFilterVM;

namespace VoxTics.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync() =>
            await _unitOfWork.Movies.GetAllAsync();

        public async Task<Movie?> GetByIdAsync(int id) =>
            await _unitOfWork.Movies.GetByIdAsync(id);

        public async Task<IEnumerable<Movie>> GetByCategoryAsync(int categoryId) =>
            await _unitOfWork.Movies.GetMoviesByCategoryAsync(categoryId);

        public async Task<IEnumerable<Movie>> GetUpcomingAsync(DateTime fromDate) =>
            await _unitOfWork.Movies.GetUpcomingMoviesAsync(fromDate);

        public async Task CreateAsync(Movie movie)
        {
            await _unitOfWork.Movies.AddAsync(movie);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            _unitOfWork.Movies.Update(movie);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await _unitOfWork.Movies.GetByIdAsync(id);
            if (movie != null)
            {
                _unitOfWork.Movies.Remove(movie);
                await _unitOfWork.CompleteAsync();
            }
        }
    }

}
