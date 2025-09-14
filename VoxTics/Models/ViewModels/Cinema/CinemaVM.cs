using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VoxTics.Models.ViewModels.Showtime;

namespace VoxTics.Models.ViewModels.Cinema
{
    public class CinemaVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string DisplayImage { get; set; } = "/images/default-cinema.jpg";

        public int HallCount { get; set; }
        public int TotalSeats { get; set; }
        public int ShowtimeCount { get; set; }

        public bool IsActive { get; set; }
    }
}
