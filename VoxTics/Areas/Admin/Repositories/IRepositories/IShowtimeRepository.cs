using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels;

namespace VoxTics.Areas.Admin.Repositories.IRepositories
{
    public interface IShowtimeRepository : IBaseRepository<Showtime>
    {
        // Basic retrievals
        Task<IEnumerable<Showtime>> GetShowtimesByMovieAsync(int movieId);
        Task<IEnumerable<Showtime>> GetShowtimesByCinemaAsync(int cinemaId);
        Task<IEnumerable<Showtime>> GetShowtimesByHallAsync(int hallId);
        Task<Showtime?> GetShowtimeWithDetailsAsync(int showtimeId);
        Task<IEnumerable<Showtime>> GetActiveShowtimesAsync();
        Task<IEnumerable<Showtime>> GetShowtimesByStatusAsync(ShowtimeStatus status);

        // Date/time queries
        Task<IEnumerable<Showtime>> GetShowtimesByDateAsync(DateTime date);
        Task<IEnumerable<Showtime>> GetShowtimesByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Showtime>> GetTodaysShowtimesAsync();
        Task<IEnumerable<Showtime>> GetUpcomingShowtimesAsync(int days = 7);
        Task<IEnumerable<Showtime>> GetShowtimesAfterTimeAsync(DateTime afterTime);

        // Combinations
        Task<IEnumerable<Showtime>> GetShowtimesByMovieAndCinemaAsync(int movieId, int cinemaId);
        Task<IEnumerable<Showtime>> GetShowtimesByMovieAndDateAsync(int movieId, DateTime date);
        Task<IEnumerable<Showtime>> GetShowtimesByCinemaAndDateAsync(int cinemaId, DateTime date);
        Task<IEnumerable<Showtime>> GetShowtimesByMovieCinemaAndDateAsync(int movieId, int cinemaId, DateTime date);

        // Availability & seats
        Task<int> GetAvailableSeatsCountAsync(int showtimeId);
        Task<int> GetBookedSeatsCountAsync(int showtimeId);
        Task<double> GetOccupancyRateAsync(int showtimeId);
        Task<bool> HasAvailableSeatsAsync(int showtimeId);
        Task<IEnumerable<Seat>> GetAvailableSeatsAsync(int showtimeId);

        // Search & paging
        Task<IEnumerable<Showtime>> SearchShowtimesAsync(string searchTerm);
        Task<(IEnumerable<Showtime> showtimes, int totalCount)> GetPagedShowtimesAsync(BasePaginatedFilterVM filter);
        Task<IEnumerable<Showtime>> GetFilteredShowtimesAsync(ShowtimeFilterVM filter);

        // Time-slot management
        Task<bool> IsTimeSlotAvailableAsync(int hallId, DateTime startTime, DateTime endTime, int? excludeShowtimeId = null);
        Task<IEnumerable<Showtime>> GetConflictingShowtimesAsync(int hallId, DateTime startTime, DateTime endTime, int? excludeShowtimeId = null);
        Task<TimeSpan> GetNextAvailableTimeSlotAsync(int hallId, DateTime preferredTime, TimeSpan duration);

        // Statistics & analytics
        Task<int> GetTotalBookingsAsync(int showtimeId);
        Task<decimal> GetTotalRevenueAsync(int showtimeId);
        Task<Dictionary<DateTime, int>> GetShowtimeCountByDateAsync(int days = 30);
        Task<Dictionary<string, int>> GetShowtimeCountByTimeRangeAsync();
        Task<IEnumerable<(Showtime showtime, int bookingCount)>> GetPopularShowtimesAsync(int count = 10);

        // Revenue reports
        Task<decimal> GetShowtimeRevenueAsync(int showtimeId);
        Task<decimal> GetMovieRevenueByDateAsync(int movieId, DateTime date);
        Task<decimal> GetCinemaRevenueByDateAsync(int cinemaId, DateTime date);
        Task<IEnumerable<(Movie movie, decimal revenue)>> GetTopMoviesByRevenueAsync(DateTime startDate, DateTime endDate, int count = 10);

        // Management
        Task<bool> CanCancelShowtimeAsync(int showtimeId);
        Task<bool> CancelShowtimeAsync(int showtimeId);
    }
}
