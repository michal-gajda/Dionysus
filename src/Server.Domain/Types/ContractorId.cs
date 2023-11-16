namespace Dionysus.Server.Domain.Types;

public record struct ContractorId
{
    public ContractorId(Guid value) => this.Value = value;

    public Guid Value { get; init; }
}
