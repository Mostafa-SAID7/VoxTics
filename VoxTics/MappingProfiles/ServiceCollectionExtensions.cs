using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace VoxTics.MappingProfiles
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
