using AutoMapper;
using System;
using System.Linq;
using VoxTics.Areas.Admin.ViewModels.Actor;
using VoxTics.Models.Entities;

namespace VoxTics.Areas.Admin.AdminProfiles
{
    public class ActorAdminProfile : Profile
    {
        public ActorAdminProfile()
        {
            // Actor -> ActorDetailsViewModel
            CreateMap<Actor, ActorDetailsViewModel>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src =>
                    src.DateOfBirth.HasValue
                        ? DateTime.Today.Year - src.DateOfBirth.Value.Year - (src.DateOfBirth.Value.Date > DateTime.Today.AddYears(-(DateTime.Today.Year - src.DateOfBirth.Value.Year)) ? 1 : 0)
                        : (int?)null))
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Movie.Title)))
                .ForMember(dest => dest.SocialMediaLinks, opt => opt.MapFrom(src => src.SocialMediaLinks.Select(sm => sm.Url)));

            // Actor -> ActorTableViewModel
            CreateMap<Actor, ActorTableViewModel>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src =>
                    src.DateOfBirth.HasValue
                        ? DateTime.Today.Year - src.DateOfBirth.Value.Year - (src.DateOfBirth.Value.Date > DateTime.Today.AddYears(-(DateTime.Today.Year - src.DateOfBirth.Value.Year)) ? 1 : 0)
                        : (int?)null));

            // Actor -> ActorViewModel

            // ActorCreateEditViewModel -> Actor
            CreateMap<ActorCreateEditViewModel, Actor>()
                .ForMember(dest => dest.Bio, opt => opt.MapFrom(src => src.Bio))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}
