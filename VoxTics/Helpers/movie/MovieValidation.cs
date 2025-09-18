namespace VoxTics.Helpers.movie
{
    public static class MovieValidation
    {
        public static bool ValidateMovieDates(DateTime releaseDate, DateTime? endDate)
        {
            if (endDate.HasValue)
                return releaseDate <= endDate.Value;

            return true;
        }

   

        public static bool ValidatePrice(decimal price)
        {
            return price >= 0;
        }
        public static bool IsValidMovieDuration(int duration, int minMinutes = 1, int maxMinutes = 600) =>
    duration >= minMinutes && duration <= maxMinutes;

        public static bool IsValidRating(double? rating)
        {
            if (!rating.HasValue)
                return true;

            return rating >= 0.0 && rating <= 10.0;
        }
    }
}
