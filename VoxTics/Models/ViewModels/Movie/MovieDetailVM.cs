using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels.Actor;
using VoxTics.Models.ViewModels.Booking;
using VoxTics.Models.ViewModels.Category;
using VoxTics.Models.ViewModels.Showtime;

namespace VoxTics.Models.ViewModels.Movie
{
    public class MovieDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public decimal? Rating { get; set; }
        public string Language { get; set; } = "EN";
        public string? Country { get; set; }

        // Images
        public string MainImageUrl { get; set; } = string.Empty;
        public string? TrailerUrl { get; set; }
        public List<MovieImgVM> VariantImages { get; set; } = new();

        // Related
        public CategoryVM? Category { get; set; }
        public int CinemaId { get; set; }
        public List<ActorVM> Actors { get; set; } = new();
        public List<ShowtimeVM> Showtimes { get; set; } = new();
        //Booking input
    }
}