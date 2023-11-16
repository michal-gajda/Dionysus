namespace Dionysus.Server.Domain.Catalogues.Interfaces;

using Dionysus.Server.Domain.Catalogues.Entities;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
}
