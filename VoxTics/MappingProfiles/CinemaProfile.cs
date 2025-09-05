using AutoMapper;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;

namespace VoxTics.MappingProfiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<Cinema, CinemaViewModel>().ReverseMap();
            CreateMap<Cinema, CinemaVM>();
        }
    }
}
