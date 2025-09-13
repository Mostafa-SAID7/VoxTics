using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace VoxTics.Helpers
{
    public static class ImageHelper
    {
        public static readonly string[] AllowedExtensions = { ".JPG", ".JPEG", ".PNG", ".GIF", ".BMP", ".WEBP" };
        public const long MaxFileSize = 5 * 1024 * 1024; // 5MB
        public const string DefaultImagePath = "/images/default.jpg";

        /// <summary>
        /// Checks if the file is a valid image according to extension and size.
        /// </summary>
        public static bool IsValidImageFile(IFormFile file)
        {
            if (file == null || file.Length == 0) return false;
            if (file.Length > MaxFileSize) return false;

            // Use ToUpperInvariant for consistent comparison
            var extension = Path.GetExtension(file.FileName)?.ToUpperInvariant();
            return !string.IsNullOrEmpty(extension) && AllowedExtensions.Contains(extension);
        }

        /// <summary>
        /// Saves the image to the given path with optional file name. Returns the saved file name.
        /// </summary>
        public static async Task<string> SaveImageAsync(IFormFile file, string uploadPath, string? fileName = null)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            if (!IsValidImageFile(file))
                throw new ArgumentException("Invalid image file", nameof(file));

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            fileName ??= $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            await using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true);
            await file.CopyToAsync(stream).ConfigureAwait(false);

            return fileName;
        }

        /// <summary>
        /// Deletes the image file if it exists.
        /// </summary>
        public static bool DeleteImage(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath)) return false;

            try
            {
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                    return true;
                }
            }
            catch (IOException ioEx)
            {
                // Log warning if necessary
                Console.WriteLine($"DeleteImage failed: {ioEx.Message}");
            }
            catch (UnauthorizedAccessException uaEx)
            {
                Console.WriteLine($"DeleteImage failed due to permissions: {uaEx.Message}");
            }

            return false;
        }

        /// <summary>
        /// Returns the public URL of the image as a Uri, or default image if null/empty.
        /// </summary>
        public static Uri GetImageUrl(string? imageName, string? defaultImage = null)
        {
            var imagePath = string.IsNullOrEmpty(imageName) ? (defaultImage ?? DefaultImagePath) : $"/images/{imageName}";
            return new Uri(imagePath, UriKind.RelativeOrAbsolute);
        }

        /// <summary>
        /// Placeholder for image resizing using an external library (ImageSharp, SkiaSharp, etc.)
        /// </summary>
        public static Task<string> ResizeImageAsync(string imagePath, int width, int height)
        {
            throw new NotImplementedException("Image resizing requires an image processing library.");
        }
    }
}
