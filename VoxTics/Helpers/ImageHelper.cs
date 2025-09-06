using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace VoxTics.Helpers
{
    public static class ImageHelper
    {
        public static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
        public const long MaxFileSize = 5 * 1024 * 1024; // 5MB
        public const string DefaultImagePath = "/images/default.jpg";

        /// <summary>
        /// Checks if the file is a valid image according to extension and size.
        /// </summary>
        public static bool IsValidImageFile(IFormFile file)
        {
            if (file == null || file.Length == 0) return false;
            if (file.Length > MaxFileSize) return false;

            var extension = Path.GetExtension(file.FileName)?.ToLowerInvariant();
            return !string.IsNullOrEmpty(extension) && AllowedExtensions.Contains(extension);
        }

        /// <summary>
        /// Saves the image to the given path with optional file name. Returns the saved file name.
        /// </summary>
        public static async Task<string> SaveImageAsync(IFormFile file, string uploadPath, string? fileName = null)
        {
            if (!IsValidImageFile(file))
                throw new ArgumentException("Invalid image file");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            fileName ??= $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return fileName;
        }

        /// <summary>
        /// Deletes the image file if exists.
        /// </summary>
        public static bool DeleteImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath)) return false;

            try
            {
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                    return true;
                }
            }
            catch
            {
                // Log exception if necessary
            }

            return false;
        }

        /// <summary>
        /// Returns the public URL of the image, or default image if null/empty.
        /// </summary>
        public static string GetImageUrl(string? imageName, string? defaultImage = null)
        {
            return string.IsNullOrEmpty(imageName) ? (defaultImage ?? DefaultImagePath) : $"/images/{imageName}";
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
