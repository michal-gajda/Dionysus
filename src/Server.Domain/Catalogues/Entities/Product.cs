namespace Dionysus.Server.Domain.Catalogues.Entities;

public sealed class Product
{
    public required ProductId Id {get; init;}
    public required string Name {get; init;}
}
