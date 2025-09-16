using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels.Actor;
using VoxTics.Models.ViewModels.Category;
using VoxTics.Models.ViewModels.Movie;
using VoxTics.Models.ViewModels.Showtime;
using VoxTics.Services.Interfaces;

namespace VoxTics.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(
            int page = 1,
            int pageSize = 10,
            string? search = null,
            MovieStatus? status = null,
            string? sort = null,
            CancellationToken cancellationToken = default)
        {
            // Fetch paginated list of Movie entities
            var pagedMovies = await _movieService
                .GetPagedMoviesAsync(page, pageSize, search, status, sort, cancellationToken)
                .ConfigureAwait(false);

            // Map to MovieVM
            var movieVMList = pagedMovies.Select(m => new MovieVM
            {
                Id = m.Id,
                Title = m.Title,
                PosterImage = m.ImageUrl,
                ReleaseDate = m.ReleaseDate,
                Duration = m.Duration,
                Price = m.Price,
                Rating = m.Rating.ToString(),
                Status = m.Status
            }).ToList();

            // Wrap in PaginatedList<MovieVM>
            var model = PaginatedList<MovieVM>.CreateFromList(movieVMList, page, pageSize);

            return View(model);
        }



        public async Task<IActionResult> Featured(CancellationToken cancellationToken)
        {
            var featured = await _movieService.GetFeaturedMoviesAsync(cancellationToken).ConfigureAwait(false);
            return View(featured);
        }

   
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var movie = await _movieService.GetMovieDetailsAsync(id, cancellationToken).ConfigureAwait(false);
            if (movie == null) return NotFound();

            var vm = new MovieDetailsVM
            {
                Id = movie.Id,
                Title = movie.Title,
                ShortDescription = movie.ShortDescription,
                Description = movie.Description,
                Director = movie.Director,
                Country = movie.Country,
                Language = movie.Language,
                AgeRating = movie.AgeRating,
                ImageUrl = movie.ImageUrl,
                TrailerImageUrl = movie.TrailerImageUrl,
                TrailerUrl = movie.TrailerUrl,
                IsFeatured = movie.IsFeatured,
                Status = movie.Status,
                ReleaseDate = movie.ReleaseDate,
                Duration = movie.Duration,
                Price = movie.Price,
                Rating = movie.Rating,
                Cast = movie.MovieActors.Select(a => new ActorVM
                {
                    Id = a.Actor.Id,
                    FullName = a.Actor.FullName,
                    ImageUrl = a.Actor.ImageUrl
                }).ToList(),
                Categories = movie.MovieCategories.Select(c => new CategoryVM
                {
                    Id = c.Category.Id,
                    Name = c.Category.Name
                }).ToList(),
                GalleryImages = movie.MovieImages.Select(i => i.ImageUrl).ToList(),
                Showtimes = movie.Showtimes.Select(s => new ShowtimeVM
                {
                    Id = s.Id,
                    StartTime = s.StartTime,
                    HallName = s.Hall.Name,
                    Price = s.Price
                }).ToList()
            };

            return View(vm);
        }



        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ByCategory(int categoryId, CancellationToken cancellationToken)
        {
            var movies = await _movieService.GetMoviesByCategoryAsync(categoryId, cancellationToken).ConfigureAwait(false);
            return View(movies);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ByReleaseDate(DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var movies = await _movieService.GetMoviesByReleaseDateRangeAsync(startDate, endDate, cancellationToken);
            return View(movies);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Search(string keyword, CancellationToken cancellationToken)
        {
            var movies = await _movieService.SearchMoviesAsync(keyword, cancellationToken).ConfigureAwait(false);
            return View(movies);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> TopRated(int count = 10, CancellationToken cancellationToken = default)
        {
            var movies = await _movieService.GetTopRatedMoviesAsync(count, cancellationToken).ConfigureAwait(false);
            return View(movies);
        }
    }
}
