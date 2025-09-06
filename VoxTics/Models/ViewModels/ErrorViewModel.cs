namespace VoxTics.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string Title { get; set; } = "An error occurred";
        public string Message { get; set; } = "Something went wrong. Please try again later.";
        public int StatusCode { get; set; } = 404;
    }
}
