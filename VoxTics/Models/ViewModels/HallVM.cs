using System.Collections.Generic;
using System.Linq;
using VoxTics.Models.Entities;

namespace VoxTics.Models.ViewModels
{
    public class HallVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SeatCount { get; set; }
        public bool IsActive { get; set; } = true;

        // Cinema info
        public int CinemaId { get; set; }
        public string CinemaName { get; set; } = string.Empty;

        // Optional: Showtimes info
        public int ShowtimeCount => Showtimes?.Count ?? 0;
        public List<ShowtimeVM> Showtimes { get; set; } = new List<ShowtimeVM>();

        // Optional: Computed display property
        public string SeatSummary => SeatCount == 1 ? "1 Seat" : $"{SeatCount} Seats";
        public bool HasShowtimes => ShowtimeCount > 0;
    }
}
