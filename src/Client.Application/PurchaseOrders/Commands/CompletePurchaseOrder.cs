namespace Dionysus.Client.Application.PurchaseOrders.Commands;

public sealed record CompletePurchaseOrder : IRequest
{
    public required string Id { get; init; }
}
