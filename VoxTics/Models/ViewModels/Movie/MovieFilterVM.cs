using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels.Filter;

namespace VoxTics.Models.ViewModels.Movie
{

    public class MovieFilterVM : PaginatedFilterVM
    {
        // Filtering
        public string? SearchTerm { get; set; }
        public DateTime? ReleaseStartDate { get; set; }
        public DateTime? ReleaseEndDate { get; set; }

        // Movie-specific filters
        public MovieStatus? Status { get; set; }
        public int? CategoryId { get; set; }
        public int? CinemaId { get; set; }
        public int? ReleaseYear { get; set; }
        public decimal? MinRating { get; set; }
        public decimal? MaxRating { get; set; }
    }
}
