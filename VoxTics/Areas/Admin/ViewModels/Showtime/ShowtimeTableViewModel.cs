namespace VoxTics.Areas.Admin.ViewModels.Showtime
{
    public class ShowtimeTableViewModel
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public string HallName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Price { get; set; }

        public ShowtimeStatus Status { get; set; }

        // Computed display properties
        public string StatusBadge => Status switch
        {
            ShowtimeStatus.Scheduled => "badge bg-info",
            ShowtimeStatus.Active => "badge bg-success",
            ShowtimeStatus.Cancelled => "badge bg-danger",
            _ => "badge bg-secondary"
        };
    }
}
