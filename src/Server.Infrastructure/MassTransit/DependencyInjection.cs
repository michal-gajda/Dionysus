namespace Dionysus.Server.Infrastructure.MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using global::MassTransit;

internal static class DependencyInjection
{
    public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(cfg =>
        {
            
        });
        
        return services;
    }
}