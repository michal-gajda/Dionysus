namespace Dionysus.Client.Infrastructure.Server;

using Dionysus.Client.Infrastructure.Server.Interfaces;
using Dionysus.Client.Infrastructure.Server.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class DependencyInjection
{
    public static void AddServer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<ServerOptions>(ServerOptions.SectionName).ValidateOnStart();

        var options = configuration.GetSection(ServerOptions.SectionName).Get<ServerOptions>();
        options ??= new ServerOptions();
        services.AddSingleton<ServerOptions>(options);

        services.AddSingleton<IServerService, ServerService>();
    }
}
