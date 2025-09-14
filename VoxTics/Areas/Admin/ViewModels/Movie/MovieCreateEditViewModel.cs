using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels.Movie
{
    public class MovieCreateEditViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Movie title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Director is required")]
        [StringLength(200, ErrorMessage = "Director name cannot exceed 200 characters")]
        public string Director { get; set; } = string.Empty;

        [Required(ErrorMessage = "Release date is required")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Language is required")]
        [StringLength(50, ErrorMessage = "Language cannot exceed 50 characters")]
        public string Language { get; set; } = "EN";

        [Range(0.0, 10.0, ErrorMessage = "Rating must be between 0 and 10")]
        public decimal Rating { get; set; } = 0;

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes")]
        public int Duration { get; set; } // in minutes

        [Required(ErrorMessage = "Base price is required")]
        [Range(0, 9999, ErrorMessage = "Price must be positive and less than 10,000")]
        public decimal Price { get; set; }

        public bool IsFeatured { get; set; } = false;

        [Url(ErrorMessage = "Trailer URL must be valid")]
        [StringLength(500, ErrorMessage = "Trailer URL cannot exceed 500 characters")]
        public string? TrailerUrl { get; set; }

        // Poster file upload
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "jpg,jpeg,png,gif", ErrorMessage = "Allowed image formats: jpg, jpeg, png, gif")]
        public IFormFile? PosterFile { get; set; }

        [StringLength(500, ErrorMessage = "Poster URL cannot exceed 500 characters")]
        public string? PosterImage { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation/relationships
        [Required(ErrorMessage = "At least one actor must be selected")]
        public List<int> SelectedActorIds { get; set; } = new();

        [Required(ErrorMessage = "At least one category must be selected")]
        public List<int> SelectedCategoryIds { get; set; } = new();

        [MinLength(0)]
        [MaxLength(10, ErrorMessage = "You can upload up to 10 images")]
        public List<IFormFile> GalleryFiles { get; set; } = new();

        [MinLength(0)]
        [MaxLength(10, ErrorMessage = "You can provide up to 10 image URLs")]
        [Url(ErrorMessage = "All image URLs must be valid")]
        public List<string> ImageUrls { get; set; } = new();
    }
}
