using AutoMapper;
using MovieTickets.Areas.Admin.ViewModels;
using MovieTickets.Models.ViewModels;
using MovieTickets.Models.Entities;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace VoxTics.MappingProfiles
{
    

    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieVM>()
                .ForMember(dest => dest.PosterUrl, opt => opt.MapFrom(src => src.MovieImgs.OrderBy(i => i.Id).FirstOrDefault().ImgUrl))
                .ForMember(dest => dest.ExistingImages, opt => opt.MapFrom(src => src.MovieImgs.Select(i => i.ImgUrl)))
                .ForMember(dest => dest.ActorNames, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor != null ? ma.Actor.Name : string.Empty)));

            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.ExistingPosterUrl, opt => opt.MapFrom(src => src.MovieImgs.OrderBy(i => i.Id).FirstOrDefault().ImgUrl))
                .ForMember(dest => dest.ExistingImages, opt => opt.MapFrom(src => src.MovieImgs.Select(i => new MovieImgDto { Id = i.Id, ImgUrl = i.ImgUrl })))
                .ForMember(dest => dest.SelectedActorIds, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.ActorId)));
        }
    }
}
