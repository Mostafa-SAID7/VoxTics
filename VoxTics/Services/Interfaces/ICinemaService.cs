using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.ViewModels.Cinema;

namespace VoxTics.Services.Interfaces
{
    public interface ICinemaService
    {
        /// <summary>Returns active cinemas for user-facing listings.</summary>
        Task<IEnumerable<CinemaVM>> GetActiveCinemasAsync(CancellationToken cancellationToken = default);

        /// <summary>Returns paged cinemas with optional search/sort for admin or list pages.</summary>
        Task<(IEnumerable<CinemaVM> Items, int TotalCount)> GetPagedCinemasAsync(
            int page,
            int pageSize,
            string? search,
            string? sort,
            CancellationToken cancellationToken = default);

        /// <summary>Gets detailed info for a specific cinema including halls, showtimes, and bookings.</summary>
        Task<CinemaDetailsVM?> GetCinemaDetailsAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>Gets all gallery image filenames for a cinema.</summary>
        Task<string[]> GetCinemaImagesAsync(int cinemaId);

        /// <summary>Builds a full web path for a cinema image or fallback if not found.</summary>
        string GetCinemaImageWebPath(int cinemaId, string? imageName = null);

        /// <summary>Gets the primary (main) display image for a cinema.</summary>
        string GetMainCinemaImagePath(int cinemaId, string? displayImage);
    }
}
