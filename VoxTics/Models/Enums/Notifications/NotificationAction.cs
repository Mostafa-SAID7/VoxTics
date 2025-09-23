namespace VoxTics.Models.Enums.Notifications
{
    public class NotificationAction
    {
        public string Label { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Method { get; set; } = "GET";
        public string CssClass { get; set; } = "btn-primary";
        public object? Data { get; set; }
    }
}
