using System.Text;
using System.Text.RegularExpressions;

namespace VoxTics.Helpers
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return string.Empty;

            string slug = title.ToLowerInvariant();

            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");

            slug = Regex.Replace(slug, @"\s+", "-").Trim('-');

            slug = Regex.Replace(slug, @"-+", "-");

            return slug;
        }
    }
}
