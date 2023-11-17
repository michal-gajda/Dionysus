namespace Dionysus.Client.Infrastructure.Server.QueryHandlers;

using Dionysus.Client.Application.PurchaseOrders.Queries;
using Dionysus.Client.Application.PurchaseOrders.ViewModels;

internal sealed class GetPurchaseOrdersHandler : IRequestHandler<GetPurchaseOrders, IEnumerable<PurchaseOrder>>
{
    public async Task<IEnumerable<PurchaseOrder>> Handle(GetPurchaseOrders request, CancellationToken cancellationToken)
    {
        var orders = new List<PurchaseOrder>();

        var order = new PurchaseOrder
        {
            Id = "1",
            Name = "One",
            SupplierId = "BMW",
            SupplyDate = new DateOnly(2023, 11, 20),
        };

        orders.Add(order);

        return await Task.FromResult(orders);
    }
}
