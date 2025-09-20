using AutoMapper;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Models.Entities;

namespace VoxTics.Areas.Admin.Profiles
{
    public class AdminMovieProfile : Profile
    {
        public AdminMovieProfile()
        {
            // 🔹 Entity -> ListItem VM
            CreateMap<Movie, MovieListItemViewModel>()
                .ForMember(dest => dest.MainImageUrl, opt => opt.MapFrom(src => src.MainImage))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.ShowtimeCount, opt => opt.MapFrom(src => src.Showtimes.Count));

            // 🔹 Entity -> Detail VM
            CreateMap<Movie, MovieDetailViewModel>()
                .ForMember(dest => dest.MainImageUrl, opt => opt.MapFrom(src => src.MainImage))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            // Create/Edit VM -> Entity
            CreateMap<MovieCreateEditViewModel, Movie>()
                .ForMember(dest => dest.MainImage, opt => opt.Ignore())
                .ForMember(dest => dest.MovieImages, opt => opt.Ignore())
                .ForMember(dest => dest.Slug, opt => opt.Ignore());

            // Entity -> Create/Edit VM (for editing)
            CreateMap<Movie, MovieCreateEditViewModel>()
                .ForMember(dest => dest.MainImage, opt => opt.Ignore())
                .ForMember(dest => dest.ExistingPosterUrl, opt => opt.MapFrom(src => src.MainImage))
                .ForMember(dest => dest.ExistingImageUrls, opt => opt.MapFrom(src => src.MovieImages.Select(mi => mi.ImageUrl).ToList()));
        }
    }
}
