namespace VoxTics.Models.ViewModels.Showtime
{
    public class ShowtimePageVM
    {
        // Filter & Pagination (optional)
        public int? MovieId { get; set; }
        public int? CinemaId { get; set; }
        public DateTime? Date { get; set; }

        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 12;
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public List<int> PageNumbers { get; set; } = new List<int>();

        // Showtimes list
        public List<ShowtimeVM> Showtimes { get; set; } = new List<ShowtimeVM>();
    }
}
