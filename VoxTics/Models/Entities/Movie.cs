using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VoxTics.Models.Enums;

namespace VoxTics.Models.Entities
{
    public class Movie : BaseEntity
    {
        [Required, MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required, MaxLength(1000)]
        public string? Description { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string? Director { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }  

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }     

        [Required, Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes")]
        public int Duration { get; set; } // in minutes

        [Required, Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; } = 0m;

        [Range(0.0, 10.0)]
        public decimal? Rating { get; set; }

        [Required, StringLength(20)]
        public string? Language { get; set; } = "EN";

        [StringLength(50)]
        public string? Country { get; set; }

        [Url]
        public string? MainImage { get; set; }


        [Url]
        public string? TrailerUrl { get; set; }

        public bool IsFeatured { get; set; } = false;

        [Required]
        public MovieStatus Status { get; set; } = MovieStatus.Upcoming;

        [Required, MaxLength(150)]
        public string Slug { get; set; } = string.Empty;  // URL-friendly slug

        // Navigation properties
        public ICollection<Booking>? Bookings { get; set; } = new List<Booking>();
        public ICollection<Showtime>? Showtimes { get; set; } = new List<Showtime>();
        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
        public ICollection<MovieImg> MovieImages { get; set; } = new List<MovieImg>();

        // New relationships
        public ICollection<WatchlistItem>? WatchlistItems { get; set; } = new List<WatchlistItem>();
        public ICollection<CartItem>? CartItems { get; set; } = new List<CartItem>();

        // Category relationship
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }
        public int CinemaId { get; set; }  // just the foreign key
                                           // OR
        public Cinema Cinema { get; set; }
    }
}
