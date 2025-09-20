using System.ComponentModel.DataAnnotations;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels.MovieVMs
{
    public class MovieFilterVM
    {
        public string? Search { get; set; }
        public int? CategoryId { get; set; }
        public int? CinemaId { get; set; }
        public MovieStatus? Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime? From { get; set; }
        [DataType(DataType.Date)]
        public DateTime? To { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        // paging & sort
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SortBy { get; set; } = "Title";
    }
}
