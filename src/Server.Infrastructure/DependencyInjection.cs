namespace Dionysus.Server.Infrastructure;

using Dionysus.Server.Infrastructure.MassTransit;
using Dionysus.Server.Infrastructure.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });
        services.AddMassTransit(configuration);

        services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true);

        services.AddHostedService<OrderOutboxService>();

        return services;
    }
}
