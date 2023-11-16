namespace Dionysus.Server.Domain.Purchases.Entities;

public sealed class Order
{
    public required ProductId ProductId { get; init; }
    public required int Quantity { get; init; }
}
