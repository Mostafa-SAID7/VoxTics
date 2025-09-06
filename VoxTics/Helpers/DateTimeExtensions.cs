using System;

namespace VoxTics.Helpers
{
    public static class DateTimeExtensions
    {
        #region Formatting Helpers

        public static string ToShortDateString(this DateTime dateTime)
        {
            return dateTime.ToString("MMM dd, yyyy");
        }

        public static string ToShortTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm");
        }

        public static string ToFullDateTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("MMM dd, yyyy HH:mm");
        }

        #endregion

        #region Relative Time

        /// <summary>
        /// Returns relative time string like "Just now", "5 minutes ago", "2 hours ago"
        /// </summary>
        public static string ToRelativeTimeString(this DateTime dateTime, bool useUtc = true)
        {
            var now = useUtc ? DateTime.UtcNow : DateTime.Now;
            var ts = now - dateTime;

            if (ts <= TimeSpan.FromSeconds(60)) return "Just now";
            if (ts <= TimeSpan.FromMinutes(60)) return $"{ts.Minutes} minute{(ts.Minutes == 1 ? "" : "s")} ago";
            if (ts <= TimeSpan.FromHours(24)) return $"{ts.Hours} hour{(ts.Hours == 1 ? "" : "s")} ago";
            if (ts <= TimeSpan.FromDays(30)) return $"{ts.Days} day{(ts.Days == 1 ? "" : "s")} ago";

            if (ts <= TimeSpan.FromDays(365))
            {
                var months = (int)(ts.Days / 30.44);
                return $"{months} month{(months == 1 ? "" : "s")} ago";
            }

            var years = (int)(ts.Days / 365.25);
            return $"{years} year{(years == 1 ? "" : "s")} ago";
        }

        #endregion

        #region Date Checks

        public static bool IsToday(this DateTime dateTime)
        {
            return dateTime.Date == DateTime.Today;
        }

        public static bool IsThisWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            var start = dateTime.StartOfWeek(startOfWeek);
            var end = dateTime.EndOfWeek(startOfWeek);
            return dateTime.Date >= start && dateTime.Date <= end;
        }

        public static bool IsThisMonth(this DateTime dateTime)
        {
            return dateTime.Month == DateTime.Today.Month && dateTime.Year == DateTime.Today.Year;
        }

        public static bool IsThisYear(this DateTime dateTime)
        {
            return dateTime.Year == DateTime.Today.Year;
        }

        #endregion

        #region Start / End of Day, Week, Month

        public static DateTime StartOfDay(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        public static DateTime EndOfDay(this DateTime dateTime)
        {
            return dateTime.Date.AddDays(1).AddTicks(-1);
        }

        public static DateTime StartOfWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int diff = (7 + (dateTime.DayOfWeek - startOfWeek)) % 7;
            return dateTime.AddDays(-diff).Date;
        }

        public static DateTime EndOfWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            return dateTime.StartOfWeek(startOfWeek).AddDays(7).AddTicks(-1);
        }

        public static DateTime StartOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public static DateTime EndOfMonth(this DateTime dateTime)
        {
            return dateTime.StartOfMonth().AddMonths(1).AddTicks(-1);
        }

        #endregion

        #region Age Helper

        /// <summary>
        /// Returns age in years as string for a nullable birth date
        /// </summary>
        public static string ToAgeString(this DateTime? birthDate)
        {
            if (!birthDate.HasValue) return "N/A";

            var age = DateTime.Today.Year - birthDate.Value.Year;
            if (birthDate.Value.Date > DateTime.Today.AddYears(-age))
                age--;

            return $"{age} years old";
        }

        #endregion
    }
}
