namespace Dionysus.Server.Application.Purchases.Commands;

public sealed record CreateOrder : IRequest
{
    public required Guid ProductId { get; init; }
    public required int Quantity { get; init; }
}
