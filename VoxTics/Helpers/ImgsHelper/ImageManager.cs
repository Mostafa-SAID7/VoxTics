using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace VoxTics.Helpers.ImgsHelper
{
    public class ImageManager
    {
        private readonly ImageSettings _settings;

        public ImageManager(IOptions<ImageSettings> options)
        {
            _settings = options.Value;
        }

        #region Validation
        public bool IsValidImageFile(IFormFile file)
        {
            if (file == null || file.Length == 0) return false;
            if (file.Length > _settings.MaxFileSize) return false;

            var ext = Path.GetExtension(file.FileName)?.ToUpperInvariant();
            return !string.IsNullOrEmpty(ext) && _settings.AllowedExtensions.Contains(ext);
        }

        public static bool IsValidUrl(string url) =>
            Uri.TryCreate(url, UriKind.Absolute, out var uri) &&
            (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        #endregion

        #region Folder Helpers
        private string GetFolder(ImageType type, string entityName)
        {
            if (string.IsNullOrWhiteSpace(entityName))
                throw new ArgumentNullException(nameof(entityName));

            string folder = type switch
            {
                ImageType.Movie => Path.Combine(_settings.UploadsFolderMovies, entityName),
                ImageType.Actor => Path.Combine(_settings.UploadsFolderActors, entityName),
                ImageType.User => Path.Combine(_settings.UploadsFolderUsers, entityName),
                ImageType.Cinema => Path.Combine(_settings.UploadsFolderCinemas, entityName),
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            return folder;
        }

        private string GetDefaultImage(ImageType type) => type switch
        {
            ImageType.Movie => _settings.DefaultMovieImage,
            ImageType.Actor => _settings.DefaultActorImage,
            ImageType.User => _settings.DefaultUserImage,
            ImageType.Cinema => _settings.DefaultCinemaImage,
            _ => _settings.DefaultMovieImage
        };
        #endregion

        #region Save & Hash
        public async Task<string> SaveImageAsync(IFormFile file, ImageType type, string entityName, bool setAsMain = false)
        {
            if (!IsValidImageFile(file))
                throw new ArgumentException("Invalid image file", nameof(file));

            string folder = GetFolder(type, entityName);

            // Compute hash to avoid duplicates
            string newFileHash;
            using (var sha = SHA256.Create())
            using (var stream = file.OpenReadStream())
                newFileHash = BitConverter.ToString(sha.ComputeHash(stream))
                    .Replace("-", "").ToLowerInvariant();

            foreach (var existingFile in Directory.GetFiles(folder))
            {
                using var fs = new FileStream(existingFile, FileMode.Open, FileAccess.Read);
                using var sha = SHA256.Create();
                var existingHash = BitConverter.ToString(sha.ComputeHash(fs))
                    .Replace("-", "").ToLowerInvariant();

                if (existingHash == newFileHash)
                    return Path.GetFileName(existingFile); // already exists
            }

            // Save new image
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string filePath = Path.Combine(folder, fileName);

            await using var outputStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true);
            await file.CopyToAsync(outputStream).ConfigureAwait(false);

            // Optional: set as main image for movies
            if (setAsMain && type == ImageType.Movie)
            {
                string mainFile = Path.Combine(folder, "main" + Path.GetExtension(file.FileName));
                if (File.Exists(mainFile)) File.Delete(mainFile);
                File.Copy(filePath, mainFile);
            }

            return fileName;
        }
        #endregion

        #region Get Images
        public string[] GetImages(ImageType type, string entityName)
        {
            string folder = GetFolder(type, entityName);
            var files = Directory.GetFiles(folder).Select(Path.GetFileName).ToArray();
            return files.Length == 0 ? new[] { GetDefaultImage(type) } : files;
        }

        public Uri GetImageUrl(ImageType type, string entityName, string? imageName = null)
        {
            string folder = GetFolder(type, entityName);
            string path = !string.IsNullOrEmpty(imageName) && File.Exists(Path.Combine(folder, imageName))
                ? Path.Combine(folder, imageName)
                : GetDefaultImage(type);

            return new Uri(path, UriKind.RelativeOrAbsolute);
        }
        #endregion

        #region Delete
        public bool DeleteFolder(ImageType type, string entityName)
        {
            string folder = GetFolder(type, entityName);
            if (!Directory.Exists(folder)) return false;

            try
            {
                Directory.Delete(folder, true);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Resize
        public async Task<string> ResizeImageAsync(ImageType type, string entityName, string imageName, int width, int height)
        {
            string folder = GetFolder(type, entityName);
            string filePath = Path.Combine(folder, imageName);

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Image not found", filePath);

            string resizedFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageName)}";
            string resizedFilePath = Path.Combine(folder, resizedFileName);

            using var image = await Image.LoadAsync(filePath);
            image.Mutate(x => x.Resize(width, height));
            await image.SaveAsync(resizedFilePath);

            return resizedFileName;
        }
        #endregion
    }
}
