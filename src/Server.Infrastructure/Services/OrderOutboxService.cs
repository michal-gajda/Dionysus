namespace Dionysus.Server.Infrastructure.Services;

using Dionysus.Server.Application.Purchases.Interfaces;
using Dionysus.Server.Application.Purchases.Messages;
using Dionysus.Server.Domain.Purchases.Interfaces;
using global::MassTransit;

internal sealed class OrderOutboxService : Microsoft.Extensions.Hosting.BackgroundService
{
    private readonly ILogger<OrderOutboxService> logger;
    private readonly IPublisher mediator;
    private readonly IOrderRepository orderRepository;
    private readonly IOrderOutboxRepository outboxRepository;

    public OrderOutboxService(ILogger<OrderOutboxService> logger, IPublisher mediator, IOrderRepository orderRepository, IOrderOutboxRepository outboxRepository)
    {
        this.logger = logger;
        this.mediator = mediator;
        this.orderRepository = orderRepository;
        this.outboxRepository = outboxRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var messages = await this.outboxRepository.GetPendingMessagesAsync(stoppingToken);

        foreach (var message in messages)
        {
            try
            {
                await this.orderRepository.AddAsync(message.Order, stoppingToken);
                await this.outboxRepository.MarkAsProcessedAsync(message.Id, stoppingToken);
            }
            catch (Exception exception)
            {
                this.logger.LogWarning("{Message}", exception.Message);
                await this.outboxRepository.HandleFailureAsync(message.Id, exception.Message, stoppingToken);
            }
        }
    }
}
