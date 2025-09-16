using AutoMapper;
using System;
using System.Linq;
using VoxTics.Areas.Admin.ViewModels.Actor;
using VoxTics.Areas.Admin.ViewModels.Category;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Models.Entities;

namespace VoxTics.Areas.Admin.AdminProfiles
{
    public class MovieAdminProfile : Profile
    {
        public MovieAdminProfile()
        {
            // Movie -> MovieDetailViewModel
            CreateMap<Movie, MovieDetailViewModel>()
                .ForMember(dest => dest.TrailerUrl, opt => opt.MapFrom(src =>
                    string.IsNullOrEmpty(src.TrailerUrl) ? null : new Uri(src.TrailerUrl)))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.MovieImages.Select(mi => new MovieImageViewModel
                {
                    Id = mi.Id,
                    ImageUrl = string.IsNullOrEmpty(mi.ImageUrl) ? new Uri("about:blank") : new Uri(mi.ImageUrl),
                    AltText = mi.AltText
                })))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.MovieActors.Select(ma => new ActorViewModel
                {
                    Id = ma.Actor.Id,
                    FullName = ma.Actor.FullName
                })))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.MovieCategories.Select(mc => new CategoryViewModel
                {
                    Id = mc.Category.Id,
                    Name = mc.Category.Name
                })))
                .ForMember(dest => dest.ShowtimesCount, opt => opt.MapFrom(src => src.Showtimes.Count))
                .ForMember(dest => dest.BookingsCount, opt => opt.MapFrom(src => src.Showtimes.Sum(st => st.Bookings.Count)));

            // Movie -> MovieListItemViewModel
            CreateMap<Movie, MovieListItemViewModel>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => string.Join(", ", src.MovieCategories.Select(mc => mc.Category.Name))))
                .ForMember(dest => dest.PosterImage, opt => opt.MapFrom(src => src.ImageUrl));

            // Movie -> MovieTableViewModel
            // Movie -> MovieTableViewModel
            CreateMap<Movie, MovieTableViewModel>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => string.Join(", ", src.MovieCategories.Select(mc => mc.Category.Name))))
                .ForMember(dest => dest.ReleaseDateFormatted, opt => opt.MapFrom(src => src.ReleaseDate.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.FormattedPrice, opt => opt.MapFrom(src => src.Price.ToString("0.00")))
                .ForMember(dest => dest.StatusBadge, opt => opt.MapFrom(src =>
                    src.Status == Models.Enums.MovieStatus.Upcoming ? "badge bg-info" :
                    src.Status == Models.Enums.MovieStatus.NowShowing ? "badge bg-success" :
                    src.Status == Models.Enums.MovieStatus.Ended ? "badge bg-secondary" :
                    src.Status == Models.Enums.MovieStatus.Cancelled ? "badge bg-dark" :
                    "badge bg-secondary"))
                .ForMember(dest => dest.FeaturedBadge, opt => opt.MapFrom(src => src.IsFeatured ? "badge bg-warning text-dark" : string.Empty));

            // MovieCreateEditViewModel -> Movie
            CreateMap<MovieCreateEditViewModel, Movie>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.IsFeatured, opt => opt.MapFrom(src => src.IsFeatured))
                .ForMember(dest => dest.TrailerUrl, opt => opt.MapFrom(src => src.TrailerUrl))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.PosterImage))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));
        }
    }
}
