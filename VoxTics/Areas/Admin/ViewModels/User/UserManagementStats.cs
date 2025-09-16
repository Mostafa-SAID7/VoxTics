namespace VoxTics.Areas.Admin.ViewModels.User
{
    public class UserManagementStats
    {
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int InactiveUsers { get; set; }
        public int NewUsersToday { get; set; }
        public int UsersWithPendingBookings { get; set; }
    }
}
