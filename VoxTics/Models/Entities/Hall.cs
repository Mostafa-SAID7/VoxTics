using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.Entities
{
    public class Hall : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, 1000, ErrorMessage = "Total seats must be between 1 and 1000")]
        public int TotalSeats { get; set; }

        [Required]
        public int CinemaId { get; set; }

        public string? Description { get; set; }

        // Navigation properties
        [ForeignKey("CinemaId")]
        public virtual Cinema Cinema { get; set; } = null!;

        public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

        public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}
