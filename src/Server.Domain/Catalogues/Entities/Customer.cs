namespace Dionysus.Server.Domain.Catalogues.Entities;

public sealed class Customer
{
    public required CustomerId Id {get; init;}
    public required string Name {get; init;}
}
