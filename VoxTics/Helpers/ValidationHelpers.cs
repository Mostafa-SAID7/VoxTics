using System.Text.RegularExpressions;

namespace VoxTics.Helpers
{
    public static class ValidationHelpers
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
                return emailRegex.IsMatch(email);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // Remove all non-digit characters
            var digitsOnly = Regex.Replace(phoneNumber, @"\D", "");

            // Check if it's between 10-15 digits (international format)
            return digitsOnly.Length >= 10 && digitsOnly.Length <= 15;
        }

        public static bool IsValidPassword(string password, int minLength = 6)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            return password.Length >= minLength;
        }

        public static bool IsValidUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;

            return Uri.TryCreate(url, UriKind.Absolute, out var result) &&
                   (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
        }

        public static bool IsValidAge(DateTime? birthDate, int minAge = 0, int maxAge = 120)
        {
            if (!birthDate.HasValue)
                return false;

            var age = DateTime.Today.Year - birthDate.Value.Year;
            if (birthDate.Value.Date > DateTime.Today.AddYears(-age))
                age--;

            return age >= minAge && age <= maxAge;
        }

        public static bool IsValidDateRange(DateTime startDate, DateTime endDate)
        {
            return endDate >= startDate;
        }

        public static bool IsValidShowtime(DateTime showDateTime, int movieDuration)
        {
            // Show must be in the future
            if (showDateTime <= DateTime.Now)
                return false;

            // Show must not be too far in the future (e.g., 1 year)
            if (showDateTime > DateTime.Now.AddYears(1))
                return false;

            return true;
        }

        public static bool IsValidSeatCount(int seatCount, int minSeats = 1, int maxSeats = 500)
        {
            return seatCount >= minSeats && seatCount <= maxSeats;
        }

        public static bool IsValidMovieDuration(int duration, int minMinutes = 1, int maxMinutes = 600)
        {
            return duration >= minMinutes && duration <= maxMinutes;
        }

        public static bool IsValidRating(double? rating)
        {
            if (!rating.HasValue)
                return true; // Rating is optional

            return rating >= 0.0 && rating <= 10.0;
        }

        public static string SanitizeInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return input.Trim()
                       .Replace("<script>", "")
                       .Replace("</script>", "")
                       .Replace("javascript:", "")
                       .Replace("vbscript:", "");
        }

        public static bool ContainsOnlyLetters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return input.All(char.IsLetter);
        }

        public static bool ContainsOnlyLettersAndSpaces(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        public static bool IsValidImageFormat(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return false;

            var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
            var extension = Path.GetExtension(fileName).ToLowerInvariant();

            return validExtensions.Contains(extension);
        }

        public static bool IsValidFileSize(long fileSize, long maxSizeInBytes = 5 * 1024 * 1024) // 5MB default
        {
            return fileSize > 0 && fileSize <= maxSizeInBytes;
        }
    }
}
