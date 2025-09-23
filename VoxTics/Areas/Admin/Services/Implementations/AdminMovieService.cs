using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        private readonly ImageManager _imageManager;

        public AdminMovieService(IUnitOfWork uow, ImageManager imageManager)
        {
            _uow = uow;
            _imageManager = imageManager;
        }

        public async Task<PaginatedList<MovieListItemViewModel>> GetPagedMoviesAsync(
            int pageIndex, int pageSize, string? search = null, string? sortColumn = null, bool sortDescending = false)
        {
            var query = _uow.AdminMovies.GetMoviesWithCategory();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(m => m.Title.Contains(search) || m.Category.Name.Contains(search));

            query = query.ApplySorting(sortColumn ?? nameof(Movie.ReleaseDate), sortDescending);

            var items = await query
                .Select(m => new MovieListItemViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    ReleaseDate = m.ReleaseDate,
                    CategoryName = m.Category.Name,
                    MainImageUrl = m.MainImage
                })
                .ToPaginatedListAsync(pageIndex, pageSize);

            return items;
        }

        public async Task<MovieDetailViewModel?> GetMovieDetailsAsync(int id)
        {
            var movie = await _uow.AdminMovies.GetMovieWithDetailsAsync(id);
            if (movie == null) return null;

            return new MovieDetailViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Director = movie.Director,
                ReleaseDate = movie.ReleaseDate,
                EndDate = movie.EndDate,
                Duration = movie.Duration,
                Price = movie.Price,
                Rating = movie.Rating,
                Language = movie.Language,
                Country = movie.Country,
                MainImageUrl = movie.MainImage,
                TrailerUrl = movie.TrailerUrl,
                IsFeatured = movie.IsFeatured,
                Status = movie.Status,
                Slug = movie.Slug,
                CategoryName = movie.Category?.Name ?? "Unknown",

                AdditionalImageUrls = movie.MovieImages?.Select(x => x.ImageUrl).ToList() ?? new List<string>()
            };
        }

        public async Task<MovieCreateEditViewModel?> GetByIdAsync(int id)
        {
            var movie = await _uow.AdminMovies.GetMovieWithDetailsAsync(id);
            if (movie == null) return null;

            return new MovieCreateEditViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Director = movie.Director,
                ReleaseDate = movie.ReleaseDate,
                EndDate = movie.EndDate,
                Duration = movie.Duration,
                Price = movie.Price,
                Rating = movie.Rating,
                Language = movie.Language,
                Country = movie.Country,
                ExistingPosterUrl = movie.MainImage,
                TrailerUrl = movie.TrailerUrl,
                IsFeatured = movie.IsFeatured,
                Status = movie.Status,
                Slug = movie.Slug,
                CategoryId = movie.CategoryId,
                ExistingImageUrls = movie.MovieImages?.Select(x => x.ImageUrl).ToList() ?? new List<string>()
            };
        }

        public async Task<int> CreateMovieAsync(MovieCreateEditViewModel model)
        {
            var slug = SlugHelper.GenerateSlug(model.Title);

            if (await _uow.AdminMovies.MovieExistsBySlugAsync(slug))
                throw new InvalidOperationException("A movie with this slug already exists.");

            var movie = new Movie
            {
                Title = model.Title,
                Description = model.Description,
                Director = model.Director,
                ReleaseDate = model.ReleaseDate,
                EndDate = model.EndDate,
                Duration = model.Duration,
                Price = model.Price,
                Rating = model.Rating,
                Language = model.Language,
                Country = model.Country,
                TrailerUrl = model.TrailerUrl,
                IsFeatured = model.IsFeatured,
                Status = model.Status,
                Slug = slug,
                CategoryId = model.CategoryId
            };

            await HandleMainImageAsync(model, movie, slug);
            await HandleAdditionalImagesAsync(model, movie, slug);

            await _uow.AdminMovies.AddAsync(movie);
            await _uow.CommitAsync();

            return movie.Id;
        }

        public async Task<bool> UpdateMovieAsync(MovieCreateEditViewModel model)
        {
            var movie = await _uow.AdminMovies.GetMovieWithDetailsAsync(model.Id);
            if (movie == null) return false;

            // Manual mapping
            movie.Title = model.Title;
            movie.Description = model.Description;
            movie.Director = model.Director;
            movie.ReleaseDate = model.ReleaseDate;
            movie.EndDate = model.EndDate;
            movie.Duration = model.Duration;
            movie.Price = model.Price;
            movie.Rating = model.Rating;
            movie.Language = model.Language;
            movie.Country = model.Country;
            movie.TrailerUrl = model.TrailerUrl;
            movie.IsFeatured = model.IsFeatured;
            movie.Status = model.Status;
            movie.CategoryId = model.CategoryId;

            await HandleMainImageAsync(model, movie, movie.Slug);
            await HandleAdditionalImagesAsync(model, movie, movie.Slug);

            await _uow.AdminMovies.UpdateAsync(movie);
            await _uow.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _uow.AdminMovies.GetMovieWithDetailsAsync(id);
            if (movie == null) return false;

            bool hasBookings = movie.Showtimes.Any(s => s.Bookings.Any());
            if (hasBookings)
                throw new InvalidOperationException("Cannot delete the movie because it has existing bookings.");

            await _uow.AdminMovies.RemoveAsync(movie);
            await _uow.CommitAsync();

            _imageManager.DeleteFolder(ImageType.Movie, movie.Slug);
            return true;
        }

        #region Private Image Handlers
        private async Task HandleMainImageAsync(MovieCreateEditViewModel model, Movie movie, string slug)
        {
            if (model.MainImage != null) // uploaded file
            {
                var fileName = await _imageManager.SaveImageAsync(model.MainImage, ImageType.Movie, slug, true);
                movie.MainImage = fileName;
            }
            else if (!string.IsNullOrWhiteSpace(model.ExistingPosterUrl)) // existing URL
            {
                movie.MainImage = model.ExistingPosterUrl;
            }
        }

        private async Task HandleAdditionalImagesAsync(MovieCreateEditViewModel model, Movie movie, string slug)
        {
            if ((model.AdditionalImages == null || !model.AdditionalImages.Any()) &&
                (model.ExistingImageUrls == null || !model.ExistingImageUrls.Any()))
                return;

            if (movie.MovieImages == null)
                movie.MovieImages = new List<MovieImg>();

            // Handle uploaded files
            if (model.AdditionalImages != null)
            {
                foreach (var file in model.AdditionalImages)
                {
                    var fileName = await _imageManager.SaveImageAsync(file, ImageType.Movie, slug);
                    movie.MovieImages.Add(new MovieImg { ImageUrl = fileName });
                }
            }

            // Handle existing URLs
            if (model.ExistingImageUrls != null)
            {
                foreach (var url in model.ExistingImageUrls)
                {
                    if (!string.IsNullOrWhiteSpace(url))
                        movie.MovieImages.Add(new MovieImg { ImageUrl = url });
                }
            }
        }
        #endregion
    }
}
