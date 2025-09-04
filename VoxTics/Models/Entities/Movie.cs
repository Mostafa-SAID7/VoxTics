using System;
using System.Collections.Generic;
using VoxTics.Models.Enums;

namespace VoxTics.Models.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Duration { get; set; } // minutes
        public DateTime ReleaseDate { get; set; } = DateTime.Today;
        public MovieStatus Status { get; set; } = MovieStatus.Upcoming;

        // Navigation
        public ICollection<MovieCategory> MovieCategories { get; set; } = new List<MovieCategory>();
        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
        public ICollection<MovieImg> Images { get; set; } = new List<MovieImg>();
        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
