namespace Dionysus.Client.Infrastructure.Server;

internal sealed record class ServerOptions
{
    public static readonly string SectionName = "Server";
    public Uri Address { get; init; } = default!;
}
