using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesRental.Application.Contracts;
using MoviesRental.Infrastructure.Context;
using MoviesRental.Infrastructure.Repositories;

namespace MoviesRental.Infrastructure
{
    public static class InfrastructureServiceCollection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<MoviesRentalWriteContext>();
            services.AddScoped<IDirectorsWriteRepository, DirectorsWriteRepository>();
            services.AddScoped<IDvdsWriteRepository, DvdsWriteRepository>();

            return services;
        }
    }
}
