using AutoMapper;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;

namespace VoxTics.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // Entity → ViewModel
            CreateMap<Category, CategoryVM>()
                .ForMember(dest => dest.MovieCount, opt => opt.MapFrom(src => src.MovieCategories.Count))
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.MovieCategories.Select(mc => mc.Movie)));

            // Movie → MovieVM mapping must exist
            CreateMap<Movie, MovieVM>();
        }
    }
}
