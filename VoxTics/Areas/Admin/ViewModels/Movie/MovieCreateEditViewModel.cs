using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels.Movie
{
    public class MovieCreateEditViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Movie title is required")]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "Director is required")]
        [StringLength(200)]
        public string Director { get; set; } = string.Empty;
        [StringLength(100)]
        public string? Language { get; set; }
        [Range(0.0, 10.0, ErrorMessage = "Rating must be between 0 and 10")]
        public decimal Rating { get; set; }
        [AllowedExtensions(new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" }, ErrorMessage = "Poster must be an image (.jpg/.png/.webp/.gif)")]
        [MaxFileSize(5 * 1024 * 1024, ErrorMessage = "Poster max size is 5 MB")]
        public IFormFile? PosterFile { get; set; }
        public string? PosterImage { get; set; }
        [Url(ErrorMessage = "Trailer must be a valid URL")]
        [StringLength(500)]
        public string? TrailerUrl { get; set; }
        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes")]
        public TimeSpan Duration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsFeatured { get; set; }

        [Required(ErrorMessage = "Base price is required")]
        [Range(0, 9999, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }
        public List<int> SelectedActorIds { get; set; } = new();
        public List<int> SelectedCategoryIds { get; set; } = new();
        [AllowedExtensions(new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" }, ErrorMessage = "Poster must be an image (.jpg/.png/.webp/.gif)")]
        [MaxFileSize(5 * 1024 * 1024, ErrorMessage = "Poster max size is 5 MB")]
        public List<string> ImageUrls { get; set; } = new();

    }
}
