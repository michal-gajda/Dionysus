namespace Dionysus.Client.Infrastructure.Server.Services;

using Dionysus.Client.Infrastructure.Server.Interfaces;
using Microsoft.Extensions.Logging;

internal sealed class ServerService : IServerService
{
    private readonly ILogger<ServerService> logger;
    private readonly ServerOptions options;

    public ServerService(ILogger<ServerService> logger, ServerOptions options)
        => (this.logger, this.options) = (logger, options);
}
