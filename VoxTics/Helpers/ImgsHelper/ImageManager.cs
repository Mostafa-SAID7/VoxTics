using Microsoft.AspNetCore.Hosting;
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
        private readonly string _webRootPath;

        public ImageManager(IOptions<ImageSettings> options, IWebHostEnvironment env)
        {
            _settings = options?.Value ?? throw new ArgumentNullException(nameof(options));
            _webRootPath = env?.WebRootPath ?? throw new ArgumentNullException(nameof(env.WebRootPath));
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
        private string NormalizeRelativeFolder(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                throw new ArgumentNullException(nameof(relativePath));

            var cleaned = relativePath.TrimStart('~', '/', '\\');
            return cleaned.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar);
        }

        private string GetFolder(ImageType type, string entityName)
        {
            if (string.IsNullOrWhiteSpace(entityName))
                throw new ArgumentException("Entity name cannot be null or empty", nameof(entityName));

            string relative = type switch
            {
                ImageType.Movie => _settings.UploadsFolderMovies,
                ImageType.Actor => _settings.UploadsFolderActors,
                ImageType.User => _settings.UploadsFolderUsers,
                ImageType.Cinema => _settings.UploadsFolderCinemas,
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };

            var relClean = NormalizeRelativeFolder(relative);
            var physical = Path.Combine(_webRootPath, relClean, entityName);

            if (!Directory.Exists(physical))
                Directory.CreateDirectory(physical);

            return physical;
        }

        private string GetDefaultImageWebPath(ImageType type) => type switch
        {
            ImageType.Movie => $"/{NormalizeRelativeFolder(_settings.DefaultMovieImage).Replace(Path.DirectorySeparatorChar, '/')}",
            ImageType.Actor => $"/{NormalizeRelativeFolder(_settings.DefaultActorImage).Replace(Path.DirectorySeparatorChar, '/')}",
            ImageType.User => $"/{NormalizeRelativeFolder(_settings.DefaultUserImage).Replace(Path.DirectorySeparatorChar, '/')}",
            ImageType.Cinema => $"/{NormalizeRelativeFolder(_settings.DefaultCinemaImage).Replace(Path.DirectorySeparatorChar, '/')}",
            _ => $"/{NormalizeRelativeFolder(_settings.DefaultMovieImage).Replace(Path.DirectorySeparatorChar, '/')}"
        };
        #endregion

        #region Save Image
        public async Task<string> SaveImageAsync(IFormFile file, ImageType type, string entityName, bool setAsMain = false)
        {
            if (!IsValidImageFile(file))
                throw new ArgumentException("Invalid image file", nameof(file));

            var folder = GetFolder(type, entityName);

            // Compute hash for duplicate check
            string newFileHash;
            using (var sha = SHA256.Create())
            using (var stream = file.OpenReadStream())
                newFileHash = BitConverter.ToString(sha.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();

            foreach (var existingFile in Directory.GetFiles(folder))
            {
                try
                {
                    using var fs = new FileStream(existingFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                    using var sha = SHA256.Create();
                    var existingHash = BitConverter.ToString(sha.ComputeHash(fs)).Replace("-", "").ToLowerInvariant();
                    if (existingHash == newFileHash) return Path.GetFileName(existingFile);
                }
                catch { continue; } // ignore locked files
            }

            var extension = Path.GetExtension(file.FileName) ?? "";
            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(folder, fileName);

            await using (var outputStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true))
            {
                await file.CopyToAsync(outputStream);
                await outputStream.FlushAsync();
            }

            // Optional: set main image
            if (setAsMain && type == ImageType.Movie)
            {
                var mainFilePath = Path.Combine(folder, "main" + extension);
                await TryReplaceFileAsync(filePath, mainFilePath);
            }

            return fileName;
        }

        private static async Task TryReplaceFileAsync(string sourcePath, string targetPath)
        {
            try
            {
                if (File.Exists(targetPath)) File.Delete(targetPath);
                File.Copy(sourcePath, targetPath);
            }
            catch (IOException)
            {
                await Task.Delay(50);
                if (File.Exists(targetPath)) File.Delete(targetPath);
                File.Copy(sourcePath, targetPath);
            }
        }
        #endregion

        #region Get Images
        public string[] GetImageFileNames(ImageType type, string entityName)
        {
            var folder = GetFolder(type, entityName);
            var files = Directory.GetFiles(folder).Select(Path.GetFileName).ToArray();
            return files.Length == 0 ? Array.Empty<string>() : files;
        }

        public string GetImageWebPath(ImageType type, string entityName, string? imageName = null)
        {
            var relUploads = type switch
            {
                ImageType.Movie => NormalizeRelativeFolder(_settings.UploadsFolderMovies),
                ImageType.Actor => NormalizeRelativeFolder(_settings.UploadsFolderActors),
                ImageType.User => NormalizeRelativeFolder(_settings.UploadsFolderUsers),
                ImageType.Cinema => NormalizeRelativeFolder(_settings.UploadsFolderCinemas),
                _ => NormalizeRelativeFolder(_settings.UploadsFolderMovies)
            };

            if (!string.IsNullOrEmpty(imageName))
            {
                var physical = Path.Combine(_webRootPath, relUploads, entityName, imageName);
                if (File.Exists(physical))
                    return $"/{Path.Combine(relUploads, entityName, imageName).Replace(Path.DirectorySeparatorChar, '/')}";
            }

            return GetDefaultImageWebPath(type);
        }
        #endregion

        #region Delete
        public bool DeleteFolder(ImageType type, string entityName)
        {
            var folder = GetFolder(type, entityName);
            if (!Directory.Exists(folder)) return false;

            try
            {
                Directory.Delete(folder, true);
                return true;
            }
            catch
            {
                try
                {
                    foreach (var f in Directory.GetFiles(folder)) { try { File.Delete(f); } catch { } }
                    Directory.Delete(folder, true);
                    return true;
                }
                catch { return false; }
            }
        }

        public bool DeleteFile(ImageType type, string entityName, string fileName)
        {
            var folder = GetFolder(type, entityName);
            var path = Path.Combine(folder, fileName);
            if (!File.Exists(path)) return false;

            try { File.Delete(path); return true; }
            catch { Task.Delay(50).Wait(); if (File.Exists(path)) try { File.Delete(path); } catch { } return false; }
        }
        #endregion

        #region Resize
        public async Task<string> ResizeImageAsync(ImageType type, string entityName, string imageName, int width, int height)
        {
            var folder = GetFolder(type, entityName);
            var filePath = Path.Combine(folder, imageName);
            if (!File.Exists(filePath)) throw new FileNotFoundException("Image not found", filePath);

            var resizedFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageName)}";
            var resizedFilePath = Path.Combine(folder, resizedFileName);

            using var image = await Image.LoadAsync(filePath);
            image.Mutate(x => x.Resize(width, height));
            await image.SaveAsync(resizedFilePath);

            return resizedFileName;
        }
        #endregion
    }
}
