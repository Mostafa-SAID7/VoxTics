namespace VoxTics.Areas.Identity.Models.Entities
{
    public class EmailResult
    {
        /// <summary>
        /// Indicates whether the email was sent successfully.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// An optional error message if sending failed.
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Optional unique identifier for tracking the email.
        /// </summary>
        public string? MessageId { get; set; }

        /// <summary>
        /// Optional additional metadata or diagnostic info.
        /// </summary>
        public object? Data { get; set; }
    }
}
