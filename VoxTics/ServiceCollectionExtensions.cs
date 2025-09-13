using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VoxTics.Data.UoW;
using VoxTics.MappingProfiles;
using VoxTics.Repositories;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Implementations;
using VoxTics.Services.Interfaces;

namespace VoxTics
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Add services
            services.AddTransient<IEmailSender, EmailSender>();

            // Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            // Add AutoMapper
            

            // Add Helpers 

            return services;
        }
    }
}
