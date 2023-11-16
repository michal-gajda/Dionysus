namespace Dionysus.Server.Domain.Purchases.Interfaces;

using Dionysus.Server.Domain.Purchases.Entities;

public interface IOrderRepository
{
    Task AddAsync(Order order, CancellationToken cancellationToken = default);
}
