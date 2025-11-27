using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MoviesRental.Query.Application
{
    public static class ApplicationServiceCollection 
    {
        public static IServiceCollection AddQueryApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Scoped);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
