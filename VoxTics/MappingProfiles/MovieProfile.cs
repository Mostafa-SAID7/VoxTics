using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;

namespace VoxTics.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            // Entity to ViewModel mappings
            CreateMap<Movie, MovieVM>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src =>
                    src.MovieCategories.Select(mc => mc.Category)))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src =>
                    src.MovieActors.Select(ma => ma.Actor)))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.MovieImages));

            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.MovieCategories, opt => opt.MapFrom(src =>
                    src.MovieCategories.Select(mc => mc.Category)))
                .ForMember(dest => dest.MovieActors, opt => opt.MapFrom(src =>
                    src.MovieActors.Select(ma => ma.Actor)))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.MovieImages))
                .ForMember(dest => dest.ShowtimesCount, opt => opt.MapFrom(src => src.Showtimes.Count))
                .ForMember(dest => dest.BookingsCount, opt => opt.MapFrom(src =>
                    src.Showtimes.SelectMany(s => s.Bookings).Count()));

            CreateMap<Actor, ActorVM>();
            CreateMap<Actor, ActorViewModel>();
            CreateMap<MovieImg, MovieImageVM>();
            CreateMap<MovieImg, MovieImageViewModel>();

            // ViewModel to Entity mappings
            CreateMap<MovieViewModel, Movie>()
                .ForMember(dest => dest.MovieCategories, opt => opt.Ignore())
                .ForMember(dest => dest.MovieActors, opt => opt.Ignore())
                .ForMember(dest => dest.MovieImages, opt => opt.Ignore())
                .ForMember(dest => dest.Showtimes, opt => opt.Ignore());
        }
    }
    }