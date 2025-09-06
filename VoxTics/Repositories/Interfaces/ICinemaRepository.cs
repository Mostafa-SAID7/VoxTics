using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels; // BasePaginatedFilterVM

namespace VoxTics.Repositories.Interfaces
{
    public interface ICinemaRepository : IBaseRepository<Cinema>
    {
        // Basic listing & details
        Task<IEnumerable<Cinema>> GetActiveCinemasAsync();
        Task<Cinema?> GetCinemaWithHallsAsync(int cinemaId);
        Task<Cinema?> GetCinemaWithShowtimesAsync(int cinemaId);

        // Counts & aggregates
        Task<IEnumerable<Cinema>> GetCinemasWithHallCountAsync();
        Task<int> GetHallCountByCinemaAsync(int cinemaId);
        Task<int> GetTotalSeatsByCinemaAsync(int cinemaId);

        // Movies & showtimes
        Task<IEnumerable<Movie>> GetCinemaMoviesAsync(int cinemaId);
        Task<IEnumerable<Showtime>> GetCinemaShowtimesAsync(int cinemaId);
        Task<IEnumerable<Showtime>> GetCinemaShowtimesAsync(int cinemaId, DateTime date);
        Task<IEnumerable<Showtime>> GetCinemaMovieShowtimesAsync(int cinemaId, int movieId);

        // Location & search
        Task<IEnumerable<Cinema>> GetCinemasByLocationAsync(string location);
        Task<IEnumerable<Cinema>> GetNearbyCinemasAsync(double latitude, double longitude, double radiusKm);

        // Search & paging
        Task<IEnumerable<Cinema>> SearchCinemasAsync(string searchTerm);
        Task<(IEnumerable<Cinema> cinemas, int totalCount)> GetPagedCinemasAsync(BasePaginatedFilterVM filter);

        // Statistics & analytics
        Task<int> GetTotalBookingsByCinemaAsync(int cinemaId);
        Task<decimal> GetAverageOccupancyRateAsync(int cinemaId);
        Task<Dictionary<string, int>> GetCinemaLocationStats();

        // Validation & lifecycle
        Task<bool> IsCinemaNameUniqueAsync(string name, int? excludeId = null);
        Task<bool> CanDeleteCinemaAsync(int cinemaId);
        Task<bool> HasActiveShowtimesAsync(int cinemaId);
        Task<bool> HasHallsAsync(int cinemaId);

        // Popular & admin
        Task<IEnumerable<Cinema>> GetPopularCinemasAsync(int count = 5);
        Task<IEnumerable<Cinema>> GetCinemasForAdminAsync();

        // Helpers & utilities
        Task<IEnumerable<Cinema>> GetCinemasForDropdownAsync();
        Task<bool> ToggleCinemaStatusAsync(int cinemaId);
        Task<IEnumerable<string>> GetUniqueCitiesAsync();
        Task<IEnumerable<string>> GetUniqueStatesAsync();
    }
}
