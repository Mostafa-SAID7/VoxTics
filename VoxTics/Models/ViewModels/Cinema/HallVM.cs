using Mono.TextTemplating;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Showtime;

namespace VoxTics.Models.ViewModels.Cinema
{
    public class HallVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [NotMapped]
        public int SeatCount => Seats?.Count ?? 0;
        public bool IsActive { get; set; } = true;

        // Cinema info
        public int CinemaId { get; set; }
        public string CinemaName { get; set; } = string.Empty;
        public int TotalSeats { get; set; }

        // Optional: Showtimes info
        public int ShowtimeCount => Showtimes?.Count ?? 0;
        public List<ShowtimeVM> Showtimes { get; set; } = new List<ShowtimeVM>();

        // Optional: Computed display property
        public string SeatSummary => SeatCount == 1 ? "1 Seat" : $"{SeatCount} Seats";
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
        public bool HasShowtimes => ShowtimeCount > 0;
    }
}
