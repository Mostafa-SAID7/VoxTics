using AutoMapper;
using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Cinema;

namespace VoxTics.MappingProfiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            // Admin mapping
            CreateMap<Cinema, CinemaViewModel>()
                .ForMember(dest => dest.ImageFile, opt => opt.Ignore())
                .ReverseMap();

            // Public mapping
            CreateMap<Cinema, CinemaVM>()
                .ForMember(dest => dest.DisplayImage, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.ImageUrl)))
                .ForMember(dest => dest.DisplayImage, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.ImageUrl) ? "/images/default-cinema.jpg" : src.ImageUrl))
                .ReverseMap();
        }
    }
}
