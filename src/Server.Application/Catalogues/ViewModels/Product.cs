namespace Dionysus.Server.Application.Catalogues.ViewModels;

public sealed record class Product
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}
