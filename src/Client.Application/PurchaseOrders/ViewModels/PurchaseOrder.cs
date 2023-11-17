namespace Dionysus.Client.Application.PurchaseOrders.ViewModels;

public sealed record PurchaseOrder
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string SupplierId { get; set; } = string.Empty;
    public DateOnly? SupplyDate { get; set; } = default;
}
