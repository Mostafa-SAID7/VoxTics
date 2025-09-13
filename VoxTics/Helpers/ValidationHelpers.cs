using System;
using System.IO;
using System.Linq;
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

            var digitsOnly = Regex.Replace(phoneNumber, @"\D", "");
            return digitsOnly.Length >= 10 && digitsOnly.Length <= 15;
        }

        public static bool IsValidPassword(string password, int minLength = 6)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            return password.Length >= minLength;
        }

        // Overload that accepts System.Uri
        public static bool IsValidUrl(string url) => IsValidUrl(new Uri(url, UriKind.RelativeOrAbsolute));

        public static bool IsValidUrl(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            return url.IsAbsoluteUri &&
                   (url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps);
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

        public static bool IsValidDateRange(DateTime startDate, DateTime endDate) =>
            endDate >= startDate;

        public static bool IsValidShowtime(DateTime showDateTime)
        {
            // Show must be in the future
            if (showDateTime <= DateTime.Now)
                return false;

            // Show must not be too far in the future (e.g., 1 year)
            if (showDateTime > DateTime.Now.AddYears(1))
                return false;

            return true;
        }

        public static bool IsValidSeatCount(int seatCount, int minSeats = 1, int maxSeats = 500) =>
            seatCount >= minSeats && seatCount <= maxSeats;

        public static bool IsValidMovieDuration(int duration, int minMinutes = 1, int maxMinutes = 600) =>
            duration >= minMinutes && duration <= maxMinutes;

        public static bool IsValidRating(double? rating)
        {
            if (!rating.HasValue)
                return true;

            return rating >= 0.0 && rating <= 10.0;
        }

        public static string SanitizeInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return input.Trim()
                        .Replace("<script>", "", StringComparison.OrdinalIgnoreCase)
                        .Replace("</script>", "", StringComparison.OrdinalIgnoreCase)
                        .Replace("javascript:", "", StringComparison.OrdinalIgnoreCase)
                        .Replace("vbscript:", "", StringComparison.OrdinalIgnoreCase);
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

            var validExtensions = new[] { ".JPG", ".JPEG", ".PNG", ".GIF", ".BMP", ".WEBP" };
            var extension = Path.GetExtension(fileName)?.ToUpperInvariant();

            return !string.IsNullOrEmpty(extension) && validExtensions.Contains(extension);
        }

        public static bool IsValidFileSize(long fileSize, long maxSizeInBytes = 5 * 1024 * 1024) =>
            fileSize > 0 && fileSize <= maxSizeInBytes;
    }
}
