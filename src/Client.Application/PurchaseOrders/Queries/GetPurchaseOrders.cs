namespace Dionysus.Client.Application.PurchaseOrders.Queries;

using Dionysus.Client.Application.PurchaseOrders.ViewModels;

public sealed record GetPurchaseOrders : IRequest<IEnumerable<PurchaseOrder>>
{
    public uint PageNumber { get; init; } = 0;
    public uint PageSize { get; init; } = 25;
}
