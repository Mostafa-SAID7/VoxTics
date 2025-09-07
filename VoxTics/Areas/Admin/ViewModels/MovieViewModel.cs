using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels
{
    // --- custom validators below (placed in same file for convenience) ---
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxBytes;
        public MaxFileSizeAttribute(int maxBytes) => _maxBytes = maxBytes;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file == null) return ValidationResult.Success;
            return file.Length <= _maxBytes ? ValidationResult.Success :
                new ValidationResult(ErrorMessage ?? $"File size must be <= {_maxBytes / 1024 / 1024} MB");
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensionsAttribute(string[] extensions) => _extensions = extensions;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file == null) return ValidationResult.Success;
            var ext = System.IO.Path.GetExtension(file.FileName).ToLowerInvariant();
            return Array.Exists(_extensions, e => e.Equals(ext, StringComparison.OrdinalIgnoreCase))
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessage ?? $"Allowed extensions: {string.Join(", ", _extensions)}");
        }
    }

    // --- main VM ---
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie title is required")]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes")]
        public int DurationInMinutes { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        // DB required field — make required to avoid null DB writes
        [Required(ErrorMessage = "Director is required")]
        [StringLength(200)]
        public string Director { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Language { get; set; }

        [StringLength(20)]
        public string? Rating { get; set; }

        [Url(ErrorMessage = "Trailer must be a valid URL")]
        [StringLength(500)]
        public string? TrailerUrl { get; set; }

        [Range(0.0, 10.0, ErrorMessage = "IMDB rating must be between 0 and 10")]
        public decimal? ImdbRating { get; set; }

        [Required(ErrorMessage = "Base price is required")]
        [Range(0, 9999, ErrorMessage = "Price must be positive")]
        public decimal BasePrice { get; set; }

        [Required]
        public MovieStatus Status { get; set; } = MovieStatus.Upcoming;

        public bool IsActive { get; set; } = true;

        // Poster image: allow optional, but validate file type + size
        [AllowedExtensions(new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" }, ErrorMessage = "Poster must be an image (.jpg/.png/.webp/.gif)")]
        [MaxFileSize(5 * 1024 * 1024, ErrorMessage = "Poster max size is 5 MB")]
        public IFormFile? PosterImageFile { get; set; }

        public string? CurrentPosterImage { get; set; }

        public List<int> SelectedCategoryIds { get; set; } = new();
        public List<int> SelectedActorIds { get; set; } = new();
        public List<string> CurrentImages { get; set; } = new();

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // presentation collections
        public List<CategoryViewModel> Categories { get; set; } = new();
        public IEnumerable<SelectListItem> AvailableCategories { get; set; } = new List<SelectListItem>();

        public List<string> MovieCategories { get; set; } = new();
        public List<ActorViewModel> MovieActors { get; set; } = new();
        public List<MovieImageViewModel> Images { get; set; } = new();

        public int ShowtimesCount { get; set; }
        public int BookingsCount { get; set; }
    }
}
