namespace VoxTics.Helpers
{
    public static class EmailTemplateHelper
    {
        private static readonly string BasePath = Path.Combine(Directory.GetCurrentDirectory(), "TempHtml", "EmailTemplates");

        public static async Task<string> LoadTemplateAsync(string templateName)
        {
            var filePath = Path.Combine(BasePath, templateName);
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Email template {templateName} not found", filePath);

            return await File.ReadAllTextAsync(filePath);
        }
        public static string ReplacePlaceholders(string template, object placeholders)
        {
            var result = template;
            if (placeholders == null) return template;

            foreach (var prop in placeholders.GetType().GetProperties())
            {
                var value = prop.GetValue(placeholders)?.ToString() ?? string.Empty;
                result = result.Replace($"{{{{{prop.Name}}}}}", value); // e.g., {{UserName}}, {{OTPCode}}
            }

            return result;
        }
    }
}
