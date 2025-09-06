using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Repositories.Implementations
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieDbContext context) : base(context) { }

        // -------------------------
        // Listing & details
        // -------------------------
        public async Task<IEnumerable<Movie>> GetMoviesByStatusAsync(MovieStatus status)
        {
            return await _dbSet
                .Where(m => m.Status == status)
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieImages)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByCategoryAsync(int categoryId)
        {
            return await _dbSet
                .Where(m => m.MovieCategories.Any(mc => mc.CategoryId == categoryId))
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieImages)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<bool> IsMovieTitleUniqueAsync(string title, int? excludeId = null)
        {
            var q = _dbSet.Where(m => m.Title.ToLower() == title.ToLower());
            if (excludeId.HasValue) q = q.Where(m => m.Id != excludeId.Value);
            return !await q.AnyAsync();
        }
        public async Task<IEnumerable<Movie>> GetMoviesByCinemaAsync(int cinemaId)
        {
            return await _dbSet
                .Where(m => m.Showtimes.Any(s => s.Hall.CinemaId == cinemaId))
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieImages)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Movie?> GetMovieWithDetailsAsync(int movieId)
        {
            return await _dbSet
                .Where(m => m.Id == movieId)
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                .Include(m => m.MovieImages)
                .Include(m => m.Showtimes).ThenInclude(s => s.Hall).ThenInclude(h => h.Cinema)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        // -------------------------
        // Includes shortcuts
        // -------------------------
        public async Task<bool> HasRelatedDataAsync(int movieId)
        {
            if (movieId <= 0) return false;

            // Check for showtimes, bookings, categories, actors, images — anything that should block deletion
            var hasShowtimes = await _context.Showtimes.AnyAsync(s => s.MovieId == movieId);
            if (hasShowtimes) return true;

            var hasBookings = await _context.Bookings.AnyAsync(b => b.Showtime.MovieId == movieId);
            if (hasBookings) return true;

            var hasCategories = await _context.MovieCategories.AnyAsync(mc => mc.MovieId == movieId);
            if (hasCategories) return true;

            var hasActors = await _context.MovieActors.AnyAsync(ma => ma.MovieId == movieId);
            if (hasActors) return true;

            var hasImages = await _context.MovieImages.AnyAsync(mi => mi.MovieId == movieId);
            if (hasImages) return true;

            return false;
        }

        public async Task<IEnumerable<Movie>> GetMoviesWithCategoriesAsync()
        {
            return await _dbSet
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesWithActorsAsync()
        {
            return await _dbSet
                .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesWithImagesAsync()
        {
            return await _dbSet
                .Include(m => m.MovieImages)
                .AsNoTracking()
                .ToListAsync();
        }

        // -------------------------
        // Featured / Popular / Latest / Upcoming
        // -------------------------
        public async Task<IEnumerable<Movie>> GetFeaturedMoviesAsync(int count = 6)
        {
            return await _dbSet
                .Where(m => m.Status == MovieStatus.NowShowing && m.IsFeatured)
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieImages)
                .OrderByDescending(m => m.CreatedAt)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetPopularMoviesAsync(int count = 10)
        {
            return await _dbSet
                .Where(m => m.Status == MovieStatus.NowShowing)
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieImages)
                .OrderByDescending(m => m.Showtimes.SelectMany(s => s.Bookings).Count())
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetLatestMoviesAsync(int count = 10)
        {
            return await _dbSet
                .Where(m => m.Status == MovieStatus.NowShowing)
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieImages)
                .OrderByDescending(m => m.ReleaseDate)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetUpcomingMoviesAsync(int count = 10)
        {
            return await _dbSet
                .Where(m => m.Status == MovieStatus.Upcoming)
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieImages)
                .OrderBy(m => m.ReleaseDate)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        }

        // -------------------------
        // Search and filter
        // -------------------------
        public async Task<IEnumerable<Movie>> SearchMoviesAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllAsync();

            var lower = searchTerm.ToLower();

            return await _dbSet
                .Where(m =>
                    EF.Functions.Like(m.Title.ToLower(), $"%{lower}%") ||
                    EF.Functions.Like(m.Description.ToLower(), $"%{lower}%") ||
                    EF.Functions.Like(m.Director.ToLower(), $"%{lower}%") ||
                    m.MovieActors.Any(ma => EF.Functions.Like(ma.Actor.FullName.ToLower(), $"%{lower}%")) ||
                    m.MovieCategories.Any(mc => EF.Functions.Like(mc.Category.Name.ToLower(), $"%{lower}%"))
                )
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieImages)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetFilteredMoviesAsync(MovieFilterVM filter)
        {
            var query = _dbSet.AsQueryable();

            if (filter.Status.HasValue)
                query = query.Where(m => m.Status == filter.Status.Value);

            if (filter.CategoryId.HasValue)
                query = query.Where(m => m.MovieCategories.Any(mc => mc.CategoryId == filter.CategoryId.Value));

            if (filter.CinemaId.HasValue)
                query = query.Where(m => m.Showtimes.Any(s => s.Hall.CinemaId == filter.CinemaId.Value));

            if (filter.ReleaseYear.HasValue)
                query = query.Where(m => m.ReleaseDate.Year == filter.ReleaseYear.Value);

            if (filter.MinRating.HasValue)
                query = query.Where(m => m.Rating >= filter.MinRating.Value);

            if (filter.MaxRating.HasValue)
                query = query.Where(m => m.Rating <= filter.MaxRating.Value);

            if (!string.IsNullOrWhiteSpace(filter.AgeRating))
                query = query.Where(m => m.AgeRating == filter.AgeRating);

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                var s = filter.SearchTerm.ToLower();
                query = query.Where(m =>
                    EF.Functions.Like(m.Title.ToLower(), $"%{s}%") ||
                    EF.Functions.Like(m.Description.ToLower(), $"%{s}%") ||
                    EF.Functions.Like(m.Director.ToLower(), $"%{s}%"));
            }

            query = filter.SortBy?.ToLower() switch
            {
                "title" => filter.SortOrder == SortOrder.Desc ? query.OrderByDescending(m => m.Title) : query.OrderBy(m => m.Title),
                "releasedate" => filter.SortOrder == SortOrder.Desc ? query.OrderByDescending(m => m.ReleaseDate) : query.OrderBy(m => m.ReleaseDate),
                "rating" => filter.SortOrder == SortOrder.Desc ? query.OrderByDescending(m => m.Rating) : query.OrderBy(m => m.Rating),
                "duration" => filter.SortOrder == SortOrder.Desc ? query.OrderByDescending(m => m.DurationMinutes) : query.OrderBy(m => m.DurationMinutes),
                _ => query.OrderByDescending(m => m.CreatedAt)
            };

            return await query
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieImages)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<(IEnumerable<Movie> movies, int totalCount)> GetPagedFilteredMoviesAsync(MovieFilterVM filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));
            if (filter.PageNumber <= 0) filter.PageNumber = 1;
            if (filter.PageSize <= 0) filter.PageSize = 10;

            var query = _dbSet.AsQueryable();

            if (filter.Status.HasValue)
                query = query.Where(m => m.Status == filter.Status.Value);

            if (filter.CategoryId.HasValue)
                query = query.Where(m => m.MovieCategories.Any(mc => mc.CategoryId == filter.CategoryId.Value));

            if (filter.CinemaId.HasValue)
                query = query.Where(m => m.Showtimes.Any(s => s.Hall.CinemaId == filter.CinemaId.Value));

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                var s = filter.SearchTerm.ToLower();
                query = query.Where(m =>
                    EF.Functions.Like(m.Title.ToLower(), $"%{s}%") ||
                    EF.Functions.Like(m.Description.ToLower(), $"%{s}%") ||
                    EF.Functions.Like(m.Director.ToLower(), $"%{s}%"));
            }

            var totalCount = await query.CountAsync();

            query = filter.SortBy?.ToLower() switch
            {
                "title" => filter.SortOrder == SortOrder.Desc ? query.OrderByDescending(m => m.Title) : query.OrderBy(m => m.Title),
                "releasedate" => filter.SortOrder == SortOrder.Desc ? query.OrderByDescending(m => m.ReleaseDate) : query.OrderBy(m => m.ReleaseDate),
                "rating" => filter.SortOrder == SortOrder.Desc ? query.OrderByDescending(m => m.Rating) : query.OrderBy(m => m.Rating),
                _ => query.OrderByDescending(m => m.CreatedAt)
            };

            var ids = await query
                .Select(m => m.Id)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            var movies = await _dbSet
                .Where(m => ids.Contains(m.Id))
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.MovieImages)
                .AsNoTracking()
                .ToListAsync();

            var ordered = ids.Select(id => movies.First(m => m.Id == id)).ToList();

            return (ordered, totalCount);
        }

        // -------------------------
        // Statistics
        // -------------------------
        public async Task<int> GetMovieCountByStatusAsync(MovieStatus status) =>
            await _dbSet.CountAsync(m => m.Status == status);

        public async Task<decimal> GetAverageRatingAsync(int movieId)
        {
            var movie = await _dbSet.FindAsync(movieId);
            return movie?.Rating ?? 0m;
        }

        public async Task<int> GetTotalBookingsAsync(int movieId) =>
            await _context.Bookings.CountAsync(b => b.Showtime.MovieId == movieId);

        // -------------------------
        // Images
        // -------------------------
        public async Task<IEnumerable<MovieImg>> GetMovieImagesAsync(int movieId) =>
            await _context.MovieImages
                .Where(mi => mi.MovieId == movieId)
                .AsNoTracking()
                .ToListAsync();

        public async Task AddMovieImageAsync(MovieImg movieImage)
        {
            if (movieImage == null) throw new ArgumentNullException(nameof(movieImage));
            await _context.MovieImages.AddAsync(movieImage);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveMovieImageAsync(int movieImageId)
        {
            var movieImage = await _context.MovieImages.FindAsync(movieImageId);
            if (movieImage != null)
            {
                _context.MovieImages.Remove(movieImage);
                await _context.SaveChangesAsync();
            }
        }

        // -------------------------
        // Categories
        // -------------------------
        public async Task<IEnumerable<Category>> GetMovieCategoriesAsync(int movieId) =>
            await _context.MovieCategories
                .Where(mc => mc.MovieId == movieId)
                .Select(mc => mc.Category)
                .AsNoTracking()
                .ToListAsync();

        public async Task AddMovieCategoryAsync(int movieId, int categoryId)
        {
            var exists = await _context.MovieCategories.AnyAsync(mc => mc.MovieId == movieId && mc.CategoryId == categoryId);
            if (!exists)
            {
                await _context.MovieCategories.AddAsync(new MovieCategory { MovieId = movieId, CategoryId = categoryId });
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveMovieCategoryAsync(int movieId, int categoryId)
        {
            var movieCategory = await _context.MovieCategories
                .FirstOrDefaultAsync(mc => mc.MovieId == movieId && mc.CategoryId == categoryId);

            if (movieCategory != null)
            {
                _context.MovieCategories.Remove(movieCategory);
                await _context.SaveChangesAsync();
            }
        }

        // -------------------------
        // Actors
        // -------------------------
        public async Task<IEnumerable<Actor>> GetMovieActorsAsync(int movieId) =>
            await _context.MovieActors
                .Where(ma => ma.MovieId == movieId)
                .Select(ma => ma.Actor)
                .AsNoTracking()
                .ToListAsync();

        public async Task AddMovieActorAsync(int movieId, int actorId)
        {
            var exists = await _context.MovieActors.AnyAsync(ma => ma.MovieId == movieId && ma.ActorId == actorId);
            if (!exists)
            {
                await _context.MovieActors.AddAsync(new MovieActor { MovieId = movieId, ActorId = actorId });
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveMovieActorAsync(int movieId, int actorId)
        {
            var movieActor = await _context.MovieActors
                .FirstOrDefaultAsync(ma => ma.MovieId == movieId && ma.ActorId == actorId);

            if (movieActor != null)
            {
                _context.MovieActors.Remove(movieActor);
                await _context.SaveChangesAsync();
            }
        }

        // -------------------------
        // Admin
        // -------------------------
        public async Task<IEnumerable<Movie>> GetMoviesForAdminAsync() =>
            await _dbSet
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.Showtimes)
                .OrderByDescending(m => m.CreatedAt)
                .AsNoTracking()
                .ToListAsync();

        public async Task<(IEnumerable<Movie> movies, int totalCount)> GetPagedMoviesForAdminAsync(BasePaginatedFilterVM filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));
            if (filter.PageNumber <= 0) filter.PageNumber = 1;
            if (filter.PageSize <= 0) filter.PageSize = 10;

            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                var s = filter.SearchTerm.ToLower();
                query = query.Where(m => EF.Functions.Like(m.Title.ToLower(), $"%{s}%") ||
                                         EF.Functions.Like(m.Director.ToLower(), $"%{s}%"));
            }

            var totalCount = await query.CountAsync();

            var ids = await query
                .OrderByDescending(m => m.CreatedAt)
                .Select(m => m.Id)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            var movies = await _dbSet
                .Where(m => ids.Contains(m.Id))
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.Showtimes)
                .AsNoTracking()
                .ToListAsync();

            var ordered = ids.Select(id => movies.First(m => m.Id == id)).ToList();

            return (ordered, totalCount);
        }

        // -------------------------
        // Validation
        // -------------------------
        public async Task<bool> IsTitleUniqueAsync(string title, int? excludeId = null)
        {
            var q = _dbSet.Where(m => m.Title.ToLower() == title.ToLower());
            if (excludeId.HasValue) q = q.Where(m => m.Id != excludeId.Value);
            return !await q.AnyAsync();
        }
        

        public async Task<bool> HasActiveShowtimesAsync(int movieId) =>
            await _context.Showtimes.AnyAsync(s => s.MovieId == movieId && s.StartTime > DateTime.UtcNow);

        public async Task<bool> CanDeleteMovieAsync(int movieId)
        {
            var hasBookings = await _context.Bookings.AnyAsync(b => b.Showtime.MovieId == movieId);
            var hasActiveShowtimes = await HasActiveShowtimesAsync(movieId);
            return !hasBookings && !hasActiveShowtimes;
        }
    }
}
