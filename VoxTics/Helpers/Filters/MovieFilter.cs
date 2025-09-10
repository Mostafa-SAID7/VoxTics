using VoxTics.Models.Enums.Sorting;

namespace VoxTics.Helpers.Filters
{
    public class MovieFilter : FilterBase<MovieSortBy>
    {
        public MovieStatus? Status { get; set; }
        public decimal? MinRating { get; set; }
        public decimal? MaxRating { get; set; }
        public DateTime? ReleaseFrom { get; set; }
        public DateTime? ReleaseTo { get; set; }
        public bool? IsFeatured { get; set; }
        public int? CategoryId { get; set; }
    }

}
