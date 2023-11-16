namespace Dionysus.Server.Application.Catalogues.Commands;

public sealed record class CreateProduct : IRequest
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}
