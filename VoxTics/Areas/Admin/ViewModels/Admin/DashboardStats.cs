namespace VoxTics.Areas.Admin.ViewModels.Admin
{
    public class DashboardStats
    {
        public int TotalBookings { get; set; }
        public int TodayBookings { get; set; }
        public int WeeklyBookings { get; set; }
        public decimal TotalRevenue { get; set; }

        public int TotalMovies { get; set; }
        public int UpcomingMovies { get; set; }
        public int FeaturedMovies { get; set; }

        public int TotalUsers { get; set; }
        public int NewUsersToday { get; set; }

        public int ActiveShowtimes { get; set; }
        public int ShowtimesToday { get; set; }
    }
}
