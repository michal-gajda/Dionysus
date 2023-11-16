namespace Dionysus.Server.Application.Purchases.Interfaces;

using Dionysus.Server.Application.Purchases.Messages;

public interface IOrderOutboxRepository
{
    Task AddAsync(OrderMessage message, CancellationToken cancellationToken = default);
    Task<List<OrderMessage>> GetPendingMessagesAsync(CancellationToken cancellationToken = default);
    Task MarkAsProcessedAsync(Guid messageId, CancellationToken cancellationToken = default);
    Task HandleFailureAsync(Guid messageId, string failureReason, CancellationToken cancellationToken = default);
}
