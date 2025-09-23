using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VoxTics.Helpers;
using VoxTics.Helpers.ImgsHelper;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Cart;
using VoxTics.Models.ViewModels.Movie;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMoviesRepository _repo;
        private readonly IMapper _mapper;
        private readonly ImageManager _imgManager;
        private readonly IShowtimesRepository _showtimeRepo;

        public MovieService(IMoviesRepository repo, IMapper mapper, ImageManager imgManager, IShowtimesRepository showtimeRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _imgManager = imgManager;
            _showtimeRepo = showtimeRepo;
        }

        // List view with Category name + main image
        public async Task<PaginatedList<MovieVM>> GetPagedAsync(
     int pageIndex,
     int pageSize,
     string? search = null,
     string? sortColumn = null,
     bool sortDescending = false)
        {
            // Base query
            var query = _repo.Query()
                             .Include(m => m.Category)
                             .AsQueryable();

            // Search
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(m => m.Title.Contains(search) ||
                                         m.Description.Contains(search) ||
                                         m.Category.Name.Contains(search));
            }

            // Sort
            if (!string.IsNullOrWhiteSpace(sortColumn))
                query = query.ApplySorting(sortColumn, sortDescending);

            // Pagination
            var pagedMovies = await query.ToPaginatedListAsync(pageIndex, pageSize);

            // Map to VM
            var vmList = _mapper.Map<List<MovieVM>>(pagedMovies.Items);

            // Populate MainImage URLs
            foreach (var vm in vmList)
            {
                if (!string.IsNullOrEmpty(vm.MainImageUrl))
                    vm.MainImageUrl = _imgManager.GetImageWebPath(ImageType.Movie, vm.Slug, vm.MainImageUrl).ToString();
            }

            return new PaginatedList<MovieVM>(vmList, pagedMovies.TotalCount, pageIndex, pageSize);
        }


        // Details view with VariantImages + Category + Actors
        public async Task<MovieDetailsVM?> GetDetailsAsync(int movieId)
        {
            var movie = await _repo.Query()
                                   .Include(m => m.Category)
                                   .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                                   .Include(m => m.Showtimes)
                                   .Include(m => m.MovieImages)
                                   .FirstOrDefaultAsync(m => m.Id == movieId);

            if (movie == null) return null;

            var vm = _mapper.Map<MovieDetailsVM>(movie);

            // Populate all image URLs
            if (!string.IsNullOrEmpty(movie.MainImage))
                vm.MainImageUrl = _imgManager.GetImageWebPath(ImageType.Movie, movie.Slug, movie.MainImage).ToString();

            foreach (var imgVm in vm.VariantImages)
            {
                imgVm.Url = _imgManager.GetImageWebPath(ImageType.Movie, movie.Slug, imgVm.FileName).ToString();
            }

            // Actor images
            foreach (var actor in vm.Actors)
            {
                if (!string.IsNullOrEmpty(actor.ImageUrl))
                    actor.ImageUrl = _imgManager.GetImageWebPath(ImageType.Actor, actor.Id.ToString(), actor.ImageUrl).ToString();
            }
            return vm;
        }

        public async Task<List<MovieVM>> GetAllAsync()
        {
            // Get all movies including Category
            var movies = await _repo.Query()
                                    .Include(m => m.Category)
                                    .ToListAsync();

            // Map to MovieVM
            var vmList = _mapper.Map<List<MovieVM>>(movies);

            // Populate main image URLs
            foreach (var vm in vmList)
            {
                if (!string.IsNullOrEmpty(vm.MainImageUrl))
                    vm.MainImageUrl = _imgManager.GetImageWebPath(ImageType.Movie, vm.Slug, vm.MainImageUrl).ToString();
            }

            return vmList;
        }

        public async Task<List<SeatVM>> GetAvailableSeatsAsync(int showtimeId)
        {
            var showtime = await _showtimeRepo.Query()
                .Include(s => s.Hall)
                    .ThenInclude(h => h.Seats)
                .Include(s => s.Bookings)
                    .ThenInclude(b => b.BookingSeats)
                .FirstOrDefaultAsync(s => s.Id == showtimeId);

            if (showtime == null) return new List<SeatVM>();

            // Get all booked seat IDs for this showtime
            var bookedSeatIds = showtime.Bookings
                .SelectMany(b => b.BookingSeats)
                .Select(bs => bs.SeatId)
                .ToHashSet();

            // Filter available seats
            var availableSeats = showtime.Hall.Seats
                .Where(s => s.IsActive && !bookedSeatIds.Contains(s.Id))
                .ToList();

            // Map to SeatVM
            return _mapper.Map<List<SeatVM>>(availableSeats);
        }

    }
}
