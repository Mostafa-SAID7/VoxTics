using AutoMapper;
using System.Linq;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Movie;
using VoxTics.Models.ViewModels.Actor;
using VoxTics.Models.ViewModels.Category;

namespace VoxTics.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            // -------- Movie → MovieDetailsVM --------
            CreateMap<Movie, MovieDetailsVM>()
                .ForMember(dest => dest.Cast, opt => opt.MapFrom(src =>
                    src.MovieActors.Select(ma => new ActorVM
                    {
                        Id = ma.Actor.Id,
                        FullName = ma.Actor.FullName,
                        ImageUrl = ma.Actor.ImageUrl
                    }).ToList()))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src =>
                    src.MovieCategories.Select(mc => new CategoryVM
                    {
                        Id = mc.Category.Id,
                        Name = mc.Category.Name,
                        Slug = mc.Category.Slug
                    }).ToList()))
                .ForMember(dest => dest.GalleryImages, opt => opt.MapFrom(src =>
                    src.MovieImages.Select(mi => mi.ImageUrl).ToList()))
                .ForMember(dest => dest.Showtimes, opt => opt.MapFrom(src => src.Showtimes));

            // -------- Movie → MovieVM (preview/list) --------
            CreateMap<Movie, MovieVM>()
                .ForMember(dest => dest.PosterImage, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating.ToString("0.0")))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src =>
                    src.MovieCategories.Select(mc => mc.Category.Name).ToList()))
                .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src =>
                    string.Join(", ", src.MovieCategories.Select(mc => mc.Category.Name))));
        }
    }
}
