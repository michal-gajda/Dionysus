namespace Dionysus.Server.Application.Catalogues.Queries;

using Dionysus.Server.Application.Catalogues.ViewModels;

public sealed record GetProducts : IRequest<IReadOnlyList<Product>>
{
    public required string Keyword { get; init; }
}
