using AutoMapper;
using System.Linq;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Models.Entities;

namespace VoxTics.Areas.Admin.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            // Movie -> MovieListItemViewModel
            CreateMap<Movie, MovieListItemViewModel>()
                .ForMember(dest => dest.PosterImage,
                    opt => opt.MapFrom(src => src.MovieImages.OrderBy(i => i.Id).Select(i => i.ImageUrl).FirstOrDefault()))
                .ForMember(dest => dest.Categories,
                    opt => opt.MapFrom(src => string.Join(", ", src.MovieCategories.Select(mc => mc.Category.Name))))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating));

            // Movie -> MovieDetailViewModel
            CreateMap<Movie, MovieDetailViewModel>()
                .ForMember(d => d.Images, o => o.MapFrom(s =>
                    s.MovieImages.Select(i => new MovieImageViewModel { Id = i.Id, ImageUrl = i.ImageUrl, AltText = i.AltText })))
                .ForMember(d => d.Actors, o => o.MapFrom(s =>
                    s.MovieActors.Select(ma => new ActorViewModel { Id = ma.Actor.Id, FullName = ma.Actor.FullName, Bio = ma.Actor.Bio, ImageUrl = ma.Actor.ImageUrl })))
                .ForMember(d => d.Categories, o => o.MapFrom(s =>
                    s.MovieCategories.Select(mc => new CategoryViewModel { Id = mc.Category.Id, Name = mc.Category.Name, Description = mc.Category.Description })));

            // MovieCreateEditViewModel -> Movie (scalar properties)
            CreateMap<MovieCreateEditViewModel, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore()) // Id handled by service
                .ForMember(m => m.MovieImages, opt => opt.Ignore())
                .ForMember(m => m.MovieActors, opt => opt.Ignore())
                .ForMember(m => m.MovieCategories, opt => opt.Ignore());

            // Movie -> MovieCreateEditViewModel (for Edit page population)
            CreateMap<Movie, MovieCreateEditViewModel>()
                .ForMember(d => d.SelectedActorIds, o => o.MapFrom(s => s.MovieActors.Select(ma => ma.ActorId).ToList()))
                .ForMember(d => d.SelectedCategoryIds, o => o.MapFrom(s => s.MovieCategories.Select(mc => mc.CategoryId).ToList()))
                .ForMember(d => d.ImageUrls, o => o.MapFrom(s => s.MovieImages.Select(i => i.ImageUrl).ToList()));
        }
    }
}
