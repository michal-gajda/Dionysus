namespace Dionysus.Server.Domain.Catalogues.Interfaces;

using Dionysus.Server.Domain.Catalogues.Entities;

public interface IContractorRepository
{
    Task AddAsync(Contractor contractor, CancellationToken cancellationToken = default);
}
