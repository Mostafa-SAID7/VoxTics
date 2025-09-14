using VoxTics.Helpers.Filters.Sorting;

namespace VoxTics.Helpers.Filters
{
    public class ShowtimeFilter : FilterBase<ShowtimeSortBy>
    {
        public ShowtimeStatus? Status { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? MovieId { get; set; }
        public int? CinemaId { get; set; }
        public int? HallId { get; set; }
        public bool? Is3D { get; set; }
        public string? Language { get; set; }
    }
}
