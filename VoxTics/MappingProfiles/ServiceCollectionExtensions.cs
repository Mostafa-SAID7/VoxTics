using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace VoxTics.MappingProfiles
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
            // services.AddAutoMapper(typeof(BookingProfile));
            //services.AddAutoMapper(typeof(CategoryProfile));
            //services.AddAutoMapper(typeof(CinemaProfile));
            //services.AddAutoMapper(typeof(MovieProfile));
            //services.AddAutoMapper(typeof(ShowtimeProfile));
            //services.AddAutoMapper(typeof(UserProfile));

            return services;
        }
    }
}
