namespace Dionysus.Server.Application.Purchases.Messages;

using Dionysus.Server.Domain.Purchases.Entities;

public sealed record OrderMessage
{
    public required Guid Id { get; init; }
    public required Order Order { get; init; }
}
