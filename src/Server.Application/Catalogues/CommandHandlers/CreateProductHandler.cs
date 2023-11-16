namespace Dionysus.Server.Application.Catalogues.CommandHandlers;

using Dionysus.Server.Application.Catalogues.Commands;
using Dionysus.Server.Application.Catalogues.Events;
using Dionysus.Server.Domain.Catalogues.Entities;
using Dionysus.Server.Domain.Catalogues.Interfaces;

internal sealed class CreateProductHandler : IRequestHandler<CreateProduct>
{
    private readonly ILogger<CreateProductHandler> logger;
    private readonly IPublisher mediator;
    private readonly IProductRepository repository;

    public CreateProductHandler(ILogger<CreateProductHandler> logger, IPublisher mediator, IProductRepository repository)
        => (this.logger, this.mediator, this.repository) = (logger, mediator, repository);

    public async Task Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Creating product {ProductId} with name {Name}", request.Id, request.Name);

        var entity = new Product
        {
            Id = new(request.Id),
            Name = request.Name,
        };

        await this.repository.AddAsync(entity, cancellationToken);

        var @event = new ProductCreated
        {
            Id = entity.Id,
        };

        await this.mediator.Publish(@event, cancellationToken);
    }
}
