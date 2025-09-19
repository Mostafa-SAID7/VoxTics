using AutoMapper;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Actor;

namespace VoxTics.MappingProfiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            // Actor -> ActorVM (lightweight list view)
            CreateMap<Actor, ActorVM>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.ImageUrl,
                           opt => opt.MapFrom(src => src.ImageUrl));

            // Actor -> ActorDetailsVM (detailed view)
            CreateMap<Actor, ActorDetailsVM>()
              
                .ForMember(dest => dest.LastName,
                           opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Age,
                           opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.ImageUrl,
                           opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.DateOfBirth,
                           opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Bio,
                           opt => opt.MapFrom(src => src.Bio))
                // CharacterName and IsLeadRole might come from MovieActor or another relationship
                .ForMember(dest => dest.CharacterName,
                           opt => opt.Ignore())
                .ForMember(dest => dest.IsLeadRole,
                           opt => opt.Ignore());

            // If you need reverse mapping for create/edit scenarios:
            CreateMap<ActorDetailsVM, Actor>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => src.FullName))
               
                .ForMember(dest => dest.ImageUrl,
                           opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.DateOfBirth,
                           opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Bio,
                           opt => opt.MapFrom(src => src.Bio))
                // Ignore navigation collections when mapping back to entity
                .ForMember(dest => dest.MovieActors,
                           opt => opt.Ignore())
                .ForMember(dest => dest.SocialMediaLinks,
                           opt => opt.Ignore());
        }
    }
}
