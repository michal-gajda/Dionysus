namespace Dionysus.Server.Application.Purchases.CommandHandlers;

using Dionysus.Server.Application.Purchases.Commands;
using Dionysus.Server.Application.Purchases.Interfaces;
using Dionysus.Server.Application.Purchases.Messages;
using Dionysus.Server.Domain.Purchases.Entities;

internal sealed class CreateOrderHandler : IRequestHandler<CreateOrder>
{
    private readonly ILogger<CreateOrderHandler> logger;
    private readonly IOrderOutboxRepository repository;

    public CreateOrderHandler(ILogger<CreateOrderHandler> logger, IOrderOutboxRepository repository)
        => (this.logger, this.repository) = (logger, repository);

    public async Task Handle(CreateOrder request, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Creating order for {ProductId}", request.ProductId);

        var orderMessageId = Guid.NewGuid();

        var message = new OrderMessage
        {
            Id = orderMessageId,
            Order = new Order
            {
                ProductId = new(request.ProductId),
                Quantity = request.Quantity,
            },
        };

        await this.repository.AddAsync(message, cancellationToken);
    }
}
