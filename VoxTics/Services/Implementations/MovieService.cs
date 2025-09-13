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
        private readonly IUnitOfWork _uow;
        public MovieService(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<Movie>> GetAllAsync() => await _uow.Movies.GetAllAsync();
        public async Task<Movie?> GetByIdAsync(int id) => await _uow.Movies.GetByIdAsync(id);
        public async Task<Movie?> GetByTitleAsync(string title) => await _uow.Movies.GetByTitleAsync(title);
        public async Task<IEnumerable<Movie>> GetWithCategoriesAsync() => await _uow.Movies.GetWithCategoriesAsync();

        public async Task CreateAsync(Movie movie)
        {
            await _uow.Movies.AddAsync(movie);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            _uow.Movies.Update(movie);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await _uow.Movies.GetByIdAsync(id);
            if (movie == null) return;
            _uow.Movies.DeleteAsync(movie);
            await _uow.SaveAsync();
        }
    }

}
