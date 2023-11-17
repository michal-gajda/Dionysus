namespace Dionysus.Client.WinUI.ViewModels;

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dionysus.Client.Application.PurchaseOrders.Commands;
using Dionysus.Client.Application.PurchaseOrders.Queries;
using Dionysus.Client.Application.PurchaseOrders.ViewModels;
using MvvmDialogs;

public partial class PurchaseOrdersViewModel : ObservableObject, IModalDialogViewModel
{
    private readonly ISender mediator;

    public PurchaseOrdersViewModel(ISender mediator)
    {
        (this.mediator) = (mediator);

        this.CompleteOrderCommand = new AsyncRelayCommand<PurchaseOrder?>(this.CompleteOrderAsync, this.CanExecuteCompleteOrder);
        this.LoadSalesOrdersCommand = new AsyncRelayCommand(this.LoadSalesOrdersAsync);
    }

    public bool? DialogResult { get; } = true;

    [ObservableProperty]
    private ObservableCollection<PurchaseOrder> items = new();

    [ObservableProperty]
    private PurchaseOrder? selectedItem = null;

    public IAsyncRelayCommand<PurchaseOrder?> CompleteOrderCommand { get; }
    public IAsyncRelayCommand LoadSalesOrdersCommand { get; }

    private bool CanExecuteCompleteOrder(PurchaseOrder? parameter) => parameter is not null;

    private async Task CompleteOrderAsync(PurchaseOrder? parameter, CancellationToken cancellationToken = default)
    {
        if (parameter is null)
        {
            return;
        }

        var command = new CompletePurchaseOrder { Id = parameter.Id, };
        await this.mediator.Send(command, cancellationToken);

        await Task.CompletedTask;
    }

    private async Task LoadSalesOrdersAsync(CancellationToken cancellationToken = default)
    {
        var orders = await this.mediator.Send(new GetPurchaseOrders { }, cancellationToken);

        foreach (var order in orders)
        {
            this.Items.Add(order);
        }

        await Task.CompletedTask;
    }
}
