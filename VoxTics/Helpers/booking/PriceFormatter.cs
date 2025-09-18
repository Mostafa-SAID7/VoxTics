using System.Globalization;

namespace VoxTics.Helpers.booking
{
    public static class PriceFormatter
    {
        private static readonly CultureInfo DefaultCulture = new CultureInfo("en-US");

        /// <summary>
        /// Formats price with fixed 2 decimals and optional currency symbol.
        /// </summary>
        public static string FormatPrice(decimal price, string currencySymbol = "$")
        {
            return $"{currencySymbol}{price:F2}";
        }

        /// <summary>
        /// Formats price using a specific culture.
        /// </summary>
        public static string FormatPrice(decimal price, CultureInfo culture)
        {
            return price.ToString("C", culture ?? DefaultCulture);
        }

        /// <summary>
        /// Formats price with currency code (e.g., 10.00 USD)
        /// </summary>
        public static string FormatPriceWithCurrency(decimal price, string currencyCode = "USD")
        {
            return $"{price:F2} {currencyCode}";
        }

        /// <summary>
        /// Formats a price range (e.g., 10.00 - 20.00)
        /// </summary>
        public static string FormatPriceRange(decimal minPrice, decimal maxPrice, string currencySymbol = "$")
        {
            if (minPrice == maxPrice)
                return FormatPrice(minPrice, currencySymbol);

            return $"{FormatPrice(minPrice, currencySymbol)} - {FormatPrice(maxPrice, currencySymbol)}";
        }

        /// <summary>
        /// Formats discounted price with original price and percentage.
        /// </summary>
        public static string FormatDiscount(decimal originalPrice, decimal discountedPrice, string currencySymbol = "$")
        {
            if (originalPrice <= 0) return FormatPrice(discountedPrice, currencySymbol);

            var discountAmount = originalPrice - discountedPrice;
            var discountPercentage = discountAmount / originalPrice * 100;

            return $"{FormatPrice(discountedPrice, currencySymbol)} " +
                   $"<strike>{FormatPrice(originalPrice, currencySymbol)}</strike> " +
                   $"({discountPercentage:F0}% off)";
        }

        /// <summary>
        /// Parses a price string and removes common currency symbols.
        /// </summary>
        public static decimal ParsePrice(string priceString)
        {
            if (string.IsNullOrWhiteSpace(priceString)) return 0m;

            var cleanPrice = new string(priceString.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());
            return decimal.TryParse(cleanPrice, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) ? result : 0m;
        }

        /// <summary>
        /// Checks if price is valid (>=0 and <= 9999.99)
        /// </summary>
        public static bool IsValidPrice(decimal price)
        {
            return price >= 0 && price <= 9999.99m;
        }

        /// <summary>
        /// Returns formatted total from a collection of prices.
        /// </summary>
        public static string GetFormattedTotal(IEnumerable<decimal> prices, string currencySymbol = "$")
        {
            var total = prices?.Sum() ?? 0m;
            return FormatPrice(total, currencySymbol);
        }
    }
}
