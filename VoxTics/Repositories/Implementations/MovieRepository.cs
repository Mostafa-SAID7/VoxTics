using Microsoft.EntityFrameworkCore;
using VoxTics.Data;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Repositories.Implementations
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(VoxTicsDbContext context) : base(context)
        {
        }

        public override async Task<Movie?> GetByIdAsync(int id)
        {
            try
            {
                return await _dbSet
                    .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                    .FirstOrDefaultAsync(m => m.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<IEnumerable<Movie>> GetAllAsync()
        {
            try
            {
                return await _dbSet
                    .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                    .OrderBy(m => m.Title)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PaginatedList<Movie>> GetAllAsync(
            string? searchTerm = null,
            int? categoryId = null,
            MovieStatus? status = null,
            int pageNumber = 1,
            int pageSize = 10,
            string sortBy = "Title",
            bool sortDescending = false)
        {
            try
            {
                var query = _dbSet
                    .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                    .AsQueryable();

                // Apply filters
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query = query.Where(m => m.Title.Contains(searchTerm) ||
                                           m.Description.Contains(searchTerm));
                }

                if (categoryId.HasValue && categoryId > 0)
                {
                    query = query.Where(m => m.MovieCategories
                        .Any(mc => mc.CategoryId == categoryId));
                }

                if (status.HasValue)
                {
                    query = query.Where(m => m.Status == status);
                }

                // Apply sorting
                query = sortBy.ToLower() switch
                {
                    "title" => sortDescending ? query.OrderByDescending(m => m.Title) : query.OrderBy(m => m.Title),
                    "price" => sortDescending ? query.OrderByDescending(m => m.Price) : query.OrderBy(m => m.Price),
                    "releasedate" => sortDescending ? query.OrderByDescending(m => m.ReleaseDate) : query.OrderBy(m => m.ReleaseDate),
                    "duration" => sortDescending ? query.OrderByDescending(m => m.Duration) : query.OrderBy(m => m.Duration),
                    "status" => sortDescending ? query.OrderByDescending(m => m.Status) : query.OrderBy(m => m.Status),
                    "createdate" => sortDescending ? query.OrderByDescending(m => m.CreatedDate) : query.OrderBy(m => m.CreatedDate),
                    _ => sortDescending ? query.OrderByDescending(m => m.Title) : query.OrderBy(m => m.Title)
                };

                return await PaginatedList<Movie>.CreateAsync(query, pageNumber, pageSize);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Movie?> GetByTitleAsync(string title)
        {
            try
            {
                return await _dbSet
                    .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                    .FirstOrDefaultAsync(m => m.Title.ToLower() == title.ToLower());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Movie>> GetByStatusAsync(MovieStatus status)
        {
            try
            {
                return await _dbSet
                    .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                    .Where(m => m.Status == status)
                    .OrderBy(m => m.Title)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Movie>> GetByCategoryAsync(int categoryId)
        {
            try
            {
                return await _dbSet
                    .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                    .Where(m => m.MovieCategories.Any(mc => mc.CategoryId == categoryId))
                    .OrderBy(m => m.Title)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Movie>> GetUpcomingMoviesAsync()
        {
            try
            {
                return await _dbSet
                    .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                    .Where(m => m.Status == MovieStatus.Upcoming)
                    .OrderBy(m => m.ReleaseDate)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Movie>> GetNowShowingMoviesAsync()
        {
            try
            {
                return await _dbSet
                    .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                    .Where(m => m.Status == MovieStatus.NowShowing)
                    .OrderBy(m => m.Title)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Movie>> GetFeaturedMoviesAsync(int count = 10)
        {
            try
            {
                return await _dbSet
                    .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                    .Where(m => m.Status == MovieStatus.NowShowing)
                    .OrderByDescending(m => m.CreatedDate)
                    .Take(count)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> HasRelatedDataAsync(int movieId)
        {
            try
            {
                // Check if movie has any showtimes
                var hasShowtimes = await _context.Showtimes
                    .AnyAsync(s => s.MovieId == movieId);

                if (hasShowtimes)
                    return true;

                // Check if movie has any bookings through showtimes
                var hasBookings = await _context.Bookings
                    .AnyAsync(b => b.Showtime.MovieId == movieId);

                return hasBookings;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Movie>> SearchMoviesAsync(string searchTerm)
        {
            try
            {
                if (string.IsNullOrEmpty(searchTerm))
                    return await GetAllAsync();

                return await _dbSet
                    .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                    .Where(m => m.Title.Contains(searchTerm) ||
                               m.Description.Contains(searchTerm) ||
                               m.MovieCategories.Any(mc => mc.Category.Name.Contains(searchTerm)))
                    .OrderBy(m => m.Title)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> IsTitleUniqueAsync(string title, int? excludeId = null)
        {
            try
            {
                var query = _dbSet.Where(m => m.Title.ToLower() == title.ToLower());

                if (excludeId.HasValue)
                {
                    query = query.Where(m => m.Id != excludeId.Value);
                }

                return !await query.AnyAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Movie>> GetMoviesByCategoriesAsync(List<int> categoryIds)
        {
            try
            {
                return await _dbSet
                    .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                    .Where(m => m.MovieCategories.Any(mc => categoryIds.Contains(mc.CategoryId)))
                    .Distinct()
                    .OrderBy(m => m.Title)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Dictionary<MovieStatus, int>> GetMovieCountByStatusAsync()
        {
            try
            {
                var counts = await _dbSet
                    .GroupBy(m => m.Status)
                    .Select(g => new { Status = g.Key, Count = g.Count() })
                    .ToDictionaryAsync(x => x.Status, x => x.Count);

                return counts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Movie>> GetRecentMoviesAsync(int count = 5)
        {
            try
            {
                return await _dbSet
                    .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                    .OrderByDescending(m => m.CreatedDate)
                    .Take(count)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<decimal> GetAveragePriceAsync()
        {
            try
            {
                return await _dbSet.AverageAsync(m => m.Price);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Movie?> GetMovieWithDetailsAsync(int id)
        {
            try
            {
                return await _dbSet
                    .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                    .Include(m => m.Showtimes)
                    .ThenInclude(s => s.Cinema)
                    .FirstOrDefaultAsync(m => m.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var movie = await _dbSet
                    .Include(m => m.MovieCategories)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (movie == null)
                    return false;

                // Remove related MovieCategory entries
                if (movie.MovieCategories != null && movie.MovieCategories.Any())
                {
                    _context.MovieCategories.RemoveRange(movie.MovieCategories);
                }

                _dbSet.Remove(movie);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}