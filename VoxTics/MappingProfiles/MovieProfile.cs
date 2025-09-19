using AutoMapper;
using System.Linq;
using VoxTics.Helpers.ImgsHelper;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Movie;
using VoxTics.Models.ViewModels.Actor;
using VoxTics.Models.ViewModels.Category;
using VoxTics.Models.ViewModels.Showtime;

namespace VoxTics.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            // Movie -> MovieVM (لـ Index)
            CreateMap<Movie, MovieVM>()
                .ForMember(dest => dest.MainImageUrl,
                           opt => opt.MapFrom(src => src.MainImage ?? string.Empty))
                .ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty));

            // Movie -> MovieDetailsVM (لـ Details)
            CreateMap<Movie, MovieDetailsVM>()
                .ForMember(dest => dest.MainImageUrl,
                           opt => opt.MapFrom(src => src.MainImage ?? string.Empty))
                .ForMember(dest => dest.TrailerUrl,
                           opt => opt.MapFrom(src => src.TrailerUrl))
                .ForMember(dest => dest.Category,
                           opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Actors,
                           opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor)))
                .ForMember(dest => dest.Showtimes,
                           opt => opt.MapFrom(src => src.Showtimes))
           .ForMember(dest => dest.CinemaId,
    opt => opt.MapFrom(src =>
        src.Showtimes.FirstOrDefault() != null
            ? src.Showtimes.FirstOrDefault().CinemaId
            : 0));

            // MovieActor -> ActorVM
            CreateMap<MovieActor, ActorVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Actor.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Actor.FullName))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Actor.ImageUrl));

            // Category -> CategoryVM
            CreateMap<Category, CategoryVM>();

            // Showtime -> ShowtimeVM
            CreateMap<Showtime, ShowtimeVM>();
        }
    }
}
