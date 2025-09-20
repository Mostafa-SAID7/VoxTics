using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels.MovieVMs
{
    public class MovieListItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        // include these in case some views need them
        public string? Description { get; set; }
        public string? TrailerUrl { get; set; }

        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieStatus MovieStatus { get; set; }
        public string? ImgUrl { get; set; }

        // both id and friendly name
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? CinemaId { get; set; }
        public string? CinemaName { get; set; }
    }

}
