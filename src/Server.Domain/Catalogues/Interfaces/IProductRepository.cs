namespace Dionysus.Server.Domain.Catalogues.Interfaces;

using Dionysus.Server.Domain.Catalogues.Entities;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken cancellationToken = default);
}
