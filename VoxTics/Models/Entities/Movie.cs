using System.ComponentModel.DataAnnotations;
using VoxTics.Models.Enums;

namespace VoxTics.Models.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required, StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Range(0.0, 10000.0)]
        public decimal Price { get; set; }

        [Range(1, 600)]
        public int Duration { get; set; } // in minutes

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } = DateTime.Today;

        public MovieStatus Status { get; set; } = MovieStatus.Upcoming;

        /// <summary>
        /// Primary image URL stored (relative path under /uploads/movies)
        /// </summary>
        public string? ImageUrl { get; set; }

        // navigation
        public ICollection<MovieCategory> MovieCategories { get; set; } = new List<MovieCategory>();
        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
        public ICollection<MovieImg> MovieImgs { get; set; } = new List<MovieImg>();
        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
