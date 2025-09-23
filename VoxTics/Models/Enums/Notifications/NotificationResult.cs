namespace VoxTics.Models.Enums.Notifications
{
    public class NotificationResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? NotificationId { get; set; }
        public List<Notification>? Notifications { get; set; }
        public object? Data { get; set; }
    }
}
