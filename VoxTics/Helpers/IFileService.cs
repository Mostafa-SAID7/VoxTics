using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace VoxTics.Helpers
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file, string folder, CancellationToken cancellationToken = default);
        void DeleteFile(string relativePath);
    }

    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<FileService> _logger;
        private readonly string[] _allowed = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        private const long MaxSizeBytes = 5 * 1024 * 1024;

        public FileService(IWebHostEnvironment env, ILogger<FileService> logger)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> SaveFileAsync(IFormFile file, string folder, CancellationToken cancellationToken = default)
        {
            if (file == null || file.Length == 0) return string.Empty;

            // Use ToUpperInvariant for consistency in comparisons
            var ext = Path.GetExtension(file.FileName).ToUpperInvariant();
            if (!_allowed.Contains(ext, StringComparer.OrdinalIgnoreCase))
                throw new InvalidOperationException("Invalid image type.");
            if (file.Length > MaxSizeBytes)
                throw new InvalidOperationException("Image too large.");

            var filename = $"{Guid.NewGuid()}{ext}";
            var uploads = Path.Combine(_env.WebRootPath ?? Path.GetTempPath(), "uploads", folder);
            Directory.CreateDirectory(uploads);

            var full = Path.Combine(uploads, filename);
            try
            {
                using var fs = new FileStream(full, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true);
                await file.CopyToAsync(fs, cancellationToken).ConfigureAwait(false);
                return $"/uploads/{folder}/{filename}";
            }
            catch (IOException ioEx) // Catch specific exception type
            {
                _logger.LogError(ioEx, "FileService SaveFileAsync failed for {FullPath}", full);
                throw;
            }
        }

        public void DeleteFile(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath)) return;

            var trimmed = relativePath.TrimStart('/');
            var full = Path.Combine(_env.WebRootPath ?? Path.GetTempPath(), trimmed.Replace('/', Path.DirectorySeparatorChar));

            try
            {
                if (System.IO.File.Exists(full))
                {
                    System.IO.File.Delete(full);
                }
            }
            catch (IOException ioEx) // Catch specific exception type
            {
                _logger.LogWarning(ioEx, "FileService DeleteFile failed for {FullPath}", full);
            }
            catch (UnauthorizedAccessException uaEx)
            {
                _logger.LogWarning(uaEx, "FileService DeleteFile failed due to permission for {FullPath}", full);
            }
        }
    }
}
