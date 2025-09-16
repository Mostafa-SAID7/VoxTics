namespace VoxTics.Models.ViewModels.Showtime
{
    public class ShowtimeDetailsVM
    {
        
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public string MoviePosterImage { get; set; } = string.Empty;
        public int MovieDuration { get; set; }
        public int CinemaId { get; set; }
        public string CinemaName { get; set; } = string.Empty;
        public string CinemaAddress { get; set; } = string.Empty;
        public int HallId { get; set; }
        public string HallName { get; set; } = string.Empty;
        public DateTime ShowDateTime { get; set; }
        public decimal Price { get; set; }
        public ShowtimeStatus Status { get; set; }
        public int AvailableSeats { get; set; }
        public int TotalSeats { get; set; }
        public int BookedSeats => TotalSeats - AvailableSeats;

        // Computed properties
        public DateTime ShowDate => ShowDateTime.Date;
        public TimeSpan ShowTime => ShowDateTime.TimeOfDay;
        public string ShowTimeFormatted => ShowDateTime.ToString("HH:mm");
        public string ShowDateFormatted => ShowDateTime.ToString("MMM dd, yyyy");
        public bool IsAvailable => Status == ShowtimeStatus.Scheduled && AvailableSeats > 0;
        public bool IsSoldOut => AvailableSeats == 0;
        public double OccupancyPercentage => TotalSeats > 0 ? (double)BookedSeats / TotalSeats * 100 : 0;

    }
}
