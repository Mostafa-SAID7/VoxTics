using AutoMapper;
using VoxTics.Models.Entities;
using System.Linq;
using VoxTics.Areas.Admin.ViewModels.Movie;

namespace VoxTics.Areas.Admin.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            // Movie -> MovieViewModel
            CreateMap<Movie, MovieViewModel>()
                .ForMember(d => d.CurrentPosterImage, opt => opt.MapFrom(s => s.ImageUrl))
                .ForMember(d => d.SelectedCategoryIds, opt => opt.MapFrom(s => s.MovieCategories.Select(mc => mc.CategoryId)))
                .ForMember(d => d.MovieCategories, opt => opt.MapFrom(s => s.MovieCategories.Select(mc => mc.Category.Name)))
                .ForMember(d => d.BasePrice, opt => opt.MapFrom(s => s.Price))
                .PreserveReferences()
                .MaxDepth(2);

            // MovieViewModel -> Movie (ignore relations managed by repo)
            CreateMap<MovieViewModel, Movie>()
     .ForMember(d => d.MovieCategories, opt => opt.Ignore())
     .ForMember(d => d.MovieActors, opt => opt.Ignore())
     .ForMember(d => d.MovieImages, opt => opt.Ignore())
     .ForMember(d => d.Showtimes, opt => opt.Ignore())
     .ForMember(d => d.TrailerUrl, opt => opt.Ignore())
     // Prevent overwriting destination with null source values
     .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
