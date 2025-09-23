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
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required"), MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required"), MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Director is required"), MaxLength(100)]
        public string Director { get; set; } = string.Empty;

        [Required(ErrorMessage = "Release date is required"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Required, Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes.")]
        public int Duration { get; set; }

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Range(0.0, 10.0, ErrorMessage = "Rating must be between 0 and 10.")]
        public decimal? Rating { get; set; }

        [Required, StringLength(20, ErrorMessage = "Language cannot exceed 20 characters.")]
        public string Language { get; set; } = "EN";

        [StringLength(50, ErrorMessage = "Country cannot exceed 50 characters.")]
        public string? Country { get; set; }

        [Display(Name = "Main Poster")]
        public IFormFile? MainImage { get; set; }

        public string? ExistingPosterUrl { get; set; }

        [Url(ErrorMessage = "Invalid trailer URL.")]
        public string? TrailerUrl { get; set; }

        public bool IsFeatured { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public MovieStatus Status { get; set; } = MovieStatus.Upcoming;

        [Required(ErrorMessage = "Slug is required"), MaxLength(150)]
        public string Slug { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
        public List<SelectListItem>? Categories { get; set; }

        [Display(Name = "Upload Additional Images")]
        public List<IFormFile>? AdditionalImages { get; set; }

        public List<string> ExistingImageUrls { get; set; } = new();
        
    }
}
