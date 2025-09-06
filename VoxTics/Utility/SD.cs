
namespace VoxTics.Utility
{
    public static class SD
    {
        // Roles
        public const string Role_SuperAdmin = "SuperAdmin";
        public const string Role_Admin = "Admin";
        public const string Role_Manager = "Manager";
        public const string Role_User = "User";

        // Session Keys
        public const string SessionKey_UserId = "UserId";
        public const string SessionKey_UserRole = "UserRole";
        public const string SessionKey_UserName = "UserName";

        // Default Values
        public const int DefaultPageSize = 12;
        public const int AdminDefaultPageSize = 10;
        public const int MaxPageSize = 50;

        // File Upload
        public const string MovieImagePath = "uploads/movies";
        public const string ActorImagePath = "uploads/actors";
        public const string CinemaImagePath = "uploads/cinemas";
        public const string UserImagePath = "uploads/users";
        public const string CategoryImagePath = "uploads/categories";
        public const string BannerImagePath = "uploads/banners";

        public const long MaxFileSize = 5 * 1024 * 1024; // 5MB
        public static readonly string[] AllowedImageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };

        // Movie Status Display
        public static readonly Dictionary<int, string> MovieStatusNames = new Dictionary<int, string>
        {
            { 0, "Coming Soon" },
            { 1, "Now Playing" },
            { 2, "Ended" },
            { 3, "Cancelled" }
        };

        // Booking Status Display
        public static readonly Dictionary<int, string> BookingStatusNames = new Dictionary<int, string>
        {
            { 0, "Pending" },
            { 1, "Confirmed" },
            { 2, "Cancelled" },
            { 3, "Rejected" },
            { 4, "Completed" },
            { 5, "No Show" }
        };

        // Payment Status Display
        public static readonly Dictionary<int, string> PaymentStatusNames = new Dictionary<int, string>
        {
            { 0, "Pending" },
            { 1, "Processing" },
            { 2, "Completed" },
            { 3, "Failed" },
            { 4, "Refunded" },
            { 5, "Partially Refunded" }
        };

        // User Role Display
        public static readonly Dictionary<int, string> UserRoleNames = new Dictionary<int, string>
        {
            { 0, "Super Admin" },
            { 1, "Admin" },
            { 2, "Manager" },
            { 3, "User" }
        };

        // Seat Type Display
        public static readonly Dictionary<int, string> SeatTypeNames = new Dictionary<int, string>
        {
            { 0, "Regular" },
            { 1, "Premium" },
            { 2, "VIP" },
            { 3, "Recliner" },
            { 4, "Couple Seat" }
        };

        // Showtime Status Display
        public static readonly Dictionary<int, string> ShowtimeStatusNames = new Dictionary<int, string>
        {
            { 0, "Scheduled" },
            { 1, "Active" },
            { 2, "Completed" },
            { 3, "Cancelled" },
            { 4, "Postponed" }
        };

        // Bootstrap Classes for Status
        public static readonly Dictionary<int, string> BookingStatusClasses = new Dictionary<int, string>
        {
            { 0, "warning" },  // Pending
            { 1, "success" },  // Confirmed
            { 2, "danger" },   // Cancelled
            { 3, "danger" },   // Rejected
            { 4, "info" },     // Completed
            { 5, "secondary" } // No Show
        };

        public static readonly Dictionary<int, string> PaymentStatusClasses = new Dictionary<int, string>
        {
            { 0, "warning" },  // Pending
            { 1, "info" },     // Processing
            { 2, "success" },  // Completed
            { 3, "danger" },   // Failed
            { 4, "secondary" }, // Refunded
            { 5, "secondary" } // Partially Refunded
        };

        public static readonly Dictionary<int, string> MovieStatusClasses = new Dictionary<int, string>
        {
            { 0, "info" },     // Coming Soon
            { 1, "success" },  // Now Playing
            { 2, "secondary" }, // Ended
            { 3, "danger" }    // Cancelled
        };

        // Common Movie Ratings
        public static readonly List<string> MovieRatings = new List<string>
        {
            "G", "PG", "PG-13", "R", "NC-17", "NR", "UR"
        };

        // Common Languages
        public static readonly List<string> MovieLanguages = new List<string>
        {
            "English", "Arabic", "French", "Spanish", "German", "Italian", "Chinese", "Japanese", "Korean", "Hindi"
        };

        // Payment Methods
        public static readonly List<string> PaymentMethods = new List<string>
        {
            "Credit Card", "Debit Card", "PayPal", "Cash", "Bank Transfer", "Mobile Payment"
        };

        // Time Ranges for Filtering
        public static readonly Dictionary<string, (DateTime? Start, DateTime? End)> TimeRanges = new Dictionary<string, (DateTime?, DateTime?)>
        {
            { "today", (DateTime.Today, DateTime.Today.AddDays(1)) },
            { "yesterday", (DateTime.Today.AddDays(-1), DateTime.Today) },
            { "thisweek", (GetStartOfWeek(DateTime.Today), GetEndOfWeek(DateTime.Today)) },
            { "lastweek", (GetStartOfWeek(DateTime.Today.AddDays(-7)), GetEndOfWeek(DateTime.Today.AddDays(-7))) },
            { "thismonth", (new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1)) },
            { "lastmonth", (new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1), new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)) },
            { "thisyear", (new DateTime(DateTime.Today.Year, 1, 1), new DateTime(DateTime.Today.Year + 1, 1, 1)) },
            { "lastyear", (new DateTime(DateTime.Today.Year - 1, 1, 1), new DateTime(DateTime.Today.Year, 1, 1)) }
        };

        // Helper Methods
        private static DateTime GetStartOfWeek(DateTime date)
        {
            var diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private static DateTime GetEndOfWeek(DateTime date)
        {
            return GetStartOfWeek(date).AddDays(7);
        }

        public static string GetStatusClass(string statusType, int statusValue)
        {
            return statusType.ToLower() switch
            {
                "booking" => BookingStatusClasses.GetValueOrDefault(statusValue, "secondary"),
                "payment" => PaymentStatusClasses.GetValueOrDefault(statusValue, "secondary"),
                "movie" => MovieStatusClasses.GetValueOrDefault(statusValue, "secondary"),
                _ => "secondary"
            };
        }

        public static string GetStatusName(string statusType, int statusValue)
        {
            return statusType.ToLower() switch
            {
                "booking" => BookingStatusNames.GetValueOrDefault(statusValue, "Unknown"),
                "payment" => PaymentStatusNames.GetValueOrDefault(statusValue, "Unknown"),
                "movie" => MovieStatusNames.GetValueOrDefault(statusValue, "Unknown"),
                "user" => UserRoleNames.GetValueOrDefault(statusValue, "Unknown"),
                "seat" => SeatTypeNames.GetValueOrDefault(statusValue, "Unknown"),
                "showtime" => ShowtimeStatusNames.GetValueOrDefault(statusValue, "Unknown"),
                _ => "Unknown"
            };
        }

        public static bool IsValidImageFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return AllowedImageExtensions.Contains(extension);
        }

        public static string GenerateBookingNumber()
        {
            return $"BK{DateTime.Now:yyyyMMdd}{DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 6)}";
        }

        public static string FormatCurrency(decimal amount)
        {
            return amount.ToString("C");
        }

        public static string FormatDateTime(DateTime dateTime, string format = "MMM dd, yyyy hh:mm tt")
        {
            return dateTime.ToString(format);
        }

        public static string FormatDuration(int minutes)
        {
            var hours = minutes / 60;
            var remainingMinutes = minutes % 60;
            return hours > 0 ? $"{hours}h {remainingMinutes}m" : $"{remainingMinutes}m";
        }

        public static string TruncateText(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
                return text;

            return text.Substring(0, maxLength) + "...";
        }

        public static (DateTime Start, DateTime End) GetDateRange(string range)
        {
            if (TimeRanges.TryGetValue(range.ToLower(), out var dateRange))
            {
                return (dateRange.Start ?? DateTime.MinValue, dateRange.End ?? DateTime.MaxValue);
            }

            return (DateTime.MinValue, DateTime.MaxValue);
        }
    }
}