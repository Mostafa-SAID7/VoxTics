using VoxTics.Helpers.Filters.Sorting;

namespace VoxTics.Helpers.Filters
{
    public class BookingFilter : FilterBase<BookingSortBy>
    {
        public BookingStatus? Status { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? UserId { get; set; }
        public int? CinemaId { get; set; }
        public int? ShowtimeId { get; set; }
        public decimal? MinTotal { get; set; }
        public decimal? MaxTotal { get; set; }
    }
}
