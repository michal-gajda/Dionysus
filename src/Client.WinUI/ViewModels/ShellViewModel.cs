namespace Dionysus.Client.WinUI.ViewModels;

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dionysus.Client.WinUI.Models;
using Dionysus.Client.WinUI.Views;
using MediatR;
using Microsoft.Extensions.Logging;
using MvvmDialogs;

public partial class ShellViewModel : ObservableObject
{
    private readonly IDialogService dialogService;
    private readonly ILogger<ShellViewModel> logger;
    private readonly ISender mediator;

    [ObservableProperty]
    private string title = "Shell View";

    [ObservableProperty]
    private string keyword = string.Empty;

    public ShellViewModel(IDialogService dialogService, ILogger<ShellViewModel> logger, ISender mediator)
    {
        (this.dialogService, this.logger, this.mediator) = (dialogService, logger, mediator);
        this.OkCommand = new AsyncRelayCommand(this.OkCommandAsync);

        this.ExitCommand = new AsyncRelayCommand(this.ExitAsync);

        this.OpenProductCatalogCommand = new AsyncRelayCommand(this.OpenProductCatalogAsync);
        this.OpenPurchaseOrdersCommand = new AsyncRelayCommand(this.OpenPurchaseOrdersAsync);
        this.OpenSalesOrdersCommand = new AsyncRelayCommand(this.OpenSalesOrdersAsync);
    }

    [ObservableProperty]
    private ObservableCollection<Product> items = new();

    [ObservableProperty]
    private Product? selectedItem;

    public IAsyncRelayCommand OkCommand { get; }
    public IAsyncRelayCommand ExitCommand { get; }
    public IAsyncRelayCommand OpenProductCatalogCommand { get; }
    public IAsyncRelayCommand OpenPurchaseOrdersCommand { get; }
    public IAsyncRelayCommand OpenSalesOrdersCommand { get; }

    private async Task ExitAsync(CancellationToken cancellationToken = default)
    {
        System.Windows.Application.Current.Shutdown();

        await Task.CompletedTask;
    }

    private async Task OpenProductCatalogAsync(CancellationToken cancellationToken = default)
    {
        var viewModel = new ProductCatalogViewModel();
        _ = dialogService.ShowDialog<ProductCatalogView>(this, viewModel);

        await Task.CompletedTask;
    }

    private async Task OpenPurchaseOrdersAsync(CancellationToken cancellationToken = default)
    {
        var viewModel = new PurchaseOrdersViewModel(this.mediator);
        _ = dialogService.ShowDialog<PurchaseOrdersView>(this, viewModel);

        await Task.CompletedTask;
    }

    private async Task OpenSalesOrdersAsync(CancellationToken cancellationToken = default)
    {
        var viewModel = new SalesOrdersViewModel();
        _ = dialogService.ShowDialog<SalesOrdersView>(this, viewModel);

        await Task.CompletedTask;
    }

    private async Task OkCommandAsync(CancellationToken cancellationToken = default)
    {
        this.logger.LogInformation("{CommandName}", "OkCommandExecuteAsync");

        this.Items.Add(new Product { Id = Guid.NewGuid() });

        this.Title = $"Shell View - {DateTime.Now.Ticks}";

        await Task.CompletedTask;
    }
}
