using System;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class Cinema
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public string Name { get; set; } = string.Empty;

        public string? Phone { get; set; }
        public string Address { get; set; } = string.Empty;
        public string? Website { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<Hall> Halls { get; set; } = new List<Hall>();

        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}
