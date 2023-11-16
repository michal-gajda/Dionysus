﻿namespace Dionysus.Client.Infrastructure;

using Dionysus.Client.Infrastructure.Server;
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

        services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true);

        services.AddServer(configuration);

        return services;
    }
}
