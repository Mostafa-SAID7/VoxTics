using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MovieTickets.Repositories.Implementations;
using MovieTickets.Repositories.Interfaces;
using System;
using VoxTics.Repositories.Implementations;

namespace MovieTickets.Repositories
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers repository services using safe defaults (Scoped).
        /// Use this in Program.cs: services.AddRepositories();
        /// </summary>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Generic repository - use TryAdd to avoid duplicate registrations
            services.TryAddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // Concrete repositories (recommended lifetime: Scoped)
            services.TryAddScoped<IMovieRepository, MovieRepository>();
            services.TryAddScoped<ICategoryRepository, CategoryRepository>();
            services.TryAddScoped<ICinemaRepository, CinemaRepository>();
            services.TryAddScoped<IBookingRepository, BookingRepository>();
            services.TryAddScoped<IShowtimeRepository, ShowtimeRepository>();
            services.TryAddScoped<IUserRepository, UserRepository>();

            return services;
        }

        /// <summary>
        /// Registers repositories with a requested lifetime.
        /// NOTE: Singleton is strongly discouraged if repos depend on DbContext (which is Scoped).
        /// Allowed lifetimes: Scoped (recommended), Transient.
        /// Passing Singleton will throw to avoid lifetime mismatch bugs.
        /// </summary>
        public static IServiceCollection AddRepositories(this IServiceCollection services, ServiceLifetime lifetime)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            if (lifetime == ServiceLifetime.Singleton)
            {
                throw new InvalidOperationException("Registering repositories as Singleton is unsafe when they depend on a scoped DbContext. Use Scoped or Transient.");
            }

            // register generic
            ServiceDescriptor genericDescriptor = new ServiceDescriptor(typeof(IBaseRepository<>), typeof(BaseRepository<>), lifetime);
            services.TryAddEnumerable(new[] { genericDescriptor });

            // helper local to register by lifetime
            void Reg<TInterface, TImpl>() where TImpl : class where TInterface : class
            {
                var descriptor = new ServiceDescriptor(typeof(TInterface), typeof(TImpl), lifetime);
                services.TryAddEnumerable(new[] { descriptor });
            }

            Reg<IMovieRepository, MovieRepository>();
            Reg<ICategoryRepository, CategoryRepository>();
            Reg<ICinemaRepository, CinemaRepository>();
            Reg<IBookingRepository, BookingRepository>();
            Reg<IShowtimeRepository, ShowtimeRepository>();
            Reg<IUserRepository, UserRepository>();

            return services;
        }
    }
}
