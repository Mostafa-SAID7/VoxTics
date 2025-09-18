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

  

        public static bool ValidateSeatNumber(string seatNumber, char maxRow = 'Z', int maxSeatPerRow = 100)
        {
            if (string.IsNullOrWhiteSpace(seatNumber))
                return false;

            // Example valid pattern: A10 or B5 or Z99
            var match = Regex.Match(seatNumber.Trim().ToUpperInvariant(), @"^([A-Z])(\d{1,3})$");
            if (!match.Success) return false;

            var row = match.Groups[1].Value[0];
            if (row > char.ToUpperInvariant(maxRow))
                return false;

            if (!int.TryParse(match.Groups[2].Value, out var seat) || seat < 1 || seat > maxSeatPerRow)
                return false;

            return true;
        }
        public static List<string> ValidateEntity(object entity)
        {
            var errors = new List<string>();
            if (entity == null)
            {
                errors.Add("Entity cannot be null.");
                return errors;
            }

            switch (entity)
            {
                case Cinema cinema:
                    if (string.IsNullOrWhiteSpace(cinema.Name))
                        errors.Add("Cinema name is required.");
                    if (!string.IsNullOrWhiteSpace(cinema.Email) && !IsValidEmail(cinema.Email))
                        errors.Add("Cinema email is invalid.");
                    if (!string.IsNullOrWhiteSpace(cinema.Phone) && !IsValidPhoneNumber(cinema.Phone))
                        errors.Add("Cinema phone number is invalid.");
                    if (!IsValidSeatCount(cinema.TotalSeats))
                        errors.Add($"Cinema seat count must be between 1 and 500.");
                    break;

                case Movie movie:
                    if (string.IsNullOrWhiteSpace(movie.Title))
                        errors.Add("Movie title is required.");
            
                    break;

                case Booking booking:
                    if (booking.TotalPrice < 0)
                        errors.Add("Booking total price cannot be negative.");
                    if (!IsValidShowtime(booking.Showtime?.StartTime ?? DateTime.MinValue))
                        errors.Add("Booking showtime is invalid.");
                    break;

                case Hall hall:
                    if (string.IsNullOrWhiteSpace(hall.Name))
                        errors.Add("Hall name is required.");
                    if (!IsValidSeatCount(hall.SeatCount))
                        errors.Add($"Hall seat count must be between 1 and 500.");
                    break;

                default:
                    errors.Add($"Validation not implemented for type {entity.GetType().Name}.");
                    break;
            }

            return errors;
        }




    }
}
