using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VoxTics.Models.Enums;

namespace VoxTics.Models.Entities
{
    public class Movie : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Director { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes")]
        public int Duration { get; set; } // match repo’s DurationMinutes usage

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }

        [Range(0.0, 10.0)]
        public decimal Rating { get; set; }  // repo expects decimal, not nullable double

        [Required]
        [StringLength(20)]
        public string Language { get; set; } = "EN";

        [StringLength(50)]
        public string? Country { get; set; }

        [StringLength(10)]
        public string? AgeRating { get; set; }

        public string? ImageUrl { get; set; }
        public string? TrailerImageUrl { get; set; }

        public bool IsFeatured { get; set; } = false; // repo uses this for GetFeaturedMoviesAsync

        [Required]
        public MovieStatus Status { get; set; } = MovieStatus.Upcoming;
        public string? TrailerUrl { get; set; }
        public string ShortDescription { get; set; } = string.Empty;
        // Navigation properties
        public virtual ICollection<MovieCategory> MovieCategories { get; set; } = new List<MovieCategory>();
        public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
        public virtual ICollection<MovieImg> MovieImages { get; set; } = new List<MovieImg>();
        public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        // ✅ Optional: Social media links for the movie
        public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();
    }
}
