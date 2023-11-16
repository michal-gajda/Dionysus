namespace Dionysus.Server.Application;

using Dionysus.Server.Application.Common.Interfaces;
using Dionysus.Server.Application.Common.Services;
using Dionysus.Server.Application.Shared.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });

        services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}
