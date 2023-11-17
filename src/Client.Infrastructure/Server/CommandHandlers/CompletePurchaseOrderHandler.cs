namespace Dionysus.Client.Infrastructure.Server.CommandHandlers;

using Dionysus.Client.Application.PurchaseOrders.Commands;

internal sealed class CompletePurchaseOrderHandler : IRequestHandler<CompletePurchaseOrder>
{
    private readonly ILogger<CompletePurchaseOrderHandler> logger;

    public CompletePurchaseOrderHandler(ILogger<CompletePurchaseOrderHandler> logger)
        => (this.logger) = (logger);

    public async Task Handle(CompletePurchaseOrder request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}
