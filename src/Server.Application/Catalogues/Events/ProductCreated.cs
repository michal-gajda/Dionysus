using MediatR;

namespace Dionysus.Server.Application.Catalogues.Events;

public sealed record class ProductCreated : INotification
{
    public required ProductId Id { get; init; }
}
