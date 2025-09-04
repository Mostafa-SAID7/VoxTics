using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;

namespace VoxTics.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            // Entity -> Public VM (Frontend)
            CreateMap<Movie, MovieVM>()
                .ForMember(dest => dest.Categories, opt =>
                    opt.MapFrom(src => src.MovieCategories != null
                        ? src.MovieCategories.Select(mc => mc.Category.Name)
                        : new List<string>()))
                .ForMember(dest => dest.Actors, opt =>
                    opt.MapFrom(src => src.MovieActors != null
                        ? src.MovieActors.Select(ma => ma.Actor.FullName)
                        : new List<string>()))
                .ForMember(dest => dest.ImageUrl, opt =>
                    opt.MapFrom(src => src.Images != null && src.Images.Any()
                        ? src.Images.First().ImageUrl
                        : null));

            // Entity -> Admin VM
            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.SelectedCategoryIds, opt =>
                    opt.MapFrom(src => src.MovieCategories != null
                        ? src.MovieCategories.Select(mc => mc.CategoryId)
                        : new List<int>()))
                .ForMember(dest => dest.ImageUrl, opt =>
                    opt.MapFrom(src => src.Images != null && src.Images.Any()
                        ? src.Images.First().ImageUrl
                        : null));

            // Admin VM -> Entity
            CreateMap<MovieViewModel, Movie>()
                // don’t map MovieCategories directly, handled in service/controller
                .ForMember(dest => dest.MovieCategories, opt => opt.Ignore())
                // don’t map MovieActors directly here
                .ForMember(dest => dest.MovieActors, opt => opt.Ignore())
                // don’t map Images directly, handled separately
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                // conditional mapping: only overwrite if value present
                .ForMember(dest => dest.Title, opt =>
                    opt.Condition(src => !string.IsNullOrWhiteSpace(src.Title)))
                .ForMember(dest => dest.Description, opt =>
                    opt.Condition(src => !string.IsNullOrWhiteSpace(src.Description)))
                .ForMember(dest => dest.Price, opt =>
                    opt.Condition(src => src.Price > 0))
                .ForMember(dest => dest.Duration, opt =>
                    opt.Condition(src => src.Duration > 0))
                .ForMember(dest => dest.ReleaseDate, opt =>
                    opt.Condition(src => src.ReleaseDate != default));
        }
    }
}
