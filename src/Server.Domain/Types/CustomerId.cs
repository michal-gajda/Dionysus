namespace Dionysus.Server.Domain.Types;

public record struct CustomerId
{
    public CustomerId(Guid value) => this.Value = value;

    public Guid Value { get; init; }
}
