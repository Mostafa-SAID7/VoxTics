using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Services.Interfaces;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Data.UoW;
using VoxTics.Helpers;
using VoxTics.Helpers.ImgsHelper;
using VoxTics.Models.Entities;

namespace VoxTics.Areas.Admin.Services.Implementations
{
    public class AdminMovieService : IAdminMovieService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ImageManager _imageManager;

        public AdminMovieService(IUnitOfWork uow, IMapper mapper, ImageManager imageManager)
        {
            _uow = uow;
            _mapper = mapper;
            _imageManager = imageManager;
        }

        // 🔹 Pagination with optional search/sort
        public async Task<PaginatedList<MovieListItemViewModel>> GetPagedMoviesAsync(
            int pageIndex,
            int pageSize,
            string? search = null,
            string? sortColumn = null,
            bool sortDescending = false)
        {
            var query = _uow.AdminMovies.GetMoviesWithCategory();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(m =>
                    m.Title.Contains(search) || m.Category.Name.Contains(search));
            }

            query = query.ApplySorting(sortColumn ?? nameof(Movie.ReleaseDate), sortDescending);

            var items = await query
                .Select(m => _mapper.Map<MovieListItemViewModel>(m))
                .ToPaginatedListAsync(pageIndex, pageSize);

            return items;
        }

        // 🔹 Get detailed movie info
        public async Task<MovieDetailViewModel?> GetMovieDetailsAsync(int id)
        {
            var movie = await _uow.AdminMovies.GetMovieWithDetailsAsync(id);
            return movie == null ? null : _mapper.Map<MovieDetailViewModel>(movie);
        }

        // 🔹 Create a new movie (alias for AddMovieAsync)
        public async Task<int> CreateMovieAsync(MovieCreateEditViewModel model)
        {
            return await AddMovieAsync(model);
        }

        // 🔹 Add movie and handle images
        public async Task<int> AddMovieAsync(MovieCreateEditViewModel model)
        {
            var slug = SlugHelper.GenerateSlug(model.Title);

            if (await _uow.AdminMovies.MovieExistsBySlugAsync(slug))
                throw new InvalidOperationException("A movie with this slug already exists.");

            var movie = _mapper.Map<Movie>(model);
            movie.Slug = slug;

            await HandleMainImageAsync(model, movie, slug);
            await HandleAdditionalImagesAsync(model, movie, slug);

            await _uow.AdminMovies.AddAsync(movie);
            await _uow.CommitAsync();

            return movie.Id;
        }

        // 🔹 Get movie by ID for edit/view
        public async Task<MovieDetailViewModel?> GetByIdAsync(int id)
        {
            var movie = await _uow.AdminMovies.GetMovieWithDetailsAsync(id);
            return movie == null ? null : _mapper.Map<MovieDetailViewModel>(movie);
        }

        // 🔹 Update movie
        public async Task<bool> UpdateMovieAsync(MovieCreateEditViewModel model)
        {
            var movie = await _uow.AdminMovies.GetMovieWithDetailsAsync(model.Id);
            if (movie == null) return false;

            _mapper.Map(model, movie);

            await HandleMainImageAsync(model, movie, movie.Slug);
            await HandleAdditionalImagesAsync(model, movie, movie.Slug);

            await _uow.AdminMovies.UpdateAsync(movie);
            await _uow.CommitAsync();
            return true;
        }

        // 🔹 Delete movie and its images
        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _uow.AdminMovies.GetMovieWithDetailsAsync(id);
            if (movie == null) return false;

            await _uow.AdminMovies.RemoveAsync(movie);
            await _uow.CommitAsync();

            _imageManager.DeleteFolder(ImageType.Movie, movie.Slug);
            return true;
        }

        // ✅ Private helpers for images
        private async Task HandleMainImageAsync(MovieCreateEditViewModel model, Movie movie, string slug)
        {
            if (model.MainImage == null) return;

            var fileName = await _imageManager.SaveImageAsync(
                model.MainImage, ImageType.Movie, slug, true).ConfigureAwait(false);

            movie.MainImage = fileName;
        }

        private async Task HandleAdditionalImagesAsync(MovieCreateEditViewModel model, Movie movie, string slug)
        {
            if (model.AdditionalImages == null || !model.AdditionalImages.Any()) return;

            foreach (var img in model.AdditionalImages)
            {
                var fileName = await _imageManager.SaveImageAsync(
                    img, ImageType.Movie, slug).ConfigureAwait(false);

                movie.MovieImages.Add(new MovieImg { Url = fileName });
            }
        }
    }
}
